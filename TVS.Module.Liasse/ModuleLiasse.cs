using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using TVS.Config;
using TVS.Config.Modules;

namespace TVS.Module.Liasse
{
    [ExportMainRibonPage(PageName = "pnvModuleLiasse", Caption = "Liasse", LevelNo = 30,
         AllowTabbedViewHeader = true)]
    public class ModuleLiasse : IModule
    {
        [ImportMany("CommandLiasse", typeof(ICommand))] private Lazy<ICommand, IMainItemRibbonMetadata>[]
            _mainItems = null;

        [ImportMany("ParamLiasse", typeof(IUserControlParam))] private Lazy<IUserControlParam, IItemListParamMetadata>[]
            _paramItems = null;

        public string Description
        {
            get { return "Module Liasse Fiscal"; }
        }

        public void Init(CommandContext context)
        {
            var container = context.Container;
            container.ComposeParts(this);
           // InitModule.Init();
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
            get { return TypeModule.Liasse; }
        }
    }
}