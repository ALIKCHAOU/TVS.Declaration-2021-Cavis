using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Enums;

namespace TVS.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string NomJeuneFille { get; set; }

        public string Cin { get; set; }

        public SituationFamille SituationFamille { get; set; }

        public Civilite Civilite { get; set; }

        public string NumeroCnss { get; set; }

        public string CleCnss { get; set; }

        public int CategorieNo { get; set; }

        public string NumeroInterne { get; set; }

        public string AutresNom { get; set; }

        public int SocieteNo { get; set; }
    }
}