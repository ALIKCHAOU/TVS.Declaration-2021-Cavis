using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TVS.Module.Employee.Models.Recap;
using TVS.Module.Employee.Services;

namespace TVS.Module.Employee.UiAnnexe
{
    public class RecapDeclarationEmployeurController
    {
        private readonly IRecapService _recapService;

        public RecapDeclarationEmployeurController(IRecapService recapService)
        {
            if (recapService == null)
                throw new ArgumentNullException(nameof(recapService));

            _recapService = recapService;
        }

        public IsDeclarationEmployeurView InitDeclaredAnnexes()
        {
            return new IsDeclarationEmployeurView();
        }

        public AnnexeRecap GetRecapAnnexe(IsDeclarationEmployeurView view)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            //if ()   



            return _recapService.GetAnnexeRecap(
                view.IsAnnexeUnDeclared,
                view.IsAnnexeDeuxDeclared,
                view.IsAnnexeTroisDeclared,
                view.IsAnnexeQuatreDeclared,
                view.IsAnnexeCinqDeclared,
                view.IsAnnexeSixDeclared,
                view.IsAnnexeSeptDeclared);
        }

        public void Exporter(IsDeclarationEmployeurView view)
        {
            if (view == null) throw new ArgumentNullException(nameof(view));


            var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;
            if (dialog.SelectedPath == string.Empty) return;
            _recapService.Exporter(view.IsAnnexeUnDeclared,
                view.IsAnnexeDeuxDeclared,
                view.IsAnnexeTroisDeclared,
                view.IsAnnexeQuatreDeclared,
                view.IsAnnexeCinqDeclared,
                view.IsAnnexeSixDeclared,
                view.IsAnnexeSeptDeclared,
                dialog.SelectedPath);
            XtraMessageBox.Show("Exportation avec succès", "Déclaration", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}