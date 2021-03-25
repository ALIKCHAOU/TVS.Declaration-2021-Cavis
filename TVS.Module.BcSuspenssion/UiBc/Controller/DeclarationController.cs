using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TVS.Core;
using TVS.Core.Models;
using TVS.Module.BcSuspenssion.UiBc.Views;

namespace TVS.Module.BcSuspenssion.UiBc.Controller
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
            return _service.BcSuspenssionService.DeclarationAll().Select(ToView).OrderBy(x => x.Trimestre).ToList();
        }

        public DeclarationView GetDeclaration(int no)
        {
            return ToView(_service.BcSuspenssionService.DeclarationGet(no));
        }

        private DeclarationView ToView(DeclarationBc declaration)
        {
            return new DeclarationView
            {
                Date = declaration.Date,
                IsArchive = declaration.IsArchive,
                IsCloture = declaration.IsCloture,
                Trimestre = declaration.Trimestre,
                ExerciceId = declaration.ExerciceId,
                Id = declaration.Id,
                NumeroAutorisation = declaration.NumeroAutorisation
            };
        }

        public BindingList<LigneView> GetAllLigne(int declarationNo)
        {
            IEnumerable<LigneView> lignes = _service.BcSuspenssionService.GetAllLigne(declarationNo).Select(ToLigneView);
            return new BindingList<LigneView>(lignes.OrderBy(x => x.DateBonCommande).ToList());
        }

        private LigneView ToLigneView(LigneBc ligne)
        {
            return new LigneView
            {
                Id = ligne.Id,
                NumeroOrdre = ligne.NumeroOrdre,
                DateBonCommande = ligne.DateBonCommande,
                DateFacture = ligne.DateFacture,
                Identifiant = ligne.Identifiant,
                MontantTva = ligne.MontantTva,
                NumeroAutorisation = ligne.NumeroAutorisation,
                NumeroBonCommande = ligne.NumeroBonCommande,
                NumeroFacture = ligne.NumeroFacture,
                ObjetFacture = ligne.ObjetFacture,
                PrixAchatHorsTaxe = ligne.PrixAchatHorsTaxe,
                RaisonSocialFournisseur = ligne.RaisonSocialFournisseur,
                DeclarationNo = ligne.DeclarationNo,
                SocieteNo = ligne.SocieteNo
            };
        }

        internal void Gerer(DeclarationView declaration)
        {
            if (declaration == null) throw new ArgumentNullException("declaration");
            _service.BcSuspenssionService.DeclarationValider(declaration.Id);
        }

        internal void Archiver(DeclarationView declaration)
        {
            if (declaration == null) throw new ArgumentNullException("declaration");
            _service.BcSuspenssionService.Archiver(declaration.Id);
        }

        internal void Update(LigneView ligne)
        {
            if (ligne == null) throw new InvalidOperationException("Ligne invalide!");

            _service.BcSuspenssionService.UpdateLigne(
                ligne.Id,
                ligne.NumeroAutorisation,
                ligne.NumeroBonCommande,
                ligne.DateBonCommande,
                ligne.NumeroFacture,
                ligne.DateFacture,
                ligne.Identifiant,
                ligne.RaisonSocialFournisseur,
                ligne.PrixAchatHorsTaxe,
                ligne.MontantTva,
                ligne.ObjetFacture);
        }

        internal LigneView CreateLigne(LigneView view, DeclarationView declarationView)
        {
            if (view == null) throw new ArgumentNullException("view");
            if (declarationView == null) throw new ArgumentNullException("declarationView");
            // charger la declaration
            var declaration = _service.BcSuspenssionService.DeclarationGet(declarationView.Id);
            if (declaration == null) throw new ApplicationException("Déclaratoin invalide!");

            // verifier que la declaration n'est pas archivee
            if (declaration.IsArchive)
                throw new InvalidOperationException("Opération invalide! [Déclaration est archivée].");
            // verifier que la declration n'est pas cloturee
            if (declaration.IsCloture)
                throw new InvalidOperationException("Opération invalide! [Déclaration est clôturée].");
            // verifier que la date du bon de commande est inferieur au date du facture
            if (view.DateFacture < view.DateBonCommande)
                throw new ApplicationException("La date du bon de commande doit être inférieur au date facture!");
            // TODO : verify view
            var id = _service.BcSuspenssionService.LigneDeclarationCreate(
                declarationView.Id,
                view.NumeroAutorisation,
                view.NumeroBonCommande,
                view.DateBonCommande,
                view.NumeroFacture,
                view.DateFacture,
                view.Identifiant,
                view.RaisonSocialFournisseur,
                view.PrixAchatHorsTaxe,
                view.MontantTva,
                view.ObjetFacture);
            // charger ligne bon commande suspendue
            var newView = _service.BcSuspenssionService.GetLigneDeclarationBcSupendue(id);
            if (newView == null) throw new ApplicationException("Linge bon de commande en suspension invalide!");

            return ToLigneView(newView);
        }

        internal void Delete(LigneView ligne)
        {
            if (ligne == null) throw new ArgumentNullException("ligne");
            _service.BcSuspenssionService.LigneBcDelete(ligne.Id);
        }

        internal void Delete(DeclarationView declaration)
        {
            if (declaration == null) throw new ArgumentNullException("declaration");
            _service.BcSuspenssionService.DeclarationDelete(declaration.Id);
        }

        internal void Editer(DeclarationView declaration)
        {
            if (declaration == null) throw new ArgumentNullException("declaration");
            _service.BcSuspenssionService.Editer(declaration.Id);
        }

        internal void Exporter(DeclarationView currentDeclaration, string path)
        {
            if (currentDeclaration == null) throw new ArgumentNullException("currentDeclaration");
            _service.BcSuspenssionService.Exports(currentDeclaration.Id, path);
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
            _service.BcSuspenssionService.DeclarationCreate(view.Trimestre, view.NumeroAutorisation);
        }
    }
}