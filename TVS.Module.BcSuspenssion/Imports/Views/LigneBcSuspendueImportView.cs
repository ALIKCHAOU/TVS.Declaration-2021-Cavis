using System;
using System.Globalization;
using System.Threading;
using DevExpress.XtraEditors.DXErrorProvider;
using TVS.Config.Helpers;

namespace TVS.Module.BcSuspenssion.Imports.Views
{
    public class LigneBcSuspendueImportView : IDXDataErrorInfo
    {
        private string _anneeStr;
        private string _montantTvaStr;
        private string _prixAchatHorsTaxeStr;
        private string _trimestreStr;

        public string NumeroAutorisation { get; set; }

        public string NumeroBonCommande { get; set; }

        public DateTime DateBonCommande { get; set; }

        public string NumeroFacture { get; set; }

        public DateTime DateFacture { get; set; }
        private string _identifiant;
        public string Identifiant
        {
            get { return _identifiant; }
            set
            {
                if (value == null)
                {
                    _identifiant = string.Empty;
                    return;
                }
                if (value.Length < 13)
                {
                    _identifiant = value.PadLeft(13, '0');
                    return;
                }
                _identifiant = value;
                ;
            }
        }

        public string RaisonSocialFournisseur { get; set; }

        public string ObjetFacture { get; set; }

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

        public string PrixAchatHorsTaxeStr
        {
            get
            {
                if (_prixAchatHorsTaxeStr == null) return "0";
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string prixAchatHorsTaxeStr = _prixAchatHorsTaxeStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                return prixAchatHorsTaxeStr.Trim();
            }
            set { _prixAchatHorsTaxeStr = string.IsNullOrEmpty(value) ? "0" : value; }
        }

        public decimal PrixAchatHorsTaxeMontantTva
        {
            get
            {
                if (_prixAchatHorsTaxeStr == null) return 0;
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string prixAchatHorsTaxeStr = _prixAchatHorsTaxeStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal result;
                return !Decimal.TryParse(prixAchatHorsTaxeStr, out result) ? 0 : result;
            }
        }

        public string MontantTvaStr
        {
            get
            {
                if (_montantTvaStr == null) return "0";
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string montantTvaStr = _montantTvaStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                return montantTvaStr.Trim();
            }
            set { _montantTvaStr = string.IsNullOrEmpty(value) ? "0" : value; }
        }

        public decimal MontantTva
        {
            get
            {
                if (_montantTvaStr == null) return 0;
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string brutAtStr = _montantTvaStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal result;
                return !Decimal.TryParse(brutAtStr, out result) ? 0 : result;
            }
        }

        public void GetPropertyError(string propertyName, ErrorInfo info)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
            //******* Verify Numero autorisation ***********
            if (propertyName == "NumeroAutorisation")
            {
                if (string.IsNullOrEmpty(NumeroAutorisation.Trim()))
                {
                    info.ErrorText = "Le champs [Numéro autorisation] est obligatoire!";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    if (NumeroAutorisation.Length > 30)
                    {
                        info.ErrorText = "Longeur invalide! [Numéro autorisation]";
                        info.ErrorType = ErrorType.Critical;
                    }
                }
            }

            //******* Verify Numero bon de commande ***********
            if (propertyName == "NumeroBonCommande")
            {
                if (string.IsNullOrEmpty(NumeroBonCommande.Trim()))
                {
                    info.ErrorText = "Le champs [Numéro bon de commande] est obligatoire!";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    if (NumeroBonCommande.Length > 13)
                    {
                        info.ErrorText = "Longeur invalide! [Numéro bon de commande]";
                        info.ErrorType = ErrorType.Critical;
                    }

                }
            }

            //******* Verify Numero facture ***********
            if (propertyName == "NumeroFacture")
            {
                if (string.IsNullOrEmpty(NumeroFacture.Trim()))
                {
                    info.ErrorText = "Le champs [Numéro facture] est obligatoire!";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    if (NumeroFacture.Length > 30)
                    {
                        info.ErrorText = "Longeur invalide! [Numéro facture]";
                        info.ErrorType = ErrorType.Critical;
                    }
                }
            }

            //******* Verify Numero identifiant ***********
            if (propertyName == "Identifiant")
            {
                if (string.IsNullOrEmpty(Identifiant.Trim()))
                {
                    info.ErrorText = "Le champs [Identifiant] est obligatoire!";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    if (Identifiant.Length != 13)
                    {
                        info.ErrorText = "Longeur invalide! [Identifiant]";
                        info.ErrorType = ErrorType.Critical;
                    }
                    else
                    {
                        var valid = NumeriqueHelper.ValiderMatricule(Identifiant);
                        if(!valid)
                        {
                            info.ErrorText = "Matricule invalide! [Identifiant]";
                            info.ErrorType = ErrorType.Critical;
                        }
                    }
                }
            }

            //******* Verify Prix achat hors taxe  ********
            if (propertyName == "PrixAchatHorsTaxeStr")
            {
                string prixAchatStr = PrixAchatHorsTaxeStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal prixAchat;
                if (!decimal.TryParse(prixAchatStr, out prixAchat))
                {
                    info.ErrorText = "Format montant invalide [Prix achat hors taxe]!";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    if (prixAchat < 0)
                    {
                        info.ErrorText = "Prix achat hors taxe est invalide! ";
                        info.ErrorType = ErrorType.Critical;
                    }
                    if (PrixAchatHorsTaxeStr.Length > 15)
                    {
                        info.ErrorText = "Longeur invalide! [Prix d'achat]";
                        info.ErrorType = ErrorType.Critical;
                    }
                }
            }

            //******* Verify montant tva  ********
            if (propertyName == "MontantTvaStr")
            {
                string montantTvaStr = MontantTvaStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal montantTva;
                if (!decimal.TryParse(montantTvaStr, out montantTva))
                {
                    info.ErrorText = "Format montant invalide [Montant TVA]!";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    if (montantTva < 0)
                    {
                        info.ErrorText = "Montant TVA invalide! ";
                        info.ErrorType = ErrorType.Critical;
                    }
                    if (MontantTvaStr.Length > 15)
                    {
                        info.ErrorText = "Longeur invalide! [Montant TVA]";
                        info.ErrorType = ErrorType.Critical;
                    }
                }
            }

            //******* Verify nom prenom au raison sociale du fournisseur ***********
            if (propertyName == "RaisonSocialFournisseur")
            {
                if (string.IsNullOrEmpty(RaisonSocialFournisseur.Trim()))
                {
                    info.ErrorText = "Le champs [RaisonSocialFournisseur] est obligatoire!";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    if (RaisonSocialFournisseur.Length > 40)
                    {
                        info.ErrorText = "Longeur invalide! [Raison social fournisseur]";
                        info.ErrorType = ErrorType.Critical;
                    }
                }
            }

            //******* Verify objet facture***********
            if (propertyName == "ObjetFacture")
            {
                if (ObjetFacture.Length > 320)
                {
                    info.ErrorText = "Longueur inavalide! [ObjetFacture]";
                    info.ErrorType = ErrorType.Critical;
                }
            }
        }

        public void GetError(ErrorInfo info)
        {
            var propertyInfo = new ErrorInfo();
            GetPropertyError("NumeroBonCommande", propertyInfo);
            if (propertyInfo.ErrorText != "")
            {
                info.ErrorText = "Ligne invalide!";
            }
        }

        public bool IsValide()
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
            //******* Verify Numero autorisation ***********

            if (string.IsNullOrEmpty(NumeroAutorisation.Trim()))
            {
                return false;
            }

            if (NumeroAutorisation.Length > 30)
            {
                return false;
            }

            //******* Verify Numero bon de commande ***********

            if (string.IsNullOrEmpty(NumeroBonCommande.Trim()))
            {
                return false;
            }

            if (NumeroBonCommande.Length > 13)
            {
                return false;
            }

            //******* Verify Numero facture ***********

            if (string.IsNullOrEmpty(NumeroFacture.Trim()))
            {
                return false;
            }

            if (NumeroFacture.Length > 30)
            {
                return false;
            }

            //******* Verify Numero identifiant ***********

            if (string.IsNullOrEmpty(Identifiant.Trim()))
            {
                return false;
            }

            if (Identifiant.Length != 13)
            {
                return false;
            }

            //******* Verify Prix achat hors taxe  ********

            string prixAchatStr = PrixAchatHorsTaxeStr
                .Replace(",", decimalSeparator)
                .Replace(".", decimalSeparator);
            decimal prixAchat;
            if (!decimal.TryParse(prixAchatStr, out prixAchat))
            {
                return false;
            }

            if (prixAchat < 0)
            {
                return false;
            }
            if (PrixAchatHorsTaxeStr.Length > 15)
            {
                return false;
            }

            //******* Verify montant tva  ********

            string montantTvaStr = MontantTvaStr
                .Replace(",", decimalSeparator)
                .Replace(".", decimalSeparator);
            decimal montantTva;
            if (!decimal.TryParse(montantTvaStr, out montantTva))
            {
                return false;
            }

            if (montantTva < 0)
            {
                return false;
            }
            if (MontantTvaStr.Length > 15)
            {
                return false;
            }

            //******* Verify nom prenom au raison sociale du fournisseur ***********
            if (string.IsNullOrEmpty(RaisonSocialFournisseur.Trim()))
            {
                return false;
            }

            if (RaisonSocialFournisseur.Length > 40)
            {
                return false;
            }

            //******* Verify objet facture***********
            if (ObjetFacture.Length > 320)
            {
                return false;
            }

            //******* Verify Trimestre ***********

            int trimestre;
            if (!int.TryParse(TrimestreStr, out trimestre))
            {
                return false;
            }
            if (trimestre < 0 || trimestre > 4)
            {
                return false;
            }

            //******* Verify Annee ***********

            int annee;
            if (!int.TryParse(AnneeStr, out annee))
            {
                return false;
            }

            if (annee < 2000 || annee > 2100)
            {
                return false;
            }

            return true;
        }
    }
}