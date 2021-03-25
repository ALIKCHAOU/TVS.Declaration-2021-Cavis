using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Core.Models
{
    public class AttestationSalaire
    {
        public string Nom { get; set; }
        public string Matricule { get; set;  }
        public string Prenom { get; set; }

        public string Année { get; set; }

        public int Trimestre { get; set; }
        public decimal Brut1 { get; set; }
        public decimal Brut2 { get; set;  }
        public decimal Brut3 { get; set; }

        public decimal Montant
        {
            get
            {
                return Brut1 + Brut2 + Brut3;
            }
        }
        public int Page { get; set; }

        public int Ligne { get; set; }

        public string NomSociete { get; set; }

        public string CNSS_Societe { get; set; }

        public string CNSS_Empolye { get; set; }
        
    }
}
