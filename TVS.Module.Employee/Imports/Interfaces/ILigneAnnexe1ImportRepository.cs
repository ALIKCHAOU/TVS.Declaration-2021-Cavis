using System.Collections.Generic;
using TVS.Module.Employee.Imports.Views;

namespace Tvs.Module.Employee.Imports.Interfaces
{
    public interface ILigneAnnexeUnImportRepository
    {
        IEnumerable<LigneAnnexe1ImportView> GetAll(string path);
    }
}