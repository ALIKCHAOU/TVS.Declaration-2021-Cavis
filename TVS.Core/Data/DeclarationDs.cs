using System;
using System.Collections.Generic;
using System.Linq;
using TVS.Core.Models;

namespace TVS.Core.Data
{
    public partial class DeclarationDs
    {


        public DeclarationDs(DeclarationService service, DeclarationCnss declaration)
            : this()
        {
            if (service == null) throw new ArgumentNullException("service");
            if (declaration == null) throw new InvalidOperationException("declaration");
            Societe societe = service.Societe;
            if (societe == null) throw new InvalidOperationException("Erreur chargement societe");
            List<CategorieCnss> categories = service.CnssService.GetAllCategories().ToList();
            foreach (CategorieCnss categorieCnss in categories)
            {
                tableTCategorie.AddTCategorieRow(categorieCnss.Id,
                    categorieCnss.Intitule,
                    categorieCnss.CodeExploitation,
                    categorieCnss.TauxPatronal,
                    categorieCnss.TauxSalarial,
                    categorieCnss.AccidentTravail);
            }
            var exercice = service.ExerciceGetAll().FirstOrDefault(x => x.Id == declaration.ExerciceId);
            if (exercice == null) throw new ArgumentNullException("exercice");
            var lignes = service.CnssService.GetLigneDeclarationCnss(declaration.Id);

            tableTSociete.AddTSocieteRow(societe.RaisonSocial,
                societe.Activite,
                societe.Adresse,
                societe.CodePostal,
                societe.Ville,
                societe.Pays,
                societe.NumeroEmployeur.PadLeft(8, '0'),
                $"{societe.MatriculFiscal} {societe.MatriculCle}/{societe.MatriculCodeTva}/{societe.MatriculCategorie}/{societe.MatriculEtablissement}",
                societe.CodeBureau,
                exercice.Annee,
                declaration.Trimestre,
                societe.CleEmployeur.PadLeft(2, '0'), societe.MatriculCle, societe.MatriculCategorie, societe.MatriculEtablissement, societe.MatriculCodeTva);
            foreach (LigneCnss ligne in lignes)
            {
                CategorieCnss cat = categories.Single(x => x.Id == ligne.CategorieNo);
                if (cat == null) throw new InvalidOperationException("Catégorie");
                tableTDeclaration.AddTDeclarationRow(ligne.Id,
                    ligne.Page.Value,
                    ligne.Ligne.Value,
                    ligne.Brut1,
                    ligne.Brut2,
                    ligne.Brut3,
                    cat.Intitule,
                    ligne.CodeExploitation,
                    ligne.NumeroCnss,
                    ligne.CleCnss,
                    ligne.Cin,
                    ligne.Nom,
                    ligne.Prenom,
                    ligne.Civilite.ToString(),
                    ligne.AutresNom,
                    ligne.NomJeuneFille,
                    ligne.NumeroInterne,
                    cat.Id);
            }
        }
    }
}