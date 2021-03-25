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
    [ExportDecEmp(Caption = "Annexe 7", LevelNo = 70)]
    public class CommandeAnnexe7 : ICommand
    {
        public void Execute(CommandContext context)
        {
            if (!context.User.DecEmp)
            {
                throw new InvalidOperationException("Vous n'avez pas l'autorisation");
            }
            foreach (Form mdiChild in context.MainForm.MdiChildren)
            {
                var frm = mdiChild as FrmAnnexe<LigneAnnexeSept, PiedAnnexeSept>;
                if (frm == null)
                    continue;
                frm.Activate();
                return;
            }

            var pathDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            var annexeSeptRepository = new AnnexeSeptRepository(context.ConnectionProvider);
            var exportRepo = new FileExportRepository(pathDirectory);
            var repoImport = new LigneAnnexeSeptImportRepository();
            var annexeSixRepository = new AnnexeSeptRepository(context.ConnectionProvider);
            var annexeSeptservice = new Annexe7Service(annexeSeptRepository,
                exportRepo,
                context.Societe,
                context.Exercice,
                repoImport,
                annexeSixRepository);
            var controller = new DeclarationEmployeurController<LigneAnnexeSept, PiedAnnexeSept>(annexeSeptservice);
            var form = new FrmAnnexe<LigneAnnexeSept, PiedAnnexeSept>(controller, context.Societe, context.Exercice);
            form.MdiParent = context.MainForm;
            form.Text = "Annexe 7";
            form.Show();
        }

        public Image GetSmallImage
        {
            get { return Resources.a7; }
        }

        public Image GetLargeImage
        {
            get { return Resources.a7; }
        }
    }
}