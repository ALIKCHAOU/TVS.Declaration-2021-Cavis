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

namespace TVS.Declaration
{
    public partial class FrmCovis : DevExpress.XtraEditors.XtraForm
    {
        private static FrmCovis _FrmCovis;
        public static FrmCovis InstanceFrmCovis
        {
            get
            {
                if (_FrmCovis == null)
                    _FrmCovis = new FrmCovis();
                return _FrmCovis;
            }
        }
        public FrmCovis()
        {
            InitializeComponent();
        }

        private void FrmCovis_Load(object sender, EventArgs e)
        {

        }

        private void FrmCovis_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmCovis=null;
        }
    }
}