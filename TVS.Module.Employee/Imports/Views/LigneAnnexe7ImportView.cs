using TVS.Config.Helpers;
using TVS.Module.Employee.Models;
using TVS.Module.Employee.Models.Enums;

namespace TVS.Module.Employee.Imports.Views
{
    public class LigneAnnexe7ImportView : LigneAnnexeBase, ILingeImportAnnexe
    {
        private string _montantPayeeStr;
        private string _retenueSourceStr;
        private string _montantNetServiStr;

        public TypeMontantPayee TypeMontantPayee { get; set; }

        public decimal MontantPayee => NumeriqueHelper.ConvertToDecimal(_montantPayeeStr);

        public decimal RetenueSource => NumeriqueHelper.ConvertToDecimal(_retenueSourceStr);

        public decimal MontantNetServi => NumeriqueHelper.ConvertToDecimal(_montantNetServiStr);

        #region decimal string value

        public string MontantPayeeStr
        {
            get { return _montantPayeeStr.Trim(); }
            set { _montantPayeeStr = value; }
        }

        public string RetenueSourceStr
        {
            get { return _retenueSourceStr.Trim(); }
            set { _retenueSourceStr = value; }
        }

        public string MontantNetServiStr
        {
            get { return _montantNetServiStr.Trim(); }
            set { _montantNetServiStr = value; }
        }

        #endregion decimal string value
    }
}