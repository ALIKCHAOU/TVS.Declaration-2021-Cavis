using System;
using System.Drawing;
using System.Linq;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using TVS.Core.Enums;
using TVS.Module.FactureSuspenssion.Imports.Controller;
using TVS.Module.FactureSuspenssion.Imports.Views;
using ErrorInfo = DevExpress.XtraEditors.DXErrorProvider.ErrorInfo;

namespace TVS.Module.FactureSuspenssion.Imports
{
    public partial class UcLignesImport : XtraUserControl
    {
        private readonly ImportController _controller;

        private UcLignesImport()
        {
            InitializeComponent();
            btAnnuler.Click += AnnulerClick;
        }

        public UcLignesImport(ImportController controller)
            : this()
        {
            if (controller == null) throw new ArgumentNullException("controller");
            _controller = controller;
            InitGridLigneDeclaration();
            //btExporter.Click += ExportToCsv;
        }

        public DeclarationImportView Declaration { get; private set; }

        public void SetDeclaration(DeclarationImportView view)
        {
            if (view == null) throw new ArgumentNullException("view");
            Declaration = view;
        }

        private void InitGridLigneDeclaration()
        {
            var repoCivilite = new RepositoryItemImageComboBox();
            repoCivilite.Items.AddEnum(typeof(Civilite));

            var repoSituationFamille = new RepositoryItemImageComboBox();
            repoSituationFamille.Items.AddEnum(typeof(SituationFamille));

            #region grid columns

            var maskRepo = new RepositoryItemTextEdit();
            maskRepo.Mask.MaskType = MaskType.Numeric;
            maskRepo.Mask.EditMask = "N3";

            var repoTypeClient = new RepositoryItemImageComboBox();
            repoTypeClient.Items.Add(new ImageComboBoxItem(@"Mat. Fisc.", TypeClient.MatriculeFiscal, 0));
            repoTypeClient.Items.Add(new ImageComboBoxItem(@"CIN", TypeClient.Cin, 1));
            repoTypeClient.Items.Add(new ImageComboBoxItem(@"Carte séjour", TypeClient.CarteSejour, 2));
            repoTypeClient.Items.Add(new ImageComboBoxItem(@"Non domicliée", TypeClient.NonDomiciliee, 3));
            repoTypeClient.SmallImages = imageCollection1;

            repoTypeClient.GlyphAlignment = HorzAlignment.Far;
            repoTypeClient.ShowToolTipForTrimmedText = DefaultBoolean.True;

            var colNumeroAutorisation = new GridColumn
            {
                Caption = @"Numéro autorisation",
                FieldName = "NumeroAutorisation",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 120,
            };

            var colNumeroFacture = new GridColumn
            {
                Caption = @"Num. FC",
                FieldName = "NumeroFacture",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 160,
                ToolTip = @"Numéro facture"
            };
            var colDateFacture = new GridColumn
            {
                Caption = @"Date FC",
                FieldName = "DateFacture",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Date facture",
            };
            var colIdentifiant = new GridColumn
            {
                Caption = @"Identifiant",
                FieldName = "IdentifiantClient",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 180,
                ToolTip = @"Identifiant client"
            };
            var colTypeIdentifiantClient = new GridColumn
            {
                Caption = @"Type",
                FieldName = "TypeClient",
                Visible = true,
                MinWidth = 30,
                MaxWidth = 30,
                ToolTip = @"Type client",
                ColumnEdit = repoTypeClient
            };
            var colRaisonSocialClient = new GridColumn
            {
                Caption = @"Nom/Raison social client",
                FieldName = "AdresseClient",
                Visible = true,
                MinWidth = 80,
                ToolTip = @"Nom ou raison social du client"
            };
            var colDateAutorisation = new GridColumn
            {
                Caption = @"Date autorisation",
                FieldName = "DateAutorisation",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 120,
                ToolTip = @"Date d'autorisation",
            };
            var colPrixVenteHtStr = new GridColumn
            {
                Caption = @"Prix de vente HT",
                FieldName = "PrixVenteHtStr",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 180,
                ToolTip = @"Prix de vente HT",
                ColumnEdit = maskRepo
            };
            var colMontantTvaStr = new GridColumn
            {
                Caption = @"Monatnt TVA",
                FieldName = "MontantTvaStr",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Montant Tva",
                ColumnEdit = maskRepo
            };
            var colTauxFodecStr = new GridColumn
            {
                Caption = @"Taux fodec",
                FieldName = "TauxFodecStr",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"TauxFodec",
                ColumnEdit = maskRepo
            };
            var colMontantFodecStr = new GridColumn
            {
                Caption = @"Montant fodec",
                FieldName = "MontantFodecStr",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Montant fodec",
                ColumnEdit = maskRepo
            };
            var colTauxDroitConsommationStr = new GridColumn
            {
                Caption = @"Taux droit consommmation",
                FieldName = "TauxDroitConsommationStr",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 180,
                ToolTip = @"Taux droit consommation",
                ColumnEdit = maskRepo
            };
            var colMontantDroitConsommationStr = new GridColumn
            {
                Caption = @"Mt droit consommmation",
                FieldName = "MontantDroitConsommationStr",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 180,
                ToolTip = @"Montant droit consommmation",
                ColumnEdit = maskRepo
            };
            var colTauxTvaStr = new GridColumn
            {
                Caption = @"Taux tva",
                FieldName = "TauxTvaStr",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Taux TVA",
                ColumnEdit = maskRepo,
            };

            viewLigne.Columns.AddRange(new[]
            {
                colDateFacture,
                colNumeroFacture,
                colNumeroAutorisation,
                colDateAutorisation,
                colTypeIdentifiantClient,
                colIdentifiant,
                colRaisonSocialClient,
                colPrixVenteHtStr,
                colTauxTvaStr,
                colMontantTvaStr,
                colTauxFodecStr,
                colMontantFodecStr,
                colTauxDroitConsommationStr,
                colMontantDroitConsommationStr
            });

            #endregion grid columns

            #region grid options

            viewLigne.OptionsView.ShowAutoFilterRow = true;
            viewLigne.OptionsCustomization.AllowColumnMoving = false;
            viewLigne.OptionsCustomization.AllowColumnResizing = false;
            viewLigne.OptionsCustomization.AllowFilter = false;
            // viewLigne.OptionsCustomization.AllowGroup = false;
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
            viewLigne.InvalidRowException += ViewInvalidRowException;
            viewLigne.ValidateRow += gridLignes_ValidateRow;
            colPrixVenteHtStr.Summary.Add(SummaryItemType.Sum, "PrixVenteHt", "{0:0.000}");
            colMontantTvaStr.Summary.Add(SummaryItemType.Sum, "MontantTva", "{0:0.000}");
            colMontantFodecStr.Summary.Add(SummaryItemType.Sum, "MontantFodec", "{0:0.000}");
            colMontantDroitConsommationStr.Summary.Add(SummaryItemType.Sum, "TauxDroitConsommation", "{0:0.000}");
            viewLigne.OptionsView.ShowFooter = true;
            viewLigne.FooterPanelHeight = 35;
            //viewLigne.FocusedRowChanged += RowViewReglementFocusedChanged;

            #endregion grid options
        }

        private void gridLignes_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            //var info = new ErrorInfo();
            //var ligneView = e.Row as LigneView;
            //if (ligneView != null) ligneView.GetError(info);
            //e.Valid = info.ErrorText == "";
            //e.Valid = !viewLigne.HasColumnErrors;
            //var view = sender as GridView;
            //var info = new ErrorInfo();
            //for (int i = 0; i < view.VisibleColumns.Count; i++)
            //{
            //    (e.Row as IDXDataErrorInfo).GetPropertyError(view.VisibleColumns[i].FieldName, info);
            //    if (info.ErrorType == ErrorType.Default)
            //    {
            //        e.Valid = false;
            //        break;
            //    }
            //}
        }

        private void ViewInvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        public void Init()
        {
            gridLigne.DataSource = Declaration.Lignes;
        }

        public bool IsValider()
        {
            var info = new ErrorInfo();
            for (int i = 0; i < viewLigne.VisibleColumns.Count; i++)
            {
                foreach (var e in Declaration.Lignes)
                {
                    (e as IDXDataErrorInfo).GetPropertyError(viewLigne.VisibleColumns[i].FieldName, info);
                    if (info.ErrorType == ErrorType.Critical)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void ValidIndexChanged(object sender, EventArgs e)
        {
            var combobox = sender as ComboBoxEdit;
            if (combobox == null) return;
            if (combobox.SelectedIndex == 0)
            {
                gridLigne.DataSource = Declaration.Lignes;
                return;
            }
            gridLigne.DataSource = Declaration.Lignes.Where(x => x.IsValide() == (combobox.SelectedIndex == 1));
        }

        public void AnnulerClick(object sender, EventArgs e)
        {
            ParentForm.Close();
        }
    }
}