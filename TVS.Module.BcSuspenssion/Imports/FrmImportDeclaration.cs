using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraSplashScreen;
using TVS.Config;
using TVS.Module.BcSuspenssion.Imports.Controller;
using TVS.Module.BcSuspenssion.Imports.Views;

namespace TVS.Module.BcSuspenssion.Imports
{
    public partial class FrmImportDeclaration : XtraForm
    {
        private readonly ImportController _controller;
        private readonly IUserControlFactory _ucFactory;
        private UcImportDeclaration _entetDeclaration;
        private UcLignesImport _ucLigneDeclaration;

        private FrmImportDeclaration()
        {
            InitializeComponent();
        }

        public FrmImportDeclaration(IUserControlFactory ucFactory, ImportController controller)
            : this()
        {
            if (ucFactory == null) throw new ArgumentNullException("ucFactory");
            if (controller == null) throw new ArgumentNullException("controller");
            _ucFactory = ucFactory;
            _controller = controller;
        }

        public void InitialController(int declarationId)
        {
            DeclarationImportView declaration = _controller.GetDeclaration(declarationId);
            if (declaration == null) throw new InvalidOperationException("Déclaration invalide!");
            _entetDeclaration = _ucFactory.Create<UcImportDeclaration>();
            _ucLigneDeclaration = _ucFactory.Create<UcLignesImport>();
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
                DeclarationImportView declaration = _entetDeclaration.Declaration;
                if (declaration == null)
                    throw new InvalidOperationException("Opération invalide!");
                if (!_entetDeclaration.Valider()) return;
                _entetDeclaration.Declaration.Lignes =
                    new BindingList<LigneBcSuspendueImportView>(
                        _controller.GetLigne(
                            _entetDeclaration.Declaration.Path,
                            int.Parse(declaration.Exercice),
                            declaration.Trimestre,
                            declaration.CategorieNo));

                _ucLigneDeclaration.SetDeclaration(_entetDeclaration.Declaration);

                SetCurrentOption(_ucLigneDeclaration);

                _ucLigneDeclaration.Init();
                Size = new Size(1100, 600);
                MinimumSize = new Size(500, 400);
                Location = new Point(Location.X/2, Location.Y/2);
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