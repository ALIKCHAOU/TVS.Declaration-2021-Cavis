using TVS.Config.Helpers;
using TVS.Module.Employee.Models;
using TVS.Module.Employee.Models.Enums;

namespace TVS.Module.Employee.Imports.Views
{
    public class LigneAnnexe4ImportView : LigneAnnexeBase, ILingeImportAnnexe
    {
        private string _tauxMontantServiStr;
        private string _montantServiStr;
        private string _tauxHonoraireNonResidenteStr;
        private string _montantHonoraireNonResidenteStr;
        private string _tauxPlusValueImmobiliereStr;
        private string _montantPlusValueImmobiliereStr;
        private string _tauxRevenuValeurMobiliereStr;
        private string _montantValeurMobiliereStr;
        private string _montantJetonsPresenceStr;
        private string _montantActionsPartSocialeStr;
        private string _tauxRevenuValueCessionStr;
        private string _montantRevenuValueCessionStr;
        private string _montantRetenueOpereeStr;
        private string _montantBrutExportStr;
        private string _montantParadisFiscauxStr;
        private string _montantNetServiStr;
        // private string _montantRevenuValueMobiliereStr;
        private string _montantCessionStr;
        private string _tauxRevenuValueMobiliereStr;
        private string _tauxTauxCessionStr;

        public TypeMontantServiAnnexe4 TypeMontantServiActNonCommercial { get; set; }

        public decimal TauxMontantServi => NumeriqueHelper.ConvertToDecimal(_tauxMontantServiStr);

        public decimal MontantServi => NumeriqueHelper.ConvertToDecimal(_montantServiStr);

        public decimal TauxHonoraireNonResidente => NumeriqueHelper.ConvertToDecimal(_tauxHonoraireNonResidenteStr);

        public decimal MontantHonoraireNonResidente
            => NumeriqueHelper.ConvertToDecimal(_montantHonoraireNonResidenteStr);

        public decimal TauxPlusValueImmobiliere => NumeriqueHelper.ConvertToDecimal(_tauxPlusValueImmobiliereStr);

        public decimal MontantPlusValueImmobiliere => NumeriqueHelper.ConvertToDecimal(_montantPlusValueImmobiliereStr);

        public decimal TauxRevenuValeurMobiliere => NumeriqueHelper.ConvertToDecimal(_tauxRevenuValeurMobiliereStr);

        public decimal MontantRevenuValeurMobiliere => NumeriqueHelper.ConvertToDecimal(_montantValeurMobiliereStr);

        public decimal MontantJetonsPresence => NumeriqueHelper.ConvertToDecimal(_montantJetonsPresenceStr);

        public decimal MontantActionsPartSociale => NumeriqueHelper.ConvertToDecimal(_montantActionsPartSocialeStr);

        public decimal TauxRevenuValueCession => NumeriqueHelper.ConvertToDecimal(_tauxRevenuValueCessionStr);

        public decimal MontantRevenuValueCession => NumeriqueHelper.ConvertToDecimal(_montantRevenuValueCessionStr);

        public decimal MontantRetenueOperee => NumeriqueHelper.ConvertToDecimal(_montantRetenueOpereeStr);
        public TypeMontantServiAnnexe2 TypeMontantServiExport { get; set; }

        public decimal MontantBrutExport => NumeriqueHelper.ConvertToDecimal(_montantBrutExportStr);

        public decimal MontantParadisFiscaux => NumeriqueHelper.ConvertToDecimal(_montantParadisFiscauxStr);

        public decimal MontantNetServi => NumeriqueHelper.ConvertToDecimal(_montantNetServiStr);


        //     public decimal MontantRevenuValueMobiliere => NumeriqueHelper.ConvertToDecimal(_montantRevenuValueMobiliereStr);
        public decimal TauxRevenuValueMobiliere => NumeriqueHelper.ConvertToDecimal(_tauxRevenuValueMobiliereStr);
        public decimal MontantCession => NumeriqueHelper.ConvertToDecimal(_montantCessionStr);
        public decimal TauxCession => NumeriqueHelper.ConvertToDecimal(_tauxTauxCessionStr);

        #region

        public string TauxMontantServiStr
        {
            get { return _tauxMontantServiStr.Trim(); }
            set { _tauxMontantServiStr = value; }
        }

        public string MontantServiStr
        {
            get { return _montantServiStr.Trim(); }
            set { _montantServiStr = value; }
        }

        public string TauxHonoraireNonResidenteStr
        {
            get { return _tauxHonoraireNonResidenteStr.Trim(); }
            set { _tauxHonoraireNonResidenteStr = value; }
        }

        public string MontantHonoraireNonResidenteStr
        {
            get { return _montantHonoraireNonResidenteStr.Trim(); }
            set { _montantHonoraireNonResidenteStr = value; }
        }

        public string TauxPlusValueImmobiliereStr
        {
            get { return _tauxPlusValueImmobiliereStr.Trim(); }
            set { _tauxPlusValueImmobiliereStr = value; }
        }

        public string MontantPlusValueImmobiliereStr
        {
            get { return _montantPlusValueImmobiliereStr.Trim(); }
            set { _montantPlusValueImmobiliereStr = value; }
        }

        public string TauxRevenuValeurMobiliereStr
        {
            get { return _tauxRevenuValeurMobiliereStr.Trim(); }
            set { _tauxRevenuValeurMobiliereStr = value; }
        }

        public string MontantValeurMobiliereStr
        {
            get { return _montantValeurMobiliereStr.Trim(); }
            set { _montantValeurMobiliereStr = value; }
        }

        public string MontantJetonsPresenceStr
        {
            get { return _montantJetonsPresenceStr.Trim(); }
            set { _montantJetonsPresenceStr = value; }
        }

        public string MontantActionsPartSocialeStr
        {
            get { return _montantActionsPartSocialeStr.Trim(); }
            set { _montantActionsPartSocialeStr = value; }
        }

        public string TauxRevenuValueCessionStr
        {
            get { return _tauxRevenuValueCessionStr.Trim(); }
            set { _tauxRevenuValueCessionStr = value; }
        }

        public string MontantRevenuValueCessionStr
        {
            get { return _montantRevenuValueCessionStr.Trim(); }
            set { _montantRevenuValueCessionStr = value; }
        }

        public string MontantRetenueOpereeStr
        {
            get { return _montantRetenueOpereeStr.Trim(); }
            set { _montantRetenueOpereeStr = value; }
        }

        public string MontantBrutExportStr
        {
            get { return _montantBrutExportStr.Trim(); }
            set { _montantBrutExportStr = value; }
        }

        public string MontantParadisFiscauxStr
        {
            get { return _montantParadisFiscauxStr.Trim(); }
            set { _montantParadisFiscauxStr = value; }
        }

        public string MontantNetServiStr
        {
            get { return _montantNetServiStr.Trim(); }
            set { _montantNetServiStr = value; }
        }

        //public string MontantRevenuValueMobiliereStr
        //{
        //    get { return _montantRevenuValueMobiliereStr.Trim(); }
        //    set { _montantRevenuValueMobiliereStr = value; }
        //}

        public string TauxRevenuValueMobiliereStr
        {
            get { return _tauxRevenuValueMobiliereStr.Trim(); }
            set { _tauxRevenuValueMobiliereStr = value; }
        }

        public string MontantCessionStr
        {
            get { return _montantCessionStr.Trim(); }
            set { _montantCessionStr = value; }
        }

        public string TauxTauxCessionStr
        {
            get { return _tauxTauxCessionStr.Trim(); }
            set { _tauxTauxCessionStr = value; }
        }

        #endregion
    }
}