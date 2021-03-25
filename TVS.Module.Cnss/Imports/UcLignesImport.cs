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
using TVS.Module.Cnss.Imports.Controller;
using TVS.Module.Cnss.Imports.Views;

namespace TVS.Module.Cnss.Imports
{
    public partial class UcLignesImport : XtraUserControl
    {
        private readonly ImportController _controller;
        private GridColumn colTypeCnss;

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
            if (view.CategorieNo != -1)
                colTypeCnss.OptionsColumn.AllowEdit = false;
        }

        private void InitGridLigneDeclaration()
        {
            var repoCivilite = new RepositoryItemImageComboBox();
            repoCivilite.Items.AddEnum(typeof(Civilite));

            var repoSituationFamille = new RepositoryItemImageComboBox();
            repoSituationFamille.Items.AddEnum(typeof(SituationFamille));
            // Repository Mode de reglement
            var repo = new RepositoryItemGridLookUpEdit
            {
                DataSource = _controller.GetAllCategories(),
                DisplayMember = "Intitule",
                ValueMember = "No"
            };
            repo.View.Columns.Add(new GridColumn
            {
                Caption = @"No",
                FieldName = "No",
                Visible = true,
                MaxWidth = 30
            });
            repo.View.Columns.Add(new GridColumn
            {
                Caption = @"Intitulé",
                FieldName = "Intitule",
                Visible = true
            });
            repo.View.OptionsView.ShowColumnHeaders = false;
            repo.View.OptionsView.ShowFooter = false;
            repo.View.OptionsView.ShowIndicator = false;
            repo.ShowFooter = false;
            repo.PopupFormSize = new Size(200, 200);
            repo.NullText = string.Empty;

            #region grid columns

            var colMatricule = new GridColumn
            {
                Caption = @"Matricule",
                FieldName = "Matricule",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 120,
                ToolTip = @"Matricule"
            };
            var colNumeroCnss = new GridColumn
            {
                Caption = @"Numéro Cnss",
                FieldName = "NumeroCnss",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Numéro Cnss"
            };
            var colCleCnss = new GridColumn
            {
                Caption = @"Clé",
                FieldName = "CleCnss",
                Visible = true,
                MinWidth = 40,
                MaxWidth = 40,
                ToolTip = @"Clé Cnss"
            };
            var colCivilite = new GridColumn
            {
                Caption = @"Civilité",
                FieldName = "Civilite",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Civilite",
                ColumnEdit = repoCivilite
            };
            var colCin = new GridColumn
            {
                Caption = @"Cin",
                FieldName = "Cin",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Cin"
            };
            var colNom = new GridColumn
            {
                Caption = @"Nom",
                FieldName = "Nom",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 160,
                ToolTip = @"Nom"
            };
            var colPrenom = new GridColumn
            {
                Caption = @"Prénom",
                FieldName = "Prenom",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 160,
                ToolTip = @"Prenom"
            };
            var colAutresNom = new GridColumn
            {
                Caption = @"Autres nom",
                FieldName = "AutresNom",
                Visible = true,
                //MinWidth = 80,
                //MaxWidth = 80,
                ToolTip = @"Autres nom"
            };
            var colNomJeuneFille = new GridColumn
            {
                Caption = @"Nom de jeune fille",
                FieldName = "NomJeuneFille",
                Visible = true,
                MinWidth = 20,
                MaxWidth = 160,
                ToolTip = @"Nom de jeune fille"
            };
            var colSituationFamille = new GridColumn
            {
                Caption = @"Situation famille",
                FieldName = "SituationFamille",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Situation famille",
                ColumnEdit = repoSituationFamille
            };
            colTypeCnss = new GridColumn
            {
                Caption = @"Type Cnss",
                FieldName = "TypeCnss",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Type Cnss",
                ColumnEdit = repo
            };
            var maskRepo = new RepositoryItemTextEdit();
            maskRepo.Mask.MaskType = MaskType.Numeric;
            maskRepo.Mask.EditMask = "N3";

            var colBrutAStr = new GridColumn
            {
                ColumnEdit = maskRepo,
                Caption = @"Brut 1",
                FieldName = "BrutAStr",
                Visible = true,
                MinWidth = 50,
                MaxWidth = 80,
                ToolTip = @"BrutA"
            };

            var colBrutBStr = new GridColumn
            {
                ColumnEdit = maskRepo,
                Caption = @"Brut 2",
                FieldName = "BrutBStr",
                Visible = true,
                MinWidth = 50,
                MaxWidth = 80,
                ToolTip = @"Brut 2"
            };

            var colBrutCStr = new GridColumn
            {
                ColumnEdit = maskRepo,
                Caption = @"Brut 3",
                FieldName = "BrutCStr",
                Visible = true,
                MinWidth = 50,
                MaxWidth = 80,
                ToolTip = @"Brut 3"
            };

            viewLigne.Columns.AddRange(new[]
            {
                colMatricule,
                colNumeroCnss,
                colCleCnss,
                colCivilite,
                colCin,
                colNom,
                colPrenom,
                colAutresNom,
                colNomJeuneFille,
                colSituationFamille,
                colTypeCnss,
                colBrutAStr,
                colBrutBStr,
                colBrutCStr
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
            colBrutAStr.Summary.Add(SummaryItemType.Sum, "BrutA", "{0:0.000}");
            colBrutBStr.Summary.Add(SummaryItemType.Sum, "BrutB", "{0:0.000}");
            colBrutCStr.Summary.Add(SummaryItemType.Sum, "BrutC", "{0:0.000}");
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
                foreach (LigneImportView e in Declaration.Lignes)
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