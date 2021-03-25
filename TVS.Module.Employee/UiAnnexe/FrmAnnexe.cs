using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Extensions;
using DevExpress.XtraReports.UserDesigner;
using FluentValidation.Results;
using TVS.Module.Employee.Models;
using TVS.Core.Models;
using TVS.Module.Employee.Reports;

namespace TVS.Module.Employee.UiAnnexe
{
    public partial class FrmAnnexe<TL, TP> : RibbonForm
        where TL : ILigneAnnexe, new()
        where TP : IPiedAnnexe
    {
        private readonly DeclarationEmployeurController<TL, TP> _controller;
        private readonly Societe _societe;
        private readonly Exercice _exercice;
        private List<TL> _lignesCollection;
        private TL _currentLigne;

        private FrmAnnexe()
        {
            InitializeComponent();
            gvLignesAnnexes.FocusedRowChanged += RowChanged;
            gvLignesAnnexes.RowClick += RowChanged;
            btnImporter.Click += Importer;
            btnDelete.Click += DeleteLigne;
            btnAjouter.Click += AjouterLigne;
            btnSave.Click += SaveLigne;
            gvLigneZoneValue.KeyDown += GridZoneEnterEvent;
            btnExporter.ItemClick += GenererFichier;
            gvLigneZoneValue.CustomRowCellEdit += CustomRowCellEdit;
            gvLigneZoneValue.RowCellDefaultAlignment += RowCellDefaultAlignment;
            splitContainerControl.FixedPanel = SplitFixedPanel.Panel1;
            splitContainerControl.SplitterPosition = 480;
            btnImprimer.ItemClick += ImprimerAnnexeUn;
            btnImprimerList.ItemClick += ImprimerListAnnexeUn;
            Activated += FormActivated;
            btnExporterExcel.ItemClick += ExportToExcel;
            btCustomReport.ItemClick += PersonnaliserCertificat;
          
        }

        public FrmAnnexe(
            DeclarationEmployeurController<TL, TP> controller,
            Societe societe,
            Exercice exercice)
            : this()
        {
            if (controller == null)
                throw new ArgumentNullException("controller");
            if (societe == null) throw new ArgumentNullException("societe");
            if (exercice == null) throw new ArgumentNullException("exercice");

            _controller = controller;
            _societe = societe;
            _exercice = exercice;
      
            InitGridLignes(); 
            InitGridZoneValue();
            _lignesCollection = new List<TL>();
            RefreshDataSource();
     
        }

        private void FormActivated(object sender, EventArgs e)
        {
            var ligne = new TL();
            btnImprimer.Visibility = ligne is LigneAnnexeUn ? BarItemVisibility.Always : BarItemVisibility.Never;
            btCustomReport.Visibility = ligne is LigneAnnexeUn  ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnImprimerList.Visibility = ligne is LigneAnnexeUn ? BarItemVisibility.Always : BarItemVisibility.Never;
            //btnDelete.Visibility = ligne is LigneAnnexeSept ? BarItemVisibility.Never : BarItemVisibility.Always;
            //btnAjouter.Visibility = ligne is LigneAnnexeSept ? BarItemVisibility.Never : BarItemVisibility.Always;
            //btnImporter.Visibility = ligne is LigneAnnexeSept ? BarItemVisibility.Never : BarItemVisibility.Always;
           // gvLigneZoneValue.OptionsBehavior.ReadOnly = ligne is LigneAnnexeSept;

        }

        private void ImprimerAnnexeUn(object sender, EventArgs e)
        {
            var lignesNo = gvLignesAnnexes.GetSelectedRows();
            if (!lignesNo.Any()) return;
            var reportClass = new CertificatRetenueReport(_societe, _exercice);

            var appPath = Path.GetDirectoryName(typeof(Societe).Module.FullyQualifiedName);
            if (appPath == null) return;

            var reportFilePath = Path.Combine(appPath, @"DecEmpEtats\CertificatRetenue.repx");
#if DEBUG
            // debug stuff goes here
            reportFilePath = Path.Combine(appPath, appPath + @"\Reports\Repx\CertificatRetenue.repx");
#endif
            //reportFilePath = Path.Combine(appPath, @"DecEmpEtats\CertificatRetenue.repx");

            // verify that the report file exists
            if (!File.Exists(reportFilePath))
                throw new InvalidOperationException("Certificat de retenue n'existe pas![Report]"+ reportFilePath);
            var report2 = XtraReport.FromFile(reportFilePath, true);
            // get ligne
            foreach (var no in lignesNo)
            {
                var ligne = gvLignesAnnexes.GetRow(no) as ILigneAnnexe;
                if (ligne == null) return;
                var dataSet = reportClass.GetDataSet((LigneAnnexeUn) ligne);
                var report = XtraReport.FromFile(reportFilePath, true);
                report.DataSource = dataSet;
                report.DataMember = reportClass.GetDataMember;
                report.SourceUrl = reportFilePath;
                report.CreateDocument();
                report2.Pages.AddRange(report.Pages);
            }
            report2.ShowPreview();
        }

        private void ImprimerListAnnexeUn(object sender, EventArgs e)
        {
            _controller.Imprimer();
        }

        #region Init Grid

        private void InitGridLignes()
        {
            // intializer la gride
            foreach (var zone in _controller.GetZoneValues())
            {
                if (!zone.EditingInGrid) continue;

                switch (zone.Type)
                {
                    case ZoneType.D:
                        var repoDate = new RepositoryItemDateEdit();
                        gvLignesAnnexes.Columns.Add(new GridColumn
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
                        gvLignesAnnexes.Columns.Add(new GridColumn
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
                        gvLignesAnnexes.Columns.Add(new GridColumn
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
                        gvLignesAnnexes.Columns.Add(new GridColumn
                        {
                            Caption = zone.Code,
                            FieldName = zone.PropertieFieldName,
                            ColumnEdit = repoEnum,
                            Visible = true
                        });
                        break;

                    case ZoneType.X:
                        var repoString = new RepositoryItemTextEdit();
                        gvLignesAnnexes.Columns.Add(new GridColumn
                        {
                            Caption = zone.Code,
                            FieldName = zone.PropertieFieldName,
                            ColumnEdit = repoString,
                            Visible = true
                        });
                        break;
                }
            }

            gvLignesAnnexes.BestFitColumns();

            gvLignesAnnexes.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvLignesAnnexes.OptionsSelection.EnableAppearanceFocusedRow = true;
            gvLignesAnnexes.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            gvLignesAnnexes.Appearance.FocusedRow.BackColor = Color.FromArgb(255, 255, 192);
            gvLignesAnnexes.Appearance.SelectedRow.BackColor = Color.FromArgb(255, 255, 192);
            gvLignesAnnexes.Appearance.OddRow.BackColor = Color.FromArgb(231, 244, 247);
            gvLignesAnnexes.OptionsView.EnableAppearanceOddRow = true;
            gvLignesAnnexes.Appearance.SelectedRow.Options.UseBackColor = true;
            gvLignesAnnexes.OptionsBehavior.Editable = true;
            gvLignesAnnexes.OptionsDetail.EnableMasterViewMode = false;
            gvLignesAnnexes.OptionsBehavior.Editable = false;
            gvLignesAnnexes.OptionsSelection.MultiSelect = true;
            
            gvLignesAnnexes.OptionsView.ShowAutoFilterRow = true;
            gvLignesAnnexes.OptionsFilter.DefaultFilterEditorView = FilterEditorViewMode.VisualAndText;
            gvLignesAnnexes.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Default;
            gvLignesAnnexes.OptionsFind.AlwaysVisible = true;
        }

        private void InitGridZoneValue()
        {
            var repoDesignation = new RepositoryItemMemoEdit();

            var colCode = new GridColumn
            {
                Caption = "Code",
                FieldName = "Code",
                Visible = true,
                MinWidth = 50,
                MaxWidth = 50
            };
            colCode.OptionsColumn.AllowEdit = false;
            colCode.OptionsColumn.TabStop = false;

            var colDesignation = new GridColumn
            {
                Caption = "Designation",
                FieldName = "Description",
                Visible = true,
                ColumnEdit = repoDesignation
            };
            colDesignation.OptionsColumn.AllowEdit = false;
            colDesignation.OptionsColumn.TabStop = false;

            var colValue = new GridColumn
            {
                Caption = "Valeur",
                FieldName = "Value",
                Visible = true,
                MinWidth = 100,
                MaxWidth = 120
            };

            gvLigneZoneValue.Columns.AddRange(new[]
            {
                colCode,
                colDesignation,
                colValue
            });

            gvLigneZoneValue.OptionsView.RowAutoHeight = true;
            gvLigneZoneValue.BestFitColumns();
            gvLigneZoneValue.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvLigneZoneValue.OptionsSelection.EnableAppearanceFocusedRow = true;
            gvLigneZoneValue.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            gvLigneZoneValue.Appearance.FocusedRow.BackColor = Color.FromArgb(255, 255, 192);
            gvLigneZoneValue.Appearance.SelectedRow.BackColor = Color.FromArgb(255, 255, 192);
            gvLigneZoneValue.Appearance.OddRow.BackColor = Color.FromArgb(231, 244, 247);
            gvLigneZoneValue.OptionsView.EnableAppearanceOddRow = true;
            gvLigneZoneValue.Appearance.SelectedRow.Options.UseBackColor = true;
            gvLigneZoneValue.OptionsBehavior.Editable = true;
            gvLigneZoneValue.OptionsDetail.EnableMasterViewMode = false;
            gvLigneZoneValue.OptionsCustomization.AllowColumnMoving = false;
            //gvLigneZoneValue.OptionsCustomization.AllowColumnResizing = false;
            gvLigneZoneValue.OptionsCustomization.AllowFilter = false;
            gvLigneZoneValue.OptionsCustomization.AllowGroup = false;
            gvLigneZoneValue.OptionsCustomization.AllowQuickHideColumns = false;
            gvLigneZoneValue.OptionsCustomization.AllowSort = false;
            gvLigneZoneValue.OptionsMenu.EnableColumnMenu = false;
            gvLigneZoneValue.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            gvLigneZoneValue.OptionsView.ShowGroupPanel = false;
            gvLigneZoneValue.OptionsView.ShowIndicator = false;

            gvLigneZoneValue
                .Columns
                .Cast<GridColumn>()
                .ToList()
                .ForEach(x =>
                {
                    x.OptionsColumn.AllowEdit = false;
                    x.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                    x.AppearanceHeader.Options.UseTextOptions = true;
                });
            colValue.OptionsColumn.AllowEdit = true;
        }

        #endregion Init Grid

        private void RowCellDefaultAlignment(object sender, RowCellAlignmentEventArgs e)
        {
            if (e.Column.FieldName != "Value") return;
            var zoneValue = gvLigneZoneValue.GetRow(e.RowHandle) as LigneAnnexeZoneValue;
            if (zoneValue == null) return;
            e.HorzAlignment = zoneValue.Type == ZoneType.I || zoneValue.Type == ZoneType.N
                ? HorzAlignment.Far
                : HorzAlignment.Near;
        }

        private RepositoryItemImageComboBox GetEnumRepository(Type x)
        {
            var repo = new RepositoryItemImageComboBox();
            repo.Items.AddEnum(x);
            return repo;
        }

        private void CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName != "Value") return;
            var zoneValue = gvLigneZoneValue.GetRow(e.RowHandle) as LigneAnnexeZoneValue;
            if (zoneValue == null) return;
            switch (zoneValue.Type)
            {
                case ZoneType.D:
                    e.RepositoryItem = new RepositoryItemDateEdit
                    {
                        Mask =
                        {
                            MaskType = MaskType.DateTimeAdvancingCaret,
                            EditMask = "ddMMyy"
                        },
                        Appearance =
                        {
                            TextOptions =
                            {
                                HAlignment = HorzAlignment.Near
                            },
                            Options =
                            {
                                UseTextOptions = true,
                            }
                        },
                    };
                    break;

                case ZoneType.N:
                    e.RepositoryItem = new RepositoryItemTextEdit
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
                            FormatString = "n3",
                        },
                        Appearance =
                        {
                            TextOptions =
                            {
                                HAlignment = HorzAlignment.Far
                            },
                            Options =
                            {
                                UseTextOptions = true,
                            }
                        },
                        MaxLength = 15
                    };
                    break;

                case ZoneType.I:
                    e.RepositoryItem = new RepositoryItemTextEdit
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
                            FormatString = "n0",
                        },
                        Appearance =
                        {
                            TextOptions =
                            {
                                HAlignment = HorzAlignment.Far
                            },
                            Options =
                            {
                                UseTextOptions = true,
                            }
                        },
                        MaxLength = 15
                    };
                    break;

                case ZoneType.X:
                    e.RepositoryItem = new RepositoryItemTextEdit
                    {
                        Appearance =
                        {
                            TextOptions =
                            {
                                HAlignment = HorzAlignment.Near
                            },
                            Options =
                            {
                                UseTextOptions = true,
                            }
                        },
                    };
                    break;

                case ZoneType.E:
                    e.RepositoryItem = GetEnumRepository(zoneValue.EnumType);
                    break;
            }
        }

        private void RowChanged(object sender, EventArgs e)
        {
            var ligne = gvLignesAnnexes.GetFocusedRow() as ILigneAnnexe;
            if (ligne == null) return;
            _currentLigne = (TL) ligne;
            gcLigneZoneValue.DataSource = null;
            gcLigneZoneValue.DataSource = _controller.GetZoneValues(_currentLigne);
        }

        private void AjouterLigne(object sender, EventArgs e)
        {
            _currentLigne = new TL();
            gcLigneZoneValue.DataSource = _controller.GetZoneValues(_currentLigne);
        }

        private void SaveLigne(object sender, EventArgs e)
        {
            if (_currentLigne == null) return;

            var ligneZoneValue = gcLigneZoneValue.DataSource as List<LigneAnnexeZoneValue>;
            if (ligneZoneValue == null) return;
            var counter = -1;
            var erreurValue = false;
            var colValue = gvLigneZoneValue.Columns["Value"];

            foreach (var ligneZone in ligneZoneValue.OrderBy(x => x.Code))
            {
                // incrementer nb ligne
                counter++;
                gvLigneZoneValue.FocusedRowHandle = counter;
                switch (ligneZone.Type)
                {
                    case ZoneType.D:
                        // ver valeur date
                        var valueD = Convert.ToDateTime(ligneZone.Value);
                        if (valueD >= new DateTime(2000, 01, 01)) break;
                        gvLigneZoneValue.SetColumnError(colValue, "Date invalide!");
                        erreurValue = true;
                        break;

                    case ZoneType.E:
                        // ver valeur enum
                        var valueE = Convert.ToInt32(ligneZone.Value);
                        if (valueE >= 0) break;
                        gvLigneZoneValue.SetColumnError(colValue, "Valeur invalide!");
                        erreurValue = true;
                        break;

                    case ZoneType.I:
                        // ver valeur int
                        var valueI = Convert.ToInt32(ligneZone.Value);
                        if (valueI >= 0) break;
                        gvLigneZoneValue.SetColumnError(colValue, "Valeur invalide!");
                        erreurValue = true;
                        break;

                    case ZoneType.N:
                        // ver valeur numerique(decimal)
                        var valueN = Convert.ToInt32(ligneZone.Value);
                        if (valueN >= 0) break;
                        gvLigneZoneValue.SetColumnError(colValue, "Montant invalide!");
                        erreurValue = true;
                        break;

                    case ZoneType.X:
                        var valueX = Convert.ToString(ligneZone.Value);
                        if (!string.IsNullOrEmpty(valueX)) break;
                        gvLigneZoneValue.SetColumnError(colValue, "Chaine invalide!");
                        erreurValue = true;
                        break;

                    default:
                        throw new NotImplementedException("Zone type non implimenté!");
                }

                if (erreurValue) return;
                if (_currentLigne.Id == 0) continue;
                // get ligne annexe propertie
                var propertie = typeof(TL).GetProperty(ligneZone.PropertieFieldName);
                // set ligne annexe propertie
                propertie.SetValue(_currentLigne, ligneZone.Value);
            }
            var i = -1;


            try
            {
                // mode ajout
                if (_currentLigne.Id == 0)
                {
                    _currentLigne = _controller.InitializeLigneAnnexe(ligneZoneValue);
                    if (_currentLigne == null) return;
                    var listErr = _controller.Verifier(_currentLigne);
                    foreach (var ligneZone in ligneZoneValue.OrderBy(x => x.Code))
                    {
                        // incrementer nb ligne
                        i++;
                        gvLigneZoneValue.FocusedRowHandle = i;
                        var err = listErr.Where(x => x.PropertyName == ligneZone.PropertieFieldName).ToList();
                        if (err.Any())
                        {
                            gvLigneZoneValue.SetColumnError(colValue, err.First().ErrorMessage);
                            return;
                        }
                    }
                    _controller.Ajouter(_currentLigne);
                    RefreshDataSource();
                    AjouterLigne(null, null);
                    return;
                }

                var listErrUpadte = _controller.Verifier(_currentLigne);
                foreach (var ligneZone in ligneZoneValue.OrderBy(x => x.Code))
                {
                    // incrementer nb ligne
                    i++;
                    gvLigneZoneValue.FocusedRowHandle = i;
                    var err = listErrUpadte.Where(x => x.PropertyName == ligneZone.PropertieFieldName).ToList();
                    if (err.Any())
                    {
                        gvLigneZoneValue.SetColumnError(colValue, err.First().ErrorMessage);
                        return;
                    }
                }
                // mode update
                _controller.Update(_currentLigne);
                // get focused row
                var focusedRow = gvLignesAnnexes.GetFocusedRow() as ILigneAnnexe;
                if (focusedRow == null) return;
                // refresh
                var index = _lignesCollection.IndexOf((TL) focusedRow);
                if (index <= 0) return;
                // get updated row
                var updatedRow = _controller.GetLigne(_currentLigne.Id);
                if (updatedRow == null) return;
                _lignesCollection[index] = updatedRow;

                gvLignesAnnexes.RefreshData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridZoneEnterEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            SaveLigne(null, null);
        }

        private void Importer(object sender, EventArgs e)
        {
            try
            {
                List<TL> lignes;
                var ligne = new TL();
                //if (ligne is LigneAnnexeSept)
                //{
                //    // importation des lignes 7 apartir d'autres annexes 
                //    lignes = _controller.Importer(string.Empty);
                //}
                //else
                //{
                    // get lignes annexe file
                    var openFileDialog = new OpenFileDialog
                    {
                        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                        Filter = @"(*.csv)|*.csv;"
                    };
                    if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                    // charger les lignes annexes a importer
                    lignes = _controller.Importer(openFileDialog.FileName);
                    var errorsStr = _controller.VerifierLigne(lignes);
                    // exporter les erreurs dans un fichier texte
                    if (!string.IsNullOrEmpty(errorsStr))
                    {
                        var frmLog = new FrmLogAnnexe();
                        frmLog.SetAnnexeErreur(errorsStr, Text);
                        frmLog.ShowDialog();
                        return;
                    }
               // }
                // afficher les lignes annexe
                var frm = new FrmImportAnnexe<TL, TP>(_controller);
                frm.SetLignesAnnexe(lignes);
                frm.Text = string.Format("Ligne de l'{0}", Text);
                var result = frm.ShowDialog();
                // verifier l'import
                if (result != DialogResult.OK) return;
                // refresh
                RefreshDataSource();
            }
            catch (Exception ex)
            {
                var message = string.Format("Fichier invalide: {0}", ex.Message);
                XtraMessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteLigne(object sender, EventArgs e)
        {
            var lignesNo = gvLignesAnnexes.GetSelectedRows();
            if (!lignesNo.Any()) return;
            var message = string.Format("Voulez vous vraiment supprimer cette ligne de l'{0} ?", Text);
            var result = XtraMessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            // get ligne
            foreach (var no in lignesNo)
            {
                var ligne = gvLignesAnnexes.GetRow(no) as ILigneAnnexe;
                if (ligne == null) return;

                // suppression de la ligne
                _controller.Delete((TL) ligne);
            }
            RefreshDataSource();
        }

        private void RefreshDataSource()
        {
            var annexe = _controller.LoadAnnexe();
            _lignesCollection = annexe.Lignes.ToList();
            gcLignesAnnexes.DataSource = null;
            gcLignesAnnexes.DataSource = _lignesCollection;
        }

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
            gcLignesAnnexes.ExportToXlsx(sfd.FileName, option);
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

        private void PersonnaliserCertificat(object sender, EventArgs e)
        {
           // // Create a Ribbon End-User Designer form.
           // XRDesignRibbonForm form = new XRDesignRibbonForm();
           // var appPath = Path.GetDirectoryName(typeof(Societe).Module.FullyQualifiedName);
           // if (appPath == null) return;
           // var reportFilePath = Path.Combine(appPath, @"DecEmpEtats\CertificatRetenue.repx");


           //// var reportFilePath = Path.Combine(@"C:\Program Files (x86)\Tvsoft Consult\Declaration\DecEmpEtats\CertificatRetenue.repx");
           // // verify that the report file exists
           // if (!File.Exists(reportFilePath))
           //     throw new InvalidOperationException("Certificat de retenue n'existe pas![Report]" + reportFilePath);
           // var report2 = XtraReport.FromFile(reportFilePath, true);

            var xx = new FrmReportDesigner(new CompositionContainer(new AssemblyCatalog(Assembly.GetAssembly(typeof(Societe)))));
            xx.Show();



            //var reportClass = new CertificatRetenueReport(_societe, _exercice);
            //var dataSet = reportClass.GetDataSet(new LigneAnnexeUn());

           
            //report2.DataSource = dataSet;
            //report2.DataMember = reportClass.GetDataMember;
            //report2.ShowDesigner();


        }
        private void GenererFichier(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;
            if (dialog.SelectedPath == string.Empty) return;
            _controller.Exporter(dialog.SelectedPath);
            XtraMessageBox.Show("Exportation avec succès", ProductName, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
    class ReportExtension : ReportStorageExtension
    {
        public override void SetData(XtraReport report, Stream stream)
        {
            report.SaveLayoutToXml(stream);
        }
    }
}