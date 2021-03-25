using TVS.Config;
using TVS.Module.Cnss.Imports.Controller;
using TVS.Module.Cnss.UcConfig.Controller;
using TVS.Module.Cnss.UiCnss.Controller;

namespace TVS.Module.Cnss
{
    public static class InitModule
    {
        public static void Init()
        {
            ConfigProgram.Kernel.Bind<CategorieController>()
                .ToSelf()
                .InSingletonScope();

            ConfigProgram.Kernel.Bind<ImportController>()
                .ToSelf()
                .InSingletonScope();

            ConfigProgram.Kernel.Bind<DeclarationsController>()
                .ToSelf()
                .InSingletonScope();

            ConfigProgram.Kernel.Bind<IDeclarationCnssImportRepository>()
                .To<ReglementClientCsvRepository>()
                .InSingletonScope();
        }
    }
}