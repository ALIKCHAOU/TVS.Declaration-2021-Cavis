using System;
using TVS.Config.Modules;
using TVS.Module.Employee.Dal;
using TVS.Module.Employee.Models;
using TVS.Module.Employee.Properties;
using TVS.Module.Employee.Services;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TVS.Module.Employee.UiAnnexe;
using Tvs.Module.Employee.DalExport;
using TVS.Module.Employee.Imports.Repsitory;
using TVS.Module.Employee.Models.Pieds;

namespace TVS.Module.Employee.Commandes
{
    [ExportDecEmp(Caption = "Annexe 1", LevelNo = 10)]
    public class CommandeCnssList : ICommand
    {
        public void Execute(CommandContext context)
        {
            if (!context.User.DecEmp || !context.User.DecEmpAnnexe1)
            {
                throw new InvalidOperationException("Vous n'avez pas l'autorisation");
            }
            foreach (Form mdiChild in context.MainForm.MdiChildren)
            {
                var frm = mdiChild as FrmAnnexe<LigneAnnexeUn, PiedAnnexeUn>;
                if (frm == null)
                    continue;
                frm.Activate();
                return;
            }

            var pathDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            var annexeUnRepository = new AnnexeUnRepository(context.ConnectionProvider);
            var annexeImportRepository = new LigneAnnexe1ImportRepository();
            var exportRepo = new FileExportRepository(pathDirectory);
            var annexeUnservice = new Annexe1Service(annexeUnRepository, exportRepo, context.Societe, context.Exercice,
                annexeImportRepository);
            var controller = new DeclarationEmployeurController<LigneAnnexeUn, PiedAnnexeUn>(annexeUnservice);
            var form = new FrmAnnexe<LigneAnnexeUn, PiedAnnexeUn>(controller, context.Societe, context.Exercice);
            form.MdiParent = context.MainForm;
            form.Text = "Annexe 1";
            form.Show();
        }

        public Image GetSmallImage
        {
            get { return Resources.a1; }
        }

        public Image GetLargeImage
        {
            get { return Resources.a1; }
        }
    }
}