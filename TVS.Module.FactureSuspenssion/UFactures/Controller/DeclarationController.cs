using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TVS.Core;
using TVS.Core.Models;
using TVS.Module.FactureSuspenssion.UFactures.Views;

namespace TVS.Module.FactureSuspenssion.UFactures.Controller
{
    public class DeclarationController
    {
        private readonly DeclarationService _service;

        public DeclarationController(DeclarationService service)
        {
            if (service == null) throw new ArgumentNullException("service");
            _service = service;
        }

        public IEnumerable<DeclarationView> GetAll()
        {
            return _service.FcSuspenssionService.DeclarationAll().Select(ToView).OrderBy(x => x.Trimestre).ToList();
        }

        public DeclarationView GetDeclaration(int no)
        {
            return ToView(_service.FcSuspenssionService.DeclarationGet(no));
        }

        private DeclarationView ToView(DeclarationFc declaration)
        {
            return new DeclarationView
            {
                Date = declaration.Date,
                IsArchive = declaration.IsArchive,
                IsCloture = declaration.IsCloture,
                Trimestre = declaration.Trimestre,
                ExerciceId = declaration.ExerciceId,
                Id = declaration.Id,
            };
        }

        public BindingList<LigneView> GetAllLigne(int declarationNo)
        {
            IEnumerable<LigneView> lignes = _service.FcSuspenssionService.GetAllLigne(declarationNo).Select(ToLigneView);
            return new BindingList<LigneView>(lignes.OrderBy(x => x.DateFacture).ToList());
        }

        private LigneView ToLigneView(LigneFc l)
        {
            return new LigneView
            {
                Id = l.Id,
                MontantDroitConsommation = l.MontantDroitConsommation,
                MontantFodec = l.MontantFodec,
                MontantTva = l.MontantTva,
                SocieteNo = l.SocieteNo,
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
                DeclarationNo = l.DeclarationNo,
                NumeroOrdre = l.NumeroOrdre
            };
        }

        internal void Gerer(DeclarationView declaration)
        {
            if (declaration == null) throw new ArgumentNullException("declaration");
            _service.FcSuspenssionService.DeclarationValiderFc(declaration.Id);
        }

        internal void Archiver(DeclarationView declaration)
        {
            if (declaration == null) throw new ArgumentNullException("declaration");
            _service.FcSuspenssionService.Archiver(declaration.Id);
        }

        internal LigneView AjouterLigne(LigneView view, DeclarationView declarationView)
        {
            if (view == null) throw new ArgumentNullException("view");
            if (declarationView == null) throw new ArgumentNullException("declarationView");
            // charger la declaration
            var declaration = _service.FcSuspenssionService.DeclarationGet(declarationView.Id);
            if (declaration == null) throw new ApplicationException("Déclaratoin invalide!");

            // verifier que la declaration n'est pas archivee
            if (declaration.IsArchive)
                throw new InvalidOperationException("Opération invalide! [Déclaration est archivée].");
            // verifier que la declration n'est pas cloturee
            if (declaration.IsCloture)
                throw new InvalidOperationException("Opération invalide! [Déclaration est clôturée].");
            // charger l'exercice
            var exercice = _service.Exercice;
            int annee;
            if (!int.TryParse(exercice.Annee, out annee))
                throw new ApplicationException("Exercice invalide!");
            // verifier que la date du facture est unclue dans le trimestre declarée
            switch (declaration.Trimestre)
            {
                case 1:
                    var dateDebutT1 = new DateTime(annee, 1, 1);
                    var dateFinT1 = new DateTime(annee, 3, 31);
                    if (view.DateFacture.Date < dateDebutT1 || view.DateFacture.Date > dateFinT1)
                        throw new InvalidOperationException(
                            "La date facture doit être inclue dans la premiére trimestre!");
                    break;
                case 2:
                    var dateDebutT2 = new DateTime(annee, 4, 1);
                    var dateFinT2 = new DateTime(annee, 6, 30);
                    if (view.DateFacture.Date < dateDebutT2 || view.DateFacture.Date > dateFinT2)
                        throw new InvalidOperationException(
                            "La date facture doit être inclue dans la deuxiéme trimestre!");
                    break;
                case 3:
                    var dateDebutT3 = new DateTime(annee, 7, 1);
                    var dateFinT3 = new DateTime(annee, 9, 30);
                    if (view.DateFacture.Date < dateDebutT3 || view.DateFacture.Date > dateFinT3)
                        throw new InvalidOperationException(
                            "La date facture doit être inclue dans la troisiéme trimestre!");
                    break;
                case 4:
                    var dateDebutT4 = new DateTime(annee, 10, 1);
                    var dateFinT4 = new DateTime(annee, 12, 31);
                    if (view.DateFacture.Date < dateDebutT4 || view.DateFacture.Date > dateFinT4)
                        throw new InvalidOperationException(
                            "La date facture doit être inclue dans la quatriéme trimestre!");
                    break;
                default:
                    throw new InvalidOperationException("Trimestre invalide!");
            }
            // TODO : verify view
            var id = _service.FcSuspenssionService.LigneCreate(
                declaration.Id,
                view.NumeroOrdre,
                view.NumeroFacture,
                view.DateFacture,
                view.TypeClient,
                view.IdentifiantClient,
                view.NomPrenomClient,
                view.AdresseClient,
                view.NumeroAutorisation,
                view.DateAutorisation,
                view.PrixVenteHt,
                view.TauxFodec,
                view.MontantFodec,
                view.TauxDroitConsommation,
                view.MontantDroitConsommation,
                view.TauxTva,
                view.MontantTva);
            // charger ligne declaratoin
            var ligne = _service.FcSuspenssionService.GetLigneDeclarationFcSupendue(id);
            if (ligne == null) throw new InvalidOperationException("Opération invalide!");
            return ToLigneView(ligne);
        }

        internal void Update(LigneView view)
        {
            if (view == null) throw new InvalidOperationException("Ligne invalide!");
            // charger la declaration
            var declaration = _service.FcSuspenssionService.DeclarationGet(view.DeclarationNo);
            if (declaration == null) throw new ApplicationException("Déclaratoin invalide!");

            // verifier que la declaration n'est pas archivee
            if (declaration.IsArchive)
                throw new InvalidOperationException("Opération invalide! [Déclaration est archivée].");
            // verifier que la declration n'est pas cloturee
            if (declaration.IsCloture)
                throw new InvalidOperationException("Opération invalide! [Déclaration est clôturée].");
            // charger l'exercice
            var exercice = _service.Exercice;
            int annee;
            if (!int.TryParse(exercice.Annee, out annee))
                throw new ApplicationException("Exercice invalide!");
            // verifier que la date du facture est unclue dans le trimestre declarée
            switch (declaration.Trimestre)
            {
                case 1:
                    var dateDebutT1 = new DateTime(annee, 1, 1);
                    var dateFinT1 = new DateTime(annee, 3, 31);
                    if (view.DateFacture.Date < dateDebutT1 || view.DateFacture.Date > dateFinT1)
                        throw new InvalidOperationException(
                            "La date facture doit être inclue dans la premiére trimestre!");
                    break;
                case 2:
                    var dateDebutT2 = new DateTime(annee, 4, 1);
                    var dateFinT2 = new DateTime(annee, 6, 30);
                    if (view.DateFacture.Date < dateDebutT2 || view.DateFacture.Date > dateFinT2)
                        throw new InvalidOperationException(
                            "La date facture doit être inclue dans la deuxiéme trimestre!");
                    break;
                case 3:
                    var dateDebutT3 = new DateTime(annee, 7, 1);
                    var dateFinT3 = new DateTime(annee, 9, 30);
                    if (view.DateFacture.Date < dateDebutT3 || view.DateFacture.Date > dateFinT3)
                        throw new InvalidOperationException(
                            "La date facture doit être inclue dans la troisiéme trimestre!");
                    break;
                case 4:
                    var dateDebutT4 = new DateTime(annee, 10, 1);
                    var dateFinT4 = new DateTime(annee, 12, 31);
                    if (view.DateFacture.Date < dateDebutT4 || view.DateFacture.Date > dateFinT4)
                        throw new InvalidOperationException(
                            "La date facture doit être inclue dans la quatriéme trimestre!");
                    break;
                default:
                    throw new InvalidOperationException("Trimestre invalide!");
            }

            _service.FcSuspenssionService.UpdateLigne(
                view.Id,
                view.NumeroAutorisation,
                view.NumeroFacture,
                view.DateFacture,
                view.DateAutorisation,
                view.TypeClient,
                view.IdentifiantClient,
                view.NomPrenomClient,
                view.MontantFodec,
                view.MontantTva,
                view.PrixVenteHt,
                view.MontantDroitConsommation,
                view.TauxDroitConsommation,
                view.TauxFodec,
                view.TauxTva);
        }

        internal void Delete(LigneView ligne)
        {
            if (ligne == null) throw new ArgumentNullException("ligne");
            _service.FcSuspenssionService.LigneDelete(ligne.Id);
        }

        internal void Delete(DeclarationView declaration)
        {
            if (declaration == null) throw new ArgumentNullException("declaration");
            _service.FcSuspenssionService.DeclarationDelete(declaration.Id);
        }

        internal void Editer(DeclarationView declaration)
        {
            if (declaration == null) throw new ArgumentNullException("declaration");
            _service.FcSuspenssionService.Editer(declaration.Id);
        }

        internal void Exporter(DeclarationView currentDeclaration, string path)
        {
            if (currentDeclaration == null) throw new ArgumentNullException("currentDeclaration");
            _service.FcSuspenssionService.Exports(currentDeclaration.Id, path);
        }

        internal Societe GetCurrentSociete()
        {
            return _service.Societe;
        }

        internal Exercice GetCurrentExercice()
        {
            return _service.Exercice;
        }

        public DeclarationView InitDeclaration()
        {
            return new DeclarationView
            {
                ExerciceId = _service.Exercice.Id,
                Trimestre = 1,
                Date = DateTime.Now,
                IsArchive = false,
                IsCloture = false,
                Societe = _service.Societe.RaisonSocial,
                Annee = _service.Exercice.Annee
            };
        }

        public void CreateDeclaration(DeclarationView view)
        {
            _service.FcSuspenssionService.DeclarationCreate(view.Trimestre);
        }
    }
}