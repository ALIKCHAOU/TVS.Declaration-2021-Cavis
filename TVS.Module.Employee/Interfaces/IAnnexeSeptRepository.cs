using TVS.Module.Employee.Models;
using System.Collections.Generic;

namespace TVS.Module.Employee.Interfaces
{
    public interface IAnnexeSeptRepository
    {
        void Insert(LigneAnnexeSept ligne);

        IEnumerable<LigneAnnexeSept> GetAll(int societeId, int exerciceId);

        void Delete(LigneAnnexeSept ligne);

        void Update(LigneAnnexeSept ligne);

        LigneAnnexeSept Get(int ligneNo);
    }
}