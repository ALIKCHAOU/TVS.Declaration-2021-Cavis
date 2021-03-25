using System.Collections.Generic;
using TVS.Module.Employee.Models.Pieds;

namespace TVS.Module.Employee.Models
{
    public class AnnexeCinq : IAnnexe<LigneAnnexeCinq, PiedAnnexeCinq>
    {
        public IList<LigneAnnexeCinq> Lignes { get; set; }

        public EnteteAnnexe Entete { get; set; }

        public PiedAnnexeCinq Pied { get; set; }
    }
}