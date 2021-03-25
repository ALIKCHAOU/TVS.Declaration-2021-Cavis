using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Columns;
using TVS.Core;
using TVS.Core.Models;

namespace TVS.Declaration
{
    public partial class FrmOuverture : XtraForm
    {
        private readonly DeclarationService _service;
        private readonly AuthentView _currentView;
        private readonly DXErrorProvider _dxErrorProvider;
        private FrmOuverture()
        {
            InitializeComponent(); btnLogin.Click += LoginEvent;
            btnAnnuler.Click += CancelEvent;
            txtLogin.KeyDown += LoginKeyDown;
            txtPassword.KeyDown += LoginKeyDown;
            cbSociete.KeyDown += LoginKeyDown;
            Load += FormLoad;
            Icon = Properties.Resources.log22;
        }

        public FrmOuverture(
               DeclarationService service)
            : this()
        {
            _service = service;
          
            // initialiser DXErrorProvider
            _dxErrorProvider = new DXErrorProvider
            {
                ContainerControl = lcMain
            };
            // initialiser AuthenView
            _currentView = new AuthentView();
            BindingSource();
        }

        // Event Load
        private void FormLoad(object sender, EventArgs e)
        {
            // initialiser la liste des societes
            InitcbSociete();

            // initialiser l'allignement des icons des erreurs provider
            txtLogin.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtPassword.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            cbSociete.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            
#if DEBUG
            txtLogin.EditValue = "Admin";
            txtPassword.EditValue = "Admin";
#endif
 
        }

        private void BindingSource()
        {
            txtLogin.DataBindings.Clear();
            txtLogin.DataBindings.Add("EditValue", _currentView, "Login", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtPassword.DataBindings.Clear();
            txtPassword.DataBindings.Add("EditValue", _currentView, "Password", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            cbSociete.DataBindings.Clear();
            cbSociete.DataBindings.Add("EditValue", _currentView, "SocieteNo", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            _dxErrorProvider.DataSource = null;
        }

     
        // Event Login (valider)
        private void LoginEvent(object sender, EventArgs e)
        {
            // t5arej beuuuuugue
            if (string.IsNullOrEmpty(cbSociete.Text))
            {
                cbSociete.ErrorText = "Societe est obligatoire";
                return;
            }
            // get societe
            var societe = cbSociete.GetSelectedDataRow() as Societe;
            if (societe == null) return;


            try
            {
                //BindingSource();
                _dxErrorProvider.DataSource = _currentView;
                if (_dxErrorProvider.HasErrors) return;

                // verifier le login et le mot de passe
                if (!_service.CanConnect(_currentView.Login, _currentView.Password))
                {
                    _dxErrorProvider.SetError(txtLogin, "Le nom d'utilisateur ou le mot de passe est invalide!");
                    return;
                }

                // get selected societe
                _service.SetSociete(societe);
                _service.SetUser(_currentView.Login);

                var listeUserSociete = _service.UserGetUserBySociete(societe.Id);

                if (Program.GetService().User.IsAdmin)
                {
                    DialogResult = DialogResult.Yes;
                    return;
                }


                foreach (User user in listeUserSociete)
                {
                    if (user.Id == _service.User.Id)
                    {
                        DialogResult = DialogResult.Yes;
                        return;
                    }
                }

                _dxErrorProvider.SetError(txtLogin, "L'utilisateur n'a pas le droit de se connecter à cette société !");
                return;
                //si le login est valide , on enregistre l'utilisateur et societeNO dans le fichier apt
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Close();
        }

        // Event cancel
        private void CancelEvent(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        // Event Key down (Enter)
        private void LoginKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) LoginEvent(null, null);
        }

        // charger la liste des societe
        private void InitcbSociete()
        {
            try
            {
                 var listSociete = _service.SocieteGetAll().ToList();
         
                cbSociete.Properties.View.Columns.Add(new GridColumn
                {
                    Caption = "",
                    FieldName = "RaisonSocial",
                    Visible = true,
                });
                cbSociete.Properties.DisplayMember = "RaisonSocial";
                cbSociete.Properties.ValueMember = "Id";
                cbSociete.Properties.DataSource = listSociete;
                cbSociete.Properties.ImmediatePopup = true;
                cbSociete.Properties.View.OptionsView.ShowColumnHeaders = false;
                cbSociete.Properties.ShowFooter = false;
                cbSociete.Properties.View.OptionsView.ShowIndicator = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}