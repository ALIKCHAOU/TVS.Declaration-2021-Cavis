using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraSplashScreen;
using Ninject;
using TVS.Config;
using TVS.Config.Helpers;
using TVS.Module.Virement.Imports;
using TVS.Module.Virement.UiVirement.Controller;
using TVS.Module.Virement.UiVirement.Views;
using TVS.Module.Virement.Reports;
using System.Reflection;
using TVS.Core.Models;
using System.ComponentModel.Composition.Hosting;
using DevExpress.XtraReports.UI;
using TVS.Module.Virement.Imports.Repository;

namespace TVS.Module.Virement.UiVirement
{
    public partial class FrmListDeclaration : RibbonForm
    {
        private readonly DeclarationController _controller;

        private BindingList<DeclarationView> _collection;
        private DeclarationView _currentDeclaration;
        private BindingList<LigneView> _listLignes;

        private FrmListDeclaration()
        {
            InitializeComponent();
            btNouveau.Click += Nouveau;
            btValider.Click += Generer;
            btSupprimerLigne.ItemClick += SupprimerLigne;
            btGenererFichier.Click += Exporter;
            btLSupprimer.Click += SupprimerDeclaration;
            viewLigne.InitNewRow += LigneInitNewRow;

            btDeleteRow.ItemClick += btDeleteR;

            btArchiver.Click += Archiver;
            btImporter.ItemClick += Importer;
            btImportSage.ItemClick += ImporterSage;
            btLSupprimer.Enabled = false;
            btGenererFichier.Enabled = false;
            btSupprimerLigne.Enabled = false;
            btArchiver.Enabled = false;
            btValider.Enabled = false;
            btImporter.Enabled = false;
            btImportSage.Enabled = false;
            btnPersonnaliser.Click += Personnaliser;
            btnImprimer.Click += Imprimer;
            btnExporterCsv.Click += ExportToCsv;
            btnExporterExcel.Click += ExportToExcel;
            btnExporterPdf.Click += ExportToPdf;
            txtMotif.KeyDown += UpdateDeclaration;
            txtReference.KeyDown += UpdateDeclaration;
        }

        private void LigneInitNewRow(object sender, InitNewRowEventArgs e)
        {
            // get new ligne
            var ligne = viewLigne.GetFocusedRow() as LigneView;
            if (ligne == null) return;
            // intialise ligne
            ligne.CleRib = string.Empty;
            ligne.CodeBanque = string.Empty;
            ligne.CodeGuichet = string.Empty;
            ligne.Motif = string.Empty;
            ligne.Prenom = string.Empty;
            ligne.NetAPaye = 0;
            ligne.NumeroCompte = string.Empty;
            ligne.NomBanque = string.Empty;
            ligne.Nom = string.Empty;
           
        }

        public FrmListDeclaration(DeclarationController controller)
            : this()
        {
            if (controller == null) throw new ArgumentNullException("controller");

            _controller = controller;
            InitGridDeclaration();
            InitLigne();
            _collection = new BindingList<DeclarationView>(_controller.GetAll().ToList());
            gridDeclaration.DataSource = _collection;
            var currentSociete = controller.GetCurrentSociete();
            if (currentSociete == null) throw new ApplicationException("Societe invalide!");
            var currentExercice = controller.GetCurrentExercice();
            if (currentExercice == null) throw new ApplicationException("Exercice invalide!");
            txtExercice.Text = currentExercice.Annee;
            txtSociete.Text = currentSociete.RaisonSocial;
        }

        private void Generer(object sender, EventArgs e)
        {
            try
            {
                var declaration = viewDeclaration.GetFocusedRow() as DeclarationView;
                if (declaration == null) return;
                if (declaration.Cloturer)
                {
                    if (declaration.Archiver)
                        throw new InvalidOperationException("Impossible d'editer un virement archiver");
                    DialogResult result =
                        XtraMessageBox.Show(
                            string.Format("Voulez vous editer le virement?"),
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
                if (!_currentDeclaration.Cloturer)
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
                if (_currentDeclaration.Cloturer)
                    throw new ApplicationException("Opération invalide! [Déclaration est validé]");
                

                List<LigneView> listLigne = new List<LigneView>();
                foreach(var row in viewLigne.GetSelectedRows())
                {
                    listLigne.Add(viewLigne.GetRow(row)as LigneView);
                }

                var result =
                    XtraMessageBox.Show(
                        string.Format("Voulez vous supprimer {0} Ligne(s) ?", listLigne.Count),
                        Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
                foreach (var ligne in listLigne)
                {
                    if (ligne == null) continue;
                    _controller.Delete(ligne);
                    var indexOld = _listLignes.IndexOf(ligne);
                    _listLignes.Remove(ligne);
                    if (indexOld < 0)
                    return;
                }

                //viewLigne.FocusedRowHandle = indexOld - 1;
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
                if (_currentDeclaration.Cloturer)
                    throw new ApplicationException("Opération invalide! [Virement est validé]");

                var result =
                    XtraMessageBox.Show(
                        string.Format("Voulez vous supprimer la virement?"),
                        Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
                _controller.Delete(_currentDeclaration);
                var indexOld = _collection.IndexOf(_currentDeclaration);
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

        private void FocusedRowChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            txtMotif.Reset();
            txtReference.Reset();
            var declaration = viewDeclaration.GetFocusedRow() as DeclarationView;
            if (declaration == null)
            {
                txtDate.Text = string.Empty;
                btLSupprimer.Enabled = false;
                btGenererFichier.Enabled = false;
                btSupprimerLigne.Enabled = false;
                btArchiver.Enabled = false;
                btValider.Enabled = false;
                return;
            }
            viewLigne.OptionsView.ShowAutoFilterRow = !declaration.Cloturer;
            viewLigne.OptionsView.ShowGroupPanel = !declaration.Cloturer;
            viewLigne.OptionsCustomization.AllowSort = !declaration.Cloturer;
            viewLigne.OptionsBehavior.Editable = !declaration.Cloturer;
            viewLigne.OptionsCustomization.AllowGroup = !declaration.Cloturer;
            viewLigne.OptionsView.NewItemRowPosition = declaration.Cloturer
                ? NewItemRowPosition.None
                : NewItemRowPosition.Top;
            txtMotif.Properties.ReadOnly = declaration.Cloturer;
            txtReference.Properties.ReadOnly = declaration.Cloturer;
            //_colNumeroOrdre.Visible = declaration.Cloturer;
            btImportSage.Enabled = !declaration.Cloturer;
            btImporter.Enabled = !declaration.Cloturer;
            viewLigne.ExpandAllGroups();
            btValider.Enabled = true;
            if (declaration.Cloturer)
            {
                btLSupprimer.Enabled = false;
                btGenererFichier.Enabled = true;
                btSupprimerLigne.Enabled = false;
                btArchiver.Enabled = true;
            }
            else
            {
                btLSupprimer.Enabled = true;
                btGenererFichier.Enabled = false;
                btSupprimerLigne.Enabled = true;

                btArchiver.Enabled = false;
            }

            if (declaration.Archiver)
            {
                btArchiver.Enabled = false;
                btValider.Enabled = false;
            }
            foreach (object col in viewLigne.Columns)
            {
                var column = col as GridColumn;
                if (column == null) continue;
                column.OptionsColumn.AllowEdit = !declaration.Cloturer;
            }

            _currentDeclaration = declaration;
            btValider.Text = declaration.Cloturer ? "Editer" : "Valider";

            var lignes = _controller.GetAllLigne(_currentDeclaration.Id);
            _listLignes = new BindingList<LigneView>(lignes);
            gridLigne.DataSource = null;
            gridLigne.DataSource = _listLignes;
            viewLigne.ExpandAllGroups();
            if (declaration.Cloturer)
            {
                txtTotal.Text = string.Format("{0:0.000}", _listLignes.Sum(x => x.NetAPaye));
            }
            else
            {
                txtTotal.Text = @"0.000";
            }
            txtDate.Text = string.Format("{0:dd/MM/yyyy}", _currentDeclaration.DateCreation);
            txtMotif.EditValue = declaration.MotifOperation;
            txtReference.EditValue = declaration.ReferenceEnvoi;
        }

        public void Archiver(object sender, EventArgs e)
        {
            try
            {
                var declaration = viewDeclaration.GetFocusedRow() as DeclarationView;
                if (declaration == null) return;
                if (!declaration.Cloturer)
                    throw new ApplicationException("Opération invalide! [Virement est validé]");

                var result =
                    XtraMessageBox.Show(
                        string.Format("Voulez vous archiver la virement?"),
                        Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;

                _controller.Archiver(_currentDeclaration);
                _currentDeclaration = _controller.GetDeclaration(_currentDeclaration.Id);
                var indexOld = _collection.IndexOf(declaration);
                _collection[indexOld] = _currentDeclaration;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void btDeleteR(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            (this.gridLigne.MainView
                as GridView).DeleteSelectedRows();
            var lignesNo = viewLigne.GetSelectedRows();
            //if (!lignesNo.Any()) return;
            //var message = string.Format("Voulez vous vraiment supprimer cette ligne de l'{0} ?", Text);
            //var result = XtraMessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question);
            //if (result != DialogResult.Yes) return;

            //// get ligne
            //foreach (var no in lignesNo)
            //{
            //    var ligne = viewLigne.GetRow(no) as ILigneImportRepository;
            //    if (ligne == null) return;

            //    // suppression de la ligne
            //    _controller.Delete((TL)ligne);
            //}
            
            //RefreshDataSource();
        }
        public void ImporterSage(object sender, EventArgs e)
        {
            try
            {
                if (_currentDeclaration == null) return;
                if (_currentDeclaration.Cloturer)
                    throw new ApplicationException("Opération invalide! [Virement est validé]");
                var ligne = viewDeclaration.GetFocusedRow() as DeclarationView;
                if (ligne == null) return;
                ligne.CodeEtab = null;
                var f= new ImportsSql.FrmImportSqlVirement(_controller.GetSociete());
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    ligne.CodeEtab = f.CurrentEtablissement;
                } else return;
                _controller.ImportSageDeclaration(ligne);
                var focusedHandle = viewDeclaration.FocusedRowHandle;
                _collection = new BindingList<DeclarationView>(_controller.GetAll().ToList());
                gridDeclaration.DataSource = _collection;
                viewDeclaration.FocusedRowHandle = focusedHandle;
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
                if (_currentDeclaration.Cloturer)
                    throw new ApplicationException("Opération invalide! [Virement est validé]");
                var ligne = viewDeclaration.GetFocusedRow() as DeclarationView;
                if (ligne == null) return;

                var form = ConfigProgram.Kernel.Get<FrmImportDeclaration>();

                form.InitialController(_currentDeclaration.Id);
                var focusedHandle = viewDeclaration.FocusedRowHandle;
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

        private void Invalide(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        public void Valider(object sender, ValidateRowEventArgs e)
        {
            var regexInt = new Regex(@"^\d+$");
            // clear columns errors
            viewLigne.ClearColumnErrors();
            // get selected ligne
            var ligne = e.Row as LigneView;
            if (ligne == null)
            {
                e.Valid = false;
                return;
            }
            ////******* verify Matricule ***************
            if (string.IsNullOrEmpty(ligne.Matricule))
            {
                viewLigne.SetColumnError(_colMatricule, "Matricule invalide!");
                e.Valid = false;
                return;
            }   
            ////******* verify Nom ***************
            if (string.IsNullOrEmpty(ligne.Nom))
            {
                viewLigne.SetColumnError(_colNom, "Nom invalide!");
                e.Valid = false;
                return;
            }    
            ////******* verify Prenom ***************
            if (string.IsNullOrEmpty(ligne.Prenom))
            {
                viewLigne.SetColumnError(_colPrenom, "Prénom invalide!");
                e.Valid = false;
                return;
            }    
            
            ////******* verify nom de la banque ***************
            if (string.IsNullOrEmpty(ligne.NomBanque))
            {
                viewLigne.SetColumnError(_colNomBanque, "Nom de la banque invalide!");
                e.Valid = false;
                return;
            }  
            ////******* verify code de la banque ***************
            if (string.IsNullOrEmpty(ligne.CodeBanque) || !regexInt.IsMatch(ligne.CodeBanque.Trim()))
            {
                viewLigne.SetColumnError(_colCodeBanque, "Code invalide!");
                e.Valid = false;
                return;
            }   
         
            ////******* verify code de la quichet banque ***************
            if (string.IsNullOrEmpty(ligne.CodeGuichet) || !regexInt.IsMatch(ligne.CodeGuichet.Trim()))
            {
                viewLigne.SetColumnError(_colCodeGuichet, "Code guichet invalide!");
                e.Valid = false;
                return;
            }    ////******* verify numero compte  banque ***************
            if (string.IsNullOrEmpty(ligne.NumeroCompte) || !regexInt.IsMatch(ligne.NumeroCompte.Trim()))
            {
                viewLigne.SetColumnError(_colNumeroCompte, "Numero compte invalide!");
                e.Valid = false;
                return;
            }    ////******* verify clé de la banque ***************
            if (string.IsNullOrEmpty(ligne.CleRib) || !regexInt.IsMatch(ligne.CleRib.Trim()))
            {
                viewLigne.SetColumnError(_colCleRib, "Clé invalide!");
                e.Valid = false;
                return;
            }
            // var cle = NumeriqueHelper.GetMatriculeCleRib(string.Format(@"{0}{1}{2}", ligne.CodeBanque.PadLeft(2, '0'), ligne.CodeGuichet.PadLeft(6, '0'), ligne.NumeroCompte.PadLeft(10, '0')));
            //if (cle != ligne.CleRib.Trim().PadLeft(2, '0'))
            //{
            //    viewLigne.SetColumnError(_colCleRib, "Calcul de la clé est invalide!");
            //    e.Valid = false;
            //    return;
            //}
            ////******* verify Net a paye ***************
            if (ligne.NetAPaye <= 0)
            {
                viewLigne.SetColumnError(_colNetAPaye, "Montant invalide!");
                e.Valid = false;
                return;
            }
          
            try
            {
                if (ligne.Id == 0)
                {
                    // ajouter ligne bon de commande en suspension
                    var newView = _controller.CreateLigne(ligne, _currentDeclaration);
                    // refresh
                    var indexLigne = _listLignes.IndexOf(ligne);
                    if (indexLigne < 0) return;
                    _listLignes[indexLigne] = newView;
                    return;
                }
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
        private void Personnaliser(object sender, EventArgs e)
        {
            var xx = new FrmReportDesigner(new CompositionContainer(new AssemblyCatalog(Assembly.GetAssembly(typeof(Societe)))));
            xx.Show();
        }
        private void Imprimer(object sender, EventArgs e)
        {

            var ligne = viewDeclaration.GetFocusedRow() as DeclarationView;
            if (ligne == null) return;
            _controller.Imprimer(ligne);
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
                Separator = ";",
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
                    Application = @"Virement",
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

        private void UpdateDeclaration(object sender, KeyEventArgs e)
        {
            if(e.KeyCode != Keys.Enter)
                return;
            var declaration = viewDeclaration.GetFocusedRow() as DeclarationView;
            if (declaration == null)
                return;
            _controller.UpdateDeclaration(declaration.Id , txtMotif.Text , txtReference.Text);
            declaration.MotifOperation = txtMotif.Text;
            declaration.ReferenceEnvoi = txtReference.Text;}

        private void FrmListDeclaration_Load(object sender, EventArgs e)
        {

        }

        private void btImporter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {

        }

        private void btnExporterPdf_Click(object sender, EventArgs e)
        {

        }

        private void btnExporterExcel_Click(object sender, EventArgs e)
        {

        }
    }
}