using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Core.Models
{
    public class DeclarationFc
    {
        public int Id { get; set; }

        public int ExerciceId { get; set; }

        public int SocieteId { get; set; }

        public int Trimestre { get; set; }

        public DateTime Date { get; set; }

        public bool IsCloture { get; set; }

        public bool IsArchive { get; set; }

        public string GetEntetFcToString(Societe societe, Exercice exercice)
        {
            if (societe == null || exercice == null) return string.Empty;

            var result = "EF";
            result += societe.MatriculFiscal.PadLeft(7, '0');
            result += societe.MatriculCle.PadLeft(1, '0');
            result += societe.MatriculCategorie.PadLeft(1, '0');
            result += societe.MatriculEtablissement.PadLeft(3, '0');
            result += exercice.Annee.PadLeft(4, '0');
            result += "T";
            result += Trimestre.ToString().PadLeft(1);
            result += societe.RaisonSocial.PadRight(40, ' ');
            result += societe.Activite.PadRight(40, ' ');
            result += societe.Ville.PadRight(40, ' ');
            result += societe.Adresse.PadRight(72, ' ');
            result += "0000"; // numero?????? n'existe pas dans la Tunisie
            result += societe.CodePostal.PadLeft(4, '0');
            result += " ".PadRight(111, ' ');
            return result;
        }

        public string GetPiedToString(
            Societe societe,
            Exercice exercice,
            List<LigneFc> ligneFcSuspendues)
        {
            if (societe == null || exercice == null) return string.Empty;
            var count = ligneFcSuspendues.Select(x => x.NumeroFacture).ToList().Count();
            var totalPrixVenteHt = ligneFcSuspendues.Sum(x => x.PrixVenteHt);
            var totalMontantFodec = ligneFcSuspendues.Sum(x => x.MontantFodec);
            var totalMontantDroitConsommation = ligneFcSuspendues.Sum(x => x.MontantDroitConsommation);
            var totalMontantTva = ligneFcSuspendues.Sum(x => x.MontantTva);
            var result = "TF";
            result += societe.MatriculFiscal.PadLeft(7, '0');
            result += societe.MatriculCle.PadLeft(1, '0');
            result += societe.MatriculCategorie.PadLeft(1, '0');
            result += societe.MatriculEtablissement.PadLeft(3, '0');
            result += exercice.Annee.PadLeft(4, '0');
            result += "T";
            result += Trimestre.ToString().PadLeft(1);
            result += count.ToString().PadLeft(6, '0');
            result += string.Empty.PadLeft(230, ' ');
            result += (totalPrixVenteHt*1000).ToString("0").PadLeft(15, '0');
            result += "00000";
            result += (totalMontantFodec*1000).ToString("0").PadLeft(15, '0');
            result += "00000";
            result += (totalMontantDroitConsommation*1000).ToString("0").PadLeft(15, '0');
            result += "00000";
            result += (totalMontantTva*1000).ToString("0").PadLeft(15, '0');
            return result;
        }
    }
}