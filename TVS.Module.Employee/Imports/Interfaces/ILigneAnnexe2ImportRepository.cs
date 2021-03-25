using TVS.Module.Employee.Imports.Views;
using System.Collections.Generic;

namespace Tvs.Module.Employee.Imports.Interfaces
{
    public interface ILigneAnnexeDeuxImportRepository
    {
        IEnumerable<LigneAnnexe2ImportView> GetAll(string path);
    }
}