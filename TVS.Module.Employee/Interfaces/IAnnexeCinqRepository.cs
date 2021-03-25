using TVS.Module.Employee.Models;
using System.Collections.Generic;

namespace TVS.Module.Employee.Interfaces
{
    public interface IAnnexeCinqRepository
    {
        void Insert(LigneAnnexeCinq ligne);

        IEnumerable<LigneAnnexeCinq> GetAll(int societeId, int exerciceId);

        void Update(LigneAnnexeCinq ligne);

        void Delete(LigneAnnexeCinq ligne);

        LigneAnnexeCinq Get(int ligneNo);
    }
}