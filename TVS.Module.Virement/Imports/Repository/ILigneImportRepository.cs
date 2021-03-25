using System.Collections.Generic;
using TVS.Module.Virement.Imports.Views;

namespace TVS.Module.Virement.Imports.Repository
{
    public interface ILigneImportRepository
    {
        IEnumerable<LigneImportView> GetAll(string source);
    }
}