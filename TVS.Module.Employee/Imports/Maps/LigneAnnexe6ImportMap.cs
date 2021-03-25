using System;
using CsvHelper.Configuration;
using TVS.Module.Employee.Imports.Views;

namespace Tvs.Module.Employee.Imports.Maps
{
    public sealed class LigneAnnexeSixImportMap : CsvClassMap<LigneAnnexe6ImportView>
    {
        public LigneAnnexeSixImportMap()
        {
            Map(x => x.BeneficiaireType)
                .Name("Type identifiant", "TYPE IDENTIFIANT", "TYPE",
                    "type identifiant", "Type Identifiant", "A607");

            Map(x => x.BeneficiaireIdent)
                .Name("Identifiant", "IDENTIFIANT", "Cin", "CIN",
                    "Matricule fiscal", "Matricule Fiscal", "A608");

            Map(x => x.Beneficiaire)
                .Name("Nom et prenom", "Nom et prénom", "Bénéficiaire", " Beneficiaire", "Nom", "NOM", "A609");

            Map(x => x.BeneficiaireActivite)
                .Name("Activite", "Activité", "Fonction", "fonction", "activite", "activité", "FONCTION", "ACTIVITE",
                    "A610");

            Map(x => x.BeneficiaireAdresse)
                .Name("Adresse", "ADRESSE", "adresse", "A611");

            Map(x => x.MontantRistournesStr)
                .Name("Montant des restournes", "Montant Des Restournes", "Restournes", "A612");

            Map(x => x.MontantVentesStr)
                .Name("Montant des ventes aux P.P", "A613");

            Map(x => x.MontantAvancesStr)
                .Name("Montant avence", "MONTANT AVANCE", "Montant Avance", "A614");

            Map(x => x.MontantRevenusJeuPariStr)
                .Name("Montant revenus jeu pari", "A615");

            Map(x => x.MontantRetenuJeuPariStr)
                .Name("Montant retenu jeu pari", "A616");
            Map(x => x.MontantVenteNeDepassantVingtStr)
                .Name("A617");
            Map(x => x.MontantRetenuNeDepassantVingtStr)
                .Name("A618");
            Map(x => x.MontantPercuesStr)
                .Name("Montant perçus en espèce", "Montant perçus"
                    , "MARCHANDISES VENDUES ET SERVICE RENDUS", "Marchandises vendues et service rendus", "A619");
        }
    }
}