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
    public partial class XtraFrmF6005 : DevExpress.XtraEditors.XtraForm
    {
        private Core.Models.Liass.F6005 _CurrentF6005;
        private LiasseController _controller;
        public XtraFrmF6005(LiasseController controller)
        {
            _controller = controller;
            InitializeComponent();
            gridView1.CustomRowCellEdit+=GridView1OnCustomRowCellEdit;
            
            _CurrentF6005 = controller.CurrentF6005();
            DBf6005BindingSource.DataSource = _CurrentF6005;
            this.F6005BindingSource.DataSource = new Model.F6005(_CurrentF6005);
            btEnregistrer.Click += BtEnregistrer_Click;
            btExporter.Click += BtExporter_Click;
            //this.gridView1.OptionsView.RowAutoHeight = true;
            //colLibelle.AppearanceCell.TextOptions.WordWrap=WordWrap.Wrap;
            repositoryItemComboBox1.Items.Add("P");
            repositoryItemComboBox1.Items.Add("B");
            saveFileDialog1.FileName = controller.GetXmlFileName(this.DBf6005BindingSource.Current);

            string s1 = string.Empty;
            string  s = string.Empty;
            for (int i = 69; i <= 99; i++)

            {
                //s += "if (F600120" + i + " != (F600100" + i + " - F600110" + i + "))" + Environment.NewLine +
                //"msg.Add(\"F600120" + i + " est  invalide ! F600120" + i + " = F600100" + i + " - F600110" + i + "\"); " + Environment.NewLine;


                s += "if (F60051063 + F60051064 - F60051065 - F60051066 - F60051067 < 0 && F600510" + i + " != 0 )" + Environment.NewLine +
                "msg.Add(\"F600510" + i + " est  invalide ! F60051063 + F60051064 - F60051065 - F60051066 - F60051067 <0 et F600510" + i + " != 0 \"); " + Environment.NewLine;

              


                //if (F60051955 < 0 || F60051057 != 0)
                //    msg.Add("F60051057 est  invalide ! F60051955 >= 0 Ou F60051057 = 0");

                //if (F60051063 + F60051064 - F60051065 < 0 && F60051066 != 0)
                //    msg.Add("F60051066 est  invalide !   F60051063 + F60051064 - F60051065 <0 et F60051066 !=0");



            }
            s1 = s;
        }

        private void GridView1OnCustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            //Application.DoEvents();
            GridView view = sender as GridView;
            if (view != null)
            {
                int selectedRowIndex = view.GetSelectedRows().First();
                var rowObject = view.GetRow(selectedRowIndex) as Model.LigneLiasse;
                if (rowObject != null && Type.GetTypeCode(rowObject.ValeurN1.GetType()) == TypeCode.Decimal&&(e.Column.Equals(colValeurN)|| e.Column.Equals(colValeurN1))) e.RepositoryItem = this.repositoryItemSpinEdit1;
                else if (rowObject != null && Type.GetTypeCode(rowObject.ValeurN1.GetType()) == TypeCode.String &&
                         (e.Column.Equals(colValeurN) || e.Column.Equals(colValeurN1)))
                {
                    //repositoryItemComboBox1.Items.Clear();
                    //repositoryItemComboBox1.Items.Add(rowObject.Options);
                    e.RepositoryItem = repositoryItemComboBox1;

                }
            }
            //Application.DoEvents();
        }private void BtExporter_Click(object sender, EventArgs e)
        {
            BtEnregistrer_Click(null, null);
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK) return;
            var fileName = saveFileDialog1.FileName;
            var F6005 = this.DBf6005BindingSource.Current as Core.Models.Liass.F6005;
            _controller.Export(F6005, fileName);
        }

        private void BtEnregistrer_Click(object sender, EventArgs e)
        {
            this.F6005BindingSource.EndEdit();
            DBf6005BindingSource.EndEdit();
            var F6005 = this.F6005BindingSource.Current as  Model.F6005;
            if (F6005 != null) _controller.Save(F6005.MF6005);
            _CurrentF6005 = _controller.CurrentF6005();
            DBf6005BindingSource.DataSource = _CurrentF6005;this.F6005BindingSource.DataSource = new Model.F6005(_CurrentF6005);
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
            var model = new Model.F6005(new Core.Models.Liass.F6005());
            var z = new ImportForms.F6005ImportForm(model);
            if (z.ShowDialog(this) == DialogResult.OK)
            {

                var f6005 = this.F6005BindingSource.Current as Model.F6005;
                if (f6005 == null) return;
                foreach (var currentF6005 in model.Lignes)
                {
                    if (currentF6005 != null && !currentF6005.Calculable)
                    {
                        var l = f6005.Lignes.Single(x => x.CodeN == currentF6005.CodeN);
                        l.ValeurN = currentF6005.ValeurN;

                        l = f6005.Lignes.Single(x => x.CodeN1 == currentF6005.CodeN1);
                        l.ValeurN1 = currentF6005.ValeurN1;


                    }
                }
                this.F6005BindingSource.ResetCurrentItem();
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

                msg = _CurrentF6005.getError();

                if (msg.Count == 0)
                    XtraMessageBox.Show("Liasse Fiscale F6005 est valide ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    new XtraFrmF6005Error(msg).ShowDialog();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}