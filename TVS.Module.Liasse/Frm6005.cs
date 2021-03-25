using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TVS.Module.Liasse
{
    public partial class Frm6005 : Form
    {
        private LiasseController _controller;
        public Frm6005(LiasseController controller)
        {
            InitializeComponent();
            _controller = controller;
            foreach (var item in dataLayoutControl1.Items)
            {
                if (item is LayoutControlItem && (item as LayoutControlItem).Control is TextEdit)
                {
                    //your code

                    var txt = ((item as LayoutControlItem).Control as TextEdit);
                    switch (txt.Name)
                    {
                        case "ActeDeDepotTextEdit":
                            continue;
                        case "NatureDepotTextEdit":
                            continue;
                        case "F60050000CodeformejuridiqueTextEdit":
                            continue;
                        case "F60050000CategorieTextEdit":
                            continue;
                        case "F60050001TextEdit":
                            continue;
                        case "F60051001TextEdit":
                            continue;
                        case "F60050055TextEdit":
                            continue;
                        case "F60051055TextEdit":
                            continue;
                    }
                    txt.EnterMoveNextControl = true;
                    txt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    txt.Properties.DisplayFormat.FormatString = "N3";
                    txt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    txt.Properties.EditFormat.FormatString = "N3";
                    txt.Properties.Mask.EditMask = "N3";
                    txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    if (txt.Properties.ReadOnly) txt.Properties.AllowFocused = false;
                    txt.Validated += Txt_Validated;
                }
                if (item is LayoutControlGroup)
                {
                    var lcg = item as LayoutControlGroup;
                    if (lcg.TextVisible && lcg.GroupBordersVisible)
                    {
                        lcg.ExpandButtonVisible = true;
                        lcg.Expanded = false;
                    }
                }
            }
            btEnregistrer.Click += BtEnregistrer_Click;
            btExporter.Click += BtExporter_Click;
            this.f6005BindingSource.DataSource = controller.CurrentF6005();



        }

        private void BtExporter_Click(object sender, EventArgs e)
        {
            BtEnregistrer_Click(null, null);
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK) return;
            var fileName = saveFileDialog1.FileName;
            var F6005 = this.f6005BindingSource.Current as Core.Models.Liass.F6005;
            _controller.Export(F6005, fileName);

        }

        private void BtEnregistrer_Click(object sender, EventArgs e)
        {
            this.f6005BindingSource.EndEdit();
            var F6005 = this.f6005BindingSource.Current as Core.Models.Liass.F6005;
            _controller.Save(F6005);
            this.f6005BindingSource.DataSource = _controller.CurrentF6005();
            this.f6005BindingSource.ResetCurrentItem();
        }

        private void Txt_Validated(object sender, EventArgs e)
        {
            this.f6005BindingSource.ResetCurrentItem();
        }
    }
}
