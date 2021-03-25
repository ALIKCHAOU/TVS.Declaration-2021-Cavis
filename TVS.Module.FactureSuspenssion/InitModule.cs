using TVS.Config;
using TVS.Module.FactureSuspenssion.Imports.Repository;

namespace TVS.Module.FactureSuspenssion
{
    public class InitModule
    {
        public static void Init()
        {
            ConfigProgram.Kernel.Bind<IImportImportRepository>()
                .To<ImportImportRepository>()
                .InSingletonScope();
        }
    }
}