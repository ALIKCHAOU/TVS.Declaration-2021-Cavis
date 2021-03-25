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
using System.Xml.Linq;
using DevExpress.DataAccess.UI.Excel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using TVS.Core.Helpers;
using TVS.Core.Models.Liass;

namespace TVS.Module.Liasse.Forms.ImportForms
{
    public partial class F6001ImportForm : DevExpress.XtraEditors.XtraForm
    {
        public  Model.F6001 CurrentF6001 { get; private set; }
        private readonly string _fileName;
        public F6001ImportForm(Model.F6001 currentF6001)
        {
            InitializeComponent();
            CurrentF6001 = currentF6001;
            
            _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),Application.ProductName, $"ModelImport_{currentF6001.GetType().Name}.xml");
            this.f6001BindingSource.DataSource = CurrentF6001;
            if (File.Exists(_fileName))
                try
                {
                    this.excelDataSource1.LoadFromXml(XElement.Load(_fileName));
                    excelDataSource1.Fill();
                    var col1 = "Code Rubrique (Brut)";
                    var col2 = "Code Rubrique(Prov/Amort)";
                    //var col1 = "Code Rubrique (Net)";
                    var col3 = "Code Rubrique (Net N-1)";
                    //var col1 = "Libelle";
                    var col4 = "Brut";
                    var col5 = "Prov / Amort";
                    var col6 = "Net N-1";
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

                    //
                    this.ValProvcomboBoxEdit.Properties.Items.Clear();
                    this.ValProvcomboBoxEdit.Properties.Items.AddRange(excelDataSource1.Schema
                        .Where(x => Core.Helpers.Helper.IsNumericType(x.Type) && x.Selected).Select(x => x.Name)
                        .ToList());
                    this.ValProvcomboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x => Core.Helpers.Helper.IsNumericType(x.Type) && x.Selected).Select(x => x.Name)
                        .FirstOrDefault(x => x.Trim() == col5);

                    //
                    this.ValN_1comboBoxEdit.Properties.Items.Clear();
                    this.ValN_1comboBoxEdit.Properties.Items.AddRange(excelDataSource1.Schema
                        .Where(x => Core.Helpers.Helper.IsNumericType(x.Type) && x.Selected).Select(x => x.Name)
                        .ToList());
                    this.ValN_1comboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x => Core.Helpers.Helper.IsNumericType(x.Type) && x.Selected).Select(x => x.Name)
                        .FirstOrDefault(x => x.Trim() == col6);
                }
                catch
                {
                    // ignored
                }
            this.buttonEdit1.EditValue = excelDataSource1.FileName;
            layoutControlGroup3.Visibility = LayoutVisibility.Never;
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                var col1 = "Code Rubrique (Brut)";
                var col2 = "Code Rubrique(Prov/Amort)";
                //var col1 = "Code Rubrique (Net)";
                var col3 = "Code Rubrique (Net N-1)";
                //var col1 = "Libelle";
                var col4 = "Brut";
                var col5 = "Prov / Amort";
                var col6 = "Net N-1";
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

                    //
                    this.ValProvcomboBoxEdit.Properties.Items.Clear();
                    this.ValProvcomboBoxEdit.Properties.Items.AddRange(excelDataSource1.Schema
                        .Where(x => Core.Helpers.Helper.IsNumericType(x.Type) && x.Selected).Select(x => x.Name)
                        .ToList());
                    this.ValProvcomboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x => Core.Helpers.Helper.IsNumericType(x.Type) && x.Selected).Select(x => x.Name)
                        .FirstOrDefault(x => x.Trim() == col5);

                    //
                    this.ValN_1comboBoxEdit.Properties.Items.Clear();
                    this.ValN_1comboBoxEdit.Properties.Items.AddRange(excelDataSource1.Schema
                        .Where(x => Core.Helpers.Helper.IsNumericType(x.Type) && x.Selected).Select(x => x.Name)
                        .ToList());
                    this.ValN_1comboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x => Core.Helpers.Helper.IsNumericType(x.Type) && x.Selected).Select(x => x.Name)
                        .FirstOrDefault(x => x.Trim() == col6);
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var f6001= this.CurrentF6001;
            var dt = this.excelDataSource1.ToDataTable();
            int ligne = 1;
            foreach (DataRow dataRow in dt.Rows)
            {
                var lBrut = f6001.Lignes.FirstOrDefault(x => x.CodeB == dataRow[CodeRubBrutcomboBoxEdit.Text].ToString());
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

                var lprov = f6001.Lignes.FirstOrDefault(x => x.CodeB == dataRow[CodeRubProvcomboBoxEdit.Text].ToString());
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
          
                var ln_1= f6001.Lignes.FirstOrDefault(x => x.CodeB == dataRow[CodeRubN_1comboBoxEdit.Text].ToString());
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

            this.f6001BindingSource.DataSource = f6001;
            layoutControlGroup3.Visibility = LayoutVisibility.Always;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.excelDataSource1.SaveToXml().ToString();
            this.f6001BindingSource.EndEdit();
            this.DialogResult = DialogResult.OK;
        }
    }
}