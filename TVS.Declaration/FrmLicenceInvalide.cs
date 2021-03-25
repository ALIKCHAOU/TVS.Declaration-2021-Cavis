using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TVS.Declaration
{
    public partial class FrmLicenceInvalide : XtraForm
    {
        private const string Version = "Gestion des déclaration, version : r001.07032017";

        public FrmLicenceInvalide()
        {
            InitializeComponent();
            lblVersion.Text = Version;
            Icon = Properties.Resources.log22;
            txtCode.Text = GeneratorCode.Value();
            lbTunis.Text = "Golden Estates-9 ème étage App D7-D8 - Centre Urbain Nord-1082 Tunis Tunisie";
            lbSfax.Text = "Route Gabes, Km3 Immeuble SOTEME 1er étage-3052 Sfax Tunisie";
            lbTel.Text = " +216 71 428 073";
            lbFax.Text = " +216 71 428 135";
            lbEmail.Text = " contact@amenconseil.com";
        }

        private void BtFermer_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btLicence_Click(object sender, System.EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory =
                    Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = @"(*.tvs)|*.tvs;"
            };

            if (openFileDialog.ShowDialog(this) != DialogResult.OK) return;

            var file = openFileDialog.FileName;
            string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

            //once you have the path you get the directory with:
            var directory = System.IO.Path.GetDirectoryName(path);
            if (directory == null) return;

            File.Copy(file, string.Format("{0}\\lic.tvs", AppDomain.CurrentDomain.BaseDirectory), true);
            Application.Restart();
            Close();
        }
    }
}