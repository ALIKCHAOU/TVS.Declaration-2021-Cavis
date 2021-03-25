using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace TVS.Module.Employee.UiAnnexe
{
    public partial class FrmDeclaredAnnexe : XtraForm
    {
        private readonly IsDeclarationEmployeurView _currentView;
        //public IsDeclarationEmployeurView DeclaredAnnexes { get; private set; }

        private FrmDeclaredAnnexe()
        {
            InitializeComponent();
            btnAnnuler.Click += Annuler;
            btnValider.Click += Valider;
            chAnnexeUn.KeyDown += EnterEvent;
            chAnnexeDeux.KeyDown += EnterEvent;
            chAnnexeTrois.KeyDown += EnterEvent;
            chAnnexeQuatre.KeyDown += EnterEvent;
            chAnnexeCinq.KeyDown += EnterEvent;
            chAnnexeSix.KeyDown += EnterEvent;
            chAnnexeSept.KeyDown += EnterEvent;
        }

        public FrmDeclaredAnnexe(IsDeclarationEmployeurView currentView)
            : this()
        {
            if (currentView == null)
                throw new ArgumentNullException(nameof(currentView));

            _currentView = currentView;
            Binding();
        }

        private void Binding()
        {
            if (_currentView == null)
                throw new ArgumentNullException(nameof(_currentView));

            chAnnexeUn.DataBindings.Clear();
            chAnnexeUn.DataBindings.Add("EditValue", _currentView, "IsAnnexeUnDeclared", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            chAnnexeDeux.DataBindings.Clear();
            chAnnexeDeux.DataBindings.Add("EditValue", _currentView, "IsAnnexeDeuxDeclared", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            chAnnexeTrois.DataBindings.Clear();
            chAnnexeTrois.DataBindings.Add("EditValue", _currentView, "IsAnnexeTroisDeclared", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            chAnnexeQuatre.DataBindings.Clear();
            chAnnexeQuatre.DataBindings.Add("EditValue", _currentView, "IsAnnexeQuatreDeclared", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            chAnnexeCinq.DataBindings.Clear();
            chAnnexeCinq.DataBindings.Add("EditValue", _currentView, "IsAnnexeCinqDeclared", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            chAnnexeSix.DataBindings.Clear();
            chAnnexeSix.DataBindings.Add("EditValue", _currentView, "IsAnnexeSixDeclared", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            chAnnexeSept.DataBindings.Clear();
            chAnnexeSept.DataBindings.Add("EditValue", _currentView, "IsAnnexeSeptDeclared", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);
        }

        private void Annuler(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Valider(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            //DeclaredAnnexes = _currentView;
            Close();
        }

        private void EnterEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            Valider(null, null);
        }
    }
}