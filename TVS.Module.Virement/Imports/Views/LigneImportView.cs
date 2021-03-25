using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using DevExpress.XtraEditors.DXErrorProvider;
using TVS.Config.Helpers;

namespace TVS.Module.Virement.Imports.Views
{
    public class LigneImportView : IDXDataErrorInfo
    {
        private string _netAPayeStr;
        public string Matricule { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string NomBanque { get; set; }

        private string _codeBanque;
        public string CodeBanque
        {
            get => _codeBanque;
            set => _codeBanque = value.Trim().Length > 2 ? value.Trim().Substring(value.Trim().Length - 2) : value.Trim();
        }

        public string CodeGuichet { get; set; }

        public string NumeroCompte { get; set; }

        public string CleRib { get; set; }

        public decimal NetAPaye
        {
            get
            {
                if (_netAPayeStr == null) return 0;
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string brutAtStr = _netAPayeStr.Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal result;
                if (!Decimal.TryParse(brutAtStr, out result)) return 0;
                return result;
            }
        }

        public string Motif { get; set; }

        public string NetAPayeStr
        {
            get
            {
                if (_netAPayeStr == null) return "0";
                var culture = Thread.CurrentThread.CurrentCulture;
                var decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                var montantStr = _netAPayeStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                return montantStr.Trim();
            }
            set { _netAPayeStr = string.IsNullOrEmpty(value) ? "0" : value; }
        }


        public void GetPropertyError(string propertyName, ErrorInfo info)
        {
            var regexInt = new Regex(@"^\d+$");
            var culture = Thread.CurrentThread.CurrentCulture;
            var decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
            //******* Matricule ***********
            if (propertyName == "Matricule")
                if (string.IsNullOrEmpty(Matricule.Trim()))
                {
                    info.ErrorText = "Le champs [Matricule] est obligatoire!";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    if (Matricule.Length > 20)
                    {
                        info.ErrorText = "Longeur invalide! [Matricule]";
                        info.ErrorType = ErrorType.Critical;
                    }
                }

            //******* Nom ***********
            if (propertyName == "Nom")
                if (string.IsNullOrEmpty(Nom.Trim()))
                {
                    info.ErrorText = "Le champs [Nom] est obligatoire!";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    if (Nom.Length > 20)
                    {
                        info.ErrorText = "Longeur invalide! [Nom]";
                        info.ErrorType = ErrorType.Critical;
                    }
                }

            //******* Prenom ***********
            if (propertyName == "Prenom")
                if (string.IsNullOrEmpty(Prenom.Trim()))
                {
                    info.ErrorText = "Le champs [Prénom] est obligatoire!";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    if (Prenom.Length > 20)
                    {
                        info.ErrorText = "Longeur invalide! [Prénom]";
                        info.ErrorType = ErrorType.Critical;
                    }
                }

            //******* Verify NomBanque ***********
            if (propertyName == "NomBanque")
                if (string.IsNullOrEmpty(NomBanque.Trim()))
                {
                    info.ErrorText = "Le champs [NomBanque] est obligatoire!";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    if (NomBanque.Length > 10)
                    {
                        info.ErrorText = "Longeur invalide! [NomBanque]";
                        info.ErrorType = ErrorType.Critical;
                    }
                }
            //******* Verify CodeBanque ***********
            var ribValide = true;
            if (propertyName == "CodeBanque")
                if (string.IsNullOrEmpty(CodeBanque.Trim()))
                {
                    info.ErrorText = "Le champs [Code Banque] est obligatoire!";
                    info.ErrorType = ErrorType.Critical;
                    ribValide = false;
                }
                else
                {
                    if (CodeBanque.Length > 2)
                    {
                        info.ErrorText = "Longeur invalide! [Code Banque]";
                        info.ErrorType = ErrorType.Critical;
                        ribValide = false;
                        //CodeBanque = CodeBanque.Trim();
                        //CodeBanque = CodeBanque.Substring(CodeBanque.Length-2);
                    }
                    else
                    {
                        CodeBanque = CodeBanque.Trim();                       

                        if (!regexInt.IsMatch(CodeBanque))
                        {
                            info.ErrorText = "Type de donnée! [Code Banque]";
                            info.ErrorType = ErrorType.Critical;
                            ribValide = false;
                        }
                        
                    }
                }
            //******* Verify CodeGuichet ***********
            if (propertyName == "CodeGuichet")
                if (string.IsNullOrEmpty(CodeGuichet.Trim()))
                {
                    info.ErrorText = "Le champs [Code Guichet] est obligatoire!";
                    info.ErrorType = ErrorType.Critical;
                    ribValide = false;

                }
                else
                {
                    if (CodeGuichet.Length > 6)
                    {
                        info.ErrorText = "Longeur invalide! [Code Guichet]";
                        info.ErrorType = ErrorType.Critical;
                        ribValide = false;

                    }
                    else
                    {
                        CodeGuichet = CodeGuichet.Trim();
                        if (!regexInt.IsMatch(CodeGuichet))
                        {
                            info.ErrorText = "Type de donnée! [Code Guichet]";
                            info.ErrorType = ErrorType.Critical;
                            ribValide = false;
                        }

                    }
                }
            //******* Verify NumeroCompte ***********
            if (propertyName == "NumeroCompte")
                if (string.IsNullOrEmpty(NumeroCompte.Trim()))
                {
                    info.ErrorText = "Le champs [Numero Compte] est obligatoire!";
                    info.ErrorType = ErrorType.Critical;
                    ribValide = false;
                }
                else
                {
                    //if (NumeroCompte.Length > 10)
                    if (NumeroCompte.Length > 11)
                    {
                        info.ErrorText = "Longeur invalide! [Numero Compte]";
                        info.ErrorType = ErrorType.Critical;
                        ribValide = false;
                    }
                    else
                    {
                        NumeroCompte = NumeroCompte.Trim();
                        if (!regexInt.IsMatch(NumeroCompte))
                        {
                            info.ErrorText = "Type de donnée! [Numero Compte]";
                            info.ErrorType = ErrorType.Critical;
                            ribValide = false;
                        }

                    }
                }
            //******* Verify NumeroCompte ***********
            if (propertyName == "CleRib")
            {
                if (string.IsNullOrEmpty(CleRib.Trim()))
                {
                    info.ErrorText = "Le champs [Clé Rib] est obligatoire!";
                    info.ErrorType = ErrorType.Critical;
                    ribValide = false;

                }
                else
                {
                    if (CleRib.Length > 2)
                    {
                        info.ErrorText = "Longeur invalide! [Clé Rib]";
                        info.ErrorType = ErrorType.Critical;
                        ribValide = false;

                    }
                    else
                    {
                        CleRib = CleRib.Trim();
                        if (!regexInt.IsMatch(CleRib))
                        {
                            info.ErrorText = "Type de donnée! [Clé Rib]";
                            info.ErrorType = ErrorType.Critical;
                            ribValide = false;
                        }

                    }
                }
               //if(ribValide)
               // {
               //     var cle = NumeriqueHelper.GetMatriculeCleRib(
               //         string.Format(@"{0}{1}{2}", CodeBanque.PadLeft(2,'0'), CodeGuichet.PadLeft(6,'0'), NumeroCompte.PadLeft(10,'0')));
               //     if (cle != CleRib.PadLeft(2, '0'))
               //     {
               //         info.ErrorText = "Calcul clé invalide! [Cle Rib]";
               //         info.ErrorType = ErrorType.Critical;
               //     }
               // }
            }

            //******* Verify NetAPaye  ********
            if (propertyName == "NetAPaye")
            {
                var montantTvaStr = NetAPayeStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal montantTva;
                if (!decimal.TryParse(montantTvaStr, out montantTva))
                {
                    info.ErrorText = "Format montant invalide [NetAPaye]!";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    if (montantTva < 0)
                    {
                        info.ErrorText = "Montant NetAPaye invalide! ";
                        info.ErrorType = ErrorType.Critical;
                    }
                    if (NetAPayeStr.Length > 15)
                    {
                        info.ErrorText = "Longeur invalide! [NetAPaye]";
                        info.ErrorType = ErrorType.Critical;
                    }
                }
            }

            //******* Verify nom prenom au raison sociale du fournisseur ***********
            if (propertyName == "Motif")
                if (!string.IsNullOrEmpty(Motif) && Motif.Trim().Length > 40)
                {
                    info.ErrorText = "Longeur invalide! [Motif]";
                    info.ErrorType = ErrorType.Critical;
                }
        }


        public void GetError(ErrorInfo info)
        {
            var propertyInfo = new ErrorInfo();
            GetPropertyError("Matricule", propertyInfo);
            if (propertyInfo.ErrorText != "")
                info.ErrorText = "Ligne invalide!";
        }

        public bool IsValide()
        {
            var culture = Thread.CurrentThread.CurrentCulture;
            var decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
            //******* Matricule ***********

            if (string.IsNullOrEmpty(Matricule.Trim()))
                return false;

            if (Matricule.Length > 20)
                return false;


            //******* Nom ***********

            if (string.IsNullOrEmpty(Nom.Trim()))
                return false;

            if (Nom.Length > 20)
                return false;


            //******* Prenom ***********

            if (string.IsNullOrEmpty(Prenom.Trim()))
                return false;

            if (Prenom.Length > 20)
                return false;


            //******* Verify NomBanque ***********

            if (string.IsNullOrEmpty(NomBanque.Trim()))
                return false;

            if (NomBanque.Length > 10)
                return false;


            //******* Verify CodeBanque ***********

            if (string.IsNullOrEmpty(CodeBanque.Trim()))
                return false;

            if (CodeBanque.Length > 2)
                return false;


            //******* Verify CodeGuichet ***********

            if (string.IsNullOrEmpty(CodeGuichet.Trim()))
                return false;

            if (CodeGuichet.Length > 6)
                return false;


            //******* Verify NumeroCompte ***********

            if (string.IsNullOrEmpty(NumeroCompte.Trim()))
                return false;

            if (NumeroCompte.Length > 11)
                return false;


            //******* Verify NumeroCompte ***********

            if (string.IsNullOrEmpty(CleRib.Trim()))
                return false;

            if (CleRib.Length > 2)
                return false;

            //******* Verify NetAPaye  ********

            var montantTvaStr = NetAPayeStr
                .Replace(",", decimalSeparator)
                .Replace(".", decimalSeparator);
            decimal montantTva;
            if (!decimal.TryParse(montantTvaStr, out montantTva))
                return false;

            if (montantTva < 0)
                return false;
            if (NetAPayeStr.Length > 15)
                return false;


            //******* Verify nom prenom au raison sociale du fournisseur ***********

            if (!string.IsNullOrEmpty(Motif) && Motif.Trim().Length > 40)
                return false;

            return true;
        }
    }
}