using TVS.Module.Employee.Models;
using System.Collections.Generic;

namespace TVS.Module.Employee.Interfaces
{
    public interface IAnnexeTroisRepository
    {
        void Insert(LigneAnnexeTrois ligne);

        IEnumerable<LigneAnnexeTrois> GetAll(int societeId, int exerciceId);

        void Delete(LigneAnnexeTrois ligne);

        void Update(LigneAnnexeTrois ligne);

        LigneAnnexeTrois Get(int ligneNo);
    }
}