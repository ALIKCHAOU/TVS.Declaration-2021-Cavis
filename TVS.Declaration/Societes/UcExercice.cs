using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVS.Declaration.Societes.Controllers;
using TVS.Config;
using DevExpress.XtraEditors;
using TVS.Core.Models;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils;
using DevExpress.XtraLayout;

namespace TVS.Declaration.Societes
{
    public partial class UcExercice : XtraUserControl, IOptionUserControl
    {
        SocieteController _controller;

        private UcExercice()
        {
            InitializeComponent();
            btnNouveau.Click += Nouveau;
            btnCloturer.Click += Cloturer;
            btSupprimer.Click += Supprimer;
            gvExercice.RowClick += SetCurrentExercice;
            gvExercice.FocusedRowChanged += SetCurrentExercice;
        }

        public UcExercice(SocieteController controller)
            : this()
        {
            if (controller == null) throw new ArgumentNullException("controller");
            _controller = controller;
            ChargerGridView();
        }

        public int No
        {
            get { return 1; }
        }

        public string Titre
        {
            get { return "Exercices"; }
        }

        public string Description
        {
            get { return "Paramétre des exercices"; }
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

        private void ChargerGridView()
        {
            // repository image imprimer
            var repoImageCloture = new RepositoryItemImageComboBox();
            repoImageCloture.Items.Add(new ImageComboBoxItem("", false, 0));
            repoImageCloture.Items.Add(new ImageComboBoxItem("", true, 1));

            repoImageCloture.SmallImages = icCloture;
            repoImageCloture.GlyphAlignment = HorzAlignment.Far;
            repoImageCloture.ShowToolTipForTrimmedText = DefaultBoolean.True;

            gvExercice.OptionsCustomization.AllowColumnMoving = false;
            gvExercice.OptionsCustomization.AllowColumnResizing = false;
            gvExercice.OptionsCustomization.AllowFilter = false;
            gvExercice.OptionsCustomization.AllowGroup = false;
            gvExercice.OptionsCustomization.AllowQuickHideColumns = false;
            gvExercice.OptionsCustomization.AllowSort = false;
            gvExercice.OptionsMenu.EnableColumnMenu = false;
            gvExercice.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            gvExercice.OptionsView.ShowGroupPanel = false;
            gvExercice.OptionsView.ShowIndicator = false;
            gvExercice.OptionsBehavior.Editable = false;
            gvExercice.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            gvExercice.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvExercice.OptionsDetail.EnableMasterViewMode = false;
            gvExercice.Columns.Add(new GridColumn
            {
                Caption = @"Exercice",
                FieldName = "Annee",
                Visible = true,
                ToolTip = @"Exercice",
            });
            gvExercice.Columns.Add(new GridColumn
            {
                Caption = @"Clôturer",
                FieldName = "IsCloturer",
                Visible = true,
                MinWidth = 50,
                MaxWidth = 50,
                ToolTip = @"Clôturer",
                ColumnEdit = repoImageCloture
            });
            lcMain.OptionsView.HighlightFocusedItem = true;
            gcExercice.DataSource = _controller.GetAllExercice().ToList();
        }

        // Set the current Exercice.
        private void SetCurrentExercice(object sender, EventArgs e)
        {
            try
            {
                if (gvExercice.SelectedRowsCount != 1) return;

                int index = gvExercice.GetSelectedRows().FirstOrDefault();
                var exercice = gvExercice.GetRow(index) as Exercice;
                if (exercice == null) return;

                btnCloturer.Text = exercice.IsCloturer ? "Déclôturer" : "Clôturer";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Supprimer un exercice.
        private void Supprimer(object sender, EventArgs e)
        {
            try
            {
                var exercice = gvExercice.GetFocusedRow() as Exercice;
                if (exercice == null) return;

                // confirmation de la suppression.
                string message = string.Format("Voulez-vous supprimer l'exercice [{0}]?", exercice.Annee);
                DialogResult result = XtraMessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;

                try
                {
                    // Suppression d'une societe
                    _controller.DeleteExercice(exercice);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //// Rafrechissement de la liste des exercices
                ReloadExercices();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadExercices()
        {
            // charger les exercices
            List<Exercice> list = _controller.GetAllExercice().ToList();
            // charger gridview
            gcExercice.DataSource = null;
            gcExercice.DataSource = list;
        }

        // Nouveau exercice.
        private void Nouveau(object sender, EventArgs e)
        {
            try
            {
                _controller.NouveauExercice();
                ReloadExercices();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // cloturer ou écloturer exercice
        private void Cloturer(object sender, EventArgs e)
        {
            try
            {
                var exercice = gvExercice.GetFocusedRow() as Exercice;
                if (exercice == null) return;
                // confirmation de la suppression.
                string message = string.Format("Voulez-vous {1} l'exercice [{0}]?",
                    exercice.Annee,
                    exercice.IsCloturer ? "Déclôturer" : "Clôturé");
                DialogResult result = XtraMessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
                _controller.CloturerExercice(exercice);
                // Rafrechissement de la liste des exercice
                ReloadExercices();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}