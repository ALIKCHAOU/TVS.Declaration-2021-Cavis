using System;
using System.Drawing;
using System.Linq;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using TVS.Core.Enums;
using TVS.Module.BcSuspenssion.Imports.Controller;
using TVS.Module.BcSuspenssion.Imports.Views;

namespace TVS.Module.BcSuspenssion.Imports
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

            var colNumeroAutorisation = new GridColumn
            {
                Caption = @"Numéro autorisation",
                FieldName = "NumeroAutorisation",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
            };
            var colNumeroBonCommande = new GridColumn
            {
                Caption = @"Num. BC",
                FieldName = "NumeroBonCommande",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Numéro bon de commande"
            };
            var colDateBonCommande = new GridColumn
            {
                Caption = @"Date BC",
                FieldName = "DateBonCommande",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Date bon de commande"
            };
            var colNumeroFacture = new GridColumn
            {
                Caption = @"Num. FC",
                FieldName = "NumeroFacture",
                Visible = true,
                MinWidth = 60,
                MaxWidth = 60,
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
                FieldName = "Identifiant",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Identifiant"
            };
            var colRaisonSocialFournisseur = new GridColumn
            {
                Caption = @"Nom/Raison social frs.",
                FieldName = "RaisonSocialFournisseur",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 280,
                ToolTip = @"Nom au raison social du fournisseur"
            };
            var colPrixAchatHorsTaxeStr = new GridColumn
            {
                Caption = @"Prix achat HT",
                FieldName = "PrixAchatHorsTaxeStr",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Prix d'achat HT",
                ColumnEdit = maskRepo
            };
            var colMontantTvaStr = new GridColumn
            {
                Caption = @"Montant TVA",
                FieldName = "MontantTvaStr",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Montant TVA",
                ColumnEdit = maskRepo
            };

            var colObjetFacture = new GridColumn
            {
                Caption = @"Objet FC",
                FieldName = "ObjetFacture",
                Visible = true,
                //MinWidth = 100,
                //MaxWidth = 200,
                ToolTip = @"Objet facture",
            };

            viewLigne.Columns.AddRange(new[]
            {
        
                colNumeroBonCommande,
                colDateBonCommande,
                colDateFacture,
                colNumeroFacture,
                colNumeroAutorisation,
                colIdentifiant,
                colRaisonSocialFournisseur,
                colPrixAchatHorsTaxeStr,
                colMontantTvaStr,
                colObjetFacture
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
            colPrixAchatHorsTaxeStr.Summary.Add(SummaryItemType.Sum, "PrixAchatHorsTaxeMontantTva", "{0:0.000}");
            colMontantTvaStr.Summary.Add(SummaryItemType.Sum, "MontantTva", "{0:0.000}");
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