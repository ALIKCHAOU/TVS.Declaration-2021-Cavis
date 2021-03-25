using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Ef.Migration.Declaration.Models
{
    [Table("VirementLigne")]
    public class TVirementLigne
    {
        public int Id { get; set; }

        public int EnteteId { get; set; }

        public string Matricule { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string NomBanque { get; set; }

        public string CodeBanque { get; set; }

        public string CodeGuichet { get; set; }

        public string NumeroCompte { get; set; }

        public string CleRib { get; set; }

        public decimal NetAPaye { get; set; }

        public string Motif { get; set; }

        public virtual TVirementEntete Entete { get; set; }
    }
}
