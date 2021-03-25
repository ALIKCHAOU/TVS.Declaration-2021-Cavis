using DevExpress.XtraEditors.Controls;
using DevExpress.XtraWaitForm;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TVS.Declaration
{
    public partial class FrmLoading : Form
    {
        private readonly ProgressPanel _waitControl = new ProgressPanel();
        private string _caption;
        private string _description;

        public FrmLoading()
        {
            InitializeComponent();

            Load += WaitFormLoad;
        }

        public string Caption
        {
            get { return _caption; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                if (value == _caption) return;
                _caption = value;
                _waitControl.Caption = _caption;
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                if (value == _description) return;
                _description = value;
                _waitControl.Description = _description;
            }
        }

        private void WaitFormLoad(object sender, EventArgs e)
        {
            InitWaitControl();
        }

        private void InitWaitControl()
        {
            //Initialiser panelWaitDatabase
            _waitControl.LookAndFeel.UseDefaultLookAndFeel = false;
            _waitControl.Location = new Point(0, 0);
            _waitControl.Dock = DockStyle.Fill;
            _waitControl.BorderStyle = BorderStyles.Office2003;
            Controls.Add(_waitControl);
        }
    }
}