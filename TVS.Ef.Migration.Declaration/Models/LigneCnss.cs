using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Ef.Migration.Declaration.Models
{
    [Table("LigneCnss")]
    public class TLigneCnss
    {
        public int Id { get; set; }

        public int? Page { get; set; }

        public int? Ligne { get; set; }

        [Required]
        public decimal Brut1 { get; set; }

        [Required]
        public decimal Brut2 { get; set; }

        [Required]
        public decimal Brut3 { get; set; }

        [Required]
        public int EmployeeNo { get; set; }

        [Required]
        public int DeclarationNo { get; set; }

        public int CategorieNo { get; set; }

        public int SocieteNo { get; set; }

        public virtual TDeclarationCnss Declaration { get; set; }

        public virtual TCategorieCnss Categorie { get; set; }

        #region redendence

        [Required]
        public string CleCnss { get; set; }

        [Required]
        public string NumeroCnss { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{8}", ErrorMessage = "CIN invalide!")]
        public string Cin { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string AutresNom { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string NomJeuneFille { get; set; }

        [Required]
        [MaxLength(4)]
        public string CodeExploitation { get; set; }

        [Required]
        public int Civilite { get; set; }

        [Required]
        public string NumeroInterne { get; set; }

        #endregion redendence
    }
}