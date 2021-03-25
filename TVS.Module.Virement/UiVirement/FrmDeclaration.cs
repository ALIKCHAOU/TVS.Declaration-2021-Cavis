using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using TVS.Core.Models;
using TVS.Module.Virement.UiVirement.Controller;
using TVS.Module.Virement.UiVirement.Views;

namespace TVS.Module.Virement.UiVirement
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
            InitForm();
            gleBanque.EditValueChanged += BanqueChanged;
        }

        // Binding source mode de reglement.
        private void BindingSouce()
        {
            // currentView ne doit pas etre null (binding)
            _declaration = _declaration ?? _controller.InitDeclaration();

            txtExercice.DataBindings.Clear();
            txtExercice.DataBindings.Add("EditValue", _declaration, "Exercice", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtSociete.DataBindings.Clear();
            txtSociete.DataBindings.Add("EditValue", _declaration, "RaisonSocial", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);


            dtEcheance.DataBindings.Clear();
            dtEcheance.DataBindings.Add("EditValue", _declaration, "DateEcheance", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtReferenceEnvoi.DataBindings.Clear();
            txtReferenceEnvoi.DataBindings.Add("EditValue", _declaration, "ReferenceEnvoi", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            gleBanque.DataBindings.Clear();
            gleBanque.DataBindings.Add("EditValue", _declaration, "BanqueId", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtMotif.DataBindings.Clear();
            txtMotif.DataBindings.Add("EditValue", _declaration, "MotifOperation", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            dxErrorProvider.DataSource = null;
        }

        public void BanqueChanged(object sender, EventArgs e)
        {
            var obj = gleBanque.GetSelectedDataRow() as SocieteBanque;
            if (obj == null)
            {
                txtRib.Reset();
                return;
            }
            txtRib.Text = obj.Rib;}

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
            txtReferenceEnvoi.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            gleBanque.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtMotif.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            //cbType.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
        }

        private void InitForm()
        {
          
            gleBanque.Properties.DisplayMember = "Agence";
            gleBanque.Properties.ValueMember = "Id";
            gleBanque.Properties.View.Columns.Add(new GridColumn
            {
                Caption = "Agence",
                FieldName = "Agence",
                Visible = true
            });
            gleBanque.Properties.DataSource = _controller.GetAllBanque();
            gleBanque.Properties.ImmediatePopup = true;
            gleBanque.Properties.View.OptionsView.ShowColumnHeaders = false;
            gleBanque.Properties.ShowFooter = false;
            gleBanque.Properties.View.OptionsView.ShowIndicator = false;
            gleBanque.Properties.PopupFormSize = new Size(30, 30);
        }
    }
}