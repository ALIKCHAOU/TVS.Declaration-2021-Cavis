using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Module.Liasse.Model
{
    public class F6303 : IF600X
    {
        public F6303(Core.Models.Liass.F6303 mF6303)
        {
            MF6303 = mF6303;
            Lignes = new List<LigneLiasse>();
            for (int j = 1; j <= 18; j++)
            {
                Lignes.Add(new LigneLiasse()
                {
                    Ordre = j,
                    CodeN = $"F63030{j:000}",
                    CodeN1 = $"F63031{j:000}",
                    Libelle = Libelles[j - 1],
                    ObjectLiasse = mF6303
                });
            }

        }

        public List<LigneLiasse> Lignes { get; set; }
        public Core.Models.Liass.F6303 MF6303 { get; private set; }

        List<string> Libelles = new List<string>() {@"PR 1 ‐ Revenus du portefeuille titres",
        @"a‐ Dividendes ",
        @"b ‐ Revenus des obligations et valeurs assimilées ",
        @"c ‐ Revenus des autres valeurs ",
        @"PR 2 ‐ Revenus des placements monétaires ",
        @"Total des revenus des placements ",
        @"CH 1 ‐ Charges de gestion des placements ",
        @"Revenu net des placements ",
        @"PR 3 ‐ Autres produits",
        @"CH 2 ‐ Autres charges",
        @"Résultat d'exploitation ",
        @"PR 4 ‐ Régularisation du résultat d'exploitation ",
        @"Sommes distribuables de l'exercice ",
        @"PR 4 ‐ Régularisation du résultat d'exploitation (annulation)",
        @" Variation des(+ou‐) values potentielles sur titres ",
        @"(+ou‐) values réalisées sur cession des titres ",
        @"Frais de négociation ",
        @"Résultat net de l'exercice "};       


    }
}
