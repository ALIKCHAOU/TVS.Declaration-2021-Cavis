using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Ef.Migration.Declaration.Models
{
    [Table("DeclarationCnss")]
    public class TDeclarationCnss
    {
        public int Id { get; set; }

        public int ExerciceId { get; set; }

        public int SocieteId { get; set; }

        public int Trimestre { get; set; }

        public bool Complementaire { get; set; }

        public DateTime Date { get; set; }

        public bool IsCloture { get; set; }

        public bool IsArchive { get; set; }

        public virtual TExercice Exercice { get; set; }

        public virtual TSociete Societe { get; set; }

        public virtual ICollection<TLigneCnss> Lignes { get; set; }
    }
}