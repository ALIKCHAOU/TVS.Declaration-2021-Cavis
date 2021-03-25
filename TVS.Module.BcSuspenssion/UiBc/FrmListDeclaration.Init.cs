using System.Drawing;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace TVS.Module.BcSuspenssion.UiBc
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

            var colTrimestre = new GridColumn
            {
                Caption = @"Trimestre",
                FieldName = "Trimestre",
                Visible = true,
                MinWidth = 60,
                MaxWidth = 60,
                ToolTip = @"Trimestre",
            };

            var colDate = new GridColumn
            {
                Caption = @"Date",
                FieldName = "Date",
                Visible = true,
                ToolTip = @"Date",
            };
            var colCloture = new GridColumn
            {
                Caption = @"Valider",
                FieldName = "IsCloture",
                Visible = true,
                MinWidth = 50,
                MaxWidth = 50,
                ToolTip = @"Valider",
                ColumnEdit = repoImageCloturer
            };
            var colArchiver = new GridColumn
            {
                Caption = @"Archiver",
                FieldName = "IsArchive",
                Visible = true,
                MinWidth = 50,
                MaxWidth = 50,
                ToolTip = @"Archiver",
                ColumnEdit = repoImageArchiver
            };
            viewDeclaration.Columns.AddRange(new[]
            {
                colTrimestre,
           //     colDate,
                colCloture,
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

        private void InitLigne()
        {
            var repoIdentifiant = new RepositoryItemTextEdit
            {
                MaxLength = 13
            };

            var maskRepo = new RepositoryItemTextEdit();
            maskRepo.Mask.MaskType = MaskType.Numeric;
            maskRepo.Mask.EditMask = "N3";

            _colNumeroAutorisation = new GridColumn
            {
                Caption = @"Numéro autorisation",
                FieldName = "NumeroAutorisation",
                Visible = true,
                MinWidth = 80
            };
            _colNumeroBonCommande = new GridColumn
            {
                Caption = @"Num. BC",
                FieldName = "NumeroBonCommande",
                Visible = true,
                MinWidth = 100,
                ToolTip = @"Numéro bon de commande"
            };
            _colDateBonCommande = new GridColumn
            {
                Caption = @"Date BC",
                FieldName = "DateBonCommande",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Date bon de commande"
            };
            _colNumeroFacture = new GridColumn
            {
                Caption = @"Num. FC",
                FieldName = "NumeroFacture",
                Visible = true,
                MinWidth = 80,
                ToolTip = @"Numéro facture"
            };
            _colDateFacture = new GridColumn
            {
                Caption = @"Date FC",
                FieldName = "DateFacture",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Date facture",
            };
            _colIdentifiant = new GridColumn
            {
                Caption = @"Identifiant",
                FieldName = "Identifiant",
                Visible = true,
                MinWidth = 80,
                ToolTip = @"Identifiant",
                ColumnEdit = repoIdentifiant
            };
            _colRaisonSocialFournisseur = new GridColumn
            {
                Caption = @"Nom/Raison social frs.",
                FieldName = "RaisonSocialFournisseur",
                Visible = true,
                MinWidth = 80,
                ToolTip = @"Nom au raison social du fournisseur"
            };
            _colPrixAchatHorsTaxe = new GridColumn
            {
                Caption = @"Prix achat HT",
                FieldName = "PrixAchatHorsTaxe",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Prix d'achat HT",
                ColumnEdit = maskRepo,
            };
            _colPrixAchatHorsTaxe.DisplayFormat.FormatString = "n3";
            _colPrixAchatHorsTaxe.DisplayFormat.FormatType = FormatType.Numeric;

            _colMontantTva = new GridColumn
            {
                Caption = @"Montant TVA",
                FieldName = "MontantTva",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Montant TVA",
                ColumnEdit = maskRepo
            };
            _colMontantTva.DisplayFormat.FormatString = "n3";
            _colMontantTva.DisplayFormat.FormatType = FormatType.Numeric;

            _colObjetFacture = new GridColumn
            {
                Caption = @"Objet facture",
                FieldName = "ObjetFacture",
                Visible = true,
                ToolTip = @"Objet facture",
            };
            _colNumeroOrdre = new GridColumn
            {
                Caption = @"N° d'ordre",
                FieldName = "NumeroOrdre",
                Visible = true,
                MinWidth = 70,
                MaxWidth = 70,
                ToolTip = @"Numéro d'ordre",
            };
            viewLigne.Columns.AddRange(new[]
            {
                _colNumeroOrdre,
                _colNumeroBonCommande,
                _colNumeroAutorisation,
       
                _colDateBonCommande,
                _colIdentifiant,
                _colRaisonSocialFournisseur,
                _colNumeroFacture,
                _colDateFacture,
                _colPrixAchatHorsTaxe,
                _colMontantTva,
                _colObjetFacture
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
            _colMontantTva.Summary.Add(SummaryItemType.Sum, "MontantTva", "{0:0.000}");
            _colPrixAchatHorsTaxe.Summary.Add(SummaryItemType.Sum, "PrixAchatHorsTaxe", "{0:0.000}");
            viewLigne.OptionsView.ShowFooter = true;
            viewLigne.FooterPanelHeight = 35;

            viewLigne.ValidateRow += Valider;
            viewLigne.InvalidRowException += Invalide;
        }
    }
}