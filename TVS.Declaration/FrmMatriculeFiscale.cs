using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using TVS.Config.Helpers;

namespace TVS.Declaration
{
    public partial class FrmMatriculeFiscale : Form
    {
        public FrmMatriculeFiscale()
        {
            InitializeComponent();
            txtIdentiteBancaire.EditValueChanged += IdentiteChanged;
        }
        private void IdentiteChanged(object sender, EventArgs e)
        {
            if (txtIdentiteBancaire.EditValue == null)
            {
                txtCleRib.Text = string.Empty;
                return;
            }
            if (string.IsNullOrEmpty(txtIdentiteBancaire.EditValue.ToString()))
            {
                txtCleRib.Text = string.Empty;
                return;
            }
            if (txtIdentiteBancaire.EditValue.ToString().Trim().Length != 18)
            {
                txtCleRib.Text = string.Empty;
                return;
            }
            txtCleRib.Text = NumeriqueHelper.GetMatriculeCleRib(txtIdentiteBancaire.EditValue.ToString());
        }
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (txtMatricule.EditValue == null)
            {
                txtCle.Text = string.Empty;
                return;
            }
            if (string.IsNullOrEmpty(txtMatricule.EditValue.ToString()))
            {
                txtCle.Text = string.Empty;
                return;
            }
            if (txtMatricule.EditValue.ToString().Trim().Length != 7)
            {
                txtCle.Text = string.Empty;
                return;
            }
            txtCle.Text = NumeriqueHelper.GetMatriculeCle(txtMatricule.EditValue.ToString());
        }

        private void btVerifier_Click(object sender, EventArgs e)
        {
            var result = VerifierMatricule();
            if (result)
            {
                XtraMessageBox.Show("Matricule fiscal est vérifier", "AMEN CONSEIL", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Matricule fiscal invalide", "AMEN CONSEIL", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool VerifierMatricule()
        {
            if (txtMatriculFiscale.EditValue == null)
            {
                return false;
            }
            return NumeriqueHelper.ValiderMatricule(txtMatriculFiscale.Text.Trim());
        }
    }
}