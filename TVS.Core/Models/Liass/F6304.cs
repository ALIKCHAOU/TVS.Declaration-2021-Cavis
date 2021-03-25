using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Core.Models.Liass
{
    public partial class F6304
    {
        public int Id { get; set; }
        public int SocieteNo { get; set; }
        public int ExerciceId { get; set; }
        [DisplayName("Acte de dépot")]
        public int ActeDeDepot { get; set; }
        [DisplayName("Nature de dépot")]
        public string NatureDepot { get; set; }

        [DisplayName("Variation de l'actif net (Net Exercice)")]
        public decimal F63040001 { get { return F63040002 + F63040007 + F63040008; } }

        [DisplayName("AN1 ‐ Variation de l'actif net (Résultant des opérations d'exploitation) (Net Exercice)")]
        public decimal F63040002 { get { return F63040003 + F63040004 + F63040005 + F63040006; } }

        [DisplayName("a ‐ Résultat d'exploitation (Net Exercice)")]
        public decimal F63040003 { get; set; }

        [DisplayName("b ‐ Variation des (+ou‐) values potentielles sur titres(Net Exercice)")]
        public decimal F63040004 { get; set; }

        [DisplayName("c ‐ (+ou‐) values réalisées sur cession de titres (Net Exercice)")]
        public decimal F63040005 { get; set; }

        [DisplayName("d ‐ Frais de négociation de titres (Net Exercice)")]
        public decimal F63040006 { get; set; }

        [DisplayName("AN 2 ‐ Distribution des dividendes(Net Exercice)")]
        public decimal F63040007 { get; set; }

        [DisplayName("AN 3 ‐ Transactions sur le capital (Net Exercice)")]
        public decimal F63040008 { get { return F63040009 + F63040014; } }

        [DisplayName("a‐ Souscriptions (Net Exercice)")]
        public decimal F63040009 { get { return F63040010 + F63040011 + F63040012 + F63040013; } }

        [DisplayName("Variation des plus (ou moins) values potentielles sur titres(Net Exercice)")]
        public decimal F63040010 { get; set; }

        [DisplayName("Plus (ou moins) values réalisées sur cession des titres(Net Exercice)")]
        public decimal F63040011 { get; set; }

        [DisplayName("Plus (ou moins) values réalisées sur cession des  titres(Net Exercice)")]
        public decimal F63040012 { get; set; }


        [DisplayName("Frais de négociation (Net Exercice)")]
        public decimal F63040013 { get; set; }

        [DisplayName("b‐ Rachats (Net Exercice)")]
        public decimal F63040014 { get { return F63040015 + F63040016 + F63040017 + F63040018; } }

        [DisplayName("Capital (Net Exercice)")]
        public decimal F63040015 { get; set; }

        [DisplayName("Régularisation des sommes non distribuables de l'exercice (Net Exercice)")]
        public decimal F63040016 { get; set; }

        [DisplayName("Régularisation des sommes distribuables (Net Exercice)")]
        public decimal F63040017 { get; set; }

        [DisplayName("Droits de sortie (Net Exercice)")]
        public decimal F63040018 { get; set; }


        [DisplayName("Valeur liquidative (Net Exercice)")]
        public decimal F63040019 { get { return F63040020 + F63040023; } }

        [DisplayName("AN 4 ‐ Actif net (Net Exercice)")]
        public decimal F63040020 { get { return F63040021 + F63040022; } }
        [DisplayName("a ‐ en début d'exercice (Net Exercice)")]
        public decimal F63040021 { get; set; }

        [DisplayName("b ‐ en fin d'exercice (Net Exercice)")]
        public decimal F63040022 { get; set; }

        [DisplayName("AN 5 ‐ Nombre d'actions (ou de parts) (Net Exercice)")]
        public decimal F63040023 { get { return F63040024 + F63040025; } }

        [DisplayName("a ‐ en début d'exercice (Net Exercice)")]
        public decimal F63040024 { get; set; }
        [DisplayName("b ‐ en fin d'exercice (Net Exercice)")]
        public decimal F63040025 { get; set; }

        [DisplayName("AN 6 ‐ Taux de rendement annuel (Net Exercice)")]
        public decimal F63040026 { get { try { return (F63040019 + F63041019) / F63041019; } catch { return 0; } } }

        [DisplayName("Variation de l'actif net (Net Exercice‐1)")]
        public decimal F63041001 { get { return F63041002 + F63041007 + F63041008; } }

        [DisplayName("AN1 ‐ Variation de l'actif net (Résultant des opérations d'exploitation) (Net Exercice‐1)")]
        public decimal F63041002 { get { return F63041003 + F63041004 + F63041005 + F63041006; } }

        [DisplayName("a ‐ Résultat d'exploitation (Net Exercice‐1)")]
        public decimal F63041003 { get; set; }

        [DisplayName("b ‐ Variation des (+ou‐) values potentielles sur titres(Net Exercice‐1)")]
        public decimal F63041004 { get; set; }

        [DisplayName("c ‐ (+ou‐) values réalisées sur cession de titres (Net Exercice‐1)")]
        public decimal F63041005 { get; set; }

        [DisplayName("d ‐ Frais de négociation de titres (Net Exercice‐1)")]
        public decimal F63041006 { get; set; }

        [DisplayName("AN 2 ‐ Distribution des dividendes (Net Exercice‐1)")]
        public decimal F63041007 { get; set; }
        [DisplayName("AN 3 ‐ Transactions sur le capital (Net Exercice‐1)")]
        public decimal F63041008 { get { return F63041009 + F63041014; } }

        [DisplayName("a‐ Souscriptions (Net Exercice‐1)")]
        public decimal F63041009 { get { return F63041010 + F63041011 + F63041012 + F63041013; } }

        [DisplayName("Variation des plus (ou moins) values potentielles sur titres(Net Exercice‐1)")]
        public decimal F63041010 { get; set; }

        [DisplayName("Plus (ou moins) values réalisées sur cession des titres(Net Exercice‐1)")]
        public decimal F63041011 { get; set; }

        [DisplayName("Plus (ou moins) values réalisées sur cession des titres(Net Exercice‐1)")]
        public decimal F63041012 { get; set; }
        [DisplayName("Frais de négociation (Net Exercice‐1)")]
        public decimal F63041013 { get; set; }

        [DisplayName("b‐ Rachats (Net Exercice‐1)")]
        public decimal F63041014 { get { return F63041015 + F63041016 + F63041017 + F63041018; } }

        [DisplayName("Capital (Net Exercice‐1)")]
        public decimal F63041015 { get; set; }

        [DisplayName("Régularisation des sommes non distribuables de l'exercice (Net Exercice‐1)")]
        public decimal F63041016 { get; set; }

        [DisplayName("Régularisation des sommes distribuables (Net Exercice‐1)")]
        public decimal F63041017 { get; set; }

        [DisplayName("Droits de sortie (Net Exercice‐1)")]
        public decimal F63041018 { get; set; }
        [DisplayName("Valeur liquidative (Net Exercice‐1)")]
        public decimal F63041019 { get { return F63041020 + F63041023; } }

        [DisplayName("AN 4 ‐ Actif net (Net Exercice‐1)")]
        public decimal F63041020 { get { return F63041021 + F63041022; } }

        [DisplayName("a ‐ en début d'exercice (Net Exercice‐1)")]
        public decimal F63041021 { get; set; }

        [DisplayName("b ‐ en fin d'exercice (Net Exercice‐1)")]
        public decimal F63041022 { get; set; }

        [DisplayName("AN 5 ‐ Nombre d'actions (ou de parts) (Net Exercice‐1)")]
        public decimal F63041023 { get { return F63041024 + F63041025; } }

        [DisplayName("a ‐ en début d'exercice (Net Exercice‐1)")]
        public decimal F63041024 { get; set; }
        [DisplayName("b ‐ en fin d'exercice (Net Exercice‐1)")]
        public decimal F63041025 { get; set; }

        [DisplayName("AN 6 ‐ Taux de rendement annuel (Net Exercice‐1)")]
        public decimal F63041026 { get { try { return (F63041019 + F63041019) / F63041019; } catch { return 0; } } }



        public string ToXML(Models.Societe ste, Models.Exercice ex)
        {
            string r =
  $@"<?xml version=""1.0"" encoding=""UTF-8""?>
<?xml-stylesheet type=""text/xsl"" href=""F6304.xsl""?>
<lf:F6304 xmlns:lf=""http://www.impots.finances.gov.tn/liasse"" xmlns:vc=""http://www.w3.org/2007/XMLSchema-versioning"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://www.impots.finances.gov.tn/liasse F6304.xsd"">     
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
             <lf:F63040001>{ this.F63040001 * 1000:0}</lf:F63040001>
             <lf:F63040002>{ this.F63040002 * 1000:0}</lf:F63040002>
             <lf:F63040003>{ this.F63040003 * 1000:0}</lf:F63040003>
             <lf:F63040004>{ this.F63040004 * 1000:0}</lf:F63040004>
             <lf:F63040005>{ this.F63040005 * 1000:0}</lf:F63040005>
             <lf:F63040006>{ this.F63040006 * 1000:0}</lf:F63040006>
             <lf:F63040007>{ this.F63040007 * 1000:0}</lf:F63040007>
             <lf:F63040008>{ this.F63040008 * 1000:0}</lf:F63040008>
             <lf:F63040009>{ this.F63040009 * 1000:0}</lf:F63040009>
             <lf:F63040010>{ this.F63040010 * 1000:0}</lf:F63040010>
             <lf:F63040011>{ this.F63040011 * 1000:0}</lf:F63040011>
             <lf:F63040012>{ this.F63040012 * 1000:0}</lf:F63040012>
             <lf:F63040013>{ this.F63040013 * 1000:0}</lf:F63040013>
             <lf:F63040014>{ this.F63040014 * 1000:0}</lf:F63040014>
             <lf:F63040015>{ this.F63040015 * 1000:0}</lf:F63040015>
             <lf:F63040016>{ this.F63040016 * 1000:0}</lf:F63040016>
             <lf:F63040017>{ this.F63040017 * 1000:0}</lf:F63040017>
             <lf:F63040018>{ this.F63040018 * 1000:0}</lf:F63040018>
             <lf:F63040019>{ this.F63040019 * 1000:0}</lf:F63040019>
             <lf:F63040020>{ this.F63040020 * 1000:0}</lf:F63040020>
             <lf:F63040021>{ this.F63040021 * 1000:0}</lf:F63040021>
             <lf:F63040022>{ this.F63040022 * 1000:0}</lf:F63040022>
             <lf:F63040023>{ this.F63040023 * 1000:0}</lf:F63040023>
             <lf:F63040024>{ this.F63040024 * 1000:0}</lf:F63040024>
             <lf:F63040025>{ this.F63040025 * 1000:0}</lf:F63040025>
             <lf:F63040026>{ this.F63040026 * 1000:0}</lf:F63040026>
             <lf:F63041001>{ this.F63041001 * 1000:0}</lf:F63041001>
             <lf:F63041002>{ this.F63041002 * 1000:0}</lf:F63041002>
             <lf:F63041003>{ this.F63041003 * 1000:0}</lf:F63041003>
             <lf:F63041004>{ this.F63041004 * 1000:0}</lf:F63041004>
             <lf:F63041005>{ this.F63041005 * 1000:0}</lf:F63041005>
             <lf:F63041006>{ this.F63041006 * 1000:0}</lf:F63041006>
             <lf:F63041007>{ this.F63041007 * 1000:0}</lf:F63041007>
             <lf:F63041008>{ this.F63041008 * 1000:0}</lf:F63041008>
             <lf:F63041009>{ this.F63041009 * 1000:0}</lf:F63041009>
             <lf:F63041010>{ this.F63041010 * 1000:0}</lf:F63041010>
             <lf:F63041011>{ this.F63041011 * 1000:0}</lf:F63041011>
             <lf:F63041012>{ this.F63041012 * 1000:0}</lf:F63041012>
             <lf:F63041013>{ this.F63041013 * 1000:0}</lf:F63041013>
             <lf:F63041014>{ this.F63041014 * 1000:0}</lf:F63041014>
             <lf:F63041015>{ this.F63041015 * 1000:0}</lf:F63041015>
             <lf:F63041016>{ this.F63041016 * 1000:0}</lf:F63041016>
             <lf:F63041017>{ this.F63041017 * 1000:0}</lf:F63041017>
             <lf:F63041018>{ this.F63041018 * 1000:0}</lf:F63041018>
             <lf:F63041019>{ this.F63041019 * 1000:0}</lf:F63041019>
             <lf:F63041020>{ this.F63041020 * 1000:0}</lf:F63041020>
             <lf:F63041021>{ this.F63041021 * 1000:0}</lf:F63041021>
             <lf:F63041022>{ this.F63041022 * 1000:0}</lf:F63041022>
             <lf:F63041023>{ this.F63041023 * 1000:0}</lf:F63041023>
             <lf:F63041024>{ this.F63041024 * 1000:0}</lf:F63041024>
             <lf:F63041025>{ this.F63041025 * 1000:0}</lf:F63041025>
             <lf:F63041026>{ this.F63041026 * 1000:0}</lf:F63041026>            
             </lf:Details>
</lf:F6304>
";
            return r;
        }

        public List<string> getError()
        {
            List<string> msg = new List<string>();

            if (F63040001 != (F63040002 + F63040007 + F63040008))
                msg.Add("F63040001 est  invalide ! F63040001 = F63040002 + F63040007 + F63040008  ");
            if (F63040002 != (F63040003 + F63040004 + F63040005 + F63040006))
                msg.Add("F63040002 est  invalide ! F63040002 = F63040003 + F63040004 + F63040005 + F63040006  ");
            if (F63040008 != (F63040009 + F63040014))
                msg.Add("F63040008 est  invalide ! F63040008 = F63040009 + F63040014  ");
            if (F63040009 != (F63040010 + F63040011 + F63040012 + F63040013))
                msg.Add("F63040009 est  invalide ! F63040009 = F63040010 + F63040011 + F63040012 + F63040013  ");

            if (F63040014 != (F63040015 + F63040016 + F63040017 + F63040018))
                msg.Add("F63040014 est  invalide ! F63040014 = F63040015 + F63040016 + F63040017 + F63040018 ");

            if (F63040019 != (F63040020 + F63040023))
                msg.Add("F63040019 est  invalide ! F63040019 = F63040020 + F63040023");

            if (F63040020 != (F63040021 + F63040022))
                msg.Add("F63040020 est  invalide ! F63040020 = F63040021 + F63040022");

            if (F63040023 != (F63040024 + F63040025))
                msg.Add("F63040023 est  invalide ! F63040023 = F63040024 + F63040025");
            if (F63041019 != 0)
            {
                if (F63040026 != ((F63040019 + F63041019) / F63041019))
                    msg.Add("F63040026 est  invalide ! F63040026 = (F63040019 + F63041019) / F63041019");
            }
            if (F63041001 != (F63041002 + F63041007 + F63041008))
                msg.Add("F63041001 est  invalide ! F63041001 = (F63041002 + F63041007 + F63041008)");

            if (F63041002 != (F63041003 + F63041004 + F63041005 + F63041006))
                msg.Add("F63041002 est  invalide ! F63041002 = (F63041003 + F63041004 + F63041005 + F63041006)");

            if (F63041008 != (F63041009 + F63041014))
                msg.Add("F63041008 est  invalide ! F63041008 = ( F63041009 + F63041014)");
            if (F63041009 != (F63041010 + F63041011 + F63041012 + F63041013))
                msg.Add("F63041009 est  invalide ! F63041009 = ( F63041010 + F63041011 + F63041012 + F63041013)");

            if (F63041014 != (F63041015 + F63041016 + F63041017 + F63041018))
                msg.Add("F63041014 est  invalide ! F63041014 = ( F63041015 + F63041016 + F63041017 + F63041018)");

            if (F63041019 != (F63041020 + F63041023))
                msg.Add("F63041019 est  invalide ! F63041019 = (F63041020 + F63041023)");

            if (F63041020 != (F63041021 + F63041022))
                msg.Add("F63041020 est  invalide ! F63041020 = (F63041021 + F63041022)");
            if (F63041023 != (F63041024 + F63041025))
                msg.Add("F63041023 est  invalide ! F63041023 = (F63041024 + F63041025)");

            if (F63041019 != 0)
            {
                if (F63041026 != ((F63041019 + F63041019) / F63041019))
                    msg.Add("F63041026 est  invalide ! F63041026 = ((F63041019 + F63041019) / F63041019)");
            }
            return msg;
        }
    }
}
