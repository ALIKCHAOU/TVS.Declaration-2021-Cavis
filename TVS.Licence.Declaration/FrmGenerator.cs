using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Rhino.Licensing;

namespace TVS.Licence.Declaration
{
    public partial class FrmGenerator : Form
    {
        public FrmGenerator()
        {
            InitializeComponent();
            dtDateExpiration.EditValue = new DateTime(DateTime.Now.Year, 12, 31);
        }

        private void btGenerer_Click(object sender, EventArgs e)
        {
            var codeClient = txtCode.Text;
            if (string.IsNullOrEmpty(codeClient))
            {
                MessageBox.Show("Code client invalide!");
                return;
            }
            if (string.IsNullOrEmpty(txtSociete.Text))
            {
                MessageBox.Show("Nom du client invalide!");
                return;
            }
            var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;
            if (dialog.SelectedPath == string.Empty) return;

            var privateKey = File.ReadAllText("privateKey.xml");
            var id = Guid.NewGuid();
            var generator = new LicenseGenerator(privateKey);
            var attributes = new Dictionary<string, string>();
            attributes.Add("MultiSocite", chMultiSociete.Checked ? "0" : "1");
            attributes.Add("Societe", txtSociete.Text);
            attributes.Add("Cnss", chCnss.Checked ? "0" : "1");
            attributes.Add("Employeur", chDeclarationEmp.Checked ? "0" : "1");
            attributes.Add("BcSuspension", chDecBc.Checked ? "0" : "1");
            attributes.Add("FcSuspension", chDecFc.Checked ? "0" : "1");
            attributes.Add("Virement", chVirementBancaire.Checked ? "0" : "1");
            attributes.Add("Liasse", txtLiasse.Checked ? "0" : "1");
            var license = generator.Generate(codeClient, id, dtDateExpiration.DateTime, attributes, LicenseType.None);

            File.WriteAllText(string.Format("{0}\\Licence {1}.tvs", dialog.SelectedPath, txtSociete.Text), license);
            MessageBox.Show("Licence générer avec succés!");
        }
    }
}