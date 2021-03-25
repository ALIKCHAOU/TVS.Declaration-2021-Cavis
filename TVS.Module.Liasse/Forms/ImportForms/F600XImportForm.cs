using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using DevExpress.DataAccess.UI.Excel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using TVS.Core.Helpers;
using TVS.Core.Models.Liass;
using TVS.Module.Liasse.Model;

namespace TVS.Module.Liasse.Forms.ImportForms
{
    public partial class F600XImportForm : DevExpress.XtraEditors.XtraForm
    {
        public  IF600X CurrentF600X { get; private set; }
        private readonly string _fileName ;
        public F600XImportForm(Model.IF600X currentF600X)
        {
            InitializeComponent();
            CurrentF600X = currentF600X;
            _fileName= Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.ProductName, $"ModelImport_{currentF600X.GetType().Name}.xml");
            this.f6001BindingSource.DataSource = CurrentF600X;
            if(File.Exists(_fileName))
                try
                {
                    this.excelDataSource1.LoadFromXml(XElement.Load(_fileName));
                }
                catch
                {
                    // ignored
                }

            layoutControlGroup3.Visibility = LayoutVisibility.Never;
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                var col1 = "Code Rubrique (Net)";
                var col2 = "Code Rubrique (N-1)";

                var col3 = "Net";
                var col4 = "Net N-1";
                if (excelDataSource1.EditDataSource())
                {
                    buttonEdit1.EditValue = excelDataSource1.FileName;
                    excelDataSource1.Fill();
                    var xml = this.excelDataSource1.SaveToXml();
                    xml.Save(this._fileName);
                    //
                    this.CodeRubBrutcomboBoxEdit.Properties.Items.Clear();
                    this.CodeRubBrutcomboBoxEdit.Properties.Items.AddRange(excelDataSource1.Schema
                        .Where(x => x.Type == typeof(string) && x.Selected).Select(x => x.Name).ToList());
                    this.CodeRubBrutcomboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x => x.Type == typeof(string) && x.Selected).Select(x => x.Name)
                        .FirstOrDefault(x => x.Trim() == col1);
                    //
                    this.CodeRubProvcomboBoxEdit.Properties.Items.Clear();
                    this.CodeRubProvcomboBoxEdit.Properties.Items.AddRange(excelDataSource1.Schema
                        .Where(x => x.Type == typeof(string) && x.Selected).Select(x => x.Name).ToList());
                    this.CodeRubProvcomboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x => x.Type == typeof(string) && x.Selected).Select(x => x.Name)
                        .FirstOrDefault(x => x.Trim() == col2);
                    //
                    this.CodeRubN_1comboBoxEdit.Properties.Items.Clear();
                    this.CodeRubN_1comboBoxEdit.Properties.Items.AddRange(excelDataSource1.Schema
                        .Where(x => x.Type == typeof(string) && x.Selected).Select(x => x.Name).ToList());
                    this.CodeRubN_1comboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x => x.Type == typeof(string) && x.Selected).Select(x => x.Name)
                        .FirstOrDefault(x => x.Trim() == col3);
                    //
                    this.ValBrutcomboBoxEdit.Properties.Items.Clear();
                    this.ValBrutcomboBoxEdit.Properties.Items.AddRange(excelDataSource1.Schema
                        .Where(x => Core.Helpers.Helper.IsNumericType(x.Type) && x.Selected).Select(x => x.Name)
                        .ToList());
                    this.ValBrutcomboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x => Core.Helpers.Helper.IsNumericType(x.Type) && x.Selected).Select(x => x.Name)
                        .FirstOrDefault(x => x.Trim() == col4);
                }

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var f600X= this.CurrentF600X ;

            var dt = this.excelDataSource1.ToDataTable();
            int ligne = 1;
            foreach (DataRow dataRow in dt.Rows)
            {
                var lBrut = f600X.Lignes.FirstOrDefault(x => x.CodeB == dataRow[CodeRubBrutcomboBoxEdit.Text].ToString());
                if (lBrut != null&&!lBrut.Calculable)
                {
                    try
                    {
                        lBrut.ValeurB = Convert.ToDecimal(dataRow[ValBrutcomboBoxEdit.Text]);
                    }
                    catch (Exception ex)
                    {
                    }
                    
                }

                var lprov = f600X.Lignes.FirstOrDefault(x => x.CodeB == dataRow[CodeRubProvcomboBoxEdit.Text].ToString());
                if (lprov != null && !lprov.Calculable)
                {
                    try
                    {
                        lprov.ValeurB = dataRow[ValProvcomboBoxEdit.Text];
                    }
                    catch (Exception ex)
                    {

                        
                    }
                }
          
                var ln_1= f600X.Lignes.FirstOrDefault(x => x.CodeB == dataRow[CodeRubN_1comboBoxEdit.Text].ToString());
                if (ln_1 != null && !ln_1.Calculable)
                {
                    try
                    {
                        ln_1.ValeurB = dataRow[ValN_1comboBoxEdit.Text];
                    }
                    catch (Exception ex)
                    {


                    }
                }

            }

            this.f6001BindingSource.DataSource = f600X;
                layoutControlGroup3.Visibility = LayoutVisibility.Always;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        { 
            
            this.f6001BindingSource.EndEdit();
            this.DialogResult = DialogResult.OK;
        }
    }
}