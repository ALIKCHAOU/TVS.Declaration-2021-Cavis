using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using TVS.Core.Enums;
using TVS.Core.Interfaces;
using TVS.Core.Models;

namespace TVS.Core
{
    public class VirementService
    {
        private readonly ISocieteRepository _societeRepository;
        private readonly IVirementEnteteRepository _virementEnteteRepository;
        private readonly IVirementLigneRepository _virementLigneRepository;
        private readonly ISocieteBanqueRepository _societeBanqueRepository;

        public VirementService(ISocieteRepository societeRepository,
            IVirementLigneRepository virementLigneRepository,
            IVirementEnteteRepository virementEnteteRepository,
            ISocieteBanqueRepository societeBanqueRepository)
        {
            if (virementLigneRepository == null) throw new ArgumentNullException(nameof(virementLigneRepository));
            if (virementEnteteRepository == null) throw new ArgumentNullException(nameof(virementEnteteRepository));
            _societeRepository = societeRepository;
            _virementLigneRepository = virementLigneRepository;
            _virementEnteteRepository = virementEnteteRepository;
            _societeBanqueRepository = societeBanqueRepository;
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

        #region banqueSociete

        public int BanqueCreate(
            string adresse,
            string agence,
            Banque banque,
            string rib)
        {
            var societeBanque = new SocieteBanque
            {
                SocieteId = Societe.Id,
                Adresse = adresse,
                Agence = agence,
                Banque = banque,
                Rib = rib
            };
            return _societeBanqueRepository.Create(societeBanque);
        }

        public void BanqueDelete(int id)
        {
            // to do : verifier si la categorie est deja utilisé
            var banque = _societeBanqueRepository.Get(id);
            if (banque == null) throw new ArgumentNullException("banque");
            _societeBanqueRepository.Delete(banque);
        }

        public void BanqueUpdate(int id,
            string adresse,
            string agence,
            string rib)
        {
            var banque = _societeBanqueRepository.Get(id);
            if (banque == null) throw new ArgumentNullException(nameof(banque));
            banque.Adresse = adresse;
            banque.Agence = agence;
            banque.Rib = rib;
            _societeBanqueRepository.Update(banque);
        }

        public IEnumerable<SocieteBanque> GetAllBanque()
        {
            return _societeBanqueRepository.GetAll(Societe.Id);
        }

        #endregion banqueSociete

        #region Entete

        public void Create(string referenceEnvoi,
            string motifOperation,
            bool cloturer,
            bool archiver,
            decimal total,
            int banqueId)
        {
            var banque = _societeBanqueRepository.Get(banqueId);
            if (banque == null) throw new InvalidOperationException("Banque invalide!");
            var entete = new VirementEntete
            {
                Archiver = false,
                Banque = banque.Banque,
                BanqueId = banqueId,
                Cloturer = false,
                DateCreation = DateTime.Now,
                DateEcheance = DateTime.Now,
                Exercice = Exercice.Annee,
                ExerciceId = Exercice.Id,
                MotifOperation = motifOperation,
                NombreTotal = 0,
                ReferenceEnvoi = referenceEnvoi,
                Rib = banque.Rib,
                Total = 0,
                SocieteId = Societe.Id
            };
            _virementEnteteRepository.Create(entete);
        }

        public void Update(int no,
            string referenceEnvoi,
            string motifOperation,
            bool cloturer,
            bool archiver,
            decimal total)
        {
            var entete = _virementEnteteRepository.Get(no);
            if (entete == null) throw new InvalidOperationException("Entete virement invalide!");
            entete.ReferenceEnvoi = referenceEnvoi;
            entete.MotifOperation = motifOperation;
            entete.Cloturer = cloturer;
            entete.Archiver = archiver;
            entete.Total = total;
            _virementEnteteRepository.Update(entete);
        }

        public void Delete(int id)
        {
            var entete = _virementEnteteRepository.Get(id);
            if (entete == null) throw new InvalidOperationException("Entete virement invalide!");
            _virementEnteteRepository.Delete(entete);
        }

        public IEnumerable<VirementEntete> EnteteGetAll()
        {
            return _virementEnteteRepository.GetAll(Societe.Id, Exercice.Id);
        }

        public VirementEntete Get(int no)
        {
            return _virementEnteteRepository.Get(no);
        }

        #endregion

        #region LigneVirement 

        public int LigneCreate(
            int enteteId,
            string matricule,
            string nom,
            string prenom,
            string nomBanque,
            string codeBanque,
            string codeGuichet,
            string numeroCompte,
            string cleRib,
            decimal netAPaye,
            string motif)
        {
            var ligne = new VirementLigne
            {
                Matricule = matricule,
                Nom = nom,
                Prenom = prenom,
                NomBanque = nomBanque,
                CodeBanque = codeBanque,
                CodeGuichet = codeGuichet,
                NumeroCompte = numeroCompte,
                CleRib = cleRib,
                NetAPaye = netAPaye,
                Motif = motif,
                EnteteId = enteteId
            };
            return _virementLigneRepository.Create(ligne);
        }

        public void LigneDelete(int no)
        {
            _virementLigneRepository.Delete(no);
        }

        public void LigneUpdate(
            int no,
            string matricule,
            string nom,
            string prenom,
            string nomBanque,
            string codeBanque,
            string codeGuichet,
            string numeroCompte,
            string cleRib,
            decimal netAPaye,
            string motif)
        {
            var ligne = _virementLigneRepository.Get(no);
            if (ligne == null) throw new InvalidOperationException("Ligne invalide!");
            ligne.Matricule = matricule;
            ligne.Nom = nom;
            ligne.Prenom = prenom;
            ligne.NomBanque = nomBanque;
            ligne.CodeBanque = codeBanque;
            ligne.CodeGuichet = codeGuichet;
            ligne.NumeroCompte = numeroCompte;
            ligne.CleRib = cleRib;
            ligne.NetAPaye = netAPaye;
            ligne.Motif = motif;
            _virementLigneRepository.Update(ligne);
        }

        public IEnumerable<VirementLigne> LignesGetAll(int enteteNo)
        {
            return _virementLigneRepository.GetAll(enteteNo);
        }

        public VirementLigne LignesGet(int no)
        {
            return _virementLigneRepository.Get(no);
        }

        #endregion

        public void Editer(int no)
        {
            var declaration = _virementEnteteRepository.Get(no);
            if (declaration == null) throw new ApplicationException("Declaration invalide! ");
            if (Exercice.IsCloturer)
                throw new InvalidOperationException("Exercice est cloturé");
            _virementEnteteRepository.Cloturer(no, false, declaration.Rib);
        }

        public void Archiver(int declarationNo)
        {
            var declaration = _virementEnteteRepository.Get(declarationNo);
            if (declaration == null)
                throw new ArgumentNullException("declaration");
            if (!declaration.Cloturer)
                throw new InvalidOperationException("Impossible d'archiver un virement non valide!");
            _virementEnteteRepository.Archiver(declarationNo);
        }

        public void DeclarationValider(int declarationNo)
        {
            // tester si l'exercice est clôturer
            if (Exercice.IsCloturer)
                throw new InvalidOperationException("Exercice est cloturé");
            // charger la declaration
            var declaration = _virementEnteteRepository.Get(declarationNo);
            if (declaration == null) throw new ApplicationException("Declaration invalide! ");


            // tester si la declaration est cloture
            if (declaration.Cloturer)
                throw new ApplicationException("Opération invalide! [Déclaration est cloturée!]");
            // charger les lignes declaration
            var lignes = _virementLigneRepository.GetAll(declaration.Id).ToList();

            if (lignes.Count == 0)
                throw new ApplicationException("Aucune ligne à déclarer!");

            var banque = _societeBanqueRepository.Get(declaration.BanqueId);
            if (banque == null)
                throw new InvalidOperationException("Banque invalide");

            try
            {
                var option = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(15)
                };
                int i = 1;
                using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
                {
                    //foreach (var LigneBc in lignes)
                    //{
                    //    LigneBc. = i;
                    //    _ligneBcRepository.Update(LigneBc);
                    //    i++;
                    //}

                    _virementEnteteRepository.Cloturer(declarationNo, true, banque.Rib);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ImporterLignes(int declarationNo,
            IEnumerable<VirementLigne> lignes)
        {
            if (Exercice.IsCloturer)
                throw new InvalidOperationException("Exercice est cloturé");

            //charger la declaration
            var declaration = _virementEnteteRepository.Get(declarationNo);
            if (declaration == null) throw new ApplicationException("Déclaration invalide!");

            // tester si la daclaration est clôturer
            if (declaration.Cloturer)
                throw new InvalidOperationException("Opération invalide [Déclaration est clôturé].");

            var option = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TimeSpan.FromSeconds(60)
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
            {
                foreach (var l in lignes)
                {
                    var ligne = new VirementLigne
                    {
                        Matricule = l.Matricule,
                        Nom = l.Nom,
                        Prenom = l.Prenom,
                        NomBanque = l.NomBanque,
                        CodeBanque = l.CodeBanque,
                        CodeGuichet = l.CodeGuichet,
                        NumeroCompte = l.NumeroCompte,
                        CleRib = l.CleRib,
                        NetAPaye = l.NetAPaye,
                        Motif = l.Motif,
                        EnteteId = declarationNo
                    };
                    _virementLigneRepository.Create(ligne);
                }
                scope.Complete();
            }
        }

        private string GetMatriculeCleRib(string identite)
        {
            double num = 0;
            if (!double.TryParse(identite, out num))
            {
                return string.Empty;
            }
            //var x = string.Concat(identite, "00000000000000000000");

            // string str = Left(x, 20);

            string str = identite.PadRight(20, '0');
            var numLeft = str.Substring(0, 10);
            var numRight = str.Substring(10, 10);
            double num1 = 0;
            double.TryParse(numLeft, out num1);
            double num2 = 0;
            double.TryParse(numRight, out num2);
            double num3 = num1 % 97;
            double num4 = num3 * 10000000000 + num2 % 97;
            num4 = 97 - num4 % 97;
            return num4.ToString("00");
        }

        // exporter les declarations
        public void Exports(int declarationNo, string path)
        {
            var virement = _virementEnteteRepository.Get(declarationNo);
            if (virement == null)
                throw new InvalidOperationException("Virement invalide!");
            var lignes = _virementLigneRepository.GetAll(declarationNo).ToList();
            if (lignes.Count == 0)
                throw new InvalidOperationException("Le virement ne contient aucune ligne!");

            if (string.IsNullOrEmpty(virement.Rib))
            {
                throw new InvalidOperationException("Rib de ma banque est invalide!");
            }
            var ribSansCle = virement.Rib.PadLeft(20, '0').Substring(0, 18);
            var cleMaBanque = virement.Rib.PadLeft(20, '0').Substring(18, 2);

            //if (GetMatriculeCleRib(ribSansCle) != cleMaBanque)
            //{
            //    throw new InvalidOperationException(string.Format("Rib de ma banque est invalide!"));
            //}

            foreach (var ligne in lignes)
            {
                var cle = GetMatriculeCleRib(string.Format("{0}{1}{2}", ligne.CodeBanque.PadLeft(2, '0'), ligne.CodeGuichet.PadLeft(5, '0'),
                    ligne.NumeroCompte.PadLeft(11, '0')));
                 if (cle.PadRight(2, '0') != ligne.CleRib.PadLeft(2, '0'))
                {
                    throw new InvalidOperationException(string.Format("Rib {0} est invalide!", ligne.Matricule));
                }
            }


            switch (virement.Banque)
            {
                case Banque.Atb:
                    VirementATB(virement, lignes, path); break;
                case Banque.Biat:
                    VirementBiat(virement, lignes, path);
                    break;
                case Banque.Btk: VirementBtk(virement, lignes, path); break;
                case Banque.Attijeri: VirementAtijerie(virement, lignes, path); break;
                case Banque.Bh: VirementBh(virement, lignes, path); break;
                case Banque.Bt: VirementBt(virement, lignes, path); break;
                case Banque.Bte: VirementBte(virement, lignes, path); break;
                case Banque.Uib: VirementUib(virement, lignes, path); break;
                case Banque.STB: VirementSTB(virement, lignes, path); break;
                case Banque.Bna: VirementBna(virement, lignes, path); break;
                default: break;
            }
        }
        public void VirementBna(VirementEntete entet, List<VirementLigne> lignes, string path)
        {
            var regexInt = new Regex(@"^\d+$");
            var banque = _societeBanqueRepository.Get(entet.BanqueId);
            if (banque == null) throw new InvalidOperationException("Banque invalide!");
            var result = "";
            var count = lignes.Count;
            var total = lignes.Sum(x => x.NetAPaye);
            result += "1101";
            result += "00";

            result += "000";// code du centre regional ou de l'agence du remettant
            result += entet.DateEcheance.ToString("ddMMyyyy");// date d'opèration 
            result += "0001";// numero de lot 
            result += "11";// code enregistement 
            result += "788";//codification des devises
            result += "00";// Rang
            result += string.Format("{0:0}", total * 1000).PadLeft(15, '0');
            result += string.Format("{0}", count).PadLeft(7, '0');// nombre total des virements
            result += string.Empty.PadLeft(204, ' '); // Zone libre

            //result += banque.Rib.PadLeft(20, '0').Substring(0, 20);          
            //result += Societe.RaisonSocial.PadRight(30, ' ').Substring(0, 30);
            //result += entet.MotifOperation.PadRight(20, ' ').Substring(0, 20);
            //result += entet.DateEcheance.ToString("yyyyMMdd");
            
            if (result.Length != 254)
                throw new InvalidOperationException("Longueur entete invalide");

            try
            {

                path += @"\" +
                        string.Format("Virement {0} BNA {1:yyyyMMddhhmmss }", Societe.RaisonSocial, DateTime.Now);
                Directory.CreateDirectory(path);

                string pathDrectory = path;
                pathDrectory += @"\Virement.sal.txt";

                using (var sw = new StreamWriter(
                    new FileStream(pathDrectory, FileMode.Create), Encoding.ASCII))
                {
                    sw.WriteLine(result);
                    var i = 1;
                    foreach (var virementLigne in lignes)
                    {
                        try
                        {
                            var ligne = "1";
                            ligne += "10";
                            ligne += "1";
                            ligne += "00";
                            ligne += "000";
                            ligne += entet.DateEcheance.ToString("ddMMyyyy");
                            ligne += "0001";// 
                            ligne += "21";
                            ligne += "788";
                            ligne += "00";
                            ligne += string.Format("{0:0}", virementLigne.NetAPaye * 1000).PadLeft(15, '0');
                            ligne += i.ToString().PadLeft(7, '0'); 
                            ligne += banque.Rib.PadLeft(20, '0').Substring(0, 20);
                            var b= banque.Rib.PadLeft(20, '0').Substring(0, 20);
                            // code institution destinataire code banque 1 ere et 2 eme position du Rib
                            ligne += virementLigne.CodeBanque; 
                            // code Agence position 4,5 et 6 du rib
                            ligne += virementLigne.CodeGuichet.Substring(0, 3);
                            // Rib du benificiere
                            ligne += virementLigne.Rib.PadLeft(20, '0');
                            ligne += virementLigne.Nom.PadRight(15, ' ').Substring(0, 15);
                            ligne += virementLigne.Prenom.PadRight(15, ' ').Substring(0, 15);
                            // si matricule emp de type entier , si nn 0
                            if (regexInt.IsMatch(virementLigne.Matricule))
                                ligne += virementLigne.Matricule.PadLeft(20, '0').Substring(0, 20);
                            else
                                ligne += "0".PadLeft(20, '0');
                            ligne += "0";
                            ligne += "00";// Nombre d'enregistrements complèmentaires 
                            ligne += virementLigne.Motif.PadLeft(75, ' ');
                            ligne += "00000000";// date de compensation initial 
                            ligne += "00000000";// motid du rejet
                            ligne += string.Empty.PadLeft(15, ' ');
                            if (ligne.Length != 254)
                                throw new InvalidOperationException("Longueur ligne invalide");
                            sw.WriteLine(ligne);
                            i++;
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidOperationException(string.Format("Erreur dans la ligne {0} pour le salarier [{1}]! ", i, virementLigne.Matricule));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void VirementSTB(VirementEntete entet, List<VirementLigne> lignes, string path)
        {
            var banque = _societeBanqueRepository.Get(entet.BanqueId);
            if (banque == null) throw new InvalidOperationException("Banque invalide!");
            var Firstligne ="DEBUT FICHIER ";
            var secondeligne = "";
            var count = lignes.Count;
            var total = lignes.Sum(x => x.NetAPaye);
             var Debutfichier = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
            string Firstletter = "";
            string[] strSplit = Societe.RaisonSocial.Split();
            foreach (string res in strSplit)
            {
                Firstletter += res.Substring(0, 1);
            }


            Firstligne += Firstletter.PadRight(3, ' ').Substring(0, 3) +" "+Debutfichier;
            if (Firstligne.Length != 28)
                throw new InvalidOperationException("longeur de permier ligne invalide !");

            secondeligne += "D"+ banque.Rib.PadLeft(20, ' ');
            secondeligne += Societe.RaisonSocial.PadRight(25, ' ');           
            secondeligne += string.Format("{0:0}", total * 1000).PadLeft(15, '0');            
            secondeligne += "VOSA";
            
            try
            {

                path += @"\" +
                        string.Format("Virement {0} STB {1:yyyyMMddhhmmss }", Societe.RaisonSocial, DateTime.Now);
                Directory.CreateDirectory(path);

                string pathDrectory = path;
                pathDrectory += @"\FMANDAT."+Firstletter+ ".txt";

                using (var sw = new StreamWriter(
                    new FileStream(pathDrectory, FileMode.Create), Encoding.ASCII))
                {
                    sw.WriteLine(Firstligne.PadRight(28));                   
                    sw.WriteLine(secondeligne.PadRight(65));
                    var i = 1;
                    foreach (var virementLigne in lignes)
                    {
                        try
                        {
                            var ligne = "B";
                            
                            //if (virementLigne.NomBanque== "STB")
                            if(virementLigne.NomBanque.Equals("Stb", StringComparison.InvariantCultureIgnoreCase))
                            {                              
                                //-Code agence STB : 3 Numériques
                                //- Compte      : 7 Numériques
                                //- Code nationalité: 3 Numériques(= 788 pour les nationalités Tunisiennes)
                                //var codeagence =virementLigne.CodeGuichet.Substring(2, 5);
                                //var Compte = virementLigne.CodeGuichet+virementLigne.NumeroCompte.Substring(0, 7);  
                                //var Codenationalite = "788";
                             

                                //var NumeroCompte = codeagence + Compte + Codenationalite;
                                //var CodeBanque = virementLigne.CodeBanque;
                                //var CodeAgence = virementLigne.CodeGuichet.Substring(0, 3);
                                //var CleRib = virementLigne.CleRib; 
                               // var rib = CodeBanque.PadLeft(2, '0') + CodeAgence + NumeroCompte + CleRib;

                                if (virementLigne.Rib.Length != 20)
                                    throw new InvalidOperationException("rib.Length !=20");                          
                                ligne += virementLigne.Rib;
                            }
                            else
                            {                             
                                //-Code banque BCT : 2 Numérique
                                //- Code agence BCT : 3 Numérique
                                //- N° de compte : 13 Numériques
                                //- Clé RIB: 2 Numériques
                                var CodeBanque = virementLigne.CodeBanque;
                                var CodeAgence = virementLigne.CodeGuichet.Substring(0, 3);
                                var NumeroCompte = virementLigne.CodeGuichet.Substring(3, 2) + virementLigne.NumeroCompte;
                                var CleRib = virementLigne.CleRib;
                                var rib = CodeBanque + CodeAgence + NumeroCompte + CleRib;
                                if (rib.Length !=20)
                                    throw new InvalidOperationException("rib.Length !=20");
                                ligne += rib;
                            }                    
                           
                            ligne += string.Format("{0} {1}", virementLigne.Nom, virementLigne.Prenom).PadRight(25);
                            ligne += string.Format("{0:0}", virementLigne.NetAPaye * 1000).PadLeft(15, '0');
                            ligne += "VOSA";                            
                             if (ligne.Length != 65)
                                throw new InvalidOperationException("Longueur ligne invalide");
                            sw.WriteLine(ligne.PadRight(65));
                            i++;
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidOperationException(string.Format("Erreur dans la ligne {0} pour le salarier [{1}]! ", i, virementLigne.Matricule));
                        }
                    }
                    var finficher ="FIN FICHIER "+Firstletter.PadRight(3, ' ').Substring(0, 3)+" "+Debutfichier;
                    if (finficher.Length != 26)
                        throw new InvalidOperationException("Longueur ligne final  invalide");
                    sw.WriteLine(finficher.PadRight(26));

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void VirementATB(VirementEntete entet, List<VirementLigne> lignes, string path)
        {
            var banque = _societeBanqueRepository.Get(entet.BanqueId);
            if (banque == null) throw new InvalidOperationException("Banque invalide!");
            var result = "";
            var count = lignes.Count;
            var total = lignes.Sum(x => x.NetAPaye);
            result += "01";
            result += banque.Rib.PadLeft(20, '0').Substring(8, 12);
            result += entet.MotifOperation.PadRight(70, ' ').Substring(0, 70);
            result += string.Format("{0:0}", total * 1000).PadLeft(12, '0');
            result += string.Format("{0}", count).PadLeft(3, '0');
            if (result.Length != 99)
                throw new InvalidOperationException("Longueur entete invalide");

            try
            {

                path += @"\" +
                        string.Format("Virement {0} ATB {1:yyyyMMddhhmmss }", Societe.RaisonSocial, DateTime.Now);
                Directory.CreateDirectory(path);

                string pathDrectory = path;
                pathDrectory += @"\VIRCLT.txt";

                using (var sw = new StreamWriter(
                    new FileStream(pathDrectory, FileMode.Create), Encoding.ASCII))
                {
                    sw.WriteLine(result);
                    var i = 1;
                    foreach (var virementLigne in lignes)
                    {
                        try
                        {
                            var ligne = "02";
                            ligne += i.ToString().PadLeft(3, '0');
                            ligne += virementLigne.Rib.Substring(0, 2).PadLeft(3, '0');
                            if (virementLigne.Rib.Substring(0, 2) == "01")
                            {
                                ligne += virementLigne.Rib.Substring(3, 2);
                            }
                            else
                            {
                                ligne += "00";
                            }
                            ligne += "4000";//Replaced 4000 for nihel virement  with 4000 by mahdi&ali
                            ligne += virementLigne.Rib;
                            ligne += string.Format("{0} {1}", virementLigne.Nom, virementLigne.Prenom)
                                .PadRight(30, ' ')
                                .Substring(0, 30);
                            ligne += string.Format("{0:0}", virementLigne.NetAPaye * 1000).PadLeft(12, '0');
                            ligne += 'N';
                            if (ligne.Length != 77)
                                throw new InvalidOperationException("Longueur ligne invalide");
                            sw.WriteLine(ligne);
                            i++;
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidOperationException(string.Format("Erreur dans la ligne {0} pour le salarier [{1}]! ", i, virementLigne.Matricule));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void VirementAtijerie(VirementEntete entet, List<VirementLigne> lignes, string path)
        {

            var banque = _societeBanqueRepository.Get(entet.BanqueId);
            if (banque == null) throw new InvalidOperationException("Banque invalide!");
            var result = "";
            var count = lignes.Count;
            var total = lignes.Sum(x => x.NetAPaye);
            result += "1101"; //2,2,3
            result += "04";
            result += string.Empty.PadLeft(3, ' ');
            result += entet.DateEcheance.ToString("yyyyMMdd");
            result += "00012178800";
            result += string.Format("{0:0}", total * 1000).PadLeft(15, '0');
            result += string.Format("{0}", count).PadLeft(10, '0');
            result += string.Empty.PadLeft(227, ' ');
            if (result.Length != 280)
                throw new InvalidOperationException("Longueur entete invalide");

            try
            {

                path += @"\" +
                        string.Format("Virement {0} ATT {1:yyyyMMddhhmmss }", Societe.RaisonSocial, DateTime.Now);
                Directory.CreateDirectory(path);

                string pathDrectory = path;
                pathDrectory += @"\VIRCLT.txt";

                using (var sw = new StreamWriter(
                    new FileStream(pathDrectory, FileMode.Create), Encoding.ASCII))
                {
                    sw.WriteLine(result);
                    var i = 1;
                    foreach (var virementLigne in lignes)
                    {
                        try
                        {
                            var ligne = "1101"; // 1,2,3
                            ligne += "04";
                            ligne += string.Empty.PadLeft(3, ' '); // 5
                            ligne += entet.DateEcheance.ToString("yyyyMMdd");//6
                            ligne += "00012178800"; //7,8,9,10
                            ligne += string.Format("{0:0}", virementLigne.NetAPaye * 1000).PadLeft(15, '0');//11
                            ligne += i.ToString().PadLeft(7, '0');//12
                            ligne += banque.Rib.PadLeft(20, '0');//13
                            ligne += Societe.RaisonSocial.PadRight(30, ' '); //14
                            ligne += virementLigne.Rib.Substring(0, 2);//15
                            ligne += string.Empty.PadLeft(3, ' ');//16
                            ligne += virementLigne.Rib; //17
                            ligne += string.Format("{0} {1}", virementLigne.Nom, virementLigne.Prenom)
                                .PadRight(30, ' ')
                                .Substring(0, 30); // 18
                            ligne += string.Empty.PadLeft(20, ' ');//19
                            ligne += '0';//20
                            ligne += "00";//21
                            ligne += string.IsNullOrEmpty(virementLigne.Motif.Trim())
                                ? entet.MotifOperation.PadRight(45, ' ').Substring(0, 45)
                                : virementLigne.Motif.PadRight(45, ' ').Substring(0, 45); //22
                            ligne += entet.DateEcheance.ToString("yyyyMMdd"); //23
                            ligne += "00000000";//24
                            ligne += "0";//25
                            ligne += "1";//26
                            ligne += string.Empty.PadLeft(1, ' ');//27
                            ligne += string.Empty.PadLeft(1, ' ');//28
                            ligne += string.Empty.PadLeft(37, ' ');//29

                            if (ligne.Length != 280)
                                throw new InvalidOperationException("Longueur ligne invalide");
                            sw.WriteLine(ligne);
                            i++;
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidOperationException(string.Format("Erreur dans la ligne {0} pour le salarier [{1}]! ", i, virementLigne.Matricule));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void VirementBiat(VirementEntete entet, List<VirementLigne> lignes, string path)
        {
            var regexInt = new Regex(@"^\d+$");
            var banque = _societeBanqueRepository.Get(entet.BanqueId);
            if (banque == null) throw new InvalidOperationException("Banque invalide!");
            var result = "";
            var count = lignes.Count;
            var total = lignes.Sum(x => x.NetAPaye);
            result += "110";
            result += banque.Rib.PadLeft(20, '0').Substring(0, 20);
            result += entet.DateEcheance.ToString("yyyyMMdd");
            result += "0001";
            result += "11";
            result += "778";
            result += "00000";
            result += string.Format("{0:0}", total * 1000).PadLeft(12, '0');
            result += string.Format("{0}", count).PadLeft(10, '0');
            result += Societe.RaisonSocial.PadRight(30, ' ').Substring(0, 30);
            result += entet.MotifOperation.PadRight(20, ' ').Substring(0, 20);
            result += entet.DateEcheance.ToString("yyyyMMdd");
            result += string.Empty.PadLeft(155, ' ');
            if (result.Length != 280)
                throw new InvalidOperationException("Longueur entete invalide");

            try
            {

                path += @"\" +
                        string.Format("Virement {0} BIAT {1:yyyyMMddhhmmss }", Societe.RaisonSocial, DateTime.Now);
                Directory.CreateDirectory(path);

                string pathDrectory = path;
                pathDrectory += @"\VIRCLT.txt";

                using (var sw = new StreamWriter(
                    new FileStream(pathDrectory, FileMode.Create), Encoding.ASCII))
                {
                    sw.WriteLine(result);
                    var i = 1;
                    foreach (var virementLigne in lignes)
                    {
                        try
                        {
                            var ligne = "1";
                            ligne += "10";
                            ligne += banque.Rib.PadLeft(20, '0').Substring(0, 20);
                            ligne += entet.DateEcheance.ToString("yyyyMMdd");
                            ligne += "0001";
                            ligne += "21";
                            ligne += "778";
                            ligne += "00000";
                            ligne += string.Format("{0:0}", virementLigne.NetAPaye * 1000).PadLeft(12, '0');
                            ligne += i.ToString().PadLeft(7, '0');
                            ligne += virementLigne.Rib.PadLeft(20, '0');
                            ligne += virementLigne.Nom.PadRight(15, ' ').Substring(0, 15);
                            ligne += virementLigne.Prenom.PadRight(15, ' ').Substring(0, 15);
                            // si matricule emp de type entier , si nn 0
                            if (regexInt.IsMatch(virementLigne.Matricule))
                                ligne += virementLigne.Matricule.PadLeft(20, '0').Substring(0, 20);
                            else
                                ligne += "0".PadLeft(20, '0');
                            ligne += "000";
                            ligne += virementLigne.Motif.PadLeft(30, ' ').Substring(0, 30);
                            ligne += string.Empty.PadLeft(113, ' ');
                            if (ligne.Length != 280)
                                throw new InvalidOperationException("Longueur ligne invalide");
                            sw.WriteLine(ligne);
                            i++;
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidOperationException(string.Format("Erreur dans la ligne {0} pour le salarier [{1}]! ", i, virementLigne.Matricule));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void VirementUib(VirementEntete entet, List<VirementLigne> lignes, string path)
        {
            var banque = _societeBanqueRepository.Get(entet.BanqueId);
            if (banque == null) throw new InvalidOperationException("Banque invalide!");

            var result = "";
            var count = lignes.Count;
            var total = lignes.Sum(x => x.NetAPaye);
            result += "09";
            result += "12";
            result += banque.Rib.PadLeft(20, '0').Substring(0, 20);
            result += entet.DateEcheance.ToString("yyyyMMdd");
            result += string.Empty.PadLeft(20, '0');
            result += string.Empty.PadLeft(15, '0');
            result += string.Format("{0}", count).PadLeft(10, '0');
            result += string.Format("{0:0}", total * 1000).PadLeft(12, '0');
            result += string.Empty.PadLeft(20, '0');
            result += string.Empty.PadLeft(51, '0');                   
           
      
            if (result.Length != 160)
                throw new InvalidOperationException("Longueur entete invalide");

            try
            {

                path += @"\" +
                        string.Format("Virement {0} UIB {1:yyyyMMddhhmmss }", Societe.RaisonSocial, DateTime.Now);
                Directory.CreateDirectory(path);

                string pathDrectory = path;
                pathDrectory += @"\VIR_UIB.txt";

                using (var sw = new StreamWriter(
                    new FileStream(pathDrectory, FileMode.Create), Encoding.ASCII))
                {
                    sw.WriteLine(result);
                    var i = 1;
                    foreach (var virementLigne in lignes)
                    {
                        try
                        {
                            var ligne = "02";

                            ligne += virementLigne.Rib.Substring(0, 2).PadLeft(2, '0');
                            ligne += banque.Rib.PadLeft(20, '0').Substring(0, 20);
                            ligne += virementLigne.Rib.PadLeft(20, '0');
                            ligne += string.Empty.PadLeft(20, '0');
                            ligne += string.Format("{0} {1}", virementLigne.Nom, virementLigne.Prenom).PadRight(50, ' ').Substring(0, 50);
                            ligne += string.Format("{0:0}", virementLigne.NetAPaye * 1000).PadLeft(10, '0');
                            ligne += string.Empty.PadLeft(35, ' ');
                            ligne += string.Empty.PadLeft(1, '0');
                                                      
                            if (ligne.Length != 160)
                                throw new InvalidOperationException("Longueur ligne invalide");
                            sw.WriteLine(ligne);
                            i++;
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidOperationException(string.Format("Erreur dans la ligne {0} pour le salarier [{1}]! ", i, virementLigne.Matricule));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void VirementBte(VirementEntete entet, List<VirementLigne> lignes, string path)
        {

            var banque = _societeBanqueRepository.Get(entet.BanqueId);
            if (banque == null) throw new InvalidOperationException("Banque invalide!");
            var result = "";
            var count = lignes.Count;
            var total = lignes.Sum(x => x.NetAPaye);
            result += "V1";
            result += string.Empty.PadLeft(2, ' ');
            result += banque.Rib.PadLeft(20, '0').Substring(0, 20);
            result += entet.DateEcheance.ToString("yyyyMMdd");
            result += entet.MotifOperation.PadRight(20, ' ').Substring(0, 20);
            result += entet.DateEcheance.ToString("yyyyMMdd");
            result += string.Empty.PadLeft(4, ' ');
            result += string.Empty.PadLeft(3, ' ');
            result += string.Format("{0}", count).PadLeft(7, '0');
            result += string.Empty.PadLeft(3, ' ');
            result += "788";
            result += "TND";
            result += string.Format("{0:0}", total * 1000).PadLeft(18, '0');
            result += entet.ReferenceEnvoi.PadRight(132, ' ').Substring(0, 132); ;

            if (result.Length != 233)
                throw new InvalidOperationException("Longueur entete invalide");

            try
            {

                path += @"\" +
                        string.Format("Virement {0} BT {1:yyyyMMddhhmmss }", Societe.RaisonSocial, DateTime.Now);
                Directory.CreateDirectory(path);

                string pathDrectory = path;
                pathDrectory += @"\VIRCLT.txt";

                using (var sw = new StreamWriter(
                    new FileStream(pathDrectory, FileMode.Create), Encoding.ASCII))
                {
                    sw.WriteLine(result);
                    var i = 1;
                    foreach (var virementLigne in lignes)
                    {
                        try
                        {
                            var ligne = "V2";
                            ligne += string.Empty.PadLeft(2, ' ');
                            ligne += string.Empty.PadLeft(20, ' ');
                            ligne += virementLigne.Rib.PadLeft(20, '0');
                            ligne += virementLigne.Nom.PadRight(15, ' ').Substring(0, 15);
                            ligne += virementLigne.Prenom.PadRight(15, ' ').Substring(0, 15);
                            ligne += string.Empty.PadLeft(20, ' ');
                            ligne += string.Empty.PadLeft(8, ' ');
                            ligne += "0000";
                            ligne += i.ToString().PadLeft(7, '0');
                            ligne += "0";
                            ligne += "00";
                            ligne += virementLigne.Motif.PadRight(100, ' ').Substring(0, 100);
                            ligne += string.Format("{0:0}", virementLigne.NetAPaye * 1000).PadLeft(18, '0');

                            if (ligne.Length != 234)
                                throw new InvalidOperationException("Longueur ligne invalide");
                            sw.WriteLine(ligne);
                            i++;
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidOperationException(string.Format("Erreur dans la ligne {0} pour le salarier [{1}]! ", i, virementLigne.Matricule));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void VirementBt(VirementEntete entet, List<VirementLigne> lignes, string path)
        {

            var banque = _societeBanqueRepository.Get(entet.BanqueId);
            if (banque == null) throw new InvalidOperationException("Banque invalide!");
            var result = "";
            var count = lignes.Count;
            var total = lignes.Sum(x => x.NetAPaye);
            result += "110";
            result += banque.Rib.PadLeft(20, '0').Substring(0, 20);
            result += entet.DateEcheance.ToString("yyyyMMdd");
            result += "0000";
            result += "11";
            result += "778";
            result += "00";
            result += string.Format("{0:0}", total * 1000).PadLeft(15, '0');
            result += string.Format("{0}", count).PadLeft(10, '0');
            result += Societe.RaisonSocial.PadRight(30, ' ').Substring(0, 30);
            result += string.Empty.PadRight(20, ' ');
            result += entet.DateEcheance.ToString("yyyyMMdd");
            result += string.Empty.PadLeft(155, ' ');
            if (result.Length != 280)
                throw new InvalidOperationException("Longueur entete invalide");

            try
            {

                path += @"\" +
                        string.Format("Virement {0} BT {1:yyyyMMddhhmmss }", Societe.RaisonSocial, DateTime.Now);
                Directory.CreateDirectory(path);

                string pathDrectory = path;
                pathDrectory += @"\VIRCLT.txt";

                using (var sw = new StreamWriter(
                    new FileStream(pathDrectory, FileMode.Create), Encoding.ASCII))
                {
                    sw.WriteLine(result);
                    var i = 1;
                    foreach (var virementLigne in lignes)
                    {
                        try
                        {
                            var ligne = "1";
                            ligne += "10";
                            ligne += banque.Rib.PadLeft(20, '0').Substring(0, 20);
                            ligne += entet.DateEcheance.ToString("yyyyMMdd");
                            ligne += "0000";
                            ligne += "21";
                            ligne += "778";
                            ligne += "00";
                            ligne += string.Format("{0:0}", virementLigne.NetAPaye * 1000).PadLeft(15, '0');
                            ligne += i.ToString().PadLeft(7, '0');
                            ligne += virementLigne.Rib.PadLeft(20, '0');
                            ligne += virementLigne.Nom.PadRight(15, ' ').Substring(0, 15);
                            ligne += virementLigne.Prenom.PadRight(15, ' ').Substring(0, 15);
                            ligne += string.Empty.PadLeft(20, ' ');
                            ligne += "000";
                            ligne += string.Empty.PadLeft(75, ' ');
                            ligne += string.Empty.PadLeft(8, '0');
                            ligne += string.Empty.PadLeft(8, '0');
                            ligne += string.Empty.PadLeft(52, ' ');
                            if (ligne.Length != 280)
                                throw new InvalidOperationException("Longueur ligne invalide");
                            sw.WriteLine(ligne);
                            i++;
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidOperationException(string.Format("Erreur dans la ligne {0} pour le salarier [{1}]! ", i, virementLigne.Matricule));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void VirementBtk(VirementEntete entet, List<VirementLigne> lignes, string path)
        {

            var banque = _societeBanqueRepository.Get(entet.BanqueId);
            if (banque == null) throw new InvalidOperationException("Banque invalide!");
            var result = "";
            var count = lignes.Count;
            var total = lignes.Sum(x => x.NetAPaye);
            result += "V1";
            result += string.Empty.PadLeft(2, ' ');
            result += banque.Rib.PadLeft(20, '0').Substring(0, 20);
            result += entet.DateEcheance.ToString("yyyyMMdd");
            result += "0".PadLeft(20, '0');
            result += entet.DateCreation.ToString("yyyyMMdd");
            result += "0000";
            result += string.Empty.PadLeft(3, ' ');
            result += string.Format("{0}", count).PadLeft(7, '0');
            result += string.Empty.PadLeft(3, ' ');
            result += "TND";
            result += "DT ";
            result += string.Format("{0:0}", total * 1000).PadLeft(18, '0');
            result += string.Empty.PadLeft(139, ' ');
            if (result.Length != 240)
                throw new InvalidOperationException("Longueur entete invalide");

            try
            {

                path += @"\" +
                        string.Format("Virement {0} BTK {1:yyyyMMddhhmmss }", Societe.RaisonSocial, DateTime.Now);
                Directory.CreateDirectory(path);

                string pathDrectory = path;
                pathDrectory += @"\VIRCLT.txt";

                using (var sw = new StreamWriter(
                    new FileStream(pathDrectory, FileMode.Create), Encoding.ASCII))
                {
                    sw.WriteLine(result);
                    var i = 1;
                    foreach (var virementLigne in lignes)
                    {
                        try
                        {
                            var ligne = "V2";
                            ligne += string.Empty.PadLeft(2, ' ');
                            ligne += banque.Rib.PadLeft(20, '0').Substring(0, 20);
                            ligne += virementLigne.Rib.PadLeft(20, '0').Substring(0, 20);
                            ligne += virementLigne.Nom.PadRight(15, ' ').Substring(0, 15);
                            ligne += virementLigne.Prenom.PadRight(15, ' ').Substring(0, 15);
                            ligne += " ".PadLeft(20, ' ');
                            ligne += entet.DateEcheance.ToString("yyyyMMdd");
                            ligne += "0000";
                            ligne += i.ToString().PadLeft(7, '0');
                            ligne += "0";
                            ligne += "00";
                            ligne += entet.MotifOperation.PadLeft(100, ' ').Substring(0, 100);
                            ligne += string.Format("{0:0}", virementLigne.NetAPaye * 1000).PadLeft(18, '0');
                            ligne += string.Empty.PadLeft(6, ' ');
                            if (ligne.Length != 240)
                                throw new InvalidOperationException("Longueur ligne invalide");
                            sw.WriteLine(ligne);
                            i++;
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidOperationException(string.Format("Erreur dans la ligne {0} pour le salarier [{1}]! ", i, virementLigne.Matricule));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void VirementBh(VirementEntete entet, List<VirementLigne> lignes, string path)
        {

            var banque = _societeBanqueRepository.Get(entet.BanqueId);
            if (banque == null) throw new InvalidOperationException("Banque invalide!");
            var result = "";
            var count = lignes.Count;
            var total = lignes.Sum(x => x.NetAPaye);
            result += "V1";
            result += string.Empty.PadLeft(2, ' ');
            result += banque.Rib.PadLeft(20, '0').Substring(0, 20);
            result += entet.DateCreation.ToString("yyyyMMdd");
            result += entet.MotifOperation.PadRight(20, ' ').Substring(0, 20);
            result += entet.DateEcheance.ToString("yyyyMMdd");
            result += "0001";
            result += string.Empty.PadLeft(3, ' ');
            result += string.Format("{0}", count).PadLeft(7, '0');
            result += string.Empty.PadLeft(3, ' ');
            result += "788";
            result += "TND";
            result += string.Format("{0:0}", total * 1000).PadLeft(18, '0');
            result += string.Empty.PadLeft(139, ' ');
            if (result.Length != 240)
                throw new InvalidOperationException("Longueur entete invalide");

            try
            {

                path += @"\" +
                        string.Format("Virement {0} BH {1:yyyyMMddhhmmss }", Societe.RaisonSocial, DateTime.Now);
                Directory.CreateDirectory(path);

                string pathDrectory = path;
                pathDrectory += @"\VIRCLT.txt";

                using (var sw = new StreamWriter(
                    new FileStream(pathDrectory, FileMode.Create), Encoding.ASCII))
                {
                    sw.WriteLine(result);
                    var i = 1;
                    foreach (var virementLigne in lignes)
                    {
                        try
                        {
                            var ligne = "V2";
                            ligne += string.Empty.PadLeft(2, ' ');
                            ligne += banque.Rib.PadLeft(20, '0').Substring(0, 20);
                            ligne += virementLigne.Rib.PadLeft(20, '0').Substring(0, 20);
                            ligne += virementLigne.Nom.PadRight(15, ' ').Substring(0, 15);
                            ligne += virementLigne.Prenom.PadRight(15, ' ').Substring(0, 15);
                            ligne += entet.MotifOperation.PadLeft(20, ' ').Substring(0, 20);// a verifier
                            ligne += entet.DateEcheance.ToString("yyyyMMdd");
                            ligne += "0001";
                            ligne += i.ToString().PadLeft(7, '0');
                           // ligne += "0";// A verifier 10
                            ligne += string.Empty.PadLeft(3, ' ');// A verifier 11
                            ligne += string.Empty.PadLeft(100, ' ').Substring(0, 100);
                            ligne += string.Format("{0:0}", virementLigne.NetAPaye * 1000).PadLeft(18, '0');
                            ligne += string.Empty.PadLeft(6, ' ');
                            if (ligne.Length != 240)
                                throw new InvalidOperationException("Longueur ligne invalide");
                            sw.WriteLine(ligne);
                            i++;
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidOperationException(string.Format("Erreur dans la ligne {0} pour le salarier [{1}]! ", i, virementLigne.Matricule));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void VirementAmen(VirementEntete entet, List<VirementLigne> lignes, string path)
        {

            var banque = _societeBanqueRepository.Get(entet.BanqueId);
            if (banque == null) throw new InvalidOperationException("Banque invalide!");
            var result = "";
            var count = lignes.Count;
            var total = lignes.Sum(x => x.NetAPaye);
            result += "V1";
            result += string.Empty.PadLeft(2, ' ');
            result += banque.Rib.PadLeft(20, '0').Substring(0, 20);
            result += entet.DateCreation.ToString("yyyyMMdd");
            result += entet.MotifOperation.PadRight(20, ' ').Substring(0, 20);
            result += entet.DateEcheance.ToString("yyyyMMdd");
            result += "0000";
            result += string.Empty.PadLeft(3, ' ');
            result += string.Format("{0}", count).PadLeft(7, '0');
            result += string.Empty.PadLeft(3, ' ');
            result += "788";
            result += "TND";
            result += string.Format("{0:0}", total * 1000).PadLeft(18, '0');
            result += string.Empty.PadLeft(139, ' ');
            if (result.Length != 240)
                throw new InvalidOperationException("Longueur entete invalide");

            try
            {

                path += @"\" +
                        string.Format("Virement {0} BH {1:yyyyMMddhhmmss }", Societe.RaisonSocial, DateTime.Now);
                Directory.CreateDirectory(path);

                string pathDrectory = path;
                pathDrectory += @"\VIRCLT.txt";

                using (var sw = new StreamWriter(
                    new FileStream(pathDrectory, FileMode.Create), Encoding.ASCII))
                {
                    sw.WriteLine(result);
                    var i = 1;
                    foreach (var virementLigne in lignes)
                    {
                        try
                        {
                            var ligne = "V2";
                            ligne += string.Empty.PadLeft(2, ' ');
                            ligne += banque.Rib.PadLeft(20, '0').Substring(0, 20);
                            ligne += virementLigne.Rib.PadLeft(20, '0').Substring(0, 20);
                            ligne += virementLigne.Nom.PadRight(15, ' ').Substring(0, 15);
                            ligne += virementLigne.Prenom.PadRight(15, ' ').Substring(0, 15);
                            ligne += " ".PadLeft(20, ' ');
                            ligne += entet.DateEcheance.ToString("yyyyMMdd");
                            ligne += "0000";
                            ligne += i.ToString().PadLeft(7, '0');
                            ligne += "000";
                            ligne += entet.MotifOperation.PadLeft(100, ' ').Substring(0, 100);
                            ligne += string.Format("{0:0}", virementLigne.NetAPaye * 1000).PadLeft(18, '0');
                            ligne += string.Empty.PadLeft(6, ' ');
                            if (ligne.Length != 240)
                                throw new InvalidOperationException("Longueur ligne invalide");
                            sw.WriteLine(ligne);
                            i++;
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidOperationException(string.Format("Erreur dans la ligne {0} pour le salarier [{1}]! ", i, virementLigne.Matricule));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}