using Tvs.Module.Employee.Imports.Interfaces;
using TVS.Config;
using TVS.Module.Employee.Dal;
using TVS.Module.Employee.Imports.Repsitory;
using TVS.Module.Employee.Interfaces;

namespace TVS.Module.Employee
{
    public static class InitModule
    {
        public static void Init()
        {
            ConfigProgram.Kernel.Bind<IAnnexeUnRepository>()
                .To<AnnexeUnRepository>()
                .InSingletonScope();

            ConfigProgram.Kernel.Bind<IAnnexeDeuxRepository>()
                .To<AnnexeDeuxRepository>()
                .InSingletonScope();

            ConfigProgram.Kernel.Bind<IAnnexeTroisRepository>()
                .To<AnnexeTroisRepository>()
                .InSingletonScope();

            ConfigProgram.Kernel.Bind<IAnnexeQuatreRepository>()
                .To<AnnexeQuatreRepository>()
                .InSingletonScope();

            ConfigProgram.Kernel.Bind<IAnnexeCinqRepository>()
                .To<AnnexeCinqRepository>()
                .InSingletonScope();

            ConfigProgram.Kernel.Bind<IAnnexeSixRepository>()
                .To<AnnexeSixRepository>()
                .InSingletonScope();

            ConfigProgram.Kernel.Bind<IAnnexeSeptRepository>()
                .To<AnnexeSeptRepository>()
                .InSingletonScope();

            ConfigProgram.Kernel.Bind<ILigneAnnexeUnImportRepository>()
                .To<LigneAnnexe1ImportRepository>()
                .InSingletonScope();

            //ConfigProgram.Kernel.Bind<ILigneAnnexeDeuxImportRepository>()
            //    .To<LigneAnnexeDeuxImportRepository>()
            //    .InSingletonScope();

            ConfigProgram.Kernel.Bind<ILigneAnnexeTroisImportRepository>()
                .To<LigneAnnexe3ImportRepository>()
                .InSingletonScope();

            ConfigProgram.Kernel.Bind<ILigneAnnexeQuatreImportRepository>()
                .To<LigneAnnexe4ImportRepository>()
                .InSingletonScope();

            ConfigProgram.Kernel.Bind<ILigneAnnexeCinqImportRepository>()
                .To<LigneAnnexe5ImportRepository>()
                .InSingletonScope();

            ConfigProgram.Kernel.Bind<ILigneAnnexeSixImportRepository>()
                .To<LigneAnnexe6ImportRepository>()
                .InSingletonScope();

            //ConfigProgram.Kernel.Bind<ILigneAnnexeSeptImportRepository>()
            //    .To<LigneAnnexeSeptImportRepository>()
            //    .InSingletonScope();

            //ConfigProgram.Kernel.Bind<IConnectionProvider>()
            //    .To<SqliteConnectionProvider>()
            //    .InSingletonScope();
        }
    }
}