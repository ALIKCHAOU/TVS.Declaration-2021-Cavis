using TVS.Config.Modules;
using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace TVS.Config
{
    public class PageItems
    {
        [ImportMany("ExportItemRibon", typeof(ICommand), RequiredCreationPolicy = CreationPolicy.NonShared)] private
            Lazy<ICommand, IMainItemRibbonMetadata>[] _optionPages;

        public string[] ItemName()
        {
            return _optionPages.Select(x => x.Metadata.Caption).ToArray();
        }
    }
}