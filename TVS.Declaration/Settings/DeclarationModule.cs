using Ninject.Extensions.Factory;
using Ninject.Modules;
using TVS.Config;
using TVS.Declaration.Societes.Controllers;
using TVS.Ef.Migration.Declaration;

namespace TVS.Declaration.Settings
{
    public class DeclarationModuleWin : NinjectModule
    {
        private readonly GroupConfiguration _groupConfigurationroup;

        public DeclarationModuleWin(GroupConfiguration groupConfigurationroup)
        {
            _groupConfigurationroup = groupConfigurationroup;
        }

        public override void Load()
        {
            Bind<IGroupContextManager>()
                .To<GroupContextFactory>().InSingletonScope()
                .WithConstructorArgument(typeof(IGroupConfiguration), _groupConfigurationroup);

            Bind<IUserControlFactory>().ToFactory().InSingletonScope();

            Bind<IFormFactory>().ToFactory().InSingletonScope();

            Bind<SocieteController>()
                .ToSelf()
                .InSingletonScope();
        }
    }
}