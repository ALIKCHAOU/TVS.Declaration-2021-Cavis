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

namespace TVS.Module.Liasse.Forms
{
    public partial class XtraFrmF6001Error : DevExpress.XtraEditors.XtraForm
    {

        private List<string> _msg = new List<string>();

        public XtraFrmF6001Error(List<string> msg )
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
    }
}