using DevExpress.XtraEditors;

namespace TVS.Declaration
{
    public partial class FrmApropos : XtraForm
    {
        private const string Version = "Gestion des déclarations, version : r001.10042017";

        public FrmApropos()
        {
            InitializeComponent();
            lblVersion.Text = Version;
            Icon = Properties.Resources.log22;
            lbSociete.Text = string.Format("Société : {0}", "AMEN CONSEIL");
            lbDateExpiration.Text = string.Format("Date expération {0:dd/MM/yyyy}", Program.DateExpiration);
            lbTunis.Text = "Golden Estates-9 ème étage App D7-D8 - Centre Urbain Nord-1082 Tunis Tunisie";
            lbSfax.Text = "Route Gabes, Km3 Immeuble SOTEME 1er étage-3052 Sfax Tunisie";
            lbTel.Text = " +216 71 428 073 - +216 74 281 223";
            lbFax.Text = " +216 71 428 135 - +216 74 452 352";
            lbEmail.Text = " contact@amenconseil.com";
        }
    }
}