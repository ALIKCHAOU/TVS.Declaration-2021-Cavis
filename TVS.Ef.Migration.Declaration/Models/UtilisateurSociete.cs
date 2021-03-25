using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Ef.Migration.Declaration.Models
{
    [Table("UtilisateurSociete")]
    public class TUtilisateurSociete
    {
        public int Id { get; set; }
        [Required]
        public int IdUser { get; set; }
        [Required]
        public int IdSociete { get; set; }

    }
}
