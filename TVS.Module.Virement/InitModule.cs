using TVS.Config;
using TVS.Module.Virement.Imports.Controller;
using TVS.Module.Virement.Imports.Repository;
using TVS.Module.Virement.UcConfig.Controller;
using TVS.Module.Virement.UiVirement.Controller;


namespace TVS.Module.Virement
{
    public static class InitModule
    {
        public static void Init()
        {
            ConfigProgram.Kernel.Bind<BanqueController>()
                .ToSelf()
                .InSingletonScope();

            ConfigProgram.Kernel.Bind<ImportController>()
                .ToSelf()
                .InSingletonScope();

            ConfigProgram.Kernel.Bind<DeclarationController>()
                .ToSelf()
                .InSingletonScope();

            ConfigProgram.Kernel.Bind<ILigneImportRepository>()
                .To<LigneImportRepository>()
                .InSingletonScope();
        }
    }
}