namespace TVS.Module.Employee.UiAnnexe
{
    partial class FrmRecapDecEmp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRecapDecEmp));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnGenerer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnExporterExcel = new DevExpress.XtraBars.BarButtonItem();
            this.rbpAccueil = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbpgAccueil = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.lcm = new DevExpress.XtraLayout.LayoutControl();
            this.gcVerification = new DevExpress.XtraGrid.GridControl();
            this.gvVerification = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcRecap = new DevExpress.XtraGrid.GridControl();
            this.gvRecap = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgGrid = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciGridVerificator = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcm)).BeginInit();
            this.lcm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcVerification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVerification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRecap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGridVerificator)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnGenerer,
            this.barButtonItem1,
            this.barButtonItem2,
            this.btnExporterExcel});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbpAccueil});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowCategoryInCaption = false;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowQatLocationSelector = false;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(694, 146);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // btnGenerer
            // 
            this.btnGenerer.Caption = "Générer";
            this.btnGenerer.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGenerer.Glyph")));
            this.btnGenerer.Id = 1;
            this.btnGenerer.Name = "btnGenerer";
            this.btnGenerer.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Glyph = global::TVS.Module.Employee.Properties.Resources.apply_16x16;
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.LargeGlyph = global::TVS.Module.Employee.Properties.Resources.apply_32x32;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Glyph = global::TVS.Module.Employee.Properties.Resources.addchartpane_16x16;
            this.barButtonItem2.Id = 3;
            this.barButtonItem2.LargeGlyph = global::TVS.Module.Employee.Properties.Resources.addchartpane_32x32;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // btnExporterExcel
            // 
            this.btnExporterExcel.Caption = "Exporter Excel";
            this.btnExporterExcel.Glyph = global::TVS.Module.Employee.Properties.Resources.exporttoxlsx_16x16;
            this.btnExporterExcel.Id = 4;
            this.btnExporterExcel.LargeGlyph = global::TVS.Module.Employee.Properties.Resources.exporttoxlsx_32x32;
            this.btnExporterExcel.Name = "btnExporterExcel";
            // 
            // rbpAccueil
            // 
            this.rbpAccueil.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbpgAccueil});
            this.rbpAccueil.Name = "rbpAccueil";
            this.rbpAccueil.Text = "Fichier";
            // 
            // rbpgAccueil
            // 
            this.rbpgAccueil.AllowTextClipping = false;
            this.rbpgAccueil.ItemLinks.Add(this.btnGenerer);
            this.rbpgAccueil.ItemLinks.Add(this.btnExporterExcel);
            this.rbpgAccueil.Name = "rbpgAccueil";
            this.rbpgAccueil.ShowCaptionButton = false;
            this.rbpgAccueil.Text = "Déclaration employeurs";
            // 
            // lcm
            // 
            this.lcm.Controls.Add(this.gcVerification);
            this.lcm.Controls.Add(this.gcRecap);
            this.lcm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcm.Location = new System.Drawing.Point(0, 146);
            this.lcm.Name = "lcm";
            this.lcm.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1073, 194, 448, 532);
            this.lcm.Root = this.lcgMain;
            this.lcm.Size = new System.Drawing.Size(694, 391);
            this.lcm.TabIndex = 1;
            this.lcm.Text = "layoutControl1";
            // 
            // gcVerification
            // 
            this.gcVerification.Location = new System.Drawing.Point(488, 5);
            this.gcVerification.MainView = this.gvVerification;
            this.gcVerification.MenuManager = this.ribbon;
            this.gcVerification.Name = "gcVerification";
            this.gcVerification.Size = new System.Drawing.Size(201, 381);
            this.gcVerification.TabIndex = 6;
            this.gcVerification.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvVerification});
            this.gcVerification.Visible = false;
            // 
            // gvVerification
            // 
            this.gvVerification.GridControl = this.gcVerification;
            this.gvVerification.Name = "gvVerification";
            // 
            // gcRecap
            // 
            this.gcRecap.Location = new System.Drawing.Point(5, 5);
            this.gcRecap.MainView = this.gvRecap;
            this.gcRecap.MenuManager = this.ribbon;
            this.gcRecap.Name = "gcRecap";
            this.gcRecap.Size = new System.Drawing.Size(479, 381);
            this.gcRecap.TabIndex = 4;
            this.gcRecap.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRecap});
            // 
            // gvRecap
            // 
            this.gvRecap.GridControl = this.gcRecap;
            this.gvRecap.Name = "gvRecap";
            // 
            // lcgMain
            // 
            this.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMain.GroupBordersVisible = false;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgGrid});
            this.lcgMain.Location = new System.Drawing.Point(0, 0);
            this.lcgMain.Name = "Root";
            this.lcgMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgMain.Size = new System.Drawing.Size(694, 391);
            this.lcgMain.TextVisible = false;
            // 
            // lcgGrid
            // 
            this.lcgGrid.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciGrid,
            this.lciGridVerificator});
            this.lcgGrid.Location = new System.Drawing.Point(0, 0);
            this.lcgGrid.Name = "lcgGrid";
            this.lcgGrid.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgGrid.Size = new System.Drawing.Size(694, 391);
            this.lcgGrid.TextVisible = false;
            // 
            // lciGrid
            // 
            this.lciGrid.Control = this.gcRecap;
            this.lciGrid.Location = new System.Drawing.Point(0, 0);
            this.lciGrid.Name = "lciGrid";
            this.lciGrid.Size = new System.Drawing.Size(483, 385);
            this.lciGrid.TextSize = new System.Drawing.Size(0, 0);
            this.lciGrid.TextVisible = false;
            // 
            // lciGridVerificator
            // 
            this.lciGridVerificator.Control = this.gcVerification;
            this.lciGridVerificator.Location = new System.Drawing.Point(483, 0);
            this.lciGridVerificator.Name = "lciGridVerificator";
            this.lciGridVerificator.Size = new System.Drawing.Size(205, 385);
            this.lciGridVerificator.TextSize = new System.Drawing.Size(0, 0);
            this.lciGridVerificator.TextVisible = false;
            this.lciGridVerificator.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // FrmRecapDecEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 537);
            this.Controls.Add(this.lcm);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmRecapDecEmp";
            this.Ribbon = this.ribbon;
            this.Text = "Récap";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcm)).EndInit();
            this.lcm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcVerification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVerification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRecap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGridVerificator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpAccueil;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgAccueil;
        private DevExpress.XtraBars.BarButtonItem btnGenerer;
        private DevExpress.XtraLayout.LayoutControl lcm;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMain;
        private DevExpress.XtraLayout.LayoutControlGroup lcgGrid;
        private DevExpress.XtraGrid.GridControl gcRecap;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRecap;
        private DevExpress.XtraLayout.LayoutControlItem lciGrid;
        private DevExpress.XtraGrid.GridControl gcVerification;
        private DevExpress.XtraGrid.Views.Grid.GridView gvVerification;
        private DevExpress.XtraLayout.LayoutControlItem lciGridVerificator;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btnExporterExcel;
    }
}