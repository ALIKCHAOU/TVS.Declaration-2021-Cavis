using TVS.Module.Employee.Models.Enums;

namespace TVS.Module.Employee.Models
{
    public class EnteteAnnexe : IEnteteAnnexe
    {
        [Zone("E000", 2, 1, ZoneType.X)]
        public string TypeEnregistrement { get; set; }

        [Zone("E001", 7, 3, ZoneType.I)]
        public int SocieteMatricule { get; set; }

        [Zone("E002", 1, 10, ZoneType.X)]
        public string SocieteCle { get; set; }

        [Zone("E003", 1, 11, ZoneType.X)]
        public string SocieteCategorie { get; set; }

        [Zone("E004", 3, 12, ZoneType.I)]
        public int SocieteNumeroEtablissement { get; set; }

        [Zone("E005", 4, 15, ZoneType.X)]
        public string Exercice { get; set; }

        [Zone("E006", 3, 19, ZoneType.X)]
        public string TypeDocument { get; set; }

        [Zone("E007", 1, 22, ZoneType.E)]
        public CodeActe CodeActe { get; set; }

        [Zone("E008", 6, 23, ZoneType.I)]
        public int TotalBeneficiaire { get; set; }

        [Zone("E009", 40, 29, ZoneType.X)]
        public string SocieteRaisonSocial { get; set; }

        [Zone("E010", 40, 69, ZoneType.X)]
        public string SocieteActivite { get; set; }

        [Zone("E011", 40, 109, ZoneType.X)]
        public string SocieteVille { get; set; }

        [Zone("E012", 72, 149, ZoneType.X)]
        public string SocieteRue { get; set; }

        [Zone("E013", 4, 221, ZoneType.I)]
        public int SocieteNumero { get; set; }

        [Zone("E014", 4, 225, ZoneType.I)]
        public int SocieteCodePostal { get; set; }

        [Zone("E015", 177, 229, ZoneType.Xr)]
        public string ZoneReserve { get; set; }
    }
}