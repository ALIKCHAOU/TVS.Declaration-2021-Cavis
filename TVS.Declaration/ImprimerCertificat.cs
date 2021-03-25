using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TVS.Core.Models;
using TVS.Declaration.Societes.Controllers;
using TVS.Declaration.Societes.Views;
using TVS.Module.Cnss.UiCnss.Controller;
using TVS.Module.Cnss.UiCnss.Views;

namespace CnssModule.Declarations
{
    public partial class ImprimerCertificat : XtraForm
    {
        private readonly DeclarationsController _controller;
        private DeclarationView _declaration;
        List<LigneCnss> _listeCNSS = new List<LigneCnss>();

        SocieteController _controllerSoc;

        private ImprimerCertificat()
        {
            InitializeComponent();
        }

        public ImprimerCertificat(DeclarationsController controller ,List<LigneCnss> listeCNSS)
            : this()
        {
            _controller = controller;
            _listeCNSS = listeCNSS;
            InitcbSociete();
        }

        public ImprimerCertificat(DeclarationsController controller)
            : this()
        {
            _controller = controller;
            InitErrorProvider();
            //  BindingSouce();
            InitcbSociete();

            btValider.Click += Valider;
            btAnnuler.Click += (sender, args) => Close();
 
        }

        // Binding source mode de reglement.
        private void BindingSouce()
        {
            // currentView ne doit pas etre null (binding)
            _declaration = _declaration ?? _controller.InitDeclaration();

            cbExercice.DataBindings.Clear();
            cbExercice.DataBindings.Add("EditValue", _declaration, "Annee", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            //txtSociete.DataBindings.Clear();
            //txtSociete.DataBindings.Add("EditValue", _declaration, "Societe", true,
            //    DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            //cbType.DataBindings.Clear();
            //cbType.DataBindings.Add("Checked", _declaration, "Complementaire", true,
            //    DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            cbTrimestre.DataBindings.Clear();
            cbTrimestre.DataBindings.Add("EditValue", _declaration, "Trimestre", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            dxErrorProvider.DataSource = null;
        }

        private void InitcbSociete()
        {
            cbSociete.Properties.DisplayMember = "RaisonSocial";
            cbSociete.Properties.ValueMember = "Id";
            cbSociete.Properties.View.Columns.Add(new GridColumn
            {
                Caption = "Raison social",
                FieldName = "RaisonSocial",
                Visible = true,
            });
            cbSociete.Properties.NullText = string.Empty;
            cbSociete.Properties.ImmediatePopup = true;
            cbSociete.Properties.View.OptionsView.ShowColumnHeaders = false;
            cbSociete.Properties.ShowFooter = false;
            cbSociete.Properties.View.OptionsView.ShowIndicator = false;
            cbSociete.Properties.PopupFormSize = new Size(30, 70);
            var societes = new List<SocieteView>();
            if (Program.GetService().User.IsAdmin)

                societes = _controller.GetAll().ToList();
            else
                societes = _controller.GetSocieteByUser().ToList();

            cbSociete.Properties.DataSource = societes;
            cbSociete.EditValue = _controller.GetCurrentSociete().Id;
            cbExercice.Properties.DisplayMember = "Annee";
            cbExercice.Properties.ValueMember = "Id";
            cbExercice.Properties.View.Columns.Add(new GridColumn
            {
                Caption = "",
                FieldName = "Annee",
                Visible = true,
            });
            cbExercice.Properties.NullText = string.Empty;
            cbExercice.Properties.ImmediatePopup = true;
            cbExercice.Properties.View.OptionsView.ShowColumnHeaders = false;
            cbExercice.Properties.ShowFooter = false;
            cbExercice.Properties.View.OptionsView.ShowIndicator = false;
            cbExercice.Properties.PopupFormSize = new Size(20, 50);
            cbExercice.Properties.DataSource = _controller.GetAllExercice().ToList();
            cbExercice.EditValue = _controller.GetCurrentExercie().Id;
            if (!Program.IsMultiSociete)
                cbSociete.Enabled = false;
        }


        public void Valider(object sender, EventArgs e)
        {
            try
            {
                var ligneS = _controller.GetDeclarationByTrimestre(DeclarationView.Id, ligneDec.EmployeeNo);

                // _controller.CreateDeclaration(_declaration);
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
            //txtSociete.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
           // cbExercice.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            //cbTrimestre.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
           // cbType.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
        }

        private void btAnnuler_Click(object sender, EventArgs e)
        {
            //Close();
        }
    }
}