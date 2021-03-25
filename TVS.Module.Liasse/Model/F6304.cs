using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Module.Liasse.Model
{
    public class F6304 : IF600X
    {
        public F6304(Core.Models.Liass.F6304 mF6304)
        {
            MF6304 = mF6304;
            Lignes = new List<LigneLiasse>();
            for (int j = 1; j <= 26; j++)
            {
                Lignes.Add(new LigneLiasse()
                {
                    Ordre = j,
                    CodeN = $"F63040{j:000}",
                    CodeN1 = $"F63041{j:000}",
                    Libelle = Libelles[j - 1],
                    ObjectLiasse = mF6304
                });
            }

        }

        public List<LigneLiasse> Lignes { get; set; }
        public Core.Models.Liass.F6304 MF6304 { get; private set; }

        List<string> Libelles = new List<string>() { @"Variation de l'actif net ",
        @"AN1 ‐ Variation de l'actif net (Résultant des opérations d'exploitation) ",
        @"a ‐ Résultat d'exploitation ",
        @"b ‐ Variation des (+ou‐) values potentielles sur titres",
        @"c ‐ (+ou‐) values réalisées sur cession de titres ",
        @"d ‐ Frais de négociation de titres ",
        @"AN 2 ‐ Distribution des dividendes",
        @"AN 3 ‐ Transactions sur le capital ",
        @"a‐ Souscriptions ",
        @"Variation des plus (ou moins) values potentielles sur titres",
        @"Plus (ou moins) values réalisées sur cession des titres",
        @"Plus (ou moins) values réalisées sur cession des  titres",
        @"Frais de négociation ",
        @"b‐ Rachats ",
        @"Capital ",
        @"Régularisation des sommes non distribuables de l'exercice ",
        @"Régularisation des sommes distribuables ",
        @"Droits de sortie ",
        @"Valeur liquidative ",
        @"AN 4 ‐ Actif net ",
        @"a ‐ en début d'exercice ",
        @"b ‐ en fin d'exercice ",
        @"AN 5 ‐ Nombre d'actions (ou de parts) ",
        @"a ‐ en début d'exercice ",
        @"b ‐ en fin d'exercice ",
        @"AN 6 ‐ Taux de rendement annuel "};

    }
}
