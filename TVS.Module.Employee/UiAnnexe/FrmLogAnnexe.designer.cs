namespace TVS.Module.Employee.UiAnnexe
{
    partial class FrmLogAnnexe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogAnnexe));
            this.lcm = new DevExpress.XtraLayout.LayoutControl();
            this.txtLog = new DevExpress.XtraEditors.MemoEdit();
            this.btnExporter = new DevExpress.XtraEditors.SimpleButton();
            this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciTxtLog = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciBtnExporter = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcm)).BeginInit();
            this.lcm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLog.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTxtLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnExporter)).BeginInit();
            this.SuspendLayout();
            // 
            // lcm
            // 
            this.lcm.Controls.Add(this.txtLog);
            this.lcm.Controls.Add(this.btnExporter);
            this.lcm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcm.Location = new System.Drawing.Point(0, 0);
            this.lcm.Name = "lcm";
            this.lcm.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-989, 33, 407, 450);
            this.lcm.Root = this.lcgMain;
            this.lcm.Size = new System.Drawing.Size(562, 413);
            this.lcm.TabIndex = 0;
            this.lcm.Text = "layoutControl1";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(2, 2);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(558, 369);
            this.txtLog.StyleController = this.lcm;
            this.txtLog.TabIndex = 6;
            // 
            // btnExporter
            // 
            this.btnExporter.Image = ((System.Drawing.Image)(resources.GetObject("btnExporter.Image")));
            this.btnExporter.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExporter.Location = new System.Drawing.Point(464, 375);
            this.btnExporter.Name = "btnExporter";
            this.btnExporter.Size = new System.Drawing.Size(96, 36);
            this.btnExporter.StyleController = this.lcm;
            this.btnExporter.TabIndex = 5;
            this.btnExporter.Text = "Exporter";
            // 
            // lcgMain
            // 
            this.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMain.GroupBordersVisible = false;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciTxtLog,
            this.emptySpaceItem2,
            this.lciBtnExporter});
            this.lcgMain.Location = new System.Drawing.Point(0, 0);
            this.lcgMain.Name = "Root";
            this.lcgMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgMain.Size = new System.Drawing.Size(562, 413);
            this.lcgMain.TextVisible = false;
            // 
            // lciTxtLog
            // 
            this.lciTxtLog.Control = this.txtLog;
            this.lciTxtLog.Location = new System.Drawing.Point(0, 0);
            this.lciTxtLog.Name = "lciTxtLog";
            this.lciTxtLog.Size = new System.Drawing.Size(562, 373);
            this.lciTxtLog.TextSize = new System.Drawing.Size(0, 0);
            this.lciTxtLog.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 373);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(462, 40);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciBtnExporter
            // 
            this.lciBtnExporter.Control = this.btnExporter;
            this.lciBtnExporter.Location = new System.Drawing.Point(462, 373);
            this.lciBtnExporter.MaxSize = new System.Drawing.Size(100, 40);
            this.lciBtnExporter.MinSize = new System.Drawing.Size(100, 40);
            this.lciBtnExporter.Name = "lciBtnExporter";
            this.lciBtnExporter.Size = new System.Drawing.Size(100, 40);
            this.lciBtnExporter.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciBtnExporter.TextSize = new System.Drawing.Size(0, 0);
            this.lciBtnExporter.TextVisible = false;
            // 
            // FrmLogAnnexe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 413);
            this.Controls.Add(this.lcm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogAnnexe";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Erreur d\'importation";
            ((System.ComponentModel.ISupportInitialize)(this.lcm)).EndInit();
            this.lcm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLog.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTxtLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnExporter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcm;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMain;
        private DevExpress.XtraEditors.MemoEdit txtLog;
        private DevExpress.XtraEditors.SimpleButton btnExporter;
        private DevExpress.XtraLayout.LayoutControlItem lciBtnExporter;
        private DevExpress.XtraLayout.LayoutControlItem lciTxtLog;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}