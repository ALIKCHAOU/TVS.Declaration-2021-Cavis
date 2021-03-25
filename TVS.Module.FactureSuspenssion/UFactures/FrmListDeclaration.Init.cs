using System.Drawing;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using TVS.Core.Enums;

namespace TVS.Module.FactureSuspenssion.UFactures
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
             //   colDate,
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
            // repo identifiant
            var repoIdentifiant = new RepositoryItemTextEdit
            {
                MaxLength = 13
            };
            // repo numerique
            var maskRepo = new RepositoryItemTextEdit();
            maskRepo.Mask.MaskType = MaskType.Numeric;
            maskRepo.Mask.EditMask = "N3";

            // repo type identifiant client
            var repoTypeClient = new RepositoryItemImageComboBox();
            repoTypeClient.Items.Add(new ImageComboBoxItem(@"Mat. Fisc.", TypeClient.MatriculeFiscal, 0));
            repoTypeClient.Items.Add(new ImageComboBoxItem(@"CIN", TypeClient.Cin, 1));
            repoTypeClient.Items.Add(new ImageComboBoxItem(@"Carte séjour", TypeClient.CarteSejour, 2));
            repoTypeClient.Items.Add(new ImageComboBoxItem(@"Non domicliée", TypeClient.NonDomiciliee, 3));
            repoTypeClient.SmallImages = imageTypeClient;
            repoTypeClient.GlyphAlignment = HorzAlignment.Center;
            repoTypeClient.ShowToolTipForTrimmedText = DefaultBoolean.True;

            _colNumeroAutorisation = new GridColumn
            {
                Caption = @"Numéro autorisation",
                FieldName = "NumeroAutorisation",
                Visible = true,
                MinWidth = 80,
            };

            _colNumeroFacture = new GridColumn
            {
                Caption = @"Num. FC",
                FieldName = "NumeroFacture",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 120,
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
                FieldName = "IdentifiantClient",
                Visible = true,
                MinWidth = 100,
                MaxWidth = 100,
                ToolTip = @"Identifiant client",
                ColumnEdit = repoIdentifiant
            };
            _colTypeIdentifiantClient = new GridColumn
            {
                Caption = @"T",
                FieldName = "TypeClient",
                Visible = true,
                MinWidth = 20,
                MaxWidth = 20,
                ToolTip = @"Type identifiant client",
                ColumnEdit = repoTypeClient
            };
            _colRaisonSocialClient = new GridColumn
            {
                Caption = @"Nom/Raison social client",
                FieldName = "NomPrenomClient",
                Visible = true,
                MinWidth = 80,
                ToolTip = @"Nom ou raison social du client"
            };

            _colAdresseClient = new GridColumn
            {
                Caption = @"Adresse client",
                FieldName = "AdresseClient",
                Visible = true,
                MinWidth = 80,
                ToolTip = @"Adresse du client"
            };
            _colDateAutorisation = new GridColumn
            {
                Caption = @"Date autorisation",
                FieldName = "DateAutorisation",
                Visible = true,
                MinWidth = 80,
                ToolTip = @"Date d'autorisation",
            };
            _colPrixVenteHt = new GridColumn
            {
                Caption = @"Prix de vente HT",
                FieldName = "PrixVenteHt",
                Visible = true,
                MinWidth = 80,
                ToolTip = @"Prix de vente HT",
                ColumnEdit = maskRepo
            };
            _colPrixVenteHt.DisplayFormat.FormatString = "n3";
            _colPrixVenteHt.DisplayFormat.FormatType = FormatType.Numeric;

            _colTauxFodec = new GridColumn
            {
                Caption = @"Taux FODEC",
                FieldName = "TauxFodec",
                Visible = true,
                MinWidth = 80,
                ToolTip = @"Taux Fodec",
                ColumnEdit = maskRepo
            };
            _colTauxFodec.DisplayFormat.FormatString = "n3";
            _colTauxFodec.DisplayFormat.FormatType = FormatType.Numeric;

            _colMontantFodec = new GridColumn
            {
                Caption = @"Montant FODEC",
                FieldName = "MontantFodec",
                Visible = true,
                MinWidth = 80,
                ToolTip = @"Montant fodec",
                ColumnEdit = maskRepo
            };
            _colMontantFodec.DisplayFormat.FormatString = "n3";
            _colMontantFodec.DisplayFormat.FormatType = FormatType.Numeric;

            _colTauxDroitConsommation = new GridColumn
            {
                Caption = @"Taux droit consommmation",
                FieldName = "TauxDroitConsommation",
                Visible = true,
                MinWidth = 80,
                ToolTip = @"Taux droit consommation",
                ColumnEdit = maskRepo
            };
            _colTauxDroitConsommation.DisplayFormat.FormatString = "n3";
            _colTauxDroitConsommation.DisplayFormat.FormatType = FormatType.Numeric;

            _colMontantDroitConsommation = new GridColumn
            {
                Caption = @"Mt droit consommmation",
                FieldName = "MontantDroitConsommation",
                Visible = true,
                MinWidth = 80,
                ToolTip = @"Montant droit consommmation",
                ColumnEdit = maskRepo
            };
            _colMontantDroitConsommation.DisplayFormat.FormatString = "n3";
            _colMontantDroitConsommation.DisplayFormat.FormatType = FormatType.Numeric;

            _colTauxTva = new GridColumn
            {
                Caption = @"Taux TVA",
                FieldName = "TauxTva",
                Visible = true,
                MinWidth = 80,
                ToolTip = @"Taux TVA",
                ColumnEdit = maskRepo
            };
            _colTauxTva.DisplayFormat.FormatString = "n3";
            _colTauxTva.DisplayFormat.FormatType = FormatType.Numeric;

            _colMontantTva = new GridColumn
            {
                Caption = @"Montant TVA",
                FieldName = "MontantTva",
                Visible = true,
                MinWidth = 80,
                ToolTip = @"Montant TVA",
                ColumnEdit = maskRepo
            };
            _colMontantTva.DisplayFormat.FormatString = "n3";
            _colMontantTva.DisplayFormat.FormatType = FormatType.Numeric;

            _colNumeroOrdre = new GridColumn
            {
                Caption = @"N° d'ordre",
                FieldName = "NumeroOrdre",
                Visible = true,
                MinWidth = 70,
                ToolTip = @"Numéro d'ordre"
            };
            viewLigne.Columns.AddRange(new[]
            {
                _colNumeroOrdre,
                _colNumeroFacture,
                _colDateFacture,
                _colTypeIdentifiantClient,
                _colIdentifiant,
                _colRaisonSocialClient,
                _colAdresseClient,
                _colNumeroAutorisation,
                _colDateAutorisation,
                _colPrixVenteHt,
                _colTauxFodec,
                _colMontantFodec,
                _colTauxDroitConsommation,
                _colMontantDroitConsommation,
                _colTauxTva,
                _colMontantTva
            });

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
            _colPrixVenteHt.Summary.Add(SummaryItemType.Sum, "PrixVenteHt", "{0:0.000}");
            _colMontantFodec.Summary.Add(SummaryItemType.Sum, "MontantFodec", "{0:0.000}");
            _colMontantDroitConsommation.Summary.Add(SummaryItemType.Sum, "MontantDroitConsommation", "{0:0.000}");

            viewLigne.OptionsView.ShowFooter = true;
            viewLigne.FooterPanelHeight = 35;

            viewLigne.ValidateRow += Valider;
            viewLigne.InvalidRowException += Invalide;
        }
    }
}