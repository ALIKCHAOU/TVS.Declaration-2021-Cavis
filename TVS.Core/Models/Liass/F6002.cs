using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Core.Models.Liass
{
    public partial class F6002
    {
        public int Id { get; set; }
        public int SocieteNo { get; set; }
        public int ExerciceId { get; set; }
        [DisplayName("Acte de dépot")]
        public int ActeDeDepot { get; set; }
        [DisplayName("Nature de dépot")]
        public string NatureDepot { get; set; }
        [DisplayName("Capitaux propres.")] public decimal F60020001 { get { return F60020006 + F60020007; } }
        [DisplayName("")] public decimal F60020054 { get { return F60020059 + F60020060; } }
        [DisplayName("Capital social")] public decimal F60020002 { get; set; }
        [DisplayName("")] public decimal F60020055 { get; set; }
        [DisplayName("Réserves ")] public decimal F60020003 { get; set; }
        [DisplayName("")] public decimal F60020056 { get; set; }
        [DisplayName("Autres capitaux propres  ")] public decimal F60020004 { get; set; }
        [DisplayName("")] public decimal F60020057 { get; set; }
        [DisplayName("Résultats reportés ")] public decimal F60020005 { get; set; }
        [DisplayName("")] public decimal F60020058 { get; set; }
        [DisplayName("Capitaux propres avant résultat de l'exercice")]
        public decimal F60020006 { get { return F60020002 + F60020003 + F60020004 + F60020005; } }
        [DisplayName("")]
        public decimal F60020059 { get { return F60020055 + F60020056 + F60020057 + F60020058; } }
        [DisplayName("Résultat de l'exercice  ")] public decimal F60020007 { get; set; }
        [DisplayName("")] public decimal F60020060 { get; set; }
        [DisplayName("Total Passifs  .")] public decimal F60020008 { get { return F60020009 + F60020031; } }
        [DisplayName("")] public decimal F60020061 { get { return F60020062 + F60020084; } }
        [DisplayName("Passifs non courants.")] public decimal F60020009 { get { return F60020010 + F60020019 + F60020022; } }
        [DisplayName("")] public decimal F60020062 { get { return F60020063 + F60020072 + F60020075; } }
        [DisplayName("Emprunts.")] public decimal F60020010 { get { return F60020011 + F60020012 + F60020013 + F60020014 + F60020015 + F60020016 + F60020017 + F60020018; } }
        [DisplayName("")] public decimal F60020063 { get { return F60020064 + F60020065 + F60020066 + F60020067 + F60020068 + F60020069 + F60020070 + F60020071; } }
        [DisplayName("Emprunts obligataires (assortis de seretés)  ")] public decimal F60020011 { get; set; }
        [DisplayName("")] public decimal F60020064 { get; set; }
        [DisplayName("Empts auprès d'étab.Fin. (assortis de séretés) ")] public decimal F60020012 { get; set; }
        [DisplayName("")] public decimal F60020065 { get; set; }
        [DisplayName("Empts auprès d'étab°Fin° (assorti de sûretés)")] public decimal F60020013 { get; set; }
        [DisplayName("")] public decimal F60020066 { get; set; }
        [DisplayName("Empts et dettes assorties de condit° particulières")] public decimal F60020014 { get; set; }
        [DisplayName("")] public decimal F60020067 { get; set; }
        [DisplayName("Emprunts non assortis de sûretés")] public decimal F60020015 { get; set; }
        [DisplayName("")]
        public decimal F60020068 { get; set; }
        [DisplayName("Dettes rattachées à des participations")]
        public decimal F60020016 { get; set; }
        [DisplayName("")]
        public decimal F60020069 { get; set; }
        [DisplayName("Dépôts & cautionnements reçus")]
        public decimal F60020017 { get; set; }
        [DisplayName("")]
        public decimal F60020070 { get; set; }
        [DisplayName("Autres emprunts et dettes")] public decimal F60020018 { get; set; }
        [DisplayName("")]
        public decimal F60020071 { get; set; }
        [DisplayName("Autres Passifs Financiers")]
        public decimal F60020019 { get { return F60020020 + F60020021; } }
        [DisplayName("")]
        public decimal F60020072 { get { return F60020073 + F60020074; } }
        [DisplayName("Provisions pour risques")]
        public decimal F60020020 { get; set; }
        [DisplayName("")] public decimal F60020073 { get; set; }
        [DisplayName("Prov° pour charges à répartir/plusieurs exercices")]
        public decimal F60020021 { get; set; }
        [DisplayName("")] public decimal F60020074 { get; set; }
        [DisplayName("Provisions")]
        public decimal F60020022 { get { return F60020023 + F60020024 + F60020025 + F60020026 + F60020027 + F60020028 + F60020029 + F60020030; } }
        [DisplayName("")]
        public decimal F60020075 { get { return F60020076 + F60020077 + F60020078 + F60020079 + F60020080 + F60020081 + F60020082 + F60020083; } }

        [DisplayName("Provisions pour risques")]
        public decimal F60020023 { get; set; }
        [DisplayName("")] public decimal F60020076 { get; set; }
        [DisplayName("Prov° pour charges à répartir/plusieurs exercices ")] public decimal F60020024 { get; set; }
        [DisplayName("")] public decimal F60020077 { get; set; }
        [DisplayName("Prov°pour retraites et obligations similaires")] public decimal F60020025 { get; set; }
        [DisplayName("")] public decimal F60020078 { get; set; }
        [DisplayName("Provisions d'origine réglementaire")] public decimal F60020026 { get; set; }
        [DisplayName("")] public decimal F60020079 { get; set; }
        [DisplayName("Provisions pour impôts")] public decimal F60020027 { get; set; }
        [DisplayName("")] public decimal F60020080 { get; set; }
        [DisplayName("Prov°pour renouvellement des immobilisations")] public decimal F60020028 { get; set; }
        [DisplayName("")] public decimal F60020081 { get; set; }
        [DisplayName("Provisions pour amortissement")] public decimal F60020029 { get; set; }
        [DisplayName("")] public decimal F60020082 { get; set; }
        [DisplayName("Provisions pour amortissement")] public decimal F60020030 { get; set; }
        [DisplayName("")] public decimal F60020083 { get; set; }
        [DisplayName("Passifs courants")]
        public decimal F60020031 { get { return F60020032 + F60020038 + F60020047; } }
        [DisplayName("")] public decimal F60020084 { get { return F60020085 + F60020091 + F60020100; } }
        [DisplayName("Fournisseurs et Comptes Rattachés")] public decimal F60020032 { get { return F60020033 + F60020034 + F60020035 + F60020036 + F60020037; } }
        [DisplayName("")]
        public decimal F60020085 { get { return F60020086 + F60020087 + F60020088 + F60020089 + F60020090; } }
        [DisplayName("Fournisseurs d'exploitation")] public decimal F60020033 { get; set; }
        [DisplayName("")] public decimal F60020086 { get; set; }
        [DisplayName("Fournisseurs d'exploitation - effets à payer")] public decimal F60020034 { get; set; }
        [DisplayName("")] public decimal F60020087 { get; set; }
        [DisplayName("Fournisseurs d'immobilisations")] public decimal F60020035 { get; set; }
        [DisplayName("")] public decimal F60020088 { get; set; }
        [DisplayName("Fournisseurs d'immobilisations - effets à payer")] public decimal F60020036 { get; set; }
        [DisplayName("")] public decimal F60020089 { get; set; }
        [DisplayName("Fournisseurs - factures non parvenues")] public decimal F60020037 { get; set; }
        [DisplayName("")] public decimal F60020090 { get; set; }
        [DisplayName("utres passifs courants")]
        public decimal F60020038 { get { return F60020039 + F60020040 + F60020041 + F60020042 + F60020043 + F60020044 + F60020045 + F60020046; } }
        [DisplayName("")]
        public decimal F60020091 { get { return F60020092 + F60020093 + F60020094 + F60020095 + F60020096 + F60020097 + F60020098 + F60020099; } }
        [DisplayName("Clients créditeurs")] public decimal F60020039 { get; set; }
        [DisplayName("")] public decimal F60020092 { get; set; }
        [DisplayName("Sociétés du groupe & associés")] public decimal F60020040 { get; set; }
        [DisplayName("")] public decimal F60020093 { get; set; }
        [DisplayName("État et collectivités publiques")] public decimal F60020041 { get; set; }
        [DisplayName("")] public decimal F60020094 { get; set; }
        [DisplayName("Rémunérations dues au personnel")] public decimal F60020042 { get; set; }
        [DisplayName("")] public decimal F60020095 { get; set; }
        [DisplayName("Débiteurs divers et Créditeurs divers")] public decimal F60020043 { get; set; }
        [DisplayName("")] public decimal F60020096 { get; set; }
        [DisplayName("Comptes transitoires ou d'attente")] public decimal F60020044 { get; set; }
        [DisplayName("")] public decimal F60020097 { get; set; }
        [DisplayName("Comptes de régularisation")] public decimal F60020045 { get; set; }
        [DisplayName("")] public decimal F60020098 { get; set; }
        [DisplayName("Provisions courantes pour risques et charges")] public decimal F60020046 { get; set; }
        [DisplayName("")] public decimal F60020099 { get; set; }
        [DisplayName("Concours Bancaires et Autres Passifs Financiers")] public decimal F60020047 { get { return F60020048 + F60020049 + F60020050 + F60020051; } }
        [DisplayName("")] public decimal F60020100 { get { return F60020101 + F60020102 + F60020103 + F60020104; } }
        [DisplayName("Emprunts et autres dettes financières courants")] public decimal F60020048 { get; set; }
        [DisplayName("")] public decimal F60020101 { get; set; }
        [DisplayName("Emprunts échus et impayés")] public decimal F60020049 { get; set; }
        [DisplayName("")] public decimal F60020102 { get; set; }
        [DisplayName("Intérêts courus")] public decimal F60020050 { get; set; }
        [DisplayName("")] public decimal F60020103 { get; set; }
        [DisplayName("Banques établissements financiers et assimilés")] public decimal F60020051 { get; set; }
        [DisplayName("")] public decimal F60020104 { get; set; }
        [DisplayName("Autres Postes des Capitaux Propres&Passifs du Bilan")]
        public decimal F60020052 { get; set; }
        [DisplayName("")]
        public decimal F60020105 { get; set; }
        [DisplayName("Total des capitaux propres et des passifs")]
        public decimal F60020053
        {
            get { return F60020001 + F60020008 + F60020052; }
        }
        [DisplayName("")]
        public decimal F60020106
        {
            get { return F60020054 + F60020061 + F60020105; }

        }



        public List<string> getError()
        {
            List<string> msg = new List<string>();

            if (F60020001 != (F60020006 + F60020007))
                msg.Add("F60020001 est  invalide ! F60020001 = F60020006 + F60020007 ");
            if (F60020006 != (F60020002 + F60020003 + F60020004 + F60020005))
                msg.Add("F60020006 est  invalide ! F60020006 = F60020002 + F60020003 + F60020004 + F60020005");

            if (F60020008 != (F60020009 + F60020031))
                msg.Add("F60020008 est  invalide ! F60020008 = F60020009 + F60020031");

            if (F60020009 != (F60020010 + F60020019 + F60020022))
                msg.Add("F60020009 est  invalide ! F60020009 = F60020010 + F60020019 + F60020022");

            if (F60020010 != (F60020011 + F60020012 + F60020013 + F60020014 + F60020015 + F60020016 + F60020017 + F60020018))
                msg.Add("F60020010 est  invalide ! F60020010 = F60020011 + F60020012 + F60020013 + F60020014 + F60020015 + F60020016 + F60020017 + F60020018");

            if (F60020019 != (F60020020 + F60020021))
                msg.Add("F60020019 est  invalide ! F60020019 = F60020020 + F60020021");

            if (F60020022 != (F60020023 + F60020024 + F60020025 + F60020026 + F60020027 + F60020028 + F60020029 + F60020030))
                msg.Add("F60020022 est  invalide ! F60020022 = F60020023 + F60020024 + F60020025 + F60020026 + F60020027 + F60020028 + F60020029 + F60020030");

            if (F60020031 != (F60020032 + F60020038 + F60020047))
                msg.Add("F60020031 est  invalide ! F60020031 = F60020032 + F60020038 + F60020047");

            if (F60020032 != (F60020033 + F60020034 + F60020035 + F60020036 + F60020037))
                msg.Add("F60020032 est  invalide ! F60020032 = F60020033 + F60020034 + F60020035 + F60020036 + F60020037");

            if (F60020038 != (F60020039 + F60020040 + F60020041 + F60020042 + F60020043 + F60020044 + F60020045 + F60020046))
                msg.Add("F60020038 est  invalide ! F60020038 = F60020039 + F60020040 + F60020041 + F60020042 + F60020043 + F60020044 + F60020045 + F60020046");
            if (F60020047 != (F60020048 + F60020049 + F60020050 + F60020051))
                msg.Add("F60020047 est  invalide ! F60020047 = F60020048 + F60020049 + F60020050 + F60020051");

            if (F60020053 != (F60020001 + F60020008 + F60020052))
                msg.Add("F60020053 est  invalide ! F60020053 = F60020001 + F60020008 + F60020052");

            if (F60020054 != (F60020059 + F60020060))
                msg.Add("F60020054 est  invalide ! F60020054 = F60020059 + F60020060");

            if (F60020059 != (F60020055 + F60020056 + F60020057 + F60020058))
                msg.Add("F60020059 est  invalide ! F60020059 = F60020055 + F60020056 + F60020057 + F60020058");
            if (F60020061 != (F60020062 + F60020084))
                msg.Add("F60020061 est  invalide ! F60020061 = F60020062 + F60020084");

            if (F60020062 != (F60020063 + F60020072 + F60020075))
                msg.Add("F60020062 est  invalide ! F60020062 = F60020063 + F60020072 + F60020075");

            if (F60020063 != (F60020064 + F60020065 + F60020066 + F60020067 + F60020068 + F60020069 + F60020070 + F60020071))
                msg.Add("F60020063 est  invalide ! F60020063 = F60020064 + F60020065 + F60020066 + F60020067 + F60020068 + F60020069 + F60020070 + F60020071");

            if (F60020072 != (F60020073 + F60020074))
                msg.Add("F60020072 est  invalide ! F60020072 = F60020073 + F60020074");

            if (F60020075 != (F60020076 + F60020077 + F60020078 + F60020079 + F60020080 + F60020081 + F60020082 + F60020083))
                msg.Add("F60020075 est  invalide ! F60020075 = F60020076 + F60020077 + F60020078 + F60020079 + F60020080 + F60020081 + F60020082 + F60020083");

            if (F60020084 != (F60020085 + F60020091 + F60020100))
                msg.Add("F60020084 est  invalide ! F60020084 = F60020085 + F60020091 + F60020100");

            if (F60020085 != (F60020086 + F60020087 + F60020088 + F60020089 + F60020090))
                msg.Add("F60020085 est  invalide ! F60020085 = F60020086 + F60020087 + F60020088 + F60020089 + F60020090");

            if (F60020091 != (F60020092 + F60020093 + F60020094 + F60020095 + F60020096 + F60020097 + F60020098 + F60020099))
                msg.Add("F60020091 est  invalide ! F60020091 = F60020092 + F60020093 + F60020094 + F60020095 + F60020096 + F60020097 + F60020098 + F60020099");

            if (F60020100 != (F60020101 + F60020102 + F60020103 + F60020104))
                msg.Add("F60020100 est  invalide ! F60020100 = F60020101 + F60020102 + F60020103 + F60020104");

            if (F60020106 != (F60020054 + F60020061 + F60020105))
                msg.Add("F60020106 est  invalide ! F60020106 = F60020054 + F60020061 + F60020105 ");

            return msg;
        }
    }
}
