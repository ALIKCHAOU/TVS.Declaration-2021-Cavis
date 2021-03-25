using TVS.Core.Enums;

namespace TVS.Module.Cnss.UiCnss.Views
{
    public class LigneView
    {
        public int No { get; set; }

        public int? Page { get; set; }

        public int? Ligne { get; set; }

        public decimal Brut1 { get; set; }

        public decimal Brut2 { get; set; }

        public decimal Brut3 { get; set; }

        public decimal Total
        {
            get { return Brut1 + Brut2 + Brut3; }
        }

        public int EmployeeNo { get; set; }

        public int DeclarationNo { get; set; }

        public int CategorieNo { get; set; }

        public int? LigneGeneratedNo { get; set; }

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
    }
}