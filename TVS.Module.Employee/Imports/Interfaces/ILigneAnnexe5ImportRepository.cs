using TVS.Module.Employee.Imports.Views;
using System.Collections.Generic;

namespace Tvs.Module.Employee.Imports.Interfaces
{
    public interface ILigneAnnexeCinqImportRepository
    {
        IEnumerable<LigneAnnexe5ImportView> GetAll(string path);
    }
}