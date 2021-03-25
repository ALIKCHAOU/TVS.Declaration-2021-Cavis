using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TVS.Config;
using TVS.Declaration.Societes;

namespace TVS.Declaration
{
    public partial class FrmParametrage : XtraForm
    {
        private readonly IUserControlFactory _ucFactory;
        private IList<IOptionUserControl> _options;

        private FrmParametrage()
        {
            InitializeComponent();

          //  lbcOptions.SelectedIndexChanged += ListBoxSetlectedIndexChanged;
            KeyDown += FormParametre_KeyDown;
        }

        public FrmParametrage(IUserControlFactory ucFactory)
            : this()
        {
            _ucFactory = ucFactory;
        }

        //private void SetCurrentOption(IOptionUserControl option)
        //{
        //    var ctrl = option as Control;
        //    if (ctrl == null) return;

        //    // set the the LayoutItemControl Owner (LayoutGroupItem)
        //    LayoutControlGroup itemOwner = lcgCurrentOption;
        //    itemOwner.BeginUpdate();
        //    try
        //    {
        //        // remove the current LayoutItemControl
        //        if (lcgCurrentOption.Items.Count > 0)
        //        {
        //            var item = itemOwner.Items[0] as LayoutControlItem;
        //            if (item != null)
        //            {
        //                Control control = item.Control;
        //                if (control != null)
        //                {
        //                    control.Parent = null;
        //                }
        //                item.Dispose();
        //            }
        //        }

        //        // add the new LayoutItemControl
        //        itemOwner.AddItem(string.Empty, ctrl).TextVisible = false;
        //    }
        //    finally
        //    {
        //        itemOwner.EndUpdate();
        //    }
        //}

        //private void ListBoxSetlectedIndexChanged(object sender, EventArgs e)
        //{
        //    // verifier le controle selectionner
        //    var option = lbcOptions.SelectedItem as IOptionUserControl;
        //    if (option == null) return;
        //    // refresh source for control
        //    option.RefreshSource();
        //    // basculement du control en cours
        //    SetCurrentOption(option);
        //}

        private void FormParametre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        //internal void SetParameter(List<IOptionUserControl> list)
        //{
        //    // creation des controles du groupe
        //    _options = new List<IOptionUserControl>
        //    {
        //        _ucFactory.Create<UcSociete>(),
        //        _ucFactory.Create<UcExercice>(),
        //    };
        //    if (Program.GetService().User.IsAdmin)
        //    {
        //        _options.Add(_ucFactory.Create<UcUser>());
        //    }
        //    foreach (var optionUserControl in list)
        //    {
        //        _options.Add(optionUserControl);
        //    }
        //    // initialiser la list box
        //    lbcOptions.DisplayMember = "Titre";
        //    lbcOptions.ValueMember = "No";
        //    lbcOptions.DataSource = _options;
        //    lbcOptions.ItemHeight = 20;
        //    ListBoxSetlectedIndexChanged(null, null);
        //}
        internal void SetParameter(List<IOptionUserControl> list)
        {
            // creation des controles du groupe
            _options = new List<IOptionUserControl>
            {
                _ucFactory.Create<UcSociete>(),
                _ucFactory.Create<UcExercice>(),
            };
            if (Program.GetService().User.IsAdmin)
            {
                _options.Add(_ucFactory.Create<UcUser>());
            }
            foreach (var optionUserControl in list)
            {
                _options.Add(optionUserControl);
            }
            InitOptionForm();
        }
        private void InitOptionForm()
        {
            foreach (var cntrl in _options)
            {
                var tab = new DevExpress.XtraTab.XtraTabPage();
                tab.Name = cntrl.Titre;
                tab.Size = new System.Drawing.Size(468, 461);
                tab.Text = cntrl.Titre;

                xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
          tab });
                var cnt = cntrl as Control;
                cnt.Dock = System.Windows.Forms.DockStyle.Fill;
                tab.Controls.Add(cnt);
            }

            //// initialiser la list box
            //lbcOptions.DisplayMember = "Titre";
            //lbcOptions.ValueMember = "No";
            //lbcOptions.DataSource = _optionsToLoad;
            //lbcOptions.ItemHeight = 20;
            //ListBoxSetlectedIndexChanged(null, null);
        }
    }
}