using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Ef.Migration.Declaration.Models
{
    [Table("CategorieCnss")]
    public class TCategorieCnss
    {
        public int Id { get; set; }

        [Required]
        public int SocieteNo { get; set; }

        public int No { get; set; }
        // [Required]
        [MaxLength(100)]
        public string Intitule { get; set; }

        // [Required]
        [MaxLength(4)]
        public string CodeExploitation { get; set; }

        [Required]
        public decimal TauxSalarial { get; set; }

        [Required]
        public decimal TauxPatronal { get; set; }

        [Required]
        public decimal AccidentTravail { get; set; }

        public int TypeVariablePaie { get; set; }

        public string CodePaie { get; set; }
        public virtual ICollection<TEmployee> Employees { get; set; }

        public virtual TSociete Societe { get; set; }

        public virtual ICollection<TLigneCnss> LignesCnss { get; set; }
    }
}