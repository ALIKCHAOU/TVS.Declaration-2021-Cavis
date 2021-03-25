using TVS.Module.Employee.Imports.Views;
using System.Collections.Generic;

namespace Tvs.Module.Employee.Imports.Interfaces
{
    public interface ILigneAnnexeQuatreImportRepository
    {
        IEnumerable<LigneAnnexe4ImportView> GetAll(string path);
    }
}