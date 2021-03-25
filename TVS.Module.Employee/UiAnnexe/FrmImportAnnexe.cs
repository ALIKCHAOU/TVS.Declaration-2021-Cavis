using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TVS.Module.Employee.Models;

namespace TVS.Module.Employee.UiAnnexe
{
    public partial class FrmImportAnnexe<TL, TP> : XtraForm
        where TL : ILigneAnnexe, new()
        where TP : IPiedAnnexe
    {
        private readonly DeclarationEmployeurController<TL, TP> _controller;
        private List<TL> _lignesAnnexe;

        private FrmImportAnnexe()
        {
            InitializeComponent();
            btnAnnuler.Click += Annuler;
            btnImporter.Click += Importer;
        }

        public FrmImportAnnexe(DeclarationEmployeurController<TL, TP> controller)
            : this()
        {
            if (controller == null)
                throw new ArgumentNullException(nameof(controller));

            _controller = controller;

            InitGrid();
        }

        public void SetLignesAnnexe(List<TL> lignes)
        {
            _lignesAnnexe = new List<TL>();
            _lignesAnnexe.AddRange(lignes);
            gcLigneImport.DataSource = _lignesAnnexe;
        }

        private void Annuler(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Importer(object sender, EventArgs e)
        {
            try
            {
                // TODO: verifier ligne
                _controller.Ajouter(_lignesAnnexe);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Initialisation grid

        private void InitGrid()
        {
            // intializer la gride
            foreach (var zone in _controller.GetZoneValues())
            {
                switch (zone.Type)
                {
                    case ZoneType.D:
                        var repoDate = new RepositoryItemDateEdit();
                        gvLigneImport.Columns.Add(new GridColumn
                        {
                            Caption = zone.Code,
                            FieldName = zone.PropertieFieldName,
                            ColumnEdit = repoDate,
                            Visible = true
                        });
                        break;

                    case ZoneType.N:

                        var repoDecimal = new RepositoryItemTextEdit
                        {
                            Mask =
                            {
                                MaskType = MaskType.Numeric,
                                EditMask = "n3",
                                ShowPlaceHolders = false
                            },
                            DisplayFormat =
                            {
                                FormatType = FormatType.Numeric,
                                FormatString = "n3"
                            },
                            MaxLength = 15
                        };
                        gvLigneImport.Columns.Add(new GridColumn
                        {
                            Caption = zone.Code,
                            FieldName = zone.PropertieFieldName,
                            ColumnEdit = repoDecimal,
                            Visible = true
                        });
                        break;

                    case ZoneType.I:
                        var repoInterger = new RepositoryItemTextEdit
                        {
                            Mask =
                            {
                                MaskType = MaskType.Numeric,
                                EditMask = "n0",
                                ShowPlaceHolders = false
                            },
                            DisplayFormat =
                            {
                                FormatType = FormatType.Numeric,
                                FormatString = "n0"
                            },
                            MaxLength = 15
                        };
                        gvLigneImport.Columns.Add(new GridColumn
                        {
                            Caption = zone.Code,
                            FieldName = zone.PropertieFieldName,
                            ColumnEdit = repoInterger,
                            Visible = true
                        });
                        break;

                    case ZoneType.E:
                        var repoEnum = new RepositoryItemImageComboBox();
                        repoEnum.Items.AddEnum(zone.EnumType);
                        gvLigneImport.Columns.Add(new GridColumn
                        {
                            Caption = zone.Code,
                            FieldName = zone.PropertieFieldName,
                            ColumnEdit = repoEnum,
                            Visible = true
                        });
                        break;

                    case ZoneType.X:
                        var repoString = new RepositoryItemTextEdit();
                        gvLigneImport.Columns.Add(new GridColumn
                        {
                            Caption = zone.Code,
                            FieldName = zone.PropertieFieldName,
                            ColumnEdit = repoString,
                            Visible = true
                        });
                        break;
                }
            }

            gvLigneImport.BestFitColumns();
            gvLigneImport.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvLigneImport.OptionsSelection.EnableAppearanceFocusedRow = true;
            gvLigneImport.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            gvLigneImport.Appearance.FocusedRow.BackColor = Color.FromArgb(255, 255, 192);
            gvLigneImport.Appearance.SelectedRow.BackColor = Color.FromArgb(255, 255, 192);
            gvLigneImport.Appearance.OddRow.BackColor = Color.FromArgb(231, 244, 247);
            gvLigneImport.OptionsView.EnableAppearanceOddRow = true;
            gvLigneImport.Appearance.SelectedRow.Options.UseBackColor = true;
            gvLigneImport.OptionsBehavior.Editable = true;
            gvLigneImport.OptionsDetail.EnableMasterViewMode = false;
            gvLigneImport.OptionsBehavior.Editable = false;

            gvLigneImport.OptionsCustomization.AllowColumnMoving = false;
            gvLigneImport.OptionsCustomization.AllowColumnResizing = false;
            gvLigneImport.OptionsCustomization.AllowFilter = false;
            gvLigneImport.OptionsCustomization.AllowGroup = false;
            gvLigneImport.OptionsCustomization.AllowQuickHideColumns = false;
            gvLigneImport.OptionsCustomization.AllowSort = false;
            gvLigneImport.OptionsMenu.EnableColumnMenu = false;
            gvLigneImport.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            gvLigneImport.OptionsView.ShowGroupPanel = false;
            gvLigneImport.OptionsView.ShowIndicator = false;
        }

        #endregion Initialisation grid
    }
}