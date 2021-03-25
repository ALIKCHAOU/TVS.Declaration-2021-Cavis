using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Core.Models.Liass
{
    public partial class F6303
    {
        public int Id { get; set; }
        public int SocieteNo { get; set; }
        public int ExerciceId { get; set; }
        [DisplayName("Acte de dépot")]
        public int ActeDeDepot { get; set; }
        [DisplayName("Nature de dépot")]
        public string NatureDepot { get; set; }

        [DisplayName("PR 1 ‐ Revenus du portefeuille titres (NetExercice)")]
        public decimal F63030001 { get { return F63030002 + F63030003 + F63030004; } }

        [DisplayName("a‐ Dividendes (Net Exercice)")]
        public decimal F63030002 { get; set; }

        [DisplayName("b ‐ Revenus des obligations et valeurs assimilées (Net Exercice)")]
        public decimal F63030003 { get; set; }

        [DisplayName("c ‐ Revenus des autres valeurs (Net Exercice)")]
        public decimal F63030004 { get; set; }


        [DisplayName("PR 2 ‐ Revenus des placements monétaires (Net Exercice)")]
        public decimal F63030005 { get; set; }


        [DisplayName("Total des revenus des placements (Net Exercice)")]
        public decimal F63030006 { get { return F63030001 + F63030005; } }

        [DisplayName("CH 1 ‐ Charges de gestion des placements (Net Exercice)")]
        public decimal F63030007 { get; set; }


        [DisplayName("Revenu net des placements (Net Exercice)")]
        public decimal F63030008
        {
            get
            {
                return F63030006 - F63030007;
            }
        }

        [DisplayName("PR 3 ‐ Autres produits(Net Exercice)")]
        public decimal F63030009 { get; set; }
        [DisplayName("CH 2 ‐ Autres charges(Net Exercice)")]
        public decimal F63030010 { get; set; }

        [DisplayName("Résultat d'exploitation (Net Exercice)")]
        public decimal F63030011
        {
            get
            {
                return F63030008 + F63030009 - F63030010;
            }
        }

        [DisplayName("PR 4 ‐ Régularisation du résultat d'exploitation (Net Exercice)")]
        public decimal F63030012 { get; set; }

        [DisplayName("Sommes distribuables de l'exercice (Net Exercice)")]
        public decimal F63030013
        {
            get
            {
                return F63030011 + F63030012;
            }
        }

        [DisplayName("PR 4 ‐ Régularisation du résultat d'exploitation (annulation)(Net Exercice)")]
        public decimal F63030014
        {
            get
            {
                return -F63030012;
            }
        }
        [DisplayName(" Variation des(+ou‐) values potentielles sur titres (Net Exercice)")]
        public decimal F63030015 { get; set; }

        [DisplayName(" (+ou‐) values réalisées sur cession des titres (Net Exercice)")]
        public decimal F63030016 { get; set; }

        [DisplayName("Frais de négociation (Net Exercice)")]
        public decimal F63030017 { get; set; }

        [DisplayName("Résultat net de l'exercice (Net Exercice)")]
        public decimal F63030018
        {
            get
            {
                return F63030013 + F63030014;
            }
        }



        [DisplayName("PR 1 ‐ Revenus du portefeuille titres (Net Exercice‐1)")]
        public decimal F63031001
        {
            get
            {
                return F63031002 + F63031003 + F63031004;
            }
        }

        [DisplayName("a‐ Dividendes (Net Exercice‐1)")]
        public decimal F63031002 { get; set; }

        [DisplayName("b ‐ Revenus des obligations et valeurs assimilées (Net Exercice‐1)")]
        public decimal F63031003 { get; set; }

        [DisplayName("c ‐ Revenus des autres valeurs (Net Exercice‐1)")]
        public decimal F63031004 { get; set; }
        [DisplayName("PR 2 ‐ Revenus des placements monétaires (Net Exercice‐1)")]
        public decimal F63031005 { get; set; }

        [DisplayName("Total des revenus des placements (Net Exercice‐1)")]
        public decimal F63031006
        {
            get
            {
                return F63031001 + F63031005;
            }
        }
        [DisplayName("CH 1 ‐ Charges de gestion des placements(Net Exercice‐1)")]
        public decimal F63031007 { get; set; }

        [DisplayName("Revenu net des placements(Net Exercice‐1)")]
        public decimal F63031008
        {
            get
            {
                return F63031006 - F63031007;
            }
        }

        [DisplayName("PR 3 ‐ Autres produits (Net Exercice‐1)")]
        public decimal F63031009 { get; set; }

        [DisplayName("CH 2 ‐ Autres charges (Net Exercice‐1)")]
        public decimal F63031010 { get; set; }

        [DisplayName("Résultat d'exploitation (Net Exercice‐1)")]
        public decimal F63031011
        {
            get
            {
                return F63031008 + F63031009 - F63031010;
            }
        }

        [DisplayName("PR 4 ‐ Régularisation du résultat d'exploitation (Net Exercice‐1)")]
        public decimal F63031012 { get; set; }

        [DisplayName("Sommes distribuables de l'exercice (Net Exercice‐1)")]
        public decimal F63031013
        {
            get
            {
                return F63031011 + F63031012;
            }
        }

        [DisplayName("PR 4 ‐ Régularisation du résultat d'exploitation (annulation)(Net Exercice‐1)")]
        public decimal F63031014
        {
            get
            {
                return -F63031012;
            }
        }

        [DisplayName("Variation des (+ou‐) values potentielles sur titres (Net Exercice‐1)")]
        public decimal F63031015 { get; set; }

        [DisplayName("(+ou‐) values réalisées sur cession des titres (Net Exercice‐1)")]
        public decimal F63031016 { get; set; }

        [DisplayName("Frais de négociation (Net Exercice‐1)")]
        public decimal F63031017 { get; set; }

        [DisplayName("Résultat net de l'exercice (Net Exercice‐1)")]
        public decimal F63031018
        {
            get
            {
                return F63031013 + F63031014;
            }
        }

        public List<string> getError()
        {
            List<string> msg = new List<string>();

            if (F63030001 != (F63030002 + F63030003 + F63030004))
                msg.Add("F63030001 est  invalide ! F63030001 = F63030002 + F63030003 + F63030004");
            if (F63030006 != (F63030001 + F63030005))
                msg.Add("F63030006 est  invalide ! F63030006 = F63030001 + F63030005");
            if (F63030008 != (F63030006 - F63030007))
                msg.Add("F63030008 est  invalide ! F63030008 = F63030006 - F63030007");

            if (F63030011 != (F63030008 + F63030009 - F63030010))
                msg.Add("F63030011 est  invalide ! F63030011 = F63030008 + F63030009 - F63030010");

            if (F63030013 != (F63030011 + F63030012))
                msg.Add("F63030013 est  invalide ! F63030013 = F63030011 + F63030012");

            if (F63030014 != (-F63030012))
                msg.Add("F63030014 est  invalide ! F63030014 = -F63030012");

            if (F63030018 != (F63030013 + F63030014))
                msg.Add("F63030018 est  invalide ! F63030018 = F63030013 + F63030014");
            if (F63031001 != (F63031002 + F63031003 + F63031004))
                msg.Add("F63031001 est  invalide ! F63031001 = F63031002 + F63031003 + F63031004");

            if (F63031006 != (F63031001 + F63031005))
                msg.Add("F63031006 est  invalide ! F63031006 = F63031001 + F63031005");
            if (F63031008 != (F63031006 - F63031007))
                msg.Add("F63031008 est  invalide ! F63031008 = F63031006 - F63031007");

            if (F63031011 != (F63031008 + F63031009 - F63031010))
                msg.Add("F63031011 est  invalide ! F63031011 = F63031008 + F63031009 - F63031010");
            if (F63031013 != (F63031011 + F63031012))
                msg.Add("F63031013 est  invalide ! F63031013 = F63031011 + F63031012");

            if (F63031014 != (-F63031012))
                msg.Add("F63031014 est  invalide ! F63031014 = -F63031012");

            if (F63031018 != (F63031013 + F63031014))
                msg.Add("F63031018 est  invalide ! F63031018 = F63031013 + F63031014");        
            return msg;
        }

        public string ToXML(Models.Societe ste, Models.Exercice ex)
        {
            string r =
  $@"<?xml version=""1.0"" encoding=""UTF-8""?>
<?xml-stylesheet type=""text/xsl"" href=""F6303.xsl""?>
<lf:F6303 xmlns:lf=""http://www.impots.finances.gov.tn/liasse"" xmlns:vc=""http://www.w3.org/2007/XMLSchema-versioning"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://www.impots.finances.gov.tn/liasse F6303.xsd"">     
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
             <lf:Details > 
             <lf:F63030001>{ this.F63030001 * 1000:0}</lf:F63030001>
             <lf:F63030002>{ this.F63030002 * 1000:0}</lf:F63030002>
             <lf:F63030003>{ this.F63030003 * 1000:0}</lf:F63030003>
             <lf:F63030004>{ this.F63030004 * 1000:0}</lf:F63030004>
             <lf:F63030005>{ this.F63030005 * 1000:0}</lf:F63030005>
             <lf:F63030006>{ this.F63030006 * 1000:0}</lf:F63030006>
             <lf:F63030007>{ this.F63030007 * 1000:0}</lf:F63030007>
             <lf:F63030008>{ this.F63030008 * 1000:0}</lf:F63030008>
             <lf:F63030009>{ this.F63030009 * 1000:0}</lf:F63030009>
             <lf:F63030010>{ this.F63030010 * 1000:0}</lf:F63030010>
             <lf:F63030011>{ this.F63030011 * 1000:0}</lf:F63030011>
             <lf:F63030012>{ this.F63030012 * 1000:0}</lf:F63030012>
             <lf:F63030013>{ this.F63030013 * 1000:0}</lf:F63030013>
             <lf:F63030014>{ this.F63030014 * 1000:0}</lf:F63030014>
             <lf:F63030015>{ this.F63030015 * 1000:0}</lf:F63030015>
             <lf:F63030016>{ this.F63030016 * 1000:0}</lf:F63030016>
             <lf:F63030017>{ this.F63030017 * 1000:0}</lf:F63030017>
             <lf:F63030018>{ this.F63030018 * 1000:0}</lf:F63030018>   
             <lf:F63031001>{ this.F63031001 * 1000:0}</lf:F63031001>
             <lf:F63031002>{ this.F63031002 * 1000:0}</lf:F63031002>
             <lf:F63031003>{ this.F63031003 * 1000:0}</lf:F63031003>
             <lf:F63031004>{ this.F63031004 * 1000:0}</lf:F63031004>
             <lf:F63031005>{ this.F63031005 * 1000:0}</lf:F63031005>
             <lf:F63031006>{ this.F63031006 * 1000:0}</lf:F63031006>
             <lf:F63031007>{ this.F63031007 * 1000:0}</lf:F63031007>
             <lf:F63031008>{ this.F63031008 * 1000:0}</lf:F63031008>
             <lf:F63031009>{ this.F63031009 * 1000:0}</lf:F63031009>
             <lf:F63031010>{ this.F63031010 * 1000:0}</lf:F63031010>
             <lf:F63031011>{ this.F63031011 * 1000:0}</lf:F63031011>
             <lf:F63031012>{ this.F63031012 * 1000:0}</lf:F63031012>
             <lf:F63031013>{ this.F63031013 * 1000:0}</lf:F63031013>
             <lf:F63031014>{ this.F63031014 * 1000:0}</lf:F63031014>
             <lf:F63031015>{ this.F63031015 * 1000:0}</lf:F63031015>
             <lf:F63031016>{ this.F63031016 * 1000:0}</lf:F63031016>
             <lf:F63031017>{ this.F63031017 * 1000:0}</lf:F63031017>
             <lf:F63031018>{ this.F63031018 * 1000:0}</lf:F63031018>
             </lf:Details>
</lf:F6303>
";
            return r;
        }
    }
}