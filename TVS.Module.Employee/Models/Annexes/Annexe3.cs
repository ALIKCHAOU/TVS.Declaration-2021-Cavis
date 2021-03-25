using System.Collections.Generic;
using TVS.Module.Employee.Models.Pieds;

namespace TVS.Module.Employee.Models
{
    public class AnnexeTrois : IAnnexe<LigneAnnexeTrois, PiedAnnexeTrois>
    {
        public IList<LigneAnnexeTrois> Lignes { get; set; }

        public EnteteAnnexe Entete { get; set; }

        public PiedAnnexeTrois Pied { get; set; }
    }
}