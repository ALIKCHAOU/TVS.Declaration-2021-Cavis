using System.Collections.Generic;
using TVS.Module.Employee.Models.Pieds;

namespace TVS.Module.Employee.Models
{
    public class AnnexeDeux : IAnnexe<LigneAnnexeDeux, PiedAnnexeDeux>
    {
        public IList<LigneAnnexeDeux> Lignes { get; set; }

        public EnteteAnnexe Entete { get; set; }

        public PiedAnnexeDeux Pied { get; set; }
    }
}