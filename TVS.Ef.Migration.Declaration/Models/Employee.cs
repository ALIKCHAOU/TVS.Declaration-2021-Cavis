using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Ef.Migration.Declaration.Models
{
    [Table("Employee")]
    public class TEmployee
    {
        public int Id { get; set; }

        [Required]
        public int SocieteNo { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string NomJeuneFille { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{8}", ErrorMessage = "CIN invalide!")]
        public string Cin { get; set; }

        [Required]
        public int SituationFamille { get; set; }

        [Required]
        public int Civilite { get; set; }

        [Required]
        public string NumeroCnss { get; set; }

        [Required]
        public string CleCnss { get; set; }

        [Required]
        public int CategorieNo { get; set; }

        [Required]
        public string NumeroInterne { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string AutresNom { get; set; }

        public virtual TCategorieCnss Categorie { get; set; }

        public virtual TSociete Societe { get; set; }
    }
}