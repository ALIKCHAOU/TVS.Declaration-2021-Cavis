using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using TVS.Config;
using TVS.Config.Modules;

namespace TVS.Module.Employee
{
    [ExportMainRibonPage(PageName = "pnvDecEmp", Caption = "Declaration employeurs", LevelNo = 5,
         AllowTabbedViewHeader = false)]
    public class ModuleDeclarationEmployeur : IModule
    {
        [ImportMany("CommandDecEmp", typeof(ICommand))] private Lazy<ICommand, IMainItemRibbonMetadata>[] _mainItems =
            null;

        [ImportMany("ParamDecEmp", typeof(IUserControlParam))] private Lazy<IUserControlParam, IItemListParamMetadata>[]
            _paramItems = null;

        public string Description
        {
            get { return "Module declaration employeurs"; }
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
            get { return TypeModule.DecEmp; }
        }
    }
}