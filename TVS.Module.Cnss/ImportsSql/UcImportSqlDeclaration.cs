using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using TVS.Module.Cnss.Imports.Controller;
using TVS.Module.Cnss.Imports.Views;
using TVS.Module.Cnss.ImportsSql.Controller;
using TVS.Module.Cnss.ImportsSql.Views;

namespace TVS.Module.Cnss.Imports
{
    public partial class UcImportSqlDeclaration : XtraUserControl
    {
        private readonly DeclarationSqlController _controller;

        private UcImportSqlDeclaration()
        {
            InitializeComponent();
        }

        public UcImportSqlDeclaration(DeclarationSqlController controller)
            : this()
        {
            if (controller == null) throw new ArgumentNullException("controller");
            _controller = controller;
            InitForm();
            InitErrorProvider();
        }

        public DeclarationImportSqlView Declaration { get; private set; }

        public void SetDeclaration(DeclarationImportSqlView view)
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

            cbType.DataBindings.Clear();
            cbType.DataBindings.Add("Checked", Declaration, "Complementaire", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            cbTrimestre.DataBindings.Clear();
            cbTrimestre.DataBindings.Add("EditValue", Declaration, "Trimestre", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            gleCategorie.DataBindings.Clear();
            gleCategorie.DataBindings.Add("EditValue", Declaration, "CategorieNo", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtEtablissement.DataBindings.Clear();
            txtEtablissement.DataBindings.Add("EditValue", Declaration, "Etablissement", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            dxErrorProvider.DataSource = null;
        }

        public bool Valider()
        {
            if (Declaration == null)
                return false;
            //if (string.IsNullOrEmpty(Declaration.Etablissement))
            //{
            //    txtEtablissement.ErrorText = "Champ obligatoire!";
            //    txtEtablissement.Focus();
            //    return false;
            //}
            return true;
        }

        // initalisation des erreurProvider
        private void InitErrorProvider()
        {
            txtSociete.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtExercice.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            cbTrimestre.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            cbType.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtEtablissement.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
        }

        private void InitForm()
        {
            var categories = new List<CategorieView>
            {
                //new CategorieView
                //{
                //    Id = -1,
                //    Intitule = "<Toutes>"
                //}
            };
            categories.AddRange(_controller.GetAllCategories().ToList());
            gleCategorie.Properties.DisplayMember = "Intitule";
            gleCategorie.Properties.ValueMember = "Id";
            gleCategorie.Properties.View.Columns.Add(new GridColumn
            {
                Caption = "Initulé",
                FieldName = "Intitule",
                Visible = true
            });
            gleCategorie.Properties.DataSource = categories;
            gleCategorie.Properties.ImmediatePopup = true;
            gleCategorie.Properties.View.OptionsView.ShowColumnHeaders = false;
            gleCategorie.Properties.ShowFooter = false;
            gleCategorie.Properties.View.OptionsView.ShowIndicator = false;
            gleCategorie.Properties.PopupFormSize = new Size(30, 30);


            txtEtablissement.Properties.DisplayMember = "Intitule";
            txtEtablissement.Properties.ValueMember = "Id";
            txtEtablissement.Properties.View.Columns.Add(new GridColumn
            {
                Caption = "Initulé",
                FieldName = "Intitule",
                Visible = true
            });
            txtEtablissement.Properties.DataSource = _controller.GetEtb();
            txtEtablissement.Properties.ImmediatePopup = true;
            txtEtablissement.Properties.View.OptionsView.ShowColumnHeaders = false;
            txtEtablissement.Properties.ShowFooter = false;
            txtEtablissement.Properties.View.OptionsView.ShowIndicator = false;
            txtEtablissement.Properties.PopupFormSize = new Size(30, 30);

        }

        private void btSuivant_Click(object sender, EventArgs e)
        {

        }
    }
}