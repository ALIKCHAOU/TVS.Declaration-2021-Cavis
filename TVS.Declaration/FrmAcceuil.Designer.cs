namespace TVS.Declaration
{
    partial class FrmAcceuil
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
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement8 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement9 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement10 = new DevExpress.XtraEditors.TileItemElement();
            this.titleControl = new DevExpress.XtraEditors.TileControl();
            this.tcFichier = new DevExpress.XtraEditors.TileGroup();
            this.tiSetting = new DevExpress.XtraEditors.TileItem();
            this.tiExerciceEncours = new DevExpress.XtraEditors.TileItem();
            this.tiApropos = new DevExpress.XtraEditors.TileItem();
            this.tgModule = new DevExpress.XtraEditors.TileGroup();
            this.tiDecEmp = new DevExpress.XtraEditors.TileItem();
            this.tiDeclarationCnss = new DevExpress.XtraEditors.TileItem();
            this.tiDeclarationBC = new DevExpress.XtraEditors.TileItem();
            this.tiFcsuspension = new DevExpress.XtraEditors.TileItem();
            this.tiVirementBancaire = new DevExpress.XtraEditors.TileItem();
            this.tiLiasse = new DevExpress.XtraEditors.TileItem();
            this.tiCovis = new DevExpress.XtraEditors.TileItem();
            this.SuspendLayout();
            // 
            // titleControl
            // 
            this.titleControl.AppearanceGroupText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleControl.AppearanceGroupText.Options.UseFont = true;
            this.titleControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.titleControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.titleControl.Groups.Add(this.tcFichier);
            this.titleControl.Groups.Add(this.tgModule);
            this.titleControl.IndentBetweenGroups = 20;
            this.titleControl.ItemContentAnimation = DevExpress.XtraEditors.TileItemContentAnimationType.ScrollDown;
            this.titleControl.Location = new System.Drawing.Point(3, 3);
            this.titleControl.MaxId = 13;
            this.titleControl.Name = "titleControl";
            this.titleControl.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.titleControl.ShowGroupText = true;
            this.titleControl.Size = new System.Drawing.Size(726, 503);
            this.titleControl.TabIndex = 7;
            this.titleControl.Text = "tileControl1";
            // 
            // tcFichier
            // 
            this.tcFichier.Items.Add(this.tiSetting);
            this.tcFichier.Items.Add(this.tiExerciceEncours);
            this.tcFichier.Items.Add(this.tiApropos);
            this.tcFichier.Name = "tcFichier";
            this.tcFichier.Text = "Démarrage";
            // 
            // tiSetting
            // 
            tileItemElement1.Image = global::TVS.Declaration.Properties.Resources.parametres;
            tileItemElement1.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement1.Text = "Setting";
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tiSetting.Elements.Add(tileItemElement1);
            this.tiSetting.Id = 1;
            this.tiSetting.Name = "tiSetting";
            // 
            // tiExerciceEncours
            // 
            tileItemElement2.Image = global::TVS.Declaration.Properties.Resources.calendrier;
            tileItemElement2.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement2.Text = "Exercice en cours";
            tileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tiExerciceEncours.Elements.Add(tileItemElement2);
            this.tiExerciceEncours.Id = 6;
            this.tiExerciceEncours.Name = "tiExerciceEncours";
            // 
            // tiApropos
            // 
            this.tiApropos.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tiApropos.AppearanceItem.Normal.Options.UseBackColor = true;
            tileItemElement3.Image = global::TVS.Declaration.Properties.Resources.informations;
            tileItemElement3.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement3.Text = "A propos";
            tileItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tiApropos.Elements.Add(tileItemElement3);
            this.tiApropos.Id = 7;
            this.tiApropos.Name = "tiApropos";
            // 
            // tgModule
            // 
            this.tgModule.Items.Add(this.tiDecEmp);
            this.tgModule.Items.Add(this.tiDeclarationCnss);
            this.tgModule.Items.Add(this.tiDeclarationBC);
            this.tgModule.Items.Add(this.tiFcsuspension);
            this.tgModule.Items.Add(this.tiVirementBancaire);
            this.tgModule.Items.Add(this.tiLiasse);
            this.tgModule.Items.Add(this.tiCovis);
            this.tgModule.Name = "tgModule";
            this.tgModule.Text = "Modules";
            // 
            // tiDecEmp
            // 
            tileItemElement4.Image = global::TVS.Declaration.Properties.Resources.famille_contact;
            tileItemElement4.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement4.Text = "Déclaration employeur";
            tileItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tiDecEmp.Elements.Add(tileItemElement4);
            this.tiDecEmp.Id = 0;
            this.tiDecEmp.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tiDecEmp.Name = "tiDecEmp";
            // 
            // tiDeclarationCnss
            // 
            tileItemElement5.Image = global::TVS.Declaration.Properties.Resources.partenaires;
            tileItemElement5.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement5.Text = "Déclaration CNSS";
            tileItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tiDeclarationCnss.Elements.Add(tileItemElement5);
            this.tiDeclarationCnss.Id = 3;
            this.tiDeclarationCnss.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tiDeclarationCnss.Name = "tiDeclarationCnss";
            // 
            // tiDeclarationBC
            // 
            tileItemElement6.Image = global::TVS.Declaration.Properties.Resources.famille_immobilisations;
            tileItemElement6.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement6.Text = "Déclaration achat en suspension";
            tileItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tiDeclarationBC.Elements.Add(tileItemElement6);
            this.tiDeclarationBC.Id = 4;
            this.tiDeclarationBC.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tiDeclarationBC.Name = "tiDeclarationBC";
            // 
            // tiFcsuspension
            // 
            tileItemElement7.Image = global::TVS.Declaration.Properties.Resources.famille_articles;
            tileItemElement7.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement7.Text = "Déclaration vente en suspension";
            tileItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tiFcsuspension.Elements.Add(tileItemElement7);
            this.tiFcsuspension.Id = 5;
            this.tiFcsuspension.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tiFcsuspension.Name = "tiFcsuspension";
            // 
            // tiVirementBancaire
            // 
            tileItemElement8.Image = global::TVS.Declaration.Properties.Resources.banque;
            tileItemElement8.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement8.Text = "Virement bancaire";
            tileItemElement8.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tiVirementBancaire.Elements.Add(tileItemElement8);
            this.tiVirementBancaire.Id = 8;
            this.tiVirementBancaire.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tiVirementBancaire.Name = "tiVirementBancaire";
            this.tiVirementBancaire.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiVirementBancaire_ItemClick_1);
            // 
            // tiLiasse
            // 
            tileItemElement9.Image = global::TVS.Declaration.Properties.Resources.icons_certificationV48;
            tileItemElement9.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement9.Text = "Liasse Fiscal";
            tileItemElement9.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tiLiasse.Elements.Add(tileItemElement9);
            this.tiLiasse.Id = 11;
            this.tiLiasse.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tiLiasse.Name = "tiLiasse";
            // 
            // tiCovis
            // 
            tileItemElement10.Image = global::TVS.Declaration.Properties.Resources.partenaires;
            tileItemElement10.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement10.Text = "Covis";
            tileItemElement10.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tiCovis.Elements.Add(tileItemElement10);
            this.tiCovis.Id = 12;
            this.tiCovis.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tiCovis.Name = "tiCovis";
           
            // 
            // FrmAcceuil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 518);
            this.Controls.Add(this.titleControl);
            this.Name = "FrmAcceuil";
            this.Text = "Accueil";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TileControl titleControl;
        private DevExpress.XtraEditors.TileGroup tcFichier;
        private DevExpress.XtraEditors.TileItem tiSetting;
        private DevExpress.XtraEditors.TileItem tiExerciceEncours;
        private DevExpress.XtraEditors.TileItem tiApropos;
        private DevExpress.XtraEditors.TileGroup tgModule;
        private DevExpress.XtraEditors.TileItem tiDecEmp;
        private DevExpress.XtraEditors.TileItem tiDeclarationCnss;
        private DevExpress.XtraEditors.TileItem tiDeclarationBC;
        private DevExpress.XtraEditors.TileItem tiFcsuspension;
        private DevExpress.XtraEditors.TileItem tiVirementBancaire;
        private DevExpress.XtraEditors.TileItem tiLiasse;
        private DevExpress.XtraEditors.TileItem tiCovis;
    }
}