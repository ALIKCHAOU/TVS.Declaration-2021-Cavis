using CsvHelper.Configuration;

namespace TVS.Module.Virement.Imports.Views
{
    public sealed class LigneImportMap : CsvClassMap<LigneImportView>
    {
        public LigneImportMap()
        {
            Map(x => x.Matricule)
                .Name("Matricule");

            Map(x => x.Nom)
                .Name("Nom");

            Map(x => x.Prenom)
                .Name("Prenom");

            Map(x => x.NomBanque)
                .Name("NomBanque");

            Map(x => x.CodeBanque)
                .Name("CodeBanque");

            Map(x => x.CodeGuichet)
                .Name("CodeGuichet");

            Map(x => x.NumeroCompte)
                .Name("NumeroCompte");

            Map(x => x.CleRib)
                .Name("CleRib");

            Map(x => x.NetAPayeStr)
                .Name("NetAPaye").Default("0"); ;

            Map(x => x.Motif)
                .Name("Motif");

        }
    }
}