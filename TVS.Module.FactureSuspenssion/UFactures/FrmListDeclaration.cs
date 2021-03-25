using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
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
using TVS.Core.Enums;
using TVS.Module.FactureSuspenssion.Imports;
using TVS.Module.FactureSuspenssion.UFactures.Controller;
using TVS.Module.FactureSuspenssion.UFactures.Views;

namespace TVS.Module.FactureSuspenssion.UFactures
{
    public partial class FrmListDeclaration : RibbonForm
    {
        private readonly DeclarationController _controller;
        private GridColumn _colNumeroAutorisation;
        private GridColumn _colNumeroFacture;
        private GridColumn _colDateFacture;
        private GridColumn _colIdentifiant;
        private GridColumn _colTypeIdentifiantClient;
        private GridColumn _colRaisonSocialClient;
        private GridColumn _colAdresseClient;
        private GridColumn _colDateAutorisation;
        private GridColumn _colPrixVenteHt;
        private GridColumn _colTauxFodec;
        private GridColumn _colMontantFodec;
        private GridColumn _colTauxDroitConsommation;
        private GridColumn _colMontantDroitConsommation;
        private GridColumn _colTauxTva;
        private GridColumn _colMontantTva;
        private GridColumn _colNumeroOrdre;
        private BindingList<DeclarationView> _collection;
        private DeclarationView _currentDeclaration;
        private BindingList<LigneView> _listLignes;

        private FrmListDeclaration()
        {
            InitializeComponent();
            btNouveau.Click += Nouveau;
            btValider.Click += Generer;
            btSupprimerLigne.ItemClick += SupprimerLigne;
            btnGenererFichier.Click += Exporter;
            btLSupprimer.Click += SupprimerDeclaration;
            btArchiver.Click += Archiver;
            btImporter.ItemClick += Importer;
            btLSupprimer.Enabled = false;
            btnGenererFichier.Enabled = false;
            btSupprimerLigne.Enabled = false;
            btArchiver.Enabled = false;
            btValider.Enabled = false;
            btImporter.Enabled = false;

            viewLigne.InitNewRow += LigneInitNewRow;
            btnExporterCsv.Click += ExportToCsv;
            btnExporterExcel.Click += ExportToExcel;
            btnExporterPdf.Click += ExportToPdf;
        }

        private void LigneInitNewRow(object sender, InitNewRowEventArgs e)
        {
            var ligne = viewLigne.GetFocusedRow() as LigneView;
            if (ligne == null) return;
            ligne.DateAutorisation = DateTime.Now;
            ligne.DateFacture = DateTime.Now;
            ligne.NumeroAutorisation = string.Empty;
            ligne.NumeroFacture = string.Empty;
            ligne.IdentifiantClient = string.Empty;
            ligne.NomPrenomClient = string.Empty;
            ligne.AdresseClient = string.Empty;
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
                if (declaration.IsCloture)
                {
                    if (declaration.IsArchive)
                        throw new InvalidOperationException("Impossible d'editer une déclaration archiver");
                    var result =
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
                if (form.ShowDialog() != DialogResult.OK) return;
                var declarations = _controller.GetAll().ToList();
                _collection = new BindingList<DeclarationView>(declarations);
                gridDeclaration.DataSource = _collection;
                viewDeclaration.FocusedRowHandle = declarations.Count - 1;
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
                        string.Format("Voulez vous supprimer Facture N°[{0}]?", ligne.NumeroFacture),
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

        private void FocusedRowChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            var declaration = viewDeclaration.GetFocusedRow() as DeclarationView;
            if (declaration == null)
            {
                txtTrimestre.Text = string.Empty;
                txtDate.Text = string.Empty;
                btLSupprimer.Enabled = false;
                btnGenererFichier.Enabled = false;
                btSupprimerLigne.Enabled = false;
                btArchiver.Enabled = false;
                btValider.Enabled = false;
                return;
            }
            viewLigne.OptionsView.ShowAutoFilterRow = !declaration.IsCloture;
            viewLigne.OptionsView.ShowGroupPanel = !declaration.IsCloture;
            viewLigne.OptionsCustomization.AllowSort = !declaration.IsCloture;
            viewLigne.OptionsBehavior.Editable = !declaration.IsCloture;
            viewLigne.OptionsCustomization.AllowGroup = !declaration.IsCloture;
            viewLigne.OptionsView.NewItemRowPosition = declaration.IsCloture
                ? NewItemRowPosition.None
                : NewItemRowPosition.Top;

            _colNumeroOrdre.Visible = declaration.IsCloture;

            btImporter.Enabled = !declaration.IsCloture;
            viewLigne.ExpandAllGroups();
            btValider.Enabled = true;
            if (declaration.IsCloture)
            {
                btLSupprimer.Enabled = false;
                btnGenererFichier.Enabled = true;
                btSupprimerLigne.Enabled = false;
                btArchiver.Enabled = true;
            }
            else
            {
                btLSupprimer.Enabled = true;
                btnGenererFichier.Enabled = false;
                btSupprimerLigne.Enabled = true;

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

            _currentDeclaration = declaration;
            btValider.Text = declaration.IsCloture ? "Editer" : "Valider";

            var lignes = _controller.GetAllLigne(_currentDeclaration.Id);
            _listLignes = new BindingList<LigneView>(lignes);
            gridLigne.DataSource = null;
            gridLigne.DataSource = _listLignes;
            viewLigne.ExpandAllGroups();
            if (declaration.IsCloture)
            {
                txtTotalPrixVenteHorsTaxe.Text = string.Format("{0:0.000}", _listLignes.Sum(x => x.PrixVenteHt));
                txtMontantTva.Text = string.Format("{0:0.000}", _listLignes.Sum(x => x.MontantTva));
                txtMontantConsommation.Text = string.Format("{0:0.000}",
                    _listLignes.Sum(x => x.MontantDroitConsommation));
                txtMontantFodec.Text = string.Format("{0:0.000}", _listLignes.Sum(x => x.MontantFodec));
            }
            else
            {
                txtTotalPrixVenteHorsTaxe.Text = @"0.000";
                txtMontantTva.Text = @"0.000";
                txtMontantConsommation.Text = @"0.000";
                txtMontantFodec.Text = @"0.000";
            }
            txtTrimestre.Text = string.Format("{0:0}", _currentDeclaration.Trimestre);
            txtDate.Text = string.Format("{0:dd/MM/yyyy}", _currentDeclaration.Date);
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

        private void Invalide(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        public void Valider(object sender, ValidateRowEventArgs e)
        {
            // clear columns errors
            viewLigne.ClearColumnErrors();
            // current row
            var ligne = e.Row as LigneView;
            if (ligne == null)
            {
                e.Valid = false;
                return;
            }
            //******* Verify Numero facture ***********
            if (string.IsNullOrEmpty(ligne.NumeroFacture.Trim()) ||
                ligne.NumeroFacture.Length > 20)
            {
                viewLigne.SetColumnError(_colNumeroFacture, "Numéro facture invalide!");

                e.Valid = false;
                return;
            }
            // charger l'exercice
            var exercice = _controller.GetCurrentExercice();
            int annee;
            if (!int.TryParse(exercice.Annee, out annee))
                throw new ApplicationException("Exercice invalide!");
            // verifier que la date du facture est unclue dans le trimestre declarée
            switch (_currentDeclaration.Trimestre)
            {
                case 1:
                    var dateDebutT1 = new DateTime(annee, 1, 1);
                    var dateFinT1 = new DateTime(annee, 3, 31);
                    if (ligne.DateFacture.Date < dateDebutT1 || ligne.DateFacture.Date > dateFinT1)
                    {
                        viewLigne.SetColumnError(_colDateFacture,
                            "La date facture doit être inclue dans la premiére trimestre!");
                        e.Valid = false;
                        return;
                    }
                    break;
                case 2:
                    var dateDebutT2 = new DateTime(annee, 4, 1);
                    var dateFinT2 = new DateTime(annee, 6, 30);
                    if (ligne.DateFacture.Date < dateDebutT2 || ligne.DateFacture.Date > dateFinT2)
                    {
                        viewLigne.SetColumnError(_colDateFacture,
                            "La date facture doit être inclue dans la deuxiéme trimestre!");
                        e.Valid = false;
                        return;
                    }
                    break;
                case 3:
                    var dateDebutT3 = new DateTime(annee, 7, 1);
                    var dateFinT3 = new DateTime(annee, 9, 30);
                    if (ligne.DateFacture.Date < dateDebutT3 || ligne.DateFacture.Date > dateFinT3)
                    {
                        viewLigne.SetColumnError(_colDateFacture,
                            "La date facture doit être inclue dans la troisiéme trimestre!");
                        e.Valid = false;
                        return;
                    }
                    break;
                case 4:
                    var dateDebutT4 = new DateTime(annee, 10, 1);
                    var dateFinT4 = new DateTime(annee, 12, 31);
                    if (ligne.DateFacture.Date < dateDebutT4 || ligne.DateFacture.Date > dateFinT4)
                    {
                        viewLigne.SetColumnError(_colDateFacture,
                            "La date facture doit être inclue dans la quatriéme trimestre!");
                        e.Valid = false;
                        return;
                    }
                    break;
                default:
                    throw new InvalidOperationException("Trimestre invalide!");
            }

            //******* Verify identifiant ***********
            switch (ligne.TypeClient)
            {
                case TypeClient.MatriculeFiscal:
                    // verifier le matricule fiscal du client
                    if (ligne.IdentifiantClient.Length != 13)
                    {
                        viewLigne.SetColumnError(_colIdentifiant, "Identifiant client invalide!");
                        e.Valid = false;
                        return;
                    }
                    break;

                case TypeClient.CarteSejour:
                    // verifier le numero du carte de sejour du client
                    if (ligne.IdentifiantClient.Length != 10)
                    {
                        viewLigne.SetColumnError(_colIdentifiant, "Identifiant client invalide!");
                        e.Valid = false;
                        return;
                    }
                    break;

                case TypeClient.Cin:
                    // verifier le numero du CIN du client
                    if (ligne.IdentifiantClient.Length != 8)
                    {
                        viewLigne.SetColumnError(_colIdentifiant, "Identifiant client invalide!");
                        e.Valid = false;
                        return;
                    }
                    break;

                case TypeClient.NonDomiciliee:
                    // verifier le numero du client non domiciliée ni établie
                    if (ligne.IdentifiantClient.Length == 0 || ligne.IdentifiantClient.Length > 13)
                    {
                        viewLigne.SetColumnError(_colIdentifiant, "Identifiant client invalide!");
                        e.Valid = false;
                        return;
                    }
                    break;
                default:
                    viewLigne.SetColumnError(_colTypeIdentifiantClient, "Type identifiant client invalide!");
                    e.Valid = false;
                    return;
            }
            if (string.IsNullOrEmpty(ligne.IdentifiantClient.Trim()) ||
                ligne.IdentifiantClient.Length > 13)
            {
                viewLigne.SetColumnError(_colIdentifiant, "Identifiant client invalide!");
                e.Valid = false;
                return;
            }
            //******* Verify nom prenom du client
            if (string.IsNullOrEmpty(ligne.NomPrenomClient.Trim()) ||
                ligne.NomPrenomClient.Length > 40)
            {
                viewLigne.SetColumnError(_colRaisonSocialClient, "Nom et prénom du client invalide!");
                e.Valid = false;
                return;
            }
            //******* Verify Numero bon de commande ***********
            if (string.IsNullOrEmpty(ligne.AdresseClient.Trim()) ||
                ligne.AdresseClient.Length > 120)
            {
                viewLigne.SetColumnError(_colAdresseClient, "Adresse client in invalide!");
                e.Valid = false;
                return;
            }
            //******* Verify numero autorisation
            if (string.IsNullOrEmpty(ligne.NumeroAutorisation.Trim()) ||
                ligne.NumeroAutorisation.Length > 20)
            {
                viewLigne.SetColumnError(_colNumeroAutorisation, "Numéro autorisation invalide!");
                e.Valid = false;
                return;
            }
            //******* Verify Prix vente hors taxe  ********
            if (ligne.PrixVenteHt < 0)
            {
                viewLigne.SetColumnError(_colPrixVenteHt, "Prix de vente hors taxe invalide!");
                e.Valid = false;
                return;
            }
            //******* Verify taux FODEC
            if (ligne.TauxFodec < 0 || ligne.TauxFodec > 1)
            {
                viewLigne.SetColumnError(_colTauxFodec, "Taux fodec invalide!");
                e.Valid = false;
                return;
            }
            //****** Verify montant FODEC
            if (ligne.MontantFodec < 0)
            {
                viewLigne.SetColumnError(_colMontantTva, "Montant fodec invalide!");
                e.Valid = false;
                return;
            }
            //******* Verify taux droit de consommation
            if (ligne.TauxDroitConsommation < 0 || ligne.TauxDroitConsommation > 1)
            {
                viewLigne.SetColumnError(_colTauxDroitConsommation, "Taux droit de consommation invalide!");
                e.Valid = false;
                return;
            }
            //******* Verify montant droit de consommation
            if (ligne.MontantDroitConsommation < 0)
            {
                viewLigne.SetColumnError(_colMontantDroitConsommation, "Montant droit de consommation invalide!");
                e.Valid = false;
                return;
            }
            //******* Verify taux TVA
            if (ligne.TauxTva < 0 || ligne.TauxTva > 1)
            {
                viewLigne.SetColumnError(_colTauxTva, "Taux Tva invalide!");
                e.Valid = false;
                return;
            }
            //******* Verify montant TVA  ********
            if (ligne.MontantTva < 0)
            {
                viewLigne.SetColumnError(_colMontantTva, "Montant Tva invalide!");
                e.Valid = false;
                return;
            }

            try
            {
                // add ligne
                if (ligne.Id == 0)
                {
                    // create ligne
                    var newView = _controller.AjouterLigne(ligne, _currentDeclaration);
                    // refresh
                    var indexLigne = _listLignes.IndexOf(ligne);
                    if (indexLigne < 0) return;
                    _listLignes[indexLigne] = newView;
                    return;
                }
                // update ligne
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
                    Application = @"Déclaration Facture en suspension",
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

        
    }
}