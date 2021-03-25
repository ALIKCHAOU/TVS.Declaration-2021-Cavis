using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.XtraEditors.DXErrorProvider;
using TVS.Core.Enums;

namespace TVS.Module.Cnss.ImportsSql.Views
{
    public class LigneSqlView : IDXDataErrorInfo
    {
        public string Matricule { get; set; }
        public string NumCnss { get; set; }
        public string Cin { get; set; }
        public string CleCnss { get; set; }
        public Civilite Civilite { get; set; }
        public SituationFamille SituationFamille { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string AutreNom { get; set; }
        public string NomJeuneFille { get; set; }
        public string Adresse { get; set; }
        public decimal BrutA { get; set; }
        public decimal BrutB { get; set; }
        public decimal BrutC { get; set; }


        public bool IsValide()
        {
            bool isValid = true;
            var regNumber = new Regex(@"^\d+$");
            var regName = new Regex(@"^[\ a-zA-Z\'\.]+$");
            
            Matricule = Matricule.Trim();
            CleCnss = CleCnss.Trim();
            NumCnss = NumCnss.Trim();
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

            //******* Verify Autres nom ********
            if (!regName.IsMatch(AutreNom) && AutreNom.Trim() != string.Empty)
            {
                return false;
            }

            //******* Verify NomJeuneFille ********

            if (!string.IsNullOrEmpty(NomJeuneFille) && !regName.IsMatch(NomJeuneFille.Trim()))
            {
                return false;
            }

            //******* Verify BrutA ********

            if (BrutA < 0)
            {
                return false;
            }

            //******* Verify BrutB ********

            if (BrutB < 0)
            {
                return false;
            }

            //******* Verify BrutC ********

            if (BrutC < 0)
            {
                return false;
            }

            //******* Verify Matricule ********
            if (string.IsNullOrEmpty(NumCnss)
                || NumCnss.Length > 8
                || !regNumber.IsMatch(NumCnss))
            {
                return false;
            }
            if (NumCnss.Trim().Length < 8)
            {
                NumCnss = NumCnss.Trim().PadLeft(8, '0');
            }
            

            //******* Verify Cle ********

            if (string.IsNullOrEmpty(CleCnss)
                   || CleCnss.Length > 2
                   || !regNumber.IsMatch(CleCnss.Trim()))
            {
                return false;
            }
          

            if (CleCnss.Trim().Length < 2)
            {
                CleCnss = CleCnss.Trim().PadLeft(2, '0');
            }
           

            //******* Verify matricule interne ********

            if (string.IsNullOrEmpty(Matricule)
                || Matricule.Length > 10
                //|| !regNumber.IsMatch(Matricule)
                )
            {
                return false;
            }

            return true;
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
           
            //******* Verify Autres nom ********
            if (propertyName == "AutreNom"
                && !regName.IsMatch(AutreNom.Trim())
                && AutreNom.Trim() != string.Empty)
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
            if (propertyName == "NumCnss")
            {
                if (string.IsNullOrEmpty(NumCnss)
                    || NumCnss.Trim().Length > 8
                    || !regNumber.IsMatch(NumCnss.Trim()))
                {
                    info.ErrorText = "Numéro Cnss invalide! ";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    NumCnss = NumCnss.Trim().PadLeft(8, '0');
                }
            }
            //******* Verify Cle ********
            if (propertyName == "CleCnss")
            {
                if (string.IsNullOrEmpty(CleCnss)
                    || CleCnss.Length > 2
                    || !regNumber.IsMatch(CleCnss.Trim()))
                {
                    info.ErrorText = "Clé Cnss invalide! ";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    CleCnss = CleCnss.Trim().PadLeft(2, '0');
                }
            }
            //******* Verify matricule interne ********
            if (propertyName == "Matricule")
            {
                if (string.IsNullOrEmpty(Matricule.Trim())
                    || Matricule.Trim().Length > 10
                   // || !regNumber.IsMatch(Matricule.Trim())
                    )
                {
                    info.ErrorText = "Matricule interne invalide! ";
                    info.ErrorType = ErrorType.Critical;
                }
            }
        }
    }
}
