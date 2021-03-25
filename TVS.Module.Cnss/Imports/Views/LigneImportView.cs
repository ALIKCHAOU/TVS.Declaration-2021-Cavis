using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using DevExpress.XtraEditors.DXErrorProvider;
using TVS.Core.Enums;

namespace TVS.Module.Cnss.Imports.Views
{
    public class LigneImportView : IDXDataErrorInfo
    {
        private string _anneeStr;
        private string _brutAStr;
        private string _brutBStr;
        private string _brutCStr;
        private string _situationFamilleStr;

        private string _trimestreStr;
        private string _typeCnssStr;

        public string Matricule { get; set; }

        public string NumeroCnss { get; set; }

        public string CleCnss { get; set; }

        public int CiviliteNo { get; set; }

        public Civilite Civilite
        {
            get { return (Civilite) CiviliteNo; }
            set { CiviliteNo = (int) value; }
        }

        public string Prenom { get; set; }

        public string AutresNom { get; set; }

        public string Nom { get; set; }

        public string NomJeuneFille { get; set; }

        public string Cin { get; set; }

        public string BrutAStr
        {
            get
            {
                if (_brutAStr == null) return "0";
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string brutStr = _brutAStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                return brutStr.Trim();
            }
            set { _brutAStr = value; }
        }

        public string BrutBStr
        {
            get
            {
                if (_brutBStr == null) return "0";
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string brutStr = _brutBStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                return brutStr.Trim();
            }
            set { _brutBStr = value; }
        }

        public string BrutCStr
        {
            get
            {
                if (_brutCStr == null) return "0";
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string brutStr = _brutCStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                return brutStr.Trim();
            }
            set { _brutCStr = value; }
        }

        public decimal BrutA
        {
            get
            {
                if (_brutAStr == null) return 0;
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string brutAtStr = _brutAStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal result;
                if (!Decimal.TryParse(brutAtStr, out result)) return 0;
                return result;
            }
        }

        public decimal BrutB
        {
            get
            {
                if (_brutBStr == null) return 0;
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string brutBtStr = _brutBStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal result;
                if (!Decimal.TryParse(brutBtStr, out result)) return 0;
                return result;
            }
        }

        public decimal BrutC
        {
            get
            {
                if (_brutCStr == null) return 0;
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string brutCtStr = _brutCStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal result;
                if (!Decimal.TryParse(brutCtStr, out result)) return 0;
                return result;
            }
        }

        public string SituationFamilleStr
        {
            get { return _situationFamilleStr.Trim(); }
            set { _situationFamilleStr = value; }
        }

        public string TrimestreStr
        {
            get { return _trimestreStr.Trim(); }
            set { _trimestreStr = value; }
        }

        public string AnneeStr
        {
            get { return _anneeStr.Trim(); }
            set { _anneeStr = value; }
        }

        public string TypeCnssStr
        {
            get { return _typeCnssStr.Trim(); }
            set { _typeCnssStr = value; }
        }

        public int SituationFamilleNo
        {
            get
            {
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string brutCtStr = _situationFamilleStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                int result;
                if (!int.TryParse(brutCtStr, out result)) return 0;
                return result;
            }
        }

        public SituationFamille SituationFamille
        {
            get { return (SituationFamille) SituationFamilleNo; }
            set { _situationFamilleStr = ((int) value).ToString(); }
        }

        public int Trimestre
        {
            get
            {
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string trim = _trimestreStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal result;
                if (!Decimal.TryParse(trim, out result)) return 0;
                return (int) result;
            }
        }

        public int Annee
        {
            get
            {
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string an = _anneeStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal result;
                if (!Decimal.TryParse(an, out result)) return 0;
                return (int) result;
            }
        }

        public int TypeCnss
        {
            get
            {
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string brutCtStr = _typeCnssStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal result;
                if (!Decimal.TryParse(brutCtStr, out result)) return 0;
                return (int) result;
            }
        }

        public void GetError(ErrorInfo info)
        {
            var propertyInfo = new ErrorInfo();
            GetPropertyError("Cin", propertyInfo);
            if (propertyInfo.ErrorText != "")
            {
                info.ErrorText = "Ligne invalide!";
            }
        }

        public void GetPropertyError(string propertyName, ErrorInfo info)
        {
            var regNumber = new Regex(@"^\d+$");
            var regName = new Regex(@"^[\ a-zA-Z\'\.]+$");
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
            //******* Verify Nom ***********
            if (propertyName == "Nom")
            {
                if (string.IsNullOrEmpty(Nom.Trim()))
                {
                    info.ErrorText = "Le champs [Nom] est obligatoire!";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    if (!regName.IsMatch(Nom.Trim()))
                    {
                        info.ErrorText = "Le champs [Nom] est invalide!";
                        info.ErrorType = ErrorType.Critical;
                    }
                }
            }
            //******* Verify Prenom ***********
            if (propertyName == "Prenom")
            {
                if (string.IsNullOrEmpty(Prenom.Trim()))
                {
                    info.ErrorText = "Le champs [Prenom] est obligatoire!";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    if (!regName.IsMatch(Prenom.Trim()))
                    {
                        info.ErrorText = "Le champs [Prénom] est invalide!";
                        info.ErrorType = ErrorType.Critical;
                    }
                }
            }
            //******* Verify CIN ***********
            if (propertyName == "Cin")
            {
                if (string.IsNullOrEmpty(Cin.Trim()))
                {
                    info.ErrorText = "Le champs [Cin] est obligatoire!";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    if (Cin.Length > 8)
                    {
                        info.ErrorText = "Le champs [Cin] est invalide!";
                        info.ErrorType = ErrorType.Critical;
                    }
                    else
                    {
                        if (Cin.Length < 8)
                        {
                            Cin = Cin.Trim().PadLeft(8, '0');
                        }
                        //var rgxCin = new Regex(@"[0-9]{8}");
                        //if (!rgxCin.IsMatch(Cin))
                        //{
                        //    info.ErrorText = "Le champs [Cin] est invalide!";
                        //    info.ErrorType = ErrorType.Critical;
                        //}
                    }
                }
            }
            //******** Verify Civilite **********
            if (propertyName == "Civilite" && (CiviliteNo < 0 || CiviliteNo > 2))
            {
                info.ErrorText = "Le champs [Civilité] est invalide!";
                info.ErrorType = ErrorType.Critical;
            }

            //******* Verify Autres nom ********
            if (propertyName == "AutresNom"
                && !regName.IsMatch(AutresNom.Trim())
                && AutresNom.Trim() != string.Empty)
            {
                info.ErrorText = "Le champs [Autres nom] est invalide!";
                info.ErrorType = ErrorType.Critical;
            }

            //******* Verify NomJeuneFille ********
            if (propertyName == "NomJeuneFille")
            {
                if (!string.IsNullOrEmpty(NomJeuneFille.Trim()) && !regName.IsMatch(NomJeuneFille.Trim()))
                {
                    info.ErrorText = "Le champs [Nom de jeune fille] est invalide!";
                    info.ErrorType = ErrorType.Critical;
                }
            }

            //******* Verify BrutA ********
            if (propertyName == "BrutAStr")
            {
                string brutAtStr = BrutAStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal brutA;
                if (!decimal.TryParse(brutAtStr, out brutA))
                {
                    info.ErrorText = "Format montant invalide [BrutA]!";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    if (brutA < 0)
                    {
                        info.ErrorText = "BrutA invalide! ";
                        info.ErrorType = ErrorType.Critical;
                    }
                }
            }

            //******* Verify BrutB ********
            if (propertyName == "BrutBStr")
            {
                string brutBtStr = BrutBStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal brutB;
                if (!decimal.TryParse(brutBtStr, out brutB))
                {
                    info.ErrorText = "Format montant invalide [BrutB]!";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    if (brutB < 0)
                    {
                        info.ErrorText = "BrutB invalide! ";
                        info.ErrorType = ErrorType.Critical;
                    }
                }
            }
            //******* Verify BrutC ********
            if (propertyName == "BrutCStr")
            {
                string brutCtStr = BrutCStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal brutC;
                if (!decimal.TryParse(brutCtStr, out brutC))
                {
                    info.ErrorText = "Format montant invalide [BrutC]!";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    if (brutC < 0)
                    {
                        info.ErrorText = "BrutC invalide! ";
                        info.ErrorType = ErrorType.Critical;
                    }
                }
            }
            //******* Verify Matricule ********
            if (propertyName == "NumeroCnss")
            {
                if (string.IsNullOrEmpty(NumeroCnss.Trim())
                    || NumeroCnss.Length > 8
                    || !regNumber.IsMatch(NumeroCnss.Trim()))
                {
                    info.ErrorText = "Numéro Cnss invalide! ";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    NumeroCnss = NumeroCnss.PadLeft(8, '0');
                }
            }
            //******* Verify Cle ********
            if (propertyName == "CleCnss")
            {
                if (string.IsNullOrEmpty(CleCnss.Trim())
                    || CleCnss.Length > 2
                    || !regNumber.IsMatch(CleCnss.Trim()))
                {
                    info.ErrorText = "Clé Cnss invalide! ";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    CleCnss = CleCnss.PadLeft(2, '0');
                }
            }
            //******* Verify matricule interne ********
            if (propertyName == "Matricule")
            {
                if (string.IsNullOrEmpty(Matricule.Trim())
                    || Matricule.Trim().Length > 10
                 //   || !regNumber.IsMatch(Matricule.Trim())
                    )
                {
                    info.ErrorText = "Matricule interne invalide! ";
                    info.ErrorType = ErrorType.Critical;
                }
            }
            //******* Verify Type cnss  ********
            if (propertyName == "TypeCnss")
            {
                if (TypeCnss > 19 || TypeCnss < 0)
                {
                    info.ErrorText = "Type cnss invalide! ";
                    info.ErrorType = ErrorType.Critical;
                }
            }
            //******* Situation familiale  ********
            if (propertyName == "SituationFamille")
            {
                if (SituationFamilleNo > 8 || SituationFamilleNo < 0)
                {
                    info.ErrorText = "Situation familiale invalide! ";
                    info.ErrorType = ErrorType.Critical;
                }
            }
        }

        public bool IsValide()
        {
            bool isValid = true;
            var regNumber = new Regex(@"^\d+$");
            var regName = new Regex(@"^[\ a-zA-Z\'\.]+$");
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

            Matricule = Matricule.Trim();
            CleCnss = CleCnss.Trim();
            NumeroCnss = NumeroCnss.Trim();
            Nom = Nom.Trim();
            Prenom = Prenom.Trim();

            //******* Verify Nom ***********

            if (string.IsNullOrEmpty(Nom))
            {
                return false;
            }
            if (!regName.IsMatch(Nom))
            {
                return false;
            }

            //******* Verify Prenom ***********

            if (string.IsNullOrEmpty(Prenom))
            {
                return false;
            }
            if (!regName.IsMatch(Prenom))
            {
                return false;
            }

            //******* Verify CIN ***********

            if (string.IsNullOrEmpty(Cin))
            {
                return false;
            }
            if (Cin.Length > 8)
            {
                return false;
            }
            if (Cin.Length < 8)
            {
                Cin = Cin.Trim().PadLeft(8, '0');
            }
            //var rgxCin = new Regex(@"[0-9]{8}");
            //if (!rgxCin.IsMatch(Cin))
            //{
            //    return false;
            //}

            //******** Verify Civilite **********
            if (CiviliteNo < 0 || CiviliteNo > 2)
            {
                return false;
            }

            //******* Verify Autres nom ********
            if (!regName.IsMatch(AutresNom) && AutresNom.Trim() != string.Empty)
            {
                return false;
            }

            //******* Verify NomJeuneFille ********

            if (!string.IsNullOrEmpty(NomJeuneFille) && !regName.IsMatch(NomJeuneFille.Trim()))
            {
                return false;
            }

            //******* Verify BrutA ********

            string brutAtStr = BrutAStr
                .Replace(",", decimalSeparator)
                .Replace(".", decimalSeparator);
            decimal brutA;
            if (!decimal.TryParse(brutAtStr, out brutA))
            {
                return false;
            }
            if (brutA < 0)
            {
                return false;
            }

            //******* Verify BrutB ********

            string brutBtStr = BrutBStr
                .Replace(",", decimalSeparator)
                .Replace(".", decimalSeparator);
            decimal brutB;
            if (!decimal.TryParse(brutBtStr, out brutB))
            {
                return false;
            }
            if (brutB < 0)
            {
                return false;
            }

            //******* Verify BrutC ********

            string brutCtStr = BrutCStr
                .Replace(",", decimalSeparator)
                .Replace(".", decimalSeparator);
            decimal brutC;
            if (!decimal.TryParse(brutCtStr, out brutC))
            {
                return false;
            }
            if (brutC < 0)
            {
                return false;
            }

            //******* Verify Matricule ********
            if (NumeroCnss.Trim().Length < 8)
            {
                NumeroCnss = NumeroCnss.Trim().PadLeft(8, '0');
            }
            if (string.IsNullOrEmpty(NumeroCnss)
                || NumeroCnss.Length > 8
                || !regNumber.IsMatch(NumeroCnss))
            {
                return false;
            }

            //******* Verify Cle ********
            if (CleCnss.Trim().Length < 2)
            {
                CleCnss = CleCnss.Trim().PadLeft(2, '0');
            }
            if (string.IsNullOrEmpty(CleCnss)
                || CleCnss.Length > 2
                || !regNumber.IsMatch(CleCnss))
            {
                return false;
            }

            //******* Verify matricule interne ********

            if (string.IsNullOrEmpty(Matricule)
                || Matricule.Length > 10
                //|| !regNumber.IsMatch(Matricule)
                )
            {
                return false;
            }

            //******* Verify Type cnss  ********

            if (TypeCnss > 19 || TypeCnss < 0)
            {
                return false;
            }

            //******* Situation familiale  ********

            if (SituationFamilleNo > 8 || SituationFamilleNo < 0)
            {
                return false;
            }
            return true;
        }
    }
}