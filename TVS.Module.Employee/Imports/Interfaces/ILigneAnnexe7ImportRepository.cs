using System.Collections.Generic;
using TVS.Module.Employee.Imports.Views;

namespace Tvs.Module.Employee.Imports.Interfaces
{
    public interface ILigneAnnexeSeptImportRepository
    {
        IEnumerable<LigneAnnexe7ImportView> GetAll(string path);
    }
}