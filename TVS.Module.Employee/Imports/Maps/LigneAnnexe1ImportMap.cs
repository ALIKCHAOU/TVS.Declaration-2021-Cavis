using System;
using CsvHelper.Configuration;
using TVS.Module.Employee.Imports.Views;

namespace Tvs.Module.Employee.Imports.Maps
{
    public sealed class LigneAnnexeUnImportMap : CsvClassMap<LigneAnnexe1ImportView>
    {
        public LigneAnnexeUnImportMap()
        {
            Map(x => x.BeneficiaireType)
                .Name("Type identifiant", "TYPE IDENTIFIANT", "TYPE",
                    "type identifiant", "Type Identifiant", "A107");

            Map(x => x.BeneficiaireIdent)
                .Name("Identifiant", "IDENTIFIANT", "Cin", "CIN",
                    "Matricule fiscal", "Matricule Fiscal", "A108");

            Map(x => x.Beneficiaire)
                .Name("Nom et prenom", "Nom et prénom", "Bénéficiaire", " Beneficiaire", "A109");

            Map(x => x.Nom).Name("NOM", "Nom", "nom").Default(string.Empty);

            Map(x => x.Prenom).Name("PRENOM", "Prenom", "prenom", "Prénom", "prénom").Default(string.Empty);

            Map(x => x.BeneficiaireActivite)
                .Name("Activite", "Activité", "Fonction", "fonction", "activite", "activité", "FONCTION", "ACTIVITE",
                    "A110");

            Map(x => x.BeneficiaireAdresse)
                .Name("Adresse", "ADRESSE", "adresse", "A111");

            Map(x => x.SituationFamiliale)
                .Name("Situation", "Situation familiale", "SITUATION FAMILIALE", "situation familiale",
                    "Situation Familiale", "A112");

            Map(x => x.NombreEnfantStr)
                .Name("Nombre  d'enfant", "Nombre enfant", "Nbr enfants", "A113")
                .Default("0");

            Map(x => x.DateDebutTravail)
                .Name("Date début", "Date debut", "DATE DEBUT", "date debut", "A114").Default(new DateTime(2016, 1, 1));

            Map(x => x.DateFinTravail)
                .Name("Date Fin", "DATE FIN", "date fin", "A115").Default(new DateTime(2016, 12, 31));

            Map(x => x.DureeEnJourStr)
                .Name("Période Jours", "Duree en jours", "DureeEnJours", "Periode en jours", "A116")
                .Default("0");

            Map(x => x.RevenuImposableStr)
                .Name("Revenue Imposable", "revenue imposable", "REVENUE IMPOSABLE", "A117")
                .Default("0");

            Map(x => x.AvantageEnNatureStr)
                .Name("Valeur Avantage", " valeur avantage", "VALEUR AVANTAGE", "Valeur en nature", "A118")
                .Default("0");

            Map(x => x.RevenuBrutImposableStr)
                .Name("Total Revenue Imposable", "Revenue Brut Imposable", "revenue brut imposable",
                    "REVENUE BRUT IMPOSABLE", "A119")
                .Default("0");

            Map(x => x.RevenuReinvestiStr)
                .Name("Revenue Réinvesti", "Revenue reinvesti", "REVENUE REINVESTI", "Revenue Reinvesti", "A120")
                .Default("0");

            Map(x => x.MontantRetenuesRegimeCommunStr)
                .Name("Retenue Opère", "Retenue regime commun", "Retenue Regime Commun", "RETENUE REGIME COMMUN",
                    "Retenue Opere",
                    "retenue regime commun", "A121")
                .Default("0");

            Map(x => x.Irpp1Str).Name("Irpp1", "IRPP1").Default("0");
            Map(x => x.Irpp2Str).Name("Irpp2", "IRPP2").Default("0");
            Map(x => x.Irpp3Str).Name("Irpp3", "IRPP3").Default("0");
            Map(x => x.GaSituationFamiliale).Name("S Fam");

            Map(x => x.MontantRetenuesTauxVingtStr)
                .Name("Retenue 20%", " retenue 20%", "RETENUE 20%", "Retenue 20", "retenue 20", "RETENUE 20", "A122")
                .Default("0");

            Map(x => x.MontantNetServieStr)
                .Name("Montant Net Servi", " MONTANT NET SERVI", "montant net servi", "A123")
                .Default("0");

            Map(x => x.RetenueUnPrctStr)
                .Name("RetenueUnPrct","retenu 1%","A198")
                .Default("0");

            Map(x => x.ContributionConjoncturelleStr)
                .Name("Contribution Conjoncturelle", "contribution conjoncturelle", "A199")
                .Default("0");

            Map(x => x.SalaireNonImposableStr)
                .Name("Salaire non imposable", "salaire non imposable", "A200")
                .Default("0");

           

            Map(x => x.ContributionSocialeSolid)
              .Name("Contribution Sociale Solidarité", "contribution sociale solidarite", "A201")
              .Default("0");

            Map(x => x.ChefFamilletStr)
               .Name("ChefFamille", "Chef Famille", "cheffamille")
             .Default("0");

          

            Map(x => x.IntereDetectible)
             .Name("IntereDetectible", "Intere Detectible", "Intere detectible")
             .Default("0");



        }
    }
}