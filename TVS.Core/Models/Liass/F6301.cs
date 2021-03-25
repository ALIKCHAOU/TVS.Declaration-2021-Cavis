using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Core.Models.Liass
{
    public partial class F6301
    {
        public int Id { get; set; }
        public int SocieteNo { get; set; }
        public int ExerciceId { get; set; }
        [DisplayName("Acte de dépot")]
        public int ActeDeDepot { get; set; }
        [DisplayName("Nature de dépot")]
        public string NatureDepot { get; set; }

        [DisplayName("AC 1‐Portefeuille titres (Net Exercice)")]
        public decimal F63010001 { get { return F63010002 + F63010003 + F63010004; } }

        [DisplayName(" a ‐ Actions, valeurs assimilées et droits rattachés(Net Exercice)")]

        public decimal F63010002 { get; set; }

        [DisplayName("b ‐ Obligations et valeurs assimilées (Net Exercice)")]
        public decimal F63010003 { get; set; }

        [DisplayName("c ‐ Autres valeurs (Net Exercice)")]
        public decimal F63010004 { get; set; }

        [DisplayName("AC 2 ‐ Placements monétaires et disponibilités(Net Exercice)")]
        public decimal F63010005 { get { return F63010006 + F63010007; } }

        [DisplayName("a ‐ Placements monétaires (Net Exercice)")]
        public decimal F63010006 { get; set; }

        [DisplayName("b ‐ Disponibilités (Net Exercice)")]
        public decimal F63010007 { get; set; }

        [DisplayName("AC 3 ‐ Créances d'exploitation (Net Exercice)")]
        public decimal F63010008 { get; set; }


        [DisplayName("AC 4 ‐ Autres actifs (Net Exercice)")]
        public decimal F63010009 { get; set; }

        [DisplayName("Total actif (Net Exercice)")]
        public decimal F63010010 { get { return F63010001 + F63010005 + F63010008 + F63010009; } }

        [DisplayName("PA 1 ‐ Opérateurs créditeurs (Net Exercice)")]
        public decimal F63010011 { get; set; }

        [DisplayName("PA 2 ‐ Autres créditeurs divers (Net Exercice)")]
        public decimal F63010012 { get; set; }

        [DisplayName("Total passif (Net Exercice)")]
        public decimal F63010013 { get { return F63010011 + F63010012; } }


        [DisplayName("CP 1 ‐ Capital (Net Exercice)")]
        public decimal F63010014 { get; set; }

        [DisplayName("CP 2 ‐ Sommes distribuables (Net Exercice)")]
        public decimal F63010015 { get { return F63010016 + F63010017; } }

        [DisplayName("a ‐ Sommes distribuables des exercices antérieurs (Net Exercice)")]
        public decimal F63010016 { get; set; }
        [DisplayName("b‐ Sommes distribuables de l'exercice (Net Exercice)")]
        public decimal F63010017 { get; set; }

        [DisplayName("Total actif net (Net Exercice)")]
        public decimal F63010018 { get { return F63010014 + F63010015; } }

        [DisplayName("Total passif et actif net (Net Exercice)")]
        public decimal F63010019 { get { return F63010013 + F63010018; } }

        [DisplayName("AC 1 ‐ Portefeuille titres (Net Exercice‐1)")]
        public decimal F63011001 { get { return F63011002 + F63011003 + F63011004; } }


        [DisplayName("a ‐ Actions, valeurs assimilées et droits rattachés (Net Exercice‐1)")]
        public decimal F63011002 { get; set; }

        [DisplayName("b ‐ Obligations et valeurs assimilées (Net Exercice‐1)")]
        public decimal F63011003 { get; set; }

        [DisplayName("c ‐ Autres valeurs (Net Exercice‐1)")]
        public decimal F63011004 { get; set; }

        [DisplayName("AC 2 ‐ Placements monétaires et disponibilités (Net Exercice‐1)")]
        public decimal F63011005 { get { return F63011006 + F63011007; } }

        [DisplayName("a ‐ Placements monétaires (Net Exercice‐1)")]
        public decimal F63011006 { get; set; }

        [DisplayName("b ‐ Disponibilités (Net Exercice‐1)")]
        public decimal F63011007 { get; set; }

        [DisplayName("AC 3 ‐ Créances d'exploitation (Net Exercice‐1)")]
        public decimal F63011008 { get; set; }

        [DisplayName("AC 4 ‐ Autres actifs (Net Exercice‐1)")]
        public decimal F63011009 { get; set; }


        [DisplayName("Total actif (Net Exercice‐1)")]
        public decimal F63011010 { get { return F63011001 + F63011005 + F63011008 + F63011009; } }

        [DisplayName("PA 1 ‐ Opérateurs créditeurs (Net Exercice‐1)")]
        public decimal F63011011 { get; set; }

        [DisplayName("PA 2 ‐ Autres créditeurs divers (Net Exercice‐1)")]
        public decimal F63011012 { get; set; }


        [DisplayName("Total passif (Net Exercice‐1)")]
        public decimal F63011013 { get { return F63011011 + F63011012; } }

        [DisplayName("CP 1 ‐ Capital (Net Exercice‐1)")]
        public decimal F63011014 { get; set; }

        [DisplayName("CP 2 ‐ Sommes distribuables (Net Exercice‐1)")]
        public decimal F63011015 { get { return F63011016 + F63011017; } }

        [DisplayName("a ‐ Sommes distribuables des exercices antérieurs (Net Exercice‐1)")]
        public decimal F63011016 { get; set; }

        [DisplayName("b‐ Sommes distribuables de l'exercice (Net Exercice‐1)")]
        public decimal F63011017 { get; set; }


        [DisplayName("Total actif net (Net Exercice‐1)")]
        public decimal F63011018 { get { return F63011014 + F63011015; } }

        [DisplayName("Total passif et actif net (Net Exercice‐1)")]
        public decimal F63011019 { get { return F63011013 + F63011018; } }

        public List<string> getError()
        {
            List<string> msg = new List<string>();

            if (F63010001 != (F63010002 + F63010003 + F63010004))
                msg.Add("F63010001 est  invalide ! F63010001 = F63010002 + F63010003 + F63010004 ");

            if (F63010005 != (F63010006 + F63010007))
                msg.Add("F63010005 est  invalide ! F63010005 = F63010006 + F63010007 ");
            if (F63010010 != (F63010001 + F63010005 + F63010008 + F63010009))
                msg.Add("F63010010 est  invalide ! F63010010 = F63010001 + F63010005 + F63010008 + F63010009 ");

            if (F63010013 != (F63010011 + F63010012))
                msg.Add("F63010013 est  invalide ! F63010013 = F63010011 + F63010012 ");

            if (F63010015 != (F63010016 + F63010017))
                msg.Add("F63010015 est  invalide ! F63010015 = F63010016 + F63010017 ");
            if (F63010018 != (F63010014 + F63010015))
                msg.Add("F63010018 est  invalide ! F63010018 = F63010014 + F63010015 ");
            if (F63010019 != (F63010013 + F63010018))
                msg.Add("F63010019 est  invalide ! F63010019 = F63010013 + F63010018 ");
            if (F63011001 != (F63011002 + F63011003 + F63011004))
                msg.Add("F63011001 est  invalide ! F63011001 = F63011002 + F63011003 + F63011004 ");
            if (F63011005 != (F63011006 + F63011007))
                msg.Add("F63011005 est  invalide ! F63011005 = F63011006 + F63011007");

            if (F63011010 != (F63011001 + F63011005 + F63011008 + F63011009))
                msg.Add("F63011010 est  invalide ! F63011010 = F63011001 + F63011005 + F63011008 + F63011009");
            if (F63011013 != (F63011011 + F63011012))
                msg.Add("F63011013 est  invalide ! F63011013 =  F63011011 + F63011012");
            if (F63011015 != (F63011016 + F63011017))
                msg.Add("F63011015 est  invalide ! F63011015 =  F63011016 + F63011017");
            if (F63011018 != (F63011014 + F63011015))
                msg.Add("F63011018 est  invalide ! F63011018 =  F63011014 + F63011015");
            if (F63011019 != (F63011013 + F63011018))
                msg.Add("F63011019 est  invalide ! F63011019 =  F63011013 + F63011018");
            return msg;
        }
    

        public string ToXML(Models.Societe ste, Models.Exercice ex)
        {
            string r =
$@"<?xml version=""1.0"" encoding=""UTF-8""?>
<?xml-stylesheet type=""text/xsl"" href=""F6301.xsl""?>
<lf:F6301 xmlns:lf=""http://www.impots.finances.gov.tn/liasse"" xmlns:vc=""http://www.w3.org/2007/XMLSchema-versioning"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://www.impots.finances.gov.tn/liasse F6301.xsd"">
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
        <lf:F63010001>{ this.F63010001 * 1000:0}</lf:F63010001>
        <lf:F63010002>{ this.F63010002 * 1000:0}</lf:F63010002>
        <lf:F63010003>{ this.F63010003 * 1000:0}</lf:F63010003>
        <lf:F63010004>{ this.F63010004 * 1000:0}</lf:F63010004>
        <lf:F63010005>{ this.F63010005 * 1000:0}</lf:F63010005>
        <lf:F63010006>{ this.F63010006 * 1000:0}</lf:F63010006>
        <lf:F63010007>{ this.F63010007 * 1000:0}</lf:F63010007>
        <lf:F63010008>{ this.F63010008 * 1000:0}</lf:F63010008>
        <lf:F63010009>{ this.F63010009 * 1000:0}</lf:F63010009>
        <lf:F63010010>{ this.F63010010 * 1000:0}</lf:F63010010>
        <lf:F63010011>{ this.F63010011 * 1000:0}</lf:F63010011>
        <lf:F63010012>{ this.F63010012 * 1000:0}</lf:F63010012>
        <lf:F63010013>{ this.F63010013 * 1000:0}</lf:F63010013>
        <lf:F63010014>{ this.F63010014 * 1000:0}</lf:F63010014>
        <lf:F63010015>{ this.F63010015 * 1000:0}</lf:F63010015>
        <lf:F63010016>{ this.F63010016 * 1000:0}</lf:F63010016>
        <lf:F63010017>{ this.F63010017 * 1000:0}</lf:F63010017>
        <lf:F63010018>{ this.F63010018 * 1000:0}</lf:F63010018>
        <lf:F63010019>{ this.F63010019 * 1000:0}</lf:F63010019>
        <lf:F63011001>{ this.F63011001 * 1000:0}</lf:F63011001>
        <lf:F63011002>{ this.F63011002 * 1000:0}</lf:F63011002>
        <lf:F63011003>{ this.F63011003 * 1000:0}</lf:F63011003>
        <lf:F63011004>{ this.F63011004 * 1000:0}</lf:F63011004>
        <lf:F63011005>{ this.F63011005 * 1000:0}</lf:F63011005>
        <lf:F63011006>{ this.F63011006 * 1000:0}</lf:F63011006>
        <lf:F63011007>{ this.F63011007 * 1000:0}</lf:F63011007>
        <lf:F63011008>{ this.F63011008 * 1000:0}</lf:F63011008>
        <lf:F63011009>{ this.F63011009 * 1000:0}</lf:F63011009>
        <lf:F63011010>{ this.F63011010 * 1000:0}</lf:F63011010>   
        <lf:F63011011>{ this.F63011011 * 1000:0}</lf:F63011011> 
        <lf:F63011012>{ this.F63011012 * 1000:0}</lf:F63011012> 
        <lf:F63011013>{ this.F63011013 * 1000:0}</lf:F63011013> 
        <lf:F63011014>{ this.F63011014 * 1000:0}</lf:F63011014> 
        <lf:F63011015>{ this.F63011015 * 1000:0}</lf:F63011015> 
        <lf:F63011016>{ this.F63011016 * 1000:0}</lf:F63011016> 
        <lf:F63011017>{ this.F63011017 * 1000:0}</lf:F63011017> 
        <lf:F63011018>{ this.F63011018 * 1000:0}</lf:F63011018> 
        <lf:F63011019>{ this.F63011019 * 1000:0}</lf:F63011019>    
   </lf:Details>
</lf:F6301>
";
            return r;
        }
    }
}
