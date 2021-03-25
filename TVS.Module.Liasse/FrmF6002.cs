﻿using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TVS.Module.Liasse
{
    public partial class FrmF6002 : Form
    {
        private LiasseController _controller;
        public FrmF6002(LiasseController controller)
        {
            InitializeComponent();
            _controller = controller;
            foreach (var item in dataLayoutControl1.Items)
            {
                if (item is LayoutControlItem && (item as LayoutControlItem).Control is TextEdit)
                {
                    //your code

                    var txt = ((item as LayoutControlItem).Control as TextEdit);
                    if ("ActeDeDepotTextEdit" == txt.Name) continue;
                    if ("NatureDepotComboBoxEdit" == txt.Name) continue;
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
                    if (lcg.TextVisible&&lcg.GroupBordersVisible)
                    {
                        lcg.ExpandButtonVisible = true;
                        lcg.Expanded = false;
                    }
                }
            }
            btEnregistrer.Click += BtEnregistrer_Click;
            btExporter.Click += BtExporter_Click;
            this.f6002BindingSource.DataSource = controller.CurrentF6002();
            saveFileDialog1.FileName = controller.GetXmlFileName(this.f6002BindingSource.Current);


        }

        private void BtExporter_Click(object sender, EventArgs e)
        {
            BtEnregistrer_Click(null, null);
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK) return;
            var fileName = saveFileDialog1.FileName;
            var f6002 = this.f6002BindingSource.Current as Core.Models.Liass.F6002;
            _controller.Export(f6002, fileName);

        }

        private void BtEnregistrer_Click(object sender, EventArgs e)
        {
            this.f6002BindingSource.EndEdit();
            var f6002 = this.f6002BindingSource.Current as Core.Models.Liass.F6002;
            _controller.Save(f6002);
            this.f6002BindingSource.DataSource = _controller.CurrentF6002();
            this.f6002BindingSource.ResetCurrentItem();
        }

        private void Txt_Validated(object sender, EventArgs e)
        {
            this.f6002BindingSource.ResetCurrentItem();
        }
    }
}
