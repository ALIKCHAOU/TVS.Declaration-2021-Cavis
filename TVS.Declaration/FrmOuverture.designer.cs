namespace TVS.Declaration
{
    partial class FrmOuverture
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
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.lciSociete = new DevExpress.XtraLayout.LayoutControlItem();
            this.cbSociete = new DevExpress.XtraEditors.GridLookUpEdit();
            this.viewCaisse = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.btnAnnuler = new DevExpress.XtraEditors.SimpleButton();
            this.lbl = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtLogin = new DevExpress.XtraEditors.TextEdit();
            this.lciVide = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgAuthentification = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciLogin = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgButtons = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciBtnAnnuler = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBtnLogin = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lciSociete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSociete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewCaisse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgAuthentification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnAnnuler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // lciSociete
            // 
            this.lciSociete.Control = this.cbSociete;
            this.lciSociete.CustomizationFormText = "Société";
            this.lciSociete.Location = new System.Drawing.Point(0, 130);
            this.lciSociete.Name = "lciSociete";
            this.lciSociete.Padding = new DevExpress.XtraLayout.Utils.Padding(80, 6, 6, 6);
            this.lciSociete.Size = new System.Drawing.Size(419, 32);
            this.lciSociete.Text = "Société";
            this.lciSociete.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciSociete.TextSize = new System.Drawing.Size(75, 20);
            this.lciSociete.TextToControlDistance = 0;
            // 
            // cbSociete
            // 
            this.cbSociete.Location = new System.Drawing.Point(158, 139);
            this.cbSociete.Name = "cbSociete";
            this.cbSociete.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSociete.Properties.NullText = "";
            this.cbSociete.Properties.PopupFormSize = new System.Drawing.Size(0, 30);
            this.cbSociete.Properties.PopupSizeable = false;
            this.cbSociete.Properties.View = this.viewCaisse;
            this.cbSociete.Size = new System.Drawing.Size(258, 20);
            this.cbSociete.StyleController = this.lcMain;
            this.cbSociete.TabIndex = 6;
            // 
            // viewCaisse
            // 
            this.viewCaisse.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.viewCaisse.Name = "viewCaisse";
            this.viewCaisse.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.viewCaisse.OptionsView.ShowGroupPanel = false;
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.pictureEdit1);
            this.lcMain.Controls.Add(this.btnLogin);
            this.lcMain.Controls.Add(this.btnAnnuler);
            this.lcMain.Controls.Add(this.cbSociete);
            this.lcMain.Controls.Add(this.lbl);
            this.lcMain.Controls.Add(this.txtPassword);
            this.lcMain.Controls.Add(this.txtLogin);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciVide});
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(858, 195, 369, 456);
            this.lcMain.Root = this.lcgRoot;
            this.lcMain.Size = new System.Drawing.Size(425, 201);
            this.lcMain.TabIndex = 1;
            this.lcMain.Text = "layoutControl1";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = global::TVS.Declaration.Properties.Resources.amen_logo;
            this.pictureEdit1.Location = new System.Drawing.Point(5, 5);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(415, 62);
            this.pictureEdit1.StyleController = this.lcMain;
            this.pictureEdit1.TabIndex = 12;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(224, 173);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(96, 23);
            this.btnLogin.StyleController = this.lcMain;
            this.btnLogin.TabIndex = 11;
            this.btnLogin.Text = "&Ok";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(324, 173);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(96, 23);
            this.btnAnnuler.StyleController = this.lcMain;
            this.btnAnnuler.TabIndex = 10;
            this.btnAnnuler.Text = "&Annuler";
            // 
            // lbl
            // 
            this.lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbl.Appearance.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lbl.Appearance.Options.UseFont = true;
            this.lbl.Appearance.Options.UseForeColor = true;
            this.lbl.Location = new System.Drawing.Point(20, 19);
            this.lbl.Name = "lbl";
            this.lbl.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbl.Size = new System.Drawing.Size(142, 19);
            this.lbl.StyleController = this.lcMain;
            this.lbl.TabIndex = 9;
            this.lbl.Text = "Authentification";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(158, 107);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(258, 20);
            this.txtPassword.StyleController = this.lcMain;
            this.txtPassword.TabIndex = 5;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(158, 75);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(258, 20);
            this.txtLogin.StyleController = this.lcMain;
            this.txtLogin.TabIndex = 4;
            // 
            // lciVide
            // 
            this.lciVide.Control = this.lbl;
            this.lciVide.CustomizationFormText = "lciVide";
            this.lciVide.Location = new System.Drawing.Point(0, 17);
            this.lciVide.Name = "lciVide";
            this.lciVide.Padding = new DevExpress.XtraLayout.Utils.Padding(20, 2, 2, 10);
            this.lciVide.Size = new System.Drawing.Size(412, 31);
            this.lciVide.TextSize = new System.Drawing.Size(0, 0);
            this.lciVide.TextVisible = false;
            // 
            // lcgRoot
            // 
            this.lcgRoot.CustomizationFormText = "lcgRoot";
            this.lcgRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgRoot.GroupBordersVisible = false;
            this.lcgRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgAuthentification,
            this.lcgButtons});
            this.lcgRoot.Location = new System.Drawing.Point(0, 0);
            this.lcgRoot.Name = "Root";
            this.lcgRoot.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgRoot.Size = new System.Drawing.Size(425, 201);
            this.lcgRoot.TextVisible = false;
            // 
            // lcgAuthentification
            // 
            this.lcgAuthentification.AppearanceGroup.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lcgAuthentification.AppearanceGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lcgAuthentification.AppearanceGroup.Options.UseBackColor = true;
            this.lcgAuthentification.AppearanceGroup.Options.UseForeColor = true;
            this.lcgAuthentification.CustomizationFormText = "lcgAuthentification";
            this.lcgAuthentification.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciPassword,
            this.lciLogin,
            this.lciSociete,
            this.layoutControlItem1});
            this.lcgAuthentification.Location = new System.Drawing.Point(0, 0);
            this.lcgAuthentification.Name = "lcgAuthentification";
            this.lcgAuthentification.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgAuthentification.Size = new System.Drawing.Size(425, 168);
            this.lcgAuthentification.TextVisible = false;
            // 
            // lciPassword
            // 
            this.lciPassword.Control = this.txtPassword;
            this.lciPassword.CustomizationFormText = "Password";
            this.lciPassword.Location = new System.Drawing.Point(0, 98);
            this.lciPassword.Name = "lciPassword";
            this.lciPassword.Padding = new DevExpress.XtraLayout.Utils.Padding(80, 6, 6, 6);
            this.lciPassword.Size = new System.Drawing.Size(419, 32);
            this.lciPassword.Text = "Mot de passe";
            this.lciPassword.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciPassword.TextSize = new System.Drawing.Size(75, 20);
            this.lciPassword.TextToControlDistance = 0;
            // 
            // lciLogin
            // 
            this.lciLogin.Control = this.txtLogin;
            this.lciLogin.CustomizationFormText = "Login";
            this.lciLogin.Location = new System.Drawing.Point(0, 66);
            this.lciLogin.Name = "lciLogin";
            this.lciLogin.Padding = new DevExpress.XtraLayout.Utils.Padding(80, 6, 6, 6);
            this.lciLogin.Size = new System.Drawing.Size(419, 32);
            this.lciLogin.Text = "Login";
            this.lciLogin.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciLogin.TextSize = new System.Drawing.Size(75, 20);
            this.lciLogin.TextToControlDistance = 0;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pictureEdit1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(419, 66);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lcgButtons
            // 
            this.lcgButtons.CustomizationFormText = "lcgButtons";
            this.lcgButtons.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.lciBtnAnnuler,
            this.lciBtnLogin});
            this.lcgButtons.Location = new System.Drawing.Point(0, 168);
            this.lcgButtons.Name = "lcgButtons";
            this.lcgButtons.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgButtons.Size = new System.Drawing.Size(425, 33);
            this.lcgButtons.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(219, 27);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciBtnAnnuler
            // 
            this.lciBtnAnnuler.Control = this.btnAnnuler;
            this.lciBtnAnnuler.CustomizationFormText = "lciBtnAnnuler";
            this.lciBtnAnnuler.Location = new System.Drawing.Point(319, 0);
            this.lciBtnAnnuler.MaxSize = new System.Drawing.Size(100, 27);
            this.lciBtnAnnuler.MinSize = new System.Drawing.Size(100, 27);
            this.lciBtnAnnuler.Name = "lciBtnAnnuler";
            this.lciBtnAnnuler.Size = new System.Drawing.Size(100, 27);
            this.lciBtnAnnuler.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciBtnAnnuler.TextSize = new System.Drawing.Size(0, 0);
            this.lciBtnAnnuler.TextVisible = false;
            // 
            // lciBtnLogin
            // 
            this.lciBtnLogin.Control = this.btnLogin;
            this.lciBtnLogin.CustomizationFormText = "lciBtnLogin";
            this.lciBtnLogin.Location = new System.Drawing.Point(219, 0);
            this.lciBtnLogin.MaxSize = new System.Drawing.Size(100, 27);
            this.lciBtnLogin.MinSize = new System.Drawing.Size(100, 27);
            this.lciBtnLogin.Name = "lciBtnLogin";
            this.lciBtnLogin.Size = new System.Drawing.Size(100, 27);
            this.lciBtnLogin.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciBtnLogin.TextSize = new System.Drawing.Size(0, 0);
            this.lciBtnLogin.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtPassword;
            this.layoutControlItem5.CustomizationFormText = "Password";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 32);
            this.layoutControlItem5.Name = "liciPassword";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(80, 6, 6, 6);
            this.layoutControlItem5.Size = new System.Drawing.Size(428, 32);
            this.layoutControlItem5.Text = "Password    ";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(58, 13);
            // 
            // FrmOuverture
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(425, 201);
            this.Controls.Add(this.lcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmOuverture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acceuil";
            ((System.ComponentModel.ISupportInitialize)(this.lciSociete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSociete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewCaisse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgAuthentification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnAnnuler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBtnLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraLayout.LayoutControlItem lciSociete;
        private DevExpress.XtraEditors.GridLookUpEdit cbSociete;
        private DevExpress.XtraGrid.Views.Grid.GridView viewCaisse;
        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraEditors.LabelControl lbl;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtLogin;
        private DevExpress.XtraLayout.LayoutControlItem lciVide;
        private DevExpress.XtraLayout.LayoutControlGroup lcgRoot;
        private DevExpress.XtraLayout.LayoutControlGroup lcgAuthentification;
        private DevExpress.XtraLayout.LayoutControlItem lciPassword;
        private DevExpress.XtraLayout.LayoutControlItem lciLogin;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.SimpleButton btnAnnuler;
        private DevExpress.XtraLayout.LayoutControlGroup lcgButtons;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem lciBtnAnnuler;
        private DevExpress.XtraLayout.LayoutControlItem lciBtnLogin;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}