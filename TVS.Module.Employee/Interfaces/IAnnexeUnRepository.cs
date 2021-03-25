using TVS.Module.Employee.Models;
using System.Collections.Generic;

namespace TVS.Module.Employee.Interfaces
{
    public interface IAnnexeUnRepository
    {
        void Insert(LigneAnnexeUn ligne);

        bool ExistBeneficiaire(string ident);

        IEnumerable<LigneAnnexeUn> GetAll(int societeId, int exerciceId);

        void Delete(LigneAnnexeUn ligne);

        void Update(LigneAnnexeUn ligne);

        LigneAnnexeUn Get(int ligneNo);
    }
}