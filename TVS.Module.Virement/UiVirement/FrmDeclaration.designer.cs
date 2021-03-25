namespace TVS.Module.Virement.UiVirement
{
    partial class FrmDeclaration
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
            this.txtRib = new DevExpress.XtraEditors.TextEdit();
            this.txtReferenceEnvoi = new DevExpress.XtraEditors.TextEdit();
            this.txtMotif = new DevExpress.XtraEditors.TextEdit();
            this.btValider = new DevExpress.XtraEditors.SimpleButton();
            this.btAnnuler = new DevExpress.XtraEditors.SimpleButton();
            this.txtExercice = new DevExpress.XtraEditors.TextEdit();
            this.txtSociete = new DevExpress.XtraEditors.TextEdit();
            this.dtEcheance = new DevExpress.XtraEditors.DateEdit();
            this.gleBanque = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lcMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Societe = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDateEcheance = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciMotif = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciExercice = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciReferenceEnvoie = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBanque = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciRib = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgButton = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lciMain)).BeginInit();
            this.lciMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRib.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceEnvoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMotif.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExercice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSociete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEcheance.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEcheance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleBanque.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Societe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDateEcheance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMotif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExercice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciReferenceEnvoie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBanque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRib)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lciMain
            // 
            this.lciMain.Controls.Add(this.txtRib);
            this.lciMain.Controls.Add(this.txtReferenceEnvoi);
            this.lciMain.Controls.Add(this.txtMotif);
            this.lciMain.Controls.Add(this.btValider);
            this.lciMain.Controls.Add(this.btAnnuler);
            this.lciMain.Controls.Add(this.txtExercice);
            this.lciMain.Controls.Add(this.txtSociete);
            this.lciMain.Controls.Add(this.dtEcheance);
            this.lciMain.Controls.Add(this.gleBanque);
            this.lciMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lciMain.Location = new System.Drawing.Point(0, 0);
            this.lciMain.Name = "lciMain";
            this.lciMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1356, 247, 250, 350);
            this.lciMain.Root = this.lcMain;
            this.lciMain.Size = new System.Drawing.Size(558, 136);
            this.lciMain.TabIndex = 1;
            this.lciMain.Text = "layoutControl1";
            // 
            // txtRib
            // 
            this.txtRib.Location = new System.Drawing.Point(250, 53);
            this.txtRib.Name = "txtRib";
            this.txtRib.Properties.ReadOnly = true;
            this.txtRib.Size = new System.Drawing.Size(303, 20);
            this.txtRib.StyleController = this.lciMain;
            this.txtRib.TabIndex = 16;
            // 
            // txtReferenceEnvoi
            // 
            this.txtReferenceEnvoi.Location = new System.Drawing.Point(355, 29);
            this.txtReferenceEnvoi.Name = "txtReferenceEnvoi";
            this.txtReferenceEnvoi.Size = new System.Drawing.Size(198, 20);
            this.txtReferenceEnvoi.StyleController = this.lciMain;
            this.txtReferenceEnvoi.TabIndex = 14;
            // 
            // txtMotif
            // 
            this.txtMotif.Location = new System.Drawing.Point(80, 77);
            this.txtMotif.Name = "txtMotif";
            this.txtMotif.Size = new System.Drawing.Size(473, 20);
            this.txtMotif.StyleController = this.lciMain;
            this.txtMotif.TabIndex = 13;
            // 
            // btValider
            // 
            this.btValider.Location = new System.Drawing.Point(368, 107);
            this.btValider.Name = "btValider";
            this.btValider.Size = new System.Drawing.Size(90, 22);
            this.btValider.StyleController = this.lciMain;
            this.btValider.TabIndex = 11;
            this.btValider.Text = "Valider";
            // 
            // btAnnuler
            // 
            this.btAnnuler.Location = new System.Drawing.Point(462, 107);
            this.btAnnuler.Name = "btAnnuler";
            this.btAnnuler.Size = new System.Drawing.Size(91, 24);
            this.btAnnuler.StyleController = this.lciMain;
            this.btAnnuler.TabIndex = 10;
            this.btAnnuler.Text = "&Annuler";
            // 
            // txtExercice
            // 
            this.txtExercice.Location = new System.Drawing.Point(355, 5);
            this.txtExercice.Name = "txtExercice";
            this.txtExercice.Properties.ReadOnly = true;
            this.txtExercice.Size = new System.Drawing.Size(198, 20);
            this.txtExercice.StyleController = this.lciMain;
            this.txtExercice.TabIndex = 6;
            // 
            // txtSociete
            // 
            this.txtSociete.Location = new System.Drawing.Point(80, 5);
            this.txtSociete.Name = "txtSociete";
            this.txtSociete.Properties.ReadOnly = true;
            this.txtSociete.Size = new System.Drawing.Size(166, 20);
            this.txtSociete.StyleController = this.lciMain;
            this.txtSociete.TabIndex = 4;
            // 
            // dtEcheance
            // 
            this.dtEcheance.EditValue = new System.DateTime(2017, 5, 8, 9, 59, 2, 448);
            this.dtEcheance.Location = new System.Drawing.Point(80, 29);
            this.dtEcheance.Name = "dtEcheance";
            this.dtEcheance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEcheance.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEcheance.Properties.Mask.EditMask = "";
            this.dtEcheance.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dtEcheance.Size = new System.Drawing.Size(166, 20);
            this.dtEcheance.StyleController = this.lciMain;
            this.dtEcheance.TabIndex = 12;
            // 
            // gleBanque
            // 
            this.gleBanque.Location = new System.Drawing.Point(80, 53);
            this.gleBanque.Name = "gleBanque";
            this.gleBanque.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gleBanque.Properties.NullText = "";
            this.gleBanque.Properties.View = this.gridLookUpEdit1View;
            this.gleBanque.Size = new System.Drawing.Size(166, 20);
            this.gleBanque.StyleController = this.lciMain;
            this.gleBanque.TabIndex = 15;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
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
            this.lcMain.Size = new System.Drawing.Size(558, 136);
            this.lcMain.TextVisible = false;
            // 
            // lcgDetail
            // 
            this.lcgDetail.CustomizationFormText = "lcgDetail";
            this.lcgDetail.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Societe,
            this.lciDateEcheance,
            this.lciMotif,
            this.lciExercice,
            this.lciReferenceEnvoie,
            this.lciBanque,
            this.lciRib});
            this.lcgDetail.Location = new System.Drawing.Point(0, 0);
            this.lcgDetail.Name = "lcgDetail";
            this.lcgDetail.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgDetail.Size = new System.Drawing.Size(558, 102);
            this.lcgDetail.TextVisible = false;
            // 
            // Societe
            // 
            this.Societe.Control = this.txtSociete;
            this.Societe.CustomizationFormText = "Societe";
            this.Societe.Location = new System.Drawing.Point(0, 0);
            this.Societe.Name = "Societe";
            this.Societe.Size = new System.Drawing.Size(245, 24);
            this.Societe.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 0, 0, 0);
            this.Societe.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.Societe.TextSize = new System.Drawing.Size(70, 13);
            this.Societe.TextToControlDistance = 0;
            // 
            // lciDateEcheance
            // 
            this.lciDateEcheance.Control = this.dtEcheance;
            this.lciDateEcheance.Location = new System.Drawing.Point(0, 24);
            this.lciDateEcheance.Name = "lciDateEcheance";
            this.lciDateEcheance.Size = new System.Drawing.Size(245, 24);
            this.lciDateEcheance.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 0, 0, 0);
            this.lciDateEcheance.Text = "Echéance";
            this.lciDateEcheance.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciDateEcheance.TextSize = new System.Drawing.Size(70, 20);
            this.lciDateEcheance.TextToControlDistance = 0;
            // 
            // lciMotif
            // 
            this.lciMotif.Control = this.txtMotif;
            this.lciMotif.Location = new System.Drawing.Point(0, 72);
            this.lciMotif.Name = "lciMotif";
            this.lciMotif.Size = new System.Drawing.Size(552, 24);
            this.lciMotif.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 0, 0, 0);
            this.lciMotif.Text = "Motif";
            this.lciMotif.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciMotif.TextSize = new System.Drawing.Size(70, 20);
            this.lciMotif.TextToControlDistance = 0;
            // 
            // lciExercice
            // 
            this.lciExercice.Control = this.txtExercice;
            this.lciExercice.CustomizationFormText = "Exrcice";
            this.lciExercice.Location = new System.Drawing.Point(245, 0);
            this.lciExercice.Name = "lciExercice";
            this.lciExercice.Size = new System.Drawing.Size(307, 24);
            this.lciExercice.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 0, 0, 0);
            this.lciExercice.Text = "Exercice";
            this.lciExercice.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciExercice.TextSize = new System.Drawing.Size(100, 13);
            this.lciExercice.TextToControlDistance = 0;
            // 
            // lciReferenceEnvoie
            // 
            this.lciReferenceEnvoie.Control = this.txtReferenceEnvoi;
            this.lciReferenceEnvoie.Location = new System.Drawing.Point(245, 24);
            this.lciReferenceEnvoie.Name = "lciReferenceEnvoie";
            this.lciReferenceEnvoie.Size = new System.Drawing.Size(307, 24);
            this.lciReferenceEnvoie.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 0, 0, 0);
            this.lciReferenceEnvoie.Text = "Référence d\'envoie";
            this.lciReferenceEnvoie.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciReferenceEnvoie.TextSize = new System.Drawing.Size(100, 20);
            this.lciReferenceEnvoie.TextToControlDistance = 0;
            // 
            // lciBanque
            // 
            this.lciBanque.Control = this.gleBanque;
            this.lciBanque.Location = new System.Drawing.Point(0, 48);
            this.lciBanque.Name = "lciBanque";
            this.lciBanque.Size = new System.Drawing.Size(245, 24);
            this.lciBanque.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 0, 0, 0);
            this.lciBanque.Text = "Banque";
            this.lciBanque.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciBanque.TextSize = new System.Drawing.Size(70, 20);
            this.lciBanque.TextToControlDistance = 0;
            // 
            // lciRib
            // 
            this.lciRib.Control = this.txtRib;
            this.lciRib.Location = new System.Drawing.Point(245, 48);
            this.lciRib.Name = "lciRib";
            this.lciRib.Size = new System.Drawing.Size(307, 24);
            this.lciRib.Text = "Rib";
            this.lciRib.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciRib.TextSize = new System.Drawing.Size(0, 0);
            this.lciRib.TextToControlDistance = 0;
            this.lciRib.TextVisible = false;
            // 
            // lcgButton
            // 
            this.lcgButton.CustomizationFormText = "lcgButton";
            this.lcgButton.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.lcgButton.Location = new System.Drawing.Point(0, 102);
            this.lcgButton.Name = "lcgButton";
            this.lcgButton.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgButton.Size = new System.Drawing.Size(558, 34);
            this.lcgButton.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btAnnuler;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(457, 0);
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
            this.layoutControlItem2.Location = new System.Drawing.Point(363, 0);
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
            this.emptySpaceItem1.Size = new System.Drawing.Size(363, 28);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // FrmDeclaration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 136);
            this.Controls.Add(this.lciMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDeclaration";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nouveau virement";
            ((System.ComponentModel.ISupportInitialize)(this.lciMain)).EndInit();
            this.lciMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRib.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceEnvoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMotif.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExercice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSociete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEcheance.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEcheance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleBanque.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Societe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDateEcheance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMotif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExercice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciReferenceEnvoie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBanque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRib)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lciMain;
        private DevExpress.XtraEditors.SimpleButton btValider;
        public DevExpress.XtraEditors.SimpleButton btAnnuler;
        private DevExpress.XtraEditors.TextEdit txtExercice;
        private DevExpress.XtraEditors.TextEdit txtSociete;
        private DevExpress.XtraLayout.LayoutControlGroup lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup lcgDetail;
        private DevExpress.XtraLayout.LayoutControlItem lciExercice;
        private DevExpress.XtraLayout.LayoutControlItem Societe;
        private DevExpress.XtraLayout.LayoutControlGroup lcgButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.TextEdit txtMotif;
        private DevExpress.XtraEditors.DateEdit dtEcheance;
        private DevExpress.XtraLayout.LayoutControlItem lciDateEcheance;
        private DevExpress.XtraLayout.LayoutControlItem lciMotif;
        private DevExpress.XtraEditors.TextEdit txtReferenceEnvoi;
        private DevExpress.XtraLayout.LayoutControlItem lciReferenceEnvoie;
        private DevExpress.XtraEditors.TextEdit txtRib;
        private DevExpress.XtraEditors.GridLookUpEdit gleBanque;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem lciBanque;
        private DevExpress.XtraLayout.LayoutControlItem lciRib;
    }
}