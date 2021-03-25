using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Core.Models.Liass
{
    public partial class F6004
    {
        public int Id { get; set; }
        public int SocieteNo { get; set; }
        public int ExerciceId { get; set; }
        [DisplayName("Acte de dépot")]
        public int ActeDeDepot { get; set; }
        [DisplayName("Nature de dépot")]
        public string NatureDepot { get; set; }

        [DisplayName("Flux de Trésorerie liés à l'Exploitation ")]
        public decimal F60040001 { get { return F60040002  -  F60040012  -  F60040023  -  F60040032  -  F60040045; } }
        public decimal F60041001 { get { return F60041002 - F60041012 - F60041023 - F60041032 - F60041045; } }
        [DisplayName("Encaissements reçus des clients")]
        public decimal F60040002 { get { return F60040003  -  F60040004  +  F60040005  +  F60040006  -  F60040007  +  F60040008  -  F60040009  -  F60040010  + F60040011; } }
        public decimal F60041002 { get { return F60041003 - F60041004 + F60041005 + F60041006 - F60041007 + F60041008 - F60041009 - F60041010 + F60041011; } }
        [DisplayName("S.Debiteurs Clts et Rattaches et Regul.bruts en Debut d'exercice")]
        public decimal F60040003 { get; set; }
        public decimal F60041003 { get; set; }
        [DisplayName("S.Crediteurs Clts et Rattaches et Regul.bruts en Debut d'exercice")]
        public decimal F60040004 { get; set; }
        public decimal F60041004 { get; set; }
        [DisplayName("Ventes TTC")]
        public decimal F60040005 { get; set; }
        public decimal F60041005 { get; set; }
        [DisplayName("Ajustements des ventes des exercices anterieurs portes en modifications comptables (compte 128) majores de la TVA")]
        public decimal F60040006 { get; set; }
        public decimal F60041006 { get; set; }
        [DisplayName("Creances clients passees en pertes (comptes 634)")]
        public decimal F60040007 { get; set; }
        public decimal F60041007 { get; set; }
        [DisplayName("Gains de change sur creances clients en devises")]
        public decimal F60040008 { get; set; }
        public decimal F60041008 { get; set; }
        [DisplayName("Pertes de change sur creances client en devises")]
        public decimal F60040009 { get; set; }
        public decimal F60041009 { get; set; }
        [DisplayName("S.Debiteurs Clts et Rattaches et Regul.bruts en Fin d'exercice")]
        public decimal F60040010 { get; set; }
        public decimal F60041010 { get; set; }
        [DisplayName(".Crediteurs Clts et Rattaches et Regul.bruts en Fin d'exercice")]
        public decimal F60040011 { get; set; }
        public decimal F60041011 { get; set; }
        [DisplayName("Sommes versees aux fournisseurs (d'exploitation)")]
        public decimal F60040012 { get { return F60040013  -  F60040014  +  F60040015  +  F60040016  +  F60040017  -  F60040018  +  F60040019  -  F60040020  +  F60040021  -  F60040022; } }
        public decimal F60041012 { get { return F60041013 - F60041014 + F60041015 + F60041016 + F60041017 - F60041018 + F60041019 - F60041020 + F60041021 - F60041022; } }

        [DisplayName("S.Crediteurs Frs Expl. et Rattaches et Regul. en Debut d'exercice")]
        public decimal F60040013 { get; set; }
        public decimal F60041013 { get; set; }
        [DisplayName("S.Debiteurs Frs Expl. et Rattaches et Regul. en Debut d'exercice")]
        public decimal F60040014 { get; set; }
        public decimal F60041014 { get; set; }
        [DisplayName("S.C. Etat, RaS  et autres I et T/Ch.Exploitation en Debut d'exercice")]
        public decimal F60040015 { get; set; }
        public decimal F60041015 { get; set; }
        [DisplayName("Achats TTC (des comptes 60, 61, 62 et 63 en partie)")]
        public decimal F60040016 { get; set; }
        public decimal F60041016 { get; set; }
        [DisplayName("Ajustements des achats des exercices anterieurs portes en modifications comptables (compte 128) majores de la TVA")]
        public decimal F60040017 { get; set; }
        public decimal F60041017 { get; set; }
        [DisplayName("Gains de change sur dettes Frs Expl. en devises")]
        public decimal F60040018 { get; set; }
        public decimal F60041018 { get; set; }
        [DisplayName("Pertes de change sur dettes Frs Expl. en devises")]
        public decimal F60040019 { get; set; }
        public decimal F60041019 { get; set; }
        [DisplayName("S.Crediteurs Frs Expl. et Rattaches et Regul. en Fin d'exercice")]
        public decimal F60040020 { get; set; }
        public decimal F60041020 { get; set; }
        [DisplayName("S.Debiteurs Frs Expl. et Rattaches et Regul. en Fin d'exercice")]
        public decimal F60040021 { get; set; }
        public decimal F60041021 { get; set; }
        [DisplayName("S.C. Etat, RaS  et autres I et T/Ch.Exploitation en Fin d'exercice")]
        public decimal F60040022 { get; set; }
        public decimal F60041022 { get; set; }
        [DisplayName("Sommes versees au personnel")]
        public decimal F60040023 { get { return F60040024 - F60040025 + F60040026 + F60040027 + -F60040028 - F60040029 + F60040030 + F60040031; } }
        public decimal F60041023 { get { return F60041024 - F60041025 + F60041026 + F60041027 + -F60041028 - F60041029 + F60041030 + F60041031; } }

        [DisplayName("S.Crediteurs PL(Org.Sociaux) et Lies et Regul.en Debut d'exercice")]
        public decimal F60040024 { get; set; }
        public decimal F60041024 { get; set; }
        [DisplayName("S.Debiteurs PL(Org.Sociaux) et Lies et Regul.en Debut d'exercice")]
        public decimal F60040025 { get; set; }
        public decimal F60041025 { get; set; }
        [DisplayName("S.C. Etat, RaS  et autres I et T/Ch.du personnel en Debut d'exercice")]
        public decimal F60040026 { get; set; }
        public decimal F60041026 { get; set; }
        [DisplayName("Charges de personnel de l'exercice")]
        public decimal F60040027 { get; set; }
        public decimal F60041027 { get; set; }
        [DisplayName("Ajustements des charges de personnel des exercices anterieurs portes en modifications comptables (compte 128)")]
        public decimal F60040028 { get; set; }
        public decimal F60041028 { get; set; }
        [DisplayName("S.Crediteurs PL(Org.Sociaux) et Lies et Regul.en Fin d'exercice")]
        public decimal F60040029 { get; set; }
        public decimal F60041029 { get; set; }
        [DisplayName("S.Debiteurs PL(Org.Sociaux) et Lies et Regul.en Fin d'exercice")]
        public decimal F60040030 { get; set; }
        public decimal F60041030 { get; set; }
        [DisplayName("S.C. Etat, RaS  et autres I et T/Ch.du personnel en Fin d'exercice")]
        public decimal F60040031 { get; set; }
        public decimal F60041031 { get; set; }
        [DisplayName("Interets payes")]
        public decimal F60040032 { get { return F60040033  -  F60040034  +  F60040035  +  F60040036  +  F60040037  -  F60040038  -  F60040039  -  F60040040  +  F60040041  -  F60040042  +  F60040043  -  F60040044; } }
        public decimal F60041032 { get { return F60041033 - F60041034 + F60041035 + F60041036 + F60041037 - F60041038 - F60041039 - F60041040 + F60041041 - F60041042 + F60041043 - F60041044; } }

        [DisplayName("S.C. Interets dus et Rattaches et Regul.a Payer en Debut d'exercice")]
        public decimal F60040033 { get; set; }
        public decimal F60041033 { get; set; }
        [DisplayName("S.D. Interets comptes de Regul.d'Avance en Debut d'exercice")]
        public decimal F60040034 { get; set; }
        public decimal F60041034 { get; set; }
        [DisplayName("S.C. Etat, RaS/Revenus de Capitaux en Debut d'exercice")]
        public decimal F60040035 { get; set; }
        public decimal F60041035 { get; set; }
        [DisplayName("Charges Financieres de l'exercice")]
        public decimal F60040036 { get; set; }
        public decimal F60041036 { get; set; }
        [DisplayName("Ajustements des charges d'interet des exercices anterieurs portes en modifications comptables (compte 128)")]
        public decimal F60040037 { get; set; }
        public decimal F60041037 { get; set; }
        [DisplayName("Frais d'emission d'emprunt")]
        public decimal F60040038 { get; set; }
        public decimal F60041038 { get; set; }
        [DisplayName("Dot.Resorp. Frais d'emission et Primes de Rembours.Empts")]
        public decimal F60040039 { get; set; }
        public decimal F60041039 { get; set; }
        [DisplayName("Dot.Prov. Risques et charges financiers  et  Risques de change  et  deprec.immo.financieres  et  deprec.placements et prets courants")]
        public decimal F60040040 { get; set; }
        public decimal F60041040 { get; set; }
        [DisplayName("eprise/Prov. Risques  et charges financiers  et  Risques de change  et  deprec.immo.financieres  et  deprec.placements et prets courants")]
        public decimal F60040041 { get; set; }
        public decimal F60041041 { get; set; }
        [DisplayName("S.C. Interets dus et Rattaches et Regul.a Payer en Fin d'exercice")]
        public decimal F60040042 { get; set; }
        public decimal F60041042 { get; set; }
        [DisplayName("S.D. Interets Comptes de Regul.d'Avance en Fin d'exercice")]
        public decimal F60040043 { get; set; }
        public decimal F60041043 { get; set; }
        [DisplayName("S.C. Etat, RaS/Revenus de Capitaux en Fin d'exercice")]
        public decimal F60040044 { get; set; }
        public decimal F60041044 { get; set; }
        [DisplayName("Impots et taxes payes")]
        public decimal F60040045 { get { return F60040046  -  F60040047  -  F60040048  +  F60040049  +  F60040050  +  F60040051  -  F60040052  +  F60040053  +  F60040054  -  F60040055  +  F60040056  +  F60040057; } }
        public decimal F60041045 { get { return F60041046 - F60041047 - F60041048 + F60041049 + F60041050 + F60041051 - F60041052 + F60041053 + F60041054 - F60041055 + F60041056 + F60041057; } }

        [DisplayName("S.Crediteurs ( Etat, impots et taxes ) en Debut d'exercice ")]
        public decimal F60040046 { get; set; }
        public decimal F60041046 { get; set; }
        [DisplayName("S.Debiteurs ( Etat, impots et taxes ) en Debut d'exercice")]
        public decimal F60040047 { get; set; }
        public decimal F60041047 { get; set; }
        [DisplayName("S.C.Impot/Resultat differe (+)actif;(-)passif en Debut d'exercice")]
        public decimal F60040048 { get; set; }
        public decimal F60041048 { get; set; }
        [DisplayName("Impot sur les Resultats (69) ")]
        public decimal F60040049 { get; set; }
        public decimal F60041049 { get; set; }
        [DisplayName("Impots et Taxes de l'exercice  (66)")]
        public decimal F60040050 { get; set; }
        public decimal F60041050 { get; set; }
        [DisplayName("TVA et autres Taxes/B et S Hors exploitation")]
        public decimal F60040051 { get; set; }
        public decimal F60041051 { get; set; }
        [DisplayName("Impot/Resultat differe (+)actif;(-)passif constate durant l'exercice sans passer par l�Etat de resultat")]
        public decimal F60040052 { get; set; }
        public decimal F60041052 { get; set; }
        [DisplayName("Impots et Taxes portes en Modif.Compt.(cpt128)")]
        public decimal F60040053 { get; set; }
        public decimal F60041053 { get; set; }
        [DisplayName("Impot/Resultat a(+)liquider;(-)imputer portes en Modif.Compt.")]
        public decimal F60040054 { get; set; }
        public decimal F60041054 { get; set; }
        [DisplayName("S.Crediteurs ( Etat, impot et taxes ) en Fin d'exercice")]
        public decimal F60040055 { get; set; }
        public decimal F60041055 { get; set; }
        [DisplayName("S.Debiteurs ( Etat, impot et taxes ) en Fin d'exercice ")]
        public decimal F60040056 { get; set; }
        public decimal F60041056 { get; set; }
        [DisplayName("S.C.Impot/Resultat differe (+)actif;(-)passif en Fin d'exercice ")]
        public decimal F60040057 { get; set; }
        public decimal F60041057 { get; set; }
        [DisplayName("Flux de tresorerie lies aux activites d'investissement")]
        public decimal F60040058 { get { return -F60040059  +  F60040066  -  F60040080  +  F60040084; } }
        public decimal F60041058 { get { return -F60041059 + F60041066 - F60041080 + F60041084; } }
        [DisplayName("Decaissements lies aux immo. Corporelles et incorporelles ")]
        public decimal F60040059 { get { return F60040060  +  F60040061  +  F60040062  +  F60040063  -  F60040064  -  F60040065; } }
        public decimal F60041059 { get { return F60041060 + F60041061 + F60041062 + F60041063 - F60041064 - F60041065; } }
        [DisplayName("S.C.FRS d'Invest. et Rattaches et Regul. en Debut d'exercice ")]
        public decimal F60040060 { get; set; }
        public decimal F60041060 { get; set; }
        [DisplayName("S.C. Etat, RaS operee/plus value immobiliere en Fin d'exercice")]
        public decimal F60040061 { get; set; }
        public decimal F60041061 { get; set; }
        [DisplayName("Valeurs brutes des Invest. d'exercice")]
        public decimal F60040062 { get; set; }
        public decimal F60041062 { get; set; }
        [DisplayName("TVA payee/Investissements de l'exercice")]
        public decimal F60040063 { get; set; }
        public decimal F60041063 { get; set; }
        [DisplayName("S.C. FRS d'Invest. et Rattaches et Regul. en Fin d'exercice ")]
        public decimal F60040064 { get; set; }
        public decimal F60041064 { get; set; }
        [DisplayName("S.C. Etat, RaS operee/plus value immobiliere en Fin d'exercice")]
        public decimal F60040065 { get; set; }
        public decimal F60041065 { get; set; }
        [DisplayName("Encaissements lies aux immo. Corporelles et incorporelles")]
        public decimal F60040066 { get { return F60040067  +  F60040068  -  F60040069  -  F60040070  +  F60040071  -  F60040072  -  F60040073  +  F60040074  -  F60040075  -  F60040076  +  F60040077  +  F60040078  -  F60040079; } }
        public decimal F60041066 { get { return F60041067 + F60041068 - F60041069 - F60041070 + F60041071 - F60041072 - F60041073 + F60041074 - F60041075 - F60041076 + F60041077 + F60041078 - F60041079; } }
        [DisplayName("S.D. Immo.Corporelles et Incorporelles en Debut d'exercice")]
        public decimal F60040067 { get; set; }
        public decimal F60041067 { get; set; }
        [DisplayName("S.D. Debiteurs  et  autres Creances TTC / cession des Immo.en Debut d'exercice")]
        public decimal F60040068 { get; set; }
        public decimal F60041068 { get; set; }
        [DisplayName("S.C.TVA collectee/cession Investissements en Debut d'exercice ")]
        public decimal F60040069 { get; set; }
        public decimal F60041069 { get; set; }
        [DisplayName("S.C.TVA a reverser/cession Investissements en Debut d'exercice")]
        public decimal F60040070 { get; set; }
        public decimal F60041070 { get; set; }
        [DisplayName("S.D.Etat, RaS supportee/plus value immobiliere en Debut d'exercice")]
        public decimal F60040071 { get; set; }
        public decimal F60041071 { get; set; }
        [DisplayName("TVA a reverser/cession d'Invest. durant l'exercice ")]
        public decimal F60040072 { get; set; }
        public decimal F60041072 { get; set; }
        [DisplayName("Produits nets/Cession des Invest.(-TVA a reverser comprise) durant l'exercice")]
        public decimal F60040073 { get; set; }
        public decimal F60041073 { get; set; }
        [DisplayName("Charges Nettes/Cession des Invest. durant l'exercice")]
        public decimal F60040074 { get; set; }
        public decimal F60041074 { get; set; }
        [DisplayName("S.D. Immo.Corporelles et Incorporelles en Fin d'exercice ")]
        public decimal F60040075 { get; set; }
        public decimal F60041075 { get; set; }
        [DisplayName("S.D.Debiteurs  et  autres Creances TTC / cession des Invest. en Fin d'exercice")]
        public decimal F60040076 { get; set; }
        public decimal F60041076 { get; set; }
        [DisplayName("S.C. TVA collectee/cession investissements en Fin d'exercice")]
        public decimal F60040077 { get; set; }
        public decimal F60041077 { get; set; }
        [DisplayName("S.C. TVA a reverser/cession investissements en Fin d'exercice")]
        public decimal F60040078 { get; set; }
        public decimal F60041078 { get; set; }
        [DisplayName("S.D.Etat, RaS supportee/plus value immobiliere en Fin d�exercice")]
        public decimal F60040079 { get; set; }
        public decimal F60041079 { get; set; }
        [DisplayName("Decaissements lies aux immobilisations financieres")]
        public decimal F60040080 { get { return F60040081  +  F60040082  -  F60040083; } }
        public decimal F60041080 { get { return F60041081 + F60041082 - F60041083; } }
        [DisplayName("Dettes/acquisition d'immo. Financieres en fin d'exercice")]
        public decimal F60040081 { get; set; }
        public decimal F60041081 { get; set; }
        [DisplayName("Valeur brute des titres acquis durant l�exercice")]
        public decimal F60040082 { get; set; }
        public decimal F60041082 { get; set; }
        [DisplayName("Dettes/acquisition d'immo. Finan. en debut d'exercice")]
        public decimal F60040083 { get; set; }
        public decimal F60041083 { get; set; }
        [DisplayName("Encaissements lies aux immobilisations financieres")]
        public decimal F60040084 { get { return F60040085 + F60040086 + F60040087 - F60040088; } }
        public decimal F60041084 { get {return F60041085 + F60041086 + F60041087 - F60041088;}}
        [DisplayName("Creances sur cessions d'immo.Fin. en debut d'exercice")]
        public decimal F60040085 { get; set; }
        public decimal F60041085 { get; set; }
        [DisplayName("Cessions /Immo.Financieres durant l'exercice")]
        public decimal F60040086 { get; set; }
        public decimal F60041086 { get; set; }
        [DisplayName("Remboursements/Immo.Financieres durant l'exercice ")]
        public decimal F60040087 { get; set; }
        public decimal F60041087 { get; set; }
        [DisplayName("Creances sur cessions d'immo.financ. en fin d�exercice")]
        public decimal F60040088 { get; set; }
        public decimal F60041088 { get; set; }
        [DisplayName("Flux de tresorerie lies aux activites de financement")]
        public decimal F60040089 { get { return F60040090  -  F60040097  +  F60040103  -  F60040108; } }
        public decimal F60041089 { get { return F60041090 - F60041097 + F60041103 - F60041108; } }
        [DisplayName("Encaissements suite a l'emission d'actions")]
        public decimal F60040090 { get { return F60040091  +  F60040092  -  F60040093  -  F60040094  -  F60040095  +  F60040096; } }
        public decimal F60041090 { get { return F60041091 + F60041092 - F60041093 - F60041094 - F60041095 + F60041096; } }
        [DisplayName("Capital en fin d'exercice")]
        public decimal F60040091 { get; set; }
        public decimal F60041091 { get; set; }
        [DisplayName("Primes liees au capital en fin d'exercice")]
        public decimal F60040092 { get; set; }
        public decimal F60041092 { get; set; }
        [DisplayName("Augmentations du capital durant l'exercice ")]
        public decimal F60040093 { get; set; }
        public decimal F60041093 { get; set; }
        [DisplayName("Conversion de dettes en capital durant l'exercice ")]
        public decimal F60040094 { get; set; }
        public decimal F60041094 { get; set; }
        [DisplayName("Capital en debut d'exercice")]
        public decimal F60040095 { get; set; }
        public decimal F60041095 { get; set; }
        [DisplayName("Primes liees au capital en debut d'exercice")]
        public decimal F60040096 { get; set; }
        public decimal F60041096 { get; set; }
        [DisplayName("Dividendes at autres distributions")]
        public decimal F60040097 { get { return F60040098  +  F60040099  +  F60040100  +  F60040101  -  F60040102; } }
        public decimal F60041097 { get { return F60041098 + F60041099 + F60041100 + F60041101 - F60041102; } }
        [DisplayName("Dividendes dus aux actionnaires en debut d'exercice")]
        public decimal F60040098 { get; set; }
        public decimal F60041098 { get; set; }
        [DisplayName("Dividendes attribues en (N)")]
        public decimal F60040099 { get; set; }
        public decimal F60041099 { get; set; }
        [DisplayName("Prelevements sur les reserves en (N)")]
        public decimal F60040100 { get; set; }
        public decimal F60041100 { get; set; }
        [DisplayName("Rachat d'actions et autres reductions de capital (non motivees par des pertes ou modif.Comptable) en (N)")]
        public decimal F60040101 { get; set; }
        public decimal F60041101 { get; set; }
        [DisplayName("Dividendes dus aux actionnaires en fin d�exercice ")]
        public decimal F60040102 { get; set; }
        public decimal F60041102 { get; set; }
        [DisplayName("Encaissements/remboursements d'emprunts")]
        public decimal F60040103 {
            get { return F60040104  +  F60040105  -  F60040106  -  F60040107; } }
        public decimal F60041103 { get { return F60041104 + F60041105 - F60041106 - F60041107; } }
        [DisplayName("S.C. (Emprunts et dettes assimilees) en fin d'exercice")]
        public decimal F60040104 { get; set; }
        public decimal F60041104 { get; set; }
        [DisplayName("S.C. (Emprunts courants) en fin d'exercice")]
        public decimal F60040105 { get; set; }
        public decimal F60041105 { get; set; }
        [DisplayName("S.C. (Emprunts et dettes assimilees) en debut d'exercice")]
        public decimal F60040106 { get; set; }
        public decimal F60041106 { get; set; }
        [DisplayName("S.C. (Emprunts courants) en debut d'exercice")]
        public decimal F60040107 { get; set; }
        public decimal F60041107 { get; set; }
        [DisplayName("Decaissements/remboursements de prets et des placements ")]
        public decimal F60040108 { get { return F60040109  +  F60040110  -  F60040111  -  F60040112; } }
        public decimal F60041108 { get { return F60041109 + F60041110 - F60041111 - F60041112; } }
        [DisplayName("S.D.(Prets et Creances Fin. courants) en fin d'exercice")]
        public decimal F60040109 { get; set; }
        public decimal F60041109 { get; set; }
        [DisplayName("S.D. (Placements Courants) en fin d'exercice ")]
        public decimal F60040110 { get; set; }
        public decimal F60041110 { get; set; }
        [DisplayName("S.D.(Prets et Creances Fin. courants) en debut d'exercice")]
        public decimal F60040111 { get; set; }
        public decimal F60041111 { get; set; }
        [DisplayName("S.D. (Placements Courants) en debut d'exercice")]
        public decimal F60040112 { get; set; }
        public decimal F60041112 { get; set; }
        [DisplayName("Incidences des variations des taux de change/les liquidites et equiv.")]
        public decimal F60040113 { get; set; }
        public decimal F60041113 { get; set; }
        [DisplayName("Autres Postes des Flux de Tresorerie")]
        public decimal F60040114 { get; set; }
        public decimal F60041114 { get; set; }
        [DisplayName("Variation de Tresorerie")]
        public decimal F60040115 { get { return F60040001  +  F60040058  +  F60040089  +  F60040113  +  F60040114; } }
        public decimal F60041115 { get { return F60041001 + F60041058 + F60041089 + F60041113 + F60041114; } }
        [DisplayName("Tresorerie au debut de la periode")]
        public decimal F60040116 { get; set; }public decimal F60041116 { get; set; }
        [DisplayName("Tresorerie a la cloture de la periode")]
        public decimal F60040117 { get; set; }
        public decimal F60041117 { get; set; }

        public List<string> getError()
        {
            List<string> msg = new List<string>();

            if (F60040001 != (F60040002 - F60040012 - F60040023 - F60040032 - F60040045))
                msg.Add("F60040001 est  invalide ! F60040001 = F60040002 - F60040012 - F60040023 - F60040032 - F60040045 ");

            if (F60040002 != (F60040003 - F60040004 + F60040005 + F60040006 - F60040007 + F60040008 - F60040009 - F60040010 + F60040011))
                msg.Add("F60040002 est  invalide ! F60040002 = F60040003 - F60040004 + F60040005 + F60040006 - F60040007 + F60040008 - F60040009 - F60040010 + F60040011 ");

            if (F60040012 != (F60040013 - F60040014 + F60040015 + F60040016 + F60040017 - F60040018 + F60040019 - F60040020 + F60040021 - F60040022))
                msg.Add("F60040012 est  invalide ! F60040012 = F60040013 - F60040014 + F60040015 + F60040016 + F60040017 - F60040018 + F60040019 - F60040020 + F60040021 - F60040022 ");

            if (F60040023 != (F60040024 - F60040025 + F60040026 + F60040027 + F60040028 - F60040029 + F60040030 + F60040031))
                msg.Add("F60040023 est  invalide ! F60040023 = F60040024 - F60040025 + F60040026 + F60040027 + F60040028 - F60040029 + F60040030 + F60040031");

            if (F60040032 != (F60040033 - F60040034 + F60040035 + F60040036 + F60040037 - F60040038 - F60040039 - F60040040 + F60040041 - F60040042 + F60040043 - F60040044))
                msg.Add("F60040032 est  invalide ! F60040032 = F60040033 - F60040034 + F60040035 + F60040036 + F60040037 - F60040038 - F60040039 - F60040040 + F60040041 - F60040042 + F60040043 - F60040044");

            if (F60040045 != (F60040046 - F60040047 - F60040048 + F60040049 + F60040050 + F60040051 - F60040052 + F60040053 + F60040054 - F60040055 + F60040056 + F60040057))
                msg.Add("F60040045 est  invalide ! F60040045 = F60040046 - F60040047 - F60040048 + F60040049 + F60040050 + F60040051 - F60040052 + F60040053 + F60040054 - F60040055 + F60040056 + F60040057");


            if (F60040058 != (F60040066 - F60040080 + F60040084 - F60040059))
                msg.Add("F60040058 est  invalide ! F60040058 = F60040066 - F60040080 + F60040084 - F60040059");

            if (F60040059 != (F60040060 + F60040061 + F60040062 + F60040063 - F60040064 - F60040065))
                msg.Add("F60040059 est  invalide ! F60040059 = F60040060 + F60040061 + F60040062 + F60040063 - F60040064 - F60040065");

            if (F60040066 != (F60040067 + F60040068 - F60040069 - F60040070 + F60040071 - F60040072 - F60040073 + F60040074 - F60040075 - F60040076 + F60040077 + F60040078 - F60040079))
                msg.Add("F60040066 est  invalide ! F60040066 = F60040067 + F60040068 - F60040069 - F60040070 + F60040071 - F60040072 - F60040073 + F60040074 - F60040075 - F60040076 + F60040077 + F60040078 - F60040079");

            if (F60040080 != (F60040081 + F60040082 - F60040083))
                msg.Add("F60040080 est  invalide ! F60040080 = F60040081 + F60040082 - F60040083");

            if (F60040084 != (F60040085 + F60040086 + F60040087 - F60040088))
                msg.Add("F60040084 est  invalide ! F60040084 = F60040085 + F60040086 + F60040087 - F60040088");

            if (F60040089 != (F60040090 - F60040097 + F60040103 - F60040108))
                msg.Add("F60040089 est  invalide ! F60040089 = F60040090 - F60040097 + F60040103 - F60040108");

            if (F60040090 != (F60040091 + F60040092 - F60040093 - F60040094 - F60040095 - F60040096))
                msg.Add("F60040090 est  invalide ! F60040090 = F60040091 + F60040092 - F60040093 - F60040094 - F60040095 - F60040096");

            if (F60040097 != (F60040098 + F60040099 + F60040100 + F60040101 - F60040102))
                msg.Add("F60040097 est  invalide ! F60040097 = F60040098 + F60040099 + F60040100 + F60040101 - F60040102");

            if (F60040103 != (F60040104 + F60040105 - F60040106 - F60040107))
                msg.Add("F60040103 est  invalide ! F60040103 = F60040104 + F60040105 - F60040106 - F60040107");

            if (F60040108 != (F60040109 + F60040110 - F60040111 - F60040112))
                msg.Add("F60040108 est  invalide ! F60040108 = F60040109 + F60040110 - F60040111 - F60040112");

            if (F60040115 != (F60040001 + F60040058 + F60040089 + F60040113 + F60040114))
                msg.Add("F60040115 est  invalide ! F60040115 = F60040001 + F60040058 + F60040089 + F60040113 + F60040114");

            if (F60041001 != (F60041002 - F60041012 - F60041023 - F60041032 - F60041045))
                msg.Add("F60041001 est  invalide ! F60041001 = F60041002 - F60041012 - F60041023 - F60041032 - F60041045");

            if (F60041002 != (F60041003 - F60041004 + F60041005 + F60041006 - F60041007 + F60041008 - F60041009 - F60041010 + F60041011))
                msg.Add("F60041002 est  invalide ! F60041002 = F60041003 - F60041004 + F60041005 + F60041006 - F60041007 + F60041008 - F60041009 - F60041010 + F60041011");

            if (F60041012 != (F60041013 - F60041014 + F60041015 + F60041016 + F60041017 - F60041018 + F60041019 - F60041020 + F60041021 - F60041022))
                msg.Add("F60041012 est  invalide ! F60041012 = F60041013 - F60041014 + F60041015 + F60041016 + F60041017 - F60041018 + F60041019 - F60041020 + F60041021 - F60041022");

            if (F60041023 != (F60041024 - F60041025 + F60041026 + F60041027 + F60041028 - F60041029 + F60041030 + F60041031))
                msg.Add("F60041023 est  invalide ! F60041023 =F60041024 - F60041025 + F60041026 + F60041027 + F60041028 - F60041029 + F60041030 + F60041031");

            if (F60041032 != (F60041033 - F60041034 + F60041035 + F60041036 + F60041037 - F60041038 - F60041039 - F60041040 + F60041041 - F60041042 + F60041043 - F60041044))
                msg.Add("F60041032 est  invalide ! F60041032 = F60041033 - F60041034 + F60041035 + F60041036 + F60041037 - F60041038 - F60041039 - F60041040 + F60041041 - F60041042 + F60041043 - F60041044");


            if (F60041045 != (F60041046 - F60041047 - F60041048 + F60041049 + F60041050 + F60041051 - F60041052 + F60041053 + F60041054 - F60041055 + F60041056 + F60041057))
                msg.Add("F60041045 est  invalide ! F60041045 = F60041046 - F60041047 - F60041048 + F60041049 + F60041050 + F60041051 - F60041052 + F60041053 + F60041054 - F60041055 + F60041056 + F60041057");

            if (F60041058 != (F60041066 - F60041080 + F60041084 - F60041059))
                msg.Add("F60041058 est  invalide ! F60041058 = F60041066 - F60041080 + F60041084 - F60041059");

            if (F60041059 != (F60041060 + F60041061 + F60041062 + F60041063 - F60041064 - F60041065))
                msg.Add("F60041059 est  invalide ! F60041059 = F60041060 + F60041061 + F60041062 + F60041063 - F60041064 - F60041065");

            if (F60041066 != (F60041067 + F60041068 - F60041069 - F60041070 + F60041071 - F60041072 - F60041073 + F60041074 - F60041075 - F60041076 + F60041077 + F60041078 - F60041079))
                msg.Add("F60041066 est  invalide ! F60041066 = F60041067 + F60041068 - F60041069 - F60041070 + F60041071 - F60041072 - F60041073 + F60041074 - F60041075 - F60041076 + F60041077 + F60041078 - F60041079");


            if (F60041080 != (F60041081 + F60041082 - F60041083))
                msg.Add("F60041080 est  invalide ! F60041080 = F60041081 + F60041082 - F60041083");

            if (F60041084 != (F60041085 + F60041086 + F60041087 - F60041088))
                msg.Add("F60041084 est  invalide ! F60041084 = F60041085 + F60041086 + F60041087 - F60041088");

            if (F60041089 != (F60041090 - F60041097 + F60041103 - F60041108))
                msg.Add("F60041089 est  invalide ! F60041089 = F60041090 - F60041097 + F60041103 - F60041108");


            if (F60041090 != (F60041091 + F60041092 - F60041093 - F60041094 - F60041095 - F60041096))
                msg.Add("F60041090 est  invalide ! F60041090 = F60041091 + F60041092 - F60041093 - F60041094 - F60041095 - F60041096 ");

            if (F60041097 != (F60041098 + F60041099 + F60041100 + F60041101 - F60041102))
                msg.Add("F60041097 est  invalide ! F60041097 = F60041098 + F60041099 + F60041100 + F60041101 - F60041102 ");

            if (F60041103 != (F60041104 + F60041105 - F60041106 - F60041107))
                msg.Add("F60041103 est  invalide ! F60041103 = F60041104 + F60041105 - F60041106 - F60041107 ");

            if (F60041108 != (F60041109 + F60041110 - F60041111 - F60041112))
                msg.Add("F60041108 est  invalide ! F60041108 = F60041109 + F60041110 - F60041111 - F60041112 ");

            if (F60041115 != (F60041001 + F60041058 + F60041089 + F60041113 + F60041114))
                msg.Add("F60041115 est  invalide ! F60041115 = F60041001 + F60041058 + F60041089 + F60041113 + F60041114 ");



            return msg;
        }

        public string ToXML(Models.Societe ste, Models.Exercice ex)
        {
            // Models.Societe sos = TVS.
            string r = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
<?xml-stylesheet type=""text/xsl"" href=""F6003.xsl""?>
<lf:F6004 xmlns:lf=""http://www.impots.finances.gov.tn/liasse"" xmlns:vc=""http://www.w3.org/2007/XMLSchema-versioning"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://www.impots.finances.gov.tn/liasse F6004.xsd"">
	<lf:VersionDocument>String</lf:VersionDocument>
	<lf:Entete>
		<lf:MatriculeFiscalDeclarant>{ste.MatriculFiscal}{ste.MatriculCle}{ste.MatriculCodeTva}{ste.MatriculCategorie}{ste.MatriculEtablissement}</lf:MatriculeFiscalDeclarant>
		<lf:NometPrenomouRaisonSociale>{ste.RaisonSocial}</lf:NometPrenomouRaisonSociale>
		<lf:Activite>{ste.Activite}</lf:Activite>
		<lf:Adresse>{ste.Adresse}</lf:Adresse>
		<lf:Exercice>{ex.Annee}</lf:Exercice>
		<lf:DateDebutExercice>01/01/{ex.Annee}</lf:DateDebutExercice>
		<lf:DateClotureExercice>31/12/{ex.Annee}</lf:DateClotureExercice>
		<lf:ActeDeDepot>{this.ActeDeDepot}</lf:ActeDeDepot>
		<lf:NatureDepot>{this.NatureDepot}</lf:NatureDepot>
	</lf:Entete>
    <lf:Details>
        <lf:F60040001>{this.F60040001 * 1000:0}</lf:F60040001>
        <lf:F60040002>{this.F60040002 * 1000:0}</lf:F60040002>
        <lf:F60040003>{this.F60040003 * 1000:0}</lf:F60040003>
        <lf:F60040004>{this.F60040004 * 1000:0}</lf:F60040004>
        <lf:F60040005>{this.F60040005 * 1000:0}</lf:F60040005>
        <lf:F60040006>{this.F60040006 * 1000:0}</lf:F60040006>
        <lf:F60040007>{this.F60040007 * 1000:0}</lf:F60040007>
        <lf:F60040008>{this.F60040008 * 1000:0}</lf:F60040008>
        <lf:F60040009>{this.F60040009 * 1000:0}</lf:F60040009>
        <lf:F60040010>{this.F60040010 * 1000:0}</lf:F60040010>
        <lf:F60040011>{this.F60040011 * 1000:0}</lf:F60040011>
        <lf:F60040012>{this.F60040012 * 1000:0}</lf:F60040012>
        <lf:F60040013>{this.F60040013 * 1000:0}</lf:F60040013>
        <lf:F60040014>{this.F60040014 * 1000:0}</lf:F60040014>
        <lf:F60040015>{this.F60040015 * 1000:0}</lf:F60040015>
        <lf:F60040016>{this.F60040016 * 1000:0}</lf:F60040016>
        <lf:F60040017>{this.F60040017 * 1000:0}</lf:F60040017>
        <lf:F60040018>{this.F60040018 * 1000:0}</lf:F60040018>
        <lf:F60040019>{this.F60040019 * 1000:0}</lf:F60040019>
        <lf:F60040020>{this.F60040020 * 1000:0}</lf:F60040020>
        <lf:F60040021>{this.F60040021 * 1000:0}</lf:F60040021>
        <lf:F60040022>{this.F60040022 * 1000:0}</lf:F60040022>
        <lf:F60040023>{this.F60040023 * 1000:0}</lf:F60040023>
        <lf:F60040024>{this.F60040024 * 1000:0}</lf:F60040024>
        <lf:F60040025>{this.F60040025 * 1000:0}</lf:F60040025>
        <lf:F60040026>{this.F60040026 * 1000:0}</lf:F60040026>
        <lf:F60040027>{this.F60040027 * 1000:0}</lf:F60040027>
        <lf:F60040028>{this.F60040028 * 1000:0}</lf:F60040028>
        <lf:F60040029>{this.F60040029 * 1000:0}</lf:F60040029>
        <lf:F60040030>{this.F60040030 * 1000:0}</lf:F60040030>
        <lf:F60040031>{this.F60040031 * 1000:0}</lf:F60040031>
        <lf:F60040032>{this.F60040032 * 1000:0}</lf:F60040032>
        <lf:F60040033>{this.F60040033 * 1000:0}</lf:F60040033>
        <lf:F60040034>{this.F60040034 * 1000:0}</lf:F60040034>
        <lf:F60040035>{this.F60040035 * 1000:0}</lf:F60040035>
        <lf:F60040036>{this.F60040036 * 1000:0}</lf:F60040036>
        <lf:F60040037>{this.F60040037 * 1000:0}</lf:F60040037>
        <lf:F60040038>{this.F60040038 * 1000:0}</lf:F60040038>
        <lf:F60040039>{this.F60040039 * 1000:0}</lf:F60040039>
        <lf:F60040040>{this.F60040040 * 1000:0}</lf:F60040040>
        <lf:F60040041>{this.F60040041 * 1000:0}</lf:F60040041>
        <lf:F60040042>{this.F60040042 * 1000:0}</lf:F60040042>
        <lf:F60040043>{this.F60040043 * 1000:0}</lf:F60040043>
        <lf:F60040044>{this.F60040044 * 1000:0}</lf:F60040044>
        <lf:F60040045>{this.F60040045 * 1000:0}</lf:F60040045>
        <lf:F60040046>{this.F60040046 * 1000:0}</lf:F60040046>
        <lf:F60040047>{this.F60040047 * 1000:0}</lf:F60040047>
        <lf:F60040048>{this.F60040048 * 1000:0}</lf:F60040048>
        <lf:F60040049>{this.F60040049 * 1000:0}</lf:F60040049>
        <lf:F60040050>{this.F60040050 * 1000:0}</lf:F60040050>
        <lf:F60040051>{this.F60040051 * 1000:0}</lf:F60040051>
        <lf:F60040052>{this.F60040052 * 1000:0}</lf:F60040052>
        <lf:F60040053>{this.F60040053 * 1000:0}</lf:F60040053>
        <lf:F60040054>{this.F60040054 * 1000:0}</lf:F60040054>
		<lf:F60040055>{this.F60040055 * 1000:0}</lf:F60040055>
        <lf:F60040056>{this.F60040056 * 1000:0}</lf:F60040056>
        <lf:F60040057>{this.F60040057 * 1000:0}</lf:F60040057>
        <lf:F60040058>{this.F60040058 * 1000:0}</lf:F60040058>
        <lf:F60040059>{this.F60040059 * 1000:0}</lf:F60040059>
        <lf:F60040060>{this.F60040060 * 1000:0}</lf:F60040060>
        <lf:F60040061>{this.F60040061 * 1000:0}</lf:F60040061>
        <lf:F60040062>{this.F60040062 * 1000:0}</lf:F60040062>
        <lf:F60040063>{this.F60040063 * 1000:0}</lf:F60040063>
        <lf:F60040064>{this.F60040064 * 1000:0}</lf:F60040064>
        <lf:F60040065>{this.F60040065 * 1000:0}</lf:F60040065>
        <lf:F60040066>{this.F60040066 * 1000:0}</lf:F60040066>
        <lf:F60040067>{this.F60040067 * 1000:0}</lf:F60040067>
        <lf:F60040068>{this.F60040068 * 1000:0}</lf:F60040068>
        <lf:F60040069>{this.F60040069 * 1000:0}</lf:F60040069>
        <lf:F60040070>{this.F60040070 * 1000:0}</lf:F60040070>
        <lf:F60040071>{this.F60040071 * 1000:0}</lf:F60040071>
        <lf:F60040072>{this.F60040072 * 1000:0}</lf:F60040072>
        <lf:F60040073>{this.F60040073 * 1000:0}</lf:F60040073>
        <lf:F60040074>{this.F60040074 * 1000:0}</lf:F60040074>
        <lf:F60040075>{this.F60040075 * 1000:0}</lf:F60040075>
        <lf:F60040076>{this.F60040076 * 1000:0}</lf:F60040076>
        <lf:F60040077>{this.F60040077 * 1000:0}</lf:F60040077>
        <lf:F60040078>{this.F60040078 * 1000:0}</lf:F60040078>
        <lf:F60040079>{this.F60040079 * 1000:0}</lf:F60040079>
        <lf:F60040080>{this.F60040080 * 1000:0}</lf:F60040080>
        <lf:F60040081>{this.F60040081 * 1000:0}</lf:F60040081>
        <lf:F60040082>{this.F60040082 * 1000:0}</lf:F60040082>
        <lf:F60040083>{this.F60040083 * 1000:0}</lf:F60040083>
        <lf:F60040084>{this.F60040084 * 1000:0}</lf:F60040084>
        <lf:F60040085>{this.F60040085 * 1000:0}</lf:F60040085>
        <lf:F60040086>{this.F60040086 * 1000:0}</lf:F60040086>
        <lf:F60040087>{this.F60040087 * 1000:0}</lf:F60040087>
        <lf:F60040088>{this.F60040088 * 1000:0}</lf:F60040088>
        <lf:F60040089>{this.F60040089 * 1000:0}</lf:F60040089>
        <lf:F60040090>{this.F60040090 * 1000:0}</lf:F60040090>
        <lf:F60040091>{this.F60040091 * 1000:0}</lf:F60040091>
        <lf:F60040092>{this.F60040092 * 1000:0}</lf:F60040092>
        <lf:F60040093>{this.F60040093 * 1000:0}</lf:F60040093>
        <lf:F60040094>{this.F60040094 * 1000:0}</lf:F60040094>
        <lf:F60040095>{this.F60040095 * 1000:0}</lf:F60040095>
        <lf:F60040096>{this.F60040096 * 1000:0}</lf:F60040096>
        <lf:F60040097>{this.F60040097 * 1000:0}</lf:F60040097>
        <lf:F60040098>{this.F60040098 * 1000:0}</lf:F60040098>
        <lf:F60040099>{this.F60040099 * 1000:0}</lf:F60040099>
        <lf:F60040100>{this.F60040100 * 1000:0}</lf:F60040100>
        <lf:F60040101>{this.F60040101 * 1000:0}</lf:F60040101>
        <lf:F60040102>{this.F60040102 * 1000:0}</lf:F60040102>
        <lf:F60040103>{this.F60040103 * 1000:0}</lf:F60040103>
        <lf:F60040104>{this.F60040104 * 1000:0}</lf:F60040104>
        <lf:F60040105>{this.F60040105 * 1000:0}</lf:F60040105>
        <lf:F60040106>{this.F60040106 * 1000:0}</lf:F60040106>
        <lf:F60040107>{this.F60040107 * 1000:0}</lf:F60040107>
        <lf:F60040108>{this.F60040108 * 1000:0}</lf:F60040108>
        <lf:F60040109>{this.F60040109 * 1000:0}</lf:F60040109>
        <lf:F60040110>{this.F60040110 * 1000:0}</lf:F60040110>		   
        <lf:F60040111>{this.F60040111 * 1000:0}</lf:F60040111>
        <lf:F60040112>{this.F60040112 * 1000:0}</lf:F60040112>
        <lf:F60040113>{this.F60040113 * 1000:0}</lf:F60040113>
        <lf:F60040114>{this.F60040114 * 1000:0}</lf:F60040114>
        <lf:F60040115>{this.F60040115 * 1000:0}</lf:F60040115>
        <lf:F60040116>{this.F60040116 * 1000:0}</lf:F60040116>
        <lf:F60040117>{this.F60040117 * 1000:0}</lf:F60040117>
		    <lf:F60041001>{this.F60041001 * 1000:0}</lf:F60041001>
        <lf:F60041002>{this.F60041002 * 1000:0}</lf:F60041002>
        <lf:F60041003>{this.F60041003 * 1000:0}</lf:F60041003>
        <lf:F60041004>{this.F60041004 * 1000:0}</lf:F60041004>
        <lf:F60041005>{this.F60041005 * 1000:0}</lf:F60041005>
        <lf:F60041006>{this.F60041006 * 1000:0}</lf:F60041006>
        <lf:F60041007>{this.F60041007 * 1000:0}</lf:F60041007>
        <lf:F60041008>{this.F60041008 * 1000:0}</lf:F60041008>
        <lf:F60041009>{this.F60041009 * 1000:0}</lf:F60041009>
        <lf:F60041010>{this.F60041010 * 1000:0}</lf:F60041010>
        <lf:F60041011>{this.F60041011 * 1000:0}</lf:F60041011>
        <lf:F60041012>{this.F60041012 * 1000:0}</lf:F60041012>
        <lf:F60041013>{this.F60041013 * 1000:0}</lf:F60041013>
        <lf:F60041014>{this.F60041014 * 1000:0}</lf:F60041014>
        <lf:F60041015>{this.F60041015 * 1000:0}</lf:F60041015>
        <lf:F60041016>{this.F60041016 * 1000:0}</lf:F60041016>
        <lf:F60041017>{this.F60041017 * 1000:0}</lf:F60041017>
        <lf:F60041018>{this.F60041018 * 1000:0}</lf:F60041018>
        <lf:F60041019>{this.F60041019 * 1000:0}</lf:F60041019>
        <lf:F60041020>{this.F60041020 * 1000:0}</lf:F60041020>
        <lf:F60041021>{this.F60041021 * 1000:0}</lf:F60041021>
        <lf:F60041022>{this.F60041022 * 1000:0}</lf:F60041022>
        <lf:F60041023>{this.F60041023 * 1000:0}</lf:F60041023>
        <lf:F60041024>{this.F60041024 * 1000:0}</lf:F60041024>
        <lf:F60041025>{this.F60041025 * 1000:0}</lf:F60041025>
        <lf:F60041026>{this.F60041026 * 1000:0}</lf:F60041026>
        <lf:F60041027>{this.F60041027 * 1000:0}</lf:F60041027>
        <lf:F60041028>{this.F60041028 * 1000:0}</lf:F60041028>
        <lf:F60041029>{this.F60041029 * 1000:0}</lf:F60041029>
        <lf:F60041030>{this.F60041030 * 1000:0}</lf:F60041030>
        <lf:F60041031>{this.F60041031 * 1000:0}</lf:F60041031>
        <lf:F60041032>{this.F60041032 * 1000:0}</lf:F60041032>
        <lf:F60041033>{this.F60041033 * 1000:0}</lf:F60041033>
        <lf:F60041034>{this.F60041034 * 1000:0}</lf:F60041034>
        <lf:F60041035>{this.F60041035 * 1000:0}</lf:F60041035>
        <lf:F60041036>{this.F60041036 * 1000:0}</lf:F60041036>
        <lf:F60041037>{this.F60041037 * 1000:0}</lf:F60041037>
        <lf:F60041038>{this.F60041038 * 1000:0}</lf:F60041038>
        <lf:F60041039>{this.F60041039 * 1000:0}</lf:F60041039>
        <lf:F60041040>{this.F60041040 * 1000:0}</lf:F60041040>
        <lf:F60041041>{this.F60041041 * 1000:0}</lf:F60041041>
        <lf:F60041042>{this.F60041042 * 1000:0}</lf:F60041042>
        <lf:F60041043>{this.F60041043 * 1000:0}</lf:F60041043>
        <lf:F60041044>{this.F60041044 * 1000:0}</lf:F60041044>
        <lf:F60041045>{this.F60041045 * 1000:0}</lf:F60041045>
        <lf:F60041046>{this.F60041046 * 1000:0}</lf:F60041046>
        <lf:F60041047>{this.F60041047 * 1000:0}</lf:F60041047>
        <lf:F60041048>{this.F60041048 * 1000:0}</lf:F60041048>
        <lf:F60041049>{this.F60041049 * 1000:0}</lf:F60041049>
        <lf:F60041050>{this.F60041050 * 1000:0}</lf:F60041050>
        <lf:F60041051>{this.F60041051 * 1000:0}</lf:F60041051>
        <lf:F60041052>{this.F60041052 * 1000:0}</lf:F60041052>
        <lf:F60041053>{this.F60041053 * 1000:0}</lf:F60041053>
        <lf:F60041054>{this.F60041054 * 1000:0}</lf:F60041054>
		<lf:F60041055>{this.F60041055 * 1000:0}</lf:F60041055>
        <lf:F60041056>{this.F60041056 * 1000:0}</lf:F60041056>
        <lf:F60041057>{this.F60041057 * 1000:0}</lf:F60041057>
        <lf:F60041058>{this.F60041058 * 1000:0}</lf:F60041058>
        <lf:F60041059>{this.F60041059 * 1000:0}</lf:F60041059>
        <lf:F60041060>{this.F60041060 * 1000:0}</lf:F60041060>
        <lf:F60041061>{this.F60041061 * 1000:0}</lf:F60041061>
        <lf:F60041062>{this.F60041062 * 1000:0}</lf:F60041062>
        <lf:F60041063>{this.F60041063 * 1000:0}</lf:F60041063>
        <lf:F60041064>{this.F60041064 * 1000:0}</lf:F60041064>
        <lf:F60041065>{this.F60041065 * 1000:0}</lf:F60041065>
        <lf:F60041066>{this.F60041066 * 1000:0}</lf:F60041066>
        <lf:F60041067>{this.F60041067 * 1000:0}</lf:F60041067>
        <lf:F60041068>{this.F60041068 * 1000:0}</lf:F60041068>
        <lf:F60041069>{this.F60041069 * 1000:0}</lf:F60041069>
        <lf:F60041070>{this.F60041070 * 1000:0}</lf:F60041070>
        <lf:F60041071>{this.F60041071 * 1000:0}</lf:F60041071>
        <lf:F60041072>{this.F60041072 * 1000:0}</lf:F60041072>
        <lf:F60041073>{this.F60041073 * 1000:0}</lf:F60041073>
        <lf:F60041074>{this.F60041074 * 1000:0}</lf:F60041074>
        <lf:F60041075>{this.F60041075 * 1000:0}</lf:F60041075>
        <lf:F60041076>{this.F60041076 * 1000:0}</lf:F60041076>
        <lf:F60041077>{this.F60041077 * 1000:0}</lf:F60041077>
        <lf:F60041078>{this.F60041078 * 1000:0}</lf:F60041078>
        <lf:F60041079>{this.F60041079 * 1000:0}</lf:F60041079>
        <lf:F60041080>{this.F60041080 * 1000:0}</lf:F60041080>
        <lf:F60041081>{this.F60041081 * 1000:0}</lf:F60041081>
        <lf:F60041082>{this.F60041082 * 1000:0}</lf:F60041082>
        <lf:F60041083>{this.F60041083 * 1000:0}</lf:F60041083>
        <lf:F60041084>{this.F60041084 * 1000:0}</lf:F60041084>
        <lf:F60041085>{this.F60041085 * 1000:0}</lf:F60041085>
        <lf:F60041086>{this.F60041086 * 1000:0}</lf:F60041086>
        <lf:F60041087>{this.F60041087 * 1000:0}</lf:F60041087>
        <lf:F60041088>{this.F60041088 * 1000:0}</lf:F60041088>
        <lf:F60041089>{this.F60041089 * 1000:0}</lf:F60041089>
        <lf:F60041090>{this.F60041090 * 1000:0}</lf:F60041090>
        <lf:F60041091>{this.F60041091 * 1000:0}</lf:F60041091>
        <lf:F60041092>{this.F60041092 * 1000:0}</lf:F60041092>
        <lf:F60041093>{this.F60041093 * 1000:0}</lf:F60041093>
        <lf:F60041094>{this.F60041094 * 1000:0}</lf:F60041094>
        <lf:F60041095>{this.F60041095 * 1000:0}</lf:F60041095>
        <lf:F60041096>{this.F60041096 * 1000:0}</lf:F60041096>
        <lf:F60041097>{this.F60041097 * 1000:0}</lf:F60041097>
        <lf:F60041098>{this.F60041098 * 1000:0}</lf:F60041098>
        <lf:F60041099>{this.F60041099 * 1000:0}</lf:F60041099>
        <lf:F60041100>{this.F60041100 * 1000:0}</lf:F60041100>
        <lf:F60041101>{this.F60041101 * 1000:0}</lf:F60041101>
        <lf:F60041102>{this.F60041102 * 1000:0}</lf:F60041102>
        <lf:F60041103>{this.F60041103 * 1000:0}</lf:F60041103>
        <lf:F60041104>{this.F60041104 * 1000:0}</lf:F60041104>
        <lf:F60041105>{this.F60041105 * 1000:0}</lf:F60041105>
        <lf:F60041106>{this.F60041106 * 1000:0}</lf:F60041106>
        <lf:F60041107>{this.F60041107 * 1000:0}</lf:F60041107>
        <lf:F60041108>{this.F60041108 * 1000:0}</lf:F60041108>
        <lf:F60041109>{this.F60041109 * 1000:0}</lf:F60041109>
        <lf:F60041110>{this.F60041110 * 1000:0}</lf:F60041110>		   
        <lf:F60041111>{this.F60041111 * 1000:0}</lf:F60041111>
        <lf:F60041112>{this.F60041112 * 1000:0}</lf:F60041112>
        <lf:F60041113>{this.F60041113 * 1000:0}</lf:F60041113>
        <lf:F60041114>{this.F60041114 * 1000:0}</lf:F60041114>
        <lf:F60041115>{this.F60041115 * 1000:0}</lf:F60041115>
        <lf:F60041116>{this.F60041116 * 1000:0}</lf:F60041116>
        <lf:F60041117>{this.F60041117 * 1000:0}</lf:F60041117>
    </lf:Details>
</lf:F6004>";
            return r;
        }
    }
}
