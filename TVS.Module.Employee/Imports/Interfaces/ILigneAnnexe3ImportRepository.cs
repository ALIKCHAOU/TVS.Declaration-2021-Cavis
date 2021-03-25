using TVS.Module.Employee.Imports.Views;
using System.Collections.Generic;

namespace Tvs.Module.Employee.Imports.Interfaces
{
    public interface ILigneAnnexeTroisImportRepository
    {
        IEnumerable<LigneAnnexe3ImportView> GetAll(string path);
    }
}