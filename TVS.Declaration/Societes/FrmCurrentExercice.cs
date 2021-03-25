using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVS.Core.Models;
using TVS.Declaration.Societes.Controllers;
using TVS.Declaration.Societes.Views;

namespace TVS.Declaration
{
    public partial class FrmCurrentExercice : Form
    {
        SocieteController _controller;

        private FrmCurrentExercice()
        {
            InitializeComponent();
            Icon = Properties.Resources.log22;
        }

        public FrmCurrentExercice(SocieteController controller)
            : this()
        {
            _controller = controller;
            InitcbSociete();
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

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            var societe = cbSociete.GetSelectedDataRow() as SocieteView;
            if (societe == null)
            {
                MessageBox.Show("Société invalide", "AMEN CONSEIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var exercice = cbExercice.GetSelectedDataRow() as Exercice;
            if (exercice == null)
            {
                MessageBox.Show("Exercice invalide", "AMEN CONSEIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _controller.ChangeCurrentParametre(societe, exercice);
            Close();
        }

        private void FrmCurrentExercice_Load(object sender, EventArgs e)
        {

        }
    }
}