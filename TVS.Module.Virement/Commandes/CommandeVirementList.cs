using System;
using System.Drawing;
using System.Windows.Forms;

using Ninject;
using TVS.Config;
using TVS.Config.Modules;
using TVS.Module.Virement.Properties;
using TVS.Module.Virement.UiVirement;


namespace TVS.Module.Virement.Commandes
{
    [ExportCommandVirement(Caption = "Virement Bancaire", LevelNo = 20)]
    public class CommandeVirementList : ICommand
    {
        public void Execute(CommandContext context)
        {
            if (!context.User.Virement)
            {
                throw new InvalidOperationException("Vous n'avez pas l'autorisation");
            }
            foreach (Form mdiChild in context.MainForm.MdiChildren)
            {
                var frm = mdiChild as FrmListDeclaration;
                if (frm == null)
                    continue;
                frm.Activate();
                return;
            }

            var form = ConfigProgram.Kernel.Get<FrmListDeclaration>();
            form.MdiParent = context.MainForm;
            form.Show();
        }

        public Image GetSmallImage
        {
            get { return Resources.bq; }
        }

        public Image GetLargeImage
        {
            get { return Resources.bq; }
        }
    }
}