using TVS.Config.Modules;
using System;
using System.ComponentModel.Composition;

namespace TVS.Module.Employee.Commandes
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportDecEmpAttribute : ExportAttribute, IMainItemRibbonMetadata
    {
        public ExportDecEmpAttribute()
            : base("CommandDecEmp", typeof(ICommand))
        {
        }

        public string ItemName { get; set; }

        public string Caption { get; set; }

        public int LevelNo { get; set; }

        public TypeButton TypeButton
        {
            get { return TypeButton.SimpleButton; }
        }
    }
}