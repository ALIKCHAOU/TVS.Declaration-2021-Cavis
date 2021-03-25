using System;
using System.Collections.Generic;
using System.Linq;
using TVS.Core;
using TVS.Core.Enums;
using TVS.Core.Models;
using TVS.Module.Cnss.Imports.Views;

namespace TVS.Module.Cnss.Imports.Controller
{
    public class ImportController
    {
        private readonly DeclarationService _service;
        private readonly IDeclarationCnssImportRepository _serviceImport;

        public ImportController(DeclarationService service, IDeclarationCnssImportRepository serviceImport)
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
                Complementaire = false,
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

            //si la categorie egale a -1 =>l'utilisateur choisit d'importer toutes les categories
            //si non, l'utilisateur choisit d'importer une seule catégorie
            if (categorieNo != -1)
            {
                CategorieCnss categorie = _service.CnssService.GetAllCategories().Single(x => x.Id == categorieNo);
                foreach (LigneImportView ligneImportView in listImport)
                {
                    ligneImportView.TypeCnssStr = categorie.No.ToString();
                }
            }
            return listImport;
        }

        public List<CategorieView> GetAllCategories()
        {
            return _service.CnssService.GetAllCategories().Select(ToViewCategorie).ToList();
        }

        public CategorieView ToViewCategorie(CategorieCnss categorieCnss)
        {
            return new CategorieView
            {
                TauxPatronal = categorieCnss.TauxPatronal,
                AccidentTravail = categorieCnss.AccidentTravail,
                TauxSalarial = categorieCnss.TauxSalarial,
                CodeExploitation = categorieCnss.CodeExploitation,
                Intitule = categorieCnss.Intitule,
                No = categorieCnss.No,
                Id = categorieCnss.Id
            };
        }

        internal void Importer(DeclarationImportView declarationView)
        {
            var lignes = declarationView.Lignes.Select(ToLigneImport);
            var group = lignes.GroupBy(x => new {x.Cin, x.Matricule});
            foreach (var list in group)
            {
                var w = list.GroupBy(x => x.TypeCnss).ToList();
                foreach (var g in w)
                {
                    if (g.ToList().Count != 1)
                        throw new InvalidOperationException(list.Key.Cin + " est déclaré plusieurs fois!");
                }
            }

            _service.CnssService.ImporterLignesCnss(declarationView.Id,
                lignes);
        }

        private LigneImport ToLigneImport(LigneImportView ligne)
        {
            return new LigneImport
            {
                Annee = ligne.Annee,
                Cin = ligne.Cin,
                TypeCnss = ligne.TypeCnss,
                Trimestre = ligne.Trimestre,
                AutresNom = ligne.AutresNom,
                BrutA = ligne.BrutA,
                BrutB = ligne.BrutB,
                BrutC = ligne.BrutC,
                Civilite = (Civilite) ligne.CiviliteNo,
                CleCnss = ligne.CleCnss,
                Matricule = ligne.Matricule,
                Nom = ligne.Nom,
                NomJeuneFille = ligne.NomJeuneFille,
                NumeroCnss = ligne.NumeroCnss,
                Prenom = ligne.Prenom,
                SituationFamille = (SituationFamille) ligne.SituationFamilleNo
            };
        }

        public DeclarationImportView GetDeclaration(int no)
        {
            var declaration = _service.CnssService.DeclarationGet(no);
            var exercice = _service.Exercice;
            return new DeclarationImportView
            {
                Id = declaration.Id,
                RaisonSocial = _service.Societe.RaisonSocial,
                Complementaire = declaration.Complementaire,
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