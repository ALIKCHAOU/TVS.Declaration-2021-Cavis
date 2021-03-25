using System;
using TVS.Config.Helpers;
using TVS.Core.Models;
using TVS.Module.Employee.Models;
using TVS.Module.Employee.Models.Enums;

namespace TVS.Module.Employee.Imports.Views
{
    public class LigneAnnexe1ImportView : LigneAnnexeBase, ILingeImportAnnexe
    {
       
        private string _nombreEnfantStr;
        private string _ChefFamilleStr; 


        private string _dureeEnJourStr;
        private string _revenuImposableStr;
        private string _avantageEnNatureStr;
        private string _revenuBrutImposableStr;
        private string _revenuReinvestiStr;
        private string _montantRetenuesRegimeCommunStr;
        private string _montantRetenuesTauxVingtStr;

        private string _montantNetServieStr;
        private string _retenueUnPrctStr;
        private string _contributionConjoncturelleStr;
        private string _contributionSocialSolid;
        private string _IntereDetectible;


        public SituationFamiliale SituationFamiliale { get; set; }

     //   private string _nombreEnfantStr;
        public int NombreEnfant
        {
            get { return NumeriqueHelper.ConvertToInt(_nombreEnfantStr); }
        }

     //   private string _ChefFamilleStr;
        public string ChefFamille
        {
            get { return _ChefFamilleStr; }
        }

        private DateTime _dateDebutTravail;

        public DateTime DateDebutTravail
        {
            get { return _dateDebutTravail; }
            set
            {
                //if (value < new DateTime(2016, 1, 1))
                //{
                //    _dateDebutTravail = new DateTime(2016, 1, 1);
                //    return;
                //}
                //if (value > new DateTime(2016, 12, 31))
                //{
                //    _dateDebutTravail = new DateTime(2016, 12, 31);
                //    return;
                //}
                _dateDebutTravail = value;
            }
        }

        private DateTime _dateFinTravail;

        public DateTime DateFinTravail
        {
            get { return _dateFinTravail; }
            set
            {
                //if (value < new DateTime(2016, 1, 1))
                //{
                //    _dateFinTravail = new DateTime(2016, 12, 31);
                //    return;
                //}
                //if (value > new DateTime(2016, 12, 31))
                //{
                //    _dateFinTravail = new DateTime(2016, 12, 31);
                //    return;
                //}
                _dateFinTravail = value;
            }
        }

        public int DureeEnJour
        {
            get { return (int) (DateFinTravail.Date - DateDebutTravail.Date).TotalDays + 1; }
        }

        public decimal RevenuImposable => NumeriqueHelper.ConvertToDecimal(_revenuImposableStr);

        public decimal AvantageEnNature => NumeriqueHelper.ConvertToDecimal(_avantageEnNatureStr);

        public decimal RevenuBrutImposable => NumeriqueHelper.ConvertToDecimal(_revenuBrutImposableStr);

        public decimal RevenuReinvesti => NumeriqueHelper.ConvertToDecimal(_revenuReinvestiStr);
        public decimal RetenueUnPrct => NumeriqueHelper.ConvertToDecimal(_retenueUnPrctStr);
        public decimal SalaireNonImposable => NumeriqueHelper.ConvertToDecimal(_salaireNonImposableStr);

       public decimal ContributionConjoncturelle => NumeriqueHelper.ConvertToDecimal(_contributionConjoncturelleStr);
        public decimal ContributionSocialeSol => NumeriqueHelper.ConvertToDecimal(_contributionSocialSolid);

        public decimal InteretDeductibleSol => NumeriqueHelper.ConvertToDecimal(_IntereDetectible);

        public decimal MontantRetenuesRegimeCommun
        {
            get
            {
                if (!string.IsNullOrEmpty(_montantRetenuesRegimeCommunStr))
                    return NumeriqueHelper.ConvertToDecimal(_montantRetenuesRegimeCommunStr);
                var irpp1 = NumeriqueHelper.ConvertToDecimal(_irpp1Str);
                var irpp2 = NumeriqueHelper.ConvertToDecimal(_irpp2Str);
                var irpp3 = NumeriqueHelper.ConvertToDecimal(_irpp3Str);
                return irpp1 + irpp2 + irpp3;
            }
        }

        public decimal MontantRetenuesTauxVingt => NumeriqueHelper.ConvertToDecimal(_montantRetenuesTauxVingtStr);

        public decimal MontantNetServie => NumeriqueHelper.ConvertToDecimal(_montantNetServieStr);

        #region decimal string value

        private string _nom;

        public string Nom
        {
            get { return _nom; }
            set
            {
                _nom = value;
                if (!string.IsNullOrEmpty(value))
                    Beneficiaire = string.Format("{0} {1}", value, _prenom);
            }
        }

        private string _prenom;

        public string Prenom
        {
            get { return _prenom; }
            set
            {
                _prenom = value;
                if (!string.IsNullOrEmpty(value))
                    Beneficiaire = string.Format("{0} {1}", _nom, value);
            }
        }

        public string NombreEnfantStr
        {
            get { return _nombreEnfantStr.Trim(); }
            set { _nombreEnfantStr = value; }
        }


        public string ChefFamilletStr
        {
            get { return _ChefFamilleStr.Trim(); }
            set { _ChefFamilleStr = value; }
        }

        public string DureeEnJourStr
        {
            get { return _dureeEnJourStr.Trim(); }
            set { _dureeEnJourStr = value; }
        }

        public string RevenuImposableStr
        {
            get { return _revenuImposableStr.Trim(); }
            set { _revenuImposableStr = value; }
        }

        public string AvantageEnNatureStr
        {
            get { return _avantageEnNatureStr.Trim(); }
            set { _avantageEnNatureStr = value; }
        }

        public string RevenuBrutImposableStr
        {
            get { return _revenuBrutImposableStr.Trim(); }
            set { _revenuBrutImposableStr = value; }
        }

        public string RevenuReinvestiStr
        {
            get { return _revenuReinvestiStr.Trim(); }
            set { _revenuReinvestiStr = value; }
        }

        public string MontantRetenuesRegimeCommunStr
        {
            get { return _montantRetenuesRegimeCommunStr.Trim(); }
            set { _montantRetenuesRegimeCommunStr = value; }
        }

        public string MontantRetenuesTauxVingtStr
        {
            get { return _montantRetenuesTauxVingtStr.Trim(); }
            set { _montantRetenuesTauxVingtStr = value; }
        }

        public string MontantNetServieStr
        {
            get { return _montantNetServieStr.Trim(); }
            set { _montantNetServieStr = value; }
        }
        public string ContributionConjoncturelleStr
        {
            get { return _contributionConjoncturelleStr.Trim(); }
            set { _contributionConjoncturelleStr = value; }
        }
 public string ContributionSocialeSolid
        {
            get { return _contributionSocialSolid.Trim(); }
            set { _contributionSocialSolid = value; }
        }


public string IntereDetectible
        {
            get { return _IntereDetectible.Trim(); }
            set { _IntereDetectible = value; }
        }

        private string _salaireNonImposableStr;
        public string SalaireNonImposableStr
        {
            get { return _salaireNonImposableStr.Trim(); }
            set { _salaireNonImposableStr = value; }
        }
        public string RetenueUnPrctStr
        {
            get { return _retenueUnPrctStr.Trim(); }
            set { _retenueUnPrctStr = value; }
        }

        private string _irpp1Str;

        public string Irpp1Str
        {
            get { return _irpp1Str.Trim(); }
            set { _irpp1Str = value; }
        }

        private string _irpp2Str;

        public string Irpp2Str
        {
            get { return _irpp2Str.Trim(); }
            set { _irpp2Str = value; }
        }

        private string _irpp3Str;

        public string Irpp3Str
        {
            get { return _irpp3Str.Trim(); }
            set { _irpp3Str = value; }
        }

        private int _gaSituationFamiliale;

        public int GaSituationFamiliale
        {
            get { return _gaSituationFamiliale; }
            set
            {
                switch (value)
                {
                    case 0:
                        SituationFamiliale = SituationFamiliale.Celebataire;
                        break;
                    case 1:
                        SituationFamiliale = SituationFamiliale.Mariee;
                        break;
                    case 2:
                        SituationFamiliale = SituationFamiliale.Veuf;
                        break;
                    case 3:
                        SituationFamiliale = SituationFamiliale.Divorse;
                        break;
                }
            }
        }

        #endregion decimal string value
    }
}