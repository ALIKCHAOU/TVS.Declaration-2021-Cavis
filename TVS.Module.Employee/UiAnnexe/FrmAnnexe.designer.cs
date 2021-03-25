using DevExpress.XtraEditors;
using TVS.Core.Interfaces;
using TVS.Module.Employee.Models;

namespace TVS.Module.Employee.UiAnnexe
{
    partial class FrmAnnexe<TL, TP>
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnExporter = new DevExpress.XtraBars.BarButtonItem();
            this.btnExporterExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnImprimerList = new DevExpress.XtraBars.BarButtonItem();
            this.btnImprimer = new DevExpress.XtraBars.BarButtonItem();
            this.btCustomReport = new DevExpress.XtraBars.BarButtonItem();
            this.rbpAccueil = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbpgAccueil = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.lcmPanel1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnImporter = new DevExpress.XtraEditors.SimpleButton();
            this.btnAjouter = new DevExpress.XtraEditors.SimpleButton();
            this.gcLigneZoneValue = new DevExpress.XtraGrid.GridControl();
            this.gvLigneZoneValue = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lcgMainPanel1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgGridLigne = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcmPanel2 = new DevExpress.XtraLayout.LayoutControl();
            this.gcLignesAnnexes = new DevExpress.XtraGrid.GridControl();
            this.gvLignesAnnexes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lcgMainPanel2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgGridLigneZoneValue = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcmPanel1)).BeginInit();
            this.lcmPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcLigneZoneValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLigneZoneValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMainPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGridLigne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcmPanel2)).BeginInit();
            this.lcmPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcLignesAnnexes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLignesAnnexes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMainPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGridLigneZoneValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnExporter,
            this.btnExporterExcel,
            this.btnImprimerList,
            this.btnImprimer,
            this.btCustomReport});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 3;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbpAccueil});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowCategoryInCaption = false;
            this.ribbon.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Show;
            this.ribbon.ShowQatLocationSelector = false;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(1118, 143);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // btnExporter
            // 
            this.btnExporter.Caption = "Générer fichier";
            this.btnExporter.Id = 5;
            this.btnExporter.ImageOptions.Image = global::TVS.Module.Employee.Properties.Resources.exporttotxt_16x16;
            this.btnExporter.ImageOptions.LargeImage = global::TVS.Module.Employee.Properties.Resources.exporttotxt_32x32;
            this.btnExporter.Name = "btnExporter";
            this.btnExporter.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // btnExporterExcel
            // 
            this.btnExporterExcel.Caption = "Exporter Excel";
            this.btnExporterExcel.Id = 5;
            this.btnExporterExcel.ImageOptions.Image = global::TVS.Module.Employee.Properties.Resources.exporttoxlsx_16x16;
            this.btnExporterExcel.ImageOptions.LargeImage = global::TVS.Module.Employee.Properties.Resources.exporttoxlsx_32x32;
            this.btnExporterExcel.Name = "btnExporterExcel";
            this.btnExporterExcel.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // btnImprimerList
            // 
            this.btnImprimerList.Caption = "Imprimer Annexe";
            this.btnImprimerList.Id = 5;
            this.btnImprimerList.ImageOptions.Image = global::TVS.Module.Employee.Properties.Resources.preview_16x16;
            this.btnImprimerList.ImageOptions.LargeImage = global::TVS.Module.Employee.Properties.Resources.preview_32x32;
            this.btnImprimerList.Name = "btnImprimerList";
            this.btnImprimerList.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // btnImprimer
            // 
            this.btnImprimer.Caption = "Imprimer certificat";
            this.btnImprimer.Id = 5;
            this.btnImprimer.ImageOptions.Image = global::TVS.Module.Employee.Properties.Resources.print_16x16;
            this.btnImprimer.ImageOptions.LargeImage = global::TVS.Module.Employee.Properties.Resources.print_32x32;
            this.btnImprimer.Name = "btnImprimer";
            this.btnImprimer.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // btCustomReport
            // 
            this.btCustomReport.Caption = "Personnaliser la certificat";
            this.btCustomReport.Id = 2;
            this.btCustomReport.ImageOptions.Image = global::TVS.Module.Employee.Properties.Resources.printquick_32x32;
            this.btCustomReport.ImageOptions.LargeImage = global::TVS.Module.Employee.Properties.Resources.printquick_32x32;
            this.btCustomReport.Name = "btCustomReport";
            // 
            // rbpAccueil
            // 
            this.rbpAccueil.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbpgAccueil});
            this.rbpAccueil.Name = "rbpAccueil";
            this.rbpAccueil.Text = "Fichier";
            // 
            // rbpgAccueil
            // 
            this.rbpgAccueil.AllowTextClipping = false;
            this.rbpgAccueil.ItemLinks.Add(this.btnExporter);
            this.rbpgAccueil.ItemLinks.Add(this.btnExporterExcel);
            this.rbpgAccueil.ItemLinks.Add(this.btnImprimerList);
            this.rbpgAccueil.ItemLinks.Add(this.btnImprimer);
            this.rbpgAccueil.ItemLinks.Add(this.btCustomReport);
            this.rbpgAccueil.Name = "rbpgAccueil";
            this.rbpgAccueil.ShowCaptionButton = false;
            this.rbpgAccueil.Text = "Déclaration employeurs";
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 143);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.lcmPanel1);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.lcmPanel2);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(1118, 545);
            this.splitContainerControl.SplitterPosition = 150;
            this.splitContainerControl.TabIndex = 2;
            this.splitContainerControl.Text = "splitContainerControl1";
            // 
            // lcmPanel1
            // 
            this.lcmPanel1.Controls.Add(this.btnDelete);
            this.lcmPanel1.Controls.Add(this.btnSave);
            this.lcmPanel1.Controls.Add(this.btnImporter);
            this.lcmPanel1.Controls.Add(this.btnAjouter);
            this.lcmPanel1.Controls.Add(this.gcLigneZoneValue);
            this.lcmPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcmPanel1.Location = new System.Drawing.Point(0, 0);
            this.lcmPanel1.Name = "lcmPanel1";
            this.lcmPanel1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1075, 249, 250, 350);
            this.lcmPanel1.Root = this.lcgMainPanel1;
            this.lcmPanel1.Size = new System.Drawing.Size(150, 545);
            this.lcmPanel1.TabIndex = 0;
            this.lcmPanel1.Text = "layoutControl1";
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = global::TVS.Module.Employee.Properties.Resources.cancel_16x16;
            this.btnDelete.Location = new System.Drawing.Point(5, 31);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(81, 22);
            this.btnDelete.StyleController = this.lcmPanel1;
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Supprimer";
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = global::TVS.Module.Employee.Properties.Resources.save_16x16;
            this.btnSave.Location = new System.Drawing.Point(5, 57);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 22);
            this.btnSave.StyleController = this.lcmPanel1;
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Enregistrer";
            // 
            // btnImporter
            // 
            this.btnImporter.ImageOptions.Image = global::TVS.Module.Employee.Properties.Resources.exporttocsv_16x16;
            this.btnImporter.Location = new System.Drawing.Point(5, 83);
            this.btnImporter.Name = "btnImporter";
            this.btnImporter.Size = new System.Drawing.Size(81, 22);
            this.btnImporter.StyleController = this.lcmPanel1;
            this.btnImporter.TabIndex = 5;
            this.btnImporter.Text = "Importer";
            // 
            // btnAjouter
            // 
            this.btnAjouter.ImageOptions.Image = global::TVS.Module.Employee.Properties.Resources.additem_16x16;
            this.btnAjouter.Location = new System.Drawing.Point(5, 5);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(81, 22);
            this.btnAjouter.StyleController = this.lcmPanel1;
            this.btnAjouter.TabIndex = 4;
            this.btnAjouter.Text = "Ajouter";
            // 
            // gcLigneZoneValue
            // 
            this.gcLigneZoneValue.Location = new System.Drawing.Point(90, 5);
            this.gcLigneZoneValue.MainView = this.gvLigneZoneValue;
            this.gcLigneZoneValue.MenuManager = this.ribbon;
            this.gcLigneZoneValue.Name = "gcLigneZoneValue";
            this.gcLigneZoneValue.Size = new System.Drawing.Size(100, 518);
            this.gcLigneZoneValue.TabIndex = 0;
            this.gcLigneZoneValue.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLigneZoneValue});
            // 
            // gvLigneZoneValue
            // 
            this.gvLigneZoneValue.GridControl = this.gcLigneZoneValue;
            this.gvLigneZoneValue.Name = "gvLigneZoneValue";
            // 
            // lcgMainPanel1
            // 
            this.lcgMainPanel1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMainPanel1.GroupBordersVisible = false;
            this.lcgMainPanel1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgGridLigne});
            this.lcgMainPanel1.Location = new System.Drawing.Point(0, 0);
            this.lcgMainPanel1.Name = "Root";
            this.lcgMainPanel1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgMainPanel1.Size = new System.Drawing.Size(195, 528);
            this.lcgMainPanel1.TextVisible = false;
            // 
            // lcgGridLigne
            // 
            this.lcgGridLigne.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem1});
            this.lcgGridLigne.Location = new System.Drawing.Point(0, 0);
            this.lcgGridLigne.Name = "lcgGridLigne";
            this.lcgGridLigne.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgGridLigne.Size = new System.Drawing.Size(195, 528);
            this.lcgGridLigne.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcLigneZoneValue;
            this.layoutControlItem1.Location = new System.Drawing.Point(85, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(104, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(104, 522);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnAjouter;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(85, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnImporter;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 78);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(85, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnSave;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(85, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnDelete;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(85, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 104);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(80, 0);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(80, 10);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(85, 418);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcmPanel2
            // 
            this.lcmPanel2.Controls.Add(this.gcLignesAnnexes);
            this.lcmPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcmPanel2.Location = new System.Drawing.Point(0, 0);
            this.lcmPanel2.Name = "lcmPanel2";
            this.lcmPanel2.Root = this.lcgMainPanel2;
            this.lcmPanel2.Size = new System.Drawing.Size(963, 545);
            this.lcmPanel2.TabIndex = 0;
            this.lcmPanel2.Text = "layoutControl1";
            // 
            // gcLignesAnnexes
            // 
            this.gcLignesAnnexes.Location = new System.Drawing.Point(5, 5);
            this.gcLignesAnnexes.MainView = this.gvLignesAnnexes;
            this.gcLignesAnnexes.MenuManager = this.ribbon;
            this.gcLignesAnnexes.Name = "gcLignesAnnexes";
            this.gcLignesAnnexes.Size = new System.Drawing.Size(953, 535);
            this.gcLignesAnnexes.TabIndex = 4;
            this.gcLignesAnnexes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLignesAnnexes});
            // 
            // gvLignesAnnexes
            // 
            this.gvLignesAnnexes.GridControl = this.gcLignesAnnexes;
            this.gvLignesAnnexes.Name = "gvLignesAnnexes";
            // 
            // lcgMainPanel2
            // 
            this.lcgMainPanel2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMainPanel2.GroupBordersVisible = false;
            this.lcgMainPanel2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgGridLigneZoneValue});
            this.lcgMainPanel2.Location = new System.Drawing.Point(0, 0);
            this.lcgMainPanel2.Name = "lcgMainPanel2";
            this.lcgMainPanel2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgMainPanel2.Size = new System.Drawing.Size(963, 545);
            this.lcgMainPanel2.TextVisible = false;
            // 
            // lcgGridLigneZoneValue
            // 
            this.lcgGridLigneZoneValue.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.lcgGridLigneZoneValue.Location = new System.Drawing.Point(0, 0);
            this.lcgGridLigneZoneValue.Name = "lcgGridLigneZoneValue";
            this.lcgGridLigneZoneValue.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgGridLigneZoneValue.Size = new System.Drawing.Size(963, 545);
            this.lcgGridLigneZoneValue.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gcLignesAnnexes;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(957, 539);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // FrmAnnexe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 688);
            this.Controls.Add(this.splitContainerControl);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmAnnexe";
            this.Ribbon = this.ribbon;
            this.Text = "DecEmp";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcmPanel1)).EndInit();
            this.lcmPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcLigneZoneValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLigneZoneValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMainPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGridLigne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcmPanel2)).EndInit();
            this.lcmPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcLignesAnnexes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLignesAnnexes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMainPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGridLigneZoneValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpAccueil;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbpgAccueil;
        private DevExpress.XtraBars.BarButtonItem btnExporter;
        private DevExpress.XtraBars.BarButtonItem btnExporterExcel;
        private DevExpress.XtraBars.BarButtonItem btnImprimer;
        private DevExpress.XtraBars.BarButtonItem btnImprimerList;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraLayout.LayoutControl lcmPanel2;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMainPanel2;
        private DevExpress.XtraLayout.LayoutControl lcmPanel1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMainPanel1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgGridLigneZoneValue;
        private DevExpress.XtraLayout.LayoutControlGroup lcgGridLigne;
        private DevExpress.XtraBars.BarButtonItem btCustomReport;
        private DevExpress.XtraGrid.GridControl gcLigneZoneValue;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLigneZoneValue;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gcLignesAnnexes;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLignesAnnexes;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private SimpleButton btnDelete;
        private SimpleButton btnSave;
        private SimpleButton btnImporter;
        private SimpleButton btnAjouter;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}