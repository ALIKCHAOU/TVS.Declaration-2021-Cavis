using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Enums;
using TVS.Core.Helpers;

namespace TVS.Core.Models
{
    public class LigneCnss
    {
        public int Id { get; set; }

        public int? Page { get; set; }

        public int? Ligne { get; set; }

        public decimal Brut1 { get; set; }

        public decimal Brut2 { get; set; }

        public decimal Brut3 { get; set; }

        public int EmployeeNo { get; set; }

        public int DeclarationNo { get; set; }

        public int CategorieNo { get; set; }

        public int SocieteNo { get; set; }

        #region redendance

        public string CleCnss { get; set; }

        public string NumeroCnss { get; set; }

        public string Cin { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string AutresNom { get; set; }

        public string NomJeuneFille { get; set; }

        public string CodeExploitation { get; set; }

        public Civilite Civilite { get; set; }

        public string NumeroInterne { get; set; }

        #endregion redendance

        public string GetToString(Societe societe, DeclarationCnss declaration, Exercice exercice)
        {
            if (societe == null || declaration == null || exercice == null) return string.Empty;
            string result = string.Empty;
            result += societe.NumeroEmployeur.PadLeft(8, '0');
            result += societe.CleEmployeur.PadLeft(2, '0');
            result += CodeExploitation.PadLeft(4, '0');
            result += declaration.Trimestre.ToString().PadLeft(1);
            result += exercice.Annee.PadLeft(4, '0');
            result += Page.ToString().PadLeft(3, '0');
            result += Ligne.ToString().PadLeft(2, '0');
            result += NumeroCnss.PadLeft(8, '0');
            result += CleCnss.PadLeft(2, '0');
            string identite = (Prenom.Trim() + " " + AutresNom.Trim() + " " + Nom.Trim() + " " + NomJeuneFille.Trim());
            result += Helper.StrTr(identite.PadRight(60)).ToUpper();
            result += Cin.PadLeft(8, '0');
            decimal total = Brut1 + Brut2 + Brut3;
            result += ((double) (total*1000)).ToString("0").PadLeft(10, '0');
            result += string.Empty.PadLeft(10, '0');

            if (result.Length != 122)
            {
                throw new InvalidOperationException(
                    "Le nombre de caractère est invalide! Année [" + exercice + "] Trimestre " +
                    declaration.Trimestre);
            }

            return result;
        }
    }
}