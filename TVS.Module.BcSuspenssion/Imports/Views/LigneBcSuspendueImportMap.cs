using CsvHelper.Configuration;

namespace TVS.Module.BcSuspenssion.Imports.Views
{
    public sealed class LigneBcSuspendueImportMap : CsvClassMap<LigneBcSuspendueImportView>
    {
        public LigneBcSuspendueImportMap()
        {
            Map(x => x.NumeroAutorisation)
                .Name("N° Autorisation", "numéro autorisation", "Numéro Autorisation",
                    "N°Autorisation", "n°autorisation", "num autorisation", "N° AUTORISATION");

            Map(x => x.NumeroBonCommande)
                .Name("N° BC", "N° Bon Commande", "N° bon commande", "N° Bon de commande",
                    "N° BON DE COMMANDE", "N° BON COMMANDE", "Numéro bon de commande", "Numero bon commande",
                    "N BC", "n bc");

            Map(x => x.DateBonCommande)
                .Name("Date BC", "Date bon commande", "Date bon  de commande",
                    "DATE BON DE COMMANDE", "DATE BON COMMANDE", "date bon commande", "date bon de commande");

            Map(x => x.NumeroFacture)
                .Name("N° Facture", "N° facture", "Numéro Facture", "Numero Facture",
                    "numero facture", "n° facture");

            Map(x => x.DateFacture)
                .Name("Date facture", "Date Facture", "DATE FACTURE", "date facture", "Date FC", "date fc");

            Map(x => x.Identifiant)
                .Name("Identifiant", "identifiant", "IDENTIFIANT");

            Map(x => x.RaisonSocialFournisseur)
                .Name("Raison sociale frs.", "Nom et prenom fournisseur", "NOM ET PRENOM FOURNISSEUR", "Fournisseur",
                    "Nom et prénom ou raison sociale du fournisseur");

            Map(x => x.PrixAchatHorsTaxeStr)
                .Name("Prix achat HT", "Prix achat Hors Taxe", "PRIX ACHAT HORS TAXE", "prix achat hors taxe",
                    "prix achat ht", "Prix Achat HT", "Prix achat HT");

            Map(x => x.MontantTvaStr)
                .Name("Montant TVA", "MONTANT TVA", "montant TVA", "montant tva",
                    "Mt TVA", "Montant tva");

            Map(x => x.ObjetFacture)
                .Name("Objet Facture", "OBJET FACTURE", "objet facture", "Objet facture", "Objet Fact");

            Map(x => x.TrimestreStr)
                .Name("Trimestre", "TRIMESTRE", "trimestre")
                .Default("0");

            Map(x => x.AnneeStr)
                .Name("Annee", "annee", "Année", "année")
                .Default("0");
        }
    }
}