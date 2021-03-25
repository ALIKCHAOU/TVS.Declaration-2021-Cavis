using CsvHelper.Configuration;

namespace TVS.Module.Cnss.Imports.Views
{
    public sealed class DeclarationCnssImportMap : CsvClassMap<LigneImportView>
    {
        public DeclarationCnssImportMap()
        {
            Map(x => x.Matricule)
                .Name("Matricule", "matricule", "MATRICULE", "Code interne")
                .Default("#");

            Map(x => x.NumeroCnss)
                .Name("N Cnss", "n cnss", "Numero Cnss", "numero Cnss", "numero cnss")
                .Default("#");

            Map(x => x.Annee)
                .Name("Annee", "ANNEE", "Année", "année", "annee")
                .Default(0);

            Map(x => x.AutresNom)
                .Name("AutresPrenoms", "Autre Prenom", "Autre prenom", "autre prénom", "Autre prénom", "Autres prenoms")
                .Default("");

            Map(x => x.BrutAStr)
                .Name("BrutA", "Brut1", "BRUTA", "BRUT1", "BRUT A", "BRUT 1", "Brut A", "brutA", "brut1", "brut 1",
                    "brut A", "m01", "m04", "m07", "m10", "M01", "M04", "M07", "M10");

            Map(x => x.BrutBStr)
                .Name("BrutB", "Brut2", "BRUTB", "BRUT2", "BRUT B", "BRUT 2", "Brut B", "brutB", "brut2", "brut 2",
                    "brut B", "m02", "m05", "m08", "m11", "M02", "M05", "M08", "M11");

            Map(x => x.BrutCStr)
                .Name("BrutC", "Brut3", "BRUTC", "BRUT3", "BRUT C", "BRUT 3", "Brut C", "brutC", "brut3", "brut 3",
                    "brut C", "m03", "m06", "m09", "m12", "M03", "M06", "M09", "M12");

            Map(x => x.Cin)
                .Name("cin", "CIN", "Cin")
                .Default("#");

            Map(x => x.CiviliteNo)
                .Name("Civilite", "civilite", "Civilité", "civilité")
                .Default(-1);

            Map(x => x.CleCnss)
                .Name("CleCnss", "Clé Cnss", "cle", "clé", "Clé", "Cle")
                .Default("#");

            Map(x => x.Nom)
                .Name("Nom", "nom", "NOM")
                .Default("#");

            Map(x => x.Prenom)
                .Name("Prénom", "Prenom", "prenom", "prénom", "PRENOM")
                .Default("#");

            Map(x => x.NomJeuneFille)
                .Name("NomJeuneFille", "Nom de Jeune Fille", "NOMJEUNEFILLE", "Nom de jeune fille");

            Map(x => x.TrimestreStr)
                .Name("Trimestre", "TRIMESTRE", "trimestre")
                .Default("0");

            Map(x => x.TypeCnssStr)
                .Name("TypeCnss", "Type Cnss", "Type cnss", "Type")
                .Default("0");

            Map(x => x.SituationFamilleStr)
                .Name("SituationFamiliale", "Situation Familiale", "Situation familiale", "situation")
                .Default("0");

            Map(x => x.AnneeStr)
                .Name("Annee", "annee", "Année", "année")
                .Default("0");
        }
    }
}