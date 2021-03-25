using TVS.Config.Modules;
using System;
using System.ComponentModel.Composition;

namespace TVS.Config
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportMainRibonPageAttribute : ExportAttribute, IMainPageRibonMetadata
    {
        public ExportMainRibonPageAttribute()
            : base("MainPageRibon", typeof(IModule))
        {
        }

        public string PageName { get; set; }

        public string Caption { get; set; }

        public int LevelNo { get; set; }

        public bool AllowTabbedViewHeader { get; set; }
    }
}