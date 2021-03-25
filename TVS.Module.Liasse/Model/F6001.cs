using System.Collections.Generic;

namespace TVS.Module.Liasse.Model
{
    public class F6001 : IF600X
    {
        public F6001(Core.Models.Liass.F6001 mf6001)
        {
            Mf6001 = mf6001;
            Lignes= new List<LigneLiasse>();
            for (int j = 1; j <= 68; j++)
            {
                Lignes.Add(new LigneLiasse()
                {
                    Ordre = j,
                    CodeB = $"F600100{j:00}",
                    CodeAmortissement = $"F600110{j:00}",
                    CodeN = $"F600120{j:00}",
                    CodeN1 = $"F600130{j:00}",
                    Libelle = Libelles[j-1],
                    ObjectLiasse = mf6001
                });
            }

        }

        public List<LigneLiasse> Lignes { get; set; }
        public Core.Models.Liass.F6001 Mf6001 { get; private set; }

        List<string> Libelles = new List<string>() {
            @"Actifs non courants"
            ,@"Actifs immobilises"
            ,@"Immobilisations Incorporelles"
            ,@"Investissement recherche et developpement"
            ,@"Concess. marque,brevet,licence,marque"
            ,@"Logiciels"
            ,@"Fonds commercial"
            ,@"Droit au bail"
            ,@"Autres Immobilisations Incorporelles"
            ,@"Immobilisations Incorporelles en cours"
            ,@"Av. et Ac. Verses/Cmde.Immob.Incorp."
            ,@"Immobilisations corporelles"
            ,@"Terrains"
            ,@"Constructions"
            ,@"Inst. Tech., materiel et outillages Industriels"
            ,@"Materiel de transport "
            ,@"Autres Immobilisations Corporelles "
            ,@"Immob. Corporelles en cours"
            ,@"Av. et Ac. Verses/Commande Immob.Corp."
            ,@"Immob. a statut juridique particulier"
            ,@"Immobilisations Financieres"
            ,@"Actions"
            ,@"Autres creances rattach. a des participat."
            ,@"Creances rattach. a des stes en participat."
            ,@"Vers.a eff./titre de participation non liberes"
            ,@"Titres immobilises (droit de propriete)"
            ,@"Titres immobilises (droit de creance)"
            ,@"Depots et cautionnements verses"
            ,@"Autres creances immobilisees"
            ,@"Vers.a eff./Titres immobilises non liberes"
            ,@"Autres Actifs Non Courants"
            ,@"Frais preliminaires"
            ,@"Charges a repartir"
            ,@"Frais d'emission et primes de Remb. Empts"
            ,@"ecarts de conversion"
            ,@"Actifs courants"
            ,@"Stocks"
            ,@"Stocks Matieres Premieres et Fournit. Liees"
            ,@"Stocks Autres Approvisionnements"
            ,@"Stocks En-cours de production de biens"
            ,@"Stocks En-cours de production services"
            ,@"Stocks de produits"
            ,@"Stocks de marchandises"
            ,@"Clients et Comptes Rattaches"
            ,@"Clients  et  comptes rattaches"
            ,@"Clients - effets a recevoir"
            ,@"Clients douteux ou litigieux"
            ,@"Creances/travaux non encore facturables"
            ,@"Clt-pdts non encore factures (pdt a recev.)"
            ,@"Autres Actifs Courants"
            ,@"Fournisseurs debiteurs"
            ,@"Personnel et comptes rattaches"
            ,@"etat et collectivites publiques"
            ,@"Societes du groupe  et  associes"
            ,@"Debiteurs divers et Crediteurs divers"
            ,@"Comptes transitoires ou d'attente"
            ,@"Comptes de regularisation"
            ,@"Prov. / deprec. comptes debiteurs divers"
            ,@"Placements et Autres Actifs Financiers"
            ,@"Prets et autres creances Fin. courants"
            ,@"Placements courants"
            ,@"Regies d'avances et accreditifs"
            ,@"Prov. / deprec. des comptes financiers"
            ,@"Liquidites et equivalents de liquidites"
            ,@"Banques, etabl. Financiers et assimiles"
            ,@"Caisse"
            ,@"Autres Postes des Actifs du Bilan"
            ,@"Total des actifs"};
    }
}