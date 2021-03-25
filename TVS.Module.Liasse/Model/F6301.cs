using System.Collections.Generic;

namespace TVS.Module.Liasse.Model
{
    public class F6301 : IF600X
    {
        public F6301(Core.Models.Liass.F6301 mF6301)
        {
            MF6301 = mF6301;
            Lignes = new List<LigneLiasse>();
            for (int j = 1; j <= 19; j++)
            {
                Lignes.Add(new LigneLiasse()
                {
                    Ordre = j,
                    CodeN = $"F63010{j:000}",                             
                    CodeN1 = $"F63011{j:000}",
                    Libelle = Libelles[j - 1],
                    ObjectLiasse = mF6301
                });
            }

        }

        public List<LigneLiasse> Lignes { get; set; }
        public Core.Models.Liass.F6301 MF6301 { get; private set; }

        List<string> Libelles = new List<string>() {@"AC 1‐Portefeuille titres " ,
        @"a ‐ Actions, valeurs assimilées et droits rattachés",
        @"b ‐ Obligations et valeurs assimilées ",
        @"c ‐ Autres valeurs ",
        @"AC 2 ‐ Placements monétaires et disponibilités",
        @"a ‐ Placements monétaires ",
        @"b ‐ Disponibilités ",
        @"AC 3 ‐ Créances d'exploitation ",
        @"AC 4 ‐ Autres actifs ",
        @"Total actif ",
        @"PA 1 ‐ Opérateurs créditeurs ",
        @"PA 2 ‐ Autres créditeurs divers ",
        @"Total passif ",
        @"CP 1 ‐ Capital ",
        @"CP 2 ‐ Sommes distribuables ",
        @"a‐ Sommes distribuables des exercices antérieurs ",
        @"b‐ Sommes distribuables de l'exercice ",
        @"Total actif net ",
        @"Total passif et actif net "};

        

    }
}