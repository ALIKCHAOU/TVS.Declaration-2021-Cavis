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
            @"Rabais, Remises et Ristournes (3R) accord�s/ventes de Marchandises",
            @"Ventes nettes de la production",
            @"Ventes de Produits Finis",
            @"Ventes de Produits Interm�diaires",
            @"Ventes de Produits R�siduels",
            @"Ventes des Travaux",
            @"Ventes des Etudes et Prestations de Services",
            @"Produits des Activit�s Annexes",
            @"Rabais, Remises et Ristournes (3R) accord�s/ventes de la Production",
            @"Production immobilis�e",
            @"Autres produits d'exploitation",
            @"Produits divers ordin.(sans gains/cession immo.)",
            @"Subventions d'exploitation et d'�quilibre",
            @"Reprises sur amortissements et provisions",
            @"Transferts de charges",
            @"Charges d'exploitation",
            @"Variation stocks produits finis et encours",
            @"Variations des en-cours de production biens",
            @"Variation des en-cours de production services",
            @"Variation des stocks de produits",
            @"Achats de marchandises consomm�es",
            @"Achats de marchandises",
            @"Rabais, Remises et Ristournes (3R) obtenus sur achats marchandises",
            @"Variation des stocks de marchandises",
            @"Achats d'approvisionnements consomm�s",
            @"Achats stock�s-Mat.Premi�res et Fournit. li�es",
            @"Achats stock�s - Autres approvisionnements",
            @"Rabais, Remises et Ristournes (3R) obtenus/achats Mat.Premi�res et Fournit. li�es",
            @"Rabais, Remises et Ristournes (3R) obtenus/achats autres approvisionnements",
            @"Var.de stocks Mat.Premi�res et Fournitures",
            @"Var.de stocks des autres approvisionnements",
            @"Charges de personnel",
            @"Salaires et compl�ments de salaires",
            @"Appointements et compl�ments d'appoint.",
            @"Indemnit�s repr�sentatives de frais",
            @"Commissions au personnel",
            @"R�mun.des administrateurs, g�rants et associ�s",
            @"Ch.connexes sal., appoint., comm. et r�mun.",
            @"Charges sociales l�gales",
            @"Ch.PL/Modif.Compt.� imputer au R�slt de l'exerc.ou Activ.abandonn�e",
            @"Autres charges de PL et autres charges sociales",
            @"Dotations aux amortissements et aux provisions",
            @"Dot.amort. et prov.-Ch.ord.(autres que Fin.)",
            @"Dot. aux r�sorptions des charges report�es",
            @"Dot. Prov. Risques et Charges d'exploitation",
            @"Dot.Prov.d�pr�c.immob. Incorp. et Corporelles",
            @"Dot.Prov.d�pr�c.actifs courants (autres que Val.Mobil.de Placem. et �quiv. de liquidit�s)",
            @"Dot.aux amort. et prov./Modif.Compt. � imputer au R�slt de l'exerc. ou Activ. abandonn�e",
            @"Autres charges d'exploitation",
            @"Achats d��tudes et prestations services (y compris achat de sous-traitance production)",
            @"Achats de mat�riel, �quipements et travaux",
            @"Achats non stock�s non rattach�s",
            @"Services ext�rieurs",
            @"Autres services ext�rieurs",
            @"Charges diverses ordinaires",
            @"Imp�ts, taxes et versements assimil�s",
            @"Resultat d'exploitation",
            @"Charges financi�res nettes",
            @"Charges financi�res",
            @"Dot.amort. et provisions - charges financi�res",
            @"Produits des placements",
            @"Produits financiers",
            @"Reprise/prov.(� inscrire dans les pdts financ.)",
            @"Transferts de charges financi�res",
            @"Autres gains ordinaires",
            @"Produits nets sur cessions d'immobilisations",
            @"Autres gains/�l�m.non r�currents ou except.",
            @"Autres pertes ordinanires",
            @"Charges Nettes/cession immobilisations",
            @"Autres pertes/�l�m.non r�currents ou except.",
            @"R�duction de valeur",
            @"R�sultat des Activit�s Ordinaires avant Imp�t",
            @"Imp�t sur les b�n�fices",
            @"Imp�ts/B�n�fices calcul�s/R�sultat/activ./ ord.",
            @"Autres imp�ts/B�n�fice (r�gimes particuliers)",
            @"R�sultat des Activit�s Ordinaires apr�s Imp�t",
            @"Elements extraordinanires (Gains/pertes)",
            @"Gains extraordinaires",
            @"Pertes extraordinaires",
            @"R�sultat net de l'exercice",
            @"Effets des modif. Comptables (net d'imp�t)",
            @"Effet positif/Modif.C.affectant R�slts Report�s",
            @"Effet n�gatif/Modif.C.affectant R�slts Report�s",
            @"Autres Postes des Comptes de R�sultat",
            @"Resultat apres modifications comptables"};
    }
}