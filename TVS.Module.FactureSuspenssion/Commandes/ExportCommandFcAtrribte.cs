using System;
using System.ComponentModel.Composition;
using TVS.Config.Modules;

namespace TVS.Module.FactureSuspenssion.Commandes
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportCommandFcAttribute : ExportAttribute, IMainItemRibbonMetadata
    {
        public ExportCommandFcAttribute()
            : base("CommandFcSuspension", typeof(ICommand))
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