using TVS.Module.Employee.Models;
using System.Collections.Generic;

namespace TVS.Module.Employee.Interfaces
{
    public interface IAnnexeQuatreRepository
    {
        void Insert(LigneAnnexeQuatre ligne);

        IEnumerable<LigneAnnexeQuatre> GetAll(int societeId, int exerciceId);

        void Delete(LigneAnnexeQuatre ligne);

        void Update(LigneAnnexeQuatre ligne);

        LigneAnnexeQuatre Get(int ligneNo);
    }
}