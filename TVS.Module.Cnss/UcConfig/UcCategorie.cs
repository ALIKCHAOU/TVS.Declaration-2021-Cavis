using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
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
using TVS.Module.Cnss.UcConfig.Controller;
using TVS.Module.Cnss.UcConfig.Views;

namespace TVS.Module.Cnss.UcConfig
{
    public partial class UcCategorie : XtraUserControl, IOptionUserControl
    {
        private readonly CategorieController _controller;
        private CategorieView _currentView;
        private int _index;

        private UcCategorie()
        {
            InitializeComponent();
            viewCategorie.RowClick += SetCurrentCategorie;
            viewCategorie.FocusedRowChanged += SetCurrentCategorie;
            btEnregistrer.Click += Enregistrer;
            txtCodeExploitation.KeyDown += ActionKeyDown;
            txtIntitule.KeyDown += ActionKeyDown;
            txtNo.KeyDown += ActionKeyDown;

            txtTauxAccidenTravail.KeyDown += ActionKeyDown;
            txtTauxPatronal.KeyDown += ActionKeyDown;
            txtTauxSalarial.KeyDown += ActionKeyDown;
            btNouveau.Click += Nouveau;
            btSupprimer.Click += Delete;

            txtTauxAccidenTravail.Properties.DisplayFormat.FormatString = "n3";
            txtTauxAccidenTravail.Properties.DisplayFormat.FormatType = FormatType.Custom;
            if (txtTauxAccidenTravail.Properties.Mask.MaskType == MaskType.Numeric)
            {
                txtTauxAccidenTravail.Properties.Mask.EditMask = string.Format("N{0}", 3);
            }
            txtTauxAccidenTravail.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtTauxAccidenTravail.Properties.Mask.ShowPlaceHolders = false;

            txtTauxPatronal.Properties.DisplayFormat.FormatString = "n3";
            txtTauxPatronal.Properties.DisplayFormat.FormatType = FormatType.Custom;
            if (txtTauxPatronal.Properties.Mask.MaskType == MaskType.Numeric)
            {
                txtTauxPatronal.Properties.Mask.EditMask = string.Format("N{0}", 3);
            }
            txtTauxPatronal.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtTauxPatronal.Properties.Mask.ShowPlaceHolders = false;

            txtTauxSalarial.Properties.DisplayFormat.FormatString = "n3";
            txtTauxSalarial.Properties.DisplayFormat.FormatType = FormatType.Custom;
            if (txtTauxSalarial.Properties.Mask.MaskType == MaskType.Numeric)
            {
                txtTauxSalarial.Properties.Mask.EditMask = string.Format("N{0}", 3);
            }
            txtTauxSalarial.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtTauxSalarial.Properties.Mask.ShowPlaceHolders = false;
            InitTypeVariablePaie();
        }

        public UcCategorie(CategorieController controller)
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
            get { return "Catégorie CNSS"; }
        }

        public string Description
        {
            get { return "Paramétre Catégories CNSS"; }
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
            _currentView = _currentView ?? new CategorieView();

            txtNo.DataBindings.Clear();
            txtNo.DataBindings.Add("EditValue", _currentView, "No", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtIntitule.DataBindings.Clear();
            txtIntitule.DataBindings.Add("EditValue", _currentView, "Intitule", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtCodeExploitation.DataBindings.Clear();
            txtCodeExploitation.DataBindings.Add("EditValue", _currentView, "CodeExploitation", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtTauxAccidenTravail.DataBindings.Clear();
            txtTauxAccidenTravail.DataBindings.Add("EditValue", _currentView, "AccidentTravail", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            txtTauxPatronal.DataBindings.Clear();
            txtTauxPatronal.DataBindings.Add("EditValue", _currentView, "TauxPatronal", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            txtTauxSalarial.DataBindings.Clear();
            txtTauxSalarial.DataBindings.Add("EditValue", _currentView, "TauxSalarial", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            gleTypePaie.DataBindings.Clear();
            gleTypePaie.DataBindings.Add("EditValue", _currentView, "TypeVariablePaie", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtCodePaie.DataBindings.Clear();
            txtCodePaie.DataBindings.Add("EditValue", _currentView, "CodePaie", true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            dxErrorProvider.DataSource = null;
        }

        // initalisation des erreurProvider
        private void InitErrorProvider()
        {
            txtCodeExploitation.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;

            txtIntitule.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
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
            viewCategorie.OptionsCustomization.AllowColumnMoving = false;
            viewCategorie.OptionsCustomization.AllowColumnResizing = false;
            viewCategorie.OptionsCustomization.AllowFilter = false;
            viewCategorie.OptionsCustomization.AllowGroup = false;
            viewCategorie.OptionsCustomization.AllowQuickHideColumns = false;
            viewCategorie.OptionsCustomization.AllowSort = false;
            viewCategorie.OptionsMenu.EnableColumnMenu = false;
            viewCategorie.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            viewCategorie.OptionsView.ShowGroupPanel = false;
            viewCategorie.OptionsView.ShowIndicator = false;
            viewCategorie.OptionsBehavior.Editable = false;
            viewCategorie.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            viewCategorie.OptionsSelection.EnableAppearanceFocusedCell = false;
            viewCategorie.OptionsDetail.EnableMasterViewMode = false;
            var colNo = new GridColumn
            {
                FieldName = "No",
                Visible = true,
                Caption = "N°",
                MaxWidth = 30
            };

            var colIntitule = new GridColumn
            {
                FieldName = "Intitule",
                Visible = true,
                Caption = "Intitule",
            };
            viewCategorie.Columns.Add(colNo);
            viewCategorie.Columns.Add(colIntitule);
            lcMain.OptionsView.HighlightFocusedItem = true;
            gridCategorie.DataSource = _controller.GetAll().ToList();
        }

        // Set the current categorie.
        private void SetCurrentCategorie(object sender, EventArgs e)
        {
            if (viewCategorie.SelectedRowsCount != 1) return;

            int index = viewCategorie.GetSelectedRows().FirstOrDefault();
            object categorie = viewCategorie.GetRow(index);

            _currentView = categorie as CategorieView;
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
                if (string.IsNullOrEmpty(_currentView.Intitule))
                {
                    dxErrorProvider.SetError(txtIntitule, "Champ obligatoire!");
                    return;
                }
                if (_currentView.TauxPatronal > 100 || _currentView.TauxPatronal < 0)
                {
                    dxErrorProvider.SetError(txtTauxPatronal, "Champ invalide!");
                    return;
                }
                if (_currentView.TauxSalarial > 100 || _currentView.TauxSalarial < 0)
                {
                    dxErrorProvider.SetError(txtTauxSalarial, "Champ invalide!");
                    return;
                }
                if (_currentView.AccidentTravail > 100 || _currentView.AccidentTravail < 0)
                {
                    dxErrorProvider.SetError(txtTauxAccidenTravail, "Champ invalide!");
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
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Delete(object sender, EventArgs e)
        {
            try
            {
                if (_currentView == null) return;

                if (_currentView.Id == 0) return;
                // confirmation de la suppression.
                string message = string.Format("Voulez-vous supprimer la catégorie [{0}]?", _currentView.Intitule);
                DialogResult result = XtraMessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
                _controller.DeleteCategorie(_currentView);
                Reload();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reload()
        {
            // charger les categorie
            List<CategorieView> list = _controller.GetAll().ToList();
            // charger gridview
            gridCategorie.DataSource = null;
            gridCategorie.DataSource = list;

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
            viewCategorie.FocusedRowHandle = handle;
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
            gleTypePaie.Properties.View.Columns.Add(new GridColumn
            {
                Caption = "",
                FieldName = "Description",
                Visible = true,
            });

            gleTypePaie.Properties.DisplayMember = "Description";
            gleTypePaie.Properties.ValueMember = "Value";
            gleTypePaie.Properties.DataSource = EnumHelper<TypeVariablePaie>.GetEnumExCollection().ToList();
            gleTypePaie.Properties.ImmediatePopup = true;
            gleTypePaie.Properties.View.OptionsView.ShowColumnHeaders = false;
            gleTypePaie.Properties.ShowFooter = false;
            gleTypePaie.Properties.View.OptionsView.ShowIndicator = false;
            gleTypePaie.Properties.PopupFormSize = new Size(30, 70);
        }

    }
}