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
using TVS.Module.Virement.Imports.Controller;
using TVS.Module.Virement.Imports.Views;

namespace TVS.Module.Virement.Imports
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

            var colMatricule = new GridColumn
            {
                Caption = @"Matricule",
                FieldName = "Matricule",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
            };
            var colNom = new GridColumn
            {
                Caption = @"Nom",
                FieldName = "Nom",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Nom"
            };
            var colPrenom = new GridColumn
            {
                Caption = @"Prenom",
                FieldName = "Prenom",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Prenom"
            };
            var colNomBanque = new GridColumn
            {
                Caption = @"Nom banque",
                FieldName = "NomBanque",
                Visible = true,
                MinWidth = 60,
                MaxWidth = 60,
            };
            var colCodeBanque = new GridColumn
            {
                Caption = @"Code banque",
                FieldName = "CodeBanque",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
            };
            var colCodeGuichet = new GridColumn
            {
                Caption = @"Code Guichet",
                FieldName = "CodeGuichet",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
            };
            var colNumeroCompte = new GridColumn
            {
                Caption = @"Numéro compte",
                FieldName = "NumeroCompte",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
             
            };
            var colCleRib = new GridColumn
            {
                Caption = @"Clé",
                FieldName = "CleRib",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 280,
             
            };
            var colNetAPayeStr = new GridColumn
            {
                Caption = @"Net à payé",
                FieldName = "NetAPayeStr",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ColumnEdit = maskRepo
            };
            var colMotifStr = new GridColumn
            {
                Caption = @"Motif",
                FieldName = "Motif",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Motif"
            };


            viewLigne.Columns.AddRange(new[]
            {
                colMatricule,
                colNom,
                colPrenom,
                colNomBanque,
                colCodeBanque,
                colCodeGuichet,
                colNumeroCompte,
                colCleRib,
                colNetAPayeStr,
                colMotifStr,
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
            colNetAPayeStr.Summary.Add(SummaryItemType.Sum, "NetAPaye", "{0:0.000}");
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