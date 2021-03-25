using System;
using System.ComponentModel.Composition;
using TVS.Config.Modules;

namespace TVS.Module.Cnss.Commandes
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportCommandCnssAttribute : ExportAttribute, IMainItemRibbonMetadata
    {
        public ExportCommandCnssAttribute()
            : base("CommandCnss", typeof(ICommand))
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