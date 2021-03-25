using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.PivotGrid.OLAP.AdoWrappers;
using DevExpress.XtraGauges.Core.Model;

namespace TVS.Core.Models.Liass
{
    public partial class F6005
    {
        public int Id { get; set; }
        public int SocieteNo { get; set; }
        public int ExerciceId { get; set; }
        [DisplayName("Acte de dépot")] public int ActeDeDepot { get; set; }
        [DisplayName("Nature de dépot")] public string NatureDepot { get; set; }

        private string _F60050000Codeformejuridique = "SC";

        [DisplayName("Code forme juridique")]
        public string F60050000Codeformejuridique
        {
            get { return _F60050000Codeformejuridique; }
            set { _F60050000Codeformejuridique = value; }
        }

        public string F60051000Codeformejuridique
        {
            get { return _F60050000Codeformejuridique; }
            set { _F60050000Codeformejuridique = value; }
        }

        [DisplayName("Categorie")] public string F60050000Categorie { get; set; } = "M";
        public string F60051000Categorie { get; set; } = "M";

        [DisplayName("Nature resultat net comptable apres modifications comptables (avant impôt)")]
        public string F60050001 { get; set; } = "B";

        public string F60051001 { get; set; } = "B";

        [DisplayName("Resultat net comptable apres modifications comptables (avant impôts)")]
        public decimal F60050002 { get; set; }

        public decimal F60051002 { get; set; }

        [DisplayName("Charges non déductibles")]
        public decimal F60050003
        {
            get
            {
                return F60050004 + F60050005 + F60050006 + F60050007 + F60050008 + F60050009 + F60050010 + F60050011 +
                       F60050012 + F60050013 + F60050014 + F60050015 + F60050016 + F60050017 + F60050018 + F60050019 +
                       F60050020 + F60050021 + F60050022 + F60050023 + F60050024;
            }
        }

        public decimal F60051003
        {
            get
            {
                return F60051004 + F60051005 + F60051006 + F60051007 + F60051008 + F60051009 + F60051010 + F60051011 +
                       F60051012 + F60051013 + F60051014 + F60051015 + F60051016 + F60051017 + F60051018 + F60051019 +
                       F60051020 + F60051021 + F60051022 + F60051023 + F60051024;
            }
        }

        [DisplayName(
            "Rénumérations de l'exploitant individuel, ou des associés en nom des sociétés de personnes et assimilés")]
        public decimal F60050004 { get; set; }

        public decimal F60051004 { get; set; }

        [DisplayName("Charges relatifs aux établissements situés à l'étranger")]
        public decimal F60050005 { get; set; }

        public decimal F60051005 { get; set; }

        [DisplayName(
            "Quote-part des frais de siège imputable aux établissements situés à l'étranger ( frais du siège x (chiffre d'affaires de l'établissement stable /chiffre d'affaires total))")]
        public decimal F60050006 { get; set; }

        public decimal F60051006 { get; set; }

        [DisplayName(
            "Charges relatives aux résidences secondaires, avions et bateaux de plaisance ne faisant pas l'objet de l'exploitation")]
        public decimal F60050007 { get; set; }

        public decimal F60051007 { get; set; }

        [DisplayName(
            "Charges relatives aux véhicules de tourismes d'une puissance supérieur à 9 CV ne faisant pas l'objet de l'exploitation")]
        public decimal F60050008 { get; set; }

        public decimal F60051008 { get; set; }

        [DisplayName("Cadeaux et frais de réception non déductibles")]
        public decimal F60050009 { get; set; }

        public decimal F60051009 { get; set; }

        [DisplayName("Cadeaux et frais de réception excédentaires")]
        public decimal F60050010 { get; set; }

        public decimal F60051010 { get; set; }

        [DisplayName(
            "Commissions, courtages, ristournes commerciales ou autres, vacations, honoraires er rémunérations de performance non déclarés dans la déclaration de l'employeur")]
        public decimal F60050011 { get; set; }

        public decimal F60051011 { get; set; }

        [DisplayName("Dons et subventions non déductibles")]
        public decimal F60050012 { get; set; }

        public decimal F60051012 { get; set; }

        [DisplayName("Dons et subventions excédentaires")]
        public decimal F60050013 { get; set; }

        public decimal F60051013 { get; set; }

        [DisplayName("Abandon de créances non déductibles")]
        public decimal F60050014 { get; set; }

        public decimal F60051014 { get; set; }

        [DisplayName("Pertes de change non réalisées")]
        public decimal F60050015 { get; set; }

        public decimal F60051015 { get; set; }

        [DisplayName("Gains de change non réalisés antérieurement non imposés")]
        public decimal F60050016 { get; set; }

        public decimal F60051016 { get; set; }

        [DisplayName("Intérêts servis à l'exploitant ou aux associés des sociétés de personnes et assimilés")]
        public decimal F60050017 { get; set; }

        public decimal F60051017 { get; set; }

        [DisplayName("Rémunération excédentaires des titres participatifs et des comptes courants associés")]
        public decimal F60050018 { get; set; }

        public decimal F60051018 { get; set; }

        [DisplayName("Charges d'une valeur supérieure ou égale à 5.000 dinars payée en espèces")]
        public decimal F60050019 { get; set; }

        public decimal F60051019 { get; set; }

        [DisplayName(
            "Moins values de cession des titres des organismes de placement collectif en valeurs mobilières dans la limite des dividendes réalisés")]
        public decimal F60050020 { get; set; }

        public decimal F60051020 { get; set; }

        [DisplayName("Impôts directs supportés aux lieu et place d'autrui")]
        public decimal F60050021 { get; set; }

        public decimal F60051021 { get; set; }
        [DisplayName("Taxe de voyages ()")] public decimal F60050022 { get; set; }
        public decimal F60051022 { get; set; }

        [DisplayName("Transactions, amendes, confiscations et pénalités non déductibles")]
        public decimal F60050023 { get; set; }

        public decimal F60051023 { get; set; }

        [DisplayName("Dépenses excédentaires engagées  pour la réalisation des opérations d'essaimage")]
        public decimal F60050024 { get; set; }

        public decimal F60051024 { get; set; }

        [DisplayName("Amortissements")]
        public decimal F60050025
        {
            get { return F60050026 + F60050027 + F60050028 + F60050029 + F60050030 + F60050031 + F60050032; }
        }

        public decimal F60051025
        {
            get { return F60051026 + F60051027 + F60051028 + F60051029 + F60051030 + F60051031 + F60051032; }
        }

        [DisplayName("Amort. Non déductibles relatifs aux établissements situés à l'étranger")]
        public decimal F60050026 { get; set; }

        public decimal F60051026 { get; set; }

        [DisplayName(
            "Amortissements non déductibles relatifs aux résidences secondaires, avions et bateaux de plaisance ne faisant pas l'objet de l'exploitation")]
        public decimal F60050027 { get; set; }

        public decimal F60051027 { get; set; }

        [DisplayName(
            "Amortissements non déductibles relatifs aux véhicules de tourisme d'une puissance fiscale supérieure à 9 CV ne faisant pas l'objet de l'exploitation")]
        public decimal F60050028 { get; set; }

        public decimal F60051028 { get; set; }

        [DisplayName("Amort. Non déductibles relatifs aux terrains et fonds de commerce")]
        public decimal F60050029 { get; set; }

        public decimal F60051029 { get; set; }

        [DisplayName(
            "Amort. Non déductibles relatifs aux terrains et fonds de commerce actifs d'une valeur supérieure ou égale à 5000 DT payée en espèces")]
        public decimal F60050030 { get; set; }

        public decimal F60051030 { get; set; }

        [DisplayName("Partie des amort. Ayant dépassé la limite autorisée par la législation en vigueur")]
        public decimal F60050031 { get; set; }

        public decimal F60051031 { get; set; }

        [DisplayName(
            "Partie des amortissements correspondant à une période inférieure à la période autorisée par la législation en vigueur, pour les immobilisations acquises dans le cadre d'un contrat de leasing ou d'ijara")]
        public decimal F60050032 { get; set; }

        public decimal F60051032 { get; set; }

        [DisplayName("Provisions")]
        public decimal F60050033
        {
            get { return F60050034 + F60050035 + F60050036 + F60050037 + F60050038; }
        }

        public decimal F60051033
        {
            get { return F60051034 + F60051035 + F60051036 + F60051037 + F60051038; }
        }

        [DisplayName("Provisions non déductibles")]
        public decimal F60050034 { get; set; }

        public decimal F60051034 { get; set; }

        [DisplayName(
            "Provisions déductibles pour créances douteuses (autres que celles constituées par les établissements de crédit)")]
        public decimal F60050035 { get; set; }

        public decimal F60051035 { get; set; }

        [DisplayName(
            "Provisions déductibles pour dépréciation des actions cotées en bourse autres que celles constituées par les sociétés d'investissement à capital risque)")]
        public decimal F60050036 { get; set; }

        public decimal F60051036 { get; set; }

        [DisplayName("provisions déductibles pour dépréciation des stocks destinés à la vente")]
        public decimal F60050037 { get; set; }

        public decimal F60051037 { get; set; }

        [DisplayName(
            "Provisions déductibles pour risque d'exigibilité des engagements techniques (compagnie d'assurance)")]
        public decimal F60050038 { get; set; }

        public decimal F60051038 { get; set; }

        [DisplayName("Produits non comptabilisés ou insuffisamment comptabilisés ∑ 40 à 43")]
        public decimal F60050039
        {
            get { return F60050040 + F60050041 + F60050042 + F60050043; }
        }

        public decimal F60051039
        {
            get { return F60051040 + F60051041 + F60051042 + F60051043; }
        }

        [DisplayName("Intérêts non décomptés relatifs aux comptes courants associés et aux créances non commerciales")]
        public decimal F60050040 { get; set; }

        public decimal F60051040 { get; set; }

        [DisplayName(
            "Intérêts insuffisamment décomptés relatifs aux comptes courants associés et aux créance non commerciales")]
        public decimal F60050041 { get; set; }

        public decimal F60051041 { get; set; }

        [DisplayName("Plus value de cession des actifs non comptabilisée")]
        public decimal F60050042 { get; set; }

        public decimal F60051042 { get; set; }

        [DisplayName("Plus value de cession des actifs insuffisammen comptabilisée")]
        public decimal F60050043 { get; set; }

        public decimal F60051043 { get; set; }
        [DisplayName("Autres réintégrations")] public decimal F60050044 { get; set; }
        public decimal F60051044 { get; set; }

        [DisplayName("TOTAL DES RÉINTÉGRATIONS ")]
        public decimal F60050045
        {
            get { return F60050003 + F60050025 + F60050033 + F60050039 + F60050044; }
        }

        public decimal F60051045
        {
            get { return F60051003 + F60051025 + F60051033 + F60051039 + F60051044; }
        }

        [DisplayName("Produits réalisés par les établissements situés à l'étranger")]
        public decimal F60050046 { get; set; }

        public decimal F60051046 { get; set; }

        [DisplayName("Reprise sur provisions réintégrées au résultat fiscal de l'année de leur constitution")]
        public decimal F60050047 { get; set; }

        public decimal F60051047 { get; set; }

        [DisplayName("Amortissements excédentaires réintégrés aux résultats des années antérieures")]
        public decimal F60050048 { get; set; }

        public decimal F60051048 { get; set; }

        [DisplayName("Gains de change réintégrés aux résultats des années antérieures")]
        public decimal F60050049 { get; set; }

        public decimal F60051049 { get; set; }

        [DisplayName("Gains de change non réalisés")]
        public decimal F60050050 { get; set; }

        public decimal F60051050 { get; set; }

        [DisplayName("Pertes de change antérieurement constatées")]
        public decimal F60050051 { get; set; }

        public decimal F60051051 { get; set; }

        [DisplayName("50% des salaires servis aux demandeurs d'emploi recrutés pour la première fois")]
        public decimal F60050052 { get; set; }

        public decimal F60051052 { get; set; }
        [DisplayName("Autres déductions ")] public decimal F60050053 { get; set; }
        public decimal F60051053 { get; set; }

        [DisplayName("TOTAL DES DÉDUCTIONS ∑ 46 à 53")]
        public decimal F60050054
        {
            get
            {
                return F60050046 + F60050047 + F60050048 + F60050049 + F60050050 + F60050051 + F60050052 + F60050053;
            }
        }

        public decimal F60051054
        {
            get
            {
                return F60051046 + F60051047 + F60051048 + F60051049 + F60051050 + F60051051 + F60051052 + F60051053;
            }
        }

        [DisplayName("Nature du Résultat Fiscal avant Déduction des Provisions (Perte, Bénéfice)")]
        public string F60050055 { get; set; } = "B";

        public string F60051055 { get; set; } = "B";

        [DisplayName("Resultat fiscal avant déduction des provisions)")]
        public decimal F60050955
        {
            get { return F60050002 + F60050045 - F60050054; }
        }

        public decimal F60051955
        {
            get { return F60051002 + F60051045 - F60051054; }
        }

        [DisplayName("Cas bénéficiaire : RÉSULTAT FISCAL 56=sup(55;0)")]
        public decimal F60050056
        {
            get { return F60050955 > 0 ? F60050955 : 0; }
        }

        public decimal F60051056
        {
            get { return F60051955 > 0 ? F60051955 : 0; }
        }

        [DisplayName("Provisions pour créances douteuses")]
        public decimal F60050057 { get; set; }

        public decimal F60051057 { get; set; }

        [DisplayName("Provisions pour dépréciation des stocks destinés à la vente")]
        public decimal F60050058 { get; set; }

        public decimal F60051058 { get; set; }

        [DisplayName("Prov. pour dépréciation de la valeur des actions côtées en bourse")]
        public decimal F60050059 { get; set; }

        public decimal F60051059 { get; set; }

        [DisplayName("Prov° pour risuqes d'exégibilité des engagements techniques(companies d'assurances)")]
        public decimal F60050060 { get; set; }

        public decimal F60051060 { get; set; }

        [DisplayName(
            "RÉSULTAT FISCAL après déduction des provisions F60050061=F60050056-Min( ∑F60050057 à F60050060, F60050056/2 )")]
        public decimal F60050061
        {
            get
            {
                var sum = F60050057 + F60050058 + F60050059 + F60050060;
                var moitier56 = F60050056 / 2;
                var sup = sum < moitier56 ? sum : moitier56;
                //var sup = ((F60050057 + F60050058 + F60050059 + F60050060) < F60050056 / 2 ? F60050056 / 2 : F60050057 + F60050058 + F60050059 + F60050060);
                return F60050056 - sup;
            }
        }

        public decimal F60051061
        {
            get
            {
                var sum = F60051057 + F60051058 + F60051059 + F60051060;
                var moitier56 = F60051056 / 2;
                var sup = sum < moitier56 ? sum : moitier56;
                // var sup = ((F60051057 + F60051058 + F60051059 + F60051060) < F60051056 / 2 ? F60051056 / 2 : F60051057 + F60051058 + F60051059 + F60051060);
                return F60051056 - sup;
            }
        }

        [DisplayName(
            "Déduction de la moins value provenant de la levée de l'option par les salariés de souscription au capital des sociétés ou d'acquisition de leurs actions ou parts sociales dans la limite de 5% du résultat fiscal après déduction des provisions (Société de s")]
        public decimal F60050062 { get; set; }

        public decimal F60051062 { get; set; }

        [DisplayName(
            "Résultat fiscal après déduction des provisions et avant déduction des déficits et des amortissements")]
        public decimal F60050063
        {
            get { return (F60050061 - F60050062) > 0 ? (F60050061 - F60050062) : 0; }
        }

        public decimal F60051063
        {
            get { return (F60051061 - F60051062) > 0 ? (F60051061 - F60051062) : 0; }
        }

        [DisplayName("Réintégration des amortissements d l'exercice")]
        public decimal F60050064 { get; set; }

        public decimal F60051064 { get; set; }

        [DisplayName("Déduction des déficits reportés")]
        public decimal F60050065 { get; set; }

        public decimal F60051065 { get; set; }

        [DisplayName("Déduction des amortissements de l'exercice")]
        public decimal F60050066 { get; set; }

        public decimal F60051066 { get; set; }

        [DisplayName("Déduction des amortissements différés en période déficitaire")]
        public decimal F60050067 { get; set; }

        public decimal F60051067 { get; set; }

        [DisplayName("RÉSULTAT FISCAL après déduction des provisions, des déficits et amortissements différés")]
        public decimal F60050068
        {
            get
            {
                var r = F60050063 + F60050064 - F60050065 - F60050066 - F60050067;
                if (r < 0) r = 0;
                return r;
            }
        }

        public decimal F60051068
        {
            get
            {
                var r = F60051063 + F60051064 - F60051065 - F60051066 - F60051067;
                if (r < 0) r = 0;
                return r;
            }
        }

        [DisplayName("Dividendes et assimilés distribués par des sociétés établis en Tunisie")]
        public decimal F60050069 { get; set; }

        public decimal F60051069 { get; set; }

        [DisplayName("Plus-value de cession des actions dans le cadre d'une opération d'introduction en bourse")]
        public decimal F60050070 { get; set; }

        public decimal F60051070 { get; set; }

        [DisplayName(
            "Plus-value de cession des actions cotées à la bourse des valeurs mobilières de Tunis  cédées après l'expiration de l'année suivant celle de leur acquisition ou de leursouscription")]
        public decimal F60050071 { get; set; }

        public decimal F60051071 { get; set; }

        [DisplayName(
            "Plus-value de cession des actions et des parts sociales réalisée par l'intermédiaire des sociétés d'investissement à capital rique (totalement ou dans la limite de 50%)")]
        public decimal F60050072 { get; set; }

        public decimal F60051072 { get; set; }

        [DisplayName(
            "Plus-value de cession des parts des fonds communs de placement à risque (totalement ou dans la limite de 50%)")]
        public decimal F60050073 { get; set; }

        public decimal F60051073 { get; set; }

        [DisplayName("Plus-value de cession des parts des fonds d'amorçage")]
        public decimal F60050074 { get; set; }

        public decimal F60051074 { get; set; }

        [DisplayName(
            "Plus-value d'apport dans le cadre d'une opération de fusion ou deission totale de sociétés, ou d'une opération d'apport des entreprises individuelles dans le capital d'une société (au niveau de la société absorbée,indée ou de la société ayant fait l'appor")]
        public decimal F60050075 { get; set; }

        public decimal F60051075 { get; set; }

        [DisplayName(
            "Plus-value provenant de l'apport d'actions ou de parts sociales au capital de la société mère ou de la société holding dans le cadre des opérations de restructuration des entreprises ayant pour objet l'introduction de la société mère ou de la société hold")]
        public decimal F60050076 { get; set; }

        public decimal F60051076 { get; set; }

        [DisplayName(
            "Plus-value provenant de la cession totale ou partielle des éléments de l'actif constituant une unité indépendante et autonome suite au départ à la retraite du propriétaire de l'entreprise ou à cause de l'incapacité de poursuivre la gestion de l'entreprise")]
        public decimal F60050077 { get; set; }

        public decimal F60051077 { get; set; }

        [DisplayName(
            "Plus-value provenant de la cession des entreprises en difficultés économiques dans le cadre du règlement judiciare prévu par la loi relative au redressemen des entreprises")]
        public decimal F60050078 { get; set; }

        public decimal F60051078 { get; set; }

        [DisplayName("intérêts des dépôts et de titres en devises ou en dinars convertibles")]
        public decimal F60050079 { get; set; }

        public decimal F60051079 { get; set; }

        [DisplayName("Résultat fiscal avant déduction des bénéfices provenant de l'exploitation")]
        public decimal F60050080
        {
            get
            {
                var r = F60050068 - (F60050069 + F60050070 + F60050071 + F60050072 + F60050073 + F60050074 + F60050075 +
                                     F60050076 + F60050077 + F60050078 + F60050079);
                return r > 0 ? r : 0;
            }
        }

        public decimal F60051080
        {
            get
            {
                var r = F60051068 - (F60051069 + F60051070 + F60051071 + F60051072 + F60051073 + F60051074 + F60051075 +
                                     F60051076 + F60051077 + F60051078 + F60051079);
                return r > 0 ? r : 0;
            }
        }

        [DisplayName("Revenus accessoires")]
        public decimal F60050081
        {
            get { return F60050082 + F60050083 + F60050084 + F60050085; }
        }

        public decimal F60051081
        {
            get { return F60051082 + F60051083 + F60051084 + F60051085; }
        }

        [DisplayName("Loyers ")] public decimal F60050082 { get; set; }
        public decimal F60051082 { get; set; }

        [DisplayName("Revenus de capitaux mobiliers")]
        public decimal F60050083 { get; set; }

        public decimal F60051083 { get; set; }

        [DisplayName("Dividendes de source étrangère")]
        public decimal F60050084 { get; set; }

        public decimal F60051084 { get; set; }

        [DisplayName("Autres revenus accessoires")]
        public decimal F60050085 { get; set; }

        public decimal F60051085 { get; set; }

        [DisplayName("Gains Exceptionnels")]
        public decimal F60050086
        {
            get { return F60050087 + F60050088 + F60050089 + F60050090; }
        }

        public decimal F60051086
        {
            get { return F60051087 + F60051088 + F60051089 + F60051090; }
        }

        [DisplayName("Plus value de cession des immeubles bâtis et non bâtis et des fonds de commerce")]
        public decimal F60050087 { get; set; }

        public decimal F60051087 { get; set; }

        [DisplayName("Gains de change non rattachés à l'activité principale")]
        public decimal F60050088 { get; set; }

        public decimal F60051088 { get; set; }

        [DisplayName("Plus value provenant de la cession des titres")]
        public decimal F60050089 { get; set; }

        public decimal F60051089 { get; set; }

        [DisplayName("Autres gains exceptionnels")]
        public decimal F60050090 { get; set; }

        public decimal F60051090 { get; set; }

        [DisplayName("Total")]
        public decimal F60050091
        {
            get { return F60050081 + F60050086; }
        }

        public decimal F60051091
        {
            get { return F60051081 + F60051086; }
        }

        [DisplayName(
            "Bénéfice servant de base pour la détermination de la quote-part des bénéfices provenant de l'exploitation déductible")]
        public decimal F60050092
        {
            get { return F60050080 - F60050091; }
        }

        public decimal F60051092
        {
            get { return F60051080 - F60051091; }
        }

        [DisplayName("Au titre de l'exportation")]
        public decimal F60050093 { get; set; }

        public decimal F60051093 { get; set; }

        [DisplayName("Au titre du développement régional")]
        public decimal F60050094 { get; set; }

        public decimal F60051094 { get; set; }

        [DisplayName("Au titre du développement agricole")]
        public decimal F60050095 { get; set; }

        public decimal F60051095 { get; set; }
        [DisplayName("Autres déductions")] public decimal F60050096 { get; set; }
        public decimal F60051096 { get; set; }

        [DisplayName("Total")]
        public decimal F60050097
        {
            get { return F60050093 + F60050094 + F60050095 + F60050096; }
        }

        public decimal F60051097
        {
            get { return F60051093 + F60051094 + F60051095 + F60051096; }
        }

        [DisplayName("Bénéfice fiscal après déduction des bénéfices au titre de l'exploitation")]
        public decimal F60050098
        {
            get { return F60050080 - F60050097; }
        }

        public decimal F60051098
        {
            get { return F60051080 - F60051097; }
        }

        [DisplayName("Déductions des revenus réinvestis")]
        public decimal F60050099 { get; set; }

        public decimal F60051099 { get; set; }

        [DisplayName(
            "Réintégration du cinquième de la plus-value provenant d’opérations de fusion,ission ou d’opérations d’apport (dans la limite de 50%) pour la société absorbante ou la société bénéficiaire de laission ou de l’apport d’entreprise individuelle.")]
        public decimal F60050100 { get; set; }

        public decimal F60051100 { get; set; }

        [DisplayName("Résultat imposable")]
        public decimal F60050101
        {
            get { return F60050098 - F60050099 + F60050100; }
        }

        public decimal F60051101
        {
            get { return F60051098 - F60051099 + F60051100; }
        }

        [DisplayName("Cas déficitaire / RÉSULTAT FISCAL")]
        public decimal F60050102
        {
            get
            {
                if ((F60050063 + F60050064 - F60050065 - F60050066 - F60050067) < 0)
                    return F60050063;
                return F60050955 > 0 ? 0 : F60050955;
            }
        }

        public decimal F60051102
        {
            get
            {
                if ((F60051063 + F60051064 - F60051065 - F60051066 - F60051067) < 0)
                    return F60051063;
                return F60051955 > 0 ? 0 : F60051955;
            }
        }

        [DisplayName("Réintégration des amortissements de l'exercice")]
        public decimal F60050103 { get; set; }

        public decimal F60051103 { get; set; }

        [DisplayName("Déduction des déficits reportés")]
        public decimal F60050104 { get; set; }

        public decimal F60051104 { get; set; }

        [DisplayName("Déduction des amortissements de l'exrcice")]
        public decimal F60050105 { get; set; }

        public decimal F60051105 { get; set; }

        [DisplayName("Déduction des amortissements diféfrés en périodes déficitaires")]
        public decimal F60050106 { get; set; }

        public decimal F60051106 { get; set; }

        [DisplayName("RÉSULTAT FISCAL (déficit reportable)")]
        public decimal F60050107
        {
            get { return F60050102 + F60050103 - F60050104 - F60050105 - F60050106; }
        }

        public decimal F60051107
        {
            get { return F60051102 + F60051103 - F60051104 - F60051105 - F60051106; }
        }

        [DisplayName("Autre résultat imposable (bénéfice exportation période supérieure à 10 ans)")]
        public decimal F60050108 { get; set; }

        public decimal F60051108 { get; set; }



        public List<string> getError()
        {
            List<string> msg = new List<string>();

            if (F60050003 != (F60050004 + F60050005 + F60050006 + F60050007 + F60050008 + F60050009 + +F60050010 + F60050011 + F60050012 + F60050013 + F60050014 + F60050015 + F60050016 + F60050017 + F60050018 + F60050019 + F60050020 + F60050021 + F60050022 + F60050023 + F60050024))
                msg.Add("F60050003 est  invalide ! F60050003 = F60050004 + F60050005 + F60050006 + F60050007 + F60050008 + F60050009 + +F60050010 + F60050011 + F60050012 + F60050013 + F60050014 + F60050015 + F60050016 + F60050017 + F60050018 + F60050019 + F60050020 + F60050021 + F60050022 + F60050023 + F60050024 ");

            if (F60050025 != (F60050026 + F60050027 + F60050028 + F60050029 + F60050030 + F60050031 + F60050032))
                msg.Add("F60050025 est  invalide ! F60050025 = F60050026 + F60050027 + F60050028 + F60050029 + F60050030 + F60050031 + F60050032 ");


            if (F60050033 != (F60050034 + F60050035 + F60050036 + F60050037 + F60050038))
                msg.Add("F60050033 est  invalide ! F60050033 = F60050034 + F60050035 + F60050036 + F60050037 + F60050038 ");

            if (F60050039 != (F60050040 + F60050041 + F60050042 + F60050043))
                msg.Add("F60050039 est  invalide ! F60050039 = F60050040 + F60050041 + F60050042 + F60050043");

            if (F60050045 != (F60050003 + F60050025 + F60050033 + F60050039 + F60050044))
                msg.Add("F60050045 est  invalide ! F60050045 = F60050003 + F60050025 + F60050033 + F60050039 + F60050044");

            if (F60050054 != (F60050046 + F60050047 + F60050048 + F60050049 + F60050050 + F60050051 + F60050052 + F60050053))
                msg.Add("F60050054 est  invalide ! F60050054 = F60050046 + F60050047 + F60050048 + F60050049 + F60050050 + F60050051 + F60050052 + F60050053");


            if (F60050955 < 0 && F60050068 != 0)
                msg.Add("F60050068 est  invalide !  F60050955 >=0 et F60050068 !=0");

            if (F60050063 + F60050064 - F60050065 < 0 && F60050068 != 0)
                msg.Add("F60050068 est  invalide ! F60050063 + F60050064 - F60050065 >=0 et F60050068 !=0");

            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050068 != 0)
                msg.Add("F60050068 est  invalide ! F60050063 + F60050064 - F60050065 - F60050066 >=0 et F60050068 !=0");

            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050068 != 0)
                msg.Add("F60050068 est  invalide ! F60050063 + F60050064 - F60050065 - F60050066 - F60050067 >=0 et F60050068 !=0");

            if (F60050068 != F60050063 + F60050064 - F60050065 - F60050066 - F60050067 || F60050068 != 0)
                msg.Add("F60050068 est  invalide ! F60050068 = F60050063 + F60050064 - F60050065 - F60050066 - F60050067  Ou F60050068 =0");

            if (F60050955 < 0 && F60050080 != 0)
                msg.Add("F60050080 est  invalide !  F60050955 >=0 et F60050080 !=0");


            if (F60050068
                - (F60050069 + F60050070 + F60050071 + F60050072 + F60050073 + F60050074 + F60050075 + F60050076 + F60050077 + F60050078 + F60050079) <= 0 && F60050080 != 0)

                msg.Add("F60050080 est  invalide !  F60050068 - (F60050069 + F60050070 + F60050071 + F60050072 + F60050073 + F60050074 + F60050075 + F60050076 + F60050077 + F60050078 + F60050079) >0 et F60050080 !=0");

            if (F60050063 + F60050064 - F60050065 < 0 && F60050080 != 0)
                msg.Add("F60050080 est  invalide !   F60050063 + F60050064 - F60050065 <0 et F60050080 !=0");

            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050080 != 0)
                msg.Add("F60050080 est  invalide !   F60050063 + F60050064 - F60050065 - F60050066 <0 et F60050080 !=0");

            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050080 != 0)
                msg.Add("F60050080 est  invalide !   F60050063 + F60050064 - F60050065 - F60050066 - F60050067 <0 et F60050080 !=0");

            if (F60050955 < 0 && F60050081 != 0)
                msg.Add("F60050081 est  invalide !   F60050955 >= 0 et F60050081 !=0");

            if (F60050063 + F60050064 - F60050065 < 0 && F60050081 != 0)
                msg.Add("F60050081 est  invalide !  F60050063 + F60050064 - F60050065 >=0 et F60050081 !=0");

            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050081 != 0)
                msg.Add("F60050081 est  invalide !  F60050063 + F60050064 - F60050065 -F60050066  >=0 et F60050081 !=0");

            if (F60050081 != F60050082 + F60050083 + F60050084 + F60050085 || F60050081 != 0)
                msg.Add("F60050081 est  invalide ! F60050081 = F60050082 + F60050083 + F60050084 + F60050085  Ou F60050081 = 0");

            if ((F60050955 < 0 && F60050056 != F60050045 + F60050002 - F60050054) || F60050056 != 0)

                msg.Add("F60050056 est  invalide ! F60050056 = F60050045+F60050002- F60050054  Ou F60050056 = 0");

            if ((F60050955 <= 0 && F60050056 != F60050955) || F60050056 != 0)

                msg.Add("F60050056 est  invalide ! F60050056 = F60050955 Ou F60050056 = 0");

            if (F60050955 < 0 || F60050057 != 0)
                msg.Add("F60050057 est  invalide ! F60050955 >= 0 Ou F60050057 = 0");

            //

            if (F60050955 < 0 || F60050058 != 0)
                msg.Add("F60050058 est  invalide ! F60050955>=0  Ou F60050058 = 0 ");
            if (F60050955 < 0 || F60050059 != 0)
                msg.Add("F60050059 est  invalide ! F60050955>=0  Ou F60050059 = 0 ");
            if (F60050955 < 0 || F60050060 != 0)
                msg.Add("F60050060 est  invalide ! F60050955>=0  Ou F60050060 = 0 ");
            if (F60050955 < 0 || F60050061 != 0)
                msg.Add("F60050061 est  invalide ! F60050955>=0  Ou F60050061 = 0 ");
            if (F60050955 < 0 || F60050062 != 0)
                msg.Add("F60050062 est  invalide ! F60050955>=0  Ou F60050062 = 0 ");
            if (F60050955 < 0 || F60050063 != 0)
                msg.Add("F60050063 est  invalide ! F60050955>=0  Ou F60050063 = 0 ");
            if (F60050955 < 0 || F60050064 != 0)
                msg.Add("F60050064 est  invalide ! F60050955>=0  Ou F60050064 = 0 ");
            if (F60050955 < 0 || F60050065 != 0)
                msg.Add("F60050065 est  invalide ! F60050955>=0  Ou F60050065 = 0 ");
            if (F60050955 < 0 || F60050066 != 0)
                msg.Add("F60050066 est  invalide ! F60050955>=0  Ou F60050066 = 0 ");
            if (F60050955 < 0 || F60050067 != 0)
                msg.Add("F60050067 est  invalide ! F60050955>=0  Ou F60050067 = 0 ");

            if (F60050955 < 0 || F60050069 != 0)
                msg.Add("F60050069 est  invalide ! F60050955>=0  Ou F60050069 = 0 ");
            if (F60050955 < 0 || F60050070 != 0)
                msg.Add("F60050070 est  invalide ! F60050955>=0  Ou F60050070 = 0 ");
            if (F60050955 < 0 || F60050071 != 0)
                msg.Add("F60050071 est  invalide ! F60050955>=0  Ou F60050071 = 0 ");
            if (F60050955 < 0 || F60050072 != 0)
                msg.Add("F60050072 est  invalide ! F60050955>=0  Ou F60050072 = 0 ");
            if (F60050955 < 0 || F60050073 != 0)
                msg.Add("F60050073 est  invalide ! F60050955>=0  Ou F60050073 = 0 ");
            if (F60050955 < 0 || F60050074 != 0)
                msg.Add("F60050074 est  invalide ! F60050955>=0  Ou F60050074 = 0 ");
            if (F60050955 < 0 || F60050075 != 0)
                msg.Add("F60050075 est  invalide ! F60050955>=0  Ou F60050075 = 0 ");
            if (F60050955 < 0 || F60050076 != 0)
                msg.Add("F60050076 est  invalide ! F60050955>=0  Ou F60050076 = 0 ");
            if (F60050955 < 0 || F60050077 != 0)
                msg.Add("F60050077 est  invalide ! F60050955>=0  Ou F60050077 = 0 ");
            if (F60050955 < 0 || F60050078 != 0)
                msg.Add("F60050078 est  invalide ! F60050955>=0  Ou F60050078 = 0 ");
            if (F60050955 < 0 || F60050079 != 0)
                msg.Add("F60050079 est  invalide ! F60050955>=0  Ou F60050079 = 0 ");

            if (F60050955 < 0 || F60050082 != 0)
                msg.Add("F60050082 est  invalide ! F60050955>=0  Ou F60050082 = 0 ");
            if (F60050955 < 0 || F60050083 != 0)
                msg.Add("F60050083 est  invalide ! F60050955>=0  Ou F60050083 = 0 ");
            if (F60050955 < 0 || F60050084 != 0)
                msg.Add("F60050084 est  invalide ! F60050955>=0  Ou F60050084 = 0 ");
            if (F60050955 < 0 || F60050085 != 0)
                msg.Add("F60050085 est  invalide ! F60050955>=0  Ou F60050085 = 0 ");
            if (F60050955 < 0 || F60050086 != 0)
                msg.Add("F60050086 est  invalide ! F60050955>=0  Ou F60050086 = 0 ");
            if (F60050955 < 0 || F60050087 != 0)
                msg.Add("F60050087 est  invalide ! F60050955>=0  Ou F60050087 = 0 ");
            if (F60050955 < 0 || F60050088 != 0)
                msg.Add("F60050088 est  invalide ! F60050955>=0  Ou F60050088 = 0 ");
            if (F60050955 < 0 || F60050089 != 0)
                msg.Add("F60050089 est  invalide ! F60050955>=0  Ou F60050089 = 0 ");
            if (F60050955 < 0 || F60050090 != 0)
                msg.Add("F60050090 est  invalide ! F60050955>=0  Ou F60050090 = 0 ");
            if (F60050955 < 0 || F60050091 != 0)
                msg.Add("F60050091 est  invalide ! F60050955>=0  Ou F60050091 = 0 ");
            if (F60050955 < 0 || F60050092 != 0)
                msg.Add("F60050092 est  invalide ! F60050955>=0  Ou F60050092 = 0 ");
            if (F60050955 < 0 || F60050093 != 0)
                msg.Add("F60050093 est  invalide ! F60050955>=0  Ou F60050093 = 0 ");
            if (F60050955 < 0 || F60050094 != 0)
                msg.Add("F60050094 est  invalide ! F60050955>=0  Ou F60050094 = 0 ");
            if (F60050955 < 0 || F60050095 != 0)
                msg.Add("F60050095 est  invalide ! F60050955>=0  Ou F60050095 = 0 ");
            if (F60050955 < 0 || F60050096 != 0)
                msg.Add("F60050096 est  invalide ! F60050955>=0  Ou F60050096 = 0 ");
            if (F60050955 < 0 || F60050097 != 0)
                msg.Add("F60050097 est  invalide ! F60050955>=0  Ou F60050097 = 0 ");
            if (F60050955 < 0 || F60050098 != 0)
                msg.Add("F60050098 est  invalide ! F60050955>=0  Ou F60050098 = 0 ");
            if (F60050955 < 0 || F60050099 != 0)
                msg.Add("F60050099 est  invalide ! F60050955>=0  Ou F60050099 = 0 ");

            if (F60050955 < 0 || F60050100 != 0)
                msg.Add("F60050100 est  invalide ! F60050955>=0  Ou F60050100 = 0 ");

            if (F60050955 < 0 || F60050101 != 0)
                msg.Add("F60050101 est  invalide ! F60050955>=0  Ou F60050101 = 0 ");

            if (((F60050061 - F60050062 > 0) && F60050063 != F60050061 - F60050062))

                msg.Add("F60050063 est  invalide ! F60050063 = F60050061- F60050062");
            else if (F60050063 != 0)
                msg.Add("F60050063 est  invalide ! F60050063 doit avoir 0 ");

            if (F60050063 + F60050064 - F60050065 < 0 && F60050066 != 0)
                msg.Add("F60050066 est  invalide ! F60050063+ F60050064- F60050065 >=0 et F60050066 !=0");
            //
            if (F60050063 + F60050064 - F60050065 < 0 && F60050067 != 0)
                msg.Add("F60050067 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050067 != 0 ");

            if (F60050063 + F60050064 - F60050065 < 0 && F60050069 != 0)
                msg.Add("F60050069 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050069 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050070 != 0)
                msg.Add("F60050070 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050070 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050071 != 0)
                msg.Add("F60050071 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050071 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050072 != 0)
                msg.Add("F60050072 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050072 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050073 != 0)
                msg.Add("F60050073 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050073 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050074 != 0)
                msg.Add("F60050074 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050074 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050075 != 0)
                msg.Add("F60050075 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050075 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050076 != 0)
                msg.Add("F60050076 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050076 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050077 != 0)
                msg.Add("F60050077 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050077 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050078 != 0)
                msg.Add("F60050078 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050078 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050079 != 0)
                msg.Add("F60050079 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050079 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050082 != 0)
                msg.Add("F60050082 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050082 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050083 != 0)
                msg.Add("F60050083 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050083 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050084 != 0)
                msg.Add("F60050084 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050084 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050085 != 0)
                msg.Add("F60050085 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050085 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050086 != 0)
                msg.Add("F60050086 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050086 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050087 != 0)
                msg.Add("F60050087 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050087 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050088 != 0)
                msg.Add("F60050088 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050088 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050089 != 0)
                msg.Add("F60050089 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050089 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050090 != 0)
                msg.Add("F60050090 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050090 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050091 != 0)
                msg.Add("F60050091 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050091 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050092 != 0)
                msg.Add("F60050092 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050092 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050093 != 0)
                msg.Add("F60050093 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050093 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050094 != 0)
                msg.Add("F60050094 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050094 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050095 != 0)
                msg.Add("F60050095 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050095 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050096 != 0)
                msg.Add("F60050096 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050096 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050097 != 0)
                msg.Add("F60050097 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050097 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050098 != 0)
                msg.Add("F60050098 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050098 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050099 != 0)
                msg.Add("F60050099 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050099 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050100 != 0)
                msg.Add("F60050100 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050100 != 0 ");
            if (F60050063 + F60050064 - F60050065 < 0 && F60050101 != 0)
                msg.Add("F60050101 est  invalide ! F60050063+ F60050064- F60050065 >=0  et  F60050101 != 0 ");

            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050067 != 0)
                msg.Add("F60050067 est  invalide ! F60050063 + F60050064 - F60050065- F60050066 >=0  et  F60050067 != 0 ");

            //

            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050069 != 0)
                msg.Add("F60050069 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050069 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050070 != 0)
                msg.Add("F60050070 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050070 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050071 != 0)
                msg.Add("F60050071 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050071 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050072 != 0)
                msg.Add("F60050072 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050072 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050073 != 0)
                msg.Add("F60050073 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050073 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050074 != 0)
                msg.Add("F60050074 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050074 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050075 != 0)
                msg.Add("F60050075 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050075 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050076 != 0)
                msg.Add("F60050076 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050076 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050077 != 0)
                msg.Add("F60050077 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050077 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050078 != 0)
                msg.Add("F60050078 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050078 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050079 != 0)
                msg.Add("F60050079 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050079 != 0 ");

            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050082 != 0)
                msg.Add("F60050082 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050082 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050083 != 0)
                msg.Add("F60050083 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050083 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050084 != 0)
                msg.Add("F60050084 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050084 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050085 != 0)
                msg.Add("F60050085 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050085 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050086 != 0)
                msg.Add("F60050086 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050086 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050087 != 0)
                msg.Add("F60050087 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050087 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050088 != 0)
                msg.Add("F60050088 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050088 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050089 != 0)
                msg.Add("F60050089 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050089 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050090 != 0)
                msg.Add("F60050090 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050090 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050091 != 0)
                msg.Add("F60050091 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050091 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050092 != 0)
                msg.Add("F60050092 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050092 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050093 != 0)
                msg.Add("F60050093 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050093 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050094 != 0)
                msg.Add("F60050094 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050094 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050095 != 0)
                msg.Add("F60050095 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050095 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050096 != 0)
                msg.Add("F60050096 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050096 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050097 != 0)
                msg.Add("F60050097 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050097 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050098 != 0)
                msg.Add("F60050098 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050098 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050099 != 0)
                msg.Add("F60050099 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050099 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050100 != 0)
                msg.Add("F60050100 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050100 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 < 0 && F60050101 != 0)
                msg.Add("F60050101 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 >=0  et  F60050101 != 0 ");

            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050069 != 0)
                msg.Add("F60050069 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 -F60050067 >=0  et  F60050069 != 0 ");

            //
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050070 != 0)
                msg.Add("F60050070 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050070 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050071 != 0)
                msg.Add("F60050071 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050071 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050072 != 0)
                msg.Add("F60050072 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050072 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050073 != 0)
                msg.Add("F60050073 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050073 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050074 != 0)
                msg.Add("F60050074 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050074 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050075 != 0)
                msg.Add("F60050075 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050075 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050076 != 0)
                msg.Add("F60050076 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050076 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050077 != 0)
                msg.Add("F60050077 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050077 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050078 != 0)
                msg.Add("F60050078 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050078 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050079 != 0)
                msg.Add("F60050079 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050079 != 0 ");

            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050081 != 0)
                msg.Add("F60050081 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050081 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050082 != 0)
                msg.Add("F60050082 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050082 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050083 != 0)
                msg.Add("F60050083 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050083 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050084 != 0)
                msg.Add("F60050084 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050084 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050085 != 0)
                msg.Add("F60050085 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050085 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050086 != 0)
                msg.Add("F60050086 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050086 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050087 != 0)
                msg.Add("F60050087 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050087 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050088 != 0)
                msg.Add("F60050088 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050088 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050089 != 0)
                msg.Add("F60050089 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050089 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050090 != 0)
                msg.Add("F60050090 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050090 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050091 != 0)
                msg.Add("F60050091 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050091 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050092 != 0)
                msg.Add("F60050092 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050092 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050093 != 0)
                msg.Add("F60050093 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050093 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050094 != 0)
                msg.Add("F60050094 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050094 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050095 != 0)
                msg.Add("F60050095 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050095 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050096 != 0)
                msg.Add("F60050096 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050096 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050097 != 0)
                msg.Add("F60050097 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050097 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050098 != 0)
                msg.Add("F60050098 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050098 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050099 != 0)
                msg.Add("F60050099 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050099 != 0 ");

            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050100 != 0)
                msg.Add("F60050100 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050100 != 0 ");
            if (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0 && F60050101 != 0)
                msg.Add("F60050101 est  invalide ! F60050063+ F60050064- F60050065 - F60050066 - F60050067 >=0  et  F60050101 != 0 ");

            if (F60050086 != F60050087 + F60050088 + F60050089 + F60050090 || F60050086 != 0)
                msg.Add("F60050086 est  invalide ! F60050086 = F60050087 + F60050088 + F60050089 + F60050090  Ou F60050086 = 0");

            if (F60050091 != F60050081 + F60050086 || F60050091 != 0)
                msg.Add("F60050091 est  invalide ! F60050091 = F60050081 + F60050086  Ou F60050091 = 0");

            if (F60050092 != F60050080 - F60050091 || F60050092 != 0)
                msg.Add("F60050092 est  invalide ! F60050092 = F60050080 - F60050091  Ou F60050092 = 0");
            if (F60050097 != F60050093 + F60050094 + F60050095 + F60050096 || F60050097 != 0)
                msg.Add("F60050097 est  invalide ! F60050097 = F60050093+ F60050094+ F60050095+ F60050096  Ou F60050097 = 0");
            if (F60050098 != F60050080 - F60050097 || F60050098 != 0)
                msg.Add("F60050098 est  invalide ! F60050098 = F60050080 - F60050097  Ou F60050098 = 0");

            if (F60050098 < 0 && F60050099 != 0)
                msg.Add("F60050099 est  invalide !  F60050098 >=0 et F60050099 !=0");

            if (F60050098 < 0 && F60050100 != 0)
                msg.Add("F60050100 est  invalide !  F60050098 >=0 et F60050100 !=0");

            if (F60050098 < 0 && F60050101 != 0)
                msg.Add("F60050101 est  invalide !  F60050098 >=0 et F60050101 !=0");

            if ((F60050098 < 0 && F60050101 != F60050098 - F60050099 + F60050100) || F60050101 != 0)

                msg.Add("F60050101 est  invalide ! F60050101 = F60050098 - F60050099 + F60050100  Ou F60050101 = 0");

            if (F60050107 != F60050102 + F60050103 - F60050104 - F60050105 - F60050106)
                msg.Add("F60050107 est  invalide ! F60050107 = F60050102+ F60050103- F60050104- F60050105- F60050106");


            //if (F60050955 < 0 || F60050103 != 0)
            //    msg.Add("F60050103 est  invalide ! F60050955>=0  Ou F60050103 = 0 ");
            //else
            //if (F60050063 + F60050064 - F60050065 >= 0 && F60050063 + F60050064 - F60050065 - F60050066 >= 0 && F60050063 + F60050064 - F60050065 - F60050066 - F60050067 >= 0)
            //    msg.Add("F60050103 est  invalide ! F60050063 + F60050064 - F60050065 <0 Ou F60050063 + F60050064 - F60050065 - F60050066 <0 Ou F60050063 + F60050064 - F60050065 - F60050066 -F60050067<0 ");
            //else

            if (F60051003 != F60051004 + F60051005 + F60051006 + F60051007 + F60051008 + F60051009 + F60051010 + F60051011 + F60051012 + F60051013 + F60051014 + F60051015 + F60051016 + F60051017 + F60051018 + F60051019 + F60051020 + F60051021 + F60051022 + F60051023 + F60051024)

                msg.Add("F60051003 est  invalide ! F60051003 = F60051004 + F60051005 + F60051006 + F60051007 + F60051008 + F60051009 + F60051010 + F60051011 + F60051012 + F60051013 + F60051014 + F60051015 + F60051016 + F60051017 + F60051018 + F60051019 + F60051020 + F60051021 + F60051022 + F60051023 + F60051024");

            if (F60051025 != F60051026 + F60051027 + F60051028 + F60051029 + F60051030 + F60051031 + F60051032)
                msg.Add("F60051025 est  invalide ! F60051025 = F60051026 + F60051027 + F60051028 + F60051029 + F60051030 + F60051031 + F60051032");

            if (F60051033 != F60051034 + F60051035 + F60051036 + F60051037 + F60051038)
                msg.Add("F60051033 est  invalide ! F60051033 = F60051034 + F60051035 + F60051036 + F60051037 + F60051038");

            if (F60051039 != F60051040 + F60051041 + F60051042 + F60051043)
                msg.Add("F60051039 est  invalide ! F60051039 = F60051040 + F60051041 + F60051042 + F60051043");
            if (F60051045 != F60051003 + F60051025 + F60051033 + F60051039 + F60051044)
                msg.Add("F60051045 est  invalide ! F60051045 = F60051003 + F60051025 + F60051033 + F60051039 + F60051044");
            if (F60051054 != F60051046 + F60051047 + F60051048 + F60051049 + F60051050 + F60051051 + F60051052 + F60051053)
                msg.Add("F60051054 est  invalide ! F60051054 = F60051046 + F60051047 + F60051048 + F60051049 + F60051050 + F60051051 + F60051052 + F60051053");

            if ((F60051955 < 0 && F60051068 != F60051955) || F60051068 != 0)
                msg.Add("F60051068 est  invalide ! F60051068 = F60051955 Ou F60051068 = 0");

            if (F60051063 + F60051064 - F60051065 < 0 && F60051068 != 0)
                msg.Add("F60051068 est  invalide ! F60051063 + F60051064 - F60051065 >=0  et  F60051068 != 0 ");

            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051068 != 0)
                msg.Add("F60051068 est  invalide ! F60051063 + F60051064 - F60051065 -F60051066 >=0  et  F60051068 != 0 ");

            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051068 != 0)
                msg.Add("F60051068 est  invalide ! F60051063 + F60051064 - F60051065 -F60051066 - F60051067 >=0  et  F60051068 != 0 ");

            if (F60051068 != F60051063 + F60051064 - F60051065 - F60051066 - F60051067 || F60051068 != 0)
                msg.Add("F60051068 est  invalide ! F60051068 = F60051063 + F60051064 - F60051065 - F60051066 - F60051067  Ou F60051068 = 0");

            if ((F60051955 < 0 && F60051080 != F60051955) || F60051080 != 0)
                msg.Add("F60051080 est  invalide ! F60051080 = F60051955 Ou F60051080 = 0");


            if ((F60051068 - (F60051069 + F60051070 + F60051071 + F60051072 + F60051073 + F60051074 + F60051075 + F60051076 + F60051077 + F60051078 + F60051079) > 0) && (F60051080 != F60051068 - (F60051069 + F60051070 + F60051071 + F60051072 + F60051073 + F60051074 + F60051075 + F60051076 + F60051077 + F60051078 + F60051079)))

                msg.Add("F60051080 est  invalide ! F60051080 = F60051068 - (F60051069 + F60051070 + F60051071 + F60051072 + F60051073 + F60051074 + F60051075 + F60051076 + F60051077 + F60051078 + F60051079)");
            else if (F60051080 != 0)
                msg.Add("F60051080 est  invalide ! F60051080 doit avoir 0 ");


            if (F60051063 + F60051064 - F60051065 < 0 && F60051080 != 0)
                msg.Add("F60051080 est  invalide ! F60051063 + F60051064 - F60051065 >=0  et  F60051080 != 0 ");

            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051080 != 0)
                msg.Add("F60051080 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 >=0  et  F60051080 != 0 ");

            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051080 != 0)
                msg.Add("F60051080 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 >=0  et  F60051080 != 0 ");

            if ((F60051955 < 0 && F60051081 != F60051955) || F60051081 != 0)
                msg.Add("F60051081 est  invalide ! F60051081 = F60051955 Ou F60051081 = 0");

            if (F60051063 + F60051064 - F60051065 < 0 && F60051081 != 0)
                msg.Add("F60051081 est  invalide ! F60051063 + F60051064 - F60051065  >=0  et  F60051081 != 0 ");

            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051081 != 0)
                msg.Add("F60051081 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 >=0  et  F60051081 != 0 ");

            if (F60051081 != F60051082 + F60051083 + F60051084 + F60051085 || F60051081 != 0)
                msg.Add("F60051081 est  invalide ! F60051081 = F60051082 + F60051083 + F60051084 + F60051085  Ou F60051081 = 0");


            if ((F60051955 < 0 && F60051056 != F60051002 + F60051045 - F60051054) || F60051056 != 0)

                msg.Add("F60051056 est  invalide ! F60051056 = F60051002 + F60051045 - F60051054  Ou F60051056 = 0");


            if ((F60051955 <= 0 && F60051056 != F60051955) || F60051056 != 0)

                msg.Add("F60051056 est  invalide ! F60051056 = F60051955 Ou F60051056 = 0");



            if (F60051955 < 0 || F60051057 != 0)
                msg.Add("F60051057 est  invalide ! F60051955 >= 0 Ou F60051057 = 0");

            //
            if (F60051955 < 0 || F60051058 != 0)
                msg.Add("F60051058 est  invalide ! F60051955 >=0  ou  F60051058 = 0 ");
            if (F60051955 < 0 || F60051059 != 0)
                msg.Add("F60051059 est  invalide ! F60051955 >=0  ou  F60051059 = 0 ");
            if (F60051955 < 0 || F60051060 != 0)
                msg.Add("F60051060 est  invalide ! F60051955 >=0  ou  F60051060 = 0 ");
            if (F60051955 < 0 || F60051061 != 0)
                msg.Add("F60051061 est  invalide ! F60051955 >=0  ou  F60051061 = 0 ");
            if (F60051955 < 0 || F60051062 != 0)
                msg.Add("F60051062 est  invalide ! F60051955 >=0  ou  F60051062 = 0 ");
            if (F60051955 < 0 || F60051063 != 0)
                msg.Add("F60051063 est  invalide ! F60051955 >=0  ou  F60051063 = 0 ");
            if (F60051955 < 0 || F60051064 != 0)
                msg.Add("F60051064 est  invalide ! F60051955 >=0  ou  F60051064 = 0 ");
            if (F60051955 < 0 || F60051065 != 0)
                msg.Add("F60051065 est  invalide ! F60051955 >=0  ou  F60051065 = 0 ");
            if (F60051955 < 0 || F60051066 != 0)
                msg.Add("F60051066 est  invalide ! F60051955 >=0  ou  F60051066 = 0 ");
            if (F60051955 < 0 || F60051067 != 0)
                msg.Add("F60051067 est  invalide ! F60051955 >=0  ou  F60051067 = 0 ");

            if (F60051955 < 0 || F60051069 != 0)
                msg.Add("F60051069 est  invalide ! F60051955 >=0  ou  F60051069 = 0 ");
            if (F60051955 < 0 || F60051070 != 0)
                msg.Add("F60051070 est  invalide ! F60051955 >=0  ou  F60051070 = 0 ");
            if (F60051955 < 0 || F60051071 != 0)
                msg.Add("F60051071 est  invalide ! F60051955 >=0  ou  F60051071 = 0 ");
            if (F60051955 < 0 || F60051072 != 0)
                msg.Add("F60051072 est  invalide ! F60051955 >=0  ou  F60051072 = 0 ");
            if (F60051955 < 0 || F60051073 != 0)
                msg.Add("F60051073 est  invalide ! F60051955 >=0  ou  F60051073 = 0 ");
            if (F60051955 < 0 || F60051074 != 0)
                msg.Add("F60051074 est  invalide ! F60051955 >=0  ou  F60051074 = 0 ");
            if (F60051955 < 0 || F60051075 != 0)
                msg.Add("F60051075 est  invalide ! F60051955 >=0  ou  F60051075 = 0 ");
            if (F60051955 < 0 || F60051076 != 0)
                msg.Add("F60051076 est  invalide ! F60051955 >=0  ou  F60051076 = 0 ");
            if (F60051955 < 0 || F60051077 != 0)
                msg.Add("F60051077 est  invalide ! F60051955 >=0  ou  F60051077 = 0 ");
            if (F60051955 < 0 || F60051078 != 0)
                msg.Add("F60051078 est  invalide ! F60051955 >=0  ou  F60051078 = 0 ");
            if (F60051955 < 0 || F60051079 != 0)
                msg.Add("F60051079 est  invalide ! F60051955 >=0  ou  F60051079 = 0 ");

            if (F60051955 < 0 || F60051082 != 0)
                msg.Add("F60051082 est  invalide ! F60051955 >=0  ou  F60051082 = 0 ");
            if (F60051955 < 0 || F60051083 != 0)
                msg.Add("F60051083 est  invalide ! F60051955 >=0  ou  F60051083 = 0 ");
            if (F60051955 < 0 || F60051084 != 0)
                msg.Add("F60051084 est  invalide ! F60051955 >=0  ou  F60051084 = 0 ");
            if (F60051955 < 0 || F60051085 != 0)
                msg.Add("F60051085 est  invalide ! F60051955 >=0  ou  F60051085 = 0 ");
            if (F60051955 < 0 || F60051086 != 0)
                msg.Add("F60051086 est  invalide ! F60051955 >=0  ou  F60051086 = 0 ");
            if (F60051955 < 0 || F60051087 != 0)
                msg.Add("F60051087 est  invalide ! F60051955 >=0  ou  F60051087 = 0 ");
            if (F60051955 < 0 || F60051088 != 0)
                msg.Add("F60051088 est  invalide ! F60051955 >=0  ou  F60051088 = 0 ");
            if (F60051955 < 0 || F60051089 != 0)
                msg.Add("F60051089 est  invalide ! F60051955 >=0  ou  F60051089 = 0 ");
            if (F60051955 < 0 || F60051090 != 0)
                msg.Add("F60051090 est  invalide ! F60051955 >=0  ou  F60051090 = 0 ");
            if (F60051955 < 0 || F60051091 != 0)
                msg.Add("F60051091 est  invalide ! F60051955 >=0  ou  F60051091 = 0 ");
            if (F60051955 < 0 || F60051092 != 0)
                msg.Add("F60051092 est  invalide ! F60051955 >=0  ou  F60051092 = 0 ");
            if (F60051955 < 0 || F60051093 != 0)
                msg.Add("F60051093 est  invalide ! F60051955 >=0  ou  F60051093 = 0 ");
            if (F60051955 < 0 || F60051094 != 0)
                msg.Add("F60051094 est  invalide ! F60051955 >=0  ou  F60051094 = 0 ");
            if (F60051955 < 0 || F60051095 != 0)
                msg.Add("F60051095 est  invalide ! F60051955 >=0  ou  F60051095 = 0 ");
            if (F60051955 < 0 || F60051096 != 0)
                msg.Add("F60051096 est  invalide ! F60051955 >=0  ou  F60051096 = 0 ");
            if (F60051955 < 0 || F60051097 != 0)
                msg.Add("F60051097 est  invalide ! F60051955 >=0  ou  F60051097 = 0 ");
            if (F60051955 < 0 || F60051098 != 0)
                msg.Add("F60051098 est  invalide ! F60051955 >=0  ou  F60051098 = 0 ");
            if (F60051955 < 0 || F60051099 != 0)
                msg.Add("F60051099 est  invalide ! F60051955 >=0  ou  F60051099 = 0 ");

            if (F60051955 < 0 || F60051100 != 0)
                msg.Add("F60051100 est  invalide ! F60051955 >=0  ou  F60051100 = 0 ");
            if (F60051955 < 0 || F60051101 != 0)
                msg.Add("F60051101 est  invalide ! F60051955 >=0  ou  F60051101 = 0 ");

            if (((F60051061 - F60051062 > 0) && F60051063 != F60051061 - F60051062))

                msg.Add("F60051063 est  invalide ! F60051063 = F60051061 - F60051062");
            else if (F60051063 != 0)
                msg.Add("F60051063 est  invalide ! F60051063 doit avoir 0 ");

            // 
            if (F60051063 + F60051064 - F60051065 < 0 && F60051066 != 0)
                msg.Add("F60051066 est  invalide !   F60051063 + F60051064 - F60051065 <0 et F60051066 !=0");

            if (F60051063 + F60051064 - F60051065 < 0 && F60051067 != 0)
                msg.Add("F60051067 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051067 != 0 ");

            if (F60051063 + F60051064 - F60051065 < 0 && F60051069 != 0)
                msg.Add("F60051069 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051069 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051070 != 0)
                msg.Add("F60051070 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051070 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051071 != 0)
                msg.Add("F60051071 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051071 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051072 != 0)
                msg.Add("F60051072 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051072 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051073 != 0)
                msg.Add("F60051073 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051073 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051074 != 0)
                msg.Add("F60051074 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051074 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051075 != 0)
                msg.Add("F60051075 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051075 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051076 != 0)
                msg.Add("F60051076 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051076 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051077 != 0)
                msg.Add("F60051077 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051077 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051078 != 0)
                msg.Add("F60051078 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051078 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051079 != 0)
                msg.Add("F60051079 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051079 != 0 ");

            if (F60051063 + F60051064 - F60051065 < 0 && F60051082 != 0)
                msg.Add("F60051082 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051082 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051083 != 0)
                msg.Add("F60051083 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051083 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051084 != 0)
                msg.Add("F60051084 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051084 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051085 != 0)
                msg.Add("F60051085 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051085 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051086 != 0)
                msg.Add("F60051086 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051086 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051087 != 0)
                msg.Add("F60051087 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051087 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051088 != 0)
                msg.Add("F60051088 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051088 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051089 != 0)
                msg.Add("F60051089 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051089 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051090 != 0)
                msg.Add("F60051090 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051090 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051091 != 0)
                msg.Add("F60051091 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051091 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051092 != 0)
                msg.Add("F60051092 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051092 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051093 != 0)
                msg.Add("F60051093 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051093 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051094 != 0)
                msg.Add("F60051094 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051094 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051095 != 0)
                msg.Add("F60051095 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051095 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051096 != 0)
                msg.Add("F60051096 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051096 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051097 != 0)
                msg.Add("F60051097 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051097 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051098 != 0)
                msg.Add("F60051098 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051098 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051099 != 0)
                msg.Add("F60051099 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051099 != 0 ");

            if (F60051063 + F60051064 - F60051065 < 0 && F60051100 != 0)
                msg.Add("F60051100 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051100 != 0 ");
            if (F60051063 + F60051064 - F60051065 < 0 && F60051101 != 0)
                msg.Add("F60051101 est  invalide ! F60051063 + F60051064 - F60051065 <0 et F60051101 != 0 ");
            //
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051067 != 0)
                msg.Add("F60051067 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051067 != 0 ");

            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051069 != 0)
                msg.Add("F60051069 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051069 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051070 != 0)
                msg.Add("F60051070 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051070 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051071 != 0)
                msg.Add("F60051071 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051071 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051072 != 0)
                msg.Add("F60051072 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051072 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051073 != 0)
                msg.Add("F60051073 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051073 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051074 != 0)
                msg.Add("F60051074 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051074 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051075 != 0)
                msg.Add("F60051075 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051075 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051076 != 0)
                msg.Add("F60051076 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051076 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051077 != 0)
                msg.Add("F60051077 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051077 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051078 != 0)
                msg.Add("F60051078 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051078 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051079 != 0)
                msg.Add("F60051079 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051079 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051082 != 0)
                msg.Add("F60051082 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051082 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051083 != 0)
                msg.Add("F60051083 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051083 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051084 != 0)
                msg.Add("F60051084 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051084 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051085 != 0)
                msg.Add("F60051085 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051085 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051086 != 0)
                msg.Add("F60051086 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051086 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051087 != 0)
                msg.Add("F60051087 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051087 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051088 != 0)
                msg.Add("F60051088 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051088 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051089 != 0)
                msg.Add("F60051089 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051089 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051090 != 0)
                msg.Add("F60051090 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051090 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051091 != 0)
                msg.Add("F60051091 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051091 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051092 != 0)
                msg.Add("F60051092 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051092 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051093 != 0)
                msg.Add("F60051093 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051093 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051094 != 0)
                msg.Add("F60051094 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051094 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051095 != 0)
                msg.Add("F60051095 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051095 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051096 != 0)
                msg.Add("F60051096 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051096 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051097 != 0)
                msg.Add("F60051097 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051097 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051098 != 0)
                msg.Add("F60051098 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051098 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051099 != 0)
                msg.Add("F60051099 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051099 != 0 ");

            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051100 != 0)
                msg.Add("F60051100 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051100 != 0 ");

            if (F60051063 + F60051064 - F60051065 - F60051066 < 0 && F60051101 != 0)
                msg.Add("F60051101 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 <0 et F60051101 != 0 ");
            //
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051069 != 0)
                msg.Add("F60051069 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051069 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051070 != 0)
                msg.Add("F60051070 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051070 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051071 != 0)
                msg.Add("F60051071 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051071 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051072 != 0)
                msg.Add("F60051072 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051072 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051073 != 0)
                msg.Add("F60051073 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051073 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051074 != 0)
                msg.Add("F60051074 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051074 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051075 != 0)
                msg.Add("F60051075 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051075 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051076 != 0)
                msg.Add("F60051076 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051076 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051077 != 0)
                msg.Add("F60051077 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051077 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051078 != 0)
                msg.Add("F60051078 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051078 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051079 != 0)
                msg.Add("F60051079 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051079 != 0 ");

            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051081 != 0)
                msg.Add("F60051081 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051081 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051082 != 0)
                msg.Add("F60051082 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051082 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051083 != 0)
                msg.Add("F60051083 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051083 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051084 != 0)
                msg.Add("F60051084 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051084 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051085 != 0)
                msg.Add("F60051085 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051085 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051086 != 0)
                msg.Add("F60051086 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051086 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051087 != 0)
                msg.Add("F60051087 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051087 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051088 != 0)
                msg.Add("F60051088 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051088 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051089 != 0)
                msg.Add("F60051089 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051089 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051090 != 0)
                msg.Add("F60051090 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051090 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051091 != 0)
                msg.Add("F60051091 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051091 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051092 != 0)
                msg.Add("F60051092 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051092 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051093 != 0)
                msg.Add("F60051093 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051093 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051094 != 0)
                msg.Add("F60051094 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051094 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051095 != 0)
                msg.Add("F60051095 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051095 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051096 != 0)
                msg.Add("F60051096 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051096 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051097 != 0)
                msg.Add("F60051097 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051097 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051098 != 0)
                msg.Add("F60051098 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051098 != 0 ");
            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051099 != 0)
                msg.Add("F60051099 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051099 != 0 ");

            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051100 != 0)
                msg.Add("F60051100 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051100 != 0 ");

            if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F60051101 != 0)
                msg.Add("F60051101 est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F60051101 != 0 ");


            if (F60051086 != F60051087 + F60051088 + F60051089 + F60051090 || F60051086 != 0)
                msg.Add("F60051086 est  invalide ! F60051086 = F60051087 + F60051088 + F60051089 + F60051090  Ou F60051086 = 0");

            if (F60051091 != F60051081 + F60051086 || F60051091 != 0)
                msg.Add("F60051091 est  invalide ! F60051091 = F60051081 + F60051086  Ou F60051091 = 0");

            if (F60051092 != F60051080 - F60051091 || F60051092 != 0)
                msg.Add("F60051092 est  invalide ! F60051092 = F60051080 - F60051091  Ou F60051092 = 0");

            if (F60051097 != F60051093 + F60051094 + F60051095 + F60051096 || F60051097 != 0)
                msg.Add("F60051097 est  invalide ! F60051097 = F60051093 + F60051094 + F60051095 + F60051096  Ou F60051097 = 0");

            if (F60051098 != F60051080 - F60051097 || F60051098 != 0)
                msg.Add("F60051098 est  invalide ! F60051098 = F60051080 - F60051097  Ou F60051098 = 0");


            if (F60051098 < 0 || F60051099 != 0)
                msg.Add("F60051099 est  invalide ! F60051098 >=0  ou  F60051099 = 0 ");

            if (F60051098 < 0 || F60051100 != 0)
                msg.Add("F60051100 est  invalide ! F60051098 >=0  ou  F60051100 = 0 ");

            if (F60051098 < 0 || F60051101 != 0)
                msg.Add("F60051101 est  invalide ! F60051098 >=0  ou  F60051101 = 0 ");


            if ((F60051098 < 0 && F60051101 != F60051098 - F60051099 + F60051100) || F60051101 != 0)

                msg.Add("F60051101 est  invalide ! F60051101 = F60051098 - F60051099 + F60051100  Ou F60051101 = 0");

            if (F60051107 != F60051102 + F60051103 - F60051104 - F60051105 - F60051106)
                msg.Add("F60051107 est  invalide ! F60051107 = F60051102 + F60051103 - F60051104 - F60051105 - F60051106  ");


            if (F60051955 >= 0)
                if (((F60051063 + F60051064 - F60051065 < 0) || (F60051063 + F60051064 - F60051065 - F60051066 < 0) || (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0)) && F60051064 != F60051103)
                    msg.Add("F60051103 est  invalide !  F60051063 + F60051064 - F60051065 <0 Ou F60051063 + F60051064 - F60051065 - F60051066 <0 Ou F60051063 + F60051064 - F60051065 - F60051066 -F60051067<0  ,F60051103 doit égale à F60051064 ");

            if (F60051955 >= 0)
                if (((F60051063 + F60051064 - F60051065 < 0) || (F60051063 + F60051064 - F60051065 - F60051066 < 0) || (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0)) && F60051065 != F60051104)
                    msg.Add("F60051104 est  invalide !  F60051063 + F60051064 - F60051065 <0 Ou F60051063 + F60051064 - F60051065 - F60051066 <0 Ou F60051063 + F60051064 - F60051065 - F60051066 -F60051067<0  ,F60051104 doit égale à F60051065 ");

            if (F60051955 >= 0 || (F60051063 + F60051064 - F60051065 >= 0))
                if (((F60051063 + F60051064 - F60051065 < 0) || (F60051063 + F60051064 - F60051065 - F60051066 < 0) || (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0)) && F60051066 != F60051105)
                    msg.Add("F60051105 est  invalide !  F60051063 + F60051064 - F60051065 <0 Ou F60051063 + F60051064 - F60051065 - F60051066 <0 Ou F60051063 + F60051064 - F60051065 - F60051066 -F60051067<0  ,F60051105 doit égale à F60051066 ");


            if (F60051955 >= 0 || (F60051063 + F60051064 - F60051065 >= 0) || (F60051063 + F60051064 - F60051065 - F60051066 >= 0))

                if (((F60051063 + F60051064 - F60051065 < 0) || (F60051063 + F60051064 - F60051065 - F60051066 < 0) || (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0)) && F60051067 != F60051106)
                    msg.Add("F60051106 est  invalide !  F60051063 + F60051064 - F60051065 <0 Ou F60051063 + F60051064 - F60051065 - F60051066 <0 Ou F60051063 + F60051064 - F60051065 - F60051066 -F60051067<0  ,F60051106 doit égale à F60051067 ");


            //

            if (F60050955 >= 0)
                if (((F60050063 + F60050064 - F60050065 < 0) || (F60050063 + F60050064 - F60050065 - F60050066 < 0) || (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0)) && F60050064 != F60050103)
                    msg.Add("F60050103 est  invalide !  F60050063 + F60050064 - F60050065 <0 Ou F60050063 + F60050064 - F60050065 - F60050066 <0 Ou F60050063 + F60050064 - F60050065 - F60050066 -F60050067<0  ,F60050103 doit égale à F60050064 ");

            if (F60050955 >= 0)
                if (((F60050063 + F60050064 - F60050065 < 0) || (F60050063 + F60050064 - F60050065 - F60050066 < 0) || (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0)) && F60050065 != F60050104)
                    msg.Add("F60050104 est  invalide !  F60050063 + F60050064 - F60050065 <0 Ou F60050063 + F60050064 - F60050065 - F60050066 <0 Ou F60050063 + F60050064 - F60050065 - F60050066 -F60050067<0  ,F60050104 doit égale à F60050065 ");

            if (F60050955 >= 0 || (F60050063 + F60050064 - F60050065 >= 0))
                if (((F60050063 + F60050064 - F60050065 < 0) || (F60050063 + F60050064 - F60050065 - F60050066 < 0) || (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0)) && F60050066 != F60050105)
                    msg.Add("F60050105 est  invalide !  F60050063 + F60050064 - F60050065 <0 Ou F60050063 + F60050064 - F60050065 - F60050066 <0 Ou F60050063 + F60050064 - F60050065 - F60050066 -F60050067<0  ,F60050105 doit égale à F60050066 ");


            if (F60050955 >= 0 || (F60050063 + F60050064 - F60050065 >= 0) || (F60050063 + F60050064 - F60050065 - F60050066 >= 0))

                if (((F60050063 + F60050064 - F60050065 < 0) || (F60050063 + F60050064 - F60050065 - F60050066 < 0) || (F60050063 + F60050064 - F60050065 - F60050066 - F60050067 < 0)) && F60050067 != F60050106)
                    msg.Add("F60050106 est  invalide !  F60050063 + F60050064 - F60050065 <0 Ou F60050063 + F60050064 - F60050065 - F60050066 <0 Ou F60050063 + F60050064 - F60050065 - F60050066 -F60050067<0  ,F60050106 doit égale à F60050067 ");




            return msg;
        }

        public string ToXML(Models.Societe ste, Models.Exercice ex)
        {
            // Models.Societe sos = TVS.
            string r = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
<lf:F6005 xmlns:lf=""http://www.impots.finances.gov.tn/liasse"" xmlns:vc=""http://www.w3.org/2007/XMLSchema-versioning"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://www.impots.finances.gov.tn/liasse F6005.xsd"">
	<lf:VersionDocument>String</lf:VersionDocument>
	<lf:Entete>
		<lf:MatriculeFiscalDeclarant>{ste.MatriculFiscal}{ste.MatriculCle}{ste.MatriculCodeTva}{ste.MatriculCategorie}{
                    ste.MatriculEtablissement
                }</lf:MatriculeFiscalDeclarant>
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
        <lf:F60050000 categorie=""{this.F60050000Categorie}"" codeformejuridique=""{
                    this.F60050000Codeformejuridique
                }"" />
        <lf:F60050001 resultat=""{this.F60050001}"" F60050002=""{this.F60050002 * 1000:0}""/>
        <lf:F60050003>{this.F60050003 * 1000:0}</lf:F60050003>
        <lf:F60050004>{this.F60050004 * 1000:0}</lf:F60050004>
        <lf:F60050005>{this.F60050005 * 1000:0}</lf:F60050005>
        <lf:F60050006>{this.F60050006 * 1000:0}</lf:F60050006>
        <lf:F60050007>{this.F60050007 * 1000:0}</lf:F60050007>
        <lf:F60050008>{this.F60050008 * 1000:0}</lf:F60050008>
        <lf:F60050009>{this.F60050009 * 1000:0}</lf:F60050009>
        <lf:F60050010>{this.F60050010 * 1000:0}</lf:F60050010>
        <lf:F60050011>{this.F60050011 * 1000:0}</lf:F60050011>
        <lf:F60050012>{this.F60050012 * 1000:0}</lf:F60050012>
        <lf:F60050013>{this.F60050013 * 1000:0}</lf:F60050013>
        <lf:F60050014>{this.F60050014 * 1000:0}</lf:F60050014>
        <lf:F60050015>{this.F60050015 * 1000:0}</lf:F60050015>
        <lf:F60050016>{this.F60050016 * 1000:0}</lf:F60050016>
        <lf:F60050017>{this.F60050017 * 1000:0}</lf:F60050017>
        <lf:F60050018>{this.F60050018 * 1000:0}</lf:F60050018>
        <lf:F60050019>{this.F60050019 * 1000:0}</lf:F60050019>
        <lf:F60050020>{this.F60050020 * 1000:0}</lf:F60050020>
        <lf:F60050021>{this.F60050021 * 1000:0}</lf:F60050021>
        <lf:F60050022>{this.F60050022 * 1000:0}</lf:F60050022>
        <lf:F60050023>{this.F60050023 * 1000:0}</lf:F60050023>
        <lf:F60050024>{this.F60050024 * 1000:0}</lf:F60050024>
        <lf:F60050025>{this.F60050025 * 1000:0}</lf:F60050025>
        <lf:F60050026>{this.F60050026 * 1000:0}</lf:F60050026>
        <lf:F60050027>{this.F60050027 * 1000:0}</lf:F60050027>
        <lf:F60050028>{this.F60050028 * 1000:0}</lf:F60050028>
        <lf:F60050029>{this.F60050029 * 1000:0}</lf:F60050029>
        <lf:F60050030>{this.F60050030 * 1000:0}</lf:F60050030>
        <lf:F60050031>{this.F60050031 * 1000:0}</lf:F60050031>
        <lf:F60050032>{this.F60050032 * 1000:0}</lf:F60050032>
        <lf:F60050033>{this.F60050033 * 1000:0}</lf:F60050033>
        <lf:F60050034>{this.F60050034 * 1000:0}</lf:F60050034>
        <lf:F60050035>{this.F60050035 * 1000:0}</lf:F60050035>
        <lf:F60050036>{this.F60050036 * 1000:0}</lf:F60050036>
        <lf:F60050037>{this.F60050037 * 1000:0}</lf:F60050037>
        <lf:F60050038>{this.F60050038 * 1000:0}</lf:F60050038>
        <lf:F60050039>{this.F60050039 * 1000:0}</lf:F60050039>
        <lf:F60050040>{this.F60050040 * 1000:0}</lf:F60050040>
        <lf:F60050041>{this.F60050041 * 1000:0}</lf:F60050041>
        <lf:F60050042>{this.F60050042 * 1000:0}</lf:F60050042>
        <lf:F60050043>{this.F60050043 * 1000:0}</lf:F60050043>
        <lf:F60050044>{this.F60050044 * 1000:0}</lf:F60050044>
        <lf:F60050045>{this.F60050045 * 1000:0}</lf:F60050045>
        <lf:F60050046>{this.F60050046 * 1000:0}</lf:F60050046>
        <lf:F60050047>{this.F60050047 * 1000:0}</lf:F60050047>
        <lf:F60050048>{this.F60050048 * 1000:0}</lf:F60050048>
        <lf:F60050049>{this.F60050049 * 1000:0}</lf:F60050049>
        <lf:F60050050>{this.F60050050 * 1000:0}</lf:F60050050>
        <lf:F60050051>{this.F60050051 * 1000:0}</lf:F60050051>
        <lf:F60050052>{this.F60050052 * 1000:0}</lf:F60050052>
        <lf:F60050053>{this.F60050053 * 1000:0}</lf:F60050053>
        <lf:F60050054>{this.F60050054 * 1000:0}</lf:F60050054>
        <lf:F60050055 resultat=""{this.F60050055}"" F60050955=""{this.F60050955 * 1000:0}"" />
        <lf:F60050056>{this.F60050056 * 1000:0}</lf:F60050056>
        <lf:F60050057>{this.F60050057 * 1000:0}</lf:F60050057>
        <lf:F60050058>{this.F60050058 * 1000:0}</lf:F60050058>
        <lf:F60050059>{this.F60050059 * 1000:0}</lf:F60050059>
        <lf:F60050060>{this.F60050060 * 1000:0}</lf:F60050060>
        <lf:F60050061>{this.F60050061 * 1000:0}</lf:F60050061>
        <lf:F60050062>{this.F60050062 * 1000:0}</lf:F60050062>
        <lf:F60050063>{this.F60050063 * 1000:0}</lf:F60050063>
        <lf:F60050064>{this.F60050064 * 1000:0}</lf:F60050064>
        <lf:F60050065>{this.F60050065 * 1000:0}</lf:F60050065>
        <lf:F60050066>{this.F60050066 * 1000:0}</lf:F60050066>
        <lf:F60050067>{this.F60050067 * 1000:0}</lf:F60050067>
        <lf:F60050068>{this.F60050068 * 1000:0}</lf:F60050068>
        <lf:F60050069>{this.F60050069 * 1000:0}</lf:F60050069>
        <lf:F60050070>{this.F60050070 * 1000:0}</lf:F60050070>
        <lf:F60050071>{this.F60050071 * 1000:0}</lf:F60050071>
        <lf:F60050072>{this.F60050072 * 1000:0}</lf:F60050072>
        <lf:F60050073>{this.F60050073 * 1000:0}</lf:F60050073>
        <lf:F60050074>{this.F60050074 * 1000:0}</lf:F60050074>
        <lf:F60050075>{this.F60050075 * 1000:0}</lf:F60050075>
        <lf:F60050076>{this.F60050076 * 1000:0}</lf:F60050076>
        <lf:F60050077>{this.F60050077 * 1000:0}</lf:F60050077>
        <lf:F60050078>{this.F60050078 * 1000:0}</lf:F60050078>
        <lf:F60050079>{this.F60050079 * 1000:0}</lf:F60050079>
        <lf:F60050080>{this.F60050080 * 1000:0}</lf:F60050080>
        <lf:F60050081>{this.F60050081 * 1000:0}</lf:F60050081>
        <lf:F60050082>{this.F60050082 * 1000:0}</lf:F60050082>
        <lf:F60050083>{this.F60050083 * 1000:0}</lf:F60050083>
        <lf:F60050084>{this.F60050084 * 1000:0}</lf:F60050084>
        <lf:F60050085>{this.F60050085 * 1000:0}</lf:F60050085>
        <lf:F60050086>{this.F60050086 * 1000:0}</lf:F60050086>
        <lf:F60050087>{this.F60050087 * 1000:0}</lf:F60050087>
        <lf:F60050088>{this.F60050088 * 1000:0}</lf:F60050088>
        <lf:F60050089>{this.F60050089 * 1000:0}</lf:F60050089>
        <lf:F60050090>{this.F60050090 * 1000:0}</lf:F60050090>
        <lf:F60050091>{this.F60050091 * 1000:0}</lf:F60050091>
        <lf:F60050092>{this.F60050092 * 1000:0}</lf:F60050092>
        <lf:F60050093>{this.F60050093 * 1000:0}</lf:F60050093>
        <lf:F60050094>{this.F60050094 * 1000:0}</lf:F60050094>
        <lf:F60050095>{this.F60050095 * 1000:0}</lf:F60050095>
        <lf:F60050096>{this.F60050096 * 1000:0}</lf:F60050096>
        <lf:F60050097>{this.F60050097 * 1000:0}</lf:F60050097>
        <lf:F60050098>{this.F60050098 * 1000:0}</lf:F60050098>
        <lf:F60050099>{this.F60050099 * 1000:0}</lf:F60050099>
        <lf:F60050100>{this.F60050100 * 1000:0}</lf:F60050100>
        <lf:F60050101>{this.F60050101 * 1000:0}</lf:F60050101>
        <lf:F60050102>{this.F60050102 * 1000:0}</lf:F60050102>
        <lf:F60050103>{this.F60050103 * 1000:0}</lf:F60050103>
        <lf:F60050104>{this.F60050104 * 1000:0}</lf:F60050104>
        <lf:F60050105>{this.F60050105 * 1000:0}</lf:F60050105>
        <lf:F60050106>{this.F60050106 * 1000:0}</lf:F60050106>
        <lf:F60050107>{this.F60050107 * 1000:0}</lf:F60050107>
        <lf:F60050108>{this.F60050108 * 1000:0}</lf:F60050108>
          <lf:F60051000 categorie=""{this.F60050000Categorie}"" codeformejuridique=""{
                    this.F60050000Codeformejuridique
                }"" />
        <lf:F60051001 resultat=""{this.F60051001}"" F60051002=""{this.F60051002 * 1000:0}""/>
        <lf:F60051003>{this.F60051003 * 1000:0}</lf:F60051003>
        <lf:F60051004>{this.F60051004 * 1000:0}</lf:F60051004>
        <lf:F60051005>{this.F60051005 * 1000:0}</lf:F60051005>
        <lf:F60051006>{this.F60051006 * 1000:0}</lf:F60051006>
        <lf:F60051007>{this.F60051007 * 1000:0}</lf:F60051007>
        <lf:F60051008>{this.F60051008 * 1000:0}</lf:F60051008>
        <lf:F60051009>{this.F60051009 * 1000:0}</lf:F60051009>
        <lf:F60051010>{this.F60051010 * 1000:0}</lf:F60051010>
        <lf:F60051011>{this.F60051011 * 1000:0}</lf:F60051011>
        <lf:F60051012>{this.F60051012 * 1000:0}</lf:F60051012>
        <lf:F60051013>{this.F60051013 * 1000:0}</lf:F60051013>
        <lf:F60051014>{this.F60051014 * 1000:0}</lf:F60051014>
        <lf:F60051015>{this.F60051015 * 1000:0}</lf:F60051015>
        <lf:F60051016>{this.F60051016 * 1000:0}</lf:F60051016>
        <lf:F60051017>{this.F60051017 * 1000:0}</lf:F60051017>
        <lf:F60051018>{this.F60051018 * 1000:0}</lf:F60051018>
        <lf:F60051019>{this.F60051019 * 1000:0}</lf:F60051019>
        <lf:F60051020>{this.F60051020 * 1000:0}</lf:F60051020>
        <lf:F60051021>{this.F60051021 * 1000:0}</lf:F60051021>
        <lf:F60051022>{this.F60051022 * 1000:0}</lf:F60051022>
        <lf:F60051023>{this.F60051023 * 1000:0}</lf:F60051023>
        <lf:F60051024>{this.F60051024 * 1000:0}</lf:F60051024>
        <lf:F60051025>{this.F60051025 * 1000:0}</lf:F60051025>
        <lf:F60051026>{this.F60051026 * 1000:0}</lf:F60051026>
        <lf:F60051027>{this.F60051027 * 1000:0}</lf:F60051027>
        <lf:F60051028>{this.F60051028 * 1000:0}</lf:F60051028>
        <lf:F60051029>{this.F60051029 * 1000:0}</lf:F60051029>
        <lf:F60051030>{this.F60051030 * 1000:0}</lf:F60051030>
        <lf:F60051031>{this.F60051031 * 1000:0}</lf:F60051031>
        <lf:F60051032>{this.F60051032 * 1000:0}</lf:F60051032>
        <lf:F60051033>{this.F60051033 * 1000:0}</lf:F60051033>
        <lf:F60051034>{this.F60051034 * 1000:0}</lf:F60051034>
        <lf:F60051035>{this.F60051035 * 1000:0}</lf:F60051035>
        <lf:F60051036>{this.F60051036 * 1000:0}</lf:F60051036>
        <lf:F60051037>{this.F60051037 * 1000:0}</lf:F60051037>
        <lf:F60051038>{this.F60051038 * 1000:0}</lf:F60051038>
        <lf:F60051039>{this.F60051039 * 1000:0}</lf:F60051039>
        <lf:F60051040>{this.F60051040 * 1000:0}</lf:F60051040>
        <lf:F60051041>{this.F60051041 * 1000:0}</lf:F60051041>
        <lf:F60051042>{this.F60051042 * 1000:0}</lf:F60051042>
        <lf:F60051043>{this.F60051043 * 1000:0}</lf:F60051043>
        <lf:F60051044>{this.F60051044 * 1000:0}</lf:F60051044>
        <lf:F60051045>{this.F60051045 * 1000:0}</lf:F60051045>
        <lf:F60051046>{this.F60051046 * 1000:0}</lf:F60051046>
        <lf:F60051047>{this.F60051047 * 1000:0}</lf:F60051047>
        <lf:F60051048>{this.F60051048 * 1000:0}</lf:F60051048>
        <lf:F60051049>{this.F60051049 * 1000:0}</lf:F60051049>
        <lf:F60051050>{this.F60051050 * 1000:0}</lf:F60051050>
        <lf:F60051051>{this.F60051051 * 1000:0}</lf:F60051051>
        <lf:F60051052>{this.F60051052 * 1000:0}</lf:F60051052>
        <lf:F60051053>{this.F60051053 * 1000:0}</lf:F60051053>
        <lf:F60051054>{this.F60051054 * 1000:0}</lf:F60051054>
        <lf:F60051055 resultat=""{this.F60051055}"" F60051955=""{this.F60051955 * 1000:0}"" />
        <lf:F60051056>{this.F60051056 * 1000:0}</lf:F60051056>
        <lf:F60051057>{this.F60051057 * 1000:0}</lf:F60051057>
        <lf:F60051058>{this.F60051058 * 1000:0}</lf:F60051058>
        <lf:F60051059>{this.F60051059 * 1000:0}</lf:F60051059>
        <lf:F60051060>{this.F60051060 * 1000:0}</lf:F60051060>
        <lf:F60051061>{this.F60051061 * 1000:0}</lf:F60051061>
        <lf:F60051062>{this.F60051062 * 1000:0}</lf:F60051062>
        <lf:F60051063>{this.F60051063 * 1000:0}</lf:F60051063>
        <lf:F60051064>{this.F60051064 * 1000:0}</lf:F60051064>
        <lf:F60051065>{this.F60051065 * 1000:0}</lf:F60051065>
        <lf:F60051066>{this.F60051066 * 1000:0}</lf:F60051066>
        <lf:F60051067>{this.F60051067 * 1000:0}</lf:F60051067>
        <lf:F60051068>{this.F60051068 * 1000:0}</lf:F60051068>
        <lf:F60051069>{this.F60051069 * 1000:0}</lf:F60051069>
        <lf:F60051070>{this.F60051070 * 1000:0}</lf:F60051070>
        <lf:F60051071>{this.F60051071 * 1000:0}</lf:F60051071>
        <lf:F60051072>{this.F60051072 * 1000:0}</lf:F60051072>
        <lf:F60051073>{this.F60051073 * 1000:0}</lf:F60051073>
        <lf:F60051074>{this.F60051074 * 1000:0}</lf:F60051074>
        <lf:F60051075>{this.F60051075 * 1000:0}</lf:F60051075>
        <lf:F60051076>{this.F60051076 * 1000:0}</lf:F60051076>
        <lf:F60051077>{this.F60051077 * 1000:0}</lf:F60051077>
        <lf:F60051078>{this.F60051078 * 1000:0}</lf:F60051078>
        <lf:F60051079>{this.F60051079 * 1000:0}</lf:F60051079>
        <lf:F60051080>{this.F60051080 * 1000:0}</lf:F60051080>
        <lf:F60051081>{this.F60051081 * 1000:0}</lf:F60051081>
        <lf:F60051082>{this.F60051082 * 1000:0}</lf:F60051082>
        <lf:F60051083>{this.F60051083 * 1000:0}</lf:F60051083>
        <lf:F60051084>{this.F60051084 * 1000:0}</lf:F60051084>
        <lf:F60051085>{this.F60051085 * 1000:0}</lf:F60051085>
        <lf:F60051086>{this.F60051086 * 1000:0}</lf:F60051086>
        <lf:F60051087>{this.F60051087 * 1000:0}</lf:F60051087>
        <lf:F60051088>{this.F60051088 * 1000:0}</lf:F60051088>
        <lf:F60051089>{this.F60051089 * 1000:0}</lf:F60051089>
        <lf:F60051090>{this.F60051090 * 1000:0}</lf:F60051090>
        <lf:F60051091>{this.F60051091 * 1000:0}</lf:F60051091>
        <lf:F60051092>{this.F60051092 * 1000:0}</lf:F60051092>
        <lf:F60051093>{this.F60051093 * 1000:0}</lf:F60051093>
        <lf:F60051094>{this.F60051094 * 1000:0}</lf:F60051094>
        <lf:F60051095>{this.F60051095 * 1000:0}</lf:F60051095>
        <lf:F60051096>{this.F60051096 * 1000:0}</lf:F60051096>
        <lf:F60051097>{this.F60051097 * 1000:0}</lf:F60051097>
        <lf:F60051098>{this.F60051098 * 1000:0}</lf:F60051098>
        <lf:F60051099>{this.F60051099 * 1000:0}</lf:F60051099>
        <lf:F60051100>{this.F60051100 * 1000:0}</lf:F60051100>
        <lf:F60051101>{this.F60051101 * 1000:0}</lf:F60051101>
        <lf:F60051102>{this.F60051102 * 1000:0}</lf:F60051102>
        <lf:F60051103>{this.F60051103 * 1000:0}</lf:F60051103>
        <lf:F60051104>{this.F60051104 * 1000:0}</lf:F60051104>
        <lf:F60051105>{this.F60051105 * 1000:0}</lf:F60051105>
        <lf:F60051106>{this.F60051106 * 1000:0}</lf:F60051106>
        <lf:F60051107>{this.F60051107 * 1000:0}</lf:F60051107>
        <lf:F60051108>{this.F60051108 * 1000:0}</lf:F60051108>
    </lf:Details>
</lf:F6005>";
            return r;
        }

        public Dictionary<string, string> Valider()
        {
            Dictionary<string, string> r = new Dictionary<string, string>();


            bool c10, c11, c20, c21, c30, c31, c40, c41, c50, c51;
            c10 = c11 = c20 = c21 = c30 = c31 = c40 = c41 = c50 = c51 = false;
            Cas1:
            if (F60050955 < 0)
            {
                c10 = true;
                /*F60050056 =*/
                F60050057 = F60050058 = F60050059 = 0;
                F60050060 = /*F60050061 =*/ F60050062 = /*F60050063 = */
                    F60050064 = F60050065 = F60050066 = F60050067 = /*F60050068 = F60050068 =*/ 0;
                F60050070 = F60050071 = F60050072 = F60050073 =
                    F60050074 = F60050075 = F60050076 = F60050077 = F60050078 = F60050079 = 0;
                /* F60050080 = F60050081 =*/
                F60050082 = F60050083 =
                    F60050084 = F60050085 = /*F60050086 = */F60050087 = /*F60050080 = F60050080 =*/ 0;
                F60050090 = /*F60050091 = F60050092 = */F60050093 =
                    F60050094 = F60050095 = F60050096 = /*F60050097 =*/ /*F60050098 =*/ F60050099 = 0;
                F60050100 = /*F60050101 = */ 0;
            }

            if (F60051955 < 0)
            {
                c11 = true;
                /*F60051056 =*/
                F60051057 = F60051058 = F60051059 = 0;
                F60051060 = /*F60051061 =*/ F60051062 = /*F60051063 = */
                    F60051064 = F60051065 = F60051066 = F60051067 = /*F60051068 = F60051068 =*/ 0;
                F60051070 = F60051071 = F60051072 = F60051073 =
                    F60051074 = F60051075 = F60051076 = F60051077 = F60051078 = F60051079 = 0;
                /* F60051080 = F60051081 =*/
                F60051082 = F60051083 =
                    F60051084 = F60051085 = /*F60051086 = */F60051087 = /*F60051080 = F60051080 =*/ 0;
                F60051090 = /*F60051091 = F60051092 = */F60051093 =
                    F60051094 = F60051095 = F60051096 = /*F60051097 =*/ /*F60051098 =*/ F60051099 = 0;
                F60051100 = /*F60051101 = */ 0;
            }


            Cas2:
            if ((F60050063 + F60050064 - F60050065) < 0)
            {
                c20 = true;
                F60050066 = F60050067 = /*F60050068 = F60050068 =*/ 0;
                F60050070 = F60050071 = F60050072 = F60050073 =
                    F60050074 = F60050075 = F60050076 = F60050077 = F60050078 = F60050079 = 0;
                /* F60050080 = F60050081 =*/
                F60050082 = F60050083 =
                    F60050084 = F60050085 = /*F60050086 = */F60050087 = /*F60050080 = F60050080 =*/ 0;
                F60050090 = /*F60050091 = F60050092 = */F60050093 =
                    F60050094 = F60050095 = F60050096 = /*F60050097 =*/ /*F60050098 =*/ F60050099 = 0;
                F60050100 = /*F60050101 = */ 0;
            }

            if ((F60051063 + F60051064 - F60051065) < 0)
            {
                c21 = true;
                F60051066 = F60051067 = /*F60051068 = F60051068 =*/ 0;
                F60051070 = F60051071 = F60051072 = F60051073 =
                    F60051074 = F60051075 = F60051076 = F60051077 = F60051078 = F60051079 = 0;
                /* F60051080 = F60051081 =*/
                F60051082 = F60051083 =
                    F60051084 = F60051085 = /*F60051086 = */F60051087 = /*F60051080 = F60051080 =*/ 0;
                F60051090 = /*F60051091 = F60051092 = */F60051093 =
                    F60051094 = F60051095 = F60051096 = /*F60051097 =*/ /*F60051098 =*/ F60051099 = 0;
                F60051100 = /*F60051101 = */ 0;
            }

            cas3:
            if ((F60050063 + F60050064 - F60050065 - F60050066) < 0)
            {
                c30 = true;
                F60050067 = /*F60050068 = F60050068 =*/ 0;
                F60050070 = F60050071 = F60050072 = F60050073 =
                    F60050074 = F60050075 = F60050076 = F60050077 = F60050078 = F60050079 = 0;
                /* F60050080 = F60050081 =*/
                F60050082 = F60050083 =
                    F60050084 = F60050085 = /*F60050086 = */F60050087 = /*F60050080 = F60050080 =*/ 0;
                F60050090 = /*F60050091 = F60050092 = */F60050093 =
                    F60050094 = F60050095 = F60050096 = /*F60050097 =*/ /*F60050098 =*/ F60050099 = 0;
                F60050100 = /*F60050101 = */ 0;
            }

            if ((F60051063 + F60051064 - F60051065 - F60051066) < 0)
            {
                c31 = true;
                F60051067 = /*F60051068 = F60051068 =*/ 0;
                F60051070 = F60051071 = F60051072 = F60051073 =
                    F60051074 = F60051075 = F60051076 = F60051077 = F60051078 = F60051079 = 0;
                /* F60051080 = F60051081 =*/
                F60051082 = F60051083 =
                    F60051084 = F60051085 = /*F60051086 = */F60051087 = /*F60051080 = F60051080 =*/ 0;
                F60051090 = /*F60051091 = F60051092 = */F60051093 =
                    F60051094 = F60051095 = F60051096 = /*F60051097 =*/ /*F60051098 =*/ F60051099 = 0;
                F60051100 = /*F60051101 = */ 0;
            }

            cas4:
            if ((F60050063 + F60050064 - F60050065 - F60050066 - F60050067) < 0)
            {
                c40 = true;
                /*F60050068 = F60050068 =0;*/

                F60050070 = F60050071 = F60050072 = F60050073 =
                    F60050074 = F60050075 = F60050076 = F60050077 = F60050078 = F60050079 = 0;
                /* F60050080 = F60050081 =*/
                F60050082 = F60050083 =
                    F60050084 = F60050085 = /*F60050086 = */F60050087 = /*F60050080 = F60050080 =*/ 0;
                F60050090 = /*F60050091 = F60050092 = */F60050093 =
                    F60050094 = F60050095 = F60050096 = /*F60050097 =*/ /*F60050098 =*/ F60050099 = 0;
                F60050100 = /*F60050101 = */ 0;
            }

            if ((F60051063 + F60051064 - F60051065 - F60051066 - F60051067) < 0)
            {
                c41 = true;
                /*F60051068 = F60051068 =0;*/

                F60051070 = F60051071 = F60051072 = F60051073 =
                    F60051074 = F60051075 = F60051076 = F60051077 = F60051078 = F60051079 = 0;
                /* F60051080 = F60051081 =*/
                F60051082 = F60051083 =
                    F60051084 = F60051085 = /*F60051086 = */F60051087 = /*F60051080 = F60051080 =*/ 0;
                F60051090 = /*F60051091 = F60051092 = */F60051093 =
                    F60051094 = F60051095 = F60051096 = /*F60051097 =*/ /*F60051098 =*/ F60051099 = 0;
                F60051100 = /*F60051101 = */ 0;
            }


            cas5:
            if (F60050098 < 0)
            {
                c50 = true;
                F60050099 = 0;
                F60050100 = /*F60050101 = */ 0;
            }

            if (F60051098 < 0)
            {
                c51 = true;
                F60051099 = 0;
                F60051100 = /*F60051101 = */ 0;
            }


            if (c10)
            {
                if (F60050103 == 0)
                {
                    r.Add("F60050103", "");
                }
                else if (c20 || c30 || c40) F60050103 = F60050064;

                if (F60050104 == 0)
                {
                    r.Add("F60050104", "");
                }
                else if (c20 || c30 || c40) F60050104 = F60050065;

                if (F60050105 == 0)
                {
                    r.Add("F60050105", "");
                }
                else if (c20 || c30 || c40) F60050105 = F60050066;


                if (F60050106 == 0)
                {
                    r.Add("F60050106", "");
                }
                else if (c20 || c30 || c40)
                {
                    F60050106 = F60050067;
                }
            }


            if (c11)
            {
                if (F60051103 == 0)
                {
                    r.Add("F60051103", "");
                }
                else if (c21 || c31 || c41) F60051103 = F60051064;

                if (F60051104 == 0)
                {
                    r.Add("F60051104", "");
                }
                else if (c21 || c31 || c41) F60051104 = F60051065;

                if (F60051105 == 0)
                {
                    r.Add("F60051105", "");
                }
                else if (c21 || c31 || c41) F60051105 = F60051066;


                if (F60051106 == 0)
                {
                    r.Add("F60051106", "");
                }
                else if (c21 || c31 || c41)
                {
                    F60051106 = F60051067;
                }
            }


            return r;
        }
    }
}