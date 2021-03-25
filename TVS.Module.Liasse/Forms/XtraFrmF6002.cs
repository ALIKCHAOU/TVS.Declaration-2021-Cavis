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
    public partial class XtraFrmF6002 : DevExpress.XtraEditors.XtraForm
    {
        private Core.Models.Liass.F6002 _CurrentF6002;
        private LiasseController _controller;
        public XtraFrmF6002(LiasseController controller)
        {
            _controller = controller;
            InitializeComponent();
            gridView1.CustomRowCellEdit += GridView1OnCustomRowCellEdit;
            _CurrentF6002 = controller.CurrentF6002();
            DBf6002BindingSource.DataSource = _CurrentF6002;
            var Model = new Model.F6002(_CurrentF6002);
            this.f6002BindingSource.DataSource = new Model.F6002(_CurrentF6002);
            btEnregistrer.Click += BtEnregistrer_Click;
            btExporter.Click += BtExporter_Click;
            //this.gridView1.OptionsView.RowAutoHeight = true;
            //colLibelle.AppearanceCell.TextOptions.WordWrap=WordWrap.Wrap;
            saveFileDialog1.FileName = controller.GetXmlFileName(this.DBf6002BindingSource.Current);
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
            var f6002 = this.DBf6002BindingSource.Current as Core.Models.Liass.F6002;
            _controller.Export(f6002, fileName);
        }

        private void BtEnregistrer_Click(object sender, EventArgs e)
        {
            this.f6002BindingSource.EndEdit();
            DBf6002BindingSource.EndEdit();
            var f6002 = this.f6002BindingSource.Current as Model.F6002;
            if (f6002 != null) _controller.Save(f6002.Mf6002);
            _CurrentF6002 = _controller.CurrentF6002();
            DBf6002BindingSource.DataSource = _CurrentF6002;
            this.f6002BindingSource.DataSource = new Model.F6002(_CurrentF6002);
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
            var model = new Model.F6002(new F6002());
           var z = new ImportForms.F6002ImportForm(model);
            if (z.ShowDialog(this) == DialogResult.OK)
            {

                var f6002 = this.f6002BindingSource.Current as Model.F6002;
                if (f6002 == null) return;
                foreach (var currentF6002Ligne in model.Lignes)
                {
                    if (currentF6002Ligne != null && !currentF6002Ligne.Calculable)
                    {
                        var l = f6002.Lignes.Single(x => x.CodeN == currentF6002Ligne.CodeN);
                        l.ValeurN = currentF6002Ligne.ValeurN;

                        l = f6002.Lignes.Single(x => x.CodeN1 == currentF6002Ligne.CodeN1);
                        l.ValeurN1 = currentF6002Ligne.ValeurN1;

      
                    }
                }
                this.f6002BindingSource.ResetCurrentItem();
            }

        }

        private void btTester_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> msg = new List<string>();

                msg = _CurrentF6002.getError();

                if (msg.Count == 0)
                    XtraMessageBox.Show("Liasse Fiscale F6002 est valide ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    new XtraFrmF6002Error(msg).ShowDialog();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}