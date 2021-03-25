using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;

namespace TVS.Module.Liasse.Forms
{
    public partial class XtraFrmF6304Error : DevExpress.XtraEditors.XtraForm
    {

        private List<string> _msg = new List<string>();

        public XtraFrmF6304Error(List<string> msg )
        {
            _msg = msg;

            InitializeComponent();
        }

        private void btFermer_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void XtraFrmF6001Error_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = _msg;
            gridView1.Columns[0].FieldName = "Erreur";
            gridView1.Appearance.Row.ForeColor = Color.Red;
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());

            link.Component = gridControl1;
            link.PaperKind = System.Drawing.Printing.PaperKind.A4;
            link.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            link.Landscape = true;

            link.ShowPreview();
        }
    }
}