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
    public partial class XtraFrmF6303 : DevExpress.XtraEditors.XtraForm
    {
        private Core.Models.Liass.F6303 _CurrentF6303;
        private LiasseController _controller;
        public XtraFrmF6303(LiasseController controller)
        {
            _controller = controller;
            InitializeComponent();
            gridView1.CustomRowCellEdit += GridView1OnCustomRowCellEdit;
            _CurrentF6303 = controller.CurrentF6303();
            DBf6303BindingSource.DataSource = _CurrentF6303;
            var Model = new Model.F6303(_CurrentF6303);
            this.f6303BindingSource.DataSource = new Model.F6303(_CurrentF6303);
            btEnregistrer.Click += BtEnregistrer_Click;
            btExporter.Click += BtExporter_Click;
            //this.gridView1.OptionsView.RowAutoHeight = true;
            //colLibelle.AppearanceCell.TextOptions.WordWrap=WordWrap.Wrap;
            saveFileDialog1.FileName = controller.GetXmlFileName(this.DBf6303BindingSource.Current);
        }

        private void GridView1OnCustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null)
            {
                int selectedRowIndex = view.GetSelectedRows().First();
                var rowObject = view.GetRow(selectedRowIndex) as Model.LigneLiasse;
                if (rowObject != null && Type.GetTypeCode(rowObject.TypeValeurs) == TypeCode.Decimal && e.Column.Name.Contains("Valeur"))
                    e.RepositoryItem = this.repositoryItemSpinEdit1;
            }
        }
        private void BtExporter_Click(object sender, EventArgs e)
        {
            BtEnregistrer_Click(null, null);
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK) return;
            var fileName = saveFileDialog1.FileName;
            var f6303 = this.DBf6303BindingSource.Current as Core.Models.Liass.F6303;
            _controller.Export(f6303, fileName);
        }

        private void BtEnregistrer_Click(object sender, EventArgs e)
        {
            this.f6303BindingSource.EndEdit();
            DBf6303BindingSource.EndEdit();
            var f6303 = this.f6303BindingSource.Current as Model.F6303;
            if (f6303 != null) _controller.Save(f6303.MF6303);
            _CurrentF6303 = _controller.CurrentF6303();
            DBf6303BindingSource.DataSource = _CurrentF6303;
            this.f6303BindingSource.DataSource = new Model.F6303(_CurrentF6303);
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
                if (rowObject != null && rowObject.Calculable) e.Cancel = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.gridView1.ShowRibbonPrintPreview();
        }

        private void btExportExcel_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog2.ShowDialog(this) == DialogResult.OK)
                this.gridView1.ExportToXlsx(saveFileDialog2.FileName);
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            var model = new Model.F6303(new F6303());
           var z = new ImportForms.F6303ImportForm(model);
            if (z.ShowDialog(this) == DialogResult.OK)
            {

                var f6303 = this.f6303BindingSource.Current as Model.F6303;
                if (f6303 == null) return;
                foreach (var currentF6303Ligne in model.Lignes)
                {
                    if (currentF6303Ligne != null && !currentF6303Ligne.Calculable)
                    {
                        var l = f6303.Lignes.Single(x => x.CodeN == currentF6303Ligne.CodeN);
                        l.ValeurN = currentF6303Ligne.ValeurN;

                        l = f6303.Lignes.Single(x => x.CodeN1 == currentF6303Ligne.CodeN1);
                        l.ValeurN1 = currentF6303Ligne.ValeurN1;

      
                    }
                }
                this.f6303BindingSource.ResetCurrentItem();
            }

        }

        private void btTester_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> msg = new List<string>();

                msg = _CurrentF6303.getError();

                if (msg.Count == 0)
                    XtraMessageBox.Show("Liasse Fiscale F6303 est valide ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    new XtraFrmF6303Error(msg).ShowDialog();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}