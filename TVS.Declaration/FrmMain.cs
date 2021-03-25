using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using TVS.Core;
using TVS.Declaration.Settings;
using TVS.Config;
using TVS.Config.Modules;
using System.ComponentModel.Composition;
using DevExpress.XtraSplashScreen;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Ribbon;
using Ninject;

namespace TVS.Declaration
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private List<Lazy<IModule, IMainPageRibonMetadata>> _modules;

        [ImportMany("MainPageRibon", typeof(IModule), AllowRecomposition = true)] private
            Lazy<IModule, IMainPageRibonMetadata>[] _mainPage = null;

        private DeclarationService _service;
        private FrmAcceuil _frmAcceuil;

        private FrmMain()
        {
            InitializeComponent();
            Load += MainForm_Load;
            btnFermer.ItemClick += QuitterEvent;
            btnMatriculeFiscale.ItemClick += VerifyMatricule;
            btnApropos.ItemClick += Apropos;
            Text = "Gestion des déclarations";
            Icon = Properties.Resources.log22;

            documentManager1.View.BeginFloating += BeginFloating;
            FormClosing += Main_FormClosing;
            rbMain.SelectedPageChanged += PageChanged;
        }
        public void PageChanged(object sender, EventArgs e)
        {
            var page =rbMain.SelectedPage;
            if (page == null) return;
            if (page.Tag == null) return;
            var item = page.Tag as Lazy<ICommand, IMainItemRibbonMetadata>;
            if (item == null) return;
            item.Value.Execute(Program.Context);
           // item.
        }

        public void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmAcceuil.FormClosing -= _frmAcceuil.FrmAcceuil_FormClosing;
            _frmAcceuil.Close();
            Application.Exit();
        }

        void BeginFloating(object sender, DocumentCancelEventArgs e)
        {
            if (e.Document != null && e.Document.Caption == _frmAcceuil.Text)
                e.Cancel = true;
        }

        public FrmMain(AppConfiguration appConfig)
            : this()
        {
            if (appConfig == null) throw new ArgumentNullException("appConfig");

            Program.RebindGroupConnection(appConfig.Get());
            _service = Program.GetService();

            //Update dataBase
            Program.MigrateDataBase();
            _service.InitService();
     
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                _frmAcceuil = new FrmAcceuil();
                _frmAcceuil.MdiParent = this;
                _frmAcceuil.Show();
                SplashScreenManager.ShowForm(typeof(WaitFormDec));
                AllowFormGlass = DefaultBoolean.False;
                rbMain.MdiMergeStyle = RibbonMdiMergeStyle.Always;

                var container = Program.Context.Container;
                container.ComposeParts(this);
                InitMainMenu();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SplashScreenManager.CloseForm();
            }
        }

        private void QuitterEvent(object sender, ItemClickEventArgs e)
        {
            try
            {
                _frmAcceuil.FormClosing -= _frmAcceuil.FrmAcceuil_FormClosing;
                Application.Exit();
            }
            catch (Exception)
            {
                Close();
            }
        
        }

        private void VerifyMatricule(object sender, ItemClickEventArgs e)
        {
            var frm = new FrmMatriculeFiscale();
            frm.ShowDialog();
        }

        private void Apropos(object sender, ItemClickEventArgs e)
        {
            var frm = new FrmApropos();
            frm.ShowDialog();
        }

        public void OpenGroup(RibbonPageGroup group)
        {
            if (group.Tag == null) return;
            var item = group.Tag as Lazy<ICommand, IMainItemRibbonMetadata>;
            if (item == null) return;
            item.Value.Execute(Program.Context);
            // item.
        }
        public void btnParametre_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_service == null) return;
            // Fermer toute les fenetres active.
            MdiChildren
                .ToList()
                .ForEach(x => x.Close());

            var parmetreList = new List<IOptionUserControl>();
            // parcourit les modules
            foreach (var page in _modules)
            {
                var module = page.Value;

                switch (module.Type)
                {
                    case TypeModule.BcSuspension:
                        if (!Program.IsDecBc) continue;
                        break;
                    case TypeModule.FcSuspension:
                        if (!Program.IsDecFc) continue;
                        break;
                    case TypeModule.Cnss:
                        if (!Program.IsCnss) continue;
                        break;
                    case TypeModule.VirementBancaire:
                        if (!Program.IsVirement) continue;
                        break;
                    case TypeModule.DecEmp:
                        if (!Program.IsEmp) continue;
                        break;
                    case TypeModule.Liasse:
                        if (!Program.IsLiasse) continue;
                        break;
                    default:
                        continue;
                        break;
                }

                // charger les parametres du module
                var parameters = module.GetParameters().ToList();

                foreach (var i in parameters)
                {
                    parmetreList.Add(i.Value.GetParam());
                }
            }
            var form = Program.Kernel.Get<FrmParametrage>();
            form.SetParameter(parmetreList);
            form.ShowDialog();
        }

        private void InitMainMenu()
        {
            // load modules
            _modules = _mainPage.OrderBy(c => c.Metadata.LevelNo).ToList();
            foreach (var page in _modules)
            {
                var module = page.Value;
                switch (module.Type)
                {
                    case TypeModule.BcSuspension:
                        if (!Program.IsDecBc) continue;
                        break;
                    case TypeModule.FcSuspension:
                        if (!Program.IsDecFc) continue;
                        break;
                    case TypeModule.Cnss:
                        if (!Program.IsCnss) continue;
                        break;
                    case TypeModule.VirementBancaire:
                        if (!Program.IsVirement) continue;
                        break;
                    case TypeModule.DecEmp:
                        if (!Program.IsEmp) continue;
                        break;
                    case TypeModule.Liasse:
                        if (!Program.IsLiasse) continue;
                        break;
                    default:
                        continue;
                        break;
                }
                module.Init(Program.Context);
                // load commande modules
                var commands = module.GetCommands().OrderBy(x => x.Metadata.LevelNo).ToList();

                //var pnvPage = new RibbonPage
                //{
                //    Name = page.Metadata.PageName,
                //    Text = page.Metadata.Caption,
                //    Tag = page.Metadata.AllowTabbedViewHeader
                //};
         var pnvPage = rbMain.Pages.GetPageByText("Fichier");

                // add page to ribbon
              //  rbMain.Pages.Add(pnvPage);
                var rpgroup = new RibbonPageGroup
                {
                    Text = page.Metadata.Caption,
                    AllowTextClipping = false,
                    ShowCaptionButton = true,   
                    Visible =false                
                };
                pnvPage.Groups.Add(rpgroup);


                if(commands.Count == 1)
                {
                    rpgroup.Tag = commands[0];
                }

                foreach (var i in commands)
                {

                    // gerer les simples bouttons du ribbon
                    if (i.Metadata.TypeButton == TypeButton.SimpleButton)
                    {
                        var item = new BarButtonItem
                        {
                            Name = i.Metadata.ItemName,
                            Caption = i.Metadata.Caption,
                            LargeGlyph = i.Value.GetLargeImage,
                            Glyph = i.Value.GetSmallImage,
                        };
                        rbMain.Items.Add(item);
                        rpgroup.ItemLinks.Add(item);

                        item.ItemClick += (o, e) => {
                       
                            i.Value.Execute(Program.Context);

                        };
                        
                    }
                    // gerer les check boutton du ribbon
                    if (i.Metadata.TypeButton == TypeButton.CheckButton)
                    {
                        var item = new BarCheckItem()
                        {
                            Name = i.Metadata.ItemName,
                            Caption = i.Metadata.Caption,
                            LargeGlyph = i.Value.GetLargeImage,
                            Glyph = i.Value.GetSmallImage,
                        };
                        rbMain.Items.Add(item);
                        rpgroup.ItemLinks.Add(item);

                        item.ItemClick += (o, e) =>
                        {
                            var groupeIndex = item.GroupIndex;
                            var groupPage = pnvPage.Groups[groupeIndex];
                     
                            // reinitialiser l'etat des bouttons checked
                            foreach (var itemLink in groupPage.ItemLinks)
                            {
                                var checkLink = itemLink as BarCheckItemLink;
                                if (checkLink == null)
                                    continue;
                                var checkItem = checkLink.Item as BarCheckItem;
                                if (checkItem == null) continue;
                                if (checkLink.Caption == item.Caption)
                                    continue;
                                checkItem.Checked = false;
                            }
                
                            try
                            {
                                i.Value.Execute(Program.Context);
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message );
                            }
                        };
                    }
                }
            }
        }

        public void btnEncourExercice_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_service == null) return;
            // Fermer toute les fenetres active.
            MdiChildren
                .ToList()
                .ForEach(x => x.Close());
            var form = Program.Kernel.Get<FrmCurrentExercice>();
            form.ShowDialog();
            Program.Context.Exercice = _service.Exercice;
            Program.Context.Societe = _service.Societe;
        }

        public void SelectedPage(TypeModule type)
        {
            foreach(var frm in this.MdiChildren)
            {
                if (frm.Text == "Acceuil") continue;
                frm.Close();
            }
            var pageFichier = rbMain.Pages.GetPageByText("Fichier");
        
            foreach (var p in rbMain.Pages)
            {
                var pageCnss = pageFichier.Groups.GetGroupByText("CNSS");
                if(pageCnss != null)
                pageCnss.Visible = false;
                var pageBc = pageFichier.Groups.GetGroupByText("Achat en suspension");
                if(pageBc != null)
                    pageBc.Visible = false;
                var pageFc = pageFichier.Groups.GetGroupByText("Vente en suspension");
                if(pageFc != null)
                    pageFc.Visible = false;
                var pageEmp = pageFichier.Groups.GetGroupByText("Declaration employeurs");
                if(pageEmp != null)
                    pageEmp.Visible = false;
                var pageVir = pageFichier.Groups.GetGroupByText("Virement");
                if(pageVir != null)
                    pageVir.Visible = false;
                var pageLiasse = pageFichier.Groups.GetGroupByText("Liasse");
                if (pageLiasse != null)
                    pageLiasse.Visible = false;
            }
            switch (type)
            {
                case TypeModule.Cnss:
                    var pageCnss = pageFichier.Groups.GetGroupByText("CNSS");
                    if(pageCnss == null)return;
                   // pageCnss.Visible = true;
                    OpenGroup(pageCnss);
                    //rbMain.SelectedPage = pageCnss;
                    break;
            
                case TypeModule.BcSuspension:
                    var pageBc = pageFichier.Groups.GetGroupByText("Achat en suspension");
                    if(pageBc == null)return;
                   // pageBc.Visible = true;
                    OpenGroup(pageBc);
                    // rbMain.SelectedPage = pageBc;
                    break;
            
                case TypeModule.FcSuspension:
                    var pageFc = pageFichier.Groups.GetGroupByText("Vente en suspension");
                    if(pageFc == null)return;
                   // pageFc.Visible = true;
                    OpenGroup(pageFc);
                    //  rbMain.SelectedPage = pageFc;
                    break;
            
                case TypeModule.DecEmp:
                    var pageEmp = pageFichier.Groups.GetGroupByText("Declaration employeurs");
                    if(pageEmp == null)return;
                    pageEmp.Visible = true;
                    OpenGroup(pageEmp);
                    //rbMain.SelectedPage = pageEmp;
                    break;
                case TypeModule.VirementBancaire:
                    var pageVir = pageFichier.Groups.GetGroupByText("Virement");
                    if (pageVir == null) return;
                 //   pageVir.Visible = true;
                    OpenGroup(pageVir);
                    //rbMain.SelectedPage = pageVir;
                    break;
                
                case TypeModule.Liasse:
                    var pageLiass = pageFichier.Groups.GetGroupByText("Liasse");
                    if (pageLiass == null) return;
                    pageLiass.Visible = true;
                    OpenGroup(pageLiass);
                    //rbMain.SelectedPage = pageVir;
                    break;
                //Covis
                case TypeModule.Covis:
                    var pageCovis = pageFichier.Groups.GetGroupByText("CNSS");
                    if (pageCovis == null) return;
                    pageCovis.Visible = true;
                    OpenGroup(pageCovis);
                    //rbMain.SelectedPage = pageVir;
                    break;
                default: break;
            }
            
        }

        private void btnMatriculeFiscale_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void rbMain_Click(object sender, EventArgs e)
        {

        }
    }
}