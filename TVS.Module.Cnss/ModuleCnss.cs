using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using TVS.Config;
using TVS.Config.Modules;

namespace TVS.Module.Cnss
{
    [ExportMainRibonPage(PageName = "pnvModuleCnss", Caption = "CNSS", LevelNo = 10, AllowTabbedViewHeader = true)]
    public class ModuleCnss : IModule
    {
        [ImportMany("CommandCnss", typeof(ICommand))] private Lazy<ICommand, IMainItemRibbonMetadata>[] _mainItems =
            null;

        [ImportMany("ParamCnss", typeof(IUserControlParam))] private Lazy<IUserControlParam, IItemListParamMetadata>[]
            _paramItems = null;

        public string Description
        {
            get { return "Module cnss"; }
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
            get { return TypeModule.Cnss; }
        }
    }
}