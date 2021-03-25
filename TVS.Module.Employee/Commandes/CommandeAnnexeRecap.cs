using System;
using TVS.Config.Modules;
using TVS.Module.Employee.Dal;
using TVS.Module.Employee.Properties;
using TVS.Module.Employee.Services;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Tvs.Module.Employee.DalExport;
using TVS.Module.Employee.Imports.Repsitory;
using TVS.Module.Employee.UiAnnexe;

namespace TVS.Module.Employee.Commandes
{
    [ExportDecEmp(Caption = "Récap", LevelNo = 80)]
    public class CommandeAnnexeRecap : ICommand
    {
        public void Execute(CommandContext context)
        {
            if (!context.User.DecEmp)
            {
                throw new InvalidOperationException("Vous n'avez pas l'autorisation");
            }
            foreach (Form mdiChild in context.MainForm.MdiChildren)
            {
                var frm = mdiChild as FrmRecapDecEmp;
                if (frm == null)
                    continue;
                frm.Close();
                //return;
            }

            var declaredAnnexeView = new IsDeclarationEmployeurView();
            var frmDeclaredAnnexe = new FrmDeclaredAnnexe(declaredAnnexeView);
            var result = frmDeclaredAnnexe.ShowDialog();
            if (result != DialogResult.Yes) return;

            var pathDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            var exportRepo = new FileExportRepository(pathDirectory);
            // annexe 1
            var annexeUnRepository = new AnnexeUnRepository(context.ConnectionProvider);
            var annexeUnImportRepository = new LigneAnnexe1ImportRepository();
            var annexeUnService = new Annexe1Service(annexeUnRepository, exportRepo, context.Societe, context.Exercice,
                annexeUnImportRepository);

            // annexe 2
            var annexeDeuxRepository = new AnnexeDeuxRepository(context.ConnectionProvider);
            var annexeDeuxImportRepository = new LigneAnnexe2ImportRepository();
            var annexeDeuxservice = new Annexe2Service(annexeDeuxRepository, exportRepo, context.Societe,
                context.Exercice,
                annexeDeuxImportRepository);

            // annexe 3
            var annexeTroisRepository = new AnnexeTroisRepository(context.ConnectionProvider);
            var annexeTroisImportRepository = new LigneAnnexe3ImportRepository();
            var annexeTroisService = new Annexe3Service(annexeTroisRepository, exportRepo, context.Societe,
                context.Exercice,
                annexeTroisImportRepository);

            // annexe 4
            var annexeQuatreRepository = new AnnexeQuatreRepository(context.ConnectionProvider);
            var annexeQuatreImportRepository = new LigneAnnexe4ImportRepository();
            var annexeQuatreService = new Annexe4Service(annexeQuatreRepository, exportRepo, context.Societe,
                context.Exercice,
                annexeQuatreImportRepository);

            // annexe 5
            var annexeCinqRepository = new AnnexeCinqRepository(context.ConnectionProvider);
            var annexeCinqImportRepository = new LigneAnnexe5ImportRepository();
            var annexeCinqService = new Annexe5Service(annexeCinqRepository, exportRepo, context.Societe,
                context.Exercice,
                annexeCinqImportRepository);

            // annexe 6
            var annexeSixRepository = new AnnexeSixRepository(context.ConnectionProvider);
            var annexeSixImportRepository = new LigneAnnexe6ImportRepository();
            var annexeSixService = new Annexe6Service(annexeSixRepository, exportRepo, context.Societe,
                context.Exercice,
                annexeSixImportRepository);

            //// annexe 7
            //var annexeSeptRepository = new AnnexeSeptRepository(sqliteConnectionProvider);
            //var annexeSeptImportRepository = new LigneAnnexeSeptImportRepository();
            //var annexeSeptService = new AnnexeSeptService(annexeSeptRepository, exportRepo, context.Societe, context.Exercice,
            //    annexeSeptImportRepository);

            // recap service
            var recapService = new RecapService(
                context.Societe,
                context.Exercice,
                annexeUnService,
                annexeDeuxservice,
                annexeTroisService,
                annexeQuatreService,
                annexeCinqService,
                annexeSixService,
                //  annexeSeptService,
                exportRepo);

            var controller = new RecapDeclarationEmployeurController(recapService);

            var form = new FrmRecapDecEmp(controller, declaredAnnexeView);
            form.MdiParent = context.MainForm;
            form.Text = @"Récap";
            form.Show();
        }

        public Image GetSmallImage
        {
            get { return Resources.rec; }
        }

        public Image GetLargeImage
        {
            get { return Resources.rec; }
        }
    }
}