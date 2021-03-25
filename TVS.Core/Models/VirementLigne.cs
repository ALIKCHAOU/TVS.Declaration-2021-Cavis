using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Enums;

namespace TVS.Core.Models
{
    public class VirementLigne
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

        public string Rib
        {
            get
            {
                return string.Format("{0}{1}{2}{3}", CodeBanque.PadLeft(2, '0'), CodeGuichet.PadLeft(5, '0'),
                    NumeroCompte.PadLeft(11, '0'), CleRib.PadLeft(2, '0'));
            }
        }
    }
}
