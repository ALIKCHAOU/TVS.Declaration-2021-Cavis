using System.Drawing;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace TVS.Module.Virement.UiVirement
{
    public partial class FrmListDeclaration
    {
        private void InitGridDeclaration()
        {
            // repository image imprimer
            var repoImageImprimer = new RepositoryItemImageComboBox();
            repoImageImprimer.Items.Add(new ImageComboBoxItem("", true, 0));
            repoImageImprimer.SmallImages = icImprimer;
            repoImageImprimer.GlyphAlignment = HorzAlignment.Far;
            repoImageImprimer.ShowToolTipForTrimmedText = DefaultBoolean.True;

            // repository image Exporter
            var repoImageExporter = new RepositoryItemImageComboBox();
            repoImageExporter.Items.Add(new ImageComboBoxItem("", true, 0));
            repoImageExporter.SmallImages = icExporter;
            repoImageExporter.GlyphAlignment = HorzAlignment.Far;
            repoImageExporter.ShowToolTipForTrimmedText = DefaultBoolean.True;

            // repository image valider
            var repoImageCloturer = new RepositoryItemImageComboBox();
            repoImageCloturer.Items.Add(new ImageComboBoxItem("", true, 0));
            repoImageCloturer.SmallImages = icCloturer;
            repoImageCloturer.GlyphAlignment = HorzAlignment.Far;
            repoImageCloturer.ShowToolTipForTrimmedText = DefaultBoolean.True;

            // repository image imprimer
            var repoImageArchiver = new RepositoryItemImageComboBox();
            repoImageArchiver.Items.Add(new ImageComboBoxItem("", true, 0));
            repoImageArchiver.SmallImages = icArchiver;
            repoImageArchiver.GlyphAlignment = HorzAlignment.Far;
            repoImageArchiver.ShowToolTipForTrimmedText = DefaultBoolean.True;

            // repository image Exporter
            var repoImageComplementaire = new RepositoryItemImageComboBox();
            repoImageComplementaire.Items.Add(new ImageComboBoxItem("", true, 0));
            repoImageComplementaire.SmallImages = icComplementaire;
            repoImageComplementaire.GlyphAlignment = HorzAlignment.Far;
            repoImageComplementaire.ShowToolTipForTrimmedText = DefaultBoolean.True;


            var colCreation = new GridColumn
            {
                Caption = @"Date",
                FieldName = "DateCreation",
                Visible = true,
                ToolTip = @"Echéance",
            };
            var colEcheance = new GridColumn
            {
                Caption = @"Echéance",
                FieldName = "DateEcheance",
                Visible = true,
                ToolTip = @"Echéance",
            };
            var colBanque = new GridColumn
            {
                Caption = @"Banque",
                FieldName = "Banque",
                Visible = true,
                MinWidth = 50,
                MaxWidth = 50,
                ToolTip = @"Banque"
            };
            var colArchiver = new GridColumn
            {
                Caption = @"Archiver",
                FieldName = "Archiver",
                Visible = true,
                MinWidth = 50,
                MaxWidth = 50,
                ToolTip = @"Archiver",
                ColumnEdit = repoImageArchiver
            };
            viewDeclaration.Columns.AddRange(new[]
            {
                colCreation,
                colEcheance,
                colBanque,
                colArchiver
            });

            viewDeclaration.OptionsDetail.ShowDetailTabs = true;
            viewDeclaration.OptionsCustomization.AllowColumnMoving = false;
            viewDeclaration.OptionsCustomization.AllowColumnResizing = true;
            viewDeclaration.OptionsCustomization.AllowFilter = false;
            viewDeclaration.OptionsCustomization.AllowGroup = false;
            viewDeclaration.OptionsCustomization.AllowQuickHideColumns = false;
            viewDeclaration.OptionsCustomization.AllowSort = false;
            viewDeclaration.OptionsMenu.EnableColumnMenu = false;
            viewDeclaration.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            viewDeclaration.OptionsView.ShowGroupPanel = false;
            viewDeclaration.OptionsView.ShowIndicator = true;
            viewDeclaration.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            viewDeclaration.OptionsSelection.EnableAppearanceFocusedCell = false;
            viewDeclaration.OptionsSelection.EnableAppearanceFocusedRow = true;
            viewDeclaration.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            viewDeclaration.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            viewDeclaration.OptionsBehavior.Editable = false;
            viewDeclaration.FocusedRowObjectChanged += FocusedRowChanged;

            viewDeclaration.BestFitColumns();
            viewDeclaration.OptionsDetail.ShowDetailTabs = false;
        }

        private GridColumn _colMatricule;

        private GridColumn _colNom;

        private GridColumn _colPrenom;
        private GridColumn _colNomBanque;

        private GridColumn _colCodeBanque;
        private GridColumn _colCodeGuichet;

        private GridColumn _colNumeroCompte;
        private GridColumn _colCleRib;

        private GridColumn _colNetAPaye;
        private GridColumn _colMotif;
        private void InitLigne()
        {
            var maskRepo = new RepositoryItemTextEdit();
            maskRepo.Mask.MaskType = MaskType.Numeric;
            maskRepo.Mask.EditMask = "N3";

            _colMatricule = new GridColumn
            {
                Caption = @"Matricule",
                FieldName = "Matricule",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 150,
            };
            _colNom = new GridColumn
            {
                Caption = @"Nom",
                FieldName = "Nom",
                Visible = true,

                ToolTip = @"Nom"
            };
            _colPrenom = new GridColumn
            {
                Caption = @"Prenom",
                FieldName = "Prenom",
                Visible = true,
                ToolTip = @"Prenom"
            };
             _colNomBanque = new GridColumn
            {
                Caption = @"Nom banque",
                FieldName = "NomBanque",
                Visible = true,
                MinWidth = 60,
                MaxWidth = 60,
            };
             _colCodeBanque = new GridColumn
            {
                Caption = @"Code banque",
                FieldName = "CodeBanque",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 120,
            };
             _colCodeGuichet = new GridColumn
            {Caption = @"Code guichet",
                FieldName = "CodeGuichet",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
            };
             _colNumeroCompte = new GridColumn
            {
                Caption = @"Numéro compte",
                FieldName = "NumeroCompte",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 180,

            };
             _colCleRib = new GridColumn
            {
                Caption = @"Clé",
                FieldName = "CleRib",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,

            };
             _colNetAPaye = new GridColumn
            {
                Caption = @"Net à payé",
                FieldName = "NetAPaye",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 100,
                ColumnEdit = maskRepo
            };
             _colMotif = new GridColumn
            {
                Caption = @"Motif",
                FieldName = "Motif",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 300,
                ToolTip = @"Motif"
            };


            viewLigne.Columns.AddRange(new[]
            {
                _colMatricule,
                _colNom,
                _colPrenom,
                _colNomBanque,
                _colCodeBanque,
                _colCodeGuichet,
                _colNumeroCompte,
                _colCleRib,
                _colNetAPaye,
                _colMotif,
            });

            viewLigne.BestFitColumns();
            viewLigne.OptionsCustomization.AllowFilter = false;
            viewLigne.OptionsCustomization.AllowGroup = false;
            viewLigne.OptionsCustomization.AllowQuickHideColumns = false;
            viewLigne.OptionsCustomization.AllowSort = false;
            viewLigne.OptionsMenu.EnableColumnMenu = false;
            viewLigne.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            viewLigne.OptionsSelection.EnableAppearanceFocusedCell = true;
            viewLigne.OptionsDetail.EnableMasterViewMode = false;
            viewLigne.Appearance.FocusedRow.BackColor = Color.FromArgb(255, 255, 192);
            viewLigne.Appearance.SelectedRow.BackColor = Color.FromArgb(255, 255, 192);
            viewLigne.Appearance.FocusedCell.BackColor = Color.White;
            viewLigne.Appearance.FocusedCell.Options.UseBackColor = true;
            viewLigne.Appearance.OddRow.BackColor = Color.FromArgb(231, 244, 247);
            viewLigne.OptionsView.EnableAppearanceOddRow = true;
            viewLigne.Appearance.SelectedRow.Options.UseBackColor = true;
            viewLigne.OptionsView.ShowGroupPanel = false;
            _colNetAPaye.Summary.Add(SummaryItemType.Sum, "NetAPaye", "{0:0.000}");
            viewLigne.OptionsView.ShowFooter = true;
            viewLigne.FooterPanelHeight = 35;

            viewLigne.ValidateRow += Valider;
            viewLigne.InvalidRowException += Invalide;
        }
    }
}