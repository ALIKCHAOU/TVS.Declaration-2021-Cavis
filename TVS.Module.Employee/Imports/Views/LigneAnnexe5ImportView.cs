using TVS.Config.Helpers;
using TVS.Module.Employee.Models;
using TVS.Module.Employee.Models.Enums;

namespace TVS.Module.Employee.Imports.Views
{
    public class LigneAnnexe5ImportView : LigneAnnexeBase //, ILingeImportAnnexe
    {
        private string _montantOpExportStr;

        private string _retenueOpExportStr;

        private string _montantAutreOpStr;

        private string _retenueAutreOpStr;

        private string _montantEtabprivateStr;

        private string _retenueEtabprivateStr;

        private string _montantEtabAlEtrangerStr;

        private string _retenueEtabAlEtrangerStr;

        private string _montantNetServiStr;

        public string MontantOpExportStr
        {
            get { return _montantOpExportStr.Trim(); }
            set { _montantOpExportStr = value; }
        }

        public string RetenueOpExportStr
        {
            get { return _retenueOpExportStr.Trim(); }
            set { _retenueOpExportStr = value; }
        }

        public string MontantAutreOpStr
        {
            get { return _montantAutreOpStr.Trim(); }
            set { _montantAutreOpStr = value; }
        }

        public string RetenueAutreOpStr
        {
            get { return _retenueAutreOpStr.Trim(); }
            set { _retenueAutreOpStr = value; }
        }

        public string MontantEtabPublicStr
        {
            get { return _montantEtabprivateStr.Trim(); }
            set { _montantEtabprivateStr = value; }
        }

        public string RetenueEtabPublicStr
        {
            get { return _retenueEtabprivateStr.Trim(); }
            set { _retenueEtabprivateStr = value; }
        }

        public string MontantEtabAlEtrangerStr
        {
            get { return _montantEtabAlEtrangerStr.Trim(); }
            set { _montantEtabAlEtrangerStr = value; }
        }

        public string RetenueEtabAlEtrangerStr
        {
            get { return _retenueEtabAlEtrangerStr.Trim(); }
            set { _retenueEtabAlEtrangerStr = value; }
        }

        public string MontantNetServiStr
        {
            get { return _montantNetServiStr.Trim(); }
            set { _montantNetServiStr = value; }
        }

        public decimal MontantOpExport => NumeriqueHelper.ConvertToDecimal(_montantOpExportStr);

        public decimal RetenueOpExport => NumeriqueHelper.ConvertToDecimal(_retenueOpExportStr);

        public decimal MontantAutreOp => NumeriqueHelper.ConvertToDecimal(_montantAutreOpStr);

        public decimal RetenueAutreOp => NumeriqueHelper.ConvertToDecimal(_retenueAutreOpStr);

        public decimal MontantEtabPublic => NumeriqueHelper.ConvertToDecimal(_montantEtabprivateStr);

        public decimal RetenueEtabPublic => NumeriqueHelper.ConvertToDecimal(_retenueEtabprivateStr);

        public decimal MontantEtabAlEtranger => NumeriqueHelper.ConvertToDecimal(_montantEtabAlEtrangerStr);

        public decimal RetenueEtabAlEtranger => NumeriqueHelper.ConvertToDecimal(_retenueEtabAlEtrangerStr);

        public decimal MontantNetServi => NumeriqueHelper.ConvertToDecimal(_montantNetServiStr);
    }
}