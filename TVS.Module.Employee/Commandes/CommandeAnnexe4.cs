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
    [ExportDecEmp(Caption = "Annexe 4", LevelNo = 40)]
    public class CommandeAnnexeQuatre : ICommand
    {
        public void Execute(CommandContext context)
        {
            if (!context.User.DecEmp)
            {
                throw new InvalidOperationException("Vous n'avez pas l'autorisation");
            }
            foreach (Form mdiChild in context.MainForm.MdiChildren)
            {
                var frm = mdiChild as FrmAnnexe<LigneAnnexeQuatre, PiedAnnexeQuatre>;
                if (frm == null)
                    continue;
                frm.Activate();
                return;
            }

            var pathDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            var annexeQuatreRepository = new AnnexeQuatreRepository(context.ConnectionProvider);
            var annexeImportRepository = new LigneAnnexe4ImportRepository();
            var exportRepo = new FileExportRepository(pathDirectory);
            var annexeQuatreservice = new Annexe4Service(annexeQuatreRepository, exportRepo, context.Societe,
                context.Exercice,
                annexeImportRepository);
            var controller = new DeclarationEmployeurController<LigneAnnexeQuatre, PiedAnnexeQuatre>(annexeQuatreservice);
            var form = new FrmAnnexe<LigneAnnexeQuatre, PiedAnnexeQuatre>(controller, context.Societe, context.Exercice);
            form.MdiParent = context.MainForm;
            form.Text = @"Annexe 4";
            form.Show();
        }

        public Image GetSmallImage
        {
            get { return Resources.a4; }
        }

        public Image GetLargeImage
        {
            get { return Resources.a4; }
        }
    }
}