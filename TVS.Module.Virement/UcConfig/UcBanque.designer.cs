namespace TVS.Module.Virement.UcConfig
{
    partial class UcBanque
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
            this.txtRib = new DevExpress.XtraEditors.TextEdit();
            this.btNouveau = new DevExpress.XtraEditors.SimpleButton();
            this.btSupprimer = new DevExpress.XtraEditors.SimpleButton();
            this.txtAgence = new DevExpress.XtraEditors.TextEdit();
            this.txtAdresse = new DevExpress.XtraEditors.TextEdit();
            this.btEnregistrer = new DevExpress.XtraEditors.SimpleButton();
            this.gridBanque = new DevExpress.XtraGrid.GridControl();
            this.viewBanque = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gleTypeBanque = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgButton = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciEnregister = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciAdresse = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciIntitule = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciRib = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBanque = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRib.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgence.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdresse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBanque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewBanque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleTypeBanque.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEnregister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIntitule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRib)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBanque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.txtRib);
            this.lcMain.Controls.Add(this.btNouveau);
            this.lcMain.Controls.Add(this.btSupprimer);
            this.lcMain.Controls.Add(this.txtAgence);
            this.lcMain.Controls.Add(this.txtAdresse);
            this.lcMain.Controls.Add(this.btEnregistrer);
            this.lcMain.Controls.Add(this.gridBanque);
            this.lcMain.Controls.Add(this.gleTypeBanque);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1021, 230, 250, 350);
            this.lcMain.Root = this.layoutControlGroup1;
            this.lcMain.Size = new System.Drawing.Size(424, 438);
            this.lcMain.TabIndex = 1;
            this.lcMain.Text = "layoutControl1";
            // 
            // txtRib
            // 
            this.txtRib.Location = new System.Drawing.Point(87, 380);
            this.txtRib.Name = "txtRib";
            this.txtRib.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtRib.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtRib.Properties.Mask.EditMask = "[0-9]*";
            this.txtRib.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtRib.Properties.MaxLength = 20;
            this.txtRib.Size = new System.Drawing.Size(325, 20);
            this.txtRib.StyleController = this.lcMain;
            this.txtRib.TabIndex = 27;
            // 
            // btNouveau
            // 
            this.btNouveau.Location = new System.Drawing.Point(117, 409);
            this.btNouveau.Name = "btNouveau";
            this.btNouveau.Size = new System.Drawing.Size(99, 22);
            this.btNouveau.StyleController = this.lcMain;
            this.btNouveau.TabIndex = 25;
            this.btNouveau.Text = "Nouveau";
            // 
            // btSupprimer
            // 
            this.btSupprimer.Location = new System.Drawing.Point(220, 409);
            this.btSupprimer.Name = "btSupprimer";
            this.btSupprimer.Size = new System.Drawing.Size(97, 22);
            this.btSupprimer.StyleController = this.lcMain;
            this.btSupprimer.TabIndex = 24;
            this.btSupprimer.Text = "Supprimer";
            // 
            // txtAgence
            // 
            this.txtAgence.Location = new System.Drawing.Point(88, 332);
            this.txtAgence.Name = "txtAgence";
            this.txtAgence.Properties.MaxLength = 250;
            this.txtAgence.Size = new System.Drawing.Size(122, 20);
            this.txtAgence.StyleController = this.lcMain;
            this.txtAgence.TabIndex = 19;
            // 
            // txtAdresse
            // 
            this.txtAdresse.Location = new System.Drawing.Point(88, 356);
            this.txtAdresse.Name = "txtAdresse";
            this.txtAdresse.Size = new System.Drawing.Size(324, 20);
            this.txtAdresse.StyleController = this.lcMain;
            this.txtAdresse.TabIndex = 17;
            // 
            // btEnregistrer
            // 
            this.btEnregistrer.Location = new System.Drawing.Point(321, 409);
            this.btEnregistrer.Name = "btEnregistrer";
            this.btEnregistrer.Size = new System.Drawing.Size(96, 22);
            this.btEnregistrer.StyleController = this.lcMain;
            this.btEnregistrer.TabIndex = 16;
            this.btEnregistrer.Text = "&Enregistrer";
            // 
            // gridBanque
            // 
            this.gridBanque.Location = new System.Drawing.Point(7, 7);
            this.gridBanque.MainView = this.viewBanque;
            this.gridBanque.Name = "gridBanque";
            this.gridBanque.Size = new System.Drawing.Size(410, 316);
            this.gridBanque.TabIndex = 14;
            this.gridBanque.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewBanque});
            // 
            // viewBanque
            // 
            this.viewBanque.GridControl = this.gridBanque;
            this.viewBanque.Name = "viewBanque";
            // 
            // gleTypeBanque
            // 
            this.gleTypeBanque.Location = new System.Drawing.Point(259, 332);
            this.gleTypeBanque.Name = "gleTypeBanque";
            this.gleTypeBanque.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gleTypeBanque.Properties.NullText = "";
            this.gleTypeBanque.Properties.View = this.gridLookUpEdit1View;
            this.gleTypeBanque.Size = new System.Drawing.Size(153, 20);
            this.gleTypeBanque.StyleController = this.lcMain;
            this.gleTypeBanque.TabIndex = 26;
            this.gleTypeBanque.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgButton});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(424, 438);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lcgButton
            // 
            this.lcgButton.CustomizationFormText = "lcgButton";
            this.lcgButton.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciEnregister,
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlGroup2,
            this.layoutControlItem2,
            this.layoutControlItem5});
            this.lcgButton.Location = new System.Drawing.Point(0, 0);
            this.lcgButton.Name = "lcgButton";
            this.lcgButton.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.lcgButton.Size = new System.Drawing.Size(424, 438);
            this.lcgButton.TextVisible = false;
            // 
            // lciEnregister
            // 
            this.lciEnregister.Control = this.btEnregistrer;
            this.lciEnregister.CustomizationFormText = "lciEnregister";
            this.lciEnregister.Location = new System.Drawing.Point(314, 402);
            this.lciEnregister.MaxSize = new System.Drawing.Size(100, 26);
            this.lciEnregister.MinSize = new System.Drawing.Size(100, 26);
            this.lciEnregister.Name = "lciEnregister";
            this.lciEnregister.Size = new System.Drawing.Size(100, 26);
            this.lciEnregister.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciEnregister.TextSize = new System.Drawing.Size(0, 0);
            this.lciEnregister.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridBanque;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(414, 320);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 402);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(110, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciAdresse,
            this.lciIntitule,
            this.lciRib,
            this.lciBanque});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 320);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup2.Size = new System.Drawing.Size(414, 82);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // lciAdresse
            // 
            this.lciAdresse.Control = this.txtAdresse;
            this.lciAdresse.CustomizationFormText = "Code Exploitation";
            this.lciAdresse.Location = new System.Drawing.Point(0, 24);
            this.lciAdresse.Name = "lciAdresse";
            this.lciAdresse.Size = new System.Drawing.Size(404, 24);
            this.lciAdresse.Spacing = new DevExpress.XtraLayout.Utils.Padding(6, 0, 0, 0);
            this.lciAdresse.Text = "Adresse";
            this.lciAdresse.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciAdresse.TextSize = new System.Drawing.Size(70, 13);
            this.lciAdresse.TextToControlDistance = 0;
            // 
            // lciIntitule
            // 
            this.lciIntitule.Control = this.txtAgence;
            this.lciIntitule.CustomizationFormText = "Intitule";
            this.lciIntitule.Location = new System.Drawing.Point(0, 0);
            this.lciIntitule.Name = "lciIntitule";
            this.lciIntitule.Size = new System.Drawing.Size(202, 24);
            this.lciIntitule.Spacing = new DevExpress.XtraLayout.Utils.Padding(6, 0, 0, 0);
            this.lciIntitule.Text = "Agence";
            this.lciIntitule.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciIntitule.TextSize = new System.Drawing.Size(70, 13);
            this.lciIntitule.TextToControlDistance = 0;
            // 
            // lciRib
            // 
            this.lciRib.Control = this.txtRib;
            this.lciRib.Location = new System.Drawing.Point(0, 48);
            this.lciRib.Name = "lciRib";
            this.lciRib.Size = new System.Drawing.Size(404, 24);
            this.lciRib.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 0, 0, 0);
            this.lciRib.Text = "Rib";
            this.lciRib.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciRib.TextSize = new System.Drawing.Size(70, 13);
            this.lciRib.TextToControlDistance = 0;
            // 
            // lciBanque
            // 
            this.lciBanque.Control = this.gleTypeBanque;
            this.lciBanque.Location = new System.Drawing.Point(202, 0);
            this.lciBanque.MinSize = new System.Drawing.Size(178, 24);
            this.lciBanque.Name = "lciBanque";
            this.lciBanque.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 2, 2, 2);
            this.lciBanque.Size = new System.Drawing.Size(202, 24);
            this.lciBanque.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciBanque.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 0, 0, 0);
            this.lciBanque.Text = "Banque";
            this.lciBanque.TextSize = new System.Drawing.Size(36, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btSupprimer;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(213, 402);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(101, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(101, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(101, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btNouveau;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(110, 402);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(103, 26);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(103, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(103, 26);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // UcBanque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcMain);
            this.Name = "UcBanque";
            this.Size = new System.Drawing.Size(424, 438);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRib.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgence.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdresse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBanque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewBanque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleTypeBanque.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEnregister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIntitule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRib)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBanque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraEditors.TextEdit txtAgence;
        private DevExpress.XtraEditors.TextEdit txtAdresse;
        private DevExpress.XtraEditors.SimpleButton btEnregistrer;
        private DevExpress.XtraGrid.GridControl gridBanque;
        private DevExpress.XtraGrid.Views.Grid.GridView viewBanque;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgButton;
        private DevExpress.XtraLayout.LayoutControlItem lciEnregister;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem lciIntitule;
        private DevExpress.XtraLayout.LayoutControlItem lciAdresse;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.SimpleButton btNouveau;
        private DevExpress.XtraEditors.SimpleButton btSupprimer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.TextEdit txtRib;
        private DevExpress.XtraLayout.LayoutControlItem lciBanque;
        private DevExpress.XtraLayout.LayoutControlItem lciRib;
        private DevExpress.XtraEditors.GridLookUpEdit gleTypeBanque;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
    }
}
