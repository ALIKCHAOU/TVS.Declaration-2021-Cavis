using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace TVS.Declaration
{
    public partial class DeclarationCovis : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private static DeclarationCovis _DeclarationCovis;
        public static DeclarationCovis InstanceDeclarationCovis
        {
            get
            {
                if (_DeclarationCovis == null)
                    _DeclarationCovis = new DeclarationCovis();
                return _DeclarationCovis;
            }
        }
        public DeclarationCovis()
        {
            InitializeComponent();
        }

        private void DeclarationCovis_FormClosing(object sender, FormClosingEventArgs e)
        {
            _DeclarationCovis = null;
        }
    }
}