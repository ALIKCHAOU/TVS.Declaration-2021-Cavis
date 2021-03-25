using System;
using System.ComponentModel.Composition;
using TVS.Config.Modules;

namespace TVS.Module.Liasse.Commandes
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportCommandLiasseAttribute : ExportAttribute, IMainItemRibbonMetadata
    {
        public ExportCommandLiasseAttribute()
            : base("CommandLiasse", typeof(ICommand))
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