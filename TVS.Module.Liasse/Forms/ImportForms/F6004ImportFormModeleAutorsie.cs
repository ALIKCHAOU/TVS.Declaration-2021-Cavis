using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Xml.Linq;
using DevExpress.XtraLayout.Utils;
using TVS.Core.Helpers;
using DevExpress.XtraEditors.Controls;
using DevExpress.DataAccess.UI.Excel;

namespace TVS.Module.Liasse.Forms.ImportForms
{
    public partial class F6004ImportFormModeleAutorsie : DevExpress.XtraEditors.XtraForm
    {
        public Model.F6004ModeleAutorsie CurrentF6004MA { get; private set; }
        private readonly string _fileName;
        public F6004ImportFormModeleAutorsie(Model.F6004ModeleAutorsie currentF6004MA)
        {
            InitializeComponent();
            CurrentF6004MA = currentF6004MA;

            _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.ProductName, $"ModelImport_{CurrentF6004MA.GetType().Name}.xml");
            this.f6004MABindingSource.DataSource = CurrentF6004MA;
            if (File.Exists(_fileName))
                try
                {
                    this.excelDataSource1.LoadFromXml(XElement.Load(_fileName));
                    excelDataSource1.Fill();
                    var col1 = "Code Rubrique (Net)";
                    var col2 = "Code Rubrique (N-1)";
                    //var col1 = "Code Rubrique (Net)";
                    var col3 = "Net";
                    //var col1 = "Libelle";
                   // var col4 = "Brut";
                   // var col5 = "Prov / Amort";
                    var col4 = "Net N-1";
                    //
                    this.CodeRubNetcomboBoxEdit.Properties.Items.Clear();
                    this.CodeRubNetcomboBoxEdit.Properties.Items.AddRange(excelDataSource1.Schema
                        .Where(x => x.Type == typeof(string) && x.Selected).Select(x => x.Name).ToList());
                    this.CodeRubNetcomboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x => x.Type == typeof(string) && x.Selected).Select(x => x.Name)
                        .FirstOrDefault(x => x.Trim() == col1);

                    //
                    this.CodeRubN_1comboBoxEdit.Properties.Items.Clear();
                    this.CodeRubN_1comboBoxEdit.Properties.Items.AddRange(excelDataSource1.Schema
                        .Where(x => x.Type == typeof(string) && x.Selected).Select(x => x.Name).ToList());
                    this.CodeRubN_1comboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x => x.Type == typeof(string) && x.Selected).Select(x => x.Name)
                        .FirstOrDefault(x => x.Trim() == col2);

                    //

this.ValNetcomboBoxEdit.Properties.Items.Clear();
                    this.ValNetcomboBoxEdit.Properties.Items.AddRange(excelDataSource1.Schema
                        .Where(x => Core.Helpers.Helper.IsNumericType(x.Type) && x.Selected).Select(x => x.Name)
                        .ToList());
                    this.ValNetcomboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x => Core.Helpers.Helper.IsNumericType(x.Type) && x.Selected).Select(x => x.Name)
                        .FirstOrDefault(x => x.Trim() == col3);

                    //
   this.ValN_1comboBoxEdit.Properties.Items.Clear();
                    this.ValN_1comboBoxEdit.Properties.Items.AddRange(excelDataSource1.Schema
                        .Where(x => Core.Helpers.Helper.IsNumericType(x.Type) && x.Selected).Select(x => x.Name)
                        .ToList());
                    this.ValN_1comboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x => Core.Helpers.Helper.IsNumericType(x.Type) && x.Selected).Select(x => x.Name)
                        .FirstOrDefault(x => x.Trim() == col4);
                }
                catch
                {
                    // ignored
                }
            this.buttonEdit1.EditValue = excelDataSource1.FileName;
            layoutControlGroup3.Visibility = LayoutVisibility.Never;

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.excelDataSource1.SaveToXml().ToString();
            this.f6004MABindingSource.EndEdit();
            this.DialogResult = DialogResult.OK;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var f6004MA = this.CurrentF6004MA;
            var dt = this.excelDataSource1.ToDataTable();
            int ligne = 1;
            foreach (DataRow dataRow in dt.Rows)
            {
                

                var ln = f6004MA.Lignes.FirstOrDefault(x => x.CodeN == dataRow[CodeRubNetcomboBoxEdit.Text].ToString());
                if (ln != null && !ln.Calculable)
                {
                    try
                    {
                        ln.ValeurN = dataRow[ValNetcomboBoxEdit.Text];
                    }
                    catch (Exception ex)
                    {


                    }
                }

                var ln_1 = f6004MA.Lignes.FirstOrDefault(x => x.CodeN1 == dataRow[CodeRubN_1comboBoxEdit.Text].ToString());
                if (ln_1 != null && !ln_1.Calculable)
                {
                    try
                    {
                        ln_1.ValeurN1 = dataRow[ValN_1comboBoxEdit.Text];
                    }
                    catch (Exception ex)
                    {


                    }
                }

            }

            this.f6004MABindingSource.DataSource = f6004MA;
            layoutControlGroup3.Visibility = LayoutVisibility.Always;
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                var col1 = "Code Rubrique (Net)";
                var col2 = "Code Rubrique (N-1)";
                //var col1 = "Code Rubrique (Net)";
                var col3 = "Net";
                //var col1 = "Libelle";
                // var col4 = "Brut";
                // var col5 = "Prov / Amort";
                var col4 = "Net N-1";
                                
                
                if (excelDataSource1.EditDataSource())
                {
                    buttonEdit1.EditValue = excelDataSource1.FileName;
                    excelDataSource1.Fill();
                    var xml = this.excelDataSource1.SaveToXml();
                    xml.Save(this._fileName);

                    //
                    this.CodeRubNetcomboBoxEdit.Properties.Items.Clear();
                    this.CodeRubNetcomboBoxEdit.Properties.Items.AddRange(excelDataSource1.Schema
                        .Where(x => x.Type == typeof(string) && x.Selected).Select(x => x.Name).ToList());
                    this.CodeRubNetcomboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x => x.Type == typeof(string) && x.Selected).Select(x => x.Name)
                        .FirstOrDefault(x => x.Trim() == col1);

                    //

                    //
                    this.CodeRubN_1comboBoxEdit.Properties.Items.Clear();
                    this.CodeRubN_1comboBoxEdit.Properties.Items.AddRange(excelDataSource1.Schema
                        .Where(x => x.Type == typeof(string) && x.Selected).Select(x => x.Name).ToList());
                    this.CodeRubN_1comboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x => x.Type == typeof(string) && x.Selected).Select(x => x.Name)
                        .FirstOrDefault(x => x.Trim() == col2);

                  
                    this.ValNetcomboBoxEdit.Properties.Items.Clear();
                    this.ValNetcomboBoxEdit.Properties.Items.AddRange(excelDataSource1.Schema
                        .Where(x => Core.Helpers.Helper.IsNumericType(x.Type) && x.Selected).Select(x => x.Name)
                        .ToList());
                    this.ValNetcomboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x => Core.Helpers.Helper.IsNumericType(x.Type) && x.Selected).Select(x => x.Name)
                        .FirstOrDefault(x => x.Trim() == col3);

                    //
                    this.ValN_1comboBoxEdit.Properties.Items.Clear();
                    this.ValN_1comboBoxEdit.Properties.Items.AddRange(excelDataSource1.Schema
                        .Where(x => Core.Helpers.Helper.IsNumericType(x.Type) && x.Selected).Select(x => x.Name)
                        .ToList());
                    this.ValN_1comboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x => Core.Helpers.Helper.IsNumericType(x.Type) && x.Selected).Select(x => x.Name)
                        .FirstOrDefault(x => x.Trim() == col4);
                }
            }
        }
    }
}