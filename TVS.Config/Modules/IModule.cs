using System;
using System.Collections.Generic;

namespace TVS.Config.Modules
{
    public interface IModule
    {
        string Description { get; }

        void Init(CommandContext context);

        TypeModule Type { get; }

        ICollection<Lazy<ICommand, IMainItemRibbonMetadata>> GetCommands();

        ICollection<Lazy<IUserControlParam, IItemListParamMetadata>> GetParameters();
    }
}