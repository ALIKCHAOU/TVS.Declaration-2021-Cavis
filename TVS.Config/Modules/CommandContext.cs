using System.ComponentModel.Composition.Hosting;
using System.Windows.Forms;
using TVS.Core;
using TVS.Core.Models;

namespace TVS.Config.Modules
{
    public class CommandContext
    {
        public Form MainForm { get; set; }

        public CompositionContainer Container { get; set; }

        public Societe Societe { get; set; }

        public Exercice Exercice { get; set; }
        public User User { get; set; }

        public IConnectionProvider ConnectionProvider { get; set; }
    }
}