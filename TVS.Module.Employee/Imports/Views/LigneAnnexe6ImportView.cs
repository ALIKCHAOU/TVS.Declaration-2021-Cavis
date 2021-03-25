using TVS.Config.Helpers;
using TVS.Module.Employee.Models;
using TVS.Module.Employee.Models.Enums;

namespace TVS.Module.Employee.Imports.Views
{
    public class LigneAnnexe6ImportView : LigneAnnexeBase, ILingeImportAnnexe
    {
        private string _montantRistournesStr;
        private string _montantVentesStr;
        private string _montantAvancesStr;
        private string _montantRevenusJeuPariStr;
        private string _montantPercuesStr;
        private string _montantRetenuJeuPariStr;
        private string _montantVenteNeDepassantVingtStr;
        private string _montantRetenuNeDepassantVingtStr;
        public decimal MontantRistournes => NumeriqueHelper.ConvertToDecimal(_montantRistournesStr);

        public decimal MontantVentes => NumeriqueHelper.ConvertToDecimal(_montantVentesStr);

        public decimal MontantAvances => NumeriqueHelper.ConvertToDecimal(_montantAvancesStr);

        public decimal MontantPercues => NumeriqueHelper.ConvertToDecimal(_montantPercuesStr);

        public decimal MontantRevenusJeuPari => NumeriqueHelper.ConvertToDecimal(_montantRevenusJeuPariStr);
        public decimal MontantRetenuJeuPari => NumeriqueHelper.ConvertToDecimal(_montantRetenuJeuPariStr);

        public decimal MontantVenteNeDepassantVingt
            => NumeriqueHelper.ConvertToDecimal(_montantVenteNeDepassantVingtStr);

        public decimal MontantRetenuNeDepassantVingt
            => NumeriqueHelper.ConvertToDecimal(_montantRetenuNeDepassantVingtStr);

        #region decimal string value

        public string MontantRistournesStr
        {
            get { return _montantRistournesStr.Trim(); }
            set { _montantRistournesStr = value; }
        }

        public string MontantVentesStr
        {
            get { return _montantVentesStr.Trim(); }
            set { _montantVentesStr = value; }
        }

        public string MontantAvancesStr
        {
            get { return _montantAvancesStr.Trim(); }
            set { _montantAvancesStr = value; }
        }

        public string MontantRevenusJeuPariStr
        {
            get { return _montantRevenusJeuPariStr.Trim(); }
            set { _montantRevenusJeuPariStr = value; }
        }

        public string MontantRetenuJeuPariStr
        {
            get { return _montantRetenuJeuPariStr.Trim(); }
            set { _montantRetenuJeuPariStr = value; }
        }

        public string MontantVenteNeDepassantVingtStr
        {
            get { return _montantVenteNeDepassantVingtStr.Trim(); }
            set { _montantVenteNeDepassantVingtStr = value; }
        }

        public string MontantRetenuNeDepassantVingtStr
        {
            get { return _montantRetenuNeDepassantVingtStr.Trim(); }
            set { _montantRetenuNeDepassantVingtStr = value; }
        }

        public string MontantPercuesStr
        {
            get { return _montantPercuesStr.Trim(); }
            set { _montantPercuesStr = value; }
        }

        #endregion decimal string value
    }
}