using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using TVS.Module.BcSuspenssion.Imports.Controller;
using TVS.Module.BcSuspenssion.Imports.Views;

namespace TVS.Module.BcSuspenssion.Imports
{
    public partial class UcImportDeclaration : XtraUserControl
    {
        private readonly ImportController _controller;

        private UcImportDeclaration()
        {
            InitializeComponent();
        }

        public UcImportDeclaration(ImportController controller)
            : this()
        {
            if (controller == null) throw new ArgumentNullException("controller");
            _controller = controller;
            InitErrorProvider();
        }

        public DeclarationImportView Declaration { get; private set; }

        public void SetDeclaration(DeclarationImportView view)
        {
            if (view == null) throw new ArgumentNullException("view");
            Declaration = view;
            BindingSouce();
        }

        // Binding source mode de reglement.
        private void BindingSouce()
        {
            // currentView ne doit pas etre null (binding)
            Declaration = Declaration ?? _controller.InitDeclaration();

            txtExercice.DataBindings.Clear();
            txtExercice.DataBindings.Add("EditValue", Declaration, "Exercice", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtSociete.DataBindings.Clear();
            txtSociete.DataBindings.Add("EditValue", Declaration, "RaisonSocial", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            cbTrimestre.DataBindings.Clear();
            cbTrimestre.DataBindings.Add("EditValue", Declaration, "Trimestre", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            btPath.DataBindings.Clear();
            btPath.DataBindings.Add("EditValue", Declaration, "Path", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            dxErrorProvider.DataSource = null;
        }

        public bool Valider()
        {
            if (Declaration == null)
                return false;
            if (string.IsNullOrEmpty(Declaration.Path))
            {
                btPath.ErrorText = "Champ obligatoire!";
                btPath.Focus();
                return false;
            }
            return true;
        }

        // initalisation des erreurProvider
        private void InitErrorProvider()
        {
            txtSociete.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtExercice.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            cbTrimestre.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;

            btPath.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
        }

        private void btPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory =
                    Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = @"(*.csv)|*.csv;"
            };

            if (openFileDialog.ShowDialog(this) != DialogResult.OK) return;

            btPath.EditValue = openFileDialog.FileName;
        }
    }
}