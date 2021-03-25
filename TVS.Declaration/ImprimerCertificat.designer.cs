namespace CnssModule.Declarations
{
    partial class ImprimerCertificat
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
            this.lciMain = new DevExpress.XtraLayout.LayoutControl();
            this.btValider = new DevExpress.XtraEditors.SimpleButton();
            this.btAnnuler = new DevExpress.XtraEditors.SimpleButton();
            this.lcMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgButton = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.cbExercice = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cbSociete = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lciGrroupParam = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciSociete = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciExercice = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lciMain)).BeginInit();
            this.lciMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbExercice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSociete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGrroupParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSociete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExercice)).BeginInit();
            this.SuspendLayout();
            // 
            // lciMain
            // 
            this.lciMain.Controls.Add(this.btValider);
            this.lciMain.Controls.Add(this.btAnnuler);
            this.lciMain.Controls.Add(this.cbSociete);
            this.lciMain.Controls.Add(this.cbExercice);
            this.lciMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lciMain.Location = new System.Drawing.Point(0, 0);
            this.lciMain.Name = "lciMain";
            this.lciMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1356, 247, 250, 350);
            this.lciMain.Root = this.lcMain;
            this.lciMain.Size = new System.Drawing.Size(367, 112);
            this.lciMain.TabIndex = 1;
            this.lciMain.Text = "layoutControl1";
            // 
            // btValider
            // 
            this.btValider.Location = new System.Drawing.Point(160, 11);
            this.btValider.Name = "btValider";
            this.btValider.Size = new System.Drawing.Size(90, 22);
            this.btValider.StyleController = this.lciMain;
            this.btValider.TabIndex = 11;
            this.btValider.Text = "Valider";
            // 
            // btAnnuler
            // 
            this.btAnnuler.Location = new System.Drawing.Point(254, 11);
            this.btAnnuler.Name = "btAnnuler";
            this.btAnnuler.Size = new System.Drawing.Size(91, 24);
            this.btAnnuler.StyleController = this.lciMain;
            this.btAnnuler.TabIndex = 10;
            this.btAnnuler.Text = "&Annuler";
            this.btAnnuler.Click += new System.EventHandler(this.btAnnuler_Click);
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
            this.lcgButton,
            this.lciGrroupParam});
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "Root";
            this.lcMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcMain.Size = new System.Drawing.Size(350, 131);
            this.lcMain.TextVisible = false;
            // 
            // lcgDetail
            // 
            this.lcgDetail.CustomizationFormText = "lcgDetail";
            this.lcgDetail.Location = new System.Drawing.Point(0, 0);
            this.lcgDetail.Name = "lcgDetail";
            this.lcgDetail.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgDetail.Size = new System.Drawing.Size(350, 6);
            this.lcgDetail.TextVisible = false;
            // 
            // lcgButton
            // 
            this.lcgButton.CustomizationFormText = "lcgButton";
            this.lcgButton.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.lcgButton.Location = new System.Drawing.Point(0, 6);
            this.lcgButton.Name = "lcgButton";
            this.lcgButton.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgButton.Size = new System.Drawing.Size(350, 34);
            this.lcgButton.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btAnnuler;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(249, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(95, 28);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(95, 28);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(95, 28);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btValider;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(155, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(94, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(94, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(94, 28);
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
            this.emptySpaceItem1.Size = new System.Drawing.Size(155, 28);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // cbExercice
            // 
            this.cbExercice.Location = new System.Drawing.Point(99, 97);
            this.cbExercice.Name = "cbExercice";
            this.cbExercice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbExercice.Properties.NullText = "";
            this.cbExercice.Properties.View = this.gridView1;
            this.cbExercice.Size = new System.Drawing.Size(237, 20);
            this.cbExercice.StyleController = this.lciMain;
            this.cbExercice.TabIndex = 7;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // cbSociete
            // 
            this.cbSociete.Location = new System.Drawing.Point(99, 73);
            this.cbSociete.Name = "cbSociete";
            this.cbSociete.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSociete.Properties.NullText = "";
            this.cbSociete.Properties.View = this.gridView2;
            this.cbSociete.Size = new System.Drawing.Size(237, 20);
            this.cbSociete.StyleController = this.lciMain;
            this.cbSociete.TabIndex = 6;
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // lciGrroupParam
            // 
            this.lciGrroupParam.CustomizationFormText = "Configuration";
            this.lciGrroupParam.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciSociete,
            this.lciExercice});
            this.lciGrroupParam.Location = new System.Drawing.Point(0, 40);
            this.lciGrroupParam.Name = "lciGrroupParam";
            this.lciGrroupParam.Size = new System.Drawing.Size(350, 91);
            this.lciGrroupParam.Text = "Configuration";
            // 
            // lciSociete
            // 
            this.lciSociete.Control = this.cbSociete;
            this.lciSociete.CustomizationFormText = "Société";
            this.lciSociete.Location = new System.Drawing.Point(0, 0);
            this.lciSociete.Name = "lciSociete";
            this.lciSociete.Size = new System.Drawing.Size(326, 24);
            this.lciSociete.Text = "Société";
            this.lciSociete.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciSociete.TextSize = new System.Drawing.Size(80, 20);
            this.lciSociete.TextToControlDistance = 5;
            // 
            // lciExercice
            // 
            this.lciExercice.Control = this.cbExercice;
            this.lciExercice.CustomizationFormText = "Exercice";
            this.lciExercice.Location = new System.Drawing.Point(0, 24);
            this.lciExercice.Name = "lciExercice";
            this.lciExercice.Size = new System.Drawing.Size(326, 24);
            this.lciExercice.Text = "Exercice";
            this.lciExercice.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciExercice.TextSize = new System.Drawing.Size(80, 20);
            this.lciExercice.TextToControlDistance = 5;
            // 
            // ImprimerCertificat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 112);
            this.Controls.Add(this.lciMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImprimerCertificat";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Imprimer Attestation";
            ((System.ComponentModel.ISupportInitialize)(this.lciMain)).EndInit();
            this.lciMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbExercice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSociete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGrroupParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSociete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExercice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lciMain;
        private DevExpress.XtraEditors.SimpleButton btValider;
        public DevExpress.XtraEditors.SimpleButton btAnnuler;
        private DevExpress.XtraLayout.LayoutControlGroup lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup lcgDetail;
        private DevExpress.XtraLayout.LayoutControlGroup lcgButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.GridLookUpEdit cbSociete;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.GridLookUpEdit cbExercice;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup lciGrroupParam;
        private DevExpress.XtraLayout.LayoutControlItem lciSociete;
        private DevExpress.XtraLayout.LayoutControlItem lciExercice;
    }
}