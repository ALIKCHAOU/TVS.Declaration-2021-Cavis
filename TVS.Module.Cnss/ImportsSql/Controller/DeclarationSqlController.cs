using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core;
using TVS.Core.Enums;
using TVS.Core.Models;
using TVS.Module.Cnss.Imports.Views;
using TVS.Module.Cnss.ImportsSql.Views;

namespace TVS.Module.Cnss.ImportsSql.Controller
{
    public class DeclarationSqlController
    {
        private readonly DeclarationService _service;

        public DeclarationSqlController(DeclarationService service)
        {
            if (service == null) throw new ArgumentNullException("service");
            _service = service;
        }

        public DeclarationImportSqlView InitDeclaration()
        {
            return new DeclarationImportSqlView
            {
                RaisonSocial = _service.Societe.RaisonSocial,
                Complementaire = false,
                Exercice = _service.Exercice.Annee,
                ExerciceId = _service.Exercice.Id,
                NumeroEmployeur = _service.Societe.NumeroEmployeur,
                Trimestre = 1,
                Date = DateTime.Now,
                SocieteId = _service.Societe.Id,
                CategorieNo = 0,
            };
        }

        public List<LigneSqlView> GetLigne(int annee, int trimestre, int categorieNo, string etablissement)
        {
            var categorie = _service.CnssService.GetAllCategories().FirstOrDefault(x => x.Id == categorieNo);
            if(categorie == null)throw new InvalidOperationException("Catégorie invalide!");
            if(string.IsNullOrEmpty(categorie.CodePaie))
                throw new InvalidOperationException("Veuillez configurer la catégorie CNSS");
            var dateMin = new DateTime(annee, (trimestre - 1 )* 3 + 1,1);
            var dateMax = dateMin.AddMonths(3).AddDays(-1);
            if(categorie.TypeVariablePaie == TypeVariablePaie.Rubrique)
                return LigneSqlRepository.GetLigneRubrique(_service.Societe , categorie , dateMin , dateMax, etablissement).ToList();
            return LigneSqlRepository.GetLigneConstante(_service.Societe, categorie, dateMin, dateMax, etablissement).ToList();

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

        internal void Importer(DeclarationImportSqlView declarationView)
        {
            var categorie = _service.CnssService.GetAllCategories().FirstOrDefault(x => x.Id == declarationView.CategorieNo);
            if(categorie == null)throw new InvalidOperationException("Catégorie invalide!");
            var lignes = declarationView.Lignes.Select(x=>ToLigneImport(x, categorie.No,declarationView.Trimestre,int.Parse(declarationView.Exercice)));
            var group = lignes.GroupBy(x => new { x.Cin, x.Matricule });
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

        private LigneImport ToLigneImport(LigneSqlView ligne, int typeCnss, int trimestre , int annee)
        {
            return new LigneImport
            {
                Annee = annee,
                Cin = ligne.Cin,
                TypeCnss = typeCnss,
                Trimestre = trimestre,
                AutresNom = ligne.AutreNom,
                BrutA = ligne.BrutA,
                BrutB = ligne.BrutB,
                BrutC = ligne.BrutC,
                Civilite = ligne.Civilite,
                CleCnss = ligne.CleCnss,
                Matricule = ligne.Matricule,
                Nom = ligne.Nom,
                NomJeuneFille = ligne.NomJeuneFille,
                NumeroCnss = ligne.NumCnss,
                Prenom = ligne.Prenom,
                SituationFamille = ligne.SituationFamille
            };
        }

        public DeclarationImportSqlView GetDeclaration(int no)
        {
            var declaration = _service.CnssService.DeclarationGet(no);
            var exercice = _service.Exercice;
            return new DeclarationImportSqlView
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
                CategorieNo = 0
            };
        }

        public IEnumerable<EtabSqlView> GetEtb()
        {
            return LigneSqlRepository.GetEtb(_service.Societe);
        }
    }
}