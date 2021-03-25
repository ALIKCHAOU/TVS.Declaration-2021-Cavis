using TVS.Config.Helpers;
using TVS.Module.Employee.Models;
using TVS.Module.Employee.Models.Enums;

namespace TVS.Module.Employee.Imports.Views
{
    public class LigneAnnexe3ImportView : LigneAnnexeBase, ILingeImportAnnexe
    {
        private string _compteSpeciauxStr;
        private string _autreCapitauxMobilierStr;
        private string _pretEtabBancaireStr;
        private string _montantRetenueOpereeStr;
        private string _montantNetServiStr;

        public decimal CompteSpeciaux => NumeriqueHelper.ConvertToDecimal(_compteSpeciauxStr);

        public decimal AutreCapitauxMobilier => NumeriqueHelper.ConvertToDecimal(_autreCapitauxMobilierStr);

        public decimal PretEtabBancaire => NumeriqueHelper.ConvertToDecimal(_pretEtabBancaireStr);

        public decimal MontantRetenueOperee => NumeriqueHelper.ConvertToDecimal(_montantRetenueOpereeStr);

        public decimal MontantNetServi => NumeriqueHelper.ConvertToDecimal(_montantNetServiStr);

        #region decimal string value

        public string CompteSpeciauxStr
        {
            get { return _compteSpeciauxStr.Trim(); }
            set { _compteSpeciauxStr = value; }
        }

        public string AutreCapitauxMobilierStr
        {
            get { return _autreCapitauxMobilierStr.Trim(); }
            set { _autreCapitauxMobilierStr = value; }
        }

        public string PretEtabBancaireStr
        {
            get { return _pretEtabBancaireStr.Trim(); }
            set { _pretEtabBancaireStr = value; }
        }

        public string MontantRetenueOpereeStr
        {
            get { return _montantRetenueOpereeStr.Trim(); }
            set { _montantRetenueOpereeStr = value; }
        }

        public string MontantNetServiStr
        {
            get { return _montantNetServiStr.Trim(); }
            set { _montantNetServiStr = value; }
        }

        #endregion decimal string value
    }
}