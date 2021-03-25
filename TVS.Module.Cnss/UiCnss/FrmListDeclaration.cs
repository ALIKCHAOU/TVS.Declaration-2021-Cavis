using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CnssModule.Declarations;
using Dapper;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using Ninject;
using TVS.Config;
using TVS.Core;
using TVS.Core.Enums;
using TVS.Core.Models;
using TVS.Core.Reports;
using TVS.Module.Cnss.Imports;
using TVS.Module.Cnss.Report;
using TVS.Module.Cnss.UiCnss.Controller;
using TVS.Module.Cnss.UiCnss.Views;


namespace TVS.Module.Cnss.UiCnss
{
    public partial class FrmListDeclarationCnss : RibbonForm
    {
        private readonly IList<CategorieCnss> _categories;
        private readonly DeclarationsController _controller;
        private readonly Exercice _currentExercice;
        private readonly Societe _currentSociete;
        private GridColumn _colAutresNom;
        private GridColumn _colBrutA;
        private GridColumn _colBrutB;
        private GridColumn _colBrutC;
        private GridColumn _colCin;
        private GridColumn _colCivilite;
        private GridColumn _colCleCnss;
        private GridColumn _colLigne;
        private GridColumn _colMatricule;
        private GridColumn _colNom;
        private GridColumn _colNomJeuneFille;
        private GridColumn _colNumeroCnss;
        private GridColumn _colPage;
        private GridColumn _colPrenom;
        private GridColumn _colTotal;
        private GridColumn _colTypeCnss;
        private BindingList<DeclarationView> _collection;
        private DeclarationView _currentDeclaration;
        private BindingList<LigneView> _listLignes;

        public FrmListDeclarationCnss()
        {
            InitializeComponent();
            btNouveau.Click += Nouveau;
            btValider.Click += Generer;
            btSupprimerLigne.ItemClick += SupprimerLigne;
            btGenererFichier.Click += Exporter;
            btLSupprimer.Click += SupprimerDeclaration;
            btImprimer.Click += Apercu;
            btEtatRecap.Click += ApercuRecap;
            btArchiver.Click += Archiver;
            btImporter.ItemClick += Importer;
            btImporterSage.ItemClick += ImporterSage;
            btLSupprimer.Enabled = false;
            btGenererFichier.Enabled = false;
            btSupprimerLigne.Enabled = false;
            btImprimer.Enabled = false;
            btEtatRecap.Enabled = false;
            btArchiver.Enabled = false;
            btValider.Enabled = false;
            btImporter.Enabled = false;
            btImporterSage.Enabled = false;

            btnExporterCsv.Click += ExportToCsv;
            btnExporterExcel.Click += ExportToExcel;
            btnExporterPdf.Click += ExportToPdf;
        }

        public FrmListDeclarationCnss(DeclarationsController controller)
            : this()
        {
            if (controller == null) throw new ArgumentNullException("controller");

            _controller = controller;
            _categories = _controller.GetAllCategories();
            _currentSociete = controller.GetCurrentSociete();
            _currentExercice = controller.GetCurrentExercice();
            InitGridDeclaration();
            InitLigne();
            _collection = new BindingList<DeclarationView>(_controller.GetAll().ToList());
            gridDeclaration.DataSource = _collection;
            txtExercice.Text = _currentExercice.Annee;
            txtSociete.Text = _currentSociete.RaisonSocial;
            txtMatriculeEmploye.Text = _currentSociete.NumeroEmployeur;
            var bord = viewLigne.GetFocusedRow() as LigneView;

           
        }

        private void Generer(object sender, EventArgs e)
        {
            try
            {
                var declaration = viewDeclaration.GetFocusedRow() as DeclarationView;
                if (declaration == null) return;
                if (declaration.IsCloture)
                {
                    if (declaration.IsArchive)
                        throw new InvalidOperationException("Impossible d'editer une déclaration archiver");
                    DialogResult result =
                        XtraMessageBox.Show(
                            string.Format("Voulez vous editer la déclaration?"),
                            Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result != DialogResult.Yes) return;
                    _controller.Editer(declaration);
                }
                else
                {
                    try
                    {
                        SplashScreenManager.ShowForm(typeof(WaitFormDec));
                        _controller.Gerer(declaration);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        SplashScreenManager.CloseForm();
                    }
                }

                _currentDeclaration = _controller.GetDeclaration(_currentDeclaration.Id);
                int indexOld = _collection.IndexOf(declaration);
                _collection[indexOld] = _currentDeclaration;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Nouveau(object sender, EventArgs e)
        {
            try
            {
                var form = ConfigProgram.Kernel.Get<FrmDeclaration>();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    List<DeclarationView> declarations = _controller.GetAll().ToList();
                    _collection = new BindingList<DeclarationView>(declarations);
                    gridDeclaration.DataSource = _collection;
                    viewDeclaration.FocusedRowHandle = declarations.Count - 1;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Exporter(object sender, EventArgs e)
        {
            try
            {
                if (!_currentDeclaration.IsCloture)
                    return;
                var dialog = new FolderBrowserDialog();

                DialogResult result = dialog.ShowDialog();
                if (result != DialogResult.OK) return;
                if (dialog.SelectedPath == string.Empty) return;

                _controller.Exporter(_currentDeclaration, dialog.SelectedPath);
                XtraMessageBox.Show("Exportation avec succès", ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SupprimerLigne(object sender, EventArgs e)
        {
            try
            {
                if (_currentDeclaration == null) return;
                if (_currentDeclaration.IsCloture)
                    throw new ApplicationException("Opération invalide! [Déclaration est validé]");
                var ligne = viewLigne.GetFocusedRow() as LigneView;
                if (ligne == null) return;
                DialogResult result =
                    XtraMessageBox.Show(
                        string.Format("Voulez vous supprimer ligne Cnss du l'employée N°[{0}]?", ligne.Cin),
                        Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
                _controller.Delete(ligne);
                int indexOld = _listLignes.IndexOf(ligne);
                _listLignes.Remove(ligne);
                if (indexOld < 0)
                    return;

                viewLigne.FocusedRowHandle = indexOld - 1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SupprimerDeclaration(object sender, EventArgs e)
        {
            try
            {
                if (_currentDeclaration == null) return;
                if (_currentDeclaration.IsCloture)
                    throw new ApplicationException("Opération invalide! [Déclaration est validé]");

                DialogResult result =
                    XtraMessageBox.Show(
                        string.Format("Voulez vous supprimer la déclaration?"),
                        Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
                _controller.Delete(_currentDeclaration);
                int indexOld = _collection.IndexOf(_currentDeclaration);
                _collection.Remove(_currentDeclaration);
                if (indexOld < 0) return;
                if (_collection.Count == 0)
                    gridLigne.DataSource = null;
                viewDeclaration.FocusedRowHandle = indexOld - 1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

            // Repository Mode de reglement
            var repo = new RepositoryItemGridLookUpEdit
            {
                DataSource = _controller.GetAllCategories(),
                DisplayMember = "Intitule",
                ValueMember = "Id"
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

            var colTrimestre = new GridColumn
            {
                Caption = @"Trimestre",
                FieldName = "Trimestre",
                Visible = true,
                //MinWidth = 60,
                //MaxWidth = 60,
                ToolTip = @"Trimestre",
            };
            var colComplementaire = new GridColumn
            {
                Caption = @"Complementaire",
                FieldName = "Complementaire",
                Visible = true,
                //MinWidth = 60,
                //MaxWidth = 80,
                ToolTip = @"Complementaire",
                ColumnEdit = repoImageComplementaire
            };
            var colDate = new GridColumn
            {
                Caption = @"Date",
                FieldName = "Date",
                Visible = true,
                //MinWidth = 70,
                //MaxWidth = 70,
                ToolTip = @"Date",
            };
            var colCloture = new GridColumn
            {
                Caption = @"Valider",
                FieldName = "IsCloture",
                Visible = true,
                //MinWidth = 50,
                //MaxWidth = 50,
                ToolTip = @"Valider",
                ColumnEdit = repoImageCloturer
            };
            var colArchiver = new GridColumn
            {
                Caption = @"Archiver",
                FieldName = "IsArchive",
                Visible = true,
                //MinWidth = 50,
                //MaxWidth = 50,
                ToolTip = @"Archiver",
                ColumnEdit = repoImageArchiver
            };
            viewDeclaration.Columns.AddRange(new[]
            {
                colTrimestre,
               // colDate,
                colComplementaire,
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
            //viewDeclaration.OptionsDetail.EnableMasterViewMode = false;
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
            var repoCivilite = new RepositoryItemImageComboBox();
            repoCivilite.Items.AddEnum(typeof(Civilite));

            var repoSituationFamille = new RepositoryItemImageComboBox();
            repoSituationFamille.Items.AddEnum(typeof(SituationFamille));
            // Repository Mode de reglement
            var repo = new RepositoryItemGridLookUpEdit
            {
                DataSource = _controller.GetAllCategories(),
                DisplayMember = "Intitule",
                ValueMember = "Id"
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

            _colMatricule = new GridColumn
            {
                Caption = @"Matricule",
                FieldName = "NumeroInterne",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Matricule"
            };
            _colNumeroCnss = new GridColumn
            {
                Caption = @"Numéro Cnss",
                FieldName = "NumeroCnss",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Numéro Cnss"
            };
            _colCleCnss = new GridColumn
            {
                Caption = @"Clé",
                FieldName = "CleCnss",
                Visible = true,
                MinWidth = 40,
                MaxWidth = 40,
                ToolTip = @"Clé Cnss"
            };
            _colCivilite = new GridColumn
            {
                Caption = @"Civilité",
                FieldName = "Civilite",
                Visible = true,
                MinWidth = 60,
                MaxWidth = 60,
                ToolTip = @"Civilite",
                ColumnEdit = repoCivilite
            };
            _colCin = new GridColumn
            {
                Caption = @"Cin",
                FieldName = "Cin",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Cin",
            };
            _colNom = new GridColumn
            {
                Caption = @"Nom",
                FieldName = "Nom",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Nom"
            };
            _colPrenom = new GridColumn
            {
                Caption = @"Prénom",
                FieldName = "Prenom",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Prenom"
            };
            _colAutresNom = new GridColumn
            {
                Caption = @"Autres nom",
                FieldName = "AutresNom",
                Visible = true,
                //MinWidth = 80,
                //MaxWidth = 80,
                ToolTip = @"Autres nom"
            };
            _colNomJeuneFille = new GridColumn
            {
                Caption = @"Nom de jeune fille",
                FieldName = "NomJeuneFille",
                Visible = true,
                MinWidth = 20,
                MaxWidth = 100,
                ToolTip = @"Nom de jeune fille"
            };

            _colPage = new GridColumn
            {
                Caption = @"Page",
                FieldName = "Page",
                Visible = true,
                MinWidth = 35,
                MaxWidth = 35,
                ToolTip = @"Page",
            };
            _colLigne = new GridColumn
            {
                Caption = @"Ligne",
                FieldName = "Ligne",
                Visible = true,
                MinWidth = 35,
                MaxWidth = 35,
                ToolTip = @"Ligne",
            };
            _colTypeCnss = new GridColumn
            {
                Caption = @"Type Cnss",
                FieldName = "CategorieNo",
                Visible = true,
                MinWidth = 80,
                MaxWidth = 80,
                ToolTip = @"Type Cnss",
                ColumnEdit = repo
            };
            var maskRepo = new RepositoryItemTextEdit();
            maskRepo.Mask.MaskType = MaskType.Numeric;
            maskRepo.Mask.EditMask = "N3";

            _colBrutA = new GridColumn
            {
                ColumnEdit = maskRepo,
                Caption = @"Brut 1",
                FieldName = "Brut1",
                Visible = true,
                MinWidth = 50,
                MaxWidth = 80,
                ToolTip = @"Brut1"
            };

            _colBrutB = new GridColumn
            {
                ColumnEdit = maskRepo,
                Caption = @"Brut 2",
                FieldName = "Brut2",
                Visible = true,
                MinWidth = 50,
                MaxWidth = 80,
                ToolTip = @"Brut 2"
            };

            _colBrutC = new GridColumn
            {
                ColumnEdit = maskRepo,
                Caption = @"Brut 3",
                FieldName = "Brut3",
                Visible = true,
                MinWidth = 50,
                MaxWidth = 80,
                ToolTip = @"Brut 3"
            };
            _colTotal = new GridColumn
            {
                ColumnEdit = maskRepo,
                Caption = @"Total",
                FieldName = "Total",
                Visible = true,
                MinWidth = 50,
                MaxWidth = 80,
                ToolTip = @"Total"
            };
            viewLigne.Columns.AddRange(new[]
            {
                _colMatricule,
                _colNumeroCnss,
                _colCleCnss,
                _colCin,
                _colCivilite,
                _colNom,
                _colPrenom,
                _colAutresNom,
                _colNomJeuneFille,
                _colTypeCnss,
                _colBrutA,
                _colBrutB,
                _colBrutC,
                _colTotal,
                _colPage,
                _colLigne
            });

            //viewLigne.OptionsCustomization.AllowColumnMoving = false;
            //viewLigne.OptionsCustomization.AllowColumnResizing = false;
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
            _colBrutA.Summary.Add(SummaryItemType.Sum, "Brut1", "{0:0.000}");
            _colBrutB.Summary.Add(SummaryItemType.Sum, "Brut2", "{0:0.000}");
            _colBrutC.Summary.Add(SummaryItemType.Sum, "Brut3", "{0:0.000}");
            viewLigne.OptionsView.ShowFooter = true;
            viewLigne.FooterPanelHeight = 35;

            viewLigne.CustomDrawGroupRow += GridViewCustomDrawGroupRow;
            viewLigne.ValidateRow += Valider;
            viewLigne.InvalidRowException += Invalide;
        }

        private void FocusedRowChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            var declaration = viewDeclaration.GetFocusedRow() as DeclarationView;
            if (declaration == null)
            {
                txtTrimestre.Text = string.Empty;
                txtDate.Text = string.Empty;
                btLSupprimer.Enabled = false;
                btGenererFichier.Enabled = false;
                btSupprimerLigne.Enabled = false;
                btImprimer.Enabled = false;
                btEtatRecap.Enabled = false;
                btArchiver.Enabled = false;
                btValider.Enabled = false;
                return;
            }
            viewLigne.OptionsView.ShowAutoFilterRow = !declaration.IsCloture;
            viewLigne.OptionsView.ShowGroupPanel = !declaration.IsCloture;
            viewLigne.OptionsCustomization.AllowSort = !declaration.IsCloture;
            viewLigne.OptionsBehavior.Editable = !declaration.IsCloture;
            viewLigne.OptionsCustomization.AllowGroup = !declaration.IsCloture;

            _colTypeCnss.GroupIndex = declaration.IsCloture ? 1 : -1;
            _colLigne.Visible = declaration.IsCloture;
            _colPage.Visible = declaration.IsCloture;
            _colTotal.Visible = declaration.IsCloture;

            btImporter.Enabled = !declaration.IsCloture;
            btImporterSage.Enabled = !declaration.IsCloture;
            viewLigne.ExpandAllGroups();
            btValider.Enabled = true;
            if (declaration.IsCloture)
            {
                viewLigne.GroupRowCollapsing += GridViewGroupRowCollapsing;
                btLSupprimer.Enabled = false;
                btGenererFichier.Enabled = true;
                btSupprimerLigne.Enabled = false;
                btImprimer.Enabled = true;
                btEtatRecap.Enabled = true;
                btArchiver.Enabled = true;
            }
            else
            {
                viewLigne.GroupRowCollapsing -= GridViewGroupRowCollapsing;
                btLSupprimer.Enabled = true;
                btGenererFichier.Enabled = false;
                btSupprimerLigne.Enabled = true;
                btImprimer.Enabled = false;
                btEtatRecap.Enabled = false;
                btArchiver.Enabled = false;
            }

            if (declaration.IsArchive)
            {
                btArchiver.Enabled = false;
                btValider.Enabled = false;
            }
            foreach (object col in viewLigne.Columns)
            {
                var column = col as GridColumn;
                if (column == null) continue;
                column.OptionsColumn.AllowEdit = !declaration.IsCloture;
            }
            _colCin.OptionsColumn.AllowEdit = false;
            _colMatricule.OptionsColumn.AllowEdit = false;

            _currentDeclaration = declaration;
            btValider.Text = declaration.IsCloture ? "Editer" : "Valider";

            BindingList<LigneView> lignes = _controller.GetAllLigne(_currentDeclaration.Id);
            _listLignes = new BindingList<LigneView>(lignes);
            gridLigne.DataSource = null;
            gridLigne.DataSource = _listLignes;
            viewLigne.ExpandAllGroups();
            if (declaration.IsCloture)
            {
                txtTotalBrut1.Text = string.Format("{0:0.000}", _listLignes.Sum(x => x.Brut1));
                txtTotalBrut2.Text = string.Format("{0:0.000}", _listLignes.Sum(x => x.Brut2));
                txtTotalBrut3.Text = string.Format("{0:0.000}", _listLignes.Sum(x => x.Brut3));
                txtTotal.Text = string.Format("{0:0.000}", _listLignes.Sum(x => x.Total));
            }
            else
            {
                txtTotalBrut1.Text = @"0.000";
                txtTotalBrut2.Text = @"0.000";
                txtTotalBrut3.Text = @"0.000";
                txtTotal.Text = @"0.000";
            }
            txtTrimestre.Text = string.Format("{0:0}", _currentDeclaration.Trimestre);
            txtDate.Text = string.Format("{0:dd/MM/yyyy}", _currentDeclaration.Date);
        }

        private void Apercu(object sender, EventArgs e)
        {
            try
            {
                if (_currentDeclaration == null)
                    throw new InvalidOperationException("Opération invalide!");
                if (!_currentDeclaration.IsCloture)
                    throw new InvalidOperationException("Opération invalide!");

                DeclarationReport etat = _controller.Imprimer(_currentDeclaration);
                var printTool = new ReportPrintTool(etat);

                printTool.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Archiver(object sender, EventArgs e)
        {
            try
            {
                var declaration = viewDeclaration.GetFocusedRow() as DeclarationView;
                if (declaration == null) return;
                if (!declaration.IsCloture)
                    throw new ApplicationException("Opération invalide! [Déclaration est validé]");

                DialogResult result =
                    XtraMessageBox.Show(
                        string.Format("Voulez vous archiver la déclaration?"),
                        Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;

                _controller.Archiver(_currentDeclaration);
                _currentDeclaration = _controller.GetDeclaration(_currentDeclaration.Id);
                int indexOld = _collection.IndexOf(declaration);
                _collection[indexOld] = _currentDeclaration;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Importer(object sender, EventArgs e)
        {
            try
            {
                if (_currentDeclaration == null) return;
                if (_currentDeclaration.IsCloture)
                    throw new ApplicationException("Opération invalide! [Déclaration est validé]");
                var ligne = viewDeclaration.GetFocusedRow() as DeclarationView;
                if (ligne == null) return;

                var form = ConfigProgram.Kernel.Get<FrmImportDeclaration>();

                form.InitialController(_currentDeclaration.Id);
                int focusedHandle = viewDeclaration.FocusedRowHandle;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _collection = new BindingList<DeclarationView>(_controller.GetAll().ToList());
                    gridDeclaration.DataSource = _collection;
                    viewDeclaration.FocusedRowHandle = focusedHandle;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ImporterSage(object sender, EventArgs e)
        {
            try
            {
                if (_currentDeclaration == null) return;
                if (_currentDeclaration.IsCloture)
                    throw new ApplicationException("Opération invalide! [Déclaration est validé]");
                var ligne = viewDeclaration.GetFocusedRow() as DeclarationView;
                if (ligne == null) return;

                try
                {
                    using (var con = new SqlConnection(_currentSociete.GetConnection()))
                    {
                        con.Open();
                        // connexion etablie, verifiee, valide, ...
                    }
                }
                catch
                {
                    // echec de la connexion
                    XtraMessageBox.Show("La connexion est erronée!", "AMEN CONSEIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                var form = ConfigProgram.Kernel.Get<FrmImportSqlDeclaration>();

                form.InitialController(_currentDeclaration.Id);
                int focusedHandle = viewDeclaration.FocusedRowHandle;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _collection = new BindingList<DeclarationView>(_controller.GetAll().ToList());
                    gridDeclaration.DataSource = _collection;
                    viewDeclaration.FocusedRowHandle = focusedHandle;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApercuRecap(object sender, EventArgs e)
        {
            try
            {
                if (_currentDeclaration == null)
                    throw new InvalidOperationException("Opération invalide!");
                if (!_currentDeclaration.IsCloture)
                    throw new InvalidOperationException("Opération invalide!");

                RecapCnssReportI3 etat = _controller.ImprimerRecap(_currentDeclaration);
                var printTool = new ReportPrintTool(etat);

                printTool.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridViewCustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;
            var info = e.Info as GridGroupRowInfo;
            if (info == null) return;
            if (info.Column.Caption == @"Type Cnss")
            {
                int quantity = Convert.ToInt32(view.GetGroupRowValue(e.RowHandle, info.Column));

                string action = GetAction(quantity);

                info.GroupText = action;
            }
        }

        private string GetAction(int value)
        {
            CategorieCnss ec = _categories.First(x => x.Id == value);

            string result = "";
            result += "Catégorie  : <color=RED>" + ec.Intitule + "</color>  ";
            result += " [ <color=BLUE>" + ec.CodeExploitation + "</color> ] ";

            return result;
        }

        private void GridViewGroupRowCollapsing(object sender, RowAllowEventArgs e)
        {
            e.Allow = false;
        }

        private void Invalide(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void Valider(object sender, ValidateRowEventArgs e)
        {
            // clear columns errors
            viewLigne.ClearColumnErrors();

            var ligne = e.Row as LigneView;
            if (ligne == null)
            {
                e.Valid = false;
                return;
            }
            var regNumber = new Regex(@"^\d+$");
            var regName = new Regex(@"^[\ a-zA-Z]+$");

            // verifier numero cnss
            if (string.IsNullOrEmpty(ligne.NumeroCnss)
                || ligne.NumeroCnss.Length > 8
                || !regNumber.IsMatch(ligne.NumeroCnss))
            {
                viewLigne.SetColumnError(_colNumeroCnss, "Le champs [Matricule Cnss] est invalide!");
                e.Valid = false;
                return;
            }

            // verifier numero cle cnss
            if (string.IsNullOrEmpty(ligne.CleCnss)
                || ligne.CleCnss.Length > 2
                || !regNumber.IsMatch(ligne.CleCnss))
            {
                viewLigne.SetColumnError(_colCleCnss, "Le champs [Clé Cnss] est invalide!");
                e.Valid = false;
                return;
            }
            ligne.CleCnss = ligne.CleCnss.PadLeft(2, '0');

            // verifier numero interne
            if (string.IsNullOrEmpty(ligne.NumeroInterne)
                || ligne.NumeroInterne.Length > 10
                //|| !regNumber.IsMatch(ligne.NumeroInterne)
                )
            {
                viewLigne.SetColumnError(_colMatricule, "Matricule interne invalide!");
                e.Valid = false;
                return;
            }
            //Verifier Autres nom
            if (!string.IsNullOrEmpty(ligne.AutresNom) && !regName.IsMatch(ligne.AutresNom))
            {
                viewLigne.SetColumnError(_colAutresNom, "Le champs [Autres nom] est invalide!");
                e.Valid = false;
                return;
            }
            // verifier numero cin
            if (string.IsNullOrEmpty(ligne.Cin))
            {
                viewLigne.SetColumnError(_colCin, "Champs obligatoire!");
                e.Valid = false;
                return;
            }
            var rgxCin = new Regex(@"[0-9]{8}");
            if (!rgxCin.IsMatch(ligne.Cin))
            {
                viewLigne.SetColumnError(_colCin, "Le champs [Cin] est invalide!");
                e.Valid = false;
                return;
            }
            // verifier nom
            if (string.IsNullOrEmpty(ligne.Nom))
            {
                viewLigne.SetColumnError(_colNom, "Champs obligatoire!");
                e.Valid = false;
                return;
            }
            if (!regName.IsMatch(ligne.Nom))
            {
                viewLigne.SetColumnError(_colNom, "Le champs [Nom] est invalide!");
                e.Valid = false;
                return;
            }

            // verifier prenom
            if (string.IsNullOrEmpty(ligne.Prenom))
            {
                viewLigne.SetColumnError(_colPrenom, "Champs obligatoire!");
                e.Valid = false;
                return;
            }
            if (!regName.IsMatch(ligne.Prenom))
            {
                viewLigne.SetColumnError(_colNom, "Le champs [Prenom] est invalide!");
                e.Valid = false;
                return;
            }

            // verifier les bruts
            if (ligne.Brut1 == 0 && ligne.Brut2 == 0 && ligne.Brut3 == 0)
            {
                viewLigne.SetColumnError(_colBrutA, "Montant invalide!");
                e.Valid = false;
                return;
            }
            // verifier Brut1
            if (ligne.Brut1 < 0)
            {
                viewLigne.SetColumnError(_colBrutA, "Montant invalide!");
                e.Valid = false;
                return;
            }

            // verifier Brut2
            if (ligne.Brut2 < 0)
            {
                viewLigne.SetColumnError(_colBrutB, "Montant invalide!");
                e.Valid = false;
                return;
            }
            // verifier Brut3
            if (ligne.Brut3 < 0)
            {
                viewLigne.SetColumnError(_colBrutC, "Montant invalide!");
                e.Valid = false;
                return;
            }

            try
            {
                // update
                _controller.Update(ligne);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Valid = false;
            }
        }

        #region Export

        private void ExportToExcel(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Title = @"Enregistrer",
                DefaultExt = "xlsx",
                Filter = @"Excel document (*.xlsx)|*.xlsx"
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
            viewLigne.ExportToXlsx(sfd.FileName, option);
            OpenExportedFile(sfd.FileName);
        }

        private void ExportToCsv(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Title = @"Enregistrer",
                DefaultExt = "CSV",
                Filter = @"CSV document (*.CSV)|*.CSV"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            if (string.IsNullOrEmpty(sfd.FileName)) return;
            // export CSV options
            var options = new CsvExportOptions
            {
                Separator = @";",
                TextExportMode = TextExportMode.Value,
                QuoteStringsWithSeparators = true,
                Encoding = Encoding.Unicode,
                EncodingType = EncodingType.Unicode,
            };
            viewLigne.OptionsPrint.PrintFooter = false;
            viewLigne.ExportToCsv(sfd.FileName, options);
            viewLigne.OptionsPrint.PrintFooter = true;
            OpenExportedFile(sfd.FileName);
        }

        private void ExportToPdf(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Title = @"Enregistrer",
                DefaultExt = "PDF",
                Filter = @"Pdf document (*.pdf)|*.pdf"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            if (string.IsNullOrEmpty(sfd.FileName)) return;
            // les options d'exportation Text
            var options = new PdfExportOptions
            {
                Compressed = false,
                ConvertImagesToJpeg = true,
                DocumentOptions =
                {
                    Application = @"Déclaration CNSS",
                    Author = @"AMEN CONSEIL",
                },
                ImageQuality = PdfJpegImageQuality.Highest,
            };

            // export grid view to Text
            viewLigne.OptionsPrint.PrintFooter = false;
            viewLigne.ExportToPdf(sfd.FileName, options);
            viewLigne.OptionsPrint.PrintFooter = true;
            OpenExportedFile(sfd.FileName);
        }

        private static void OpenExportedFile(string path)
        {
            if (string.IsNullOrEmpty(path)) return;
            if (!File.Exists(path)) return;

            var result = XtraMessageBox.Show("Voulez-vous ouvrir le fichier exporté?", "Export", MessageBoxButtons.YesNo,
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

        #endregion Export

        private void btnImpCer_Click(object sender, EventArgs e)
        {
         
            var lignesNo = viewLigne.GetSelectedRows();
            var ligneDec = viewLigne.GetRow(lignesNo[0]) as LigneView;
            LigneCnss ligCNSS = new LigneCnss();
            List<LigneCnss> LigneCNSS = new List<LigneCnss>();
            List<int> LigneT = new List<int>();


            ImprimerCertificat frm = new ImprimerCertificat(_controller, LigneCNSS, ligneDec.EmployeeNo, LigneT);

           // int[] selectedRows = viewLigne.GetSelectedRows();
            
               int dataRowCount = viewLigne.DataRowCount;

                string query = @"SELECT distinct   lc.nom, lc.Prenom, cast(lc.Brut1 as decimal(18,3)) as Brut1  ,cast(lc.Brut2 as decimal(18,3)) as Brut2 , cast(lc.Brut3 as decimal(18,3)) as Brut3 , lc.Page , lc.Ligne ,dc.Trimestre , s.RaisonSocial   ,  Ex.Annee as Année ,  lc.NumeroInterne as Matricule  
 ,s.[RaisonSocial] as NomSociete , CONCAT(s.[NumeroEmployeur],' - ',s.CleEmployeur) as CNSS_Societe  , CONCAT(lc.[NumeroCnss],' - ',lc.CleCnss) as CNSS_Empolye
  FROM  [dbo].[LigneCnss]   lc inner join DeclarationCnss dc on lc.SocieteNo = dc.SocieteId  and lc.DeclarationNo = dc.Id    inner join[dbo].[Societe] s on lc.SocieteNo=s.Id 

    inner join [dbo].[Exercice]   Ex on dc.ExerciceId=Ex.Id

 where  s.[RaisonSocial]='" + txtSociete.Text + "' and   year (Ex.Annee)='" + txtExercice.Text + "' order by Ex.Annee, dc.Trimestre ;";

            if (query != null)
            {
                    



                    List<AttestationSalaire> data = new List<AttestationSalaire>();

                    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString))
                    {
                        if (db.State == ConnectionState.Closed)
                            db.Open();
                        var a = db.Query<AttestationSalaire>(query, commandType: CommandType.Text);

                        foreach (AttestationSalaire at in a)
                        {
                            data.Add(at);
                            //at.Montant =(_colTotal);

                        }


                    }

                    AttestationALL report = new AttestationALL();               
                    report.DataSource = data;
                ReportPrintTool tool = new ReportPrintTool(report);
                tool.ShowPreview();



                //_attestation report1 = new _attestation();
                //report1.DataSource = data;
                //ReportPrintTool tool1 = new ReportPrintTool(report1);
                //tool1.ShowPreview();

               
                }
                else
                {
                    MessageBox.Show("", "Attestation CNSS n'existe pas!",
         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
          
          

    





        private void btPersonaliser_Click(object sender, EventArgs e)
        {
            var xx = new FrmReportDesigner(new CompositionContainer(new AssemblyCatalog(Assembly.GetAssembly(typeof(Societe)))));
            xx.Show();

        }

        ////print
        //public string getnum()
        //{
        //    var bord = viewLigne.GetFocusedRow() as LigneView;


        //    string num = bord.NumeroInterne.ToString();
        //    MessageBox.Show(bord.NumeroInterne.ToString());
        //    return num;
        //}

        //   string b = getnum();
        private void simpleButton1_Click(object sender, EventArgs e)
        {


            var lignesNo = viewLigne.GetSelectedRows();
            var ligneDec = viewLigne.GetRow(lignesNo[0]) as LigneView;
            LigneCnss ligCNSS = new LigneCnss();
            List<LigneCnss> LigneCNSS = new List<LigneCnss>();
            List<int> LigneT = new List<int>();
           

            ImprimerCertificat frm = new ImprimerCertificat(_controller, LigneCNSS, ligneDec.EmployeeNo, LigneT);
            var bord = viewLigne.GetFocusedRow() as LigneView;

            string num = bord.NumeroInterne.ToString();
            frm._Matricule = num;
            frm._RaisonSocial = _currentSociete.RaisonSocial;


             // MessageBox.Show(frm._RaisonSocial.ToString());
            if (frm.ShowDialog() == DialogResult.OK)
            {
                

  


                }


            }

        private void btImporter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    } } 