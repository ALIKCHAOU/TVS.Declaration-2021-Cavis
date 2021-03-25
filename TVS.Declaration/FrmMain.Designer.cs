namespace TVS.Declaration
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.rbMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.btnParametrage = new DevExpress.XtraBars.BarButtonItem();
            this.btnParametre = new DevExpress.XtraBars.BarButtonItem();
            this.btnApropos = new DevExpress.XtraBars.BarButtonItem();
            this.btnFermer = new DevExpress.XtraBars.BarButtonItem();
            this.btnExerciceEncours = new DevExpress.XtraBars.BarButtonItem();
            this.btnMatriculeFiscale = new DevExpress.XtraBars.BarButtonItem();
            this.rbFichier = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbParametrage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rbMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbMain
            // 
            this.rbMain.ApplicationButtonDropDownControl = this.applicationMenu1;
            this.rbMain.ApplicationIcon = ((System.Drawing.Bitmap)(resources.GetObject("rbMain.ApplicationIcon")));
            this.rbMain.ExpandCollapseItem.Id = 0;
            this.rbMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbMain.ExpandCollapseItem,
            this.btnParametrage,
            this.btnParametre,
            this.btnApropos,
            this.btnFermer,
            this.btnExerciceEncours,
            this.btnMatriculeFiscale});
            this.rbMain.Location = new System.Drawing.Point(0, 0);
            this.rbMain.MaxItemId = 9;
            this.rbMain.Name = "rbMain";
            this.rbMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbFichier});
            this.rbMain.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2007;
            this.rbMain.Size = new System.Drawing.Size(770, 146);
            this.rbMain.StatusBar = this.ribbonStatusBar;
            this.rbMain.Click += new System.EventHandler(this.rbMain_Click);
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.rbMain;
            // 
            // btnParametrage
            // 
            this.btnParametrage.Caption = "Paramètrage";
            this.btnParametrage.Id = 3;
            this.btnParametrage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnParametrage.ImageOptions.Image")));
            this.btnParametrage.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnParametrage.ImageOptions.LargeImage")));
            this.btnParametrage.Name = "btnParametrage";
            // 
            // btnParametre
            // 
            this.btnParametre.Caption = "Setting";
            this.btnParametre.Id = 4;
            this.btnParametre.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnParametre.ImageOptions.Image")));
            this.btnParametre.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnParametre.ImageOptions.LargeImage")));
            this.btnParametre.Name = "btnParametre";
            this.btnParametre.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnParametre_ItemClick);
            // 
            // btnApropos
            // 
            this.btnApropos.Caption = "A propos";
            this.btnApropos.Id = 5;
            this.btnApropos.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnApropos.ImageOptions.Image")));
            this.btnApropos.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnApropos.ImageOptions.LargeImage")));
            this.btnApropos.Name = "btnApropos";
            // 
            // btnFermer
            // 
            this.btnFermer.Caption = "Fermer";
            this.btnFermer.Id = 6;
            this.btnFermer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFermer.ImageOptions.Image")));
            this.btnFermer.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnFermer.ImageOptions.LargeImage")));
            this.btnFermer.Name = "btnFermer";
            // 
            // btnExerciceEncours
            // 
            this.btnExerciceEncours.Caption = "Exercice en cours";
            this.btnExerciceEncours.Id = 7;
            this.btnExerciceEncours.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExerciceEncours.ImageOptions.Image")));
            this.btnExerciceEncours.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExerciceEncours.ImageOptions.LargeImage")));
            this.btnExerciceEncours.Name = "btnExerciceEncours";
            this.btnExerciceEncours.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEncourExercice_ItemClick);
            // 
            // btnMatriculeFiscale
            // 
            this.btnMatriculeFiscale.Caption = "Vérifier clé";
            this.btnMatriculeFiscale.Id = 8;
            this.btnMatriculeFiscale.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMatriculeFiscale.ImageOptions.Image")));
            this.btnMatriculeFiscale.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnMatriculeFiscale.ImageOptions.LargeImage")));
            this.btnMatriculeFiscale.Name = "btnMatriculeFiscale";
            this.btnMatriculeFiscale.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMatriculeFiscale_ItemClick);
            // 
            // rbFichier
            // 
            this.rbFichier.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbParametrage});
            this.rbFichier.Name = "rbFichier";
            this.rbFichier.Text = "Fichier";
            // 
            // rbParametrage
            // 
            this.rbParametrage.ItemLinks.Add(this.btnParametre);
            this.rbParametrage.ItemLinks.Add(this.btnExerciceEncours);
            this.rbParametrage.ItemLinks.Add(this.btnMatriculeFiscale);
            this.rbParametrage.ItemLinks.Add(this.btnApropos);
            this.rbParametrage.ItemLinks.Add(this.btnFermer);
            this.rbParametrage.Name = "rbParametrage";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 563);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.rbMain;
            this.ribbonStatusBar.Size = new System.Drawing.Size(770, 21);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // tabbedView1
            // 
            this.tabbedView1.RootContainer.Element = null;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 584);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.rbMain);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(761, 585);
            this.Name = "FrmMain";
            this.Ribbon = this.rbMain;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "FrmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rbMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rbMain;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbFichier;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbParametrage;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.BarButtonItem btnParametrage;
        private DevExpress.XtraBars.BarButtonItem btnParametre;
        private DevExpress.XtraBars.BarButtonItem btnApropos;
        private DevExpress.XtraBars.BarButtonItem btnFermer;
        private DevExpress.XtraBars.BarButtonItem btnExerciceEncours;
        private DevExpress.XtraBars.BarButtonItem btnMatriculeFiscale;
    }
}