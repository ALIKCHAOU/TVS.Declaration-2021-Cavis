using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Ef.Migration.Declaration.Models
{
    [Table("SocieteBanque")]
    public class TSocieteBanque
    {
        public int Id { get; set; }
        public int SocieteId { get; set; }
        public int Banque { get; set; }
        public string Agence { get; set; }
        public string Adresse { get; set; }
        public string Rib { get; set; }
    }
}
