namespace TVS.Module.Employee.Models
{
    public class SharedDetailAnnexe
    {
        [Zone("S001", 7, 3, ZoneType.I)]
        public int SocieteMatricule { get; set; }

        [Zone("S002", 1, 10, ZoneType.X)]
        public string SocieteCle { get; set; }

        [Zone("S003", 1, 11, ZoneType.X)]
        public string SocieteCategorie { get; set; }

        [Zone("S004", 3, 12, ZoneType.I)]
        public int SocieteNumeroEtablissement { get; set; }

        [Zone("S005", 4, 15, ZoneType.X)]
        public string Exercice { get; set; }
    }
}