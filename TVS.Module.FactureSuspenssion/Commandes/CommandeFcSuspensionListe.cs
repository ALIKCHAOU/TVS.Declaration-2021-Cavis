using System;
using System.Drawing;
using System.Windows.Forms;
using Ninject;
using TVS.Config;
using TVS.Config.Modules;
using TVS.Module.FactureSuspenssion.Properties;
using TVS.Module.FactureSuspenssion.UFactures;

namespace TVS.Module.FactureSuspenssion.Commandes
{
    [ExportCommandFc(Caption = "Facture en suspension", LevelNo = 20)]
    public class CommandFcSuspensionListe : ICommand
    {
        public void Execute(CommandContext context)
        {

            if (!context.User.Vente)
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
            get { return Resources.FC; }
        }

        public Image GetLargeImage
        {
            get { return Resources.FC; }
        }
    }
}