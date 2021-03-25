using Ninject.Modules;
using TVS.Core;
using TVS.Core.Interfaces;
using TVS.Core.Interfaces.Liass;
using TVS.Dapper;
using TVS.Dapper.Liass;
using TVS.Dapper.Settings;

namespace TVS.Declaration.Modules
{
    public class CoreModule : NinjectModule
    {
        internal const string ModuleName = "CoreModule";

        public override string Name
        {
            get { return ModuleName; }
        }

        public override void Load()
        {
            #region Repositorires

            Bind<IConnectionProvider>()
                .To<ConnectionProvider>()
                .InSingletonScope();

            Bind<IExerciceRepository>()
                .To<ExerciceRepository>()
                .InSingletonScope();

            Bind<IUtilisateurSocieteRepository>()
               .To<UtilisateurSocieteRepository>()
               .InSingletonScope();

            Bind<ISocieteRepository>()
                .To<SocieteRepository>()
                .InSingletonScope();

            Bind<DeclarationService>()
                .To<DeclarationService>()
                .InSingletonScope();

            Bind<IDeclarationBcRepository>()
                .To<DeclarationBcRepository>()
                .InSingletonScope();

            Bind<IDeclarationFcRepository>()
                .To<DeclarationFcRepository>()
                .InSingletonScope();

            Bind<IDeclarationCnssRepository>()
                .To<DeclarationCnssRepository>()
                .InSingletonScope();

            Bind<ICategorieRepository>()
                .To<CategorieCnssRepository>()
                .InSingletonScope();

            Bind<IEmployeeRepository>()
                .To<EmployeeRepository>()
                .InSingletonScope();
            Bind<FcSuspenssionService>()
                .To<FcSuspenssionService>()
                .InSingletonScope();

            Bind<BcSuspenssionService>()
                .To<BcSuspenssionService>()
                .InSingletonScope();
            Bind<CnssService>()
                .To<CnssService>()
                .InSingletonScope();

            Bind<ILigneBcRepository>()
                .To<LigneBcRepository>()
                .InSingletonScope();
            Bind<ILigneFcRepository>()
                .To<LigneFcRepository>()
                .InSingletonScope();

            Bind<ILigneCnssRepository>()
                .To<LigneCnssRepository>()
                .InSingletonScope();

            Bind<IUserRepository>()
                .To<UserRepository>()
                .InSingletonScope();

            Bind<IVirementLigneRepository>()
                .To<VirementLigneRepository>()
                .InSingletonScope();

            Bind<IVirementEnteteRepository>()
                .To<VirementEnteteRepository>()
                .InSingletonScope();

            Bind<ISocieteBanqueRepository>()
                .To<SocieteBanqueRepository>()
                .InSingletonScope();

            Bind<IF6001Repository>()
                .To<F6001Repository>()
                .InSingletonScope();
            Bind<IF6002Repository>()
                .To<F6002Repository>()
                .InSingletonScope();
            Bind<IF6003Repository>()
                .To<F6003Repository>()
                .InSingletonScope();
            Bind<IF6004Repository>()
                .To<F6004Repository>()
                .InSingletonScope();
            Bind<IF6004ModeleAutorsieRepository>()
                .To<F6004ModeleAutorsieRepository>()
                .InSingletonScope();
            Bind<IF6005Repository>()
                .To<F6005Repository>()
                .InSingletonScope();
            Bind<IF6301Repository>()
               .To<F6301Repository>()
               .InSingletonScope();
            Bind<IF6303Repository>()
               .To<F6303Repository>()
               .InSingletonScope();
            Bind<IF6304Repository>()
               .To<F6304Repository>()
               .InSingletonScope();
            #endregion Repositorires
        }
    }
}