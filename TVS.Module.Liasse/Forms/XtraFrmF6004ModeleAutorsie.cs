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

namespace TVS.Module.Liasse.Forms
{
    public partial class XtraFrmF6004ModeleAutorsie : DevExpress.XtraEditors.XtraForm
    {
        private Core.Models.Liass.F6004ModeleAutorsie _CurrentF6004ModeleAutorsie;
        private LiasseController _controller;
        public XtraFrmF6004ModeleAutorsie(LiasseController controller)
        {
            _controller = controller;
            InitializeComponent();
            gridView1.CustomRowCellEdit += GridView1OnCustomRowCellEdit;
            _CurrentF6004ModeleAutorsie = controller.CurrentF6004ModeleAutorsie();
            DBf6004BindingSource.DataSource = _CurrentF6004ModeleAutorsie;
            this.F6004ModeleAutorsieBindingSource.DataSource = new Model.F6004ModeleAutorsie(_CurrentF6004ModeleAutorsie);
            btEnregistrer.Click += BtEnregistrer_Click;
            btExporter.Click += BtExporter_Click;
            //this.gridView1.OptionsView.RowAutoHeight = true;
            //colLibelle.AppearanceCell.TextOptions.WordWrap=WordWrap.Wrap;
            saveFileDialog1.FileName = controller.GetXmlFileName(this.F6004ModeleAutorsieBindingSource.Current).Replace("ModeleAutorsie", "");
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
            var fileName = saveFileDialog1.FileName.Replace("ModeleAutorsie", "");
            var F6004ModeleAutorsie = this.DBf6004BindingSource.Current as Core.Models.Liass.F6004ModeleAutorsie;
            _controller.Export(F6004ModeleAutorsie, fileName);
        }

        private void BtEnregistrer_Click(object sender, EventArgs e)
        {
            this.F6004ModeleAutorsieBindingSource.EndEdit();
            DBf6004BindingSource.EndEdit();
            var F6004ModeleAutorsie = this.F6004ModeleAutorsieBindingSource.Current as Model.F6004ModeleAutorsie;
            if (F6004ModeleAutorsie != null) _controller.Save(F6004ModeleAutorsie.MF6004ModeleAutorsie);
            _CurrentF6004ModeleAutorsie = _controller.CurrentF6004ModeleAutorsie();
            DBf6004BindingSource.DataSource = _CurrentF6004ModeleAutorsie;
            this.F6004ModeleAutorsieBindingSource.DataSource = new Model.F6004ModeleAutorsie(_CurrentF6004ModeleAutorsie);
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

        private void XtraFrmF6004ModeleAutorsie_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.gridView1.ShowRibbonPrintPreview();
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            var model = new Model.F6004ModeleAutorsie(new Core.Models.Liass.F6004ModeleAutorsie());
            var z = new ImportForms.F6004ImportFormModeleAutorsie(model);
            if (z.ShowDialog(this) == DialogResult.OK)
            {
                
                var f6004MA = this.F6004ModeleAutorsieBindingSource.Current as Model.F6004ModeleAutorsie;
                if (f6004MA == null) return;
                foreach (var currentF6004LigneMA in model.Lignes)
                {
                    if (currentF6004LigneMA != null && !currentF6004LigneMA.Calculable)
                    {
                        var l = f6004MA.Lignes.Single(x => x.CodeN == currentF6004LigneMA.CodeN);
                        l.ValeurN = currentF6004LigneMA.ValeurN;

                        l = f6004MA.Lignes.Single(x => x.CodeN1 == currentF6004LigneMA.CodeN1);
                        l.ValeurN1 = currentF6004LigneMA.ValeurN1;


                    }
                }
                this.F6004ModeleAutorsieBindingSource.ResetCurrentItem();
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

                msg = _CurrentF6004ModeleAutorsie.getError();

                if (msg.Count == 0)
                    XtraMessageBox.Show("Liasse Fiscale F6004ModeleAutorsie est valide ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    new XtraFrmF6004ModeleAutoriseError(msg).ShowDialog();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}