using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.DataAccess.Native.Excel;
using DevExpress.DataAccess.UI.Excel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using TVS.Core.Models.Liass;

namespace TVS.Module.Liasse.Forms
{
    public partial class XtraFrmF6001 : DevExpress.XtraEditors.XtraForm
    {
        private Core.Models.Liass.F6001 _CurrentF6001;
        private LiasseController _controller;
        public XtraFrmF6001(LiasseController controller)
        {
            _controller = controller;
            InitializeComponent();
            gridView1.CustomRowCellEdit+=GridView1OnCustomRowCellEdit;
            _CurrentF6001= controller.CurrentF6001();
            var Model= new Model.F6001(_CurrentF6001);
            this.DBf6001BindingSource.DataSource = _CurrentF6001;
            this.f6001BindingSource.DataSource = new Model.F6001(_CurrentF6001);
            btEnregistrer.Click += BtEnregistrer_Click;
            btExporter.Click += BtExporter_Click;
            //this.gridView1.OptionsView.RowAutoHeight = true;
            //colLibelle.AppearanceCell.TextOptions.WordWrap=WordWrap.Wrap;
            saveFileDialog1.FileName = controller.GetXmlFileName(this.DBf6001BindingSource.Current);
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
            var f6001 = this.DBf6001BindingSource.Current as Core.Models.Liass.F6001;
            _controller.Export(f6001, fileName);

        }

        private void BtEnregistrer_Click(object sender, EventArgs e)
        {
            this.f6001BindingSource.EndEdit();
            this.DBf6001BindingSource.EndEdit();
            var f6001 = this.f6001BindingSource.Current as  Model.F6001;if (f6001 != null) _controller.Save(f6001.Mf6001);
            _CurrentF6001 = _controller.CurrentF6001();
            this.DBf6001BindingSource.DataSource = _CurrentF6001;
            this.f6001BindingSource.DataSource = new Model.F6001(_CurrentF6001);
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
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());

            link.Component =this.gridControl1;
            link.Landscape = true;
            link.Margins= new Margins(20,20,20,20);
            link.PaperKind = PaperKind.A4;
            link.ShowPreview();
            //this.gridView1.ShowRibbonPrintPreview();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
           if(this.saveFileDialog2.ShowDialog(this)==DialogResult.OK)
            this.gridView1.ExportToXlsx(saveFileDialog2.FileName);
        }

        private void ImportExcelsimpleButton_Click(object sender, EventArgs e)
        {
            var model= new Model.F6001(new F6001());
            var z = new ImportForms.F6001ImportForm(model);
            if (z.ShowDialog(this) == DialogResult.OK)
            {
               
                var f6001 = this.f6001BindingSource.Current as Model.F6001;
                if (f6001 == null) return;
                foreach (var currentF6001Ligne in model.Lignes)
                {
                    if (currentF6001Ligne != null && !currentF6001Ligne.Calculable)
                    {
                        var l = f6001.Lignes.Single(x => x.CodeB == currentF6001Ligne.CodeB);
                        l.ValeurB = currentF6001Ligne.ValeurB;

                        l = f6001.Lignes.Single(x => x.CodeAmortissement == currentF6001Ligne.CodeAmortissement);
                        l.ValeurAmortissement = currentF6001Ligne.ValeurAmortissement;

                        l = f6001.Lignes.Single(x => x.CodeN1 == currentF6001Ligne.CodeN1);
                        l.ValeurN1 = currentF6001Ligne.ValeurAmortissement;
                    }
                }
                this.f6001BindingSource.ResetCurrentItem();
            }
        }

        private void btTester_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> msg = new List<string>();

                msg = _CurrentF6001.getError();

                if (msg.Count == 0)
                    XtraMessageBox.Show("Liasse Fiscale F6001 est valide ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    new XtraFrmF6001Errorr(msg).ShowDialog();

            }
            catch (Exception ex )
            {

                throw ex;
            }
        }
    }
}