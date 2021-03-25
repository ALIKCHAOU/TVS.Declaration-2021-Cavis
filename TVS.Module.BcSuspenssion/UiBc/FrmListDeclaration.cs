using System;
using System.Collections.Generic;
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
using TVS.Module.BcSuspenssion.Imports;
using TVS.Module.BcSuspenssion.UiBc.Controller;
using TVS.Module.BcSuspenssion.UiBc.Views;

namespace TVS.Module.BcSuspenssion.UiBc
{
    public partial class FrmListDeclaration : RibbonForm
    {
        private readonly DeclarationController _controller;
        private GridColumn _colDateBonCommande;
        private GridColumn _colDateFacture;
        private GridColumn _colIdentifiant;
        private GridColumn _colMontantTva;
        private GridColumn _colNumeroAutorisation;
        private GridColumn _colNumeroBonCommande;
        private GridColumn _colNumeroFacture;
        private GridColumn _colNumeroOrdre;
        private GridColumn _colObjetFacture;
        private GridColumn _colPrixAchatHorsTaxe;
        private GridColumn _colRaisonSocialFournisseur;
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

            btArchiver.Click += Archiver;
            btImporter.ItemClick += Importer;
            btLSupprimer.Enabled = false;
            btGenererFichier.Enabled = false;
            btSupprimerLigne.Enabled = false;
            btArchiver.Enabled = false;
            btValider.Enabled = false;
            btImporter.Enabled = false;

            btnExporterCsv.Click += ExportToCsv;
            btnExporterExcel.Click += ExportToExcel;
            btnExporterPdf.Click += ExportToPdf;
        }

        private void LigneInitNewRow(object sender, InitNewRowEventArgs e)
        {
            // get new ligne
            var ligne = viewLigne.GetFocusedRow() as LigneView;
            if (ligne == null) return;
            // intialise ligne
            ligne.DateBonCommande = DateTime.Now;
            ligne.DateFacture = DateTime.Now;
            ligne.NumeroAutorisation = _currentDeclaration.NumeroAutorisation;
            ligne.NumeroBonCommande = string.Empty;
            ligne.NumeroFacture = string.Empty;
            ligne.Identifiant = string.Empty;
            ligne.RaisonSocialFournisseur = string.Empty;
            ligne.ObjetFacture = string.Empty;
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
                var result =
                    XtraMessageBox.Show(
                        string.Format("Voulez vous supprimer bon commande N°[{0}]?", ligne.NumeroBonCommande),
                        Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
                _controller.Delete(ligne);
                var indexOld = _listLignes.IndexOf(ligne);
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

                var result =
                    XtraMessageBox.Show(
                        string.Format("Voulez vous supprimer la déclaration?"),
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
            var declaration = viewDeclaration.GetFocusedRow() as DeclarationView;
            if (declaration == null)
            {
                txtTrimestre.Text = string.Empty;
                txtDate.Text = string.Empty;
                btLSupprimer.Enabled = false;
                btGenererFichier.Enabled = false;
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
                txtTotalPrixAchatHorsTaxe.Text = string.Format("{0:0.000}", _listLignes.Sum(x => x.PrixAchatHorsTaxe));
                txtMontantTva.Text = string.Format("{0:0.000}", _listLignes.Sum(x => x.MontantTva));
            }
            else
            {
                txtTotalPrixAchatHorsTaxe.Text = @"0.000";
                txtMontantTva.Text = @"0.000";
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

                var result =
                    XtraMessageBox.Show(
                        string.Format("Voulez vous archiver la déclaration?"),
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
            // clear columns errors
            viewLigne.ClearColumnErrors();
            // get selected ligne
            var ligne = e.Row as LigneView;
            if (ligne == null)
            {
                e.Valid = false;
                return;
            }
            //******* Verify Numero autorisation ***********
            if (string.IsNullOrEmpty(ligne.NumeroAutorisation.Trim()) ||
                ligne.NumeroAutorisation.Length > 30)
            {
                viewLigne.SetColumnError(_colNumeroAutorisation, "Numéro autorisation invalide!");
                e.Valid = false;
                return;
            }
            //******* Verify Numero bon de commande ***********
            if (string.IsNullOrEmpty(ligne.NumeroBonCommande.Trim()) ||
                ligne.NumeroBonCommande.Length > 13)
            {
                viewLigne.SetColumnError(_colNumeroBonCommande, "Numéro bon de commande invalide!");
                e.Valid = false;
                return;
            }
            // charger l'exercice
            var exercice = _controller.GetCurrentExercice();
            int annee;
            if (!int.TryParse(exercice.Annee, out annee))
                throw new ApplicationException("Exercice invalide!");
            // verifier que la date du bon de commande est unclue dans le trimestre declarée
            switch (_currentDeclaration.Trimestre)
            {
                case 1:
                    var dateDebutT1 = new DateTime(annee, 1, 1);
                    var dateFinT1 = new DateTime(annee, 3, 31);
                    if (ligne.DateBonCommande.Date < dateDebutT1 || ligne.DateBonCommande.Date > dateFinT1)
                    {
                        viewLigne.SetColumnError(_colDateBonCommande,
                            "La date du bon de commande doit être inclue dans la premiére trimestre!");
                        e.Valid = false;
                        return;
                    }
                    break;

                case 2:
                    var dateDebutT2 = new DateTime(annee, 4, 1);
                    var dateFinT2 = new DateTime(annee, 6, 30);
                    if (ligne.DateBonCommande.Date < dateDebutT2 || ligne.DateBonCommande.Date > dateFinT2)
                    {
                        viewLigne.SetColumnError(_colDateBonCommande,
                            "La date du bon de commande doit être inclue dans la deuxiéme trimestre!");
                        e.Valid = false;
                        return;
                    }
                    break;

                case 3:
                    var dateDebutT3 = new DateTime(annee, 7, 1);
                    var dateFinT3 = new DateTime(annee, 9, 30);
                    if (ligne.DateBonCommande.Date < dateDebutT3 || ligne.DateBonCommande.Date > dateFinT3)
                    {
                        viewLigne.SetColumnError(_colDateBonCommande,
                            "La date du bon de commande doit être inclue dans la troisiéme trimestre!");
                        e.Valid = false;
                        return;
                    }
                    break;

                case 4:
                    var dateDebutT4 = new DateTime(annee, 10, 1);
                    var dateFinT4 = new DateTime(annee, 12, 31);
                    if (ligne.DateBonCommande.Date < dateDebutT4 || ligne.DateBonCommande.Date > dateFinT4)
                    {
                        viewLigne.SetColumnError(_colDateBonCommande,
                            "La date du bon de commande doit être inclue dans la quatriéme trimestre!");
                        e.Valid = false;
                        return;
                    }
                    break;

                default:
                    throw new InvalidOperationException("Trimestre invalide!");
            }
            //******* Verify Numero identifiant ***********
            if (string.IsNullOrEmpty(ligne.Identifiant.Trim()) ||
                ligne.Identifiant.Length != 13)
            {
                viewLigne.SetColumnError(_colIdentifiant, "Identifiant invalide!");
                e.Valid = false;
                return;
            }
            //******* Verify nom prenom au raison sociale du fournisseur ***********
            if (string.IsNullOrEmpty(ligne.RaisonSocialFournisseur.Trim()) || ligne.RaisonSocialFournisseur.Length > 40)
            {
                viewLigne.SetColumnError(_colRaisonSocialFournisseur,
                    "Nom prénom ou raison social fournisseur invalide!");
                e.Valid = false;
                return;
            }
            //******* Verify Numero facture ***********
            if (string.IsNullOrEmpty(ligne.NumeroFacture.Trim()) ||
                ligne.NumeroFacture.Length > 30)
            {
                viewLigne.SetColumnError(_colNumeroFacture, "Numéro facture invalide!");

                e.Valid = false;
                return;
            }
            // verifier que la date bon commande est inferieur au date facture
            if (ligne.DateFacture.Date < ligne.DateBonCommande.Date)
            {
                viewLigne.SetColumnError(_colDateFacture,
                    "La date du bon de commande doit être inférieur au date facture!");
                e.Valid = false;
                return;
            }
            //******* Verify Prix achat hors taxe  ********
            if (ligne.PrixAchatHorsTaxe < 0)
            {
                viewLigne.SetColumnError(_colPrixAchatHorsTaxe, "Prix d'achat hors taxe invalide!");
                e.Valid = false;
                return;
            }
            //******* Verify montant tva  ********
            if (ligne.MontantTva < 0)
            {
                viewLigne.SetColumnError(_colMontantTva, "Montant invalide!");
                e.Valid = false;
                return;
            }
            //******* Verify objet facture***********
            if (string.IsNullOrEmpty(ligne.ObjetFacture.Trim()) ||
                ligne.ObjetFacture.Length > 320)
            {
                viewLigne.SetColumnError(_colObjetFacture, "Objet facture invalide!");
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
                    Application = @"Déclaration BC en suspension",
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