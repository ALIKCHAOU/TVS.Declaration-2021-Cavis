namespace TVS.Module.FactureSuspenssion.Imports
{
    partial class UcImportDeclaration
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
            this.lciMain = new DevExpress.XtraLayout.LayoutControl();
            this.btSuivant = new DevExpress.XtraEditors.SimpleButton();
            this.btAnnuler = new DevExpress.XtraEditors.SimpleButton();
            this.btPath = new DevExpress.XtraEditors.ButtonEdit();
            this.txtExercice = new DevExpress.XtraEditors.TextEdit();
            this.txtSociete = new DevExpress.XtraEditors.TextEdit();
            this.cbTrimestre = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lcMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Fichier = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTrimestre = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciExercice = new DevExpress.XtraLayout.LayoutControlItem();
            this.Societe = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgButton = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            ((System.ComponentModel.ISupportInitialize)(this.lciMain)).BeginInit();
            this.lciMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExercice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSociete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTrimestre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fichier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTrimestre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExercice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Societe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lciMain
            // 
            this.lciMain.Controls.Add(this.btSuivant);
            this.lciMain.Controls.Add(this.btAnnuler);
            this.lciMain.Controls.Add(this.btPath);
            this.lciMain.Controls.Add(this.txtExercice);
            this.lciMain.Controls.Add(this.txtSociete);
            this.lciMain.Controls.Add(this.cbTrimestre);
            this.lciMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lciMain.Location = new System.Drawing.Point(0, 0);
            this.lciMain.Name = "lciMain";
            this.lciMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(969, 247, 250, 350);
            this.lciMain.Root = this.lcMain;
            this.lciMain.Size = new System.Drawing.Size(883, 580);
            this.lciMain.TabIndex = 0;
            this.lciMain.Text = "layoutControl1";
            // 
            // btSuivant
            // 
            this.btSuivant.Location = new System.Drawing.Point(636, 553);
            this.btSuivant.Name = "btSuivant";
            this.btSuivant.Size = new System.Drawing.Size(122, 22);
            this.btSuivant.StyleController = this.lciMain;
            this.btSuivant.TabIndex = 11;
            this.btSuivant.Text = "&Générer";
            // 
            // btAnnuler
            // 
            this.btAnnuler.Location = new System.Drawing.Point(762, 553);
            this.btAnnuler.Name = "btAnnuler";
            this.btAnnuler.Size = new System.Drawing.Size(116, 22);
            this.btAnnuler.StyleController = this.lciMain;
            this.btAnnuler.TabIndex = 10;
            this.btAnnuler.Text = "&Annuler";
            // 
            // btPath
            // 
            this.btPath.Location = new System.Drawing.Point(102, 77);
            this.btPath.Name = "btPath";
            this.btPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btPath.Size = new System.Drawing.Size(242, 20);
            this.btPath.StyleController = this.lciMain;
            this.btPath.TabIndex = 9;
            this.btPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btPath_ButtonClick);
            // 
            // txtExercice
            // 
            this.txtExercice.Location = new System.Drawing.Point(102, 29);
            this.txtExercice.Name = "txtExercice";
            this.txtExercice.Properties.ReadOnly = true;
            this.txtExercice.Size = new System.Drawing.Size(242, 20);
            this.txtExercice.StyleController = this.lciMain;
            this.txtExercice.TabIndex = 6;
            // 
            // txtSociete
            // 
            this.txtSociete.Location = new System.Drawing.Point(102, 5);
            this.txtSociete.Name = "txtSociete";
            this.txtSociete.Properties.ReadOnly = true;
            this.txtSociete.Size = new System.Drawing.Size(242, 20);
            this.txtSociete.StyleController = this.lciMain;
            this.txtSociete.TabIndex = 4;
            // 
            // cbTrimestre
            // 
            this.cbTrimestre.Location = new System.Drawing.Point(102, 53);
            this.cbTrimestre.Name = "cbTrimestre";
            this.cbTrimestre.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTrimestre.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbTrimestre.Properties.ReadOnly = true;
            this.cbTrimestre.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbTrimestre.Size = new System.Drawing.Size(242, 20);
            this.cbTrimestre.StyleController = this.lciMain;
            this.cbTrimestre.TabIndex = 7;
            // 
            // lcMain
            // 
            this.lcMain.AppearanceGroup.BackColor2 = System.Drawing.Color.White;
            this.lcMain.AppearanceGroup.BorderColor = System.Drawing.Color.White;
            this.lcMain.AppearanceGroup.ForeColor = System.Drawing.Color.White;
            this.lcMain.AppearanceGroup.Options.UseBorderColor = true;
            this.lcMain.AppearanceGroup.Options.UseForeColor = true;
            this.lcMain.CustomizationFormText = "Root";
            this.lcMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcMain.GroupBordersVisible = false;
            this.lcMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgDetail,
            this.lcgButton});
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "Root";
            this.lcMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcMain.Size = new System.Drawing.Size(883, 580);
            this.lcMain.TextVisible = false;
            // 
            // lcgDetail
            // 
            this.lcgDetail.CustomizationFormText = "lcgDetail";
            this.lcgDetail.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Fichier,
            this.lciTrimestre,
            this.lciExercice,
            this.Societe,
            this.emptySpaceItem2,
            this.emptySpaceItem3});
            this.lcgDetail.Location = new System.Drawing.Point(0, 0);
            this.lcgDetail.Name = "lcgDetail";
            this.lcgDetail.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgDetail.Size = new System.Drawing.Size(883, 548);
            this.lcgDetail.TextVisible = false;
            // 
            // Fichier
            // 
            this.Fichier.Control = this.btPath;
            this.Fichier.CustomizationFormText = "Fichier";
            this.Fichier.Location = new System.Drawing.Point(0, 72);
            this.Fichier.MaxSize = new System.Drawing.Size(343, 24);
            this.Fichier.MinSize = new System.Drawing.Size(343, 24);
            this.Fichier.Name = "Fichier";
            this.Fichier.Size = new System.Drawing.Size(343, 24);
            this.Fichier.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.Fichier.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 0, 0, 0);
            this.Fichier.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.Fichier.TextSize = new System.Drawing.Size(90, 13);
            this.Fichier.TextToControlDistance = 5;
            // 
            // lciTrimestre
            // 
            this.lciTrimestre.Control = this.cbTrimestre;
            this.lciTrimestre.CustomizationFormText = "Trimestre";
            this.lciTrimestre.Location = new System.Drawing.Point(0, 48);
            this.lciTrimestre.Name = "lciTrimestre";
            this.lciTrimestre.Size = new System.Drawing.Size(343, 24);
            this.lciTrimestre.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 0, 0, 0);
            this.lciTrimestre.Text = "Trimestre";
            this.lciTrimestre.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciTrimestre.TextSize = new System.Drawing.Size(90, 13);
            this.lciTrimestre.TextToControlDistance = 5;
            // 
            // lciExercice
            // 
            this.lciExercice.Control = this.txtExercice;
            this.lciExercice.CustomizationFormText = "Exrcice";
            this.lciExercice.Location = new System.Drawing.Point(0, 24);
            this.lciExercice.Name = "lciExercice";
            this.lciExercice.Size = new System.Drawing.Size(343, 24);
            this.lciExercice.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 0, 0, 0);
            this.lciExercice.Text = "Exrcice";
            this.lciExercice.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciExercice.TextSize = new System.Drawing.Size(90, 13);
            this.lciExercice.TextToControlDistance = 5;
            // 
            // Societe
            // 
            this.Societe.Control = this.txtSociete;
            this.Societe.CustomizationFormText = "Societe";
            this.Societe.Location = new System.Drawing.Point(0, 0);
            this.Societe.Name = "Societe";
            this.Societe.Size = new System.Drawing.Size(343, 24);
            this.Societe.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 0, 0, 0);
            this.Societe.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.Societe.TextSize = new System.Drawing.Size(90, 13);
            this.Societe.TextToControlDistance = 5;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(343, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(534, 96);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 96);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(877, 446);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgButton
            // 
            this.lcgButton.CustomizationFormText = "lcgButton";
            this.lcgButton.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.lcgButton.Location = new System.Drawing.Point(0, 548);
            this.lcgButton.Name = "lcgButton";
            this.lcgButton.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgButton.Size = new System.Drawing.Size(883, 32);
            this.lcgButton.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btAnnuler;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(757, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(120, 26);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(120, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(120, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btSuivant;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(631, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(126, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(126, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(126, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem1.Size = new System.Drawing.Size(631, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // UcImportDeclaration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lciMain);
            this.Name = "UcImportDeclaration";
            this.Size = new System.Drawing.Size(883, 580);
            ((System.ComponentModel.ISupportInitialize)(this.lciMain)).EndInit();
            this.lciMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExercice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSociete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTrimestre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fichier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTrimestre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExercice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Societe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lciMain;
        private DevExpress.XtraLayout.LayoutControlGroup lcMain;
        private DevExpress.XtraEditors.ButtonEdit btPath;
        private DevExpress.XtraEditors.TextEdit txtExercice;
        private DevExpress.XtraEditors.TextEdit txtSociete;
        private DevExpress.XtraLayout.LayoutControlItem Societe;
        private DevExpress.XtraLayout.LayoutControlItem lciExercice;
        private DevExpress.XtraLayout.LayoutControlItem lciTrimestre;
        private DevExpress.XtraLayout.LayoutControlItem Fichier;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.ComboBoxEdit cbTrimestre;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        public DevExpress.XtraEditors.SimpleButton btSuivant;
        public DevExpress.XtraEditors.SimpleButton btAnnuler;
        private DevExpress.XtraLayout.LayoutControlGroup lcgDetail;
        private DevExpress.XtraLayout.LayoutControlGroup lcgButton;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
    }
}
