using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Input;
using TVS.Config;
using TVS.Config.Modules;

namespace TVS.Module.Virement
{
    [ExportMainRibonPage(PageName = "pnvModuleVirement", Caption = "Virement", LevelNo = 10, AllowTabbedViewHeader = true)]
    public class ModuleVirement : IModule
    {
        [ImportMany("CommandVirement", typeof(Config.Modules.ICommand))] private Lazy<Config.Modules.ICommand, IMainItemRibbonMetadata>[] _mainItems =
            null;

        [ImportMany("ParamVirement", typeof(IUserControlParam))] private Lazy<IUserControlParam, IItemListParamMetadata>[]_paramItems = null;

        public string Description
        {
            get { return "Module virement"; }
        }

        public void Init(CommandContext context)
        {
            var container = context.Container;
            container.ComposeParts(this);
            InitModule.Init();
        }

        public ICollection<Lazy<Config.Modules.ICommand, IMainItemRibbonMetadata>> GetCommands()
        {
            return _mainItems;
        }

        public ICollection<Lazy<IUserControlParam, IItemListParamMetadata>> GetParameters()
        {
            return _paramItems;
        }

     

        public TypeModule Type
        {
            get { return TypeModule.VirementBancaire; }
        }
    }
}