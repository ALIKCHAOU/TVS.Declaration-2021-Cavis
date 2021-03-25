using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using DevExpress.XtraEditors.DXErrorProvider;
using TVS.Core.Enums;

namespace TVS.Module.Cnss.ImportsSql.Views
{
    public class LigneImportSqlView : IDXDataErrorInfo
    {
        public string Matricule { get; set; }

        public string NumeroCnss { get; set; }

        public string CleCnss { get; set; }

        public Civilite Civilite { get; set; }

        public string Prenom { get; set; }

        public string AutresNom { get; set; }

        public string Nom { get; set; }

        public string NomJeuneFille { get; set; }

        public string Cin { get; set; }

        public decimal BrutA { get; set; }
        public decimal BrutB { get; set; }

        public decimal BrutC { get; set; }
      
        public SituationFamille SituationFamille { get; set; }

        public int Trimestre { get; set; }

        public int Annee { get; set; }

        public int TypeCnss { get; set; }

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
                        var rgxCin = new Regex(@"[0-9]{8}");
                        if (!rgxCin.IsMatch(Cin))
                        {
                            info.ErrorText = "Le champs [Cin] est invalide!";
                            info.ErrorType = ErrorType.Critical;
                        }
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
            if (propertyName == "BrutA")
            {
                if (BrutA < 0)
                {
                    info.ErrorText = "BrutA invalide! ";
                    info.ErrorType = ErrorType.Critical;
                }
            }

            //******* Verify BrutB ********
            if (propertyName == "BrutB")
            {
               if (BrutB < 0)
                    {
                        info.ErrorText = "BrutB invalide! ";
                        info.ErrorType = ErrorType.Critical;
                    }
            }
            
            //******* Verify BrutC ********
            if (propertyName == "BrutC")
            {
                if (BrutC < 0)
                    {
                        info.ErrorText = "BrutC invalide! ";
                        info.ErrorType = ErrorType.Critical;
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
                    || !regNumber.IsMatch(Matricule.Trim()))
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
            var rgxCin = new Regex(@"[0-9]{8}");
            if (!rgxCin.IsMatch(Cin))
            {
                return false;
            }

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
                || !regNumber.IsMatch(Matricule))
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