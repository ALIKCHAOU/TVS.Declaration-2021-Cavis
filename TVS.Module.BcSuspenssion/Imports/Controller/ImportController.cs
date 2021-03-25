using System;
using System.Collections.Generic;
using System.Linq;
using TVS.Core;
using TVS.Core.Models;
using TVS.Module.BcSuspenssion.Imports.Repository;
using TVS.Module.BcSuspenssion.Imports.Views;

namespace TVS.Module.BcSuspenssion.Imports.Controller
{
    public class ImportController
    {
        private readonly DeclarationService _service;
        private readonly ILigneImportRepository _serviceImport;

        public ImportController(DeclarationService service, ILigneImportRepository serviceImport)
        {
            if (service == null) throw new ArgumentNullException("service");
            _service = service;
            _serviceImport = serviceImport;
        }

        public DeclarationImportView InitDeclaration()
        {
            return new DeclarationImportView
            {
                RaisonSocial = _service.Societe.RaisonSocial,
                Exercice = _service.Exercice.Annee,
                ExerciceId = _service.Exercice.Id,
                NumeroEmployeur = _service.Societe.NumeroEmployeur,
                Trimestre = 1,
                Date = DateTime.Now,
                SocieteId = _service.Societe.Id,
                Path = string.Empty,
                CategorieNo = -1,
            };
        }

        public List<LigneBcSuspendueImportView> GetLigne(string path, int annee, int trimestre, int categorieNo)
        {
            var listImport = _serviceImport.GetAll(path).ToList();

            return listImport;
        }

        internal void Importer(DeclarationImportView declarationView)
        {
            var lignes = declarationView.Lignes.Select(x=>ToLigneImport(x,declarationView));
            //var group = lignes.GroupBy(x => new {x.NumeroBonCommande});
            //foreach (var list in group)
            //{
            //    if (list.ToList().Count != 1)
            //        throw new InvalidOperationException(list.Key + " est déclaré plusieurs fois!");
            //}

            _service.BcSuspenssionService.ImporterLignes(declarationView.Id, lignes);
        }

        private LigneBc ToLigneImport(LigneBcSuspendueImportView ligne , DeclarationImportView declartion)
        {
            return new LigneBc
            {
                DateBonCommande = ligne.DateBonCommande,
                DateFacture = ligne.DateFacture,
                Identifiant = ligne.Identifiant,
                MontantTva = ligne.MontantTva,
                NumeroAutorisation = string.IsNullOrEmpty( ligne.NumeroAutorisation) ? declartion.NumeroAutorisation : ligne.NumeroAutorisation,
                NumeroBonCommande = ligne.NumeroBonCommande,
                NumeroFacture = ligne.NumeroFacture,
                ObjetFacture = ligne.ObjetFacture,
                PrixAchatHorsTaxe = ligne.PrixAchatHorsTaxeMontantTva,
                RaisonSocialFournisseur = ligne.RaisonSocialFournisseur,
            };
        }

        public DeclarationImportView GetDeclaration(int no)
        {
            var declaration = _service.BcSuspenssionService.DeclarationGet(no);
            var exercice = _service.Exercice;
            return new DeclarationImportView
            {
                Id = declaration.Id,
                RaisonSocial = _service.Societe.RaisonSocial,
                Exercice = exercice.Annee,
                ExerciceId = declaration.ExerciceId,
                NumeroEmployeur = _service.Societe.NumeroEmployeur,
                Trimestre = declaration.Trimestre,
                Date = declaration.Date,
                SocieteId = _service.Societe.Id,
                Path = string.Empty,
                CategorieNo = -1,
                NumeroAutorisation = declaration.NumeroAutorisation
            };
        }
    }
}