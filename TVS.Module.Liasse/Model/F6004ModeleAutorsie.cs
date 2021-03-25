using System.Collections.Generic;

namespace TVS.Module.Liasse.Model
{
    public class F6004ModeleAutorsie : IF600X
    {
        public F6004ModeleAutorsie(Core.Models.Liass.F6004ModeleAutorsie mF6004ModeleAutorsie)
        {
            MF6004ModeleAutorsie = mF6004ModeleAutorsie;
            Lignes= new List<LigneLiasse>();
            for (int j = 1; j <= 27; j++)
            {
                Lignes.Add(new LigneLiasse()
                {
                    Ordre = j,
                    CodeN = $"F60040{j:000}",
                    CodeN1 = $"F60041{j:000}",
                    Libelle = Libelles[j-1],
                    ObjectLiasse = mF6004ModeleAutorsie
                });
            }

        }

        public List<LigneLiasse> Lignes { get; set; }
        public Core.Models.Liass.F6004ModeleAutorsie MF6004ModeleAutorsie { get; private set; }

        List<string> Libelles = new List<string>() {@"Flux de Trésorerie provenant de (affectés à) l'Exploitation",
            @"Résultat net",
            @"Ajustement amortissement et provision",
            @"Variation des stocks",
            @"Variation des créances",
            @"Variation des autres actifs",
            @"Variation des fournisseurs et autres dettes",
            @"Ajustement plus au moins values de cession",
            @"Ajustement transfert des charges",
            @"Autres(Flux de trésorerie provenant de(affectés à) l'exploitation)",
            @"Flux de Trésorerie provenant de (affectés aux)  activités d'Investissement",
            @"Décaissements provenant de l'acquisition d'immobilisations corporelles et incorporelles",
            @"Encaissements provenant de l'acquisition d'immobilisations corporelles et incorporelles",
            @"Décaissements provenant de l'acquisition d'immobilisations financières",
            @"Encaissements provenant de l'acquisition d'immobilisations financières",
            @"Autres(Flux de Trésorerie provenant de (affectés aux) activités d'investissement",
            @"Flux de Trésorerie provenant des (affectés aux) activités de Financement",
            @"Encaissement suite à l'émission d'actions",
            @"Dividendes et autres distribution",
            @"Encaissements provenant des emprunts",
            @"Remboursement d'emprunts",
            @"Autres(Flux de Trésorerie provenant des (affectés aux) activités de Financement)",
            @"Incidences des variations des taux de change/les liquidités  équiv",
            @"Autres Postes des Flux de Trésorerie",
            @"Variation de Trésorerie",
            @"Trésorerie au début de l'exercice",
            @"Trésorerie à la clôture de l'exercice"};
    }
}