using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TVS.Config;
using TVS.Core.Enums;
using TVS.Core.Models;
using TVS.Declaration.Societes.Controllers;
using TVS.Declaration.Societes.Views;

namespace TVS.Declaration.Societes
{
    public partial class UcSociete : XtraUserControl, IOptionUserControl
    {
        private readonly SocieteController _controller;
        private SocieteView _currentView;
        private string _raisonSo;

        private UcSociete()
        {
            InitializeComponent();
            dxErrorProvider.ContainerControl = lcMain;
            btnNouveau.Click += Nouveau;
            btnEnregistrer.Click += Enregistrer;
            btnAjoutUser.Click += AjoutUser;
            btnSupprimerUser.Click += SupprimerUser;
            btnSupprimer.Click += Supprimer;
            //gvSociete.RowClick += SetCurrentSociete;
            gvSociete.FocusedRowChanged += SetCurrentSociete;
            txtRaisonSocial.KeyDown += ActionKeyDown;
            txtActivite.KeyDown += ActionKeyDown;
            txtPays.KeyDown += ActionKeyDown;
            txtNumEmployeur.KeyDown += ActionKeyDown;
            txtMatricule.KeyDown += ActionKeyDown;
            txtMatCle.KeyDown += ActionKeyDown;
            txtMatCat.KeyDown += ActionKeyDown;
            txtMatEtab.KeyDown += ActionKeyDown;
            txtAdresse.KeyDown += ActionKeyDown;
            txtVille.KeyDown += ActionKeyDown;
            txtCodePostal.KeyDown += ActionKeyDown;
            txtCodeBureau.KeyDown += ActionKeyDown;
            txtCleCnss.KeyDown += ActionKeyDown;
            txtServer.KeyDown += ActionKeyDown;
            txtBase.KeyDown += ActionKeyDown;
            txtNomUtilisateur.KeyDown += ActionKeyDown;
            txtPwd.KeyDown += ActionKeyDown;
            txtCodeTva.KeyDown += ActionKeyDown;


            linkVerifConnection.OpenLink += TesterConnexion;

            cbAuthentification.KeyDown += ActionKeyDown;
            if (!Program.IsMultiSociete)
            {
                lciNouveau.Visibility = LayoutVisibility.Never;
                lciSupprimer.Visibility = LayoutVisibility.Never;
            }

            cbAuthentification.EditValueChanged += AuthentificationChanged;

            tcgSociete.SelectedTabPage = lctInformation;


            if (Program.GetService().User.IsAdmin)

            {
                lctUtilisateur.Visibility = LayoutVisibility.Always;
                lctErp.Visibility = LayoutVisibility.Always;
                lctInformation.Enabled = true;
            }
            else
            {
                lctUtilisateur.Visibility = LayoutVisibility.Never;
                lctErp.Visibility = LayoutVisibility.Never;
                lctInformation.Enabled = false;
            }

        }



        public UcSociete(SocieteController controller)
            : this()
        {
            if (controller == null) throw new ArgumentNullException("controller");
            _controller = controller;
            ChargerGridView();
            BindingSouce();
            this.listBoxAllUser.DataSource = _controller.GetAllUsers();
            InitErrorProvider();
        }

        public int No
        {
            get { return 1; }
        }

        public string Titre
        {
            get { return "Sociétés"; }
        }

        public string Description
        {
            get { return "Paramétre Societe"; }
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
            _controller.RefreshSource();
        }

        // Binding source mode de reglement.
        private void BindingSouce()
        {
            // currentView ne doit pas etre null (binding)
            _currentView = _currentView ?? new SocieteView();
            txtActivite.DataBindings.Clear();
            txtActivite.DataBindings.Add("EditValue", _currentView, "Activite", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtAdresse.DataBindings.Clear();
            txtAdresse.DataBindings.Add("EditValue", _currentView, "Adresse", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtCodePostal.DataBindings.Clear();
            txtCodePostal.DataBindings.Add("EditValue", _currentView, "CodePostal", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtMatricule.DataBindings.Clear();
            txtMatricule.DataBindings.Add("EditValue", _currentView, "MatriculFiscal", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtMatCle.DataBindings.Clear();
            txtMatCle.DataBindings.Add("EditValue", _currentView, "MatriculCle", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtCodeTva.DataBindings.Clear();
            txtCodeTva.DataBindings.Add("EditValue", _currentView, "MatriculCodeTva", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtMatCat.DataBindings.Clear();
            txtMatCat.DataBindings.Add("EditValue", _currentView, "MatriculCategorie", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtMatEtab.DataBindings.Clear();
            txtMatEtab.DataBindings.Add("EditValue", _currentView, "MatriculEtablissement", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtPays.DataBindings.Clear();
            txtPays.DataBindings.Add("EditValue", _currentView, "Pays", true, DataSourceUpdateMode.OnPropertyChanged,
                string.Empty);

            txtRaisonSocial.DataBindings.Clear();
            txtRaisonSocial.DataBindings.Add("EditValue", _currentView, "RaisonSocial", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtVille.DataBindings.Clear();
            txtVille.DataBindings.Add("EditValue", _currentView, "Ville", true, DataSourceUpdateMode.OnPropertyChanged,
                string.Empty);

            txtNumEmployeur.DataBindings.Clear();
            txtNumEmployeur.DataBindings.Add("EditValue", _currentView, "NumeroEmployeur", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtCodeBureau.DataBindings.Clear();
            txtCodeBureau.DataBindings.Add("EditValue", _currentView, "CodeBureau", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtCleCnss.DataBindings.Clear();
            txtCleCnss.DataBindings.Add("EditValue", _currentView, "CleEmployeur", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);


            txtBase.DataBindings.Clear();
            txtBase.DataBindings.Add("EditValue", _currentView, "ConnectionView.DatabaseName", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtPwd.DataBindings.Clear();
            txtPwd.DataBindings.Add("EditValue", _currentView, "ConnectionView.Password", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtServer.DataBindings.Clear();
            txtServer.DataBindings.Add("EditValue", _currentView, "ConnectionView.ServerName", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            cbAuthentification.DataBindings.Clear();
            cbAuthentification.DataBindings.Add("EditValue", _currentView, "ConnectionView.Type", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtNomUtilisateur.DataBindings.Clear();
            txtNomUtilisateur.DataBindings.Add("EditValue", _currentView, "ConnectionView.User", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            gleNumChezEmp.DataBindings.Clear();
            gleNumChezEmp.DataBindings.Add("EditValue", _currentView, "CnssTypeMatricule", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            var listeUserSociete = _controller.GetUserBySociete(_currentView.Id);
            listBoxSocieteUser.Items.Clear();
            Application.DoEvents();
            foreach (User user in listeUserSociete)
            {
                listBoxSocieteUser.Items.Add(user);
            }

            dxErrorProvider.DataSource = null;
        }

        // initalisation des erreurProvider
        private void InitErrorProvider()
        {
            txtRaisonSocial.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtActivite.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtAdresse.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtVille.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtCodePostal.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;

            txtCodeBureau.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtMatricule.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtNumEmployeur.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtPays.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtMatCle.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtMatEtab.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            txtMatCat.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
        }

        // Event click 'keyDown'.
        public void ActionKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            Enregistrer(null, null);
        }

        // Initialisation de la liste des societes.
        private void ChargerGridView()
        {
            gvSociete.OptionsCustomization.AllowColumnMoving = false;
            gvSociete.OptionsCustomization.AllowColumnResizing = false;
            gvSociete.OptionsCustomization.AllowFilter = false;
            gvSociete.OptionsCustomization.AllowGroup = false;
            gvSociete.OptionsCustomization.AllowQuickHideColumns = false;
            gvSociete.OptionsCustomization.AllowSort = false;
            gvSociete.OptionsMenu.EnableColumnMenu = false;
            gvSociete.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            gvSociete.OptionsView.ShowGroupPanel = false;
            gvSociete.OptionsView.ShowIndicator = false;
            gvSociete.OptionsBehavior.Editable = false;
            gvSociete.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            gvSociete.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvSociete.OptionsDetail.EnableMasterViewMode = false;
            gvSociete.Columns.AddVisible("RaisonSocial", "Raison Social");
            gvSociete.Columns.AddVisible("Activite", "Activité");
            lcMain.OptionsView.HighlightFocusedItem = true;
            if (Program.GetService().User.IsAdmin)

                gcSociete.DataSource = _controller.GetAll().ToList();
            else

                gcSociete.DataSource = _controller.GetSocieteByUser().ToList();
            InitCbAuthentification();
        }

        // Supprimer une societe.
        private void Supprimer(object sender, EventArgs e)
        {
            try
            {
                // verifier la selection
                if (_currentView == null || _currentView.Id == 0) return;

                // confirmation de la suppression.
                string message = string.Format("Voulez-vous supprimer la societé [{0}]?", _currentView.RaisonSocial);
                DialogResult result = XtraMessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;

                try
                {
                    // Suppression d'une societe
                    _controller.Delete(_currentView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                _raisonSo = _currentView.RaisonSocial;
                //// Rafrechissement de la liste des societes
                ReloadSocietes();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadSocietes()
        {
            // charger les societes
            List<SocieteView> list = _controller.GetAll().ToList();
            // charger gridview
            gcSociete.DataSource = null;
            gcSociete.DataSource = list;
            // la liste est vide
            if (!list.Any())
            {
                Nouveau(null, null);
                return;
            }
            // selectionner un element
            int handle = -1;
            if (!string.IsNullOrEmpty(_raisonSo))
            {
                // chercher la position du l'element a selectionne
                handle = list
                    .ToList()
                    .FindIndex(x => x.RaisonSocial == _raisonSo);
            }

            var listeUserSociete = _controller.GetUserBySociete(_currentView.Id);
            listBoxSocieteUser.Items.Clear();
            Application.DoEvents();
            foreach (User user in listeUserSociete)
            {
                listBoxSocieteUser.Items.Add(user);
            }

            // selection
            if (handle == -1) handle = 0;
            gvSociete.FocusedRowHandle = handle;

        }

        // Nouveau societe.
        private void Nouveau(object sender, EventArgs e)
        {
            _currentView = _controller.InitNew();
            BindingSouce();
            gcSociete.MainView.Appearance.Reset();
            tcgSociete.SelectedTabPage = lctInformation;
        }

        // Ajouter & Modifier societe.
        private void Enregistrer(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider.DataSource = _currentView;
                if (string.IsNullOrEmpty(_currentView.MatriculFiscal))
                {
                    txtMatricule.ErrorText = "Matricul fiscale est invalide!";
                    return;
                }

                if (string.IsNullOrEmpty(_currentView.CodeBureau))
                {
                    txtCodeBureau.ErrorText = "Code bureau est invalide!";
                    return;
                }
                if (string.IsNullOrEmpty(_currentView.NumeroEmployeur))
                {
                    txtNumEmployeur.ErrorText = "Numéro d'employeur existe déja!";
                    return;
                }

                if (string.IsNullOrEmpty(_currentView.CleEmployeur))
                {
                    txtCleCnss.ErrorText = "Clé employeur est invalide!";
                    return;
                }


                if (_currentView == null)
                {
                    return;
                }
                if (dxErrorProvider.HasErrors) return;
                if (_currentView.Id == 0)
                {
                    if (_controller.IsSocieteExists(_currentView))
                    {
                        txtRaisonSocial.ErrorText = "Raison social existe déja!";
                        return;
                    }
                    // Ajouter une societe
                    int idSociete = _controller.Create(_currentView);

                    foreach (var item in listBoxSocieteUser.Items)
                    {
                        if (item is User user)
                            _controller.CreateUserSociete(user.Id, idSociete);
                    }
                }
                else
                {
                    // Modifier une societe
                    _controller.Update(_currentView);

                    //Mise à jour Utilisateurs Societe
                    _controller.DeleteUserBySociety(_currentView.Id);
                    foreach (var item in listBoxSocieteUser.Items)
                    {
                        if (item is User user)
                            _controller.CreateUserSociete(user.Id, _currentView.Id);
                    }
                    this.listBoxSocieteUser.Items.Clear();
                }

                // sauvgarder le numero du nouveau societe pour la selectionner dans la list
                _raisonSo = _currentView.RaisonSocial;

                // Rafrechissement de la liste des societes
                ReloadSocietes();
               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ajouter  utilisateur de société
        private void AjoutUser(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in listBoxAllUser.SelectedItems)
                {
                  if(!listBoxSocieteUser.Items.Contains(item))
                   listBoxSocieteUser.Items.Add(item);
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        // supprimer  utilisateur de société
        private void SupprimerUser(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in listBoxSocieteUser.SelectedItems)
                {
                    listBoxSocieteUser.Items.Remove(item);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Set the current societe.
        private void SetCurrentSociete(object sender, EventArgs e)
        {
            Application.DoEvents();
            this.listBoxSocieteUser.Items.Clear();
            if (gvSociete.SelectedRowsCount != 1) return;

            int index = gvSociete.GetSelectedRows().FirstOrDefault();
            object societe = gvSociete.GetRow(index);

            _currentView = societe as SocieteView;
            if (_currentView == null) return;
            txtRaisonSocial.Enabled = true;
            BindingSouce();
        }

        private void InitCbAuthentification()
        {
            var listEnum = new List<KeyValuePair<string, int>>();

            foreach (int i in Enum.GetValues(typeof(TypeAuthentification)))
            {
                string name = Enum.GetName(typeof(TypeAuthentification), i);
                string desc = name;
                var fi = typeof(TypeAuthentification).GetField(name);

                var attributes = (DescriptionAttribute[]) fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    string s = attributes[0].Description;
                    if (!string.IsNullOrEmpty(s))
                    {
                        desc = s;
                    }
                }

                listEnum.Add(new KeyValuePair<string, int>(desc, i));
            }
            cbAuthentification.Properties.View.Columns.Add(new GridColumn
            {
                Caption = "",
                FieldName = "Description",
                Visible = true,
            });

            cbAuthentification.Properties.DisplayMember = "Description";
            cbAuthentification.Properties.ValueMember = "Value";
            cbAuthentification.Properties.DataSource = EnumHelper<TypeAuthentification>.GetEnumExCollection().ToList();
            cbAuthentification.Properties.ImmediatePopup = true;
            cbAuthentification.Properties.View.OptionsView.ShowColumnHeaders = false;
            cbAuthentification.Properties.ShowFooter = false;
            cbAuthentification.Properties.View.OptionsView.ShowIndicator = false;
            cbAuthentification.Properties.PopupFormSize = new Size(30, 70);

            gleNumChezEmp.Properties.DisplayMember = "Description";
            gleNumChezEmp.Properties.ValueMember = "Value";
            gleNumChezEmp.Properties.DataSource = EnumHelper<TypeMatriculCnss>.GetEnumExCollection().ToList();
            gleNumChezEmp.Properties.ImmediatePopup = true;
            gleNumChezEmp.Properties.View.OptionsView.ShowColumnHeaders = false;
            gleNumChezEmp.Properties.ShowFooter = false;
            gleNumChezEmp.Properties.View.OptionsView.ShowIndicator = false;
            gleNumChezEmp.Properties.PopupFormSize = new Size(30, 70);
        }

        // Tester la connection
        private void TesterConnexion(object sender, OpenLinkEventArgs e)
        {
            try
            {
                _controller.VerifierConnexion(_currentView);
                XtraMessageBox.Show("Connection valide!", "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AuthentificationChanged(object sender, EventArgs e)
        {
            var type = (TypeAuthentification) cbAuthentification.EditValue;
            if (type == TypeAuthentification.Sql)
            {
                txtNomUtilisateur.Enabled = true;
                txtPwd.Enabled = true;
            }
            else
            {
                txtNomUtilisateur.Enabled = false;
                txtPwd.Enabled = false;
            }
        }

        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}