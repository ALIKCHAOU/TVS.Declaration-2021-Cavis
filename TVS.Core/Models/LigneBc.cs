using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Core.Models
{
    public class LigneBc
    {
        public int Id { get; set; }

        public int DeclarationNo { get; set; }

        public int NumeroOrdre { get; set; }

        public string NumeroAutorisation { get; set; }

        public string NumeroBonCommande { get; set; }

        public DateTime DateBonCommande { get; set; }

        public string NumeroFacture { get; set; }

        public DateTime DateFacture { get; set; }

        public string Identifiant { get; set; }

        public string RaisonSocialFournisseur { get; set; }

        public decimal PrixAchatHorsTaxe { get; set; }

        public decimal MontantTva { get; set; }

        public string ObjetFacture { get; set; }

        public int SocieteNo { get; set; }

        public string GetToString(Societe societe, DeclarationBc declaration, Exercice exercice)
        {
            if (societe == null || declaration == null || exercice == null) return string.Empty;

            string result = "DF";
            result += societe.MatriculFiscal.PadLeft(7, '0');
            result += societe.MatriculCle.PadLeft(1, '0');
            result += societe.MatriculCategorie.PadLeft(1, '0');
            result += societe.MatriculEtablissement.PadLeft(3, '0');
            result += exercice.Annee.PadLeft(4, '0');
            result += "T";
            result += declaration.Trimestre.ToString().PadLeft(1);
            result += NumeroOrdre.ToString().PadLeft(6, '0');
            result += NumeroAutorisation.PadRight(30, ' ');
            result += NumeroBonCommande.PadLeft(13, ' ');
            result += DateBonCommande.ToString("ddMMyyyy");
            result += Identifiant.PadLeft(13, '0');
            result += RaisonSocialFournisseur.PadRight(40, ' ');
            result += NumeroFacture.PadLeft(30, ' ');
            result += DateFacture.ToString("ddMMyyyy");
            result += (PrixAchatHorsTaxe*1000).ToString("0").PadLeft(15, '0');
            result += (MontantTva*1000).ToString("0").PadLeft(15, '0');
            result += "<";
            result += ObjetFacture.PadRight(320, ' ');
            result += "/>";

            return result;
        }
    }
}