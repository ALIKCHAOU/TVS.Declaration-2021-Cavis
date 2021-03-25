using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using TVS.Core.Models.Liass;

namespace TVS.Module.Liasse.Forms
{
    public partial class XtraFrmF6004 : DevExpress.XtraEditors.XtraForm
    {
        private Core.Models.Liass.F6004 _CurrentF6004;
        private LiasseController _controller;
        public XtraFrmF6004(LiasseController controller)
        {
            _controller = controller;
            InitializeComponent();
            gridView1.CustomRowCellEdit+=GridView1OnCustomRowCellEdit;
            _CurrentF6004= controller.CurrentF6004();
            DBf6004BindingSource.DataSource = _CurrentF6004;
            this.F6004BindingSource.DataSource = new Model.F6004(_CurrentF6004);
            btEnregistrer.Click += BtEnregistrer_Click;
            btExporter.Click += BtExporter_Click;
            //this.gridView1.OptionsView.RowAutoHeight = true;
            //colLibelle.AppearanceCell.TextOptions.WordWrap=WordWrap.Wrap;
            saveFileDialog1.FileName = controller.GetXmlFileName(this.DBf6004BindingSource.Current);
        }

        private void GridView1OnCustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null)
            {
                int selectedRowIndex = view.GetSelectedRows().First();
                var rowObject = view.GetRow(selectedRowIndex) as Model.LigneLiasse;
                if (rowObject != null && Type.GetTypeCode(rowObject.TypeValeurs) == TypeCode.Decimal&&e.Column.Name.Contains("Valeur"))
                    e.RepositoryItem = this.repositoryItemSpinEdit1;
            }}
        private void BtExporter_Click(object sender, EventArgs e)
        {
            BtEnregistrer_Click(null, null);
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK) return;
            var fileName = saveFileDialog1.FileName;
            var F6004 = this.DBf6004BindingSource.Current as Core.Models.Liass.F6004;
            _controller.Export(F6004, fileName);
        }

        private void BtEnregistrer_Click(object sender, EventArgs e)
        {
            this.F6004BindingSource.EndEdit();
            DBf6004BindingSource.EndEdit();var F6004 = this.F6004BindingSource.Current as  Model.F6004;
            if (F6004 != null) _controller.Save(F6004.MF6004);
            _CurrentF6004 = _controller.CurrentF6004();
            DBf6004BindingSource.DataSource = _CurrentF6004;
            this.F6004BindingSource.DataSource = new Model.F6004(_CurrentF6004);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null)
            {
                int selectedRowIndex = view.GetSelectedRows().First();
                var rowObject = view.GetRow(selectedRowIndex) as Model.LigneLiasse;
                if (rowObject != null && rowObject.Calculable) e.Cancel=true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.gridView1.ShowRibbonPrintPreview();
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            var model = new Model.F6004(new F6004());
            var z = new ImportForms.F6004ImportForm(model);
            if (z.ShowDialog(this) == DialogResult.OK)
            {

                var f6004 = this.F6004BindingSource.Current as Model.F6004;
                if (f6004 == null) return;
                foreach (var currentF6004Ligne in model.Lignes)
                {
                    if (currentF6004Ligne != null && !currentF6004Ligne.Calculable)
                    {
                        var l = f6004.Lignes.Single(x => x.CodeN == currentF6004Ligne.CodeN);
                        l.ValeurN = currentF6004Ligne.ValeurN;

                        l = f6004.Lignes.Single(x => x.CodeN1 == currentF6004Ligne.CodeN1);
                        l.ValeurN1 = currentF6004Ligne.ValeurN1;


                    }
                }
                this.F6004BindingSource.ResetCurrentItem();
            }

        }

        private void btExport_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog2.ShowDialog(this) == DialogResult.OK)
                this.gridView1.ExportToXlsx(saveFileDialog2.FileName);
        }

        private void btTester_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> msg = new List<string>();

                msg = _CurrentF6004.getError();

                if (msg.Count == 0)
                    XtraMessageBox.Show("Liasse Fiscale F6004 est valide ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    new XtraFrmF6004Error(msg).ShowDialog();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}