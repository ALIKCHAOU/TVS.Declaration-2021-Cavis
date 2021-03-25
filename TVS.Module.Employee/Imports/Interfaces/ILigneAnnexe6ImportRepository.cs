using TVS.Module.Employee.Imports.Views;
using System.Collections.Generic;

namespace Tvs.Module.Employee.Imports.Interfaces
{
    public interface ILigneAnnexeSixImportRepository
    {
        IEnumerable<LigneAnnexe6ImportView> GetAll(string path);
    }
}