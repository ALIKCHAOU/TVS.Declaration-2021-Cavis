using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Enums;

namespace TVS.Core.Models
{
    public class LigneFc
    {
        public int Id { get; set; }

        public int DeclarationNo { get; set; }

        public int NumeroOrdre { get; set; }

        public string NumeroFacture { get; set; }

        public DateTime DateFacture { get; set; }

        public TypeClient TypeClient { get; set; }

        public string IdentifiantClient { get; set; }

        public string NomPrenomClient { get; set; }

        public string AdresseClient { get; set; }

        public string NumeroAutorisation { get; set; }

        public DateTime DateAutorisation { get; set; }

        public decimal PrixVenteHt { get; set; }

        public decimal TauxFodec { get; set; }

        public decimal MontantFodec { get; set; }

        public decimal TauxDroitConsommation { get; set; }

        public decimal MontantDroitConsommation { get; set; }

        public decimal TauxTva { get; set; }

        public decimal MontantTva { get; set; }

        public int SocieteNo { get; set; }

        public string GetToString(Societe societe, DeclarationFc declaration, Exercice exercice)
        {
            if (societe == null || declaration == null || exercice == null) return string.Empty;
            var result = string.Empty;
            result = "DF";
            result += societe.MatriculFiscal.PadLeft(7, '0');
            result += societe.MatriculCle.PadLeft(1, '0');
            result += societe.MatriculCategorie.PadLeft(1, '0');
            result += societe.MatriculEtablissement.PadLeft(3, '0');
            result += exercice.Annee.PadLeft(4, '0');
            result += "T";
            result += declaration.Trimestre.ToString().PadLeft(1);
            result += NumeroOrdre.ToString().PadLeft(6, '0');
            result += NumeroFacture.PadRight(20, ' ');
            result += DateFacture.ToString("ddMMyyyy");
            result += ((int) TypeClient).ToString("0");
            result += IdentifiantClient.PadRight(13, ' ');
            result += NomPrenomClient.PadRight(40, ' ');
            result += AdresseClient.PadLeft(120, ' ');
            result += NumeroAutorisation.PadRight(20, ' ');
            result += DateAutorisation.ToString("ddMMyyyy");
            result += (PrixVenteHt*1000).ToString("0").PadLeft(15, '0');
            result += (TauxFodec*1000).ToString("0").PadLeft(5, '0');
            result += (MontantFodec*1000).ToString("0").PadLeft(15, '0');
            result += (TauxDroitConsommation*1000).ToString("0").PadLeft(5, '0');
            result += (MontantDroitConsommation*1000).ToString("0").PadLeft(15, '0');
            result += (TauxTva*1000).ToString("0").PadLeft(5, '0');
            result += (MontantTva*1000).ToString("0").PadLeft(15, '0');

            return result;
        }
    }
}