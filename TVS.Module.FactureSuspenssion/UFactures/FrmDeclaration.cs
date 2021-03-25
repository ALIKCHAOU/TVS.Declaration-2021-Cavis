using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TVS.Module.FactureSuspenssion.UFactures.Controller;
using TVS.Module.FactureSuspenssion.UFactures.Views;

namespace TVS.Module.FactureSuspenssion.UFactures
{
    public partial class FrmDeclaration : XtraForm
    {
        private readonly DeclarationController _controller;
        private DeclarationView _declaration;

        private FrmDeclaration()
        {
            InitializeComponent();
        }

        public FrmDeclaration(DeclarationController controller)
            : this()
        {
            _controller = controller;
            InitErrorProvider();
            BindingSouce();
            btValider.Click += Valider;
            btAnnuler.Click += (sender, args) => Close();
        }

        // Binding source mode de reglement.
        private void BindingSouce()
        {
            // currentView ne doit pas etre null (binding)
            _declaration = _declaration ?? _controller.InitDeclaration();

            txtExercice.DataBindings.Clear();
            txtExercice.DataBindings.Add("EditValue", _declaration, "Annee", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtSociete.DataBindings.Clear();
            txtSociete.DataBindings.Add("EditValue", _declaration, "Societe", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            //cbType.DataBindings.Clear();
            //cbType.DataBindings.Add("Checked", _declaration, "Complementaire", true,
            //    DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            cbTrimestre.DataBindings.Clear();
            cbTrimestre.DataBindings.Add("EditValue", _declaration, "Trimestre", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            dxErrorProvider.DataSource = null;
        }

        public void Valider(object sender, EventArgs e)
        {
            try
            {
                _controller.CreateDeclaration(_declaration);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // initalisation des erreurProvider
        private void InitErrorProvider()
        {
            txtSociete.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtExercice.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            cbTrimestre.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            // cbType.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
        }
    }
}