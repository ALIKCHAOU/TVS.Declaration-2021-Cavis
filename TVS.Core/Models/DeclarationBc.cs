using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Core.Models
{
    public class DeclarationBc
    {
        public int Id { get; set; }

        public int ExerciceId { get; set; }

        public int SocieteId { get; set; }

        public int Trimestre { get; set; }

        public DateTime Date { get; set; }

        public bool IsCloture { get; set; }

        public bool IsArchive { get; set; }
        public string NumeroAutorisation { get; set; }
        public string GetEntetBcToString(Societe societe, Exercice exercice)
        {
            if (societe == null || exercice == null) return string.Empty;

            string result = "EF";
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
            //result += " ".PadRight(111, ' ');
            var x = result.Length;
            return result;
        }

        public string GetPiedBcToString(
            Societe societe,
            Exercice exercice,
            List<LigneBc> ligneBcSuspendues)
        {
            if (societe == null || exercice == null) return string.Empty;
            var count = ligneBcSuspendues.Select(x => x.NumeroBonCommande).ToList().Distinct().Count();
            var totalPrixAchat = ligneBcSuspendues.Sum(x => x.PrixAchatHorsTaxe);
            var totalMontantTva = ligneBcSuspendues.Sum(x => x.MontantTva);

            var result = "TF";
            result += societe.MatriculFiscal.PadLeft(7, '0');
            result += societe.MatriculCle.PadLeft(1, '0');
            result += societe.MatriculCategorie.PadLeft(1, '0');
            result += societe.MatriculEtablissement.PadLeft(3, '0');
            result += exercice.Annee.PadLeft(4, '0');
            result += "T";
            result += Trimestre.ToString().PadLeft(1);
            result += count.ToString().PadLeft(6, '0');
            result += string.Empty.PadLeft(142, ' ');
            result += (totalPrixAchat*1000).ToString("0").PadLeft(15, '0');
            result += (totalMontantTva*1000).ToString("0").PadLeft(15, '0');
            return result;
        }
    }
}