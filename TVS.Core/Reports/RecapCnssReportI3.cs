using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using DevExpress.XtraReports.UI;

namespace TVS.Core.Reports
{
    public partial class RecapCnssReportI3 : XtraReport
    {
        private decimal _accidentDetravail;
        private int _count;
        private decimal _sumTotal;
        private decimal _taux;
        private string _codeExploitation;

        public RecapCnssReportI3()
        {
            InitializeComponent();

            BeforePrint += lbMontant_BeforePrint;
            //  lbMontant2.BeforePrint += lbMontant_BeforePrint;
            DataSourceDemanded += DemandedDaaSource;
        }

        private void DemandedDaaSource(object sender, EventArgs e)
        {
            var data = DataSource as TVS.Core.Data.DeclarationDs;
            if (data == null) throw new InvalidOperationException("DataSource invalide!");

            // charger parametre
            var no = (int)Parameters["ParamCategorie"].Value;
            if (no == 0) return;

            // filtrer les lignes declarations
            IEnumerable<DataRow> results = from DataRow myRow in data.Tables["TDeclaration"].Rows
                                           where (int)myRow["CategorieNo"] == (int)Parameters["ParamCategorie"].Value
                                           select myRow;
            // calculer les sommes des bruts
            decimal sumBrut1 = results.ToList().Sum(x => (decimal)x[3]);
            decimal sumBrut2 = results.ToList().Sum(x => (decimal)x[4]);
            decimal sumBrut3 = results.ToList().Sum(x => (decimal)x[5]);

            _sumTotal = sumBrut1 + sumBrut2 + sumBrut3;
            _count = results.Count();
            // charge categorie a imprimer
            IEnumerable<DataRow> categories = from DataRow myRow in data.Tables["TCategorie"].Rows
                                              where (int)myRow["No"] == (int)Parameters["ParamCategorie"].Value
                                              select myRow;
            DataRow categorie = categories.FirstOrDefault();
            if (categorie == null) throw new InvalidOperationException("Catégorie invalide!");
            _taux = (decimal)categorie[4] + (decimal)categorie[3];
            _accidentDetravail = (decimal)categorie[5];
            _codeExploitation = categorie[2].ToString();
        }

        private void lbMontant_BeforePrint(object sender, PrintEventArgs e)
        {
            lbMontant1.Text = string.Format("{0:0.000}", _sumTotal);
            //lbMontant2.Text = string.Format("{0:0.000}", _sumTotal);
            lbTaux.Text = string.Format("{0:0.000}", _taux);
            lbTauxAccident.Text = string.Format("{0:0.000}", _accidentDetravail);
            decimal montantAccident = (_sumTotal / 100) * _accidentDetravail;
            decimal montantApaye = (_sumTotal / 100) * _taux;

            
            decimal totalAPaye =Math.Round( montantAccident + montantApaye,3);
            decimal totalAPaye1 = Math.Round(montantAccident, 3) + Math.Round(montantApaye, 3);
            if(totalAPaye< totalAPaye1)     
                totalAPaye = totalAPaye1;
                
            
            montantAccident = totalAPaye - montantApaye;
            lbMonatAccident.Text = string.Format("{0:0.000}", montantAccident);
            lbMontantCotisation.Text = string.Format("{0:0.000}", montantApaye);


            lbMontantTotal.Text = string.Format("{0:0.000}", totalAPaye);
            //lbmontantTotal2.Text = string.Format("{0:0.000}", totalAPaye);
            // lbMontantTotal3.Text = string.Format("{0:0.000}", totalAPaye);
            lbMontantEnLettre.Text = Helper.MontantEnLettre(totalAPaye, "Dinar", "Millime", 3);
            lbCodeExploitation.Text = _codeExploitation.ToString();
            // lbCountSal.Text = string.Format("{0}", _count);
            // lbCountSal2.Text = string.Format("{0}", _count);
        }
    }
}