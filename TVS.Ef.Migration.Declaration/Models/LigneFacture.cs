using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Ef.Migration.Declaration.Models
{
    [Table("LigneFacture")]
    public class TLigneFacture
    {
        public int Id { get; set; }

        [Required]
        public int DeclarationNo { get; set; }

        [Required]
        public int NumeroOrdre { get; set; }

        [Required]
        public string NumeroFacture { get; set; }

        [Required]
        public DateTime DateFacture { get; set; }

        [Required]
        public int TypeClient { get; set; }

        [Required]
        public string IdentifiantClient { get; set; }

        [Required]
        public string NomPrenomClient { get; set; }

        [Required]
        public string AdresseClient { get; set; }

        [Required]
        public string NumeroAutorisation { get; set; }

        [Required]
        public DateTime DateAutorisation { get; set; }

        [Required]
        public decimal PrixVenteHt { get; set; }

        [Required]
        public decimal TauxFodec { get; set; }

        [Required]
        public decimal MontantFodec { get; set; }

        [Required]
        public decimal TauxDroitConsommation { get; set; }

        [Required]
        public decimal MontantDroitConsommation { get; set; }

        [Required]
        public decimal TauxTva { get; set; }

        [Required]
        public decimal MontantTva { get; set; }

        public int SocieteNo { get; set; }

        public virtual TDeclarationFactureSuspenssion Declaration { get; set; }
    }
}