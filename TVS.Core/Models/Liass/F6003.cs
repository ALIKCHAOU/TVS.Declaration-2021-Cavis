using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Core.Models.Liass
{
    public partial class F6003
    {
        public int Id { get; set; }
        public int SocieteNo { get; set; }
        public int ExerciceId { get; set; }
        [DisplayName("Acte De Dépot")]
        public int ActeDeDepot { get; set; }
        [DisplayName("Nature Dépot")]
        public string NatureDepot { get; set; }

        [DisplayName("Produits d'Exploitation")]
        public decimal F60030001 { get { return F60030002 + F60030014 + F60030015; } }
        public decimal F60030090 { get { return F60030091  +  F60030103  +  F60030104; } }
        [DisplayName("Revenus")]
        public decimal F60030002 { get { return F60030003 + F60030006; } }
        public decimal F60030091 { get{ return F60030092  +  F60030095; } }
        [DisplayName("Ventes Nettes des Marchandises")]
        public decimal F60030003 { get { return F60030004 - F60030005; } }
        public decimal F60030092 { get{ return F60030093 - F60030094; } }
        [DisplayName("Ventes nettes des marchandises")]
        public decimal F60030004 { get; set; }
        public decimal F60030093 { get; set; }
        [DisplayName("Rabais, Remises et Ristournes (3R) accordés/ventes de Marchandises")]
        public decimal F60030005 { get; set; }
        public decimal F60030094 { get; set; }
        [DisplayName("Ventes Nettes de la Production")]
        public decimal F60030006 { get { return F60030007  +  F60030008  +  F60030009  +  F60030010  +  F60030011  +  F60030012  -  F60030013; } }
        public decimal F60030095 { get { return F60030096  +  F60030097  +  F60030098  +  F60030099  +  F60030100  +  F60030101   -  F60030102; } }
        [DisplayName("Ventes de Produits Finis")]
        public decimal F60030007 { get; set; }
        public decimal F60030096 { get; set; }
        [DisplayName("Ventes de Produits Intermédiaires")]
        public decimal F60030008 { get; set; }
        public decimal F60030097 { get; set; }
        [DisplayName("Ventes de Produits Résiduels")]
        public decimal F60030009 { get; set; }
        public decimal F60030098 { get; set; }
        [DisplayName("Ventes des Travaux")]
        public decimal F60030010 { get; set; }
        public decimal F60030099 { get; set; }
        [DisplayName("Ventes des Études et Prestations de Services")]
        public decimal F60030011 { get; set; }
        public decimal F60030100 { get; set; }
        [DisplayName("Produits des Activités Annexes")]
        public decimal F60030012 { get; set; }
        public decimal F60030101 { get; set; }
        [DisplayName("rabais Remises et ristournes (3R) accordés/ventes de la Production")]
        public decimal F60030013 { get; set; }
        public decimal F60030102 { get; set; }
        [DisplayName("Production Immobilisée")]
        public decimal F60030014 { get; set; }
        public decimal F60030103 { get; set; }
        [DisplayName("Autres Produits d'Exploitation")]
        public decimal F60030015 { get { return F60030016 + F60030017 + F60030018 + F60030019; } }
        public decimal F60030104 { get { return F60030105  +  F60030106  +  F60030107  +  F60030108; } }
        [DisplayName("Produits divers ordin°(sans gains/cession immo°)")]
        public decimal F60030016 { get; set; }
        public decimal F60030105 { get; set; }
        [DisplayName("Subventions d'exploitation et d'équilibre")]
        public decimal F60030017 { get; set; }
        public decimal F60030106 { get; set; }
        [DisplayName("Reprises sur amortissements et provisions")]
        public decimal F60030018 { get; set; }
        public decimal F60030107 { get; set; }
        [DisplayName("Transferts de charges")]
        public decimal F60030019 { get; set; }
        public decimal F60030108 { get; set; }
        [DisplayName("Charges d'exploitation")]
        public decimal F60030020 { get { return F60030021  +  F60030025  +  F60030029  +  F60030036  +  F60030046  +  F60030053; } }
        public decimal F60030109 { get { return F60030110  +  F60030114 + F60030118  +  F60030125  +  F60030135  +  F60030142; } }
        [DisplayName("Variation Stocks Produits Finis& Encours (en+ou-)")]
        public decimal F60030021
        {
            get
            { return F60030022 + F60030023 + F60030024;
            }
        }
        public decimal F60030110 { get
            { return F60030111 + F60030112 + F60030113;
            }
        }
        [DisplayName("Variations des en-cours de production biens")]
        public decimal F60030022 { get; set; }
        public decimal F60030111 { get; set; }
        [DisplayName("Variation des en-cours de production services")]
        public decimal F60030023 { get; set; }
        public decimal F60030112 { get; set; }
        [DisplayName("Variation des stocks de produits")]
        public decimal F60030024 { get; set; }
        public decimal F60030113 { get; set; }
        [DisplayName("Achats de Marchandises Consommés")]
        public decimal F60030025 { get {return F60030026 - F60030027 + F60030028;}}
        public decimal F60030114 { get { return F60030115  -  F60030116  +  F60030117; } }
        [DisplayName("Achats de marchandises")]
        public decimal F60030026 { get; set; }
        public decimal F60030115 { get; set; }
        [DisplayName("Rabais Remises et ristournes (3R) obtenus sur achats marchandises")]
        public decimal F60030027 { get; set; }
        public decimal F60030116 { get; set; }
        [DisplayName("Variation des stocks de marchandises")]
        public decimal F60030028 { get; set; }
        public decimal F60030117 { get; set; }
        [DisplayName("Achats d'Approvisionnements Consommés")]
        public decimal F60030029 { get { return F60030030 + F60030031 - F60030032 - F60030033 + F60030034 + F60030035; } }
        public decimal F60030118 { get { return F60030119  +  F60030120  -  F60030121  -  F60030122  +  F60030123  +  F60030124; } }
        [DisplayName("Achats stockés-Mat°Premières&Fournit° liées")]
        public decimal F60030030 { get; set; }
        public decimal F60030119 { get; set; }
        [DisplayName("Achats stockés - Autres approvisionnements")]
        public decimal F60030031 { get; set; }
        public decimal F60030120 { get; set; }
        [DisplayName("rabais Remises et ristournes (3R) obtenus/achats Mat°Premières&Fournit° liées")]
        public decimal F60030032 { get; set; }
        public decimal F60030121 { get; set; }
        [DisplayName("rabais Remises et ristournes (3R) obtenus/achats autres approvisionnements")]
        public decimal F60030033 { get; set; }
        public decimal F60030122 { get; set; }
        [DisplayName("Var°de stocks Mat°Premières&Fournitures")]
        public decimal F60030034 { get; set; }
        public decimal F60030123 { get; set; }
        [DisplayName("Var°de stocks des autres approvisionnements")]
        public decimal F60030035 { get; set; }
        public decimal F60030124 { get; set; }
        [DisplayName("Charges de Personnel")]
        public decimal F60030036 { get { return F60030037 + F60030038 + F60030039 + F60030040 + F60030041 + F60030042 + F60030043 + F60030044 + F60030045; } }
        public decimal F60030125 { get { return F60030126 + F60030127 + F60030128 + F60030129 + F60030130 + F60030131 + F60030132 + F60030133 + F60030134; } }
        [DisplayName("Salaires et compléments de salaires")]
        public decimal F60030037 { get; set; }
        public decimal F60030126 { get; set; }
        [DisplayName("Appointements&compléments d'appoint°")]
        public decimal F60030038 { get; set; }
        public decimal F60030127 { get; set; }
        [DisplayName("Indemnités représentatives de frais")]
        public decimal F60030039 { get; set; }
        public decimal F60030128 { get; set; }
        [DisplayName("Commissions au personnel")]
        public decimal F60030040 { get; set; }
        public decimal F60030129 { get; set; }
        [DisplayName("Rémun°des administrateurs, gérants&associés")]
        public decimal F60030041 { get; set; }
        public decimal F60030130 { get; set; }
        [DisplayName("Ch°connexes sal°, appoint°, comm°&rémun°")]
        public decimal F60030042 { get; set; }
        public decimal F60030131 { get; set; }
        [DisplayName("Charges sociales légales")]
        public decimal F60030043 { get; set; }
        public decimal F60030132 { get; set; }
        [DisplayName("Ch°PL/Modif°Compt°à imputer au Réslt de l'exerc°ou Activ°abandonnée")]
        public decimal F60030044 { get; set; }
        public decimal F60030133 { get; set; }
        [DisplayName("Autres charges de PL&autres charges sociales")]
        public decimal F60030045 { get; set; }
        public decimal F60030134 { get; set; }
        [DisplayName("Dotations aux Amortissements et aux Provisions ")]
        public decimal F60030046 { get { return F60030047 + F60030048 + F60030049 + F60030050 + F60030051 + F60030052; } }
        public decimal F60030135 { get { return F60030136  +  F60030137  +  F60030138  +  F60030139  +  F60030140  +  F60030141; } }
        [DisplayName("Dot°amort°&prov°-Ch°ord°(autres que Fin°)")]
        public decimal F60030047 { get; set; }
        public decimal F60030136 { get; set; }
        [DisplayName("Dot° aux résorptions des charges reportées")]
        public decimal F60030048 { get; set; }
        public decimal F60030137 { get; set; }
        [DisplayName("Dot° Prov° Risques&Charges d'exploitation")]
        public decimal F60030049 { get; set; }
        public decimal F60030138 { get; set; }
        [DisplayName("Dot°Prov°dépréc°immob° Incorp°&Corporelles")]
        public decimal F60030050 { get; set; }
        public decimal F60030139 { get; set; }
        [DisplayName("Dot°Prov°dépréc°actifs courants (autres que Val°Mobil°de Placem°&équiv° de liquidités)")]
        public decimal F60030051 { get; set; }
        public decimal F60030140 { get; set; }
        [DisplayName("Dot°aux amort°&prov°/Modif°Compt° à imputer au Réslt de l'exerc° ou Activ° abandonnée")]
        public decimal F60030052 { get; set; }
        public decimal F60030141 { get; set; }
        [DisplayName("Autres Charges d'Exploitation")]
        public decimal F60030053 { get { return F60030054  +  F60030055  +  F60030056  +  F60030057  +  F60030058  +  F60030059  +  F60030060; } }
        public decimal F60030142 { get { return F60030143  +  F60030144  +  F60030145  +  F60030146  +  F60030147  +  F60030148  +  F60030149; } }
        [DisplayName("Achats d’études&prestations services (y compris achat de sous-traitance production)")]
        public decimal F60030054 { get; set; }
        public decimal F60030143 { get; set; }
        [DisplayName("Achats de matériel, équipements et travaux")]
        public decimal F60030055 { get; set; }
        public decimal F60030144 { get; set; }
        [DisplayName("Achats non stockés non rattachés")]
        public decimal F60030056 { get; set; }
        public decimal F60030145 { get; set; }
        [DisplayName("Services extérieurs")]
        public decimal F60030057 { get; set; }
        public decimal F60030146 { get; set; }
        [DisplayName("Autres services extérieurs")]
        public decimal F60030058 { get; set; }
        public decimal F60030147 { get; set; }
        [DisplayName("Charges diverses ordinaires")]
        public decimal F60030059 { get; set; }
        public decimal F60030148 { get; set; }
        [DisplayName("Impôts, taxes et versements assimilés")]
        public decimal F60030060 { get; set; }
        public decimal F60030149 { get; set; }
        [DisplayName("Résultat d'Exploitation")]
        public decimal F60030061 { get { return F60030001 - F60030020; } }
        public decimal F60030150 { get { return F60030090 - F60030109; } }
        [DisplayName("Charges Financières Nettes")]
        public decimal F60030062
        {
            get { return F60030063 + F60030064; }
        }
        public decimal F60030151 { get { return F60030152 + F60030153; } }
        [DisplayName("Charges financières")]
        public decimal F60030063 { get; set; }
        public decimal F60030152 { get; set; }
        [DisplayName("Dot°amort°&provisions - charges financières")]
        public decimal F60030064 { get; set; }
        public decimal F60030153 { get; set; }
        [DisplayName("Produits des Placements")]
        public decimal F60030065 { get { return F60030066 + F60030067 + F60030068; } }
        public decimal F60030154 { get{ return F60030155 + F60030156 + F60030157; } }
        [DisplayName("Produits financiers")]
        public decimal F60030066 { get; set; }
        public decimal F60030155 { get; set; }
        [DisplayName("Reprise/prov°(à inscrire dans les pdts financ°)")]
        public decimal F60030067 { get; set; }
        public decimal F60030156 { get; set; }
        [DisplayName("Transferts de charges financières")]
        public decimal F60030068 { get; set; }
        public decimal F60030157 { get; set; }
        [DisplayName("Autres Gains Ordinaires")]
        public decimal F60030069 { get { return F60030070 + F60030071; } }
        public decimal F60030158 { get { return F60030159 + F60030160; } }
        [DisplayName("Produits nets sur cessions d'immobilisations")]
        public decimal F60030070 { get; set; }
        public decimal F60030159 { get; set; }
        [DisplayName("Autres gains/élém°non récurrents ou except°")]
        public decimal F60030071 { get; set; }
        public decimal F60030160 { get; set; }
        [DisplayName("Autres Pertes Ordinaires")]
        public decimal F60030072 { get { return F60030073 + F60030074 + F60030075; } }
        public decimal F60030161 { get { return F60030162 + F60030163 + F60030164; } }
        [DisplayName("Charges Nettes/cession immobilisations")]
        public decimal F60030073 { get; set; }
        public decimal F60030162 { get; set; }
        [DisplayName("Autres pertes/élém°non récurrents ou except°")]
        public decimal F60030074 { get; set; }
        public decimal F60030163 { get; set; }
        [DisplayName("Réduction de valeur")]
        public decimal F60030075 { get; set; }
        public decimal F60030164 { get; set; }
        [DisplayName("Résultat des Activités Ordinaires avant Impôt")]
        public decimal F60030076 { get { return F60030061  -  F60030062  +  F60030065  +  F60030069  -  F60030072; } }
        public decimal F60030165 { get { return F60030150 - F60030151 + F60030154 + F60030158 - F60030161; } }
        [DisplayName("Impôt sur les Bénéfices")]
        public decimal F60030077 { get { return F60030078 + F60030079; } }
        public decimal F60030166 { get { return F60030167 + F60030168; } }
        [DisplayName("Impôts/Bénéfices calculés/Résultat/activ°/ ord°")]
        public decimal F60030078 { get; set; }
        public decimal F60030167 { get; set; }
        [DisplayName("Autres impôts/Bénéfice (régimes particuliers)")]
        public decimal F60030079 { get; set; }
        public decimal F60030168 { get; set; }
        [DisplayName("Résultat des activités ordinaires après impôt")]
        public decimal F60030080 { get { return F60030076-F60030077; } }
        public decimal F60030169 { get { return F60030165 - F60030166; } }
        [DisplayName("Éléments Extraordinaires (Gains/Pertes)")]
        public decimal F60030081 { get { return F60030082 - F60030083; } }
        public decimal F60030170 { get { return F60030171 - F60030172; } }
        [DisplayName("Gains extraordinaires")]
        public decimal F60030082 { get; set; }
        public decimal F60030171 { get; set; }
        [DisplayName("Pertes extraordinaires")]
        public decimal F60030083 { get; set; }
        public decimal F60030172 { get; set; }
        [DisplayName("Résultat net de l'exercice")]
        public decimal F60030084 { get { return F60030080 + F60030081; } }
        public decimal F60030173 { get { return F60030169 + F60030170; } }
        [DisplayName("Effets des Modif° Comptables (net d'impôt)")]
        public decimal F60030085 { get { return F60030086 - F60030087; } }
        public decimal F60030174 { get { return F60030175 - F60030176; } }
        [DisplayName("Effet positif/Modif°C°affectant Réslts Reportés")]
        public decimal F60030086 { get; set; }
        public decimal F60030175 { get; set; }
        [DisplayName("Effet négatif/Modif°C°affectant Réslts Reportés")]
        public decimal F60030087 { get; set; }
        public decimal F60030176 { get; set; }
        [DisplayName("Autres Postes des Comptes de Résultat")]
        public decimal F60030088 { get; set; }
        public decimal F60030177 { get; set; }
        [DisplayName("RÉSULTATS APRÈS MODIFICATIONS COMPTABLES")]
        public decimal F60030089 { get { return F60030084 + F60030085 + F60030088; } }
        public decimal F60030178 { get { return F60030173 + F60030174 + F60030177; } }

        public List<string> getError()
        {
            List<string> msg = new List<string>();

            if (F60030001 != (F60030002 + F60030014 + F60030015))
                msg.Add("F60030001 est  invalide ! F60030001 = F60030002 + F60030014 + F60030015 ");

            if (F60030002 != (F60030003 + F60030006))
                msg.Add("F60030002 est  invalide ! F60030002 = F60030003 + F60030006 ");
            if (F60030003 != (F60030004 - F60030005))
                msg.Add("F60030003 est  invalide ! F60030003 = F60030004 - F60030005 ");
            if (F60030006 != (F60030007 + F60030008 + F60030009 + F60030010 + F60030011 + F60030012 - F60030013))
                msg.Add("F60030006 est  invalide ! F60030006 = F60030007 + F60030008 + F60030009 + F60030010 + F60030011 + F60030012 - F60030013 ");

            if (F60030015 != (F60030016 + F60030017 + F60030018 + F60030019))
                msg.Add("F60030015 est  invalide ! F60030015 = F60030016 + F60030017 + F60030018 + F60030019 ");

            if (F60030020 != (F60030021 + F60030025 + F60030029 + F60030036 + F60030046 + F60030053))
                msg.Add("F60030020 est  invalide ! F60030020 = F60030021 + F60030025 + F60030029 + F60030036 + F60030046 + F60030053 ");

            if (F60030021 != (F60030022 + F60030023 + F60030024))
                msg.Add("F60030021 est  invalide ! F60030021 = F60030022 + F60030023 + F60030024 ");

            if (F60030025 != (F60030026 - F60030027 + F60030028))
                msg.Add("F60030025 est  invalide ! F60030025 = F60030026 - F60030027 + F60030028 ");

            if (F60030029 != (F60030030 + F60030031 - F60030032 - F60030033 + F60030034 + F60030035))
                msg.Add("F60030029 est  invalide ! F60030029 = F60030030 + F60030031 - F60030032 - F60030033 + F60030034 + F60030035 ");

            if (F60030036 != (F60030037 + F60030038 + F60030039 + F60030040 + F60030041 + F60030042 + +F60030043 + F60030044 + F60030045))
                msg.Add("F60030036 est  invalide ! F60030036 = F60030037 + F60030038 + F60030039 + F60030040 + F60030041 + F60030042 + +F60030043 + F60030044 + F60030045 ");

            if (F60030046 != (F60030047 + F60030048 + F60030049 + F60030050 + F60030051 + F60030052))
                msg.Add("F60030046 est  invalide ! F60030046 = F60030047 + F60030048 + F60030049 + F60030050 + F60030051 + F60030052 ");

            if (F60030053 != (F60030054 + F60030055 + F60030056 + F60030057 + F60030058 + F60030059 + F60030060))
                msg.Add("F60030053 est  invalide ! F60030053 = F60030054 + F60030055 + F60030056 + F60030057 + F60030058 + F60030059 + F60030060 ");

            if (F60030061 != (F60030001 - F60030020))
                msg.Add("F60030061 est  invalide ! F60030061 = F60030001 - F60030020 ");

            if (F60030062 != (F60030063 + F60030064))
                msg.Add("F60030062 est  invalide ! F60030062 = F60030063 + F60030064 ");

            if (F60030065 != (F60030066 + F60030067 + F60030068))
                msg.Add("F60030065 est  invalide ! F60030065 = F60030066 + F60030067 + F60030068 ");

            if (F60030069 != (F60030070 + F60030071))
                msg.Add("F60030069 est  invalide ! F60030069 = F60030070 + F60030071 ");

            if (F60030072 != (F60030073 + F60030074 + F60030075))
                msg.Add("F60030072 est  invalide ! F60030072 = F60030073 + F60030074 + F60030075 ");

            if (F60030076 != (F60030061 - F60030062 + F60030065 + F60030069 - F60030072))
                msg.Add("F60030076 est  invalide ! F60030076 = F60030061 - F60030062 + F60030065 + F60030069 - F60030072 ");

            if (F60030077 != (F60030078 + F60030079))
                msg.Add("F60030077 est  invalide ! F60030077 = F60030078 + F60030079 ");

            if (F60030080 != (F60030076 - F60030077))
                msg.Add("F60030080 est  invalide ! F60030080 = F60030076 - F60030077) ");

            if (F60030081 != (F60030082 - F60030083))
                msg.Add("F60030081 est  invalide ! F60030081 = F60030082 - F60030083) ");

            if (F60030084 != (F60030080 + F60030081))
                msg.Add("F60030084 est  invalide ! F60030084 = F60030080 + F60030081) ");

            if (F60030085 != (F60030086 - F60030087))
                msg.Add("F60030085 est  invalide ! F60030085 =F60030086 - F60030087) ");

            if (F60030089 != (F60030084 + F60030085 + F60030088))
                msg.Add("F60030089 est  invalide ! F60030089 =F60030084 + F60030085 + F60030088) ");

            if (F60030090 != (F60030091 + F60030103 + F60030104))
                msg.Add("F60030090 est  invalide ! F60030090 =F60030091 + F60030103 + F60030104) ");

            if (F60030091 != (F60030092 + F60030095))
                msg.Add("F60030091 est  invalide ! F60030091 =F60030092 + F60030095) ");

            if (F60030092 != (F60030093 - F60030094))
                msg.Add("F60030092 est  invalide ! F60030092 = F60030093 - F60030094) ");

            if (F60030095 != (F60030096 + F60030097 + F60030098 + F60030099 + F60030100 + F60030101 - F60030102))
                msg.Add("F60030095 est  invalide ! F60030095 = F60030096 + F60030097 + F60030098 + F60030099 + F60030100 + F60030101 - F60030102) ");

            if (F60030104 != (F60030105 + F60030106 + F60030107 + F60030108))
                msg.Add("F60030104 est  invalide ! F60030104 = F60030105 + F60030106 + F60030107 + F60030108 ) ");

            if (F60030109 != (F60030110 + F60030114 + F60030118 + F60030125 + F60030135 + F60030142))
                msg.Add("F60030109 est  invalide ! F60030109 = F60030110 + F60030114 + F60030118 + F60030125 + F60030135 + F60030142 ) ");

            if (F60030110 != (F60030111 + F60030112 + F60030113))
                msg.Add("F60030110 est  invalide ! F60030110 = F60030111 + F60030112 + F60030113 ) ");


            if (F60030114 != (F60030115 - F60030116 + F60030117))
                msg.Add("F60030114 est  invalide ! F60030114 = F60030115 - F60030116 + F60030117 ) ");

            if (F60030118 != (F60030119 + F60030120 - F60030121 - F60030122 + F60030123 + F60030124))
                msg.Add("F60030118 est  invalide ! F60030118 = F60030119 + F60030120 - F60030121 - F60030122 + F60030123 + F60030124 ) ");

            if (F60030125 != (F60030126 + F60030127 + F60030128 + F60030129 + F60030130 + F60030131 + F60030132 + F60030133 + F60030134))
                msg.Add("F60030125 est  invalide ! F60030125 = F60030126 + F60030127 + F60030128 + F60030129 + F60030130 + F60030131 + F60030132 + F60030133 + F60030134 ) ");

            if (F60030135 != (F60030136 + F60030137 + F60030138 + F60030139 + F60030140 + F60030141))
                msg.Add("F60030135 est  invalide ! F60030135 = F60030136 + F60030137 + F60030138 + F60030139 + F60030140 + F60030141 ) ");

            if (F60030142 != (F60030143 + F60030144 + F60030145 + F60030146 + F60030147 + F60030148 + F60030149))
                msg.Add("F60030142 est  invalide ! F60030142 = F60030143 + F60030144 + F60030145 + F60030146 + F60030147 + F60030148 + F60030149 ) ");


            if (F60030150 != (F60030090 - F60030109))
                msg.Add("F60030150 est  invalide ! F60030150 = F60030090 - F60030109 ) ");

            if (F60030151 != (F60030152 + F60030153))
                msg.Add("F60030151 est  invalide ! F60030151 = F60030152 + F60030153 ) ");

            if (F60030154 != (F60030155 + F60030156 + F60030157))
                msg.Add("F60030154 est  invalide ! F60030154 = F60030155 + F60030156 + F60030157 ) ");

            if (F60030158 != (F60030159 + F60030160))
                msg.Add("F60030158 est  invalide ! F60030158 = F60030159 + F60030160 ) ");

            if (F60030161 != (F60030162 + F60030163 + F60030164))
                msg.Add("F60030161 est  invalide ! F60030161 = F60030162 + F60030163 + F60030164 ) ");

            if (F60030165 != (F60030150 - F60030151 + F60030154 + F60030158 - F60030161))
                msg.Add("F60030165 est  invalide ! F60030165 = F60030150 - F60030151 + F60030154 + F60030158 - F60030161 ) ");

            if (F60030166 != (F60030167 + F60030168))
                msg.Add("F60030166 est  invalide ! F60030166 = F60030167 + F60030168 ) ");

            if (F60030169 != (F60030165 - F60030166))
                msg.Add("F60030169 est  invalide ! F60030169 = F60030165 - F60030166 ) ");

            if (F60030170 != (F60030171 - F60030172))
                msg.Add("F60030170 est  invalide ! F60030170 = F60030171 - F60030172) ");

            if (F60030173 != (F60030169 + F60030170))
                msg.Add("F60030173 est  invalide ! F60030173 = F60030169 + F60030170) ");

            if (F60030174 != (F60030175 - F60030176))
                msg.Add("F60030174 est  invalide ! F60030174 = F60030175 - F60030176) ");

            if (F60030178 != (F60030173 + F60030174 + F60030177))
                msg.Add("F60030178 est  invalide ! F60030178 = F60030173 + F60030174 + F60030177) ");


            return msg;
        }

        public string ToXML(Models.Societe ste, Models.Exercice ex)
        {
            // Models.Societe sos = TVS.
            string r =
$@"<?xml version=""1.0"" encoding=""UTF-8""?>
<?xml-stylesheet type=""text/xsl"" href=""F6003.xsl""?>
<lf:F6003 xmlns:lf=""http://www.impots.finances.gov.tn/liasse"" xmlns:vc=""http://www.w3.org/2007/XMLSchema-versioning"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://www.impots.finances.gov.tn/liasse F6003.xsd"">
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
		<lf:F60030001>{this.F60030001 * 1000:0}</lf:F60030001>
		<lf:F60030002>{this.F60030002 * 1000:0}</lf:F60030002>
		<lf:F60030003>{this.F60030003 * 1000:0}</lf:F60030003>
		<lf:F60030004>{this.F60030004 * 1000:0}</lf:F60030004>
		<lf:F60030005>{this.F60030005 * 1000:0}</lf:F60030005>
		<lf:F60030006>{this.F60030006 * 1000:0}</lf:F60030006>
		<lf:F60030007>{this.F60030007 * 1000:0}</lf:F60030007>
		<lf:F60030008>{this.F60030008 * 1000:0}</lf:F60030008>
		<lf:F60030009>{this.F60030009 * 1000:0}</lf:F60030009>
		<lf:F60030010>{this.F60030010 * 1000:0}</lf:F60030010>
		<lf:F60030011>{this.F60030011 * 1000:0}</lf:F60030011>
		<lf:F60030012>{this.F60030012 * 1000:0}</lf:F60030012>
		<lf:F60030013>{this.F60030013 * 1000:0}</lf:F60030013>
		<lf:F60030014>{this.F60030014 * 1000:0}</lf:F60030014>
		<lf:F60030015>{this.F60030015 * 1000:0}</lf:F60030015>
		<lf:F60030016>{this.F60030016 * 1000:0}</lf:F60030016>
		<lf:F60030017>{this.F60030017 * 1000:0}</lf:F60030017>
		<lf:F60030018>{this.F60030018 * 1000:0}</lf:F60030018>
		<lf:F60030019>{this.F60030019 * 1000:0}</lf:F60030019>
		<lf:F60030020>{this.F60030020 * 1000:0}</lf:F60030020>
		<lf:F60030021>{this.F60030021 * 1000:0}</lf:F60030021>
		<lf:F60030022>{this.F60030022 * 1000:0}</lf:F60030022>
		<lf:F60030023>{this.F60030023 * 1000:0}</lf:F60030023>
		<lf:F60030024>{this.F60030024 * 1000:0}</lf:F60030024>
		<lf:F60030025>{this.F60030025 * 1000:0}</lf:F60030025>
		<lf:F60030026>{this.F60030026 * 1000:0}</lf:F60030026>
		<lf:F60030027>{this.F60030027 * 1000:0}</lf:F60030027>
		<lf:F60030028>{this.F60030028 * 1000:0}</lf:F60030028>
		<lf:F60030029>{this.F60030029 * 1000:0}</lf:F60030029>
		<lf:F60030030>{this.F60030030 * 1000:0}</lf:F60030030>
		<lf:F60030031>{this.F60030031 * 1000:0}</lf:F60030031>
		<lf:F60030032>{this.F60030032 * 1000:0}</lf:F60030032>
		<lf:F60030033>{this.F60030033 * 1000:0}</lf:F60030033>
		<lf:F60030034>{this.F60030034 * 1000:0}</lf:F60030034>
		<lf:F60030035>{this.F60030035 * 1000:0}</lf:F60030035>
		<lf:F60030036>{this.F60030036 * 1000:0}</lf:F60030036>
		<lf:F60030037>{this.F60030037 * 1000:0}</lf:F60030037>
		<lf:F60030038>{this.F60030038 * 1000:0}</lf:F60030038>
		<lf:F60030039>{this.F60030039 * 1000:0}</lf:F60030039>
		<lf:F60030040>{this.F60030040 * 1000:0}</lf:F60030040>
		<lf:F60030041>{this.F60030041 * 1000:0}</lf:F60030041>
		<lf:F60030042>{this.F60030042 * 1000:0}</lf:F60030042>
		<lf:F60030043>{this.F60030043 * 1000:0}</lf:F60030043>
		<lf:F60030044>{this.F60030044 * 1000:0}</lf:F60030044>
		<lf:F60030045>{this.F60030045 * 1000:0}</lf:F60030045>
		<lf:F60030046>{this.F60030046 * 1000:0}</lf:F60030046>
		<lf:F60030047>{this.F60030047 * 1000:0}</lf:F60030047>
		<lf:F60030048>{this.F60030048 * 1000:0}</lf:F60030048>
		<lf:F60030049>{this.F60030049 * 1000:0}</lf:F60030049>
		<lf:F60030050>{this.F60030050 * 1000:0}</lf:F60030050>
		<lf:F60030051>{this.F60030051 * 1000:0}</lf:F60030051>
		<lf:F60030052>{this.F60030052 * 1000:0}</lf:F60030052>
		<lf:F60030053>{this.F60030053 * 1000:0}</lf:F60030053>
		<lf:F60030054>{this.F60030054 * 1000:0}</lf:F60030054>
		<lf:F60030055>{this.F60030055 * 1000:0}</lf:F60030055>
		<lf:F60030056>{this.F60030056 * 1000:0}</lf:F60030056>
		<lf:F60030057>{this.F60030057 * 1000:0}</lf:F60030057>
		<lf:F60030058>{this.F60030058 * 1000:0}</lf:F60030058>
		<lf:F60030059>{this.F60030059 * 1000:0}</lf:F60030059>
		<lf:F60030060>{this.F60030060 * 1000:0}</lf:F60030060>
		<lf:F60030061>{this.F60030061 * 1000:0}</lf:F60030061>
		<lf:F60030062>{this.F60030062 * 1000:0}</lf:F60030062>
		<lf:F60030063>{this.F60030063 * 1000:0}</lf:F60030063>
		<lf:F60030064>{this.F60030064 * 1000:0}</lf:F60030064>
		<lf:F60030065>{this.F60030065 * 1000:0}</lf:F60030065>
		<lf:F60030066>{this.F60030066 * 1000:0}</lf:F60030066>
		<lf:F60030067>{this.F60030067 * 1000:0}</lf:F60030067>
		<lf:F60030068>{this.F60030068 * 1000:0}</lf:F60030068>
		<lf:F60030069>{this.F60030069 * 1000:0}</lf:F60030069>
		<lf:F60030070>{this.F60030070 * 1000:0}</lf:F60030070>
		<lf:F60030071>{this.F60030071 * 1000:0}</lf:F60030071>
		<lf:F60030072>{this.F60030072 * 1000:0}</lf:F60030072>
		<lf:F60030073>{this.F60030073 * 1000:0}</lf:F60030073>
		<lf:F60030074>{this.F60030074 * 1000:0}</lf:F60030074>
		<lf:F60030075>{this.F60030075 * 1000:0}</lf:F60030075>
		<lf:F60030076>{this.F60030076 * 1000:0}</lf:F60030076>
		<lf:F60030077>{this.F60030077 * 1000:0}</lf:F60030077>
		<lf:F60030078>{this.F60030078 * 1000:0}</lf:F60030078>
		<lf:F60030079>{this.F60030079 * 1000:0}</lf:F60030079>
		<lf:F60030080>{this.F60030080 * 1000:0}</lf:F60030080>
		<lf:F60030081>{this.F60030081 * 1000:0}</lf:F60030081>
		<lf:F60030082>{this.F60030082 * 1000:0}</lf:F60030082>
		<lf:F60030083>{this.F60030083 * 1000:0}</lf:F60030083>
		<lf:F60030084>{this.F60030084 * 1000:0}</lf:F60030084>
		<lf:F60030085>{this.F60030085 * 1000:0}</lf:F60030085>
		<lf:F60030086>{this.F60030086 * 1000:0}</lf:F60030086>
		<lf:F60030087>{this.F60030087 * 1000:0}</lf:F60030087>
		<lf:F60030088>{this.F60030088 * 1000:0}</lf:F60030088>
		<lf:F60030089>{this.F60030089 * 1000:0}</lf:F60030089>
		<lf:F60030090>{this.F60030090 * 1000:0}</lf:F60030090>
		<lf:F60030091>{this.F60030091 * 1000:0}</lf:F60030091>
		<lf:F60030092>{this.F60030092 * 1000:0}</lf:F60030092>
		<lf:F60030093>{this.F60030093 * 1000:0}</lf:F60030093>
		<lf:F60030094>{this.F60030094 * 1000:0}</lf:F60030094>
		<lf:F60030095>{this.F60030095 * 1000:0}</lf:F60030095>
		<lf:F60030096>{this.F60030096 * 1000:0}</lf:F60030096>
		<lf:F60030097>{this.F60030097 * 1000:0}</lf:F60030097>
		<lf:F60030098>{this.F60030098 * 1000:0}</lf:F60030098>
		<lf:F60030099>{this.F60030099 * 1000:0}</lf:F60030099>
		<lf:F60030100>{this.F60030100 * 1000:0}</lf:F60030100>
		<lf:F60030101>{this.F60030101 * 1000:0}</lf:F60030101>
		<lf:F60030102>{this.F60030102 * 1000:0}</lf:F60030102>
		<lf:F60030103>{this.F60030103 * 1000:0}</lf:F60030103>
		<lf:F60030104>{this.F60030104 * 1000:0}</lf:F60030104>
		<lf:F60030105>{this.F60030105 * 1000:0}</lf:F60030105>
		<lf:F60030106>{this.F60030106 * 1000:0}</lf:F60030106>
		<lf:F60030107>{this.F60030107 * 1000:0}</lf:F60030107>
		<lf:F60030108>{this.F60030108 * 1000:0}</lf:F60030108>
		<lf:F60030109>{this.F60030109 * 1000:0}</lf:F60030109>
		<lf:F60030110>{this.F60030110 * 1000:0}</lf:F60030110>
		<lf:F60030111>{this.F60030111 * 1000:0}</lf:F60030111>
		<lf:F60030112>{this.F60030112 * 1000:0}</lf:F60030112>
		<lf:F60030113>{this.F60030113 * 1000:0}</lf:F60030113>
		<lf:F60030114>{this.F60030114 * 1000:0}</lf:F60030114>
		<lf:F60030115>{this.F60030115 * 1000:0}</lf:F60030115>
		<lf:F60030116>{this.F60030116 * 1000:0}</lf:F60030116>
		<lf:F60030117>{this.F60030117 * 1000:0}</lf:F60030117>
		<lf:F60030118>{this.F60030118 * 1000:0}</lf:F60030118>
		<lf:F60030119>{this.F60030119 * 1000:0}</lf:F60030119>
		<lf:F60030120>{this.F60030120 * 1000:0}</lf:F60030120>
		<lf:F60030121>{this.F60030121 * 1000:0}</lf:F60030121>
		<lf:F60030122>{this.F60030122 * 1000:0}</lf:F60030122>
		<lf:F60030123>{this.F60030123 * 1000:0}</lf:F60030123>
		<lf:F60030124>{this.F60030124 * 1000:0}</lf:F60030124>
		<lf:F60030125>{this.F60030125 * 1000:0}</lf:F60030125>
		<lf:F60030126>{this.F60030126 * 1000:0}</lf:F60030126>
		<lf:F60030127>{this.F60030127 * 1000:0}</lf:F60030127>
		<lf:F60030128>{this.F60030128 * 1000:0}</lf:F60030128>
		<lf:F60030129>{this.F60030129 * 1000:0}</lf:F60030129>
		<lf:F60030130>{this.F60030130 * 1000:0}</lf:F60030130>
		<lf:F60030131>{this.F60030131 * 1000:0}</lf:F60030131>
		<lf:F60030132>{this.F60030132 * 1000:0}</lf:F60030132>
		<lf:F60030133>{this.F60030133 * 1000:0}</lf:F60030133>
		<lf:F60030134>{this.F60030134 * 1000:0}</lf:F60030134>
		<lf:F60030135>{this.F60030135 * 1000:0}</lf:F60030135>
		<lf:F60030136>{this.F60030136 * 1000:0}</lf:F60030136>
		<lf:F60030137>{this.F60030137 * 1000:0}</lf:F60030137>
		<lf:F60030138>{this.F60030138 * 1000:0}</lf:F60030138>
		<lf:F60030139>{this.F60030139 * 1000:0}</lf:F60030139>
		<lf:F60030140>{this.F60030140 * 1000:0}</lf:F60030140>
		<lf:F60030141>{this.F60030141 * 1000:0}</lf:F60030141>
		<lf:F60030142>{this.F60030142 * 1000:0}</lf:F60030142>
		<lf:F60030143>{this.F60030143 * 1000:0}</lf:F60030143>
		<lf:F60030144>{this.F60030144 * 1000:0}</lf:F60030144>
		<lf:F60030145>{this.F60030145 * 1000:0}</lf:F60030145>
		<lf:F60030146>{this.F60030146 * 1000:0}</lf:F60030146>
		<lf:F60030147>{this.F60030147 * 1000:0}</lf:F60030147>
		<lf:F60030148>{this.F60030148 * 1000:0}</lf:F60030148>
		<lf:F60030149>{this.F60030149 * 1000:0}</lf:F60030149>
		<lf:F60030150>{this.F60030150 * 1000:0}</lf:F60030150>
		<lf:F60030151>{this.F60030151 * 1000:0}</lf:F60030151>
		<lf:F60030152>{this.F60030152 * 1000:0}</lf:F60030152>
		<lf:F60030153>{this.F60030153 * 1000:0}</lf:F60030153>
		<lf:F60030154>{this.F60030154 * 1000:0}</lf:F60030154>
		<lf:F60030155>{this.F60030155 * 1000:0}</lf:F60030155>
		<lf:F60030156>{this.F60030156 * 1000:0}</lf:F60030156>
		<lf:F60030157>{this.F60030157 * 1000:0}</lf:F60030157>
		<lf:F60030158>{this.F60030158 * 1000:0}</lf:F60030158>
		<lf:F60030159>{this.F60030159 * 1000:0}</lf:F60030159>
		<lf:F60030160>{this.F60030160 * 1000:0}</lf:F60030160>
		<lf:F60030161>{this.F60030161 * 1000:0}</lf:F60030161>
		<lf:F60030162>{this.F60030162 * 1000:0}</lf:F60030162>
		<lf:F60030163>{this.F60030163 * 1000:0}</lf:F60030163>
		<lf:F60030164>{this.F60030164 * 1000:0}</lf:F60030164>
		<lf:F60030165>{this.F60030165 * 1000:0}</lf:F60030165>
		<lf:F60030166>{this.F60030166 * 1000:0}</lf:F60030166>
		<lf:F60030167>{this.F60030167 * 1000:0}</lf:F60030167>
		<lf:F60030168>{this.F60030168 * 1000:0}</lf:F60030168>
		<lf:F60030169>{this.F60030169 * 1000:0}</lf:F60030169>
		<lf:F60030170>{this.F60030170 * 1000:0}</lf:F60030170>
		<lf:F60030171>{this.F60030171 * 1000:0}</lf:F60030171>
		<lf:F60030172>{this.F60030172 * 1000:0}</lf:F60030172>
		<lf:F60030173>{this.F60030173 * 1000:0}</lf:F60030173>
		<lf:F60030174>{this.F60030174 * 1000:0}</lf:F60030174>
		<lf:F60030175>{this.F60030175 * 1000:0}</lf:F60030175>
		<lf:F60030176>{this.F60030176 * 1000:0}</lf:F60030176>
		<lf:F60030177>{this.F60030177 * 1000:0}</lf:F60030177>
		<lf:F60030178>{this.F60030178 * 1000:0}</lf:F60030178>		
	</lf:Details>
</lf:F6003>
";


            return r;
        }
    }
}
