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
    public partial class XtraFrmF6304 : DevExpress.XtraEditors.XtraForm
    {
        private Core.Models.Liass.F6304 _CurrentF6304;
        private LiasseController _controller;
        public XtraFrmF6304(LiasseController controller)
        {
            _controller = controller;
            InitializeComponent();
            gridView1.CustomRowCellEdit += GridView1OnCustomRowCellEdit;
            _CurrentF6304 = controller.CurrentF6304();
            DBf6304BindingSource.DataSource = _CurrentF6304;
            var Model = new Model.F6304(_CurrentF6304);
            this.f6304BindingSource.DataSource = new Model.F6304(_CurrentF6304);
            btEnregistrer.Click += BtEnregistrer_Click;
            btExporter.Click += BtExporter_Click;
            //this.gridView1.OptionsView.RowAutoHeight = true;
            //colLibelle.AppearanceCell.TextOptions.WordWrap=WordWrap.Wrap;
            saveFileDialog1.FileName = controller.GetXmlFileName(this.DBf6304BindingSource.Current);
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
            var f6304 = this.DBf6304BindingSource.Current as Core.Models.Liass.F6304;
            _controller.Export(f6304, fileName);
        }

        private void BtEnregistrer_Click(object sender, EventArgs e)
        {
            this.f6304BindingSource.EndEdit();
            DBf6304BindingSource.EndEdit();
            var f6304 = this.f6304BindingSource.Current as Model.F6304;
            if (f6304 != null) _controller.Save(f6304.MF6304);
            _CurrentF6304 = _controller.CurrentF6304();
            DBf6304BindingSource.DataSource = _CurrentF6304;
            this.f6304BindingSource.DataSource = new Model.F6304(_CurrentF6304);
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
            var model = new Model.F6304(new F6304());
           var z = new ImportForms.F6304ImportForm(model);
            if (z.ShowDialog(this) == DialogResult.OK)
            {

                var f6304 = this.f6304BindingSource.Current as Model.F6304;
                if (f6304 == null) return;
                foreach (var currentF6304Ligne in model.Lignes)
                {
                    if (currentF6304Ligne != null && !currentF6304Ligne.Calculable)
                    {
                        var l = f6304.Lignes.Single(x => x.CodeN == currentF6304Ligne.CodeN);
                        l.ValeurN = currentF6304Ligne.ValeurN;

                        l = f6304.Lignes.Single(x => x.CodeN1 == currentF6304Ligne.CodeN1);
                        l.ValeurN1 = currentF6304Ligne.ValeurN1;

      
                    }
                }
                this.f6304BindingSource.ResetCurrentItem();
            }

        }

        private void btTester_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> msg = new List<string>();

                msg = _CurrentF6304.getError();

                if (msg.Count == 0)
                    XtraMessageBox.Show("Liasse Fiscale F6304 est valide ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    new XtraFrmF6304Error(msg).ShowDialog();

            }
            catch (Exception ex)
            {
                  throw ex;
                }
            }
    }
}