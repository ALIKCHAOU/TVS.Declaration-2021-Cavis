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
    public partial class XtraFrmF6301 : DevExpress.XtraEditors.XtraForm
    {
        private Core.Models.Liass.F6301 _CurrentF6301;
        private LiasseController _controller;
        public XtraFrmF6301(LiasseController controller)
        {
            _controller = controller;
            InitializeComponent();
            gridView1.CustomRowCellEdit += GridView1OnCustomRowCellEdit;
            _CurrentF6301 = controller.CurrentF6301();
            DBf6301BindingSource.DataSource = _CurrentF6301;
            var Model = new Model.F6301(_CurrentF6301);
            this.f6301BindingSource.DataSource = new Model.F6301(_CurrentF6301);
            btEnregistrer.Click += BtEnregistrer_Click;
            btExporter.Click += BtExporter_Click;
            //this.gridView1.OptionsView.RowAutoHeight = true;
            //colLibelle.AppearanceCell.TextOptions.WordWrap=WordWrap.Wrap;
            saveFileDialog1.FileName = controller.GetXmlFileName(this.DBf6301BindingSource.Current);
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
            var f6301 = this.DBf6301BindingSource.Current as Core.Models.Liass.F6301;
            _controller.Export(f6301, fileName);
        }

        private void BtEnregistrer_Click(object sender, EventArgs e)
        {
            this.f6301BindingSource.EndEdit();
            DBf6301BindingSource.EndEdit();
            var f6301 = this.f6301BindingSource.Current as Model.F6301;
            if (f6301 != null) _controller.Save(f6301.MF6301);
            _CurrentF6301 = _controller.CurrentF6301();
            DBf6301BindingSource.DataSource = _CurrentF6301;
            this.f6301BindingSource.DataSource = new Model.F6301(_CurrentF6301);
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
            var model = new Model.F6301(new F6301());
           var z = new ImportForms.F6301ImportForm(model);
            if (z.ShowDialog(this) == DialogResult.OK)
            {

                var f6301 = this.f6301BindingSource.Current as Model.F6301;
                if (f6301 == null) return;
                foreach (var currentF6301Ligne in model.Lignes)
                {
                    if (currentF6301Ligne != null && !currentF6301Ligne.Calculable)
                    {
                        var l = f6301.Lignes.Single(x => x.CodeN == currentF6301Ligne.CodeN);
                        l.ValeurN = currentF6301Ligne.ValeurN;

                        l = f6301.Lignes.Single(x => x.CodeN1 == currentF6301Ligne.CodeN1);
                        l.ValeurN1 = currentF6301Ligne.ValeurN1;

      
                    }
                }
                this.f6301BindingSource.ResetCurrentItem();
            }

        }

        private void btTester_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> msg = new List<string>();

                msg = _CurrentF6301.getError();

                if (msg.Count == 0)
                    XtraMessageBox.Show("Liasse Fiscale F6301 est valide ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    new XtraFrmF6301Error(msg).ShowDialog();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}