using System.Collections.Generic;
using TVS.Module.Employee.Models.Pieds;

namespace TVS.Module.Employee.Models
{
    public class AnnexeUn : IAnnexe<LigneAnnexeUn, PiedAnnexeUn>
    {
        public IList<LigneAnnexeUn> Lignes { get; set; }

        public EnteteAnnexe Entete { get; set; }

        public PiedAnnexeUn Pied { get; set; }
    }
}