using Ninject;
using TVS.Config;
using TVS.Config.Modules;
namespace TVS.Module.Cnss.Commandes
{
    [ExportParamCnss(Caption = "Catégorie Cnss", LevelNo = 20)]
    public class CommandeCategorieCnss : IUserControlParam
    {
        public IOptionUserControl GetParam()
        {
            return ConfigProgram.Kernel.Get<UcCategorie>();
        }
    }
}