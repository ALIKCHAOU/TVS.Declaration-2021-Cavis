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
    public class FcSuspenssionService
    {
        private readonly IDeclarationFcRepository _declarationRepository;
        private readonly ILigneFcRepository _ligneFcRepository;

        public FcSuspenssionService(IDeclarationFcRepository bcRepository, ILigneFcRepository ligneBcRepository)
        {
            if (bcRepository == null) throw new ArgumentNullException(nameof(bcRepository));
            if (ligneBcRepository == null) throw new ArgumentNullException(nameof(ligneBcRepository));
            _declarationRepository = bcRepository;
            _ligneFcRepository = ligneBcRepository;
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

        #region Declaration

        public DeclarationFc DeclarationGet(int no)
        {
            return _declarationRepository.GetDeclaration(no);
        }

        public IEnumerable<DeclarationFc> DeclarationAll()
        {
            return _declarationRepository.GetAll(Exercice.Id, Societe.Id);
        }

        public int DeclarationCreate(int trimestre)
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

            var declaration = new DeclarationFc
            {
                Trimestre = trimestre,
                IsCloture = false,
                ExerciceId = Exercice.Id,
                Date = DateTime.Now,
                IsArchive = false,
                SocieteId = Societe.Id
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

        public void DeclarationDeleteFcSuspendue(int declarationNo)
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
                    var lignesDec = _ligneFcRepository.GetAll(declarationNo);
                    foreach (var ligneCnss in lignesDec)
                    {
                        _ligneFcRepository.Delete(ligneCnss.Id);
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

        #endregion

        #region ligne declaration Fc

        public void LigneDelete(int no)
        {
            var ligne = _ligneFcRepository.Get(no);
            if (ligne == null) throw new ApplicationException("Ligne invalide!");
            _ligneFcRepository.Delete(ligne.Id);
        }

        // charger les ligne du declaration
        public IEnumerable<LigneFc> GetAllLigne(int declarationNo)
        {
            var declaration = _declarationRepository.GetDeclaration(declarationNo);
            if (declaration == null) throw new ArgumentNullException("declarationNo");
            return _ligneFcRepository.GetAll(declarationNo);
        }

        public LigneFc GetLigneDeclarationFcSupendue(int no)
        {
            return _ligneFcRepository.Get(no);
        }

        public int LigneCreate(
            int declarationNo,
            int numeroOrdre,
            string numeroFacture,
            DateTime dateFacture,
            TypeClient typeClient,
            string identifiantClient,
            string nomPrenomClient,
            string adresseClient,
            string numeroAutorisation,
            DateTime dateAutorisation,
            decimal prixVenteHt,
            decimal tauxFodec,
            decimal montantFodec,
            decimal tauxDroitConsommation,
            decimal montantDroitConsommation,
            decimal tauxTva,
            decimal montantTva
        )
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

            var option = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TimeSpan.FromSeconds(15)
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
            {
                if (string.IsNullOrEmpty(numeroAutorisation))
                    throw new InvalidOperationException(string.Format("Numéro autorisation invalide! [{0}]",
                        numeroFacture));

                if (string.IsNullOrEmpty(numeroFacture))
                    throw new InvalidOperationException(
                        string.Format("Numéro facture invalide! N°Autorisation [{0}]", numeroAutorisation));

                if (string.IsNullOrEmpty(nomPrenomClient))
                    throw new InvalidOperationException(string.Format("Identifiant client invalide! [{0}]",
                        numeroFacture));

                if (string.IsNullOrEmpty(identifiantClient))
                    throw new InvalidOperationException(string.Format("Identifiant client invalide! [{0}]",
                        numeroFacture));

                if (prixVenteHt <= 0)
                    throw new InvalidOperationException(string.Format("Prix de vente HT invalide! [{0}]",
                        numeroFacture));

                if (montantDroitConsommation < 0)
                    throw new InvalidOperationException(string.Format("Montant droit de consommation invalide! [{0}]",
                        numeroFacture));

                if (montantTva < 0)
                    throw new InvalidOperationException(string.Format("Montant tva invalide! [{0}]",
                        numeroFacture));

                if (montantFodec < 0)
                    throw new InvalidOperationException(string.Format("Montant fodec invalide! [{0}]",
                        numeroFacture));

                if (tauxFodec < 0)
                    throw new InvalidOperationException(string.Format("Taux fodec invalide! [{0}]",
                        numeroFacture));

                if (tauxDroitConsommation < 0)
                    throw new InvalidOperationException(string.Format("Taux  droit de consommation invalide! [{0}]",
                        numeroFacture));

                if (tauxTva < 0)
                    throw new InvalidOperationException(string.Format("Taux tva invalide! [{0}]",
                        numeroFacture));

                var ligne = new LigneFc
                {
                    MontantDroitConsommation = montantDroitConsommation,
                    MontantFodec = montantFodec,
                    MontantTva = montantTva,
                    SocieteNo = Societe.Id,
                    PrixVenteHt = prixVenteHt,
                    TauxDroitConsommation = tauxDroitConsommation,
                    TauxFodec = tauxFodec,
                    TauxTva = tauxTva,
                    AdresseClient = adresseClient,
                    DateAutorisation = dateAutorisation,
                    DateFacture = dateFacture,
                    IdentifiantClient = identifiantClient,
                    NomPrenomClient = nomPrenomClient,
                    NumeroAutorisation = numeroAutorisation,
                    NumeroFacture = numeroFacture,
                    TypeClient = typeClient,
                    DeclarationNo = declaration.Id,
                    NumeroOrdre = numeroOrdre
                };
                // create ligne facture en suspension
                var no = _ligneFcRepository.Create(ligne);
                if (no <= 0)
                    throw new ApplicationException("Ajout du ligne facture en suspension invalide!");

                scope.Complete();
                // valeur de retour
                return no;
            }
        }

        public void ImporterLignes(int declarationNo,
            IEnumerable<LigneFc> lignes)
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
                Timeout = TimeSpan.FromSeconds(15)
            };
            using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
            {
                foreach (var l in lignes)
                {
                    if (string.IsNullOrEmpty(l.NumeroAutorisation))
                        throw new InvalidOperationException(string.Format("Numéro autorisation invalide! [{0}]",
                            l.NumeroFacture));

                    if (string.IsNullOrEmpty(l.NumeroFacture))
                        throw new InvalidOperationException(
                            string.Format("Numéro bon commande invalide! N°Autorisation [{0}]", l.NumeroAutorisation));

                    if (string.IsNullOrEmpty(l.NomPrenomClient))
                        throw new InvalidOperationException(string.Format("Identifiant client invalide! [{0}]",
                            l.NumeroFacture));

                    if (string.IsNullOrEmpty(l.IdentifiantClient))
                        throw new InvalidOperationException(string.Format("Identifiant client invalide! [{0}]",
                            l.NumeroFacture));

                    if (l.PrixVenteHt <= 0)
                        throw new InvalidOperationException(string.Format("Prix de vente HT invalide! [{0}]",
                            l.NumeroFacture));

                    if (l.MontantDroitConsommation < 0)
                        throw new InvalidOperationException(
                            string.Format("Montant droit de consommation invalide! [{0}]",
                                l.NumeroFacture));

                    if (l.MontantTva < 0)
                        throw new InvalidOperationException(string.Format("Montant tva invalide! [{0}]",
                            l.NumeroFacture));

                    if (l.MontantFodec < 0)
                        throw new InvalidOperationException(string.Format("Montant fodec invalide! [{0}]",
                            l.NumeroFacture));

                    if (l.TauxFodec < 0)
                        throw new InvalidOperationException(string.Format("Taux fodec invalide! [{0}]",
                            l.NumeroFacture));

                    if (l.TauxDroitConsommation < 0)
                        throw new InvalidOperationException(string.Format("Taux  droit de consommation invalide! [{0}]",
                            l.NumeroFacture));

                    if (l.TauxTva < 0)
                        throw new InvalidOperationException(string.Format("Taux tva invalide! [{0}]",
                            l.NumeroFacture));

                    var ligne = new LigneFc
                    {
                        MontantDroitConsommation = l.MontantDroitConsommation,
                        MontantFodec = l.MontantFodec,
                        MontantTva = l.MontantTva,
                        SocieteNo = Societe.Id,
                        PrixVenteHt = l.PrixVenteHt,
                        TauxDroitConsommation = l.TauxDroitConsommation,
                        TauxFodec = l.TauxFodec,
                        TauxTva = l.TauxTva,
                        AdresseClient = l.AdresseClient,
                        DateAutorisation = l.DateAutorisation,
                        DateFacture = l.DateFacture,
                        IdentifiantClient = l.IdentifiantClient,
                        NomPrenomClient = l.NomPrenomClient,
                        NumeroAutorisation = l.NumeroAutorisation,
                        NumeroFacture = l.NumeroFacture,
                        TypeClient = l.TypeClient,
                        DeclarationNo = declaration.Id,
                        NumeroOrdre = l.NumeroOrdre
                    };
                    _ligneFcRepository.Create(ligne);
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
                    _ligneFcRepository.GetAll(declarationNo).ToList();

                path += @"\" +
                        string.Format("Declaration Fc Suspension {0} {1:yyyyMMddhhmmss }", Societe.RaisonSocial,
                            DateTime.Now);
                Directory.CreateDirectory(path);
                string pathDrectory = path;
                pathDrectory += @"\FAC_T" + declaration.Trimestre + "_" + Exercice.Annee[2] + Exercice.Annee[3] + ".txt";

                using (var sw = new StreamWriter(
                    new FileStream(pathDrectory, FileMode.Create), Encoding.ASCII))
                {
                    sw.WriteLine(declaration.GetEntetFcToString(Societe, Exercice));
                    foreach (var ligneGenerated in generatedDeclaration)
                    {
                        sw.WriteLine(ligneGenerated.GetToString(Societe, declaration, Exercice));
                    }
                    sw.Write(declaration.GetPiedToString(Societe, Exercice, generatedDeclaration));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeclarationValiderFc(int declarationNo)
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
            var lignes = _ligneFcRepository.GetAll(declaration.Id).ToList();

            if (lignes.Count == 0)
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
                    foreach (var ligneFcSuspendue in lignes)
                    {
                        ligneFcSuspendue.NumeroOrdre = i;
                        _ligneFcRepository.Update(ligneFcSuspendue);
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
            string numeroFacture,
            DateTime dateFacture,
            DateTime dateAutorisation,
            TypeClient typeIdentifiantClient,
            string identifiant,
            string nomPrenomClient,
            decimal montantFodec,
            decimal montantTva,
            decimal prixHorsTaxe,
            decimal montantConsommation,
            decimal tauxDroitConsommation,
            decimal tauxFodec,
            decimal tauxTva)
        {
            // tester si le l'exercice est cloturé
            if (Exercice.IsCloturer)
                throw new InvalidOperationException("Exercice est cloturé");
            if (prixHorsTaxe <= 0)
                throw new InvalidOperationException(string.Format("Montant tva invalide!"));

            if (montantConsommation < 0)
                throw new InvalidOperationException(string.Format("Montant droit de consommation invalide! "));

            if (montantTva < 0)
                throw new InvalidOperationException(string.Format("Montant tva invalide!"));

            if (montantFodec < 0)
                throw new InvalidOperationException(string.Format("Montant fodec invalide! "));

            if (tauxFodec < 0)
                throw new InvalidOperationException(string.Format("Taux fodec invalide! "));

            if (tauxDroitConsommation < 0)
                throw new InvalidOperationException(string.Format("Taux  droit de consommation invalide!"));

            if (tauxTva < 0)
                throw new InvalidOperationException(string.Format("Taux tva invalide!"));
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
                    var ligne = _ligneFcRepository.Get(ligneNo);
                    if (ligne == null) throw new ArgumentNullException("ligne");
                    var declaration = _declarationRepository.GetDeclaration(ligne.DeclarationNo);
                    if (declaration == null) throw new InvalidOperationException("Declaration invalide!");
                    ligne.NumeroAutorisation = numeroAutorisation;
                    ligne.DateFacture = dateFacture;
                    ligne.NumeroFacture = numeroFacture;
                    ligne.IdentifiantClient = identifiant;
                    ligne.TypeClient = typeIdentifiantClient;
                    ligne.NomPrenomClient = nomPrenomClient;
                    ligne.MontantTva = montantTva;
                    ligne.MontantFodec = montantFodec;
                    ligne.PrixVenteHt = prixHorsTaxe;
                    ligne.MontantDroitConsommation = montantConsommation;
                    ligne.TauxDroitConsommation = tauxDroitConsommation;
                    ligne.TauxFodec = tauxFodec;
                    ligne.TauxTva = tauxTva;
                    ligne.DateAutorisation = dateAutorisation;
                    // update ligne declaration
                    _ligneFcRepository.Update(ligne);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Delete declaration fc suspendue
        /// </summary>
        /// <param name="declarationNo">Id dclaration</param>
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
                    var lignesDec = _ligneFcRepository.GetAll(declarationNo);
                    foreach (var ligneCnss in lignesDec)
                    {
                        _ligneFcRepository.Delete(ligneCnss.Id);
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

        #endregion ligne declaration Fc
    }
}