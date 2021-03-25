using System.Collections.Generic;

namespace TVS.Module.Liasse.Model
{
    public class F6002:IF600X
    {
        public F6002(Core.Models.Liass.F6002 mf6002)
        {
            Mf6002 = mf6002;
            Lignes= new List<LigneLiasse>();
            for (int j = 1; j <= 53; j++)
            {
                Lignes.Add(new LigneLiasse()
                {
                    Ordre = j,
                    CodeN = $"F60020{j:000}",
                    CodeN1 = $"F60020{j+53:000}",
                    Libelle = Libelles[j-1],
                    ObjectLiasse = mf6002
                });
            }

        }

        public List<LigneLiasse> Lignes { get; set; }
        public Core.Models.Liass.F6002 Mf6002 { get; private set; }

        List<string> Libelles = new List<string>() {@"Capitaux propres",
            @"Capital social",
            @"Réserves",
            @"Autres capitaux propres",
            @"Résultats reportés",
            @"Capitaux propres avant résultat de l'exercice",
            @"Résultat de l'exercice",
            @"Total Passifs",
            @"Passifs non courants",
            @"Emprunts",
            @"Emprunts obligataires (assortis de séretés)",
            @"Empts auprés d'étab.Fin. (assortis de séretés)",
            @"Empts auprés d'étab.Fin. (assorti de séretés)",
            @"Empts et dettes assorties de condit. particuliéres",
            @"Emprunts non assortis de séretés",
            @"Dettes rattachées à des participations",
            @"Dépéts  et  cautionnements reéus",
            @"Autres emprunts et dettes",
            @"Autres Passifs Financiers",
            @"Ecarts de conversion",
            @"Autres passifs financiers",
            @"Provisions",
            @"Provisions pour risques",
            @"Prov.pour charges et répartir/plusieurs exercices",
            @"Prov.pour retraites et obligations similaires",
            @"Provisions d'origine réglementaire",
            @"Provisions pour impéts",
            @"Prov.pour renouvellement des immobilisations",
            @"Provisions pour amortissement",
            @"Autres provisions pour charges",
            @"Passifs courants",
            @"Fournisseurs et Comptes Rattachés",
            @"Fournisseurs d'exploitation",
            @"Fournisseurs d'exploitation - effets à payer",
            @"Fournisseurs d'immobilisations",
            @"Fournisseurs d'immobilisations - effets à payer",
            @"Fournisseurs - factures non parvenues",
            @"Autres passifs courants",
            @"Clients créditeurs",
            @"Personnels et comptes rattachés ",
            @"Etat et collectivités publiques",
            @"Sociétés du groupe  et  associés",
            @"Débiteurs divers et Créditeurs divers",
            @"Comptes transitoires ou d'attente",
            @"Comptes de régularisation",
            @"Provisions courantes pour risques et charges",
            @"Concours Bancaires et Autres Passifs Financiers",
            @"Emprunts et autres dettes financiéres courants",
            @"Emprunts échus et impayés",
            @"Intéréts courus",
            @"Banques, établissements financiers et assimilés",
            @"Autres Postes des Capitaux Propres et Passifs du Bilan",
            @"Total des capitaux propres et passifs"};
    }
}