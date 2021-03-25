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
            @"R�serves",
            @"Autres capitaux propres",
            @"R�sultats report�s",
            @"Capitaux propres avant r�sultat de l'exercice",
            @"R�sultat de l'exercice",
            @"Total Passifs",
            @"Passifs non courants",
            @"Emprunts",
            @"Emprunts obligataires (assortis de s�ret�s)",
            @"Empts aupr�s d'�tab.Fin. (assortis de s�ret�s)",
            @"Empts aupr�s d'�tab.Fin. (assorti de s�ret�s)",
            @"Empts et dettes assorties de condit. particuli�res",
            @"Emprunts non assortis de s�ret�s",
            @"Dettes rattach�es � des participations",
            @"D�p�ts  et  cautionnements re�us",
            @"Autres emprunts et dettes",
            @"Autres Passifs Financiers",
            @"Ecarts de conversion",
            @"Autres passifs financiers",
            @"Provisions",
            @"Provisions pour risques",
            @"Prov.pour charges et r�partir/plusieurs exercices",
            @"Prov.pour retraites et obligations similaires",
            @"Provisions d'origine r�glementaire",
            @"Provisions pour imp�ts",
            @"Prov.pour renouvellement des immobilisations",
            @"Provisions pour amortissement",
            @"Autres provisions pour charges",
            @"Passifs courants",
            @"Fournisseurs et Comptes Rattach�s",
            @"Fournisseurs d'exploitation",
            @"Fournisseurs d'exploitation - effets � payer",
            @"Fournisseurs d'immobilisations",
            @"Fournisseurs d'immobilisations - effets � payer",
            @"Fournisseurs - factures non parvenues",
            @"Autres passifs courants",
            @"Clients cr�diteurs",
            @"Personnels et comptes rattach�s ",
            @"Etat et collectivit�s publiques",
            @"Soci�t�s du groupe  et  associ�s",
            @"D�biteurs divers et Cr�diteurs divers",
            @"Comptes transitoires ou d'attente",
            @"Comptes de r�gularisation",
            @"Provisions courantes pour risques et charges",
            @"Concours Bancaires et Autres Passifs Financiers",
            @"Emprunts et autres dettes financi�res courants",
            @"Emprunts �chus et impay�s",
            @"Int�r�ts courus",
            @"Banques, �tablissements financiers et assimil�s",
            @"Autres Postes des Capitaux Propres et Passifs du Bilan",
            @"Total des capitaux propres et passifs"};
    }
}