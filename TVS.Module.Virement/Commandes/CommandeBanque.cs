
using Ninject;
using TVS.Config;
using TVS.Config.Modules;
using TVS.Module.Virement.UcConfig;


namespace TVS.Module.Virement.Commandes
{
    [ExportParamVirement(Caption = "Banques", LevelNo = 20)]
    public class CommandeBanque : IUserControlParam
    {
        public IOptionUserControl GetParam()
        {
            return ConfigProgram.Kernel.Get<UcBanque>();
        }
    }
}