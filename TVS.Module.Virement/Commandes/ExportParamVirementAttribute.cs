using System;
using System.ComponentModel.Composition;
using TVS.Config.Modules;

namespace TVS.Module.Virement.Commandes
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportParamVirementAttribute : ExportAttribute, IItemListParamMetadata
    {
        public ExportParamVirementAttribute(): base("ParamVirement", typeof(IUserControlParam))
        {
        }

        public string ItemName { get; set; }

        public string Caption { get; set; }

        public int LevelNo { get; set; }
    }
}