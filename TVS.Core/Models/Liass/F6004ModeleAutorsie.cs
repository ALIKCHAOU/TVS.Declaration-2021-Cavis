using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Core.Models.Liass
{
    public partial class F6004ModeleAutorsie
    {
        public int Id { get; set; }
        public int SocieteNo { get; set; }
        public int ExerciceId { get; set; }
        [DisplayName("Acte de dépot")]
        public int ActeDeDepot { get; set; }
        [DisplayName("Nature de dépot")]
        public string NatureDepot { get; set; }

        [DisplayName("Flux de Trésorerie provenant de (affectés à) l'Exploitation")]
        public decimal F60040001 { get
            {
                return F60040002 + F60040003 + F60040004 + F60040005 + F60040006 + F60040007 + F60040008 + F60040009 + F60040010;
            } }
        public decimal F60041001 { get
        {
            return F60041002 + F60041003 + F60041004 + F60041005 + F60041006 + F60041007 + F60041008 + F60041009 +F60041010;
        } }
        [DisplayName("Résultat net")]
        public decimal F60040002 { get; set; }
        public decimal F60041002 { get; set; }
        [DisplayName("Ajustement amortissement et provision")]
        public decimal F60040003 { get; set; }
        public decimal F60041003 { get; set; }
        [DisplayName("Variation des stocks")]
        public decimal F60040004 { get; set; }
        public decimal F60041004 { get; set; }
        [DisplayName("Variation des créances")]
        public decimal F60040005 { get; set; }
        public decimal F60041005 { get; set; }
        [DisplayName("Variation des autres actifs")]
        public decimal F60040006 { get; set; }
        public decimal F60041006 { get; set; }
        [DisplayName("Variation des fournisseurs et autres dettes")]
        public decimal F60040007 { get; set; }
        public decimal F60041007 { get; set; }
        [DisplayName("Ajustement plus au moins values de cession")]
        public decimal F60040008 { get; set; }
        public decimal F60041008 { get; set; }
        [DisplayName("Ajustement transfert des charges")]
        public decimal F60040009 { get; set; }
        public decimal F60041009 { get; set; }
        [DisplayName("Ajustement transfert des charges")]
        public decimal F60040010 { get; set; }
        public decimal F60041010 { get; set; }
        [DisplayName("Flux de Trésorerie provenant de (affectés aux)  activités d'Investissement")]
        public decimal F60040011 { get { return F60040012 + F60040013 + F60040014 + F60040015+ F60040016; } }
        public decimal F60041011 { get { return F60041012 + F60041013 + F60041014 + F60041015+ F60041016; } }
        [DisplayName("Décaissements provenant de l'acquisition d'immobilisations corporelles et incorporelles")]
        public decimal F60040012 { get; set; }
        public decimal F60041012 { get; set; }

        [DisplayName("Encaissements provenant de l'acquisition d'immobilisations corporelles et incorporelles")]
        public decimal F60040013 { get; set; }
        public decimal F60041013 { get; set; }
        [DisplayName("Décaissements provenant de l'acquisition d'immobilisations financières")]
        public decimal F60040014 { get; set; }
        public decimal F60041014 { get; set; }
        [DisplayName("Encaissements provenant de l'acquisition d'immobilisations financières")]
        public decimal F60040015 { get; set; }
        public decimal F60041015 { get; set; }
        [DisplayName("Encaissements provenant de l'acquisition d'immobilisations financières")]
        public decimal F60040016 { get; set; }
        public decimal F60041016 { get; set; }
        [DisplayName("Flux de Trésorerie provenant des (affectés aux) activités de Financement")]
        public decimal F60040017 {
            get { return F60040018 + F60040019 + F60040020 + F60040021 + F60040022; }
        }
        public decimal F60041017 { get { return F60041018 + F60041019 + F60041020 + F60041021 + F60041022; } }
        [DisplayName("Encaissement suite à l'émission d'actions")]
        public decimal F60040018 { get; set; }
        public decimal F60041018 { get; set; }
        [DisplayName("Dividendes et autres distribution")]
        public decimal F60040019 { get; set; }
        public decimal F60041019 { get; set; }
        [DisplayName("Encaissements provenant des emprunts")]
        public decimal F60040020 { get; set; }
        public decimal F60041020 { get; set; }
        [DisplayName("Remboursement d'emprunts")]
        public decimal F60040021 { get; set; }
        public decimal F60041021 { get; set; }
        [DisplayName("Remboursement d'emprunts")]
        public decimal F60040022 { get; set; }
        public decimal F60041022 { get; set; }
        [DisplayName("Incidences des variations des taux de change/les liquidités  équiv")]
        public decimal F60040023 { get; set; }
        public decimal F60041023 { get; set; }

        [DisplayName("Autres Postes des Flux de Trésorerie")]
        public decimal F60040024 { get; set; }
        public decimal F60041024 { get; set; }
        [DisplayName("Variation de Trésorerie")]
        public decimal F60040025 { get { return F60040024 + F60040023 + F60040017 + F60040011 + F60040001; } }
        public decimal F60041025 { get { return F60041024 + F60041023 + F60041017 + F60041011 + F60041001; } }
        [DisplayName("Trésorerie au début de l'exercice")]
        public decimal F60040026 { get; set; }
        public decimal F60041026 { get; set; }
        [DisplayName("Trésorerie à la clôture de l'exercice")]
        public decimal F60040027 { get {return F60040026+ F60040025; } }
        public decimal F60041027 { get { return F60041026 + F60041025; } }

        public List<string> getError()
        {
            List<string> msg = new List<string>();

            if (F60040001 != (F60040002 + F60040003 + F60040004 + F60040005 + F60040006 + F60040007 + F60040008 + F60040009 + F60040010))
                msg.Add("F60040001 est  invalide ! F60040001 = F60040002 + F60040003 + F60040004 + F60040005 + F60040006 + F60040007 + F60040008 + F60040009 + F60040010 ");

            if (F60040011 != (F60040012 + F60040013 + F60040014 + F60040015 + F60040016))
                msg.Add("F60040011 est  invalide ! F60040011 = F60040012 + F60040013 + F60040014 + F60040015 + F60040016 ");

            if (F60040017 != (F60040018 + F60040019 + F60040020 + F60040021 + F60040022))
                msg.Add("F60040017 est  invalide ! F60040017 = F60040018 + F60040019 + F60040020 + F60040021 + F60040022 ");

            if (F60040025 != (F60040024 + F60040023 + F60040017 + F60040011 + F60040001))
                msg.Add("F60040025 est  invalide ! F60040025 = F60040024 + F60040023 + F60040017 + F60040011 + F60040001");

            if (F60040026 != (F60041027))
                msg.Add("F60040026 est  invalide ! F60040026 = F60041027");

            if (F60041001 != (F60041002 + F60041003 + F60041004 + F60041005 + F60041006 + F60041007 + F60041008 + F60041009 + F60041010))
                msg.Add("F60041001 est  invalide ! F60041001 = F60041002 + F60041003 + F60041004 + F60041005 + F60041006 + F60041007 + F60041008 + F60041009 + F60041010");

            if (F60041011 != (F60041012 + F60041013 + F60041014 + F60041015 + F60041016))
                msg.Add("F60041011 est  invalide ! F60041011 = F60041012 + F60041013 + F60041014 + F60041015 + F60041016");

            if (F60041017 != (F60041018 + F60041019 + F60041020 + F60041021 + F60041022))
                msg.Add("F60041017 est  invalide ! F60041017 = F60041018 + F60041019 + F60041020 + F60041021 + F60041022");


            if (F60041025 != (F60041024 + F60041023 + F60041017 + F60041011 + F60041001))
                msg.Add("F60041025 est  invalide ! F60041025 = F60041024 + F60041023 + F60041017 + F60041011 + F60041001 ");




            return msg;
        }   


            public string ToXML(Models.Societe ste, Models.Exercice ex)
        {
            // Models.Societe sos = TVS.
            string r = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
<lf:F6004 xmlns:lf=""http://www.impots.finances.gov.tn/liasse"" xmlns:vc=""http://www.w3.org/2007/XMLSchema-versioning"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://www.impots.finances.gov.tn/liasse F6004-MODELE-AUT.xsd"">
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
    </lf:Details>
</lf:F6004>";
            return r;
        }


    }
}
