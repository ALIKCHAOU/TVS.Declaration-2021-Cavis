using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using TVS.Config;
using TVS.Core.Enums;
using TVS.Core.Models;
using TVS.Module.Virement.UcConfig.Controller;

namespace TVS.Module.Virement.UcConfig
{
    public partial class UcBanque : XtraUserControl, IOptionUserControl
    {
        private readonly BanqueController _controller;
        private SocieteBanque _currentView;
        private int _index;

        private UcBanque()
        {
            InitializeComponent();
            viewBanque.RowClick += SetCurrentCategorie;
            viewBanque.FocusedRowChanged += SetCurrentCategorie;
            btEnregistrer.Click += Enregistrer;
            txtAdresse.KeyDown += ActionKeyDown;
            txtAgence.KeyDown += ActionKeyDown;
            btNouveau.Click += Nouveau;
            btSupprimer.Click += Delete;
            
  
            InitTypeVariablePaie();
        }

        public UcBanque(BanqueController controller)
            : this()
        {
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
            get { return "Banques"; }
        }

        public string Description
        {
            get { return "Banques"; }
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
        }

        // Binding source
        private void BindingSouce()
        {
            // currentView ne doit pas etre null (binding)
            _currentView = _currentView ?? new SocieteBanque();

            txtAgence.DataBindings.Clear();
            txtAgence.DataBindings.Add("EditValue", _currentView, "Agence", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtAdresse.DataBindings.Clear();
            txtAdresse.DataBindings.Add("EditValue", _currentView, "Adresse", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);


            gleTypeBanque.DataBindings.Clear();
            gleTypeBanque.DataBindings.Add("EditValue", _currentView, "Banque", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtRib.DataBindings.Clear();
            txtRib.DataBindings.Add("EditValue", _currentView, "Rib", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            dxErrorProvider.DataSource = null;
        }

        // initalisation des erreurProvider
        private void InitErrorProvider()
        {
            txtAdresse.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;

            txtAgence.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
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
            viewBanque.OptionsCustomization.AllowColumnMoving = false;
            viewBanque.OptionsCustomization.AllowColumnResizing = false;
            viewBanque.OptionsCustomization.AllowFilter = false;
            viewBanque.OptionsCustomization.AllowGroup = false;
            viewBanque.OptionsCustomization.AllowQuickHideColumns = false;
            viewBanque.OptionsCustomization.AllowSort = false;
            viewBanque.OptionsMenu.EnableColumnMenu = false;
            viewBanque.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            viewBanque.OptionsView.ShowGroupPanel = false;
            viewBanque.OptionsView.ShowIndicator = false;
            viewBanque.OptionsBehavior.Editable = false;
            viewBanque.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            viewBanque.OptionsSelection.EnableAppearanceFocusedCell = false;
            viewBanque.OptionsDetail.EnableMasterViewMode = false;
            var colAgence = new GridColumn
            {
                FieldName = "Agence",
                Visible = true,
                Caption = "Agence",
                MaxWidth = 120
            };

            var colBanque = new GridColumn
            {
                FieldName = "Adresse",
                Visible = true,
                Caption = "Adresse",
            };
            viewBanque.Columns.Add(colAgence);
            viewBanque.Columns.Add(colBanque);
            lcMain.OptionsView.HighlightFocusedItem = true;
            gridBanque.DataSource = _controller.GetAll().ToList();
        }

        // Set the current categorie.
        private void SetCurrentCategorie(object sender, EventArgs e)
        {
            if (viewBanque.SelectedRowsCount != 1) return;

            int index = viewBanque.GetSelectedRows().FirstOrDefault();
            object categorie = viewBanque.GetRow(index);

            _currentView = categorie as SocieteBanque;
            if (_currentView == null) return;

            BindingSouce();
        }

        // Ajouter & Modifier societe.
        private void Enregistrer(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider.DataSource = _currentView;
                if (dxErrorProvider.HasErrors) return;
                if (string.IsNullOrEmpty(_currentView.Agence))
                {
                    dxErrorProvider.SetError(txtAgence, "Champ obligatoire!");
                    return;
                }
              

                if (_currentView == null)
                {
                    return;
                }
                if (_currentView.Id != 0)
                {
                    // Modifier une categorie
                    _controller.Update(_currentView);

                    // sauvgarder le numero du nouveau categorie pour la selectionner dans la list
                    _index = _currentView.Id;
                }
                else
                {
                    _index = _controller.Ajouter(_currentView);
                }
                // Rafrechissement de la liste des categorie
                Reload();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "AMEN CONSEIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Nouveau(object sender, EventArgs e)
        {
            try
            {
                _currentView = _controller.InitCategorie();
                BindingSouce();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "AMEN CONSEIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Delete(object sender, EventArgs e)
        {
            try
            {
                if (_currentView == null) return;

                if (_currentView.Id == 0) return;
                // confirmation de la suppression.
                string message = string.Format("Voulez-vous supprimer la banque [{0}]?", _currentView.Agence);
                DialogResult result = XtraMessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
                _controller.DeleteCategorie(_currentView);
                Reload();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "AMEN CONSEIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reload()
        {
            // charger les categorie
            List<SocieteBanque> list = _controller.GetAll().ToList();
            // charger gridview
            gridBanque.DataSource = null;
            gridBanque.DataSource = list;

            // selectionner un element
            int handle = -1;
            // chercher la position du l'element a selectionne
            handle = list
                .ToList()
                .FindIndex(x => x.Id == _index);

            // selection
            // if (handle == -1) handle = 0;
            if (handle < 0)
            {
                _currentView = _controller.InitCategorie();
                BindingSouce();
                return;
            }
            viewBanque.FocusedRowHandle = handle;
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void InitTypeVariablePaie()
        {
            var listEnum = new List<KeyValuePair<string, int>>();

            foreach (int i in Enum.GetValues(typeof(TypeVariablePaie)))
            {
                string name = Enum.GetName(typeof(TypeVariablePaie), i);
                string desc = name;
                var fi = typeof(TypeVariablePaie).GetField(name);

                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
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
            gleTypeBanque.Properties.View.Columns.Add(new GridColumn
            {
                Caption = "",
                FieldName = "Description",
                Visible = true,
            });

            gleTypeBanque.Properties.DisplayMember = "Description";
            gleTypeBanque.Properties.ValueMember = "Value";
            gleTypeBanque.Properties.DataSource = EnumHelper<Banque>.GetEnumExCollection().ToList();
            gleTypeBanque.Properties.ImmediatePopup = true;
            gleTypeBanque.Properties.View.OptionsView.ShowColumnHeaders = false;
            gleTypeBanque.Properties.ShowFooter = false;
            gleTypeBanque.Properties.View.OptionsView.ShowIndicator = false;
            gleTypeBanque.Properties.PopupFormSize = new Size(30, 70);
        }

    }
}