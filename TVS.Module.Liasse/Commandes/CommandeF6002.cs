using System;
using TVS.Config.Modules;

using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using TVS.Module.Liasse.Properties;
using TVS.Config;
using Ninject;

namespace TVS.Module.Liasse.Commandes
{
    [ExportCommandLiasse(Caption = "F6002", LevelNo = 30)]
    public class CommandeF6002 : ICommand
    {
        public void Execute(CommandContext context)
        {SplashScreenManager.ShowForm(typeof(WaitForm1));
            if (!context.User.Liasse)
            {
                SplashScreenManager.CloseForm();
                throw new InvalidOperationException("Vous n'avez pas l'autorisation");
            }
            foreach (Form mdiChild in context.MainForm.MdiChildren)
            {
                var frm = mdiChild as Forms.XtraFrmF6002;
                if (frm == null)
                    continue;
                frm.Activate(); SplashScreenManager.CloseForm();
                return;
            }

            var form = ConfigProgram.Kernel.Get<Forms.XtraFrmF6002>();
            form.MdiParent = context.MainForm;
            form.Show();
            SplashScreenManager.CloseForm();
        }

        public Image GetSmallImage
        {
            get { return Resources.F6002; }
        }

        public Image GetLargeImage
        {
            get { return Resources.F6002; }
        }
    }
}