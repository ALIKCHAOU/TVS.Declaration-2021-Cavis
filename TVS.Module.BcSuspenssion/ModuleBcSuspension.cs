using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using TVS.Config;
using TVS.Config.Modules;

namespace TVS.Module.BcSuspenssion
{
    [ExportMainRibonPage(PageName = "pnvModuleC", Caption = "Achat en suspension", LevelNo = 20,
         AllowTabbedViewHeader = true)]
    public class ModuleBcSuspension : IModule
    {
        [ImportMany("CommandBcSuspension", typeof(ICommand))] private Lazy<ICommand, IMainItemRibbonMetadata>[]
            _mainItems = null;

        [ImportMany("ParamBc", typeof(IUserControlParam))] private Lazy<IUserControlParam, IItemListParamMetadata>[]
            _paramItems = null;

        public string Description
        {
            get { return "Module Achat en suspension"; }
        }

        public void Init(CommandContext context)
        {
            var container = context.Container;
            container.ComposeParts(this);
            InitModule.Init();
        }

        public ICollection<Lazy<ICommand, IMainItemRibbonMetadata>> GetCommands()
        {
            return _mainItems;
        }

        public ICollection<Lazy<IUserControlParam, IItemListParamMetadata>> GetParameters()
        {
            return _paramItems;
        }

        public TypeModule Type
        {
            get { return TypeModule.BcSuspension; }
        }
    }
}