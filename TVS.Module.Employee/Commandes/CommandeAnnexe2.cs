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
    [ExportDecEmp(Caption = "Annexe 2", LevelNo = 20)]
    public class CommandeAnnexe2 : ICommand
    {
        public void Execute(CommandContext context)
        {
            if (!context.User.DecEmp)
            {
                throw new InvalidOperationException("Vous n'avez pas l'autorisation");
            }
            foreach (Form mdiChild in context.MainForm.MdiChildren)
            {
                var frm = mdiChild as FrmAnnexe<LigneAnnexeDeux, PiedAnnexeDeux>;
                if (frm == null)
                    continue;
                frm.Activate();
                return;
            }
            var pathDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            var annexeDeuxRepository = new AnnexeDeuxRepository(context.ConnectionProvider);

            var annexeImportRepository = new LigneAnnexe2ImportRepository();
            var exportRepo = new FileExportRepository(pathDirectory);
            var annexeDeuxservice = new Annexe2Service(annexeDeuxRepository, exportRepo, context.Societe,
                context.Exercice,
                annexeImportRepository);
            var controller = new DeclarationEmployeurController<LigneAnnexeDeux, PiedAnnexeDeux>(annexeDeuxservice);
            var form = new FrmAnnexe<LigneAnnexeDeux, PiedAnnexeDeux>(controller, context.Societe, context.Exercice);
            form.MdiParent = context.MainForm;
            form.Text = @"Annexe 2";
            form.Show();
        }

        public Image GetSmallImage
        {
            get { return Resources.a2; }
        }

        public Image GetLargeImage
        {
            get { return Resources.a2; }
        }
    }
}