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
    public partial class XtraFrmF6003 : DevExpress.XtraEditors.XtraForm
    {
        private Core.Models.Liass.F6003 _CurrentF6003;
        private LiasseController _controller;
        public XtraFrmF6003(LiasseController controller)
        {
            _controller = controller;
            InitializeComponent();
            gridView1.CustomRowCellEdit += GridView1OnCustomRowCellEdit;
            _CurrentF6003 = controller.CurrentF6003();
            DBf6003BindingSource.DataSource = _CurrentF6003;
            var Model = new Model.F6003(_CurrentF6003);
            this.F6003BindingSource.DataSource = new Model.F6003(_CurrentF6003);
            btEnregistrer.Click += BtEnregistrer_Click;
            btExporter.Click += BtExporter_Click;
            //this.gridView1.OptionsView.RowAutoHeight = true;
            //colLibelle.AppearanceCell.TextOptions.WordWrap=WordWrap.Wrap;
            saveFileDialog1.FileName = controller.GetXmlFileName(this.DBf6003BindingSource.Current);
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
            var F6003 = this.DBf6003BindingSource.Current as Core.Models.Liass.F6003;
            _controller.Export(F6003, fileName);
        }

        private void BtEnregistrer_Click(object sender, EventArgs e)
        {
            this.F6003BindingSource.EndEdit();
            DBf6003BindingSource.EndEdit();
            var F6003 = this.F6003BindingSource.Current as Model.F6003;
            if (F6003 != null) _controller.Save(F6003.MF6003);
            _CurrentF6003 = _controller.CurrentF6003();
            DBf6003BindingSource.DataSource = _CurrentF6003;
            this.F6003BindingSource.DataSource = new Model.F6003(_CurrentF6003);
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

        private void btImport_Click(object sender, EventArgs e)
        {
            var model = new Model.F6003(new F6003());
            var z = new ImportForms.F6003ImportForm(model);
            if (z.ShowDialog(this) == DialogResult.OK)
            {

                var f6003 = this.F6003BindingSource.Current as Model.F6003;
                if (f6003 == null) return;
                foreach (var currentF6003Ligne in model.Lignes)
                {
                    if (currentF6003Ligne != null && !currentF6003Ligne.Calculable)
                    {
                        var l = f6003.Lignes.Single(x => x.CodeN == currentF6003Ligne.CodeN);
                        l.ValeurN = currentF6003Ligne.ValeurN;

                        l = f6003.Lignes.Single(x => x.CodeN1 == currentF6003Ligne.CodeN1);
                        l.ValeurN1 = currentF6003Ligne.ValeurN1;


                    }
                }
                this.F6003BindingSource.ResetCurrentItem();
            }

        }

        private void btExportExcel_Click(object sender, EventArgs e)
        {

            if (this.saveFileDialog2.ShowDialog(this) == DialogResult.OK)
                this.gridView1.ExportToXlsx(saveFileDialog2.FileName);

        }

        private void btTester_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> msg = new List<string>();

                msg = _CurrentF6003.getError();

                if (msg.Count == 0)
                    XtraMessageBox.Show("Liasse Fiscale F6003 est valide ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    new XtraFrmF6003Error(msg).ShowDialog();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}