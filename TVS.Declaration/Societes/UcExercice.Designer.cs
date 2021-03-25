namespace TVS.Declaration.Societes
{
    partial class UcExercice
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcExercice));
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.btnNouveau = new DevExpress.XtraEditors.SimpleButton();
            this.btnCloturer = new DevExpress.XtraEditors.SimpleButton();
            this.btSupprimer = new DevExpress.XtraEditors.SimpleButton();
            this.gcExercice = new DevExpress.XtraGrid.GridControl();
            this.gvExercice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lciMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSupprimer = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCloture = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciAjouter = new DevExpress.XtraLayout.LayoutControlItem();
            this.icCloture = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcExercice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExercice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSupprimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCloture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAjouter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icCloture)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.btnNouveau);
            this.lcMain.Controls.Add(this.btnCloturer);
            this.lcMain.Controls.Add(this.btSupprimer);
            this.lcMain.Controls.Add(this.gcExercice);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(828, 116, 250, 350);
            this.lcMain.Root = this.lciMain;
            this.lcMain.Size = new System.Drawing.Size(510, 467);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "layoutControl1";
            // 
            // btnNouveau
            // 
            this.btnNouveau.Location = new System.Drawing.Point(212, 443);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(96, 22);
            this.btnNouveau.StyleController = this.lcMain;
            this.btnNouveau.TabIndex = 7;
            this.btnNouveau.Text = "&Nouveau";
            // 
            // btnCloturer
            // 
            this.btnCloturer.Location = new System.Drawing.Point(312, 443);
            this.btnCloturer.Name = "btnCloturer";
            this.btnCloturer.Size = new System.Drawing.Size(96, 22);
            this.btnCloturer.StyleController = this.lcMain;
            this.btnCloturer.TabIndex = 6;
            this.btnCloturer.Text = "&Clôturer";
            // 
            // btSupprimer
            // 
            this.btSupprimer.Location = new System.Drawing.Point(412, 443);
            this.btSupprimer.Name = "btSupprimer";
            this.btSupprimer.Size = new System.Drawing.Size(96, 22);
            this.btSupprimer.StyleController = this.lcMain;
            this.btSupprimer.TabIndex = 5;
            this.btSupprimer.Text = "&Supprimer";
            // 
            // gcExercice
            // 
            this.gcExercice.Location = new System.Drawing.Point(2, 2);
            this.gcExercice.MainView = this.gvExercice;
            this.gcExercice.Name = "gcExercice";
            this.gcExercice.Size = new System.Drawing.Size(506, 437);
            this.gcExercice.TabIndex = 4;
            this.gcExercice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvExercice});
            // 
            // gvExercice
            // 
            this.gvExercice.GridControl = this.gcExercice;
            this.gvExercice.Name = "gvExercice";
            // 
            // lciMain
            // 
            this.lciMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lciMain.GroupBordersVisible = false;
            this.lciMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciGrid,
            this.lciSupprimer,
            this.lciCloture,
            this.emptySpaceItem1,
            this.lciAjouter});
            this.lciMain.Location = new System.Drawing.Point(0, 0);
            this.lciMain.Name = "Root";
            this.lciMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lciMain.Size = new System.Drawing.Size(510, 467);
            this.lciMain.TextVisible = false;
            // 
            // lciGrid
            // 
            this.lciGrid.Control = this.gcExercice;
            this.lciGrid.Location = new System.Drawing.Point(0, 0);
            this.lciGrid.Name = "lciGrid";
            this.lciGrid.Size = new System.Drawing.Size(510, 441);
            this.lciGrid.TextSize = new System.Drawing.Size(0, 0);
            this.lciGrid.TextVisible = false;
            // 
            // lciSupprimer
            // 
            this.lciSupprimer.Control = this.btSupprimer;
            this.lciSupprimer.Location = new System.Drawing.Point(410, 441);
            this.lciSupprimer.MaxSize = new System.Drawing.Size(100, 26);
            this.lciSupprimer.MinSize = new System.Drawing.Size(100, 26);
            this.lciSupprimer.Name = "lciSupprimer";
            this.lciSupprimer.Size = new System.Drawing.Size(100, 26);
            this.lciSupprimer.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciSupprimer.TextSize = new System.Drawing.Size(0, 0);
            this.lciSupprimer.TextVisible = false;
            // 
            // lciCloture
            // 
            this.lciCloture.Control = this.btnCloturer;
            this.lciCloture.Location = new System.Drawing.Point(310, 441);
            this.lciCloture.MaxSize = new System.Drawing.Size(100, 26);
            this.lciCloture.MinSize = new System.Drawing.Size(100, 26);
            this.lciCloture.Name = "lciCloture";
            this.lciCloture.Size = new System.Drawing.Size(100, 26);
            this.lciCloture.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciCloture.TextSize = new System.Drawing.Size(0, 0);
            this.lciCloture.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 441);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(210, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciAjouter
            // 
            this.lciAjouter.Control = this.btnNouveau;
            this.lciAjouter.Location = new System.Drawing.Point(210, 441);
            this.lciAjouter.MaxSize = new System.Drawing.Size(100, 26);
            this.lciAjouter.MinSize = new System.Drawing.Size(100, 26);
            this.lciAjouter.Name = "lciAjouter";
            this.lciAjouter.Size = new System.Drawing.Size(100, 26);
            this.lciAjouter.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciAjouter.TextSize = new System.Drawing.Size(0, 0);
            this.lciAjouter.TextVisible = false;
            // 
            // icCloture
            // 
            this.icCloture.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("icCloture.ImageStream")));
            this.icCloture.InsertGalleryImage("checkbuttons_16x16.png", "images/filter%20elements/checkbuttons_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/filter%20elements/checkbuttons_16x16.png"), 0);
            this.icCloture.Images.SetKeyName(0, "checkbuttons_16x16.png");
            this.icCloture.InsertGalleryImage("notes_16x16.png", "images/content/notes_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/content/notes_16x16.png"), 1);
            this.icCloture.Images.SetKeyName(1, "notes_16x16.png");
            // 
            // UcExercice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcMain);
            this.Name = "UcExercice";
            this.Size = new System.Drawing.Size(510, 467);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcExercice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExercice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSupprimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCloture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAjouter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icCloture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraEditors.SimpleButton btnNouveau;
        private DevExpress.XtraEditors.SimpleButton btnCloturer;
        private DevExpress.XtraEditors.SimpleButton btSupprimer;
        private DevExpress.XtraGrid.GridControl gcExercice;
        private DevExpress.XtraGrid.Views.Grid.GridView gvExercice;
        private DevExpress.XtraLayout.LayoutControlGroup lciMain;
        private DevExpress.XtraLayout.LayoutControlItem lciGrid;
        private DevExpress.XtraLayout.LayoutControlItem lciSupprimer;
        private DevExpress.XtraLayout.LayoutControlItem lciCloture;
        private DevExpress.XtraLayout.LayoutControlItem lciAjouter;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.Utils.ImageCollection icCloture;
    }
}
