using System.Collections.Generic;
using TVS.Module.Employee.Models.Pieds;

namespace TVS.Module.Employee.Models
{
    public class AnnexeSept : IAnnexe<LigneAnnexeSept, PiedAnnexeSept>
    {
        public IList<LigneAnnexeSept> Lignes { get; set; }

        public EnteteAnnexe Entete { get; set; }

        public PiedAnnexeSept Pied { get; set; }
    }
}