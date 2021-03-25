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
    public partial class F6005ImportForm : DevExpress.XtraEditors.XtraForm
    {
        public Model.F6005 CurrentF6005 { get; private set; }
        private readonly string _fileName;
        public F6005ImportForm(Model.F6005 currentF6005)
        {
            InitializeComponent();
            CurrentF6005 = currentF6005;

            _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.ProductName, $"ModelImport_{CurrentF6005.GetType().Name}.xml");
            this.f6005BindingSource.DataSource = CurrentF6005;
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
                        .Where(x => x.Selected).Select(x => x.Name)
                        .ToList());
                    this.ValNetcomboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x => x.Selected).Select(x => x.Name)
                        .FirstOrDefault(x => x.Trim() == col3);

                    //
                    this.ValN_1comboBoxEdit.Properties.Items.Clear();
                    this.ValN_1comboBoxEdit.Properties.Items.AddRange(excelDataSource1.Schema
                        .Where(x => x.Selected).Select(x => x.Name)
                        .ToList());
                    this.ValN_1comboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x => x.Selected).Select(x => x.Name)
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
            this.f6005BindingSource.EndEdit();
            this.DialogResult = DialogResult.OK;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var f6005 = this.CurrentF6005;
            var dt = this.excelDataSource1.ToDataTable();
            int ligne = 1;
            foreach (DataRow dataRow in dt.Rows)
            {
                

                var ln = f6005.Lignes.FirstOrDefault(x => x.CodeN == dataRow[CodeRubNetcomboBoxEdit.Text].ToString());
                if (ln != null && !ln.Calculable)
                {
                    try
                    {


                        if (ln.ValeurN.GetType() == typeof(decimal))
                            ln.ValeurN = Convert.ToDecimal(dataRow[ValNetcomboBoxEdit.Text]);
                        else
                        {
                            if (ln.CodeN == "F60050001" || ln.CodeN == "F60050055")
                            {
                                if (ln.ValeurN.ToString() == "P" || ln.ValeurN.ToString() == "B")
                                {
                                    ln.ValeurN = dataRow[ValNetcomboBoxEdit.Text]; ;
                                }
                                else
                                    ln.ValeurN="B";
                            }                            
                        }

                    }
                    catch (Exception ex)
                    {


                    }
                }

                var ln_1 = f6005.Lignes.FirstOrDefault(x => x.CodeN1 == dataRow[CodeRubN_1comboBoxEdit.Text].ToString());
                if (ln_1 != null && !ln_1.Calculable)
                {
                    try
                    {


                        if (ln_1.ValeurN1.GetType() == typeof(decimal))
                            ln_1.ValeurN1 = Convert.ToDecimal(dataRow[ValN_1comboBoxEdit.Text]);

                        else

                        {
                            if (ln.CodeN1 == "F60051001" || ln.CodeN1 == "F60051055")
                            {
                                if (ln.ValeurN1.ToString() == "P" || ln.ValeurN1.ToString() == "B")
                                {
                                    ln_1.ValeurN1 = dataRow[ValN_1comboBoxEdit.Text];
                                    ;
                                }
                                else
                                    ln.ValeurN1 = "B";
                            }
                        }
                    }
                    catch (Exception ex)
                    {


                    }
                }

            }

            this.f6005BindingSource.DataSource = f6005;
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
                        .Where(x => x.Selected).Select(x => x.Name)
                        .ToList());
                    this.ValNetcomboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x =>  x.Selected).Select(x => x.Name)
                        .FirstOrDefault(x => x.Trim() == col3);

                    //
                    this.ValN_1comboBoxEdit.Properties.Items.Clear();
                    this.ValN_1comboBoxEdit.Properties.Items.AddRange(excelDataSource1.Schema
                        .Where(x =>  x.Selected).Select(x => x.Name)
                        .ToList());
                    this.ValN_1comboBoxEdit.EditValue = excelDataSource1.Schema
                        .Where(x =>  x.Selected).Select(x => x.Name)
                        .FirstOrDefault(x => x.Trim() == col4);
                }
            }
        }
    }
}