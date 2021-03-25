using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TVS.Core.Interfaces;
using TVS.Core.Models;

namespace TVS.Core
{
    public class BcSuspenssionService
    {
        private readonly IDeclarationBcRepository _declarationRepository;
        private readonly ILigneBcRepository _ligneBcRepository;

        public BcSuspenssionService(IDeclarationBcRepository bcRepository, ILigneBcRepository ligneBcRepository)
        {
            if (bcRepository == null) throw new ArgumentNullException(nameof(bcRepository));
            if (ligneBcRepository == null) throw new ArgumentNullException(nameof(ligneBcRepository));
            _declarationRepository = bcRepository;
            _ligneBcRepository = ligneBcRepository;
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

        #region declaration

        public DeclarationBc DeclarationGet(int no)
        {
            return _declarationRepository.GetDeclaration(no);
        }

        public IEnumerable<DeclarationBc> DeclarationAll()
        {
            return _declarationRepository.GetAll(Exercice.Id, Societe.Id);
        }

        public int DeclarationCreate(int trimestre, string numeroAutorisation)
        {
            // check current societe
            if (Societe == null) throw new InvalidOperationException("Societe courante invalide!");
            //check current exercice
            if (Exercice == null) throw new InvalidOperationException("Exercice courant invalid!");
            if (Exercice.IsCloturer)
                throw new InvalidOperationException("Exercice est cloturé");

            // check trimestre
            if (trimestre < 1 || trimestre > 4) throw new ApplicationException("Trimestre invalide!");


            var exist = _declarationRepository.GetDeclaration(trimestre, Exercice.Id, Societe.Id);

            if (exist != null) throw new ApplicationException("Opération invalide! [déclaration existe déja]");


            var declaration = new DeclarationBc
            {
                Trimestre = trimestre,
                IsCloture = false,
                ExerciceId = Exercice.Id,
                Date = DateTime.Now,
                IsArchive = false,
                SocieteId = Societe.Id,
                NumeroAutorisation= numeroAutorisation
            };
            return _declarationRepository.Create(declaration);
        }

        public void Archiver(int declarationNo)
        {
            var declaration = _declarationRepository.GetDeclaration(declarationNo);
            if (declaration == null)
                throw new ArgumentNullException("declaration");
            if (!declaration.IsCloture)
                throw new InvalidOperationException("Impossible d'archiver une déclaration non valide!");
            _declarationRepository.Archiver(declarationNo);
        }

        public void Editer(int no)
        {
            if (Exercice.IsCloturer)
                throw new InvalidOperationException("Exercice est cloturé");
            _declarationRepository.Cloturer(no, false);
        }

        #endregion

        #region ligne declaration Bc

        public int LigneDeclarationCreate(
            int declarationNo,
            string numeroAutorisation,
            string numeroBonCommande,
            DateTime dateBonCommande,
            string numeroFacture,
            DateTime dateFacture,
            string identifiant,
            string raisonSocialFournisseur,
            decimal prixAchatHorsTaxe,
            decimal montantTva,
            string objetFacture)
        {
            if (Exercice.IsCloturer)
                throw new InvalidOperationException("Exercice est cloturé");

            //charger la declaration
            var declaration = _declarationRepository.GetDeclaration(declarationNo);

            if (declaration == null)
                throw new ApplicationException("Déclaration invalide!");

            // tester si la daclaration est clôturer
            if (declaration.IsCloture)
                throw new InvalidOperationException("Opération invalide [Déclaration est clôturé].");

            var ligne = new LigneBc
            {
                DeclarationNo = declarationNo,
                SocieteNo = Societe.Id,
                DateBonCommande = dateBonCommande,
                DateFacture = dateFacture,
                MontantTva = montantTva,
                NumeroAutorisation = numeroAutorisation,
                Identifiant = identifiant,
                NumeroBonCommande = numeroBonCommande,
                NumeroFacture = numeroFacture,
                ObjetFacture = objetFacture,
                PrixAchatHorsTaxe = prixAchatHorsTaxe,
                RaisonSocialFournisseur = raisonSocialFournisseur
            };
            var no = _ligneBcRepository.Create(ligne);
            if (no <= 0) throw new InvalidOperationException("Opératoin invalide!");
            return no;
        }

        // charger les ligne du declaration
        public IEnumerable<LigneBc> GetAllLigne(int declarationNo)
        {
            var declaration = _declarationRepository.GetDeclaration(declarationNo);
            if (declaration == null) throw new ArgumentNullException("declarationNo");

            return _ligneBcRepository.GetAll(declarationNo);
        }

        public LigneBc GetLigneDeclarationBcSupendue(int no)
        {
            return _ligneBcRepository.Get(no);
        }

        public void DeclarationDelete(int declarationNo)
        {
            var declaration = _declarationRepository.GetDeclaration(declarationNo);
            if (declaration == null) throw new ArgumentNullException("declaration");


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
                    var lignesDec = _ligneBcRepository.GetAll(declarationNo);
                    foreach (var ligneCnss in lignesDec)
                    {
                        _ligneBcRepository.Delete(ligneCnss.Id);
                    }

                    _declarationRepository.Delete(declarationNo);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ImporterLignes(int declarationNo,
            IEnumerable<LigneBc> lignes)
        {
            if (Exercice.IsCloturer)
                throw new InvalidOperationException("Exercice est cloturé");

            //charger la declaration
            var declaration = _declarationRepository.GetDeclaration(declarationNo);
            if (declaration == null) throw new ApplicationException("Déclaration invalide!");

            // tester si la daclaration est clôturer
            if (declaration.IsCloture)
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
                    if (string.IsNullOrEmpty(l.NumeroAutorisation))
                        throw new InvalidOperationException(string.Format("Numéro autorisation invalide! [{0}]",
                            l.NumeroBonCommande));

                    if (string.IsNullOrEmpty(l.NumeroBonCommande))
                        throw new InvalidOperationException(
                            string.Format("Numéro bon commande invalide! N°Autorisation [{0}]", l.NumeroAutorisation));

                    if (string.IsNullOrEmpty(l.NumeroFacture))
                        throw new InvalidOperationException(string.Format("Numéro facture invalide! [{0}]",
                            l.NumeroBonCommande));

                    if (string.IsNullOrEmpty(l.Identifiant))
                        throw new InvalidOperationException(string.Format("Identifiant invalide! [{0}]",
                            l.NumeroBonCommande));

                    if (l.MontantTva <= 0)
                        throw new InvalidOperationException(string.Format("Montant tva invalide! [{0}]",
                            l.NumeroBonCommande));

                    if (l.PrixAchatHorsTaxe <= 0)
                        throw new InvalidOperationException(string.Format("Prix achat achat hors taxe invalide! [{0}]",
                            l.NumeroBonCommande));

                    var ligne = new LigneBc
                    {
                        DateBonCommande = l.DateBonCommande,
                        DateFacture = l.DateFacture,
                        DeclarationNo = declarationNo,
                        Identifiant = l.Identifiant,
                        MontantTva = l.MontantTva,
                        SocieteNo = Societe.Id,
                        NumeroAutorisation = l.NumeroAutorisation,
                        NumeroBonCommande = l.NumeroBonCommande,
                        NumeroFacture = l.NumeroFacture,
                        ObjetFacture = l.ObjetFacture,
                        PrixAchatHorsTaxe = l.PrixAchatHorsTaxe,
                        RaisonSocialFournisseur = l.RaisonSocialFournisseur
                    };
                    _ligneBcRepository.Create(ligne);
                }
                scope.Complete();
            }
        }

        // exporter les declarations
        public void Exports(int declarationNo, string path)
        {
            var declaration = _declarationRepository.GetDeclaration(declarationNo);
            if (declaration == null) throw new ArgumentNullException("declaration");

            try
            {
                // charger les lignes + group by categorie
                var generatedDeclaration =
                    _ligneBcRepository.GetAll(declarationNo).ToList();

                path += @"\" +
                        string.Format("Déclaration Bc Suspension {0} {1:yyyyMMddhhmmss }", Societe.RaisonSocial,
                            DateTime.Now);
                Directory.CreateDirectory(path);
                string pathDrectory = path;
                pathDrectory += @"\BCD_T" + declaration.Trimestre + "_" + Exercice.Annee[2] + Exercice.Annee[3] + ".txt";

                using (var sw = new StreamWriter(
                    new FileStream(pathDrectory, FileMode.Create), Encoding.ASCII))
                {
                    sw.WriteLine(declaration.GetEntetBcToString(Societe, Exercice));
                    foreach (var ligneGenerated in generatedDeclaration)
                    {
                        sw.WriteLine(ligneGenerated.GetToString(Societe, declaration, Exercice));
                    }
                    sw.Write(declaration.GetPiedBcToString(Societe, Exercice, generatedDeclaration));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeclarationValider(int declarationNo)
        {
            // tester si l'exercice est clôturer
            if (Exercice.IsCloturer)
                throw new InvalidOperationException("Exercice est cloturé");
            // charger la declaration
            var declaration = _declarationRepository.GetDeclaration(declarationNo);
            if (declaration == null) throw new ApplicationException("Declaration invalide! ");


            // tester si la declaration est cloture
            if (declaration.IsCloture)
                throw new ApplicationException("Opération invalide! [Déclaration est cloturée!]");
            // charger les lignes declaration
            var lignesCnss = _ligneBcRepository.GetAll(declaration.Id).ToList();

            if (lignesCnss.Count == 0)
                throw new ApplicationException("Aucune ligne à déclarer!");

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
                    foreach (var LigneBc in lignesCnss)
                    {
                        LigneBc.NumeroOrdre = i;
                        _ligneBcRepository.Update(LigneBc);
                        i++;
                    }

                    _declarationRepository.Cloturer(declarationNo, true);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // modifier ligne declaration
        public void UpdateLigne(
            int ligneNo,
            string numeroAutorisation,
            string numeroBonCommande,
            DateTime dateBonCommande,
            string numeroFacture,
            DateTime dateFacture,
            string identifiant,
            string raisonSocialFournisseur,
            decimal prixAchatHorsTaxe,
            decimal montantTva,
            string objetFacture)
        {
            // tester si le l'exercice est cloturé
            if (Exercice.IsCloturer)
                throw new InvalidOperationException("Exercice est cloturé");
            // charger la ligne declaration
            var ligne = _ligneBcRepository.Get(ligneNo);
            if (ligne == null) throw new ArgumentNullException("ligne");
            // charger la declaration
            var declaration = _declarationRepository.GetDeclaration(ligne.DeclarationNo);
            if (declaration == null) throw new InvalidOperationException("Declaration invalide!");
            // verifier que la declaration n'est pas archivee
            if (declaration.IsArchive)
                throw new InvalidOperationException("Opération invalide! [Déclaration est archivée].");
            // verifier que la declration n'est pas cloturee
            if (declaration.IsCloture)
                throw new InvalidOperationException("Opération invalide! [Déclaration est clôturée].");
            // verifier que la date bon de commande de dépasse pas la date facture
            if (dateFacture < dateBonCommande)
                throw new ApplicationException("La date du bon de commande doit être inférieur au date facture!");

            try
            {
                var option = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(15)
                };
                using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
                {
                    ligne.NumeroAutorisation = numeroAutorisation;
                    ligne.NumeroBonCommande = numeroBonCommande;
                    ligne.DateBonCommande = dateBonCommande;
                    ligne.DateFacture = dateFacture;
                    ligne.NumeroFacture = numeroFacture;
                    ligne.Identifiant = identifiant;
                    ligne.PrixAchatHorsTaxe = prixAchatHorsTaxe;
                    ligne.MontantTva = montantTva;
                    ligne.RaisonSocialFournisseur = raisonSocialFournisseur;
                    ligne.ObjetFacture = objetFacture;
                    // update ligne declaration
                    _ligneBcRepository.Update(ligne);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LigneBcDelete(int no)
        {
            var ligne = _ligneBcRepository.Get(no);
            if (ligne == null) throw new ApplicationException("Ligne invalide!");
            _ligneBcRepository.Delete(ligne.Id);
        }

        #endregion ligne declaration Bc
    }
}