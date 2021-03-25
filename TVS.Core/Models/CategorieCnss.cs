using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Enums;

namespace TVS.Core.Models
{
    public class CategorieCnss
    {
        public int Id { get; set; }

        public int No { get; set; }

        public string Intitule { get; set; }

        public string CodeExploitation { get; set; }

        public decimal TauxSalarial { get; set; }

        public decimal TauxPatronal { get; set; }

        public decimal AccidentTravail { get; set; }

        public int SocieteNo { get; set; }

        public TypeVariablePaie TypeVariablePaie { get; set; }

        public string CodePaie { get; set; }
    }
}