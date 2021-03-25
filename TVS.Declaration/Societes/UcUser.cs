using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using TVS.Config;
using TVS.Core.Enums;
using TVS.Core.Models;
using TVS.Declaration.Societes.Controllers;
using TVS.Config.Modules;

namespace TVS.Declaration.Societes
{
    public partial class UcUser : XtraUserControl, IOptionUserControl
    {
        private readonly UserController _controller;
        private User _currentView;
        private string _login;
        private UcUser()
        {
            InitializeComponent();
            dxErrorProvider.ContainerControl = lciMain;
            btNouveau.Click += Nouveau;
            btEnregistrer.Click += Enregistrer;
            btsupprimer.Click += Supprimer;
            gvUser.RowClick += SetCurrentUtilisateur;
            gvUser.FocusedRowChanged += SetCurrentUtilisateur;
            txtLogin.KeyDown += ActionKeyDown;
            txtPassword.KeyDown += ActionKeyDown;
            chAchat.KeyDown += ActionKeyDown;
            chAdmin.KeyDown += ActionKeyDown;
            chAnnexe1.KeyDown += ActionKeyDown;
            chDecCnss.KeyDown += ActionKeyDown;
            chDecEmp.KeyDown += ActionKeyDown;
            chDecVente.KeyDown += ActionKeyDown;

            chLiasseFiscale.KeyDown += ActionKeyDown;
            chVirement.KeyDown += ActionKeyDown;

            txtNom.KeyDown += ActionKeyDown;
            txtPrenom.KeyDown += ActionKeyDown;
            txtEmail.KeyDown += ActionKeyDown;
        }

        public UcUser(UserController controller)
            : this()
        {
            if (controller == null) throw new ArgumentNullException("controller");
            _controller = controller;
            ChargerGridView();
            BindingSouce();
            InitErrorProvider();
        }

        public int No
        {
            get { return 2; }
        }

        public string Titre
        {
            get { return "Utilisateurs"; }
        }

        public string Description
        {
            get { return "Gestion des utilisatuers"; }
        }

        public bool IsDefault
        {
            get { return true; }
        }

        public BaseLayoutItem LayoutItem
        {
            get { return null; }
        }

        public void RefreshSource()
        {
          //  _controller.RefreshSource();
        }

        // Binding source mode de reglement.
        private void BindingSouce()
        {
            // currentView ne doit pas etre null (binding)
            _currentView = _currentView ??_controller.InitNew();

            txtPassword.DataBindings.Clear();
            txtPassword.DataBindings.Add("EditValue", _currentView, "Password", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtLogin.DataBindings.Clear();
            txtLogin.DataBindings.Add("EditValue", _currentView, "Login", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtNom.DataBindings.Clear();
            txtNom.DataBindings.Add("EditValue", _currentView, "Nom", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtPrenom.DataBindings.Clear();
            txtPrenom.DataBindings.Add("EditValue", _currentView, "Prenom", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("EditValue", _currentView, "Mail", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            chDecVente.DataBindings.Clear();
            chDecVente.DataBindings.Add("EditValue", _currentView, "Vente", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);


            chVirement.DataBindings.Clear();
            chVirement.DataBindings.Add("EditValue", _currentView, "Virement", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);


            chLiasseFiscale.DataBindings.Clear();
            chLiasseFiscale.DataBindings.Add("EditValue", _currentView, "Liasse", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            chAchat.DataBindings.Clear();
            chAchat.DataBindings.Add("EditValue", _currentView, "Achat", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            chAnnexe1.DataBindings.Clear();
            chAnnexe1.DataBindings.Add("EditValue", _currentView, "DecEmpAnnexe1", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            chDecCnss.DataBindings.Clear();
            chDecCnss.DataBindings.Add("EditValue", _currentView, "Cnss", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            chAdmin.DataBindings.Clear();
            chAdmin.DataBindings.Add("EditValue", _currentView, "IsAdmin", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            chDecEmp.DataBindings.Clear();
            chDecEmp.DataBindings.Add("EditValue", _currentView, "DecEmp", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            dxErrorProvider.DataSource = null;
        }

        // initalisation des erreurProvider
        private void InitErrorProvider()
        {
            txtPassword.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtLogin.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            chDecVente.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            chAchat.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            chAdmin.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;

            chAnnexe1.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            chDecCnss.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            chDecEmp.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;

            txtNom.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtPrenom.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtEmail.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;

            chVirement.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            chLiasseFiscale.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;


        }

        // Event click 'keyDown'.
        public void ActionKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            Enregistrer(null, null);
        }

        // Initialisation de la liste des utilisateur.
        private void ChargerGridView()
        {
            gvUser.OptionsCustomization.AllowColumnMoving = false;
            gvUser.OptionsCustomization.AllowColumnResizing = false;
            gvUser.OptionsCustomization.AllowFilter = false;
            gvUser.OptionsCustomization.AllowGroup = false;
            gvUser.OptionsCustomization.AllowQuickHideColumns = false;
            gvUser.OptionsCustomization.AllowSort = false;
            gvUser.OptionsMenu.EnableColumnMenu = false;
            gvUser.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            gvUser.OptionsView.ShowGroupPanel = false;
            gvUser.OptionsView.ShowIndicator = false;
            gvUser.OptionsBehavior.Editable = false;
            gvUser.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            gvUser.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvUser.OptionsDetail.EnableMasterViewMode = false;
            gvUser.Columns.AddVisible("Login", "Utilisateur");
            gvUser.Columns.AddVisible("Nom", "Nom");
            lciMain.OptionsView.HighlightFocusedItem = true;
            gcUser.DataSource = _controller.GetAll().ToList();
     
        }

        // Supprimer un utilisateur.
        private void Supprimer(object sender, EventArgs e)
        {
            try
            {
                // verifier la selection
                if (_currentView == null || _currentView.Id == 0) return;

                // confirmation de la suppression.
                string message = string.Format("Voulez-vous supprimer l'utilisateur [{0}]?", _currentView.Login);
                DialogResult result = XtraMessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;

                try
                {
                    // Suppression d'un utilisateur
                    _controller.Delete(_currentView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                _login = _currentView.Login;
                //// Rafrechissement de la liste des utilisateurs
                ReloadUtilisateur();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadUtilisateur()
        {
            // charger les utilisateurs
            List<User> list = _controller.GetAll().ToList();
            // charger gridview
            gcUser.DataSource = null;
            gcUser.DataSource = list;
            // la liste est vide
            if (!list.Any())
            {
                Nouveau(null, null);
                return;
            }
            // selectionner un element
            int handle = -1;
            if (!string.IsNullOrEmpty(_login))
            {
                // chercher la position du l'element a selectionne
                handle = list
                    .ToList()
                    .FindIndex(x => x.Login == _login);
            }

            // selection
            if (handle == -1) handle = 0;
            gvUser.FocusedRowHandle = handle;
        }

        // Nouveau utilisateur.
        private void Nouveau(object sender, EventArgs e)
        {
            _currentView = _controller.InitNew();
            BindingSouce();
            gcUser.MainView.Appearance.Reset();
        }

        // Ajouter & Modifier utilisateur.
        private void Enregistrer(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider.DataSource = _currentView;
                if (string.IsNullOrEmpty(_currentView.Login))
                {
                    txtLogin.ErrorText = "Login est invalide!";
                    return;
                }
                if (string.IsNullOrEmpty(_currentView.Nom))
                {
                    txtNom.ErrorText = "Nom est invalide!";
                    return;
                }

                if (_currentView == null)
                {
                    return;
                }
                if (dxErrorProvider.HasErrors) return;
                if (_currentView.Id == 0)
                {
                    if (_controller.IsUserExists(_currentView))
                    {
                        txtLogin.ErrorText = "Nom d'utilisateur existe déja!";
                        return;
                    }
                    // Ajouter une utilisateur
                    _controller.Create(_currentView);
                }
                else
                {
                    // Modifier une utilisateur
                    _controller.Update(_currentView);
                }
                // sauvgarder le numero du nouveau utilisatet pour la selectionner dans la list
                _login = _currentView.Login;

                // Rafrechissement de la liste des utilisateur

                ReloadUtilisateur();
                //this.Refresh();
                //Application.DoEvents();
                           
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Set the current societe.
        private void SetCurrentUtilisateur(object sender, EventArgs e)
        {
            

            if (gvUser.SelectedRowsCount != 1) return;

            int index = gvUser.GetSelectedRows().FirstOrDefault();
            object user = gvUser.GetRow(index);

            _currentView = user as User;
            if (_currentView == null) return;
            txtLogin.Enabled = true;
            BindingSouce();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chVirement_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gcUser_Click(object sender, EventArgs e)
        {

        }
    }
}