using System;
using System.Drawing;
using System.Windows.Forms;
using CnssModule;
using CnssModule.Declarations;
using Ninject;
using TVS.Config;
using TVS.Config.Modules;
using TVS.Module.Cnss.Properties;
using TVS.Module.Cnss.UiCnss;

namespace TVS.Module.Cnss.Commandes
{
    [ExportCommandCnss(Caption = "Déclaration Cnss", LevelNo = 20)]
    public class CommandeCnssList : ICommand
    {
        public void Execute(CommandContext context)
        {
            if (!context.User.Cnss)
            {
                throw new InvalidOperationException("Vous n'avez pas l'autorisation");
            }
            foreach (Form mdiChild in context.MainForm.MdiChildren)
            {
                var frm = mdiChild as FrmListDeclarationCnss;
                if (frm == null)
                    continue;
                frm.Activate();
                return;
            }

            var form = ConfigProgram.Kernel.Get<FrmListDeclarationCnss>();
            form.MdiParent = context.MainForm;
            form.Show();
        }

        public Image GetSmallImage
        {
            get { return Resources.cnss; }
        }

        public Image GetLargeImage
        {
            get { return Resources.cnss; }
        }
    }
}