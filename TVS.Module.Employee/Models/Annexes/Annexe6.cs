using System.Collections.Generic;
using TVS.Module.Employee.Models.Pieds;

namespace TVS.Module.Employee.Models
{
    public class AnnexeSix : IAnnexe<LigneAnnexeSix, PiedAnnexeSix>
    {
        public IList<LigneAnnexeSix> Lignes { get; set; }

        public EnteteAnnexe Entete { get; set; }

        public PiedAnnexeSix Pied { get; set; }
    }
}