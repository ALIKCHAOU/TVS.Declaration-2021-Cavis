using System;
using System.Globalization;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;

namespace TVS.Core.Reports
{
    public partial class DeclarationReport : XtraReport
    {
        private decimal _sum;
        private decimal _sumBrut1;
        private decimal _sumBrut2;
        private decimal _sumBrut3;

        public DeclarationReport()
        {
            InitializeComponent();
            //SetFunction(xrTableCell12);
            //SetFunction(xrSumBrut1);
            //SetFunction(xrSumBrut2);
            //SetFunction(xrSumBrut3);
            SetFunction(xrLabel5);
            //xrTableCell12.SummaryGetResult += SummaryGetResult;
            xrTableCell12.SummaryRowChanged += SummaryRowChanged;
            xrLabel5.SummaryGetResult += SummaryGetResultMontantEnToutetLettre;
            xrLabel5.PrintOnPage += SummaryGetResultMontantEnToutetLettre2;
            //xrSumBrut2.SummaryGetResult += SummaryGetResultBrut2;
            //xrSumBrut3.SummaryGetResult += SummaryGetResultBrut3;
            xrLabel3.PrintOnPage += xrLabel1_PrintOnPage;
            xrSumBrut1.PrintOnPage += xrBrut1_PrintOnPage;
            xrSumBrut2.PrintOnPage += xrBrut2_PrintOnPage;
            xrSumBrut3.PrintOnPage += xrBrut3_PrintOnPage;
            xrTableCell12.PrintOnPage += xrBrutTotal_PrintOnPage;
            ParametersRequestSubmit += DeclarationReport_ParametersRequestSubmit;
            BeforePrint += PageBeforePrint;
            //var x = new GroupField("");
            //GroupeByPage.GroupFields.Add(null);
        }

        private void Reset(object sender, EventArgs e)
        {
            _sumBrut1 = 10;
        }

        private void DeclarationReport_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            _sum = 0;
            _sumBrut1 = 0;
            _sumBrut2 = 0;
            _sumBrut3 = 0;
        }

        private void PageBeforePrint(object sender, EventArgs e)
        {
            xrLabel5.Text = Helper.MontantEnLettre(_sum, "dinars", "millimes", 3);
        }

        public void SetFunction(XRLabel label)
        {
            // Create an XRSummary object.
            var summary = new XRSummary();

            // Set a function which should be calculated.
            summary.Func = SummaryFunc.Custom;

            // Set a range for which the function should be calculated.
            summary.Running = SummaryRunning.Group;

            // Set the "ingore null values" option.
            summary.IgnoreNullValues = true;

            // Set the output string format.
            summary.FormatString = "{0:c3}";

            // Make the label calculate the specified function for the
            // value specified by its DataBindings.Text property.
            label.Summary = summary;
        }

        public void SetFunction(XRTableCell label)
        {
            // Create an XRSummary object.
            var summary = new XRSummary();

            // Set a function which should be calculated.
            summary.Func = SummaryFunc.Custom;

            // Set a range for which the function should be calculated.
            summary.Running = SummaryRunning.Page;

            // Set the "ingore null values" option.
            summary.IgnoreNullValues = true;

            // Set the output string format.
            summary.FormatString = "{0:c3}";

            // Make the label calculate the specified function for the
            // value specified by its DataBindings.Text property.
            label.Summary = summary;
        }

        private void SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = string.Format("{0:0.000}", _sum);
            e.Handled = true;
        }

        private void SummaryGetResultMontantEnToutetLettre(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = Helper.MontantEnLettre(_sum, "dinars", "millimes", 3);
            e.Handled = true;
        }

        private void SummaryGetResultMontantEnToutetLettre2(object sender, PrintOnPageEventArgs e)
        {
        }

        private void SummaryRowChanged(object sender, EventArgs e)
        {
            _sum += Convert.ToDecimal(GetCurrentColumnValue("CTotal"));
            //_sumBrut1 += Convert.ToDecimal(GetCurrentColumnValue("Brut1"));
            //_sumBrut2 += Convert.ToDecimal(GetCurrentColumnValue("Brut2"));
            //_sumBrut3 += Convert.ToDecimal(GetCurrentColumnValue("Brut3"));
        }

        private void SummaryGetResultBrut1(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = string.Format("{0:0.000}", _sumBrut1);

            e.Handled = true;
        }

        private void SummaryGetResultBrut2(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = string.Format("{0:0.000}", _sumBrut2);
            e.Handled = true;
        }

        private void SummaryGetResultBrut3(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = string.Format("{0:0.000}", _sumBrut3);
            e.Handled = true;
        }

        private void xrLabel1_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            // Check if the label is printed on the last page.
            if (e.PageIndex == e.PageCount - 1)
                // Set its text.
                ((XRLabel) sender).Text = "Total";
            else
                ((XRLabel) sender).Text = "Total à reporter";
        }

        private void xrBrut1_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            var ds = (System.Data.DataSet) this.DataSource;
            var table = ds.Tables["TDeclaration"];
            var catNo = Parameters["ParamCategorie"].Value;
            var filterExpression = string.Format(CultureInfo.InvariantCulture, "[Page] <= {0} And CategorieNo ={1}  ",
                e.PageIndex + 1, catNo);
            object oBrut1 = table.Compute("SUM(Brut1)", filterExpression);
            decimal montant = 0;
            if (oBrut1 != null)
                System.Decimal.TryParse(oBrut1.ToString(), out montant);
            ((XRLabel) sender).Text = string.Format("{0:0.000}", montant);
        }

        private void xrBrut2_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            var ds = (System.Data.DataSet) this.DataSource;
            var table = ds.Tables["TDeclaration"];
            var catNo = Parameters["ParamCategorie"].Value;

            var filterExpression = string.Format(CultureInfo.InvariantCulture, "[Page] <= {0}  And CategorieNo ={1}  ",
                e.PageIndex + 1, catNo);
            object oBrut = table.Compute("SUM(Brut2)", filterExpression);
            decimal montant = 0;
            if (oBrut != null)
                System.Decimal.TryParse(oBrut.ToString(), out montant);
            ((XRLabel) sender).Text = string.Format("{0:0.000}", montant);
        }

        private void xrBrut3_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            var ds = (System.Data.DataSet) this.DataSource;
            var table = ds.Tables["TDeclaration"];
            var catNo = Parameters["ParamCategorie"].Value;
            var filterExpression = string.Format(CultureInfo.InvariantCulture, "[Page] <= {0} And CategorieNo ={1}  ",
                e.PageIndex + 1, catNo);
            object oBrut = table.Compute("SUM(Brut3)", filterExpression);
            decimal montant = 0;
            if (oBrut != null)
                System.Decimal.TryParse(oBrut.ToString(), out montant);
            ((XRLabel) sender).Text = string.Format("{0:0.000}", montant);
        }

        private void xrBrutTotal_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            var ds = (System.Data.DataSet) this.DataSource;
            var table = ds.Tables["TDeclaration"];
            var catNo = Parameters["ParamCategorie"].Value;
            var filterExpression = string.Format(CultureInfo.InvariantCulture, "[Page] <= {0} And CategorieNo ={1}  ",
                e.PageIndex + 1, catNo);
            object oBrut1 = table.Compute("SUM(Brut1)", filterExpression);
            object oBrut2 = table.Compute("SUM(Brut2)", filterExpression);
            object oBrut3 = table.Compute("SUM(Brut3)", filterExpression);
            decimal montantBrut1 = 0;
            decimal montantBrut2 = 0;
            decimal montantBrut3 = 0;
            if (oBrut1 != null)
                System.Decimal.TryParse(oBrut1.ToString(), out montantBrut1);
            if (oBrut2 != null)
                System.Decimal.TryParse(oBrut2.ToString(), out montantBrut2);
            if (oBrut3 != null)
                System.Decimal.TryParse(oBrut3.ToString(), out montantBrut3);
            ((XRLabel) sender).Text = string.Format("{0:0.000}", montantBrut3 + montantBrut2 + montantBrut1);
        }
    }
}