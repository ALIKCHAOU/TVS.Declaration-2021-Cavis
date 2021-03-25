using System.Collections.Generic;
using TVS.Module.FactureSuspenssion.Imports.Views;

namespace TVS.Module.FactureSuspenssion.Imports.Repository
{
    public interface IImportImportRepository
    {
        IEnumerable<LigneImportView> GetAll(string source);
    }
}