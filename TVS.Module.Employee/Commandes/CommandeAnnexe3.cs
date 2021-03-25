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
    [ExportDecEmp(Caption = "Annexe 3", LevelNo = 30)]
    public class CommandeTroisCnssList : ICommand
    {
        public void Execute(CommandContext context)
        {
            if (!context.User.DecEmp)
            {
                throw new InvalidOperationException("Vous n'avez pas l'autorisation");
            }
            foreach (Form mdiChild in context.MainForm.MdiChildren)
            {
                var frm = mdiChild as FrmAnnexe<LigneAnnexeTrois, PiedAnnexeTrois>;
                if (frm == null)
                    continue;
                frm.Activate();
                return;
            }

            var pathDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            var annexeTroisRepository = new AnnexeTroisRepository(context.ConnectionProvider);
            var annexeImportRepository = new LigneAnnexe3ImportRepository();
            var exportRepo = new FileExportRepository(pathDirectory);
            var annexeTroisservice = new Annexe3Service(annexeTroisRepository, exportRepo, context.Societe,
                context.Exercice,
                annexeImportRepository);
            var controller = new DeclarationEmployeurController<LigneAnnexeTrois, PiedAnnexeTrois>(annexeTroisservice);
            var form = new FrmAnnexe<LigneAnnexeTrois, PiedAnnexeTrois>(controller, context.Societe, context.Exercice);
            form.MdiParent = context.MainForm;
            form.Text = "Annexe 3";
            form.Show();
        }

        public Image GetSmallImage
        {
            get { return Resources.a3; }
        }

        public Image GetLargeImage
        {
            get { return Resources.a3; }
        }
    }
}