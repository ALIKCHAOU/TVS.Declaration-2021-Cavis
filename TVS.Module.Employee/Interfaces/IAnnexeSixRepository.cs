using TVS.Module.Employee.Models;
using System.Collections.Generic;

namespace TVS.Module.Employee.Interfaces
{
    public interface IAnnexeSixRepository
    {
        void Insert(LigneAnnexeSix ligne);

        IEnumerable<LigneAnnexeSix> GetAll(int societeId, int exerciceId);

        void Delete(LigneAnnexeSix ligne);

        void Update(LigneAnnexeSix ligne);

        LigneAnnexeSix Get(int ligneNo);
    }
}