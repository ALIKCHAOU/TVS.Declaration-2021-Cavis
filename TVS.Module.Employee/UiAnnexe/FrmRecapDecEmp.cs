using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using TVS.Module.Employee.Properties;

namespace TVS.Module.Employee.UiAnnexe
{
    public partial class FrmRecapDecEmp : RibbonForm
    {
        private readonly RecapDeclarationEmployeurController _controller;
        private readonly IsDeclarationEmployeurView _declaredAnnexeView;

        private FrmRecapDecEmp()
        {
            InitializeComponent();
            btnGenerer.ItemClick += GenererFichier;
            btnExporterExcel.ItemClick += ExportToExcel;
        }

        public FrmRecapDecEmp(
            RecapDeclarationEmployeurController controller,
            IsDeclarationEmployeurView declaredAnnexeView)
            : this()
        {
            if (controller == null)
                throw new ArgumentNullException("controller");
            if (declaredAnnexeView == null)
                throw new ArgumentNullException("declaredAnnexeView");

            _controller = controller;
            _declaredAnnexeView = declaredAnnexeView;
            InitGridRecap();
            InitGridVerification();

            var annexeRecap = _controller.GetRecapAnnexe(declaredAnnexeView);
            if (annexeRecap == null)
                throw new ArgumentNullException("annexeRecap");
            gcRecap.DataSource = annexeRecap.Lignes;
            gcVerification.DataSource = annexeRecap.Verification;
        }

        private void GenererFichier(object sender, EventArgs e)
        {
            _controller.Exporter(_declaredAnnexeView);
        }

        #region Initialisation grid

        private void ExportToExcel(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Title = "Enregistrer",
                DefaultExt = "xlsx",
                Filter = "Excel document (*.xlsx)|*.xlsx"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            if (string.IsNullOrEmpty(sfd.FileName)) return;
            // les options d'exportation Excel
            var option = new XlsxExportOptions
            {
                RawDataMode = true,
                TextExportMode = TextExportMode.Value,
                ShowGridLines = true,
                ExportMode = XlsxExportMode.SingleFile,
                ExportHyperlinks = false,
            };

            // export grid view to Excel
            gcRecap.ExportToXlsx(sfd.FileName, option);
            OpenExportedFile(sfd.FileName);
        }

        private static void OpenExportedFile(string path)
        {
            if (string.IsNullOrEmpty(path)) return;
            if (!File.Exists(path)) return;
            var msgOpenExportedFileConfirmation = "Voulez-vous ouvrir le fichier exporté?";
            var result = XtraMessageBox.Show(msgOpenExportedFileConfirmation, "Export", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = path,
                    WindowStyle = ProcessWindowStyle.Normal,
                }
            };
            process.Start();
        }

        private void InitGridRecap()
        {
            var colName = new GridColumn
            {
                Caption = "N° enregistrement",
                FieldName = "Name",
                Visible = true,
                MinWidth = 100,
                MaxWidth = 100
            };

            var colType = new GridColumn
            {
                Caption = "Type",
                FieldName = "TypeEnregistrement",
                Visible = true,
                MinWidth = 50,
                MaxWidth = 50
            };

            var colTotalAssiette = new GridColumn
            {
                Caption = "Total assiette",
                FieldName = "TotalAssiette",
                Visible = true,
                MinWidth = 150,
                MaxWidth = 150,
            };
            var colTaux = new GridColumn
            {
                Caption = "Taux",
                FieldName = "Taux",
                Visible = true,
                MinWidth = 50,
                MaxWidth = 50
            };
            var colTotalRetenue = new GridColumn
            {
                Caption = "Total Retenues",
                FieldName = "TotalRetenue",
                Visible = true,
                MinWidth = 150,
                MaxWidth = 150
            };

            gvRecap.Columns.AddRange(new[]
            {
                colName,
                colType,
                colTotalAssiette,
                colTaux,
                colTotalRetenue,
                new GridColumn()
            });

            gvRecap.BestFitColumns();
            gvRecap.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvRecap.OptionsSelection.EnableAppearanceFocusedRow = true;
            gvRecap.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            gvRecap.Appearance.FocusedRow.BackColor = Color.FromArgb(255, 255, 192);
            gvRecap.Appearance.SelectedRow.BackColor = Color.FromArgb(255, 255, 192);
            gvRecap.Appearance.OddRow.BackColor = Color.FromArgb(231, 244, 247);
            gvRecap.OptionsView.EnableAppearanceOddRow = true;
            gvRecap.Appearance.SelectedRow.Options.UseBackColor = true;
            gvRecap.OptionsBehavior.Editable = true;
            gvRecap.OptionsDetail.EnableMasterViewMode = false;
            gvRecap.OptionsBehavior.Editable = false;
            gvRecap.OptionsView.ShowGroupPanel = false;
            gvRecap.OptionsMenu.EnableColumnMenu = false;
            gvRecap.OptionsCustomization.AllowColumnMoving = false;
            gvRecap.OptionsCustomization.AllowSort = false;
            gvRecap.OptionsCustomization.AllowFilter = false;
        }


        private void InitGridVerification()
        {
            var repoVerify = new RepositoryItemImageComboBox();
            repoVerify.Items.Add(new ImageComboBoxItem("Ok", true, 0));
            repoVerify.Items.Add(new ImageComboBoxItem("", false, 1));
            repoVerify.SmallImages = new ImageCollection(false)
            {
                Images =
                {
                    Resources.apply_16x16,
                    Resources.close_16x16
                }
            };
            repoVerify.GlyphAlignment = HorzAlignment.Far;
            repoVerify.ShowToolTipForTrimmedText = DefaultBoolean.True;

            var repoDepose = new RepositoryItemImageComboBox();
            repoDepose.Items.Add(new ImageComboBoxItem("Annexe déposé", true, 0));
            repoDepose.Items.Add(new ImageComboBoxItem("Annexe non déposé", false, 1));
            repoDepose.SmallImages = new ImageCollection(false)
            {
                Images =
                {
                    Resources.addchartpane_16x16,
                    Resources.deletelist_16x16
                }
            };
            repoDepose.GlyphAlignment = HorzAlignment.Far;
            repoDepose.ShowToolTipForTrimmedText = DefaultBoolean.True;

            var colIsDepose = new GridColumn
            {
                Caption = "D",
                FieldName = "IsDepose",
                Visible = true,
                MinWidth = 20,
                MaxWidth = 20,
                ColumnEdit = repoDepose,
                ToolTip = "Déposé"
            };

            var colIsVerify = new GridColumn
            {
                Caption = "",
                FieldName = "IsVerify",
                Visible = true,
                MinWidth = 20,
                MaxWidth = 20,
                ColumnEdit = repoVerify
            };
            colIsVerify.OptionsColumn.ShowCaption = false;

            var colAnnexe = new GridColumn
            {
                Caption = "Annexe",
                FieldName = "Annexe",
                Visible = true
            };
            colAnnexe.OptionsColumn.ShowCaption = false;

            var colSumAnnexe = new GridColumn
            {
                Caption = "Annexes",
                FieldName = "SumAnnexe",
                Visible = true
            };

            var colSumRecap = new GridColumn
            {
                Caption = "Récap",
                FieldName = "SumAnnexeRecap",
                Visible = true
            };

            var colEcart = new GridColumn
            {
                Caption = "Écart",
                FieldName = "Ecart",
                Visible = true
            };

            gvVerification.Columns.AddRange(new[]
            {
                colAnnexe,
                colIsDepose,
                colSumAnnexe,
                colSumRecap,
                colEcart,
                colIsVerify
            });

            gvVerification.BestFitColumns();
            gvVerification.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvVerification.OptionsSelection.EnableAppearanceFocusedRow = true;
            gvVerification.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            gvVerification.Appearance.FocusedRow.BackColor = Color.FromArgb(255, 255, 192);
            gvVerification.Appearance.SelectedRow.BackColor = Color.FromArgb(255, 255, 192);
            gvVerification.Appearance.OddRow.BackColor = Color.FromArgb(231, 244, 247);
            gvVerification.OptionsView.EnableAppearanceOddRow = true;
            gvVerification.Appearance.SelectedRow.Options.UseBackColor = true;
            gvVerification.OptionsBehavior.Editable = true;
            gvVerification.OptionsDetail.EnableMasterViewMode = false;
            gvVerification.OptionsBehavior.Editable = false;
            gvVerification.OptionsView.ShowGroupPanel = false;
            gvVerification.OptionsMenu.EnableColumnMenu = false;
            gvVerification.OptionsCustomization.AllowColumnMoving = false;
            gvVerification.OptionsCustomization.AllowSort = false;
            gvVerification.OptionsCustomization.AllowFilter = false;
            gvVerification.OptionsView.ShowIndicator = false;
        }

        #endregion Initialisation grid
    }
}