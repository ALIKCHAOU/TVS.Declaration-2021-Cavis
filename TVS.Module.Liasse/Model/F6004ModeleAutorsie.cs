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

        List<string> Libelles = new List<string>() {@"Flux de Tr�sorerie provenant de (affect�s �) l'Exploitation",
            @"R�sultat net",
            @"Ajustement amortissement et provision",
            @"Variation des stocks",
            @"Variation des cr�ances",
            @"Variation des autres actifs",
            @"Variation des fournisseurs et autres dettes",
            @"Ajustement plus au moins values de cession",
            @"Ajustement transfert des charges",
            @"Autres(Flux de tr�sorerie provenant de(affect�s �) l'exploitation)",
            @"Flux de Tr�sorerie provenant de (affect�s aux)  activit�s d'Investissement",
            @"D�caissements provenant de l'acquisition d'immobilisations corporelles et incorporelles",
            @"Encaissements provenant de l'acquisition d'immobilisations corporelles et incorporelles",
            @"D�caissements provenant de l'acquisition d'immobilisations financi�res",
            @"Encaissements provenant de l'acquisition d'immobilisations financi�res",
            @"Autres(Flux de Tr�sorerie provenant de (affect�s aux) activit�s d'investissement",
            @"Flux de Tr�sorerie provenant des (affect�s aux) activit�s de Financement",
            @"Encaissement suite � l'�mission d'actions",
            @"Dividendes et autres distribution",
            @"Encaissements provenant des emprunts",
            @"Remboursement d'emprunts",
            @"Autres(Flux de Tr�sorerie provenant des (affect�s aux) activit�s de Financement)",
            @"Incidences des variations des taux de change/les liquidit�s  �quiv",
            @"Autres Postes des Flux de Tr�sorerie",
            @"Variation de Tr�sorerie",
            @"Tr�sorerie au d�but de l'exercice",
            @"Tr�sorerie � la cl�ture de l'exercice"};
    }
}