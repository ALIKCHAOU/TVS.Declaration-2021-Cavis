using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraSplashScreen;
using TVS.Config;
using TVS.Module.Cnss.Imports.Controller;
using TVS.Module.Cnss.Imports.Views;
using TVS.Module.Cnss.ImportsSql;
using TVS.Module.Cnss.ImportsSql.Controller;
using TVS.Module.Cnss.ImportsSql.Views;

namespace TVS.Module.Cnss.Imports
{
    public partial class FrmImportSqlDeclaration : XtraForm
    {
        private readonly DeclarationSqlController _controller;
        private readonly IUserControlFactory _ucFactory;
        private UcImportSqlDeclaration _entetDeclaration;
        private UcLignesSqlImport _ucLigneDeclaration;

        private FrmImportSqlDeclaration()
        {
            InitializeComponent();
        }

        public FrmImportSqlDeclaration(IUserControlFactory ucFactory, DeclarationSqlController controller)
            : this()
        {
            if (ucFactory == null) throw new ArgumentNullException("ucFactory");
            if (controller == null) throw new ArgumentNullException("controller");
            _ucFactory = ucFactory;
            _controller = controller;
        }

        public void InitialController(int declarationId)
        {
            var declaration = _controller.GetDeclaration(declarationId);
            if (declaration == null) throw new InvalidOperationException("Déclaration invalide!");
            _entetDeclaration = _ucFactory.Create<UcImportSqlDeclaration>();
            _ucLigneDeclaration = _ucFactory.Create<UcLignesSqlImport>();
            _entetDeclaration.SetDeclaration(declaration);
            SetCurrentOption(_entetDeclaration);
            _entetDeclaration.btSuivant.Click += SuivantClick;
            _entetDeclaration.btAnnuler.Click += AnnulerClick;
            _ucLigneDeclaration.btImporter.Click += ImportClick;
        }

        private void SetCurrentOption(XtraUserControl option)
        {
            var ctrl = option as Control;
            if (ctrl == null) return;

            // set the the LayoutItemControl Owner (LayoutGroupItem)
            LayoutControlGroup itemOwner = lciLayout;
            itemOwner.BeginUpdate();
            try
            {
                // remove the current LayoutItemControl
                if (lciLayout.Items.Count > 0)
                {
                    var item = itemOwner.Items[0] as LayoutControlItem;
                    if (item != null)
                    {
                        Control control = item.Control;
                        if (control != null)
                        {
                            control.Parent = null;
                        }
                        item.Dispose();
                    }
                }

                // add the new LayoutItemControl
                itemOwner.AddItem(string.Empty, ctrl).TextVisible = false;
            }
            finally
            {
                itemOwner.EndUpdate();
            }
        }

        private void AnnulerClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void SuivantClick(object sender, EventArgs e)
        {
            try
            {
                var declaration = _entetDeclaration.Declaration;
                if (declaration == null)
                    throw new InvalidOperationException("Opération invalide!");
                if (!_entetDeclaration.Valider()) return;
                _entetDeclaration.Declaration.Lignes =
                    new BindingList<LigneSqlView>(
                        _controller.GetLigne(
                            int.Parse(declaration.Exercice),
                            declaration.Trimestre,
                            declaration.CategorieNo,
                            declaration.Etablissement));

                _ucLigneDeclaration.SetDeclaration(_entetDeclaration.Declaration);

                SetCurrentOption(_ucLigneDeclaration);

                _ucLigneDeclaration.Init();
                //Size = new Size(1100, 600);
                //MinimumSize = new Size(500, 400);
                //Location = new Point(Location.X/2, Location.Y/2);
                //this.StartPosition = FormStartPosition.CenterParent;
                Refresh();

                _ucLigneDeclaration.cbValide.SelectedIndexChanged += _ucLigneDeclaration.ValidIndexChanged;
                _ucLigneDeclaration.cbValide.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportClick(object sender, EventArgs e)
        {
            try
            {
                bool valid = _ucLigneDeclaration.IsValider();
                if (!valid) return;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                SplashScreenManager.ShowForm(typeof(WaitFormDec));
                _controller.Importer(_ucLigneDeclaration.Declaration);
                Close();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SplashScreenManager.CloseForm();
            }
        }
    }
}