using System;
using System.Collections.Generic;
using System.Linq;
using TVS.Core;
using TVS.Core.Models;
using TVS.Module.FactureSuspenssion.Imports.Repository;
using TVS.Module.FactureSuspenssion.Imports.Views;

namespace TVS.Module.FactureSuspenssion.Imports.Controller
{
    public class ImportController
    {
        private readonly DeclarationService _service;
        private readonly IImportImportRepository _serviceImport;

        public ImportController(DeclarationService service, IImportImportRepository serviceImport)
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

        public List<LigneImportView> GetLigne(string path, int annee, int trimestre, int categorieNo)
        {
            List<LigneImportView> listImport = _serviceImport.GetAll(path).ToList();

            if (listImport.Any(x => x.Annee != annee)) throw new InvalidOperationException("Année invalide!");
            if (listImport.Any(x => x.Trimestre != trimestre))
                throw new InvalidOperationException("Trimestre invalide!");

            return listImport;
        }

        internal void Importer(DeclarationImportView declarationView)
        {
            var lignes = declarationView.Lignes.Select(ToLigneImport);
            var group = lignes.GroupBy(x => new {x.NumeroFacture});
            foreach (var list in group)
            {
               // if (list.ToList().Count != 1)
                //    throw new InvalidOperationException(list.Key + " est déclaré plusieurs fois!");
            }
            _service.FcSuspenssionService.ImporterLignes(declarationView.Id, lignes);
        }

        private LigneFc ToLigneImport(LigneImportView l)
        {
            return new LigneFc
            {
                MontantDroitConsommation = l.MontantDroitConsommation,
                MontantFodec = l.MontantFodec,
                MontantTva = l.MontantTva,
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
                NumeroOrdre = l.NumeroOrdre
            };
        }

        public DeclarationImportView GetDeclaration(int no)
        {
            var declaration = _service.FcSuspenssionService.DeclarationGet(no);
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
                CategorieNo = -1
            };
        }
    }
}