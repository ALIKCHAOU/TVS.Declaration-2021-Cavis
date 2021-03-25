namespace TVS.Module.Employee.UiAnnexe
{
    partial class FrmImportAnnexe<TL, TP>
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
            this.lcm = new DevExpress.XtraLayout.LayoutControl();
            this.gcLigneImport = new DevExpress.XtraGrid.GridControl();
            this.gvLigneImport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnImporter = new DevExpress.XtraEditors.SimpleButton();
            this.btnAnnuler = new DevExpress.XtraEditors.SimpleButton();
            this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgGrid = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgButton = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciBtnAnnuler = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBtnImporter = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcm)).BeginInit();
            this.lcm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcLigneImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLigneImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnAnnuler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnImporter)).BeginInit();
            this.SuspendLayout();
            // 
            // lcm
            // 
            this.lcm.Controls.Add(this.gcLigneImport);
            this.lcm.Controls.Add(this.btnImporter);
            this.lcm.Controls.Add(this.btnAnnuler);
            this.lcm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcm.Location = new System.Drawing.Point(0, 0);
            this.lcm.Name = "lcm";
            this.lcm.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1219, 226, 275, 570);
            this.lcm.Root = this.lcgMain;
            this.lcm.Size = new System.Drawing.Size(1046, 588);
            this.lcm.TabIndex = 0;
            this.lcm.Text = "layoutControl1";
            // 
            // gcLigneImport
            // 
            this.gcLigneImport.Location = new System.Drawing.Point(5, 5);
            this.gcLigneImport.MainView = this.gvLigneImport;
            this.gcLigneImport.Name = "gcLigneImport";
            this.gcLigneImport.Size = new System.Drawing.Size(1036, 546);
            this.gcLigneImport.TabIndex = 6;
            this.gcLigneImport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLigneImport});
            // 
            // gvLigneImport
            // 
            this.gvLigneImport.GridControl = this.gcLigneImport;
            this.gvLigneImport.Name = "gvLigneImport";
            // 
            // btnImporter
            // 
            this.btnImporter.Location = new System.Drawing.Point(845, 561);
            this.btnImporter.Name = "btnImporter";
            this.btnImporter.Size = new System.Drawing.Size(96, 22);
            this.btnImporter.StyleController = this.lcm;
            this.btnImporter.TabIndex = 5;
            this.btnImporter.Text = "Importer";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(945, 561);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(96, 22);
            this.btnAnnuler.StyleController = this.lcm;
            this.btnAnnuler.TabIndex = 4;
            this.btnAnnuler.Text = "Annuler";
            // 
            // lcgMain
            // 
            this.lcgMain.AppearanceGroup.BackColor = System.Drawing.Color.White;
            this.lcgMain.AppearanceGroup.Options.UseBackColor = true;
            this.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMain.GroupBordersVisible = false;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgGrid,
            this.lcgButton});
            this.lcgMain.Location = new System.Drawing.Point(0, 0);
            this.lcgMain.Name = "Root";
            this.lcgMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgMain.Size = new System.Drawing.Size(1046, 588);
            this.lcgMain.TextVisible = false;
            // 
            // lcgGrid
            // 
            this.lcgGrid.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciGrid});
            this.lcgGrid.Location = new System.Drawing.Point(0, 0);
            this.lcgGrid.Name = "lcgGrid";
            this.lcgGrid.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgGrid.Size = new System.Drawing.Size(1046, 556);
            this.lcgGrid.TextVisible = false;
            // 
            // lciGrid
            // 
            this.lciGrid.Control = this.gcLigneImport;
            this.lciGrid.Location = new System.Drawing.Point(0, 0);
            this.lciGrid.Name = "lciGrid";
            this.lciGrid.Size = new System.Drawing.Size(1040, 550);
            this.lciGrid.TextSize = new System.Drawing.Size(0, 0);
            this.lciGrid.TextVisible = false;
            // 
            // lcgButton
            // 
            this.lcgButton.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.lciBtnAnnuler,
            this.lciBtnImporter});
            this.lcgButton.Location = new System.Drawing.Point(0, 556);
            this.lcgButton.Name = "lcgButton";
            this.lcgButton.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgButton.Size = new System.Drawing.Size(1046, 32);
            this.lcgButton.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(840, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciBtnAnnuler
            // 
            this.lciBtnAnnuler.Control = this.btnAnnuler;
            this.lciBtnAnnuler.Location = new System.Drawing.Point(940, 0);
            this.lciBtnAnnuler.MaxSize = new System.Drawing.Size(100, 26);
            this.lciBtnAnnuler.MinSize = new System.Drawing.Size(100, 26);
            this.lciBtnAnnuler.Name = "lciBtnAnnuler";
            this.lciBtnAnnuler.Size = new System.Drawing.Size(100, 26);
            this.lciBtnAnnuler.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciBtnAnnuler.TextSize = new System.Drawing.Size(0, 0);
            this.lciBtnAnnuler.TextVisible = false;
            // 
            // lciBtnImporter
            // 
            this.lciBtnImporter.Control = this.btnImporter;
            this.lciBtnImporter.Location = new System.Drawing.Point(840, 0);
            this.lciBtnImporter.MaxSize = new System.Drawing.Size(100, 26);
            this.lciBtnImporter.MinSize = new System.Drawing.Size(100, 26);
            this.lciBtnImporter.Name = "lciBtnImporter";
            this.lciBtnImporter.Size = new System.Drawing.Size(100, 26);
            this.lciBtnImporter.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciBtnImporter.TextSize = new System.Drawing.Size(0, 0);
            this.lciBtnImporter.TextVisible = false;
            // 
            // FrmImportAnnexe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 588);
            this.Controls.Add(this.lcm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImportAnnexe";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmImportAnnexe";
            ((System.ComponentModel.ISupportInitialize)(this.lcm)).EndInit();
            this.lcm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcLigneImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLigneImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnAnnuler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnImporter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcm;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMain;
        private DevExpress.XtraLayout.LayoutControlGroup lcgGrid;
        private DevExpress.XtraLayout.LayoutControlGroup lcgButton;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.SimpleButton btnImporter;
        private DevExpress.XtraEditors.SimpleButton btnAnnuler;
        private DevExpress.XtraLayout.LayoutControlItem lciBtnAnnuler;
        private DevExpress.XtraLayout.LayoutControlItem lciBtnImporter;
        private DevExpress.XtraGrid.GridControl gcLigneImport;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLigneImport;
        private DevExpress.XtraLayout.LayoutControlItem lciGrid;
    }
}