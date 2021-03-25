using TVS.Config;
using TVS.Module.BcSuspenssion.Imports.Repository;

namespace TVS.Module.BcSuspenssion
{
    public static class InitModule
    {
        public static void Init()
        {
            ConfigProgram.Kernel.Bind<ILigneImportRepository>()
                .To<LigneImportRepository>()
                .InSingletonScope();
        }
    }
}