using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using TVS.Core.Models;

namespace TVS.Module.Virement.ImportsSql
{
    public partial class FrmImportSqlVirement : DevExpress.XtraEditors.XtraForm
    {
        public FrmImportSqlVirement(Societe societe)
        {
            InitializeComponent();


            txtEtablissement.Properties.DisplayMember = "Intitule";
            txtEtablissement.Properties.ValueMember = "Id";
            txtEtablissement.Properties.View.Columns.Add(new GridColumn
            {
                Caption = "Initulé",
                FieldName = "Intitule",
                Visible = true
            });
            txtEtablissement.Properties.DataSource = GetEtb(societe); ;
            txtEtablissement.Properties.ImmediatePopup = true;
            txtEtablissement.Properties.View.OptionsView.ShowColumnHeaders = false;
            txtEtablissement.Properties.ShowFooter = false;
            txtEtablissement.Properties.View.OptionsView.ShowIndicator = false;
            txtEtablissement.Properties.PopupFormSize = new Size(30, 30);

        }

        public static IEnumerable<EtabSqlView> GetEtb(Societe societe)
        {
            var query = @"select T_ETA.CodeEtab 'Id',T_ETA.Intitule 'Intitule'FROM T_ETA";
            using (var con = new SqlConnection(societe.GetConnection()))
            {
                var result = con.Query<EtabSqlView>(query);

                return result;
            }
        }

        public string CurrentEtablissement
        {
            get { return this.txtEtablissement.EditValue as string; }
        }
    }
    public class EtabSqlView
    {
        public string Id { get; set; }
        public string Intitule { get; set; }
    }

   
}