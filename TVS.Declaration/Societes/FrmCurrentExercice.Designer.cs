namespace TVS.Declaration
{
    partial class FrmCurrentExercice
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnAnnuler = new DevExpress.XtraEditors.SimpleButton();
            this.btnValider = new DevExpress.XtraEditors.SimpleButton();
            this.cbSociete = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cbExercice = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciGrroupParam = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciSociete = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciExercice = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciValider = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSupprimer = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSociete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbExercice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGrroupParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSociete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExercice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciValider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSupprimer)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnAnnuler);
            this.layoutControl1.Controls.Add(this.btnValider);
            this.layoutControl1.Controls.Add(this.cbSociete);
            this.layoutControl1.Controls.Add(this.cbExercice);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(812, 149, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(303, 128);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(202, 98);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(94, 22);
            this.btnAnnuler.StyleController = this.layoutControl1;
            this.btnAnnuler.TabIndex = 5;
            this.btnAnnuler.Text = "&Annuler";
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(104, 98);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(94, 22);
            this.btnValider.StyleController = this.layoutControl1;
            this.btnValider.TabIndex = 4;
            this.btnValider.Text = "&Valider";
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // cbSociete
            // 
            this.cbSociete.Location = new System.Drawing.Point(99, 33);
            this.cbSociete.Name = "cbSociete";
            this.cbSociete.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSociete.Properties.NullText = "";
            this.cbSociete.Properties.View = this.gridLookUpEdit1View;
            this.cbSociete.Size = new System.Drawing.Size(190, 20);
            this.cbSociete.TabIndex = 6;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // cbExercice
            // 
            this.cbExercice.Location = new System.Drawing.Point(99, 57);
            this.cbExercice.Name = "cbExercice";
            this.cbExercice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbExercice.Properties.NullText = "";
            this.cbExercice.Properties.View = this.gridView1;
            this.cbExercice.Size = new System.Drawing.Size(190, 20);
            this.cbExercice.TabIndex = 7;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciGrroupParam,
            this.layoutControlGroup3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(303, 128);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lciGrroupParam
            // 
            this.lciGrroupParam.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciSociete,
            this.lciExercice});
            this.lciGrroupParam.Location = new System.Drawing.Point(0, 0);
            this.lciGrroupParam.Name = "lciGrroupParam";
            this.lciGrroupParam.Size = new System.Drawing.Size(303, 91);
            this.lciGrroupParam.Text = "Configuration";
            // 
            // lciSociete
            // 
            this.lciSociete.Control = this.cbSociete;
            this.lciSociete.Location = new System.Drawing.Point(0, 0);
            this.lciSociete.Name = "lciSociete";
            this.lciSociete.Size = new System.Drawing.Size(279, 24);
            this.lciSociete.Text = "Société";
            this.lciSociete.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciSociete.TextSize = new System.Drawing.Size(80, 20);
            this.lciSociete.TextToControlDistance = 5;
            // 
            // lciExercice
            // 
            this.lciExercice.Control = this.cbExercice;
            this.lciExercice.Location = new System.Drawing.Point(0, 24);
            this.lciExercice.Name = "lciExercice";
            this.lciExercice.Size = new System.Drawing.Size(279, 24);
            this.lciExercice.Text = "Exercice";
            this.lciExercice.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciExercice.TextSize = new System.Drawing.Size(80, 20);
            this.lciExercice.TextToControlDistance = 5;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.lciValider,
            this.lciSupprimer});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 91);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup3.Size = new System.Drawing.Size(303, 37);
            this.layoutControlGroup3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(97, 27);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciValider
            // 
            this.lciValider.Control = this.btnValider;
            this.lciValider.Location = new System.Drawing.Point(97, 0);
            this.lciValider.MaxSize = new System.Drawing.Size(98, 26);
            this.lciValider.MinSize = new System.Drawing.Size(98, 26);
            this.lciValider.Name = "lciValider";
            this.lciValider.Size = new System.Drawing.Size(98, 27);
            this.lciValider.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciValider.Text = "&Valider";
            this.lciValider.TextSize = new System.Drawing.Size(0, 0);
            this.lciValider.TextVisible = false;
            // 
            // lciSupprimer
            // 
            this.lciSupprimer.Control = this.btnAnnuler;
            this.lciSupprimer.Location = new System.Drawing.Point(195, 0);
            this.lciSupprimer.MaxSize = new System.Drawing.Size(98, 26);
            this.lciSupprimer.MinSize = new System.Drawing.Size(98, 26);
            this.lciSupprimer.Name = "lciSupprimer";
            this.lciSupprimer.Size = new System.Drawing.Size(98, 27);
            this.lciSupprimer.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciSupprimer.TextSize = new System.Drawing.Size(0, 0);
            this.lciSupprimer.TextVisible = false;
            // 
            // FrmCurrentExercice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 128);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCurrentExercice";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exercice en cours ";
            this.Load += new System.EventHandler(this.FrmCurrentExercice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbSociete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbExercice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGrroupParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSociete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciExercice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciValider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSupprimer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnAnnuler;
        private DevExpress.XtraEditors.SimpleButton btnValider;
        private DevExpress.XtraEditors.GridLookUpEdit cbSociete;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.GridLookUpEdit cbExercice;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup lciGrroupParam;
        private DevExpress.XtraLayout.LayoutControlItem lciSociete;
        private DevExpress.XtraLayout.LayoutControlItem lciExercice;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem lciValider;
        private DevExpress.XtraLayout.LayoutControlItem lciSupprimer;
    }
}