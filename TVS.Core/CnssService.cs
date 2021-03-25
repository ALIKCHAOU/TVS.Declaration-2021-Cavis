using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TVS.Core.Enums;
using TVS.Core.Interfaces;
using TVS.Core.Models;


namespace TVS.Core
{
    public class CnssService
    {
        private readonly ICategorieRepository _categorieRepository;
        private readonly IDeclarationCnssRepository _declarationCnssRepository;
        private readonly ILigneCnssRepository _ligneCnssRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public CnssService(ICategorieRepository categorieRepository,
            IDeclarationCnssRepository declarationCnssRepository,
            ILigneCnssRepository ligneCnssRepository,
            IEmployeeRepository employeeRepository)
        {
            if (categorieRepository == null) throw new ArgumentNullException(nameof(categorieRepository));
            if (declarationCnssRepository == null) throw new ArgumentNullException(nameof(declarationCnssRepository));
            if (ligneCnssRepository == null) throw new ArgumentNullException(nameof(ligneCnssRepository));
            if (employeeRepository == null) throw new ArgumentNullException(nameof(employeeRepository));
            _categorieRepository = categorieRepository;
            _declarationCnssRepository = declarationCnssRepository;
            _ligneCnssRepository = ligneCnssRepository;
            _employeeRepository = employeeRepository;
        }

        public DeclarationService DeclarationService { get; internal set; }

        private Exercice Exercice
        {
            get { return DeclarationService.Exercice; }
        }

        private Societe Societe
        {
            get { return DeclarationService.Societe; }
        }

        #region Categorie Cnss

        public int CategorieCreate(int no,
            string intitule,
            string codeExploitation,
            decimal tauxPatronal,
            decimal tauxSalarial,
            decimal tauxAccident,
            TypeVariablePaie typeVariable,
            string codePaie)
        {
            var categorie = new CategorieCnss
            {
                Intitule = intitule,
                SocieteNo = DeclarationService.Societe.Id,
                No = no,
                TauxPatronal = tauxPatronal,
                TauxSalarial = tauxSalarial,
                AccidentTravail = tauxAccident,
                CodeExploitation = codeExploitation,
                TypeVariablePaie = typeVariable,
                CodePaie = codePaie
            };
            return _categorieRepository.Create(categorie);
        }

        public void CategorieCnssDelete(int id)
        {
            // to do : verifier si la categorie est deja utilisé
            var categorie = _categorieRepository.GetCategorie(id);
            if (categorie == null) throw new ArgumentNullException("categorie");
            if (_ligneCnssRepository.ExistCategorieHasLigne(id))
                throw new InvalidOperationException("Opération invalide!");
            _categorieRepository.Delete(categorie);
        }

        public void CategorieCnssUpdate(int id,
            string intitule,
            string codeExploitation,
            decimal tauxPatronal,
            decimal tauxSalarial,
            decimal tauxAccident,
            TypeVariablePaie typeVariable,
            string codePaie)
        {
            // checked intitule
            if (string.IsNullOrEmpty(intitule)) throw new InvalidOperationException("Intitule catégorie invalide!");
            CategorieCnss categorie = _categorieRepository.GetCategorie(id);
            if (categorie == null) throw new InvalidOperationException("Catégorie n'est pas existe!");

            categorie.Intitule = intitule;
            categorie.CodeExploitation = codeExploitation;
            categorie.TauxPatronal = tauxPatronal;
            categorie.TauxSalarial = tauxSalarial;
            categorie.AccidentTravail = tauxAccident;
            categorie.TypeVariablePaie = typeVariable;
            categorie.CodePaie = codePaie;
            _categorieRepository.Update(categorie);
        }

        public IEnumerable<CategorieCnss> GetAllCategories()
        {
            return _categorieRepository.GetAllCategories(DeclarationService.Societe.Id);
        }

        #endregion Categorie Cnss

        #region Declaration

        public DeclarationCnss DeclarationGet(int no)
        {
            return _declarationCnssRepository.GetDeclaration(no);
        }
        public DeclarationCnss DeclarationGetCnss(int no)
        {
            return _declarationCnssRepository.GetDeclaration(no);
        }
        public IEnumerable<DeclarationCnss> GetDeclarationByTrimestre(int trimestre, int exerciceNo, int trimestreF, int exerciceNoF)
        {
            return _declarationCnssRepository.GetDeclarationByTrimestre(trimestre , exerciceNo, trimestreF,  exerciceNoF);
        }

        //public IEnumerable<Societe> SocieteGetAll()
        //{
        //    return _declarationCnssRepository.SocieteGetAll();
        //}

        public IEnumerable<DeclarationCnss> DeclarationAll()
        {
            return _declarationCnssRepository.GetAll(DeclarationService.Exercice.Id, DeclarationService.Societe.Id);
        }

        public void DeclarationDeleteCnss(int declarationNo)
        {
            var declaration = _declarationCnssRepository.GetDeclaration(declarationNo);
            if (declaration == null) throw new ArgumentNullException("declaration");

            if (DeclarationService.Exercice.IsCloturer)
                throw new InvalidOperationException("Exercice est cloturé");

            try
            {
                var option = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(60)
                };
                using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
                {
                    IEnumerable<LigneCnss> lignesDec =
                        _ligneCnssRepository.GetLignesByDeclaration(declarationNo).ToList();
                    foreach (LigneCnss ligneCnss in lignesDec)
                    {
                        _ligneCnssRepository.Delete(ligneCnss);
                        IEnumerable<LigneCnss> ligneEmp =
                            _ligneCnssRepository.GetLignesByEmployees(ligneCnss.EmployeeNo).ToList();
                        if (!ligneEmp.Any())
                            _employeeRepository.Delete(ligneCnss.EmployeeNo);
                    }

                    _declarationCnssRepository.Delete(declarationNo);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeclarationCreate(int trimestre, bool isComplement)
        {
            // check current societe
            if (DeclarationService.Societe == null) throw new InvalidOperationException("Societe courante invalide!");
            //check current exercice
            if (DeclarationService.Exercice == null) throw new InvalidOperationException("Exercice courant invalid!");
            if (DeclarationService.Exercice.IsCloturer)
                throw new InvalidOperationException("Exercice est cloturé");

            // check trimestre
            if (trimestre < 1 || trimestre > 4) throw new ApplicationException("Trimestre invalide!");

            if (!isComplement)
            {
                var exist = _declarationCnssRepository.GetDeclaration(trimestre, DeclarationService.Exercice.Id,
                    DeclarationService.Societe.Id);

                if (exist != null) throw new ApplicationException("Opération invalide! [déclaration existe déja]");
            }
            var declaration = new DeclarationCnss
            {
                Complementaire = isComplement,
                Trimestre = trimestre,
                IsCloture = false,
                ExerciceId = DeclarationService.Exercice.Id,
                Date = DateTime.Now,
                IsArchive = false,
                SocieteId = DeclarationService.Societe.Id
            };
            return _declarationCnssRepository.Create(declaration);
        }

        public void DeclarationValiderCnss(int declarationNo)
        {
             if (DeclarationService.Exercice.IsCloturer)
                throw new InvalidOperationException("Exercice est cloturé");
            // charger la declaration
            var declaration = _declarationCnssRepository.GetDeclaration(declarationNo);
            if (declaration == null) throw new ApplicationException("Declaration invalide! ");

            // tester si la declaration est cloture
            if (declaration.IsCloture)
                throw new ApplicationException("Opération invalide! [Déclaration est cloturée!]");
            // charger les lignes declaration
            List<LigneCnss> lignesCnss = _ligneCnssRepository.GetLignesByDeclaration(declaration.Id).ToList();

            if (lignesCnss.Count == 0)
                throw new ApplicationException("Aucune ligne à déclarer!");
            var groupeByCategories = lignesCnss.GroupBy(x => x.CategorieNo);

            try
            {
                var option = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(15)
                };
                using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
                {
                    // group by categorie
                    foreach (var groupeByCategory in groupeByCategories)
                    {
                        // load categorie
                        CategorieCnss categorie = _categorieRepository.GetCategorie(groupeByCategory.Key);
                        if (categorie == null) throw new ApplicationException("Catégorie invalide!");

                        int ligne = 0;
                        int page = 1;
                        List<LigneCnss> lignes =
                            groupeByCategory.OrderBy(x => Convert.ToInt32(x.NumeroCnss)).ToList();
                        if (lignes.Count > 11988)
                            throw new InvalidOperationException("Nombre des lignes déclarer est superieur à 11988.");
                        // generated ligne and page
                        foreach (LigneCnss ligneCnss in lignes)
                        {
                            ligne++;
                            ligneCnss.Ligne = ligne;
                            ligneCnss.Page = page;
                            ligneCnss.CodeExploitation = categorie.CodeExploitation;
                            if (ligne == 12)
                            {
                                ligne = 0;
                                page++;
                            }

                            _ligneCnssRepository.Update(ligneCnss);
                        }
                    }

                    _declarationCnssRepository.Cloturer(declarationNo, true);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Archiver(int declarationNo)
        {
            var declaration = _declarationCnssRepository.GetDeclaration(declarationNo);
            if (declaration == null)
                throw new ArgumentNullException("declaration");
            if (!declaration.IsCloture)
                throw new InvalidOperationException("Impossible d'archiver une déclaration non valide!");
            _declarationCnssRepository.Archiver(declarationNo);
        }

        public void Editer(int no)
        {
            if (DeclarationService.Exercice.IsCloturer)
                throw new InvalidOperationException("Exercice est cloturé");
            _declarationCnssRepository.Cloturer(no, false);
        }

        #endregion Declaration

        #region LigneDeclaration

        // creation de ligne de déclaration
        public void LigneDeclarationCreate(int declarationNo,
            string employeeCin,
            decimal brutA,
            decimal brutB,
            decimal brutC)
        {
            if (Exercice.IsCloturer)
                throw new InvalidOperationException("Exercice est cloturé");

            //charger la declaration
            var declaration = _declarationCnssRepository.GetDeclaration(declarationNo);
            if (declaration == null) throw new ApplicationException("Déclaration invalide!");

            // tester si la daclaration est clôturer
            if (declaration.IsCloture)
                throw new InvalidOperationException("Opération invalide [Déclaration est clôturé].");

            //charger l'employee
            Employee employee = _employeeRepository.Get(employeeCin, Societe.Id);
            if (employee == null) throw new ApplicationException("Employee n'existe pas!");

            //charger categorie employee
            CategorieCnss categorie = _categorieRepository.GetCategorie(employee.CategorieNo);
            if (categorie == null) throw new ApplicationException("Categorie employee invalide!");

            IEnumerable<LigneCnss> exist = _ligneCnssRepository.GetAll(declarationNo, employee.Id,
                employee.NumeroInterne);
            if (exist != null) throw new ApplicationException("Ligne déclaration déja existe!");

            // vérifier les montants
            if (brutA < 0)
                throw new InvalidOperationException(string.Format("Brut 1 invalid! Employee {0}", employee.Cin));
            if (brutB < 0)
                throw new InvalidOperationException(string.Format("Brut 2 invalid! Employee {0}", employee.Cin));
            if (brutC < 0)
                throw new InvalidOperationException(string.Format("Brut 3 invalid! Employee {0}", employee.Cin));
            if (brutA == 0 && brutB == 0 && brutC == 0)
                throw new ApplicationException("Opération invalide! [Montant égale O]");
            var ligne = new LigneCnss
            {
                Ligne = 0,
                Page = 0,
                Brut1 = brutA,
                Brut2 = brutB,
                Brut3 = brutC,
                CategorieNo = categorie.Id,
                DeclarationNo = declarationNo,
                SocieteNo = Societe.Id,
                EmployeeNo = employee.Id,
                CleCnss = employee.CleCnss,
                Prenom = employee.Prenom,
                CodeExploitation = categorie.CodeExploitation,
                NumeroCnss = employee.NumeroCnss,
                Cin = employee.Cin,
                Nom = employee.Nom,
                NomJeuneFille = employee.NomJeuneFille,
                Civilite = employee.Civilite,
                NumeroInterne = employee.NumeroInterne,
                AutresNom = employee.AutresNom,
            };
            _ligneCnssRepository.Create(ligne);
        }

        // charger les ligne du declaration
        public IEnumerable<LigneCnss> GetLigneDeclarationCnss(int declarationNo)
        {
            var declaration = _declarationCnssRepository.GetDeclaration(declarationNo);
            if (declaration == null) throw new ArgumentNullException("declarationNo");

            return _ligneCnssRepository.GetLignesByDeclaration(declarationNo);
        }

 public IEnumerable<LigneCnss> GetLigne( int employeNo , int trim1, int ex1, int trim2, int ex2)
        {
           // var declaration = _declarationCnssRepository.GetDeclaration(declarationNo);
           // if (declaration == null) throw new ArgumentNullException("declarationNo");

            return _ligneCnssRepository.GetLigne( employeNo ,  trim1,  ex1,  trim2,  ex2);
        }


        public void LigneCnssDelete(int no)
        {
            LigneCnss ligne = _ligneCnssRepository.Get(no);
            if (ligne == null) throw new ApplicationException("Ligne cnss invalide!");

            var option = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TimeSpan.FromSeconds(15)
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
            {
                _ligneCnssRepository.Delete(ligne);

                List<LigneCnss> lignes = _ligneCnssRepository.GetLignesByEmployees(ligne.EmployeeNo).ToList();

                if (lignes.Count == 0)
                {
                    Employee emplyee = _employeeRepository.Get(ligne.EmployeeNo);
                    if (emplyee == null) throw new ArgumentException("Emplayée invalide!");
                    _employeeRepository.Delete(emplyee.Id);
                }
                scope.Complete();
            }
        }

        // exporter les declarations
        public void ExportsCnss(int declarationNo, string path)
        {
            var declaration = _declarationCnssRepository.GetDeclaration(declarationNo);
            if (declaration == null) throw new ArgumentNullException("declaration");

            try
            {
                // charger les lignes + group by categorie
                var generatedDeclaration =
                    _ligneCnssRepository.GetLignesByDeclaration(declarationNo)
                        .GroupBy(x => x.CategorieNo);

                path += @"\" +
                        string.Format("TVS DecCNSS {0} {1:yyyyMMddhhmmss }", Societe.RaisonSocial, DateTime.Now);
                Directory.CreateDirectory(path);
                foreach (var ligneGenerated in generatedDeclaration)
                {
                    string pathDrectory = path;

                    CategorieCnss categorie = _categorieRepository.GetCategorie(ligneGenerated.Key);
                    string dossier = categorie.Intitule + " " + categorie.No + " " + Exercice.Annee + " T " +
                                     declaration.Trimestre;
                    pathDrectory += @"\" + dossier;
                    Directory.CreateDirectory(pathDrectory);

                    pathDrectory += @"\DS" + Societe.NumeroEmployeur.PadLeft(8, '0') +
                                    Societe.CleEmployeur.PadLeft(2, '0') +
                                    categorie.CodeExploitation.PadLeft(4, '0') + "." + declaration.Trimestre +
                                    Exercice.Annee + ".txt";

                    using (var sw = new StreamWriter(
                        new FileStream(pathDrectory, FileMode.Create), Encoding.ASCII))
                    {
                        var groupByPage = ligneGenerated.GroupBy(x => x.Page).OrderBy(x => x.Key);
                        foreach (var groupe in groupByPage)
                        {
                            foreach (LigneCnss t in groupe.OrderBy(x => x.Ligne))
                            {
                                sw.WriteLine(t.GetToString(Societe, declaration, Exercice));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ImporterLignesCnss(int declarationNo, IEnumerable<LigneImport> lignes)
        {
            if (Exercice.IsCloturer)
                throw new InvalidOperationException("Exercice est cloturé");

            try
            {
                // charger toutes les categories
                var categories = GetAllCategories().ToList();
                if (categories.Count == 0) throw new ApplicationException("Veuillez paramétrer les categories!");
                // charger declaration
                var declaration = DeclarationGet(declarationNo);
                if (declaration == null) throw new ApplicationException("Déclaration invalide!");

                var option = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.MaxValue
                };
                using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
                {
                    foreach (var ligneImport in lignes.ToList())
                    {
                        // charger categorie cnss
                        var categorie = categories.FirstOrDefault(x => x.No == ligneImport.TypeCnss);
                        if (categorie == null)
                            throw new InvalidOperationException("Catégorie invalide!");
                        // charger l'employe
                        var emp = _employeeRepository.Get(ligneImport.Cin, Societe.Id);
                        var employeeNo = 0;
                        if (emp != null)
                        {
                            // charger les lignes declarations cnss
                            //var ligneExiste = _ligneCnssRepository.GetLignesByEmployees(emp.Id);
                            var ligneIsExiste = _ligneCnssRepository.Existe(emp.Id, declarationNo, ligneImport.Matricule,
                                categorie.Id);

                            if (ligneIsExiste)
                                throw new ApplicationException(string.Format("Salarié [{0}] est déja déclaré!",
                                    ligneImport.Cin));

                            emp.Civilite = ligneImport.Civilite;
                            emp.Nom = ligneImport.Nom;
                            emp.Prenom = ligneImport.Prenom;
                            emp.SituationFamille = ligneImport.SituationFamille;
                            emp.CleCnss = ligneImport.CleCnss;
                            emp.NumeroCnss = ligneImport.NumeroCnss;
                            emp.Cin = ligneImport.Cin;
                            emp.NomJeuneFille = ligneImport.NomJeuneFille;
                            emp.CategorieNo = categorie.Id;
                            employeeNo = EmployeeUpdate(emp);
                        }
                        else
                        {
                            // modifier ou creer employe
                            employeeNo = EmployeeCreate(ligneImport.Cin,
                                ligneImport.Nom,
                                ligneImport.Prenom,
                                ligneImport.Civilite,
                                ligneImport.SituationFamille,
                                ligneImport.NumeroCnss, ligneImport.CleCnss,
                                ligneImport.NomJeuneFille,
                                ligneImport.AutresNom,
                                ligneImport.Matricule,
                                categorie);
                        }
                        if (employeeNo == 0)
                            throw new InvalidOperationException("Erreur d'importation!");
                        if (categorie.CodeExploitation == null)
                        {
                            throw new InvalidOperationException("Erreur Code d'exploitation");
                        }
                        var ligne = new LigneCnss
                        {
                            DeclarationNo = declarationNo,
                            EmployeeNo = employeeNo,
                            Civilite = ligneImport.Civilite,
                            CategorieNo = categorie.Id,
                            Nom = ligneImport.Nom,
                            Brut3 = ligneImport.BrutC,
                            Brut2 = ligneImport.BrutB,
                            Brut1 = ligneImport.BrutA,
                            CleCnss = ligneImport.CleCnss,
                            CodeExploitation = categorie.CodeExploitation.PadLeft(4, '0'),
                            AutresNom = ligneImport.AutresNom,
                            Cin = ligneImport.Cin,
                            Prenom = ligneImport.Prenom,
                            NumeroCnss = ligneImport.NumeroCnss,
                            NomJeuneFille = ligneImport.NomJeuneFille,
                            SocieteNo = DeclarationService.Societe.Id,
                            NumeroInterne = ligneImport.Matricule,
                        };
                        _ligneCnssRepository.Create(ligne);
                    }

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // modifier ligne declaration
        public void UpdateLigneDeclarationCnss(
            int ligneNo,
            string nom,
            string prenom,
            Civilite civilite,
            string numeroCnss,
            string cleCnss,
            string nomJeuneFille,
            string autreNom,
            string numeroInterne,
            int categorieNo,
            decimal brut1,
            decimal brut2,
            decimal brut3)
        {
            // tester si le l'exercice est cloturé
            if (Exercice.IsCloturer)
                throw new InvalidOperationException("Exercice est cloturé");

            try
            {
                var option = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(15)
                };
                using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
                {
                    // charger la ligne declaration
                    LigneCnss ligne = _ligneCnssRepository.Get(ligneNo);
                    if (ligne == null) throw new ArgumentNullException("ligne");ligne.Brut1 = brut1;
                    ligne.Brut2 = brut2;
                    ligne.Brut3 = brut3;
                    ligne.CategorieNo = categorieNo;
                    ligne.NumeroCnss = numeroCnss;
                    ligne.CleCnss = cleCnss;
                    ligne.AutresNom = autreNom;
                    ligne.NomJeuneFille = nomJeuneFille;
                    ligne.Nom = nom;
                    ligne.Prenom = prenom;
                    ligne.Civilite = civilite;
                    // update ligne declaration
                    _ligneCnssRepository.Update(ligne);

                    // charger l'employee
                    var employee = _employeeRepository.Get(ligne.EmployeeNo);
                    if (employee == null)
                        throw new InvalidOperationException("Employée invalide!");
                    // modifier les données du l'employée
                    employee.Nom = nom;
                    employee.Prenom = prenom;
                    employee.NumeroCnss = numeroCnss;
                    employee.NumeroInterne = numeroInterne;
                    employee.Civilite = civilite;
                    employee.CleCnss = cleCnss;
                    employee.CategorieNo = categorieNo;
                    employee.AutresNom = autreNom;
                    employee.NomJeuneFille = nomJeuneFille;
                    // update emplaye
                    _employeeRepository.Update(employee);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion LigneDeclaration

        #region Employee

        public IEnumerable<Employee> GetEmployees()
        {
            if (DeclarationService.Societe == null) throw new ApplicationException("Societe courante invalide!");
            return _employeeRepository.GetAll(Societe.Id);
        }

        public int EmployeeCreateOrUpdate(
            string cin,
            string nom,
            string prenom,
            Civilite civilite,
            SituationFamille situationFamille,
            string numeroCnss,
            string cleCnss,
            string nomJeuneFille,
            string autresNom,
            string numeroInterne,
            CategorieCnss categorie)
        {
            var employee = new Employee
            {
                Civilite = civilite,
                Nom = nom,
                Prenom = prenom,
                SituationFamille = situationFamille,
                CleCnss = cleCnss,
                NumeroCnss = numeroCnss,
                Cin = cin,
                NomJeuneFille = nomJeuneFille,
                SocieteNo = DeclarationService.Societe.Id,
                AutresNom = autresNom,
                CategorieNo = categorie.Id,
                NumeroInterne = numeroInterne
            };
            // checked exist empployee , if not exist then create , else update

            var exist = _employeeRepository.Get(cin, DeclarationService.Societe.Id);
            if (exist == null)
            {
                return _employeeRepository.Create(employee);
            }
            exist.Civilite = civilite;
            exist.CleCnss = cleCnss;
            exist.Nom = nom;
            exist.Prenom = prenom;
            exist.SituationFamille = situationFamille;
            exist.CleCnss = cleCnss;
            exist.NumeroCnss = numeroCnss;
            exist.Cin = cin;
            exist.NomJeuneFille = nomJeuneFille;
            exist.CategorieNo = categorie.Id;
            _employeeRepository.Update(exist);
            return exist.Id;
        }

        private int EmployeeUpdate(Employee employee)
        {
            _employeeRepository.Update(employee);
            return employee.Id;
        }

        private int EmployeeCreate(
            string cin,
            string nom,
            string prenom,
            Civilite civilite,
            SituationFamille situationFamille,
            string numeroCnss,
            string cleCnss,
            string nomJeuneFille,
            string autresNom,
            string numeroInterne,
            CategorieCnss categorie)
        {
            var employee = new Employee
            {
                Civilite = civilite,
                Nom = nom,
                Prenom = prenom,
                SituationFamille = situationFamille,
                CleCnss = cleCnss,
                NumeroCnss = numeroCnss,
                Cin = cin,
                NomJeuneFille = nomJeuneFille,
                SocieteNo = DeclarationService.Societe.Id,
                AutresNom = autresNom,
                CategorieNo = categorie.Id,
                NumeroInterne = numeroInterne
            };
            return _employeeRepository.Create(employee);
        }

        #endregion Employee
    }
}