namespace TVS.Declaration
{
    public partial class FrmInvalidLicence : DevExpress.XtraEditors.XtraForm
    {
        public FrmInvalidLicence()
        {
            InitializeComponent();
            txtCode.Text = GeneratorCode.Value();
        }
    }
}