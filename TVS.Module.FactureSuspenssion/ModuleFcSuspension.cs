using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using TVS.Config;
using TVS.Config.Modules;

namespace TVS.Module.FactureSuspenssion
{
    [ExportMainRibonPage(PageName = "pnvModuleFC", Caption = "Vente en suspension", LevelNo = 30,
         AllowTabbedViewHeader = true)]
    public class ModuleFcSuspension : IModule
    {
        [ImportMany("CommandFcSuspension", typeof(ICommand))] private Lazy<ICommand, IMainItemRibbonMetadata>[]
            _mainItems = null;

        [ImportMany("ParamFc", typeof(IUserControlParam))] private Lazy<IUserControlParam, IItemListParamMetadata>[]
            _paramItems = null;

        public string Description
        {
            get { return "Module Vente en suspension"; }
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
            get { return TypeModule.FcSuspension; }
        }
    }
}