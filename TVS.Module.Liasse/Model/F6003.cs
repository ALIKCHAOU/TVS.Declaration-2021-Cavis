using System.Collections.Generic;

namespace TVS.Module.Liasse.Model
{
    public class F6003 : IF600X
    {
        public F6003(Core.Models.Liass.F6003 mF6003)
        {
            MF6003 = mF6003;
            Lignes= new List<LigneLiasse>();
            for (int j = 1; j <= 89; j++)
            {
                Lignes.Add(new LigneLiasse()
                {
                    Ordre = j,
                    CodeN = $"F60030{j:000}",
                    CodeN1 = $"F60030{j+89:000}",
                    Libelle = Libelles[j-1],
                    ObjectLiasse = mF6003
                });
            }

        }

        public List<LigneLiasse> Lignes { get; set; }
        public Core.Models.Liass.F6003 MF6003 { get; private set; }

        List<string> Libelles = new List<string>() {@"Produits d'exploitation",
            @"Revenus",
            @"Ventes nettes des marchandises",
            @"Ventes de Marchandises",
            @"Rabais, Remises et Ristournes (3R) accordés/ventes de Marchandises",
            @"Ventes nettes de la production",
            @"Ventes de Produits Finis",
            @"Ventes de Produits Intermédiaires",
            @"Ventes de Produits Résiduels",
            @"Ventes des Travaux",
            @"Ventes des Etudes et Prestations de Services",
            @"Produits des Activités Annexes",
            @"Rabais, Remises et Ristournes (3R) accordés/ventes de la Production",
            @"Production immobilisée",
            @"Autres produits d'exploitation",
            @"Produits divers ordin.(sans gains/cession immo.)",
            @"Subventions d'exploitation et d'équilibre",
            @"Reprises sur amortissements et provisions",
            @"Transferts de charges",
            @"Charges d'exploitation",
            @"Variation stocks produits finis et encours",
            @"Variations des en-cours de production biens",
            @"Variation des en-cours de production services",
            @"Variation des stocks de produits",
            @"Achats de marchandises consommées",
            @"Achats de marchandises",
            @"Rabais, Remises et Ristournes (3R) obtenus sur achats marchandises",
            @"Variation des stocks de marchandises",
            @"Achats d'approvisionnements consommés",
            @"Achats stockés-Mat.Premiéres et Fournit. liées",
            @"Achats stockés - Autres approvisionnements",
            @"Rabais, Remises et Ristournes (3R) obtenus/achats Mat.Premiéres et Fournit. liées",
            @"Rabais, Remises et Ristournes (3R) obtenus/achats autres approvisionnements",
            @"Var.de stocks Mat.Premiéres et Fournitures",
            @"Var.de stocks des autres approvisionnements",
            @"Charges de personnel",
            @"Salaires et compléments de salaires",
            @"Appointements et compléments d'appoint.",
            @"Indemnités représentatives de frais",
            @"Commissions au personnel",
            @"Rémun.des administrateurs, gérants et associés",
            @"Ch.connexes sal., appoint., comm. et rémun.",
            @"Charges sociales légales",
            @"Ch.PL/Modif.Compt.é imputer au Réslt de l'exerc.ou Activ.abandonnée",
            @"Autres charges de PL et autres charges sociales",
            @"Dotations aux amortissements et aux provisions",
            @"Dot.amort. et prov.-Ch.ord.(autres que Fin.)",
            @"Dot. aux résorptions des charges reportées",
            @"Dot. Prov. Risques et Charges d'exploitation",
            @"Dot.Prov.dépréc.immob. Incorp. et Corporelles",
            @"Dot.Prov.dépréc.actifs courants (autres que Val.Mobil.de Placem. et équiv. de liquidités)",
            @"Dot.aux amort. et prov./Modif.Compt. é imputer au Réslt de l'exerc. ou Activ. abandonnée",
            @"Autres charges d'exploitation",
            @"Achats déétudes et prestations services (y compris achat de sous-traitance production)",
            @"Achats de matériel, équipements et travaux",
            @"Achats non stockés non rattachés",
            @"Services extérieurs",
            @"Autres services extérieurs",
            @"Charges diverses ordinaires",
            @"Impéts, taxes et versements assimilés",
            @"Resultat d'exploitation",
            @"Charges financiéres nettes",
            @"Charges financiéres",
            @"Dot.amort. et provisions - charges financiéres",
            @"Produits des placements",
            @"Produits financiers",
            @"Reprise/prov.(é inscrire dans les pdts financ.)",
            @"Transferts de charges financiéres",
            @"Autres gains ordinaires",
            @"Produits nets sur cessions d'immobilisations",
            @"Autres gains/élém.non récurrents ou except.",
            @"Autres pertes ordinanires",
            @"Charges Nettes/cession immobilisations",
            @"Autres pertes/élém.non récurrents ou except.",
            @"Réduction de valeur",
            @"Résultat des Activités Ordinaires avant Impét",
            @"Impôt sur les bénéfices",
            @"Impéts/Bénéfices calculés/Résultat/activ./ ord.",
            @"Autres impéts/Bénéfice (régimes particuliers)",
            @"Résultat des Activités Ordinaires aprés Impét",
            @"Elements extraordinanires (Gains/pertes)",
            @"Gains extraordinaires",
            @"Pertes extraordinaires",
            @"Résultat net de l'exercice",
            @"Effets des modif. Comptables (net d'impôt)",
            @"Effet positif/Modif.C.affectant Réslts Reportés",
            @"Effet négatif/Modif.C.affectant Réslts Reportés",
            @"Autres Postes des Comptes de Résultat",
            @"Resultat apres modifications comptables"};
    }
}