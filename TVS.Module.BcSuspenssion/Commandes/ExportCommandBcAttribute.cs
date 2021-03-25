using System;
using System.ComponentModel.Composition;
using TVS.Config.Modules;

namespace TVS.Module.BcSuspenssion.Commandes
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportCommandBcAttribute : ExportAttribute, IMainItemRibbonMetadata
    {
        public ExportCommandBcAttribute()
            : base("CommandBcSuspension", typeof(ICommand))
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