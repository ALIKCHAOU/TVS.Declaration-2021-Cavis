namespace TVS.Declaration
{
    partial class FrmMatriculeFiscale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMatriculeFiscale));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtCleRib = new System.Windows.Forms.TextBox();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.txtIdentiteBancaire = new DevExpress.XtraEditors.TextEdit();
            this.txtCle = new DevExpress.XtraEditors.TextEdit();
            this.btVerifier = new DevExpress.XtraEditors.SimpleButton();
            this.txtMatriculFiscale = new DevExpress.XtraEditors.TextEdit();
            this.txtMatricule = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciMatricul = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCle = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciMatriculeFiscale = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgVerifCleRib = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciRib = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdentiteBancaire.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatriculFiscale.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatricule.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMatricul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMatriculeFiscale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgVerifCleRib)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRib)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtCleRib);
            this.layoutControl1.Controls.Add(this.textEdit2);
            this.layoutControl1.Controls.Add(this.txtIdentiteBancaire);
            this.layoutControl1.Controls.Add(this.txtCle);
            this.layoutControl1.Controls.Add(this.btVerifier);
            this.layoutControl1.Controls.Add(this.txtMatriculFiscale);
            this.layoutControl1.Controls.Add(this.txtMatricule);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(769, 171, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(301, 224);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtCleRib
            // 
            this.txtCleRib.Location = new System.Drawing.Point(226, 179);
            this.txtCleRib.Name = "txtCleRib";
            this.txtCleRib.ReadOnly = true;
            this.txtCleRib.Size = new System.Drawing.Size(51, 20);
            this.txtCleRib.TabIndex = 12;
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(258, 146);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(50, 20);
            this.textEdit2.StyleController = this.layoutControl1;
            this.textEdit2.TabIndex = 11;
            // 
            // txtIdentiteBancaire
            // 
            this.txtIdentiteBancaire.Location = new System.Drawing.Point(79, 179);
            this.txtIdentiteBancaire.Name = "txtIdentiteBancaire";
            this.txtIdentiteBancaire.Properties.Mask.EditMask = "[0-9]*";
            this.txtIdentiteBancaire.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtIdentiteBancaire.Properties.MaxLength = 18;
            this.txtIdentiteBancaire.Size = new System.Drawing.Size(143, 20);
            this.txtIdentiteBancaire.StyleController = this.layoutControl1;
            this.txtIdentiteBancaire.TabIndex = 10;
            // 
            // txtCle
            // 
            this.txtCle.Location = new System.Drawing.Point(227, 43);
            this.txtCle.Name = "txtCle";
            this.txtCle.Properties.ReadOnly = true;
            this.txtCle.Size = new System.Drawing.Size(50, 20);
            this.txtCle.StyleController = this.layoutControl1;
            this.txtCle.TabIndex = 9;
            // 
            // btVerifier
            // 
            this.btVerifier.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btVerifier.ImageOptions.Image")));
            this.btVerifier.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btVerifier.Location = new System.Drawing.Point(226, 110);
            this.btVerifier.Name = "btVerifier";
            this.btVerifier.Size = new System.Drawing.Size(51, 22);
            this.btVerifier.StyleController = this.layoutControl1;
            this.btVerifier.TabIndex = 7;
            this.btVerifier.Click += new System.EventHandler(this.btVerifier_Click);
            // 
            // txtMatriculFiscale
            // 
            this.txtMatriculFiscale.Location = new System.Drawing.Point(99, 110);
            this.txtMatriculFiscale.Name = "txtMatriculFiscale";
            this.txtMatriculFiscale.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMatriculFiscale.Properties.MaxLength = 13;
            this.txtMatriculFiscale.Size = new System.Drawing.Size(123, 20);
            this.txtMatriculFiscale.StyleController = this.layoutControl1;
            this.txtMatriculFiscale.TabIndex = 5;
            // 
            // txtMatricule
            // 
            this.txtMatricule.Location = new System.Drawing.Point(99, 43);
            this.txtMatricule.Name = "txtMatricule";
            this.txtMatricule.Properties.MaxLength = 7;
            this.txtMatricule.Size = new System.Drawing.Size(124, 20);
            this.txtMatricule.StyleController = this.layoutControl1;
            this.txtMatricule.TabIndex = 4;
            this.txtMatricule.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEdit2;
            this.layoutControlItem2.Location = new System.Drawing.Point(150, 134);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(150, 24);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(50, 20);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.lcgVerifCleRib});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(301, 224);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciMatricul,
            this.lciCle});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(281, 67);
            this.layoutControlGroup2.Text = "Générer clé matricule";
            // 
            // lciMatricul
            // 
            this.lciMatricul.Control = this.txtMatricule;
            this.lciMatricul.Location = new System.Drawing.Point(0, 0);
            this.lciMatricul.MaxSize = new System.Drawing.Size(203, 24);
            this.lciMatricul.MinSize = new System.Drawing.Size(203, 24);
            this.lciMatricul.Name = "lciMatricul";
            this.lciMatricul.Size = new System.Drawing.Size(203, 24);
            this.lciMatricul.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciMatricul.Text = "Matricule";
            this.lciMatricul.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciMatricul.TextSize = new System.Drawing.Size(70, 20);
            this.lciMatricul.TextToControlDistance = 5;
            // 
            // lciCle
            // 
            this.lciCle.Control = this.txtCle;
            this.lciCle.Location = new System.Drawing.Point(203, 0);
            this.lciCle.Name = "lciCle";
            this.lciCle.Size = new System.Drawing.Size(54, 24);
            this.lciCle.TextSize = new System.Drawing.Size(0, 0);
            this.lciCle.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciMatriculeFiscale,
            this.layoutControlItem4});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 67);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(281, 69);
            this.layoutControlGroup3.Text = "Vérifier matricule";
            // 
            // lciMatriculeFiscale
            // 
            this.lciMatriculeFiscale.Control = this.txtMatriculFiscale;
            this.lciMatriculeFiscale.CustomizationFormText = "Matricul fiscale";
            this.lciMatriculeFiscale.Location = new System.Drawing.Point(0, 0);
            this.lciMatriculeFiscale.MaxSize = new System.Drawing.Size(202, 26);
            this.lciMatriculeFiscale.MinSize = new System.Drawing.Size(202, 26);
            this.lciMatriculeFiscale.Name = "lciMatriculeFiscale";
            this.lciMatriculeFiscale.Size = new System.Drawing.Size(202, 26);
            this.lciMatriculeFiscale.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciMatriculeFiscale.Text = "Matricule fiscal";
            this.lciMatriculeFiscale.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciMatriculeFiscale.TextSize = new System.Drawing.Size(70, 20);
            this.lciMatriculeFiscale.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btVerifier;
            this.layoutControlItem4.Location = new System.Drawing.Point(202, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(55, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // lcgVerifCleRib
            // 
            this.lcgVerifCleRib.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciRib,
            this.layoutControlItem3});
            this.lcgVerifCleRib.Location = new System.Drawing.Point(0, 136);
            this.lcgVerifCleRib.Name = "lcgVerifCleRib";
            this.lcgVerifCleRib.Size = new System.Drawing.Size(281, 68);
            this.lcgVerifCleRib.Text = "Vérifier clé RIB bancaire";
            // 
            // lciRib
            // 
            this.lciRib.Control = this.txtIdentiteBancaire;
            this.lciRib.Location = new System.Drawing.Point(0, 0);
            this.lciRib.Name = "lciRib";
            this.lciRib.Size = new System.Drawing.Size(202, 25);
            this.lciRib.Text = "RIB";
            this.lciRib.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciRib.TextSize = new System.Drawing.Size(50, 20);
            this.lciRib.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtCleRib;
            this.layoutControlItem3.Location = new System.Drawing.Point(202, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(55, 25);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // FrmMatriculeFiscale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 224);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMatriculeFiscale";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vérifier clé";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdentiteBancaire.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatriculFiscale.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatricule.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMatricul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMatriculeFiscale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgVerifCleRib)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRib)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtCle;
        private DevExpress.XtraEditors.SimpleButton btVerifier;
        private DevExpress.XtraEditors.TextEdit txtMatriculFiscale;
        private DevExpress.XtraEditors.TextEdit txtMatricule;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem lciMatricul;
        private DevExpress.XtraLayout.LayoutControlItem lciCle;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem lciMatriculeFiscale;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.TextBox txtCleRib;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit txtIdentiteBancaire;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup lcgVerifCleRib;
        private DevExpress.XtraLayout.LayoutControlItem lciRib;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}