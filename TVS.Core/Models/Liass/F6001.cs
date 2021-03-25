using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Core.Models.Liass
{
    public partial class F6001
    {
        public int Id { get; set; }
        public int SocieteNo { get; set; }
        public int ExerciceId { get; set; }
        [DisplayName("Acte de dépot")]
        public int ActeDeDepot { get; set; }
        [DisplayName("Nature de dépot")]
        public string NatureDepot { get; set; }
        [DisplayName("Actifs non courants (Brut)")]
        public decimal F60010001 { get { return F60010002 + F60010031; } }
        [DisplayName("Actifs immobilises (Brut)")]
        public decimal F60010002 { get { return F60010003 + F60010012 + F60010021; } }
        [DisplayName("Immobilisations Incorporelles (Brut)")]
        public decimal F60010003 { get { return F60010004 + F60010005 + F60010006 + F60010007 + F60010008 + F60010009 + F60010010 + F60010011; } }
        [DisplayName("Investissement recherche et developpement (Brut)")]
        public decimal F60010004 { get; set; }
        [DisplayName("Concess. marque,brevet,licence,marque (Brut)")]
        public decimal F60010005 { get; set; }
        [DisplayName("Logiciels (Brut)")]
        public decimal F60010006 { get; set; }
        [DisplayName("Fonds commercial (Brut)")]
        public decimal F60010007 { get; set; }
        [DisplayName("Droit au bail (Brut)")]
        public decimal F60010008 { get; set; }
        [DisplayName("Autres Immobilisations Incorporelles (Brut)")]
        public decimal F60010009 { get; set; }
        [DisplayName("Immobilisations Incorporelles en cours (Brut)")]
        public decimal F60010010 { get; set; }
        [DisplayName("Av. et Ac. Verses/Cmde.Immob.Incorp. (Brut)")]
        public decimal F60010011 { get; set; }
        [DisplayName("Immobilisations corporelles (Brut)")]
        public decimal F60010012 { get { return F60010013 + F60010014 + F60010015 + F60010016 + F60010017 + F60010018 + F60010019 + F60010020; } }
        [DisplayName("Terrains (Brut)")]
        public decimal F60010013 { get; set; }
        [DisplayName("Constructions (Brut)")]
        public decimal F60010014 { get; set; }
        [DisplayName("Inst. Tech., materiel et outillages Industriels (Brut)")]
        public decimal F60010015 { get; set; }
        [DisplayName("Materiel de transport  (Brut)")]
        public decimal F60010016 { get; set; }
        [DisplayName("Autres Immobilisations Corporelles  (Brut)")]
        public decimal F60010017 { get; set; }
        [DisplayName("Immob. Corporelles en cours (Brut)")]
        public decimal F60010018 { get; set; }
        [DisplayName("Av. et Ac. Verses/Commande Immob.Corp. (Brut)")]
        public decimal F60010019 { get; set; }
        [DisplayName("Immob. a statut juridique particulier (Brut)")]
        public decimal F60010020 { get; set; }
        [DisplayName("Immobilisations Financieres (Brut)")]
        public decimal F60010021 { get { return F60010022 + F60010023 + F60010024 + F60010025 + F60010026 + F60010027 + F60010028 + F60010029 + F60010030; } }
        [DisplayName("Actions (Brut)")]
        public decimal F60010022 { get; set; }
        [DisplayName("Autres creances rattach. a des participat. (Brut)")]
        public decimal F60010023 { get; set; }
        [DisplayName("Creances rattach. a des stes en participat. (Brut)")]
        public decimal F60010024 { get; set; }
        [DisplayName("Vers.a eff./titre de participation non liberes (Brut)")]
        public decimal F60010025 { get; set; }
        [DisplayName("Titres immobilises (droit de propriete) (Brut)")]
        public decimal F60010026 { get; set; }
        [DisplayName("Titres immobilises (droit de creance) (Brut)")]
        public decimal F60010027 { get; set; }
        [DisplayName("Depots et cautionnements verses (Brut)")]
        public decimal F60010028 { get; set; }
        [DisplayName("Autres creances immobilisees (Brut)")]
        public decimal F60010029 { get; set; }
        [DisplayName("Vers.a eff./Titres immobilises non liberes (Brut)")]
        public decimal F60010030 { get; set; }
        [DisplayName("Autres Actifs Non Courants (Brut)")]
        public decimal F60010031 { get { return F60010032 + F60010033 + F60010034 + F60010035; } }

        [DisplayName("Frais preliminaires (Brut)")]
        public decimal F60010032 { get; set; }
        [DisplayName("Charges a repartir (Brut)")]
        public decimal F60010033 { get; set; }
        [DisplayName("Frais d'emission et primes de Remb. Empts (Brut)")]
        public decimal F60010034 { get; set; }
        [DisplayName("Ecarts de conversion (Brut)")]
        public decimal F60010035 { get; set; }
        [DisplayName("Actifs courants (Brut)")]
        public decimal F60010036 { get { return F60010037 + F60010044 + F60010050 + F60010059 + F60010064; } }
        [DisplayName("Stocks (Brut)")]
        public decimal F60010037 { get { return F60010038 + F60010039 + F60010040 + F60010041 + F60010042 + F60010043; } }
        [DisplayName("Stocks Matieres Premieres et Fournit")]
        public decimal F60010038 { get; set; }
        [DisplayName("Stocks Autres Approvisionnements (Brut)")]
        public decimal F60010039 { get; set; }
        [DisplayName("Stocks En-cours de production de biens (Brut)")]
        public decimal F60010040 { get; set; }
        [DisplayName("Stocks En-cours de production services (Brut)")]
        public decimal F60010041 { get; set; }
        [DisplayName("Stocks de produits (Brut)")]
        public decimal F60010042 { get; set; }
        [DisplayName("Stocks de marchandises (Brut)")]
        public decimal F60010043 { get; set; }
        [DisplayName("Clients et Comptes Rattaches (Brut)")]
        public decimal F60010044 { get { return F60010045 + F60010046 + F60010047 + F60010048 + F60010049; } }

        [DisplayName("Clients  et  comptes rattaches (Brut)")]
        public decimal F60010045 { get; set; }
        [DisplayName("Clients - effets a recevoir (Brut)")]
        public decimal F60010046 { get; set; }
        [DisplayName("Clients douteux ou litigieux (Brut)")]
        public decimal F60010047 { get; set; }
        [DisplayName("Creances/travaux non encore facturables (Brut)")]
        public decimal F60010048 { get; set; }
        [DisplayName("Clt-pdts non encore factures (pdt a recev.) (Brut)")]
        public decimal F60010049 { get; set; }
        [DisplayName("Autres Actifs Courants (Brut)")]
        public decimal F60010050 { get { return F60010051 + F60010052 + F60010053 + F60010054 + F60010055 + F60010056 + F60010057 + F60010058; } }
        [DisplayName("Fournisseurs debiteurs (Brut)")]
        public decimal F60010051 { get; set; }
        [DisplayName("Personnel et comptes rattaches (Brut)")]
        public decimal F60010052 { get; set; }
        [DisplayName("Etat et collectivites publiques (Brut)")]
        public decimal F60010053 { get; set; }
        [DisplayName("Societes du groupe  et  associes (Brut)")]
        public decimal F60010054 { get; set; }
        [DisplayName("Debiteurs divers et Crediteurs divers (Brut)")]
        public decimal F60010055 { get; set; }
        [DisplayName("Comptes transitoires ou d'attente (Brut)")]
        public decimal F60010056 { get; set; }
        [DisplayName("Comptes de regularisation (Brut)")]
        public decimal F60010057 { get; set; }
        [DisplayName("Prov. / deprec. comptes debiteurs divers (Brut)")]
        public decimal F60010058 { get; set; }
        [DisplayName("Placements et Autres Actifs Financiers (Brut)")]
        public decimal F60010059 { get { return F60010060 + F60010061 + F60010062 + F60010063; } }

        [DisplayName("Prets et autres creances Fin. courants (Brut)")]
        public decimal F60010060 { get; set; }
        [DisplayName("Placements courants (Brut)")]
        public decimal F60010061 { get; set; }
        [DisplayName("Regies d'avances et accreditifs (Brut)")]
        public decimal F60010062 { get; set; }
        [DisplayName("Prov. / deprec. des comptes financiers (Brut)")]
        public decimal F60010063 { get; set; }
        [DisplayName("Liquidites et equivalents de liquidites (Brut)")]
        public decimal F60010064 { get { return F60010065 + F60010066; } }

        [DisplayName("Banques, etabl. Financiers et assimiles (Brut)")]
        public decimal F60010065 { get; set; }

        [DisplayName("Caisse (Brut)")]
        public decimal F60010066 { get; set; }
        [DisplayName("Autres Postes des Actifs du Bilan (Brut)")]
        public decimal F60010067 { get; set; }
        [DisplayName("Total des actifs (Brut)")]
        public decimal F60010068 { get { return F60010001 + F60010036 + F60010067; } }


        [DisplayName("")]
        public decimal F60011001 { get { return F60011002 + F60011031; } }
        [DisplayName("")]
        public decimal F60011002 { get { return F60011003 + F60011012 + F60011021; } }
        [DisplayName("")]
        public decimal F60011003 { get { return F60011004 + F60011005 + F60011006 + F60011007 + F60011008 + F60011009 + F60011010 + F60011011; } }
        [DisplayName("")]
        public decimal F60011004 { get; set; }
        [DisplayName("")]
        public decimal F60011005 { get; set; }
        [DisplayName("")]
        public decimal F60011006 { get; set; }
        [DisplayName("")]
        public decimal F60011007 { get; set; }
        [DisplayName("")]
        public decimal F60011008 { get; set; }
        [DisplayName("")]
        public decimal F60011009 { get; set; }
        [DisplayName("")]
        public decimal F60011010 { get; set; }
        [DisplayName("")]
        public decimal F60011011 { get; set; }
        [DisplayName("")]
        public decimal F60011012 { get { return F60011013 + F60011014 + F60011015 + F60011016 + F60011017 + F60011018 + F60011019 + F60011020; } }
        [DisplayName("")]
        public decimal F60011013 { get; set; }
        [DisplayName("")]
        public decimal F60011014 { get; set; }
        [DisplayName("")]
        public decimal F60011015 { get; set; }
        [DisplayName("")]
        public decimal F60011016 { get; set; }
        [DisplayName("")]
        public decimal F60011017 { get; set; }
        [DisplayName("")]
        public decimal F60011018 { get; set; }
        [DisplayName("")]
        public decimal F60011019 { get; set; }
        [DisplayName("")]
        public decimal F60011020 { get; set; }
        [DisplayName("")]
        public decimal F60011021 { get { return F60011022 + F60011023 + F60011024 + F60011025 + F60011026 + F60011027 + F60011028 + F60011029 + F60011030; } }
        [DisplayName("")]
        public decimal F60011022 { get; set; }
        [DisplayName("")]
        public decimal F60011023 { get; set; }
        [DisplayName("")]
        public decimal F60011024 { get; set; }
        [DisplayName("")]
        public decimal F60011025 { get; set; }
        [DisplayName("")]
        public decimal F60011026 { get; set; }
        [DisplayName("")]
        public decimal F60011027 { get; set; }
        [DisplayName("")]
        public decimal F60011028 { get; set; }
        [DisplayName("")]
        public decimal F60011029 { get; set; }
        [DisplayName("")]
        public decimal F60011030 { get; set; }
        [DisplayName("")]
        public decimal F60011031 { get { return F60011032 + F60011033 + F60011034; } }
        [DisplayName("")]
        public decimal F60011032 { get; set; }
        [DisplayName("")]
        public decimal F60011033 { get; set; }
        [DisplayName("")]
        public decimal F60011034 { get; set; }
        [DisplayName("")]
        public decimal F60011035 { get; set; }
        [DisplayName("")]
        public decimal F60011036 { get { return F60011037 + F60011044 + F60011050 + F60011059 + F60011064; } }
        [DisplayName("")]
        public decimal F60011037 { get { return F60011038 + F60011039 + F60011040 + F60011041 + F60011042 + F60011043; } }
        [DisplayName("")]
        public decimal F60011038 { get; set; }
        [DisplayName("")]
        public decimal F60011039 { get; set; }
        [DisplayName("")]
        public decimal F60011040 { get; set; }
        [DisplayName("")]
        public decimal F60011041 { get; set; }
        [DisplayName("")]
        public decimal F60011042 { get; set; }
        [DisplayName("")]
        public decimal F60011043 { get; set; }
        [DisplayName("")]
        public decimal F60011044 { get { return F60011045 + F60011046 + F60011047 + F60011048 + F60011049; } }
        [DisplayName("")]
        public decimal F60011045 { get; set; }
        [DisplayName("")]
        public decimal F60011046 { get; set; }
        [DisplayName("")]
        public decimal F60011047 { get; set; }
        [DisplayName("")]
        public decimal F60011048 { get; set; }
        [DisplayName("")]
        public decimal F60011049 { get; set; }
        [DisplayName("")]
        public decimal F60011050 { get { return F60011051 + F60011052 + F60011053 + F60011054 + F60011055 + F60011056 + F60011057 + F60011058; } }
        [DisplayName("")]
        public decimal F60011051 { get; set; }
        [DisplayName("")]
        public decimal F60011052 { get; set; }
        [DisplayName("")]
        public decimal F60011053 { get; set; }
        [DisplayName("")]
        public decimal F60011054 { get; set; }
        [DisplayName("")]
        public decimal F60011055 { get; set; }
        [DisplayName("")]
        public decimal F60011056 { get; set; }
        [DisplayName("")]
        public decimal F60011057 { get; set; }
        [DisplayName("")]
        public decimal F60011058 { get; set; }
        [DisplayName("")]
        public decimal F60011059 { get { return F60011060 + F60011061 + F60011062 + F60011063; } }
        [DisplayName("")]
        public decimal F60011060 { get; set; }
        [DisplayName("")]
        public decimal F60011061 { get; set; }
        [DisplayName("")]
        public decimal F60011062 { get; set; }
        [DisplayName("")]
        public decimal F60011063 { get; set; }
        [DisplayName("")]
        public decimal F60011064 { get { return F60011065 + F60011066; } }
        [DisplayName("")]
        public decimal F60011065 { get; set; }

        [DisplayName("")]
        public decimal F60011066 { get; set; }
        [DisplayName("")]
        public decimal F60011067 { get; set; }
        [DisplayName("")]
        public decimal F60011068 { get { return F60011001 + F60011036 + F60011067; } }

        [DisplayName("")]
        public decimal F60012001 { get { return F60012002 + F60012031; } }
        [DisplayName("")]
        public decimal F60012002 { get { return F60012003 + F60012012 + F60012021; } }
        [DisplayName("")]
        public decimal F60012003 { get { return F60012004 + F60012005 + F60012006 + F60012007 + F60012008 + F60012009 + F60012010 + F60012011; } }
        [DisplayName("")]
        public decimal F60012004 { get { return F60010004 - F60011004; } }
        [DisplayName("")]
        public decimal F60012005 { get { return F60010005 - F60011005; } }
        [DisplayName("")]
        public decimal F60012006 { get { return F60010006 - F60011006; } }
        [DisplayName("")]
        public decimal F60012007 { get { return F60010007 - F60011007; } }
        [DisplayName("")]
        public decimal F60012008 { get { return F60010008 - F60011008; } }
        [DisplayName("")]
        public decimal F60012009 { get { return F60010009 - F60011009; } }
        [DisplayName("")]
        public decimal F60012010 { get { return F60010010 - F60011010; } }
        [DisplayName("")]
        public decimal F60012011 { get { return F60010011 - F60011011; } }
        [DisplayName("")]
        public decimal F60012012
        {
            get
            {
                return
F60012013 + F60012014 + F60012015 + F60012016 + F60012017 + F60012018 + F60012019 + F60012020;
            }
        }
        [DisplayName("")]
        public decimal F60012013 { get { return F60010013 - F60011013; } }
        [DisplayName("")]
        public decimal F60012014 { get { return F60010014 - F60011014; } }
        [DisplayName("")]
        public decimal F60012015 { get { return F60010015 - F60011015; } }
        [DisplayName("")]
        public decimal F60012016 { get { return F60010016 - F60011016; } }
        [DisplayName("")]
        public decimal F60012017 { get { return F60010017 - F60011017; } }
        [DisplayName("")]
        public decimal F60012018 { get { return F60010018 - F60011018; } }
        [DisplayName("")]
        public decimal F60012019 { get { return F60010019 - F60011019; } }
        [DisplayName("")]
        public decimal F60012020 { get { return F60010020 - F60011020; } }
        [DisplayName("")]
        public decimal F60012021
        {
            get
            {
                return F60012022 + F60012023 + F60012024 + F60012025 + F60012026 + F60012027 + F60012028 + F60012029 + F60012030;
            }
        }
        [DisplayName("")]
        public decimal F60012022 { get { return F60010022 - F60011022; } }
        [DisplayName("")]
        public decimal F60012023 { get { return F60010023 - F60011023; } }
        [DisplayName("")]
        public decimal F60012024 { get { return F60010024 - F60011024; } }
        [DisplayName("")]
        public decimal F60012025 { get { return F60010025 - F60011025; } }
        [DisplayName("")]
        public decimal F60012026 { get { return F60010026 - F60011026; } }
        [DisplayName("")]
        public decimal F60012027 { get { return F60010027 - F60011027; } }
        [DisplayName("")]
        public decimal F60012028 { get { return F60010028 - F60011028; } }
        [DisplayName("")]
        public decimal F60012029 { get { return F60010029 - F60011029; } }
        [DisplayName("")]
        public decimal F60012030 { get { return F60010030 - F60011030; } }
        [DisplayName("")]
        public decimal F60012031 { get { return F60012032 + F60012033 + F60012034 + F60012035; } }
        [DisplayName("")]
        public decimal F60012032 { get { return F60010032 - F60011032; } }
        [DisplayName("")]
        public decimal F60012033 { get { return F60010033 - F60011033; } }
        [DisplayName("")]
        public decimal F60012034 { get { return F60010034 - F60011034; } }
        [DisplayName("")]
        public decimal F60012035 { get { return F60010035 - F60011035; } }
        [DisplayName("")]
        public decimal F60012036 { get { return F60012037 + F60012044 + F60012050 + F60012059 + F60012064; } }
        [DisplayName("")]
        public decimal F60012038 { get { return F60010038 - F60011038; } }
        [DisplayName("")]
        public decimal F60012037 { get { return F60012038 + F60012039 + F60012040 + F60012041 + F60012042 + F60012043; } }
        [DisplayName("")]
        public decimal F60012039 { get { return F60010039 - F60011039; } }
        [DisplayName("")]
        public decimal F60012040 { get { return F60010040 - F60011040; } }
        [DisplayName("")]
        public decimal F60012041 { get { return F60010041 - F60011041; } }
        [DisplayName("")]
        public decimal F60012042 { get { return F60010042 - F60011042; } }
        [DisplayName("")]
        public decimal F60012043 { get { return F60010043 - F60011043; } }
        [DisplayName("")]
        public decimal F60012044 { get { return F60012045 + F60012046 + F60012047 + F60012048 + F60012049; } }
        [DisplayName("")]
        public decimal F60012045 { get { return F60010045 - F60011045; } }
        [DisplayName("")]
        public decimal F60012046 { get { return F60010046 - F60011046; } }
        [DisplayName("")]
        public decimal F60012047 { get { return F60010047 - F60011047; } }
        [DisplayName("")]
        public decimal F60012048 { get { return F60010048 - F60011048; } }
        [DisplayName("")]
        public decimal F60012049 { get { return F60010049 - F60011049; } }
        [DisplayName("")]
        public decimal F60012050 { get { return F60012051 + F60012052 + F60012053 + F60012054 + F60012055 + F60012056 + F60012057 + F60012058; } }
        [DisplayName("")]
        public decimal F60012051 { get { return F60010051 - F60011051; } }
        [DisplayName("")]
        public decimal F60012052 { get { return F60010052 - F60011052; } }
        [DisplayName("")]
        public decimal F60012053 { get { return F60010053 - F60011053; } }
        [DisplayName("")]
        public decimal F60012054 { get { return F60010054 - F60011054; } }
        [DisplayName("")]
        public decimal F60012055 { get { return F60010055 - F60011055; } }
        [DisplayName("")]
        public decimal F60012056 { get { return F60010056 - F60011056; } }
        [DisplayName("")]
        public decimal F60012057 { get { return F60010057 - F60011057; } }
        [DisplayName("")]
        public decimal F60012058 { get { return F60010058 - F60011058; } }
        [DisplayName("")]
        public decimal F60012059 { get { return F60010059 - F60011059; } }
        [DisplayName("")]
        public decimal F60012060 { get { return F60010060 - F60011060; } }
        [DisplayName("")]
        public decimal F60012061 { get { return F60010061 - F60011061; } }
        [DisplayName("")]
        public decimal F60012062 { get { return F60010062 - F60011062; } }
        [DisplayName("")]
        public decimal F60012063 { get { return F60010063 - F60011063; } }
        [DisplayName("")]
        public decimal F60012064 { get { return F60012065 + F60012066; } }
        [DisplayName("")]
        public decimal F60012065 { get { return F60010065 - F60011065; } }

        [DisplayName("")]
        public decimal F60012066 { get { return F60010066 - F60011066; } }
        [DisplayName("")]
        public decimal F60012067 { get { return F60010067 - F60011067; } }
        [DisplayName("")]
        public decimal F60012068 { get { return F60012001 + F60012036 + F60012067; } }
        [DisplayName("")]
        public decimal F60013001 { get { return F60013002 + F60013031; } }
        [DisplayName("")]
        public decimal F60013002 { get { return F60013003 + F60013012 + F60013021; } }
        [DisplayName("")]
        public decimal F60013003 { get { return F60013004 + F60013005 + F60013006 + F60013007 + F60013008 + F60013009 + F60013010 + F60013011; } }
        [DisplayName("")]
        public decimal F60013004 { get; set; }
        [DisplayName("")]
        public decimal F60013005 { get; set; }
        [DisplayName("")]
        public decimal F60013006 { get; set; }
        [DisplayName("")]
        public decimal F60013007 { get; set; }
        [DisplayName("")]
        public decimal F60013008 { get; set; }
        [DisplayName("")]
        public decimal F60013009 { get; set; }
        [DisplayName("")]
        public decimal F60013010 { get; set; }
        [DisplayName("")]
        public decimal F60013011 { get; set; }
        [DisplayName("")]
        public decimal F60013012 { get { return F60013013 + F60013014 + F60013015 + F60013016 + F60013017 + F60013018 + F60013019 + F60013020; } }
        [DisplayName("")]
        public decimal F60013013 { get; set; }
        [DisplayName("")]
        public decimal F60013014 { get; set; }
        [DisplayName("")]
        public decimal F60013015 { get; set; }
        [DisplayName("")]
        public decimal F60013016 { get; set; }
        [DisplayName("")]
        public decimal F60013017 { get; set; }
        [DisplayName("")]
        public decimal F60013018 { get; set; }
        [DisplayName("")]
        public decimal F60013019 { get; set; }
        [DisplayName("")]
        public decimal F60013020 { get; set; }
        [DisplayName("")]
        public decimal F60013021 { get { return F60013022 + F60013023 + F60013024 + F60013025 + F60013026 + F60013027 + F60013028 + F60013029; } }
        [DisplayName("")]
        public decimal F60013022 { get; set; }
        [DisplayName("")]
        public decimal F60013023 { get; set; }
        [DisplayName("")]
        public decimal F60013024 { get; set; }
        [DisplayName("")]
        public decimal F60013025 { get; set; }
        [DisplayName("")]
        public decimal F60013026 { get; set; }
        [DisplayName("")]
        public decimal F60013027 { get; set; }
        [DisplayName("")]
        public decimal F60013028 { get; set; }
        [DisplayName("")]
        public decimal F60013029 { get; set; }
        [DisplayName("")]
        public decimal F60013030 { get; set; }
        [DisplayName("")]
        public decimal F60013031 { get { return F60013032 + F60013033 + F60013034+ F60013035; } }
        [DisplayName("")]
        public decimal F60013032 { get; set; }
        [DisplayName("")]
        public decimal F60013033 { get; set; }
        [DisplayName("")]
        public decimal F60013034 { get; set; }
        [DisplayName("")]
        public decimal F60013035 { get; set; }
        [DisplayName("")]
        public decimal F60013036
        {
            get { return F60013037 + F60013044 + F60013050 + F60013059 + F60013064; }
        }
        [DisplayName("")]
        public decimal F60013037 { get { return F60013038 + F60013039 + F60013040 + F60013041 + F60013042 + F60013043; } }
        [DisplayName("")]
        public decimal F60013038 { get; set; }
        [DisplayName("")]
        public decimal F60013039 { get; set; }
        [DisplayName("")]
        public decimal F60013040 { get; set; }
        [DisplayName("")]
        public decimal F60013041 { get; set; }
        [DisplayName("")]
        public decimal F60013042 { get; set; }
        [DisplayName("")]
        public decimal F60013043 { get; set; }
        [DisplayName("")]
        public decimal F60013044 { get { return F60013045 + F60013046 + F60013047 + F60013048 + F60013049; } }
        [DisplayName("")]
        public decimal F60013045 { get; set; }
        [DisplayName("")]
        public decimal F60013046 { get; set; }
        [DisplayName("")]
        public decimal F60013047 { get; set; }
        [DisplayName("")]
        public decimal F60013048 { get; set; }
        [DisplayName("")]
        public decimal F60013049 { get; set; }
        [DisplayName("")]
        public decimal F60013050 { get { return F60013051 + F60013052 + F60013053 + F60013054 + F60013055 + F60013056 + F60013057 + F60013058; } }
        [DisplayName("")]
        public decimal F60013051 { get; set; }
        [DisplayName("")]
        public decimal F60013052 { get; set; }
        [DisplayName("")]
        public decimal F60013053 { get; set; }
        [DisplayName("")]
        public decimal F60013054 { get; set; }
        [DisplayName("")]
        public decimal F60013055 { get; set; }
        [DisplayName("")]
        public decimal F60013056 { get; set; }
        [DisplayName("")]
        public decimal F60013057 { get; set; }
        [DisplayName("")]
        public decimal F60013058 { get; set; }
        [DisplayName("")]
        public decimal F60013059 { get { return F60013060 + F60013061 + F60013062 + F60013063; } }
        [DisplayName("")]
        public decimal F60013060 { get; set; }
        [DisplayName("")]
        public decimal F60013061 { get; set; }
        [DisplayName("")]
        public decimal F60013062 { get; set; }
        [DisplayName("")]
        public decimal F60013063 { get; set; }
        [DisplayName("")]
        public decimal F60013064 { get { return F60013065 + F60013066; } }
        [DisplayName("")]
        public decimal F60013065 { get; set; }

        [DisplayName("")]
        public decimal F60013066 { get; set; }
        [DisplayName("")]
        public decimal F60013067 { get; set; }
        [DisplayName("")]
        public decimal F60013068 { get { return F60013001 + F60013036 + F60013067; } }

        public  List<string> getError()
        {
            List<string> msg = new List<string>();

            if (F60010001 != (F60010002 + F60010031))
                msg.Add("F60010001 est  invalide ! F60010001 = F60010002 + F60010031  ");

            if (F60010002 != (F60010003 + F60010012 + F60010021))
                msg.Add("F60010002 est  invalide ! F60010002 = F60010003+  F60010012+ F60010021 ");

            if (F60010003 != (F60010004 + F60010005 + F60010006 + F60010007 + F60010008 + F60010009 + F60010010 + F60010011))
                msg.Add("F60010003 est  invalide ! F60010003= F60010004+ F60010005+ F60010006+ F60010007+F60010008+ F60010009+ F60010010+  F60010011 ");

            if (F60010012 != (F60010013 + F60010014 + F60010015 + F60010016 + F60010017 + F60010018 + F60010019 + F60010020))
                msg.Add("F60010012 est  invalide ! (F60010012 = F60010013+ F60010014+ F60010015+ F60010016+ F60010017+ F60010018+ F60010019+ F60010020");

            if (F60010021 != (F60010022 + F60010023 + F60010024 + F60010025 + F60010026 + F60010027 + F60010028 + F60010029 + F60010030))
                msg.Add("F60010021 est  invalide ! (F60010021 = F60010022+ F60010023+ F60010024+F60010025+ F60010026+F60010027+ F60010028+  F60010029+ F60010030");

            if (F60010031 != (F60010032 + F60010033 + F60010034 + F60010035))
                msg.Add("F60010031 est  invalide ! F60010031 = F60010032+ F60010033+ F60010034+F60010035");

            if (F60010036 != (F60010037 + F60010044 + F60010050 + F60010059 + F60010064))
                msg.Add("F60010036 est  invalide ! F60010036 = F60010037+ F60010044+F60010050+ F60010059+ F60010064");

            if (F60010037 != (F60010038 + F60010039 + F60010040 + F60010041 + F60010042 + F60010043))
                msg.Add("F60010037 est  invalide ! F60010037 = F60010038+ F60010039+ F60010040+ F60010041+ F60010042+F60010043");

            if (F60010044 != (F60010045 + F60010046 + F60010047 + F60010048 + F60010049))
                msg.Add("F60010044 est  invalide ! F60010044 = F60010045+ F60010046+F60010047+F60010048+ F60010049");

            if (F60010050 != (F60010051 + F60010052 + F60010053 + F60010054 + F60010055 + F60010056 + F60010057 + F60010058))
                msg.Add("F60010050 est  invalide ! F60010050 = F60010051+ F60010052+ F60010053+F60010054+ F60010055+ F60010056+ F60010057 +  F60010058");

            if (F60010059 != (F60010060 + F60010061 + F60010062 + F60010063))
                msg.Add("F60010059 est  invalide ! F60010059 = F60010060+F60010061+F60010062+ F60010063");

            if (F60010064 != (F60010065 + F60010066))
                msg.Add("F60010064 est  invalide ! F60010064 =F60010065 +F60010066");

            if (F60010068 != (F60010001 + F60010036 + F60010067))
                msg.Add("F60010068 est  invalide ! F60010068 =F60010001+F60010036+ F60010067 ");

            if (F60011001 != (F60011002 + F60011031))
                msg.Add("F60011001 est  invalide ! F60011001 =F60011002+ F60011031 ");

            if (F60011002 != (F60011003 + F60011012 + F60011021))
                msg.Add("F60011002 est  invalide ! F60011002 =F60011003+ F60011012+ F60011021 ");

            if (F60011003 != (F60011004 + F60011005 + F60011006 + F60011007 + F60011008 + F60011009 + F60011010 + F60011011))
                msg.Add("F60011003 est  invalide ! F60011003 =F60011004+ F60011005+ F60011006+ F60011007+ F60011008+ F60011009+ F60011010+ F60011011 ");

            if (F60011012 != (F60011013 + F60011014 + F60011015 + F60011016 + F60011017 + F60011018 + F60011019 + F60011020))
                msg.Add("F60011012 est  invalide ! F60011012 =F60011013+ F60011014+ F60011015+ F60011016+ F60011017+F60011018+F60011019+ F60011020");

            if (F60011021 != (F60011022 + F60011023 + F60011024 + F60011025 + F60011026 + F60011027 + F60011028 + F60011029 + F60011030))
                msg.Add("F60011021 est  invalide ! F60011021 =F60011022+ F60011023+ F60011024+ F60011025+ F60011026+ F60011027+ F60011028+ F60011029+ F60011030");

            if (F60011031 != (F60011032 + F60011033 + F60011034 + F60011035))
                msg.Add("F60011031 est  invalide ! F60011031 =F60011032+ F60011033+ F60011034+F60011035");

            if (F60011036 != (F60011037 + F60011044 + F60011050 + F60011059 + F60011064))
                msg.Add("F60011036 est  invalide ! F60011036 =F60011037+ F60011044+ F60011050+ F60011059+ F60011064");

            if (F60011037 != (F60011038 + F60011039 + F60011040 + F60011041 + F60011042 + F60011043))
                msg.Add("F60011037 est  invalide ! F60011037 =F60011038+ F60011039+ F60011040+ F60011041+ F60011042+ F60011043");

            if (F60011044 != (F60011045 + F60011046 + F60011047 + F60011048 + F60011049))
                msg.Add("F60011044 est  invalide ! F60011044 =F60011045 + F60011046 + F60011047 + F60011048 + F60011049");

            if (F60011050 != (F60011051 + F60011052 + F60011053 + F60011054 + F60011055 + F60011056 + F60011057 + F60011058))
                msg.Add("F60011050 est  invalide ! F60011050 =F60011051 + F60011052 + F60011053 + F60011054 + F60011055 + F60011056 + F60011057 + F60011058");

            if (F60011059 != (F60011060 + F60011061 + F60011062 + F60011063))
                msg.Add("F60011059 est  invalide ! F60011059 =F60011060+ F60011061+ F60011062+ F60011063");

            if (F60011064 != (F60011065 + F60011066))
                msg.Add("F60011064 est  invalide ! F60011064 = F60011065+ F60011066");

            if (F60011068 != (F60011001 + F60011036 + F60011067))
                msg.Add("F60011068 est  invalide ! F60011068 = F60011001+ F60011036+ F60011067");

            if (F60012001 != (F60012002 + F60012031))
                msg.Add("F60012001 est  invalide ! F60012001 = F60012002+ F60012031");

            if (F60012002 != (F60012003 + F60012012 + F60012021))
                msg.Add("F60012002 est  invalide ! F60012002 = F60012003+ F60012012+ F60012021");

            if (F60012003 != (F60012004 + F60012005 + F60012006 + F60012007 + F60012008 + F60012009 + F60012010 + F60012011))
                msg.Add("F60012003 est  invalide ! F60012003 = F60012004 + F60012005 + F60012006 + F60012007 + F60012008 + F60012009 + F60012010 + F60012011");

            if (F60012012 != (F60012013 + F60012014 + F60012015 + F60012016 + F60012017 + F60012018 + F60012019 + F60012020))
                msg.Add("F60012012 est  invalide ! F60012012 = F60012013 + F60012014 + F60012015 + F60012016 + F60012017 + F60012018 + F60012019 + F60012020");

            if (F60012021 != (F60012022 + F60012023 + F60012024 + F60012025 + F60012026 + F60012027 + F60012028 + +F60012029 + F60012030))
                msg.Add("F60012021 est  invalide ! F60012021 =F60012022 + F60012023 + F60012024 + F60012025 + F60012026 + F60012027 + F60012028 + +F60012029 + F60012030");

            if (F60012031 != (F60012032 + F60012033 + F60012034 + F60012035))
                msg.Add("F60012031 est  invalide ! F60012031 =F60012032 + F60012033+ F60012034+ F60012035");


            if (F60012036 != (F60012037 + F60012044 + F60012050 + F60012059 + F60012064))
                msg.Add("F60012036 est  invalide ! F60012036 =F60012037 + F60012044 + F60012050 + F60012059 + F60012064");


            if (F60012037 != (F60012038 + F60012039 + F60012040 + F60012041 + F60012042 + F60012043))
                msg.Add("F60012037 est  invalide ! F60012037 = F60012038 + F60012039 + F60012040 + F60012041 + F60012042 + F60012043");

            if (F60011044 != (F60011045 + F60011046 + F60011047 + F60011048 + F60011049))
                msg.Add("F60011044 est  invalide ! F60011044 = F60011045 + F60011046 + F60011047 + F60011048 + F60011049");

            if (F60011050 != (F60011051 + F60011052 + F60011053 + F60011054 + F60011055 + F60011056 + F60011057 + F60011058))
                msg.Add("F60011050 est  invalide ! F60011050 = F60011051 + F60011052 + F60011053 + F60011054 + F60011055 + F60011056 + F60011057 + F60011058");

            if (F60011059 != (F60011060 + F60011061 + F60011062 + F60011063))
                msg.Add("F60011059 est  invalide ! F60011059 = F60011060+F60011061+ F60011062+F60011063");

            if (F60011064 != (F60011065 + F60011066))
                msg.Add("F60011064 est  invalide ! F60011064 =F60011065 + F60011066");

            if (F60011068 != (F60011001 + F60011036 + F60011067))
                msg.Add("F60011068 est  invalide ! F60011068 =F60011001 + F60011036 + F60011067");

            if (F60012001 != (F60012002 + F60012031))
                msg.Add("F60012001 est  invalide ! F60012001 =F60012002 + F60012031");

            if (F60012002 != (F60012003 + F60012012 + F60012021))
                msg.Add("F60012002 est  invalide ! F60012002 =F60012003 + F60012012 + F60012021");

            if (F60012003 != (F60012004 + F60012005 + F60012006 + F60012007 + F60012008 + F60012009 + F60012010 + F60012011))
                msg.Add("F60012003 est  invalide ! F60012003 =F60012004 + F60012005 + F60012006 + F60012007 + F60012008 + F60012009 + F60012010 + F60012011");

            if (F60012012 != (F60012013 + F60012014 + F60012015 + F60012016 + F60012017 + F60012018 + F60012019 + F60012020))
                msg.Add("F60012012 est  invalide ! F60012012 =F60012013 + F60012014 + F60012015 + F60012016 + F60012017 + F60012018 + F60012019 + F60012020");


            if (F60012021 != (F60012022 + F60012023 + F60012024 + F60012025 + F60012026 + F60012027 + F60012028 + F60012029 + F60012030))
                msg.Add("F60012021 est  invalide ! F60012021 =F60012022 + F60012023 + F60012024 + F60012025 + F60012026 + F60012027 + F60012028 + F60012029 + F60012030");


            if (F60012031 != (F60012032 + F60012033 + F60012034 + F60012035))
                msg.Add("F60012031 est  invalide ! F60012031 =F60012032 + F60012033 + F60012034 + F60012035");

            if (F60012036 != (F60012037 + F60012044 + F60012050 + F60012059 + F60012064))
                msg.Add("F60012036 est  invalide ! F60012036 =F60012037 + F60012044 + F60012050 + F60012059 + F60012064");

            if (F60012037 != (F60012038 + F60012039 + F60012040 + F60012041 + F60012042 + F60012043))
                msg.Add("F60012037 est  invalide ! F60012037 =F60012038 + F60012039 + F60012040 + F60012041 + F60012042 + F60012043");

            if (F60012044 != (F60012045 + F60012046 + F60012047 + F60012048 + F60012049))
                msg.Add("F60012044 est  invalide ! F60012044 =F60012045 + F60012046 + F60012047 + F60012048 + F60012049");

            if (F60012050 != (F60012051 + F60012052 + F60012053 + F60012054 + F60012055 + F60012056 + F60012057 + F60012058))
                msg.Add("F60012050 est  invalide ! F60012050 =F60012051 + F60012052 + F60012053 + F60012054 + F60012055 + F60012056 + F60012057 + F60012058");

            if (F60012050 != (F60012051 + F60012052 + F60012053 + F60012054 + F60012055 + F60012056 + F60012057 + F60012058))
                msg.Add("F60012050 est  invalide ! F60012050 =F60012051 + F60012052 + F60012053 + F60012054 + F60012055 + F60012056 + F60012057 + F60012058");

            if (F60012059 != (F60012060 + F60012061 + F60012062 + F60012063))
                msg.Add("F60012059 est  invalide ! F60012059 =F60012060 + F60012061 + F60012062 + F60012063");


            if (F60012064 != (F60012065 + F60012066))
                msg.Add("F60012064 est  invalide ! F60012064 =F60012065 + F60012066");

            if (F60012068 != (F60012001 + F60012036 + F60012067))
                msg.Add("F60012068 est  invalide ! F60012068 =F60012001 + F60012036 + F60012067");


            if (F60013001 != (F60013002 + F60013031))
                msg.Add("F60013001 est  invalide ! F60013001 =F60013002+ F60013031");

            if (F60013002 != (F60013003 + F60013012 + F60013021))
                msg.Add("F60013002 est  invalide ! F60013002 =F60013003 + F60013012 + F60013021");


            if (F60013003 != (F60013004 + F60013005 + F60013006 + F60013007 + F60013008 + F60013009 + F60013010 + F60013011))
                msg.Add("F60013003 est  invalide ! F60013003 =F60013004 + F60013005 + F60013006 + F60013007 + F60013008 + F60013009 + F60013010 + F60013011");


            if (F60013012 != (F60013013 + F60013014 + F60013015 + F60013016 + F60013017 + F60013018 + F60013019 + F60013020))
                msg.Add("F60013012 est  invalide ! F60013012 =F60013013 + F60013014 + F60013015 + F60013016 + F60013017 + F60013018 + F60013019 + F60013020");

            if (F60013021 != (F60013022 + F60013023 + F60013024 + F60013025 + F60013026 + F60013027 + F60013028 + F60013029 + F60013030))
                msg.Add("F60013021 est  invalide ! F60013021 =F60013022 + F60013023 + F60013024 + F60013025 + F60013026 + F60013027 + F60013028 + F60013029 + F60013030");

            if (F60013031 != (F60013032 + F60013033 + F60013034 + F60013035))
                msg.Add("F60013031 est  invalide ! F60013031 =F60013032 + F60013033 + F60013034 + F60013035");

            if (F60013036 != (F60013037 + F60013044 + F60013050 + F60013059 + F60013064))
                msg.Add("F60013036 est  invalide ! F60013036 =F60013037 + F60013044 + F60013050 + F60013059 + F60013064");

            if (F60013037 != (F60013038 + F60013039 + F60013040 + F60013041 + F60013042 + F60013043))
                msg.Add("F60013037 est  invalide ! F60013037 =F60013038 + F60013039 + F60013040 + F60013041 + F60013042 + F60013043");

            if (F60013044 != (F60013045 + F60013046 + F60013047 + F60013048 + F60013049))
                msg.Add("F60013044 est  invalide ! F60013044 =F60013045 + F60013046 + F60013047 + F60013048 + F60013049");

            if (F60013050 != (F60013051 + F60013052 + F60013053 + F60013054 + F60013055 + F60013056 + F60013057 + F60013058))
                msg.Add("F60013050 est  invalide ! F60013050 =F60013051 + F60013052 + F60013053 + F60013054 + F60013055 + F60013056 + F60013057 + F60013058");

            if (F60013059 != (F60013060 + F60013061 + F60013062 + F60013063))
                msg.Add("F60013059 est  invalide ! F60013059 =F60013060 + F60013061 + F60013062 + F60013063");

            if (F60013064 != (F60013065 + F60013066))
                msg.Add("F60013064 est  invalide ! F60013064 =F60013065 + F60013066");

            if (F60013068 != (F60013001 + F60013036 + F60013067))
                msg.Add("F60013068 est  invalide ! F60013068 =F60013001 + F60013036 + F60013067");

            if (F60012001 != (F60010001 - F60011001))
                msg.Add("F60012001 est  invalide ! F60012001 =F60010001 - F60011001");

            if (F60012002 != (F60010002 - F60011002))
                msg.Add("F60012002 est  invalide ! F60012002 = F60010002 - F60011002");

            if (F60012003 != (F60010003 - F60011003))
                msg.Add("F60012003 est  invalide ! F60012003 = F60010003 - F60011003");

            if (F60012004 != (F60010004 - F60011004))
                msg.Add("F60012004 est  invalide ! F60012004 = F60010004 - F60011004");

            if (F60012005 != (F60010005 - F60011005))
                msg.Add("F60012005 est  invalide ! F60012005 = F60010005 - F60011005");

            if (F60012006 != (F60010006 - F60011006))
                msg.Add("F60012006 est  invalide ! F60012006 = F60010006 - F60011006");

            if (F60012007 != (F60010007 - F60011007))
                msg.Add("F60012007 est  invalide ! F60012007 = F60010007 - F60011007");

            if (F60012008 != (F60010008 - F60011008))
                msg.Add("F60012008 est  invalide ! F60012008 = F60010008 - F60011008");                      
            if (F60012009 != (F60010009 - F60011009))
                msg.Add("F60012009 est  invalide ! F60012009 = F60010009 - F60011009");

            if (F60012010 != (F60010010 - F60011010))
                msg.Add("F60012010 est  invalide ! F60012010 = F60010010 - F60011010");
            if (F60012011 != (F60010011 - F60011011))
                msg.Add("F60012011 est  invalide ! F60012011 = F60010011 - F60011011");
            if (F60012012 != (F60010012 - F60011012))
                msg.Add("F60012012 est  invalide ! F60012012 = F60010012 - F60011012");
            if (F60012013 != (F60010013 - F60011013))
                msg.Add("F60012013 est  invalide ! F60012013 = F60010013 - F60011013");
            if (F60012014 != (F60010014 - F60011014))
                msg.Add("F60012014 est  invalide ! F60012014 = F60010014 - F60011014");
            if (F60012015 != (F60010015 - F60011015))
                msg.Add("F60012015 est  invalide ! F60012015 = F60010015 - F60011015");
            if (F60012016 != (F60010016 - F60011016))
                msg.Add("F60012016 est  invalide ! F60012016 = F60010016 - F60011016");
            if (F60012017 != (F60010017 - F60011017))
                msg.Add("F60012017 est  invalide ! F60012017 = F60010017 - F60011017");
            if (F60012018 != (F60010018 - F60011018))
                msg.Add("F60012018 est  invalide ! F60012018 = F60010018 - F60011018");
            if (F60012019 != (F60010019 - F60011019))
                msg.Add("F60012019 est  invalide ! F60012019 = F60010019 - F60011019");
            if (F60012020 != (F60010020 - F60011020))
                msg.Add("F60012020 est  invalide ! F60012020 = F60010020 - F60011020");
            if (F60012021 != (F60010021 - F60011021))
                msg.Add("F60012021 est  invalide ! F60012021 = F60010021 - F60011021");
            if (F60012022 != (F60010022 - F60011022))
                msg.Add("F60012022 est  invalide ! F60012022 = F60010022 - F60011022");
            if (F60012023 != (F60010023 - F60011023))
                msg.Add("F60012023 est  invalide ! F60012023 = F60010023 - F60011023");
            if (F60012024 != (F60010024 - F60011024))
                msg.Add("F60012024 est  invalide ! F60012024 = F60010024 - F60011024");
            if (F60012025 != (F60010025 - F60011025))
                msg.Add("F60012025 est  invalide ! F60012025 = F60010025 - F60011025");
            if (F60012026 != (F60010026 - F60011026))
                msg.Add("F60012026 est  invalide ! F60012026 = F60010026 - F60011026");
            if (F60012027 != (F60010027 - F60011027))
                msg.Add("F60012027 est  invalide ! F60012027 = F60010027 - F60011027");
            if (F60012028 != (F60010028 - F60011028))
                msg.Add("F60012028 est  invalide ! F60012028 = F60010028 - F60011028");
            if (F60012029 != (F60010029 - F60011029))
                msg.Add("F60012029 est  invalide ! F60012029 = F60010029 - F60011029");
            if (F60012030 != (F60010030 - F60011030))
                msg.Add("F60012030 est  invalide ! F60012030 = F60010030 - F60011030");
            if (F60012031 != (F60010031 - F60011031))
                msg.Add("F60012031 est  invalide ! F60012031 = F60010031 - F60011031");
            if (F60012032 != (F60010032 - F60011032))
                msg.Add("F60012032 est  invalide ! F60012032 = F60010032 - F60011032");
            if (F60012033 != (F60010033 - F60011033))
                msg.Add("F60012033 est  invalide ! F60012033 = F60010033 - F60011033");
            if (F60012034 != (F60010034 - F60011034))
                msg.Add("F60012034 est  invalide ! F60012034 = F60010034 - F60011034");
            if (F60012035 != (F60010035 - F60011035))
                msg.Add("F60012035 est  invalide ! F60012035 = F60010035 - F60011035");
            if (F60012036 != (F60010036 - F60011036))
                msg.Add("F60012036 est  invalide ! F60012036 = F60010036 - F60011036");
            if (F60012037 != (F60010037 - F60011037))
                msg.Add("F60012037 est  invalide ! F60012037 = F60010037 - F60011037");
            if (F60012038 != (F60010038 - F60011038))
                msg.Add("F60012038 est  invalide ! F60012038 = F60010038 - F60011038");
            if (F60012039 != (F60010039 - F60011039))
                msg.Add("F60012039 est  invalide ! F60012039 = F60010039 - F60011039");
            if (F60012040 != (F60010040 - F60011040))
                msg.Add("F60012040 est  invalide ! F60012040 = F60010040 - F60011040");
            if (F60012041 != (F60010041 - F60011041))
                msg.Add("F60012041 est  invalide ! F60012041 = F60010041 - F60011041");
            if (F60012042 != (F60010042 - F60011042))
                msg.Add("F60012042 est  invalide ! F60012042 = F60010042 - F60011042");
            if (F60012043 != (F60010043 - F60011043))
                msg.Add("F60012043 est  invalide ! F60012043 = F60010043 - F60011043");
            if (F60012044 != (F60010044 - F60011044))
                msg.Add("F60012044 est  invalide ! F60012044 = F60010044 - F60011044");
            if (F60012045 != (F60010045 - F60011045))
                msg.Add("F60012045 est  invalide ! F60012045 = F60010045 - F60011045");
            if (F60012046 != (F60010046 - F60011046))
                msg.Add("F60012046 est  invalide ! F60012046 = F60010046 - F60011046");
            if (F60012047 != (F60010047 - F60011047))
                msg.Add("F60012047 est  invalide ! F60012047 = F60010047 - F60011047");
            if (F60012048 != (F60010048 - F60011048))
                msg.Add("F60012048 est  invalide ! F60012048 = F60010048 - F60011048");
            if (F60012049 != (F60010049 - F60011049))
                msg.Add("F60012049 est  invalide ! F60012049 = F60010049 - F60011049");
            if (F60012050 != (F60010050 - F60011050))
                msg.Add("F60012050 est  invalide ! F60012050 = F60010050 - F60011050");
            if (F60012051 != (F60010051 - F60011051))
                msg.Add("F60012051 est  invalide ! F60012051 = F60010051 - F60011051");
            if (F60012052 != (F60010052 - F60011052))
                msg.Add("F60012052 est  invalide ! F60012052 = F60010052 - F60011052");
            if (F60012053 != (F60010053 - F60011053))
                msg.Add("F60012053 est  invalide ! F60012053 = F60010053 - F60011053");
            if (F60012054 != (F60010054 - F60011054))
                msg.Add("F60012054 est  invalide ! F60012054 = F60010054 - F60011054");
            if (F60012055 != (F60010055 - F60011055))
                msg.Add("F60012055 est  invalide ! F60012055 = F60010055 - F60011055");
            if (F60012056 != (F60010056 - F60011056))
                msg.Add("F60012056 est  invalide ! F60012056 = F60010056 - F60011056");
            if (F60012057 != (F60010057 - F60011057))
                msg.Add("F60012057 est  invalide ! F60012057 = F60010057 - F60011057");
            if (F60012058 != (F60010058 - F60011058))
                msg.Add("F60012058 est  invalide ! F60012058 = F60010058 - F60011058");
            if (F60012059 != (F60010059 - F60011059))
                msg.Add("F60012059 est  invalide ! F60012059 = F60010059 - F60011059");
            if (F60012060 != (F60010060 - F60011060))
                msg.Add("F60012060 est  invalide ! F60012060 = F60010060 - F60011060");
            if (F60012061 != (F60010061 - F60011061))
                msg.Add("F60012061 est  invalide ! F60012061 = F60010061 - F60011061");
            if (F60012062 != (F60010062 - F60011062))
                msg.Add("F60012062 est  invalide ! F60012062 = F60010062 - F60011062");
            if (F60012063 != (F60010063 - F60011063))
                msg.Add("F60012063 est  invalide ! F60012063 = F60010063 - F60011063");
            if (F60012064 != (F60010064 - F60011064))
                msg.Add("F60012064 est  invalide ! F60012064 = F60010064 - F60011064");
            if (F60012065 != (F60010065 - F60011065))
                msg.Add("F60012065 est  invalide ! F60012065 = F60010065 - F60011065");
            if (F60012066 != (F60010066 - F60011066))
                msg.Add("F60012066 est  invalide ! F60012066 = F60010066 - F60011066");
            if (F60012067 != (F60010067 - F60011067))
                msg.Add("F60012067 est  invalide ! F60012067 = F60010067 - F60011067");
            if (F60012068 != (F60010068 - F60011068))
                msg.Add("F60012068 est  invalide ! F60012068 = F60010068 - F60011068");


            return msg;
        }

    }
}
