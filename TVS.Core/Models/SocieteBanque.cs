using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Enums;

namespace TVS.Core.Models
{
    public class SocieteBanque
    {
        public int Id { get; set; }
        public int SocieteId { get; set; }
        public Banque Banque { get; set; }
        public string Agence { get; set; }
        public string Adresse { get; set; }
        public string Rib { get; set; }
    }
}
