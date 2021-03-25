using TVS.Core.Enums;

namespace TVS.Core.Models
{
    public class LigneImport
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
    }
}