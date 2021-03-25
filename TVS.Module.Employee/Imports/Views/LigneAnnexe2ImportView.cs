using TVS.Config.Helpers;
using TVS.Module.Employee.Models;
using TVS.Module.Employee.Models.Enums;

namespace TVS.Module.Employee.Imports.Views
{
    public class LigneAnnexe2ImportView : LigneAnnexeBase, ILingeImportAnnexe
    {
        private string _honorairesSocieteStr;

        private string _actionsPartSocialeStr;

        private string _remunerationsSalariesStr;

        private string _prixImmeubleStr;

        private string _loyersHotelsStr;

        private string _remunerationsArtistesStr;

        private string _honorairesBureauEtudeStr;

        private string _montantBrutHonorairesOperationExportationStr;

        private string _montantRetenueOpereeStr;

        private string _montantNetServiStr;
        private string _montantBurtOperateurTelephoniqueStr;

        #region decimal string value

        public string HonorairesSocieteStr
        {
            get { return _honorairesSocieteStr.Trim(); }
            set { _honorairesSocieteStr = value; }
        }

        public string ActionsPartSocialeStr
        {
            get { return _actionsPartSocialeStr.Trim(); }
            set { _actionsPartSocialeStr = value; }
        }

        public string RemunerationsSalariesStr
        {
            get { return _remunerationsSalariesStr.Trim(); }
            set { _remunerationsSalariesStr = value; }
        }

        public string PrixImmeubleStr
        {
            get { return _prixImmeubleStr.Trim(); }
            set { _prixImmeubleStr = value; }
        }

        public string LoyersHotelsStr
        {
            get { return _loyersHotelsStr.Trim(); }
            set { _loyersHotelsStr = value; }
        }

        public string RemunerationsArtistesStr
        {
            get { return _remunerationsArtistesStr.Trim(); }
            set { _remunerationsArtistesStr = value; }
        }

        public string MontantBurtOperateurTelephoniqueStr
        {
            get { return _montantBurtOperateurTelephoniqueStr.Trim(); }
            set { _montantBurtOperateurTelephoniqueStr = value; }
        }

        public string HonorairesBureauEtudeStr
        {
            get { return _honorairesBureauEtudeStr.Trim(); }
            set { _honorairesBureauEtudeStr = value; }
        }

        public string MontantBrutHonorairesOperationExportationStr
        {
            get { return _montantBrutHonorairesOperationExportationStr.Trim(); }
            set { _montantBrutHonorairesOperationExportationStr = value; }
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

        public TypeMontantServiAnnexe2 TypeMontantServiPersonne { get; set; }

        public decimal MontantBurtOperateurTelephonique
            => NumeriqueHelper.ConvertToDecimal(_montantBurtOperateurTelephoniqueStr);

        public decimal HonorairesSociete => NumeriqueHelper.ConvertToDecimal(_honorairesSocieteStr);

        public decimal ActionsPartSociale => NumeriqueHelper.ConvertToDecimal(_actionsPartSocialeStr);

        public decimal RemunerationsSalaries => NumeriqueHelper.ConvertToDecimal(_remunerationsSalariesStr);

        public decimal PrixImmeuble => NumeriqueHelper.ConvertToDecimal(_prixImmeubleStr);

        public decimal LoyersHotels => NumeriqueHelper.ConvertToDecimal(_loyersHotelsStr);

        public decimal RemunerationsArtistes => NumeriqueHelper.ConvertToDecimal(_remunerationsArtistesStr);

        public decimal HonorairesBureauEtude => NumeriqueHelper.ConvertToDecimal(_honorairesBureauEtudeStr);

        public TypeMontantServiAnnexe2 TypeMontantServiOperationExport { get; set; }

        public decimal MontantBrutHonorairesOperationExportation
            => NumeriqueHelper.ConvertToDecimal(_montantBrutHonorairesOperationExportationStr);

        public decimal MontantRetenueOperee => NumeriqueHelper.ConvertToDecimal(_montantRetenueOpereeStr);

        public decimal MontantNetServi => NumeriqueHelper.ConvertToDecimal(_montantNetServiStr);
    }
}