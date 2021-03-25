using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Ef.Migration.Declaration.Models.Dec2016;
using TVS.Ef.Migration.Declaration.Models.Liass;

namespace TVS.Ef.Migration.Declaration.Models
{
    [Table("Exercice")]
    public class TExercice
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"20[0-9][0-9]", ErrorMessage = "Exercice invalide!")]
        public string Annee { get; set; }

        public bool IsArchive { get; set; }
        public bool IsCloturer { get; set; }
        public virtual ICollection<TSociete> Societees { get; set; }
        public virtual ICollection<TF6001> F6001 { get; set; }
        public virtual ICollection<TF6002> F6002 { get; set; }
        public virtual ICollection<TF6003> F6003 { get; set; }
        public virtual ICollection<TF6004> F6004 { get; set; }
        public virtual ICollection<TF6004ModeleAutorsie> F6004ModeleAutorsie { get; set; }
        public virtual ICollection<TF6005> F6005 { get; set; }
        public virtual ICollection<TF6301> F6301 { get; set; }
        public virtual ICollection<TF6303> F6303 { get; set; }
        public virtual ICollection<TF6304> F6304 { get; set; }

        public virtual ICollection<T2016Annexe1> T2016Annexe1 { get; set; }
        public virtual ICollection<T2016Annexe2> T2016Annexe2 { get; set; }
        public virtual ICollection<T2016Annexe3> T2016Annexe3 { get; set; }
        public virtual ICollection<T2016Annexe4> T2016Annexe4 { get; set; }
        public virtual ICollection<T2016Annexe5> T2016Annexe5 { get; set; }
        public virtual ICollection<T2016Annexe6> T2016Annexe6 { get; set; }
        public virtual ICollection<T2016Annexe7> T2016Annexe7 { get; set; }
        public virtual ICollection<TDeclarationCnss> DeclarationCnss { get; set; }
        public virtual ICollection<TDeclarationBcSuspenssion> DeclarationBc { get; set; }
        public virtual ICollection<TDeclarationFactureSuspenssion> DeclarationFacture { get; set; }
    }
}