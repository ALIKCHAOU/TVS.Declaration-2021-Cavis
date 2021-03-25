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
    [Table("Societe")]
    public class TSociete
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string RaisonSocial { get; set; }

        [MaxLength(250)]
        public string Activite { get; set; }

        [MaxLength(250)]
        public string Adresse { get; set; }

        [MaxLength(10)]
        public string CodePostal { get; set; }

        [MaxLength(50)]
        public string Ville { get; set; }

        [MaxLength(50)]
        public string Pays { get; set; }

        [MaxLength(8)]
        [RegularExpression(@"[0-9]*", ErrorMessage = "Numéro empoloyeur est invalide!")]
        public string NumeroEmployeur { get; set; }

        [MaxLength(2)]
        [RegularExpression(@"[0-9]*", ErrorMessage = "Clé empoloyeur est invalide!")]
        public string CleEmployeur { get; set; }

        [MaxLength(50)]
        public string MatriculFiscal { get; set; }

        [MaxLength(50)]
        public string MatriculCle { get; set; }

        [MaxLength(50)]
        public string MatriculCodeTva { get; set; }

        [MaxLength(50)]
        public string MatriculCategorie { get; set; }

        [MaxLength(50)]
        public string MatriculEtablissement { get; set; }

        [MaxLength(2)]
        public string CodeBureau { get; set; }

        public int? CurrentExerciceNo { get; set; }

        public string ServerName { get; set; }

        public string DatabaseName { get; set; }

        public string User { get; set; }

        public string Password { get; set; }
        public int CnssTypeMatricule { get; set; }
        public int Type { get; set; }
        public virtual TExercice CurrentExercice { get; set; }
        public virtual ICollection<T2016Annexe1> T2016Annexe1 { get; set; }
        public virtual ICollection<T2016Annexe2> T2016Annexe2 { get; set; }
        public virtual ICollection<T2016Annexe3> T2016Annexe3 { get; set; }
        public virtual ICollection<T2016Annexe4> T2016Annexe4 { get; set; }
        public virtual ICollection<T2016Annexe5> T2016Annexe5 { get; set; }
        public virtual ICollection<T2016Annexe6> T2016Annexe6 { get; set; }
        public virtual ICollection<T2016Annexe7> T2016Annexe7 { get; set; }
        public virtual ICollection<TEmployee> Employees { get; set; }
        public virtual ICollection<TDeclarationCnss> DeclarationCnss { get; set; }
        public virtual ICollection<TDeclarationBcSuspenssion> DeclarationBc { get; set; }
        public virtual ICollection<TDeclarationFactureSuspenssion> DeclarationFc { get; set; }
        public virtual ICollection<TCategorieCnss> CategorieCnss { get; set; }
        public virtual ICollection<TF6001> F6001 { get; set; }
        public virtual ICollection<TF6002> F6002 { get; set; }
        public virtual ICollection<TF6003> F6003 { get; set; }
        public virtual ICollection<TF6004> F6004 { get; set; }
        public virtual ICollection<TF6004ModeleAutorsie> F6004ModeleAutorsie { get; set; }
        public virtual ICollection<TF6005> F6005 { get; set; }

        public virtual ICollection<TF6301> F6301 { get; set; }
        public virtual ICollection<TF6303> F6303 { get; set; }
        public virtual ICollection<TF6304> F6304 { get; set; }

        public override string ToString()
        {
            return string.Format("Societe {0} : {1}", RaisonSocial, Activite);
        }
    }
}