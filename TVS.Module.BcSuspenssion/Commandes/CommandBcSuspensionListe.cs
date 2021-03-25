using System;
using System.Drawing;
using System.Windows.Forms;
using Ninject;
using TVS.Config;
using TVS.Config.Modules;
using TVS.Module.BcSuspenssion.Properties;
using TVS.Module.BcSuspenssion.UiBc;

namespace TVS.Module.BcSuspenssion.Commandes
{
    [ExportCommandBc(Caption = "Bon Commande en suspension", LevelNo = 20)]
    public class CommandBcSuspensionListe : ICommand
    {
        public void Execute(CommandContext context)
        {

            if (!context.User.Achat)
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
            get { return Resources.BC; }
        }

        public Image GetLargeImage
        {
            get { return Resources.BC; }
        }
    }
}