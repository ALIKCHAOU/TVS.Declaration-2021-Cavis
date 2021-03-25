using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Ef.Migration.Declaration.Models
{
    [Table("LigneBc")]
    public class TLigneBc
    {
        public int Id { get; set; }

        [Required]
        public int DeclarationNo { get; set; }

        [Required]
        public int NumeroOrdre { get; set; }

        public string NumeroAutorisation { get; set; }

        [Required]
        public string NumeroBonCommande { get; set; }

        [Required]
        public DateTime DateBonCommande { get; set; }

        [Required]
        public string NumeroFacture { get; set; }

        [Required]
        public DateTime DateFacture { get; set; }

        [Required]
        public string Identifiant { get; set; }

        [Required]
        public string RaisonSocialFournisseur { get; set; }

        [Required]
        public decimal PrixAchatHorsTaxe { get; set; }

        [Required]
        public decimal MontantTva { get; set; }

        public string ObjetFacture { get; set; }

        public int SocieteNo { get; set; }

        public virtual TDeclarationBcSuspenssion Declaration { get; set; }
    }
}