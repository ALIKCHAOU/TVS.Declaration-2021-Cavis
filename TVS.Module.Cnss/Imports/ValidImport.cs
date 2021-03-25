using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using TVS.Core;
using TVS.Core.Enums;
using TVS.Core.Models;
using TVS.Module.Cnss.Imports.Views;

namespace TVS.Module.Cnss.Imports
{
    public class ValidImport
    {
        public static bool Verify(IEnumerable<LigneImportView> lignesImport, DeclarationService service, int trimestre)
        {
            Exercice currentExercice = service.Exercice;
            if (currentExercice == null) throw new ApplicationException("Exercice invalide!");
            List<CategorieCnss> categories = service.CnssService.GetAllCategories().ToList();
            int no = 1;
            foreach (LigneImportView ligne in lignesImport)
            {
                if (ligne.Annee == 0)
                {
                    throw new ApplicationException(string.Format(
                        "L'année est obligatoire! Enregistrement N[{0}]", no));
                }
                if (!ligne.Annee.ToString().Equals(currentExercice.Annee))
                {
                    throw new ApplicationException(string.Format(
                        "L'année invalide! Enregistrement N[{0}]", no));
                }
                //******* Verify CIN ***********
                if (ligne.Cin.Length > 8)
                {
                    throw new ApplicationException(string.Format(
                        "CIN invalide! Enregistrement N[{0}]", no));
                }
                if (ligne.Cin.Length < 8)
                {
                    ligne.Cin = ligne.Cin.Trim().PadLeft(8, '0');
                }

                var rgxCin = new Regex(@"[0-9]{8}");

                if (!rgxCin.IsMatch(ligne.Cin))
                {
                    throw new ApplicationException(string.Format(
                        "CIN invalide! Enregistrement N[{0}]", no));
                }
                //******** Verify Civilite **********
                if (ligne.CiviliteNo < 0 || ligne.CiviliteNo > 2)
                {
                    throw new ApplicationException(string.Format(
                        "Civilité invalide! Enregistrement N[{0}]", no));
                }
                //******* Verify Nom *********
                var regName = new Regex(@"^[a-zA-Z]");
                if (string.IsNullOrEmpty(ligne.Nom) || !regName.IsMatch(ligne.Nom))
                {
                    throw new ApplicationException(string.Format(
                        "Nom invalide! Enregistrement N[{0}]", no));
                }
                //******* Verify Prenom ********
                if (string.IsNullOrEmpty(ligne.Prenom) || !regName.IsMatch(ligne.Prenom))
                {
                    throw new ApplicationException(string.Format(
                        "Prénom invalide! Enregistrement N[{0}]", no));
                }
                //******* Verify Autre nom ********
                if (ligne.AutresNom.Trim() != string.Empty && !regName.IsMatch(ligne.AutresNom))
                {
                    throw new ApplicationException(string.Format(
                        "Autre nom invalide! Enregistrement N[{0}]", no));
                }
                //******* Verify NomJeuneFille ********
                if (!string.IsNullOrEmpty(ligne.NomJeuneFille))
                {
                    if (!regName.IsMatch(ligne.NomJeuneFille))
                        throw new ApplicationException(string.Format(
                            "Nom de jeune fille invalide! Enregistrement N[{0}]", no));
                }
                //******* Verify BrutA ********
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;

                string brutAtStr = ligne.BrutAStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal brutA;
                if (!decimal.TryParse(brutAtStr, out brutA))
                {
                    throw new ApplicationException(string.Format(
                        "Format montant invalide [BrutA]! Enregistrement N[{0}]", no));
                }
                if (brutA < 0)
                {
                    throw new ApplicationException(string.Format(
                        "BrutA invalide! Enregistrement N[{0}]", no));
                }
                //ligne.BrutA = brutA;
                //******* Verify BrutB ********
                string brutBtStr = ligne.BrutBStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal brutB;
                if (!decimal.TryParse(brutBtStr, out brutB))
                {
                    throw new ApplicationException(string.Format(
                        "Format montant invalide [BrutB]! Enregistrement N[{0}]", no));
                }
                if (brutB < 0)
                {
                    throw new ApplicationException(string.Format(
                        "BrutB invalide! Enregistrement N[{0}]", no));
                }
                // ligne.BrutB = brutB;
                //******* Verify BrutC ********
                string brutCtStr = ligne.BrutCStr
                    .Replace(",", decimalSeparator)
                    .Replace(".", decimalSeparator);
                decimal brutC;
                if (!decimal.TryParse(brutCtStr, out brutC))
                {
                    throw new ApplicationException(string.Format(
                        "Format montant invalide [BrutC]! Enregistrement N[{0}]", no));
                }
                if (brutC < 0)
                {
                    throw new ApplicationException(string.Format(
                        "BrutC invalide! Enregistrement N[{0}]", no));
                }
                //ligne.BrutC = brutC;
                //******* Verify Matricule cnss ********
                var regNumero = new Regex(@"^[0-9]");

                if (string.IsNullOrEmpty(ligne.NumeroCnss)
                    || ligne.NumeroCnss.Length > 8
                    || !regNumero.IsMatch(ligne.NumeroCnss))
                {
                    throw new ApplicationException(string.Format(
                        "Numéro Cnss invalide! Enregistrement N[{0}]", no));
                }

                //******* Verify Cle ********

                if (string.IsNullOrEmpty(ligne.CleCnss)
                    || ligne.CleCnss.Length > 2
                    || !regNumero.IsMatch(ligne.CleCnss))
                {
                    throw new ApplicationException(string.Format(
                        "Clé invalide! Enregistrement N[{0}]", no));
                }

                //******* Verify matricule interne ********
                if (string.IsNullOrEmpty(ligne.Matricule)
                    || ligne.Matricule.Length > 10
                    //|| !regNumero.IsMatch(ligne.Matricule)
                    )
                {
                    throw new ApplicationException(string.Format(
                        "Matricule interne invalide! Enregistrement N[{0}]", no));
                }

                //******* Verify Trimestre  ********
                if (ligne.Trimestre != trimestre)
                {
                    throw new ApplicationException(string.Format(
                        "Trimestre invalid! Enregistrement N[{0}]", no));
                }

                //******* Verify Type cnss  ********
                if (ligne.TypeCnss > 19 || ligne.TypeCnss < 0 || categories.All(x => x.No != ligne.TypeCnss))
                {
                    throw new ApplicationException(string.Format(
                        "Type cnss invalid! Enregistrement N[{0}]", no));
                }

                //******* Situation familiale  ********
                if (ligne.SituationFamilleNo > 8 || ligne.SituationFamilleNo < 0)
                {
                    throw new ApplicationException(string.Format(
                        "Situation familiale invalide! Enregistrement N[{0}]", no));
                }
            }
            return true;
        }

        public static void CreateLignes(IEnumerable<LigneImportView> lignesImport,
            DeclarationService service, DeclarationCnss declaration)
        {
            List<CategorieCnss> categories = service.CnssService.GetAllCategories().ToList();
            var _employee = new List<Employee>();
            foreach (LigneImportView ligne in lignesImport)
            {
                if (_employee.Any(x => x.Cin == ligne.Cin))
                    throw new ApplicationException(string.Format("Employee {0} est déclaré deux ou plusieurs fois!"));

                var categorie = categories.Single(x => x.No == ligne.TypeCnss);
                var emp = new Employee
                {
                    AutresNom = ligne.AutresNom,
                    CleCnss = ligne.CleCnss,
                    SituationFamille = (SituationFamille) ligne.SituationFamilleNo,
                    Prenom = ligne.Prenom,
                    Cin = ligne.Cin,
                    Nom = ligne.Nom,
                    Civilite = (Civilite) ligne.CiviliteNo,
                    NumeroInterne = ligne.Matricule,
                    NumeroCnss = ligne.NumeroCnss,
                    NomJeuneFille = ligne.NomJeuneFille,
                    CategorieNo = categorie.No,
                };
                _employee.Add(emp);
            }

            foreach (var employee in _employee)
            {
                service.CnssService.EmployeeCreateOrUpdate(employee.Cin,
                    employee.Nom,
                    employee.Prenom,
                    employee.Civilite,
                    employee.SituationFamille,
                    employee.NumeroCnss,
                    employee.CleCnss,
                    employee.NomJeuneFille,
                    employee.AutresNom,
                    employee.NumeroInterne,
                    categories.Single(x => x.No == employee.CategorieNo));
            }
            foreach (var l in lignesImport)
            {
                service.CnssService.LigneDeclarationCreate(declaration.Id, l.Cin, l.BrutA, l.BrutB, l.BrutC);
            }
        }
    }
}