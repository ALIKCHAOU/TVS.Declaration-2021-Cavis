using System.Collections.Generic;
using TVS.Module.BcSuspenssion.Imports.Views;

namespace TVS.Module.BcSuspenssion.Imports.Repository
{
    public interface ILigneImportRepository
    {
        IEnumerable<LigneBcSuspendueImportView> GetAll(string source);
    }
}