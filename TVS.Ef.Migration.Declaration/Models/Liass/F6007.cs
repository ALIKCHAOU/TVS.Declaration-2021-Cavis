using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Ef.Migration.Declaration.Models.Liass
{
    [Table("F6007")]
    public class TF6007
    {
        public int Id { get; set; }
        [Required]
        public int SocieteNo { get; set; }

        public int ExerciceId { get; set; }
        public TSociete Societe { get; set; }
        public TExercice Exercice { get; set; }

        public int ActeDeDepot { get; set; }

        public string NatureDepot { get; set; }

        public string F60070001_Reunion { get; set; }

        public decimal F60071001_F60073001 { get; set; }
        public decimal F60071001_F60073002 { get; set; }
        public DateTime F60071002_F60073001 { get; set; }
        public DateTime F60071002_F60073002 { get; set; }

    }
}
