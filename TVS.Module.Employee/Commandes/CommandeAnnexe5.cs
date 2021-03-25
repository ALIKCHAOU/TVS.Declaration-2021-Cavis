using System;
using TVS.Config.Modules;
using TVS.Module.Employee.Dal;
using TVS.Module.Employee.Models;
using TVS.Module.Employee.Properties;
using TVS.Module.Employee.Services;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Tvs.Module.Employee.DalExport;
using TVS.Module.Employee.Imports.Repsitory;
using TVS.Module.Employee.Models.Pieds;
using TVS.Module.Employee.UiAnnexe;

namespace TVS.Module.Employee.Commandes
{
    [ExportDecEmp(Caption = "Annexe 5", LevelNo = 50)]
    public class CommandeAnnexeCinq : ICommand
    {
        public void Execute(CommandContext context)
        {
            if (!context.User.DecEmp)
            {
                throw new InvalidOperationException("Vous n'avez pas l'autorisation");
            }
            foreach (Form mdiChild in context.MainForm.MdiChildren)
            {
                var frm = mdiChild as FrmAnnexe<LigneAnnexeCinq, PiedAnnexeCinq>;
                if (frm == null)
                    continue;
                frm.Activate();
                return;
            }

            var pathDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            var annexeRepository = new AnnexeCinqRepository(context.ConnectionProvider);
            var annexeImportRepository = new LigneAnnexe5ImportRepository();
            var exportRepo = new FileExportRepository(pathDirectory);
            var annexeCinqservice = new Annexe5Service(annexeRepository, exportRepo, context.Societe,
                context.Exercice, annexeImportRepository);
            var controller = new DeclarationEmployeurController<LigneAnnexeCinq, PiedAnnexeCinq>(annexeCinqservice);
            var form = new FrmAnnexe<LigneAnnexeCinq, PiedAnnexeCinq>(controller, context.Societe, context.Exercice);
            form.MdiParent = context.MainForm;
            form.Text = "Annexe 5";
            form.Show();
        }

        public Image GetSmallImage
        {
            get { return Resources.a5; }
        }

        public Image GetLargeImage
        {
            get { return Resources.a5; }
        }
    }
}