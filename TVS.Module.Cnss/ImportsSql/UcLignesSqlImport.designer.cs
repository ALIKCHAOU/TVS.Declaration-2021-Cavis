namespace TVS.Module.Cnss.ImportsSql
{
    partial class UcLignesSqlImport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.btImporter = new DevExpress.XtraEditors.SimpleButton();
            this.btAnnuler = new DevExpress.XtraEditors.SimpleButton();
            this.gridLigne = new DevExpress.XtraGrid.GridControl();
            this.viewLigne = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cbValide = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lcgGrid = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLigne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewLigne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbValide.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.btImporter);
            this.lcMain.Controls.Add(this.btAnnuler);
            this.lcMain.Controls.Add(this.gridLigne);
            this.lcMain.Controls.Add(this.cbValide);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Margin = new System.Windows.Forms.Padding(0);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1043, 358, 250, 350);
            this.lcMain.Root = this.lcgGrid;
            this.lcMain.Size = new System.Drawing.Size(680, 627);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "layoutControl1";
            // 
            // btImporter
            // 
            this.btImporter.Location = new System.Drawing.Point(479, 600);
            this.btImporter.Name = "btImporter";
            this.btImporter.Size = new System.Drawing.Size(96, 22);
            this.btImporter.StyleController = this.lcMain;
            this.btImporter.TabIndex = 6;
            this.btImporter.Text = "&Importer";
            // 
            // btAnnuler
            // 
            this.btAnnuler.Location = new System.Drawing.Point(579, 600);
            this.btAnnuler.Name = "btAnnuler";
            this.btAnnuler.Size = new System.Drawing.Size(96, 22);
            this.btAnnuler.StyleController = this.lcMain;
            this.btAnnuler.TabIndex = 5;
            this.btAnnuler.Text = "&Annuler";
            // 
            // gridLigne
            // 
            this.gridLigne.Location = new System.Drawing.Point(3, 3);
            this.gridLigne.MainView = this.viewLigne;
            this.gridLigne.Name = "gridLigne";
            this.gridLigne.Size = new System.Drawing.Size(674, 589);
            this.gridLigne.TabIndex = 4;
            this.gridLigne.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewLigne});
            // 
            // viewLigne
            // 
            this.viewLigne.GridControl = this.gridLigne;
            this.viewLigne.Name = "viewLigne";
            // 
            // cbValide
            // 
            this.cbValide.Location = new System.Drawing.Point(5, 600);
            this.cbValide.Name = "cbValide";
            this.cbValide.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbValide.Properties.Items.AddRange(new object[] {
            "Toutes",
            "Valide",
            "Invalide"});
            this.cbValide.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbValide.Size = new System.Drawing.Size(113, 20);
            this.cbValide.StyleController = this.lcMain;
            this.cbValide.TabIndex = 8;
            // 
            // lcgGrid
            // 
            this.lcgGrid.CustomizationFormText = "Root";
            this.lcgGrid.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgGrid.GroupBordersVisible = false;
            this.lcgGrid.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1,
            this.layoutControlGroup2});
            this.lcgGrid.Location = new System.Drawing.Point(0, 0);
            this.lcgGrid.Name = "Root";
            this.lcgGrid.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgGrid.Size = new System.Drawing.Size(680, 627);
            this.lcgGrid.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciGrid});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(680, 595);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lciGrid
            // 
            this.lciGrid.Control = this.gridLigne;
            this.lciGrid.CustomizationFormText = "lciGrid";
            this.lciGrid.Location = new System.Drawing.Point(0, 0);
            this.lciGrid.Name = "lciGrid";
            this.lciGrid.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lciGrid.Size = new System.Drawing.Size(674, 589);
            this.lciGrid.TextSize = new System.Drawing.Size(0, 0);
            this.lciGrid.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 595);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(680, 32);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cbValide;
            this.layoutControlItem4.CustomizationFormText = "lciFiltre";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(117, 26);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(117, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(117, 26);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "lciFiltre";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(117, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(357, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btImporter;
            this.layoutControlItem2.CustomizationFormText = "Importer";
            this.layoutControlItem2.Location = new System.Drawing.Point(474, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(100, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(100, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(100, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Importer";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btAnnuler;
            this.layoutControlItem1.CustomizationFormText = "lciAnnuler";
            this.layoutControlItem1.Location = new System.Drawing.Point(574, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(100, 26);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(100, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(100, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "lciAnnuler";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // UcLignesSqlImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcMain);
            this.Name = "UcLignesSqlImport";
            this.Size = new System.Drawing.Size(680, 627);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLigne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewLigne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbValide.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup lcgGrid;
        private DevExpress.XtraGrid.GridControl gridLigne;
        private DevExpress.XtraGrid.Views.Grid.GridView viewLigne;
        private DevExpress.XtraLayout.LayoutControlItem lciGrid;
        public DevExpress.XtraEditors.SimpleButton btImporter;
        public DevExpress.XtraEditors.SimpleButton btAnnuler;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        public DevExpress.XtraEditors.ComboBoxEdit cbValide;
    }
}
