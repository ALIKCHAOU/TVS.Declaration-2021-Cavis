using System.Collections.Generic;
using TVS.Module.Employee.Models.Pieds;

namespace TVS.Module.Employee.Models
{
    public class AnnexeQuatre : IAnnexe<LigneAnnexeQuatre, PiedAnnexeQuatre>
    {
        public IList<LigneAnnexeQuatre> Lignes { get; set; }

        public EnteteAnnexe Entete { get; set; }

        public PiedAnnexeQuatre Pied { get; set; }
    }
}