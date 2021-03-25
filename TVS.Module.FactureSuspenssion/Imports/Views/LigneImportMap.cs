using CsvHelper.Configuration;

namespace TVS.Module.FactureSuspenssion.Imports.Views
{
    public sealed class LigneImportMap : CsvClassMap<LigneImportView>
    {
        public LigneImportMap()
        {
            Map(x => x.NumeroAutorisation)
                .Name("N° Autorisation", "numéro autorisation", "Numéro Autorisation",
                    "N°Autorisation", "n°autorisation", "num autorisation", "N° AUTORISATION");

            Map(x => x.DateAutorisation)
                .Name("Date autorisation", "Date Autorisation", "DATE AUTORISATION", "date autorisation");

            Map(x => x.NumeroFacture)
                .Name("N° Facture", "N° facture", "Numéro Facture", "Numero Facture",
                    "numero facture", "n° facture");

            Map(x => x.DateFacture)
                .Name("Date facture", "Date Facture", "DATE FACTURE", "date facture", "Date FC", "date fc");

            Map(x => x.IdentifiantClient)
                .Name("Identifiant", "identifiant", "IDENTIFIANT");

            Map(x => x.AdresseClient)
                .Name("Adresse client", "ADRESSE CLIENT", "Adresse Client", "Adresse");

            Map(x => x.TypeClient)
                .Name("Type identifiant client", "Type identifiant du client", "TYPE IDENTIFIANT CLIENT",
                    "TYPE IDENTIFIANT DU CLIENT")
                .Default(1);

            Map(x => x.NomPrenomClient)
                .Name("Raison sociale client", "Nom et prenom client", "NOM ET PRENOM CLIENT", "Client",
                    "Nom et prénom ou raison sociale du client");

            Map(x => x.PrixVenteHtStr)
                .Name("Prix vente HT", "Prix vente Hors Taxe", "PRIX VENTE HORS TAXE", "prix vente hors taxe",
                    "prix vente ht", "Prix Vente HT", "Prix vente HT");

            Map(x => x.MontantTvaStr)
                .Name("Montant TVA", "MONTANT TVA", "montant TVA", "montant tva",
                    "Mt TVA", "Montant tva");

            Map(x => x.TauxFodecStr)
                .Name("Taux FODEC", "TAUX FODEC", "Taux fodec", "taux fodec");

            Map(x => x.MontantFodecStr)
                .Name("Montant FODEC", "MONTANT FODEC", "montant fodec", "Montant fodec");

            Map(x => x.TauxDroitConsommationStr)
                .Name("Taux droit de consommation", "taux droit de consommation", "droit de consommation");

            Map(x => x.MontantDroitConsommationStr)
                .Name("Montant droit consommation", "MONTANT DROIT CONSOMMATION", "Montant consommation");

            Map(x => x.TauxTvaStr)
                .Name("Taux TVA", "TAUX TVA", "taux TVA", "taux tva");

            Map(x => x.TrimestreStr)
                .Name("Trimestre", "TRIMESTRE", "trimestre")
                .Default("0");

            Map(x => x.AnneeStr)
                .Name("Annee", "annee", "Année", "année")
                .Default("0");
        }
    }
}