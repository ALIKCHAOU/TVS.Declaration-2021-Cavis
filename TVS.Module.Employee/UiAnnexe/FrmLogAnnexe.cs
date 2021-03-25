using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TVS.Module.Employee.UiAnnexe
{
    public partial class FrmLogAnnexe : XtraForm
    {
        private readonly StringBuilder _logErreur;
        private string _fileName;

        public FrmLogAnnexe()
        {
            InitializeComponent();
            
            btnExporter.Click += Exporter;
            _logErreur = new StringBuilder();
            InitControl();
        }

        private void InitControl()
        {
            txtLog.Properties.ReadOnly = true;
            var fontFamily = txtLog.Properties.Appearance.Font.FontFamily;
            txtLog.Properties.Appearance.Font = new Font(fontFamily, 10, FontStyle.Regular);
            txtLog.Properties.Appearance.ForeColor = Color.Black;
            txtLog.Properties.Appearance.Options.UseForeColor = true;
            txtLog.Properties.Appearance.BackColor = Color.White;
            txtLog.Properties.Appearance.Options.UseBackColor = true;
        }

        public void SetAnnexeErreur(string erreurText, string text)
        {
            if (string.IsNullOrEmpty(erreurText))
                throw new ArgumentNullException(nameof(erreurText));
            _fileName = string.IsNullOrEmpty(text) ? "Annexe erreur" : string.Format("Erreur {0}", text);
            Text = _fileName;
            _logErreur.AppendLine(erreurText);
            txtLog.EditValue = _logErreur.ToString();
            InitControl();
        }


        private void Exporter(object sender, EventArgs e)
        {
            try
            {
                // verifier qu'il y a des erreurs
                if (string.IsNullOrEmpty(_logErreur.ToString())) return;
                // exporter les erreurs
                var saveFileDialog = new SaveFileDialog
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                    DefaultExt = ".txt",
                    Filter = @"(*.txt)|*.txt;",
                    FileName = _fileName
                };
                var result = saveFileDialog.ShowDialog();
                if (result != DialogResult.OK) return;
                // get path
                var path = saveFileDialog.FileName;
                if (string.IsNullOrEmpty(path))
                    throw new ArgumentException("Emplacement invalide!");
                // write file log
                using (var stramWriter = new StreamWriter(path))
                {
                    stramWriter.WriteLine(_logErreur);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // fermer la fenetre
            Close();
        }
    }
}