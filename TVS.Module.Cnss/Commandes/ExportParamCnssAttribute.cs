using System;
using System.ComponentModel.Composition;
using TVS.Config.Modules;

namespace TVS.Module.Cnss.Commandes
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportParamCnssAttribute : ExportAttribute, IItemListParamMetadata
    {
        public ExportParamCnssAttribute()
            : base("ParamCnss", typeof(IUserControlParam))
        {
        }

        public string ItemName { get; set; }

        public string Caption { get; set; }

        public int LevelNo { get; set; }
    }
}