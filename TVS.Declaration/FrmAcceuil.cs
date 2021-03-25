using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using TVS.Config.Modules;

namespace TVS.Declaration
{
    public partial class FrmAcceuil : Form
    {
        public FrmAcceuil()
        {
            InitializeComponent();
            FormClosing += FrmAcceuil_FormClosing;
            tiSetting.ItemClick += tiSetting_ItemClick;
            tiExerciceEncours.ItemClick += tiExerciceEncours_ItemClick;
            tiApropos.ItemClick += tiApropos_ItemClick;
            tiVirementBancaire.ItemClick += DeclarationVirementItemClick;
            tiFcsuspension.ItemClick += DeclarationFcItemClick;
            tiDeclarationBC.ItemClick += DeclarationBcItemClick;
            tiDeclarationCnss.ItemClick += DeclarationCnssItemClick;
            tiDecEmp.ItemClick += DeclarationEmpItemClick;
            tiLiasse.ItemClick += DeclarationLiasseItemClick;
            tiCovis.ItemClick += DeclarationCovisItemClick;
            if (!Program.IsVirement)
                LicenseInvalideLayout(tiVirementBancaire);
            else
            {
                if(!Program.Context.User.Virement)
                {
                    AuthorisationdeLayout(tiVirementBancaire);
                }
            }
            if (!Program.IsCnss)
                LicenseInvalideLayout(tiDeclarationCnss);
            else
            {
                if (!Program.Context.User.Cnss)
                {
                    AuthorisationdeLayout(tiDeclarationCnss);
                }
            }
            if (!Program.IsEmp)
                LicenseInvalideLayout(tiDecEmp);
            else
            {
                if (!Program.Context.User.DecEmp)
                {
                    AuthorisationdeLayout(tiDecEmp);
                }
            }
            if (!Program.IsDecBc)
                LicenseInvalideLayout(tiDeclarationBC);
            else
            {
                if (!Program.Context.User.Achat)
                {
                    AuthorisationdeLayout(tiDeclarationBC);
                }
            }
            if (!Program.IsDecFc)
                LicenseInvalideLayout(tiFcsuspension);
            else
            {
                if (!Program.Context.User.Vente)
                {
                    AuthorisationdeLayout(tiFcsuspension);
                }
            }

            if (!Program.IsLiasse)
                LicenseInvalideLayout(tiLiasse);
            else
            {
                if (!Program.Context.User.Liasse)
                {
                    AuthorisationdeLayout(tiLiasse);
                }
            }
        }


        void LicenseInvalideLayout(TileItem item)
        {
            item.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkGray;
            item.AppearanceItem.Normal.Options.UseBackColor = true;
            item.Tag = 0;
        }
        void AuthorisationdeLayout(TileItem item)
        {
            item.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkSlateGray;
            item.AppearanceItem.Normal.Options.UseBackColor = true;
            item.Tag = 0;
        }
        public void FrmAcceuil_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void tiApropos_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var frm = new FrmApropos();
            frm.ShowDialog();
        }

        private void tiExerciceEncours_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var frmMain = this.MdiParent as FrmMain;
            if (frmMain == null) return;
            frmMain.btnEncourExercice_ItemClick(null, null);
        }

        private void tiSetting_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var frmMain = this.MdiParent as FrmMain;
            if (frmMain == null) return;
            frmMain.btnParametre_ItemClick(null, null);
        }

        private void DeclarationCnssItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var frmMain = this.MdiParent as FrmMain;
            if (frmMain == null) return;
            if (!Program.IsCnss)
            {
                XtraMessageBox.Show("Licence invalide!", "AMEN CONSEIL", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            frmMain.SelectedPage(TypeModule.Cnss);
          
        }

        private void DeclarationEmpItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var frmMain = this.MdiParent as FrmMain;
            if (frmMain == null) return;
            if (!Program.IsEmp)
            {
                XtraMessageBox.Show("Licence invalide!", "AMEN CONSEIL", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }
            frmMain.SelectedPage(TypeModule.DecEmp);
            
        }
        private void DeclarationLiasseItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var frmMain = this.MdiParent as FrmMain;
            if (frmMain == null) return;
            if (!Program.IsLiasse)
            {
                XtraMessageBox.Show("Licence invalide!", "AMEN CONSEIL", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }
            frmMain.SelectedPage(TypeModule.Liasse);

        }
        private void DeclarationBcItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var frmMain = this.MdiParent as FrmMain;
            if (frmMain == null) return;
            if (!Program.IsDecBc)
            {
                XtraMessageBox.Show("Licence invalide!", "AMEN CONSEIL", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            frmMain.SelectedPage(TypeModule.BcSuspension);
            
        }

        private void DeclarationFcItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var frmMain = this.MdiParent as FrmMain;
            if (frmMain == null) return;
            ;
            if (!Program.IsDecFc)
            {
                XtraMessageBox.Show("Licence invalide!", "AMEN CONSEIL", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
                frmMain.SelectedPage(TypeModule.FcSuspension);
            
        }
        private void DeclarationCovisItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var frmMain = this.MdiParent as FrmMain;
            if (frmMain == null) return;
            //if (!Program.IsCovis)
            //{
            //    XtraMessageBox.Show("Licence invalide!", "AMEN CONSEIL", MessageBoxButtons.OK,
            //        MessageBoxIcon.Information);
            //    return;
            //}
            // frmMain.SelectedPage(TypeModule.Covis);
        
            Formshow(DeclarationCovis.InstanceDeclarationCovis);
        }
        public void Formshow(Form frm)
        {
            //// waiting Form
            //SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
            //SplashScreenManager.Default.SetWaitFormCaption("Veuillez Patienter ....");
            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.Sleep(10);
            //}
            //SplashScreenManager.CloseForm();
            ////waiting Form
            var frmMain = this.MdiParent as FrmMain;
            frm.MdiParent = frmMain;
            frm.Show();
            frm.Activate();
        }


        private void DeclarationVirementItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var frmMain = this.MdiParent as FrmMain;
            if (frmMain == null) return;
            if (!Program.IsVirement)
            {
                XtraMessageBox.Show("Licence invalide!", "AMEN CONSEIL", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            frmMain.SelectedPage(TypeModule.VirementBancaire);
        }

        private void tiVirementBancaire_ItemClick(object sender, TileItemEventArgs e)
        {

        }

        private void tiVirementBancaire_ItemClick_1(object sender, TileItemEventArgs e)
        {

        }

       
    }
}