using System.Drawing;

namespace TVS.Config.Modules
{
    public interface ICommand
    {
        Image GetSmallImage { get; }

        Image GetLargeImage { get; }

        void Execute(CommandContext context);
    }
}