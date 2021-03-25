using System;
using System.Globalization;
using System.Threading;
using DevExpress.XtraEditors.DXErrorProvider;
using TVS.Core.Enums;

namespace TVS.Module.FactureSuspenssion.Imports.Views
{
    public class LigneImportView : IDXDataErrorInfo
    {
        private string _trimestreStr;
        private string _anneeStr;
        private string _prixVenteHtStr;
        private string _tauxFodecStr;
        private string _montantFodecStr;
        private string _tauxDroitConsommationStr;
        private string _montantDroitConsommationStr;
        private string _tauxTvaStr;
        private string _montantTvaStr;

        public int NumeroOrdre { get; set; }

        public string NumeroFacture { get; set; }

        public DateTime DateFacture { get; set; }

        public TypeClient TypeClient { get; set; }

        public string IdentifiantClient { get; set; }

        public string NomPrenomClient { get; set; }

        public string AdresseClient { get; set; }

        public string NumeroAutorisation { get; set; }

        public DateTime DateAutorisation { get; set; }

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

        public string PrixVenteHtStr
        {
            get
            {
                if (_prixVenteHtStr == null) return "0";
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string montantTvaStr = _prixVenteHtStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                return montantTvaStr.Trim();
            }
            set { _prixVenteHtStr = string.IsNullOrEmpty(value) ? "0" : value; }
        }

        public decimal PrixVenteHt
        {
            get
            {
                if (_prixVenteHtStr == null) return 0;
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string taux = _prixVenteHtStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal result;
                return !Decimal.TryParse(taux, out result) ? 0 : result;
            }
        }

        public string TauxFodecStr
        {
            get
            {
                if (_tauxFodecStr == null) return "0";
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string montantTvaStr = _tauxFodecStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                return montantTvaStr.Trim();
            }
            set { _tauxFodecStr = string.IsNullOrEmpty(value) ? "0" : value; }
        }

        public decimal TauxFodec
        {
            get
            {
                if (_tauxFodecStr == null) return 0;
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string taux = _tauxFodecStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal result;
                return !Decimal.TryParse(taux, out result) ? 0 : result;
            }
        }

        public string MontantFodecStr
        {
            get
            {
                if (_montantFodecStr == null) return "0";
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string montantTvaStr = _montantFodecStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                return montantTvaStr.Trim();
            }
            set { _montantFodecStr = string.IsNullOrEmpty(value) ? "0" : value; }
        }

        public decimal MontantFodec
        {
            get
            {
                if (_montantFodecStr == null) return 0;
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string taux = _montantFodecStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal result;
                return !Decimal.TryParse(taux, out result) ? 0 : result;
            }
        }

        public string TauxDroitConsommationStr
        {
            get
            {
                if (_tauxDroitConsommationStr == null) return "0";
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string montantTvaStr = _tauxDroitConsommationStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                return montantTvaStr.Trim();
            }
            set { _tauxDroitConsommationStr = string.IsNullOrEmpty(value) ? "0" : value; }
        }

        public decimal TauxDroitConsommation
        {
            get
            {
                if (_tauxDroitConsommationStr == null) return 0;
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string taux = _tauxDroitConsommationStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal result;
                return !Decimal.TryParse(taux, out result) ? 0 : result;
            }
        }

        public string MontantDroitConsommationStr
        {
            get
            {
                if (_montantDroitConsommationStr == null) return "0";
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string montantTvaStr = _montantDroitConsommationStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                return montantTvaStr.Trim();
            }
            set { _montantDroitConsommationStr = string.IsNullOrEmpty(value) ? "0" : value; }
        }

        public decimal MontantDroitConsommation
        {
            get
            {
                if (_montantDroitConsommationStr == null) return 0;
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string taux = _montantDroitConsommationStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal result;
                return !Decimal.TryParse(taux, out result) ? 0 : result;
            }
        }

        public string TauxTvaStr
        {
            get
            {
                if (_tauxTvaStr == null) return "0";
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string montantTvaStr = _tauxTvaStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                return montantTvaStr.Trim();
            }
            set { _tauxTvaStr = string.IsNullOrEmpty(value) ? "0" : value; }
        }

        public decimal TauxTva
        {
            get
            {
                if (_tauxTvaStr == null) return 0;
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string taux = _tauxTvaStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal result;
                return !Decimal.TryParse(taux, out result) ? 0 : result;
            }
        }

        public string MontantTvaStr
        {
            get
            {
                if (_montantTvaStr == null) return "0";
                var culture = Thread.CurrentThread.CurrentCulture;
                var decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                var montantTvaStr = _montantTvaStr
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
                var culture = Thread.CurrentThread.CurrentCulture;
                var decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                var brutAtStr = _montantTvaStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal result;
                return !Decimal.TryParse(brutAtStr, out result) ? 0 : result;
            }
        }

        public void GetPropertyError(string propertyName, ErrorInfo info)
        {
            var culture = Thread.CurrentThread.CurrentCulture;
            var decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

            //******* Verify Numero autorisation ***********
            if (propertyName == "NumeroAutorisation")
            {
                if (string.IsNullOrEmpty(NumeroAutorisation.Trim()))
                {
                    SetErreur(info, "Le champs [Numéro autorisation] est obligatoire!");
                }
                else
                {
                    if (NumeroAutorisation.Length > 20)
                    {
                        SetErreur(info, "Longeur invalide! [Numéro autorisation]");
                    }
                }
            }

            //******* Verify type identifiant client ******
            if (propertyName == "TypeClient")
            {
                if (((int) TypeClient) < 1 || ((int) TypeClient) > 4)
                {
                    SetErreur(info, "Type identifiant client invalide!");
                }
            }

            //******* Verify Numero facture ***********
            if (propertyName == "NumeroFacture")
            {
                if (string.IsNullOrEmpty(NumeroFacture.Trim()))
                {
                    SetErreur(info, "Le champs [Numéro facture] est obligatoire!");
                }
                else
                {
                    if (NumeroFacture.Length > 20)
                    {
                        SetErreur(info, "Longeur invalide! [Numéro facture]");
                    }
                }
            }

            //******* Verify Numero identifiant ***********
            if (propertyName == "IdentifiantClient")
            {
                if (string.IsNullOrEmpty(IdentifiantClient.Trim()))
                {
                    SetErreur(info, "Le champs [Identifiant Client] est obligatoire!");
                }
                else
                {
                    if (IdentifiantClient.Length > 13)
                    {
                        SetErreur(info, "Longeur invalide! [Identifiant Client]");
                    }
                }
            }
            //******* Verify nom prenom du client ***********
            if (propertyName == "NomPrenomClient")
            {
                if (string.IsNullOrEmpty(NomPrenomClient.Trim()))
                {
                    SetErreur(info, "Le champs [Nom Prenom Client] est obligatoire!");
                }
                else
                {
                    if (NomPrenomClient.Length > 40)
                    {
                        SetErreur(info, "Longeur invalide! [Nom Prenom Client]");
                    }
                }
            }
            //******* Verify Numero AdresseClient ***********
            if (propertyName == "AdresseClient")
            {
                if (string.IsNullOrEmpty(AdresseClient.Trim()))
                {
                    SetErreur(info, "Le champs [Adresse Client] est obligatoire!");
                }
                else
                {
                    if (AdresseClient.Length > 120)
                    {
                        SetErreur(info, "Longeur invalide! [AdresseClient]");
                    }
                }
            }
            //******* Verify Prix achat hors taxe  ********
            if (propertyName == "PrixVenteHtStr")
            {
                var prixVenteStr = PrixVenteHtStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal prixVente;
                if (!decimal.TryParse(prixVenteStr, out prixVente))
                {
                    SetErreur(info, "Format montant invalide [Prix de vente hors taxe]!");
                }
                else
                {
                    if (prixVente < 0)
                    {
                        SetErreur(info, "Prix de vente hors taxe est invalide! ");
                    }
                    if (PrixVenteHtStr.Length > 16)
                    {
                        SetErreur(info, "Longeur invalide! [Prix de vente]");
                    }
                }
            }
            //******* Verify  TauxFodecStr ********
            if (propertyName == "TauxFodecStr")
            {
                var tauxFodecStr = TauxFodecStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal tauxFodec;
                if (!decimal.TryParse(tauxFodecStr, out tauxFodec))
                {
                    SetErreur(info, "Format montant invalide [Taux fodec]!");
                }
                else
                {
                    if (tauxFodec < 0 || tauxFodec > 1)
                    {
                        SetErreur(info, "Taux Fodec est invalide! ");
                    }
                    if (TauxFodecStr.Length > 6)
                    {
                        SetErreur(info, "Longeur invalide! [Taux fodec]");
                    }
                }
            }

            //******* Verify  MontantFodecStr  ********
            if (propertyName == "MontantFodecStr")
            {
                var montantFodecStr = MontantFodecStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal montantFodec;
                if (!decimal.TryParse(montantFodecStr, out montantFodec))
                {
                    SetErreur(info, "Format montant invalide [Montant fodec]!");
                }
                else
                {
                    if (montantFodec < 0)
                    {
                        SetErreur(info, "Montant fodec est invalide! ");
                    }
                    if (MontantFodecStr.Length > 15)
                    {
                        SetErreur(info, "Longeur invalide! [Montant fodec]");
                    }
                }
            }

            //******* Verify TauxDroitConsommationStr  ********
            if (propertyName == "TauxDroitConsommationStr")
            {
                var tauxDroitConsommationStr = TauxDroitConsommationStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal tauxDroitConsommation;
                if (!decimal.TryParse(tauxDroitConsommationStr, out tauxDroitConsommation))
                {
                    SetErreur(info, "Format montant invalide [Taux droit de consommation]!");
                }
                else
                {
                    if (tauxDroitConsommation < 0 || tauxDroitConsommation > 1)
                    {
                        SetErreur(info, "Taux droit de consommation est invalide! ");
                    }
                    if (TauxDroitConsommationStr.Length > 15)
                    {
                        SetErreur(info, "Longeur invalide! [Taux droit de consommation]");
                    }
                }
            }

            //******* Verify TauxDroitConsommation  ********
            if (propertyName == "MontantDroitConsommationStr")
            {
                var montantDroitConsommationStr = MontantDroitConsommationStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal montantDroitConsommation;
                if (!decimal.TryParse(montantDroitConsommationStr, out montantDroitConsommation))
                {
                    SetErreur(info, "Format montant invalide [Montant droit de Consommation]!");
                }
                else
                {
                    if (montantDroitConsommation < 0)
                    {
                        SetErreur(info, "Montant droit de consommation est invalide! ");
                    }
                    if (MontantDroitConsommationStr.Length > 16)
                    {
                        SetErreur(info, "Longeur invalide! [Montant droit de Consommation]");
                    }
                }
            }

            //******* Verify Taux Tva  ********
            if (propertyName == "TauxTvaStr")
            {
                var tauxTvaStr = TauxTvaStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal tauxTva;
                if (!decimal.TryParse(tauxTvaStr, out tauxTva))
                {
                    SetErreur(info, "Format montant invalide [TauxTvaStr]!");
                }
                else
                {
                    if (tauxTva < 0 || tauxTva > 1)
                    {
                        SetErreur(info, "Taux tva est invalide! ");
                    }
                    if (TauxTvaStr.Length > 6)
                    {
                        SetErreur(info, "Longeur invalide! [TauxTvaStr]");
                    }
                }
            }

            //******* Verify MontantTva  ********
            if (propertyName == "MontantTvaStr")
            {
                var montantTvaStr = MontantTvaStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal montantTva;
                if (!decimal.TryParse(montantTvaStr, out montantTva))
                {
                    info.ErrorText = "Format montant invalide [Montant Tva]!";
                    info.ErrorType = ErrorType.Critical;
                }
                else
                {
                    if (montantTva < 0)
                    {
                        SetErreur(info, "Montant tva est invalide! ");
                    }
                    if (MontantTvaStr.Length > 15)
                    {
                        SetErreur(info, "Longeur invalide! [Montant Tva]");
                    }
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

            if (string.IsNullOrEmpty(NumeroAutorisation.Trim()) || (NumeroAutorisation.Length > 30))
            {
                return false;
            }

            //******* Verify Numero facture ***********

            if (string.IsNullOrEmpty(NumeroFacture.Trim()) || (NumeroFacture.Length > 30))
            {
                return false;
            }

            //******* Verify Numero identifiant ***********

            if (string.IsNullOrEmpty(IdentifiantClient.Trim()) || (IdentifiantClient.Length > 13))
            {
                return false;
            }
            //******* Verify Numero NomPrenomClient ***********
            if (string.IsNullOrEmpty(NomPrenomClient.Trim()) || (IdentifiantClient.Length > 13))
            {
                return false;
            }
            //******* Verify Numero AdresseClient ***********

            if (string.IsNullOrEmpty(AdresseClient.Trim()) || IdentifiantClient.Length > 13)
            {
                return false;
            }

            //******* Verify Prix achat hors taxe  ********

            string prixVentStr = PrixVenteHtStr
                .Replace(",", decimalSeparator)
                .Replace(".", decimalSeparator);
            decimal prixVente;
            if (!decimal.TryParse(prixVentStr, out prixVente))
            {
                return false;
            }

            if (prixVente < 0 || PrixVenteHtStr.Length > 16)
            {
                return false;
            }

            //******* Verify  TauxFodecStr ********

            string tauxFodecStr = TauxFodecStr
                .Replace(",", decimalSeparator)
                .Replace(".", decimalSeparator);
            decimal tauxFodec;
            if (!decimal.TryParse(tauxFodecStr, out tauxFodec))
            {
                return false;
            }

            if (tauxFodec < 0 || TauxFodecStr.Length > 6)
            {
                return false;
            }

            //******* Verify  MontantFodecStr  ********

            string montantFodecStr = MontantFodecStr
                .Replace(",", decimalSeparator)
                .Replace(".", decimalSeparator);
            decimal montantFodec;
            if (!decimal.TryParse(montantFodecStr, out montantFodec))
            {
                return false;
            }

            if (montantFodec < 0 || MontantFodecStr.Length > 15)
            {
                return false;
            }

            //******* Verify TauxDroitConsommationStr  ********

            string tauxConsommationStr = TauxDroitConsommationStr
                .Replace(",", decimalSeparator)
                .Replace(".", decimalSeparator);
            decimal tauxConsommation;
            if (!decimal.TryParse(tauxConsommationStr, out tauxConsommation))
            {
                return false;
            }

            if (tauxConsommation < 0 || TauxDroitConsommationStr.Length > 15)
            {
                return false;
            }

            //******* Verify TauxDroitConsommation  ********
            string montantConsommationStr = MontantDroitConsommationStr
                .Replace(",", decimalSeparator)
                .Replace(".", decimalSeparator);
            decimal montantConsommation;
            if (!decimal.TryParse(montantConsommationStr, out montantConsommation))
            {
                return false;
            }
            if (montantConsommation < 0 || MontantDroitConsommationStr.Length > 16)
            {
                return false;
            }

            //******* Verify Taux Tva  ********
            string tauxTvaStr = TauxTvaStr
                .Replace(",", decimalSeparator)
                .Replace(".", decimalSeparator);
            decimal tauxTva;
            if (!decimal.TryParse(tauxTvaStr, out tauxTva))
            {
                return false;
            }

            if (tauxTva < 0 || TauxTvaStr.Length > 15)
            {
                return false;
            }
            //******* Verify MontantTva  ********

            string montantTvaStr = MontantTvaStr
                .Replace(",", decimalSeparator)
                .Replace(".", decimalSeparator);
            decimal montantTva;
            if (!decimal.TryParse(montantTvaStr, out montantTva))
            {
                return false;
            }
            if (montantTva < 0 || MontantTvaStr.Length > 15)
            {
                return false;
            }
            return true;
        }

        private void SetErreur(ErrorInfo info, string message)
        {
            info.ErrorText = message;
            info.ErrorType = ErrorType.Critical;
        }
    }
}