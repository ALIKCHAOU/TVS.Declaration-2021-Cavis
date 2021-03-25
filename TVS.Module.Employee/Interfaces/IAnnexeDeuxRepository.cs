using TVS.Module.Employee.Models;
using System.Collections.Generic;

namespace TVS.Module.Employee.Interfaces
{
    public interface IAnnexeDeuxRepository
    {
        void Insert(LigneAnnexeDeux ligne);

        IEnumerable<LigneAnnexeDeux> GetAll(int societeId, int exerciceId);

        void Delete(LigneAnnexeDeux ligne);

        void Update(LigneAnnexeDeux ligne);

        LigneAnnexeDeux Get(int ligneNo);
    }
}