namespace TVS.Module.Employee.Models.Recap
{
    public interface IEnregistrementAnnexeRecap
    {
    }

    public interface IEnteteAnnexeRecap : IEnregistrementAnnexeRecap
    {
    }

    public interface ILigneAnnexeRecap : IEnregistrementAnnexeRecap
    {
    }

    public interface IPiedAnnexeRecap : IEnregistrementAnnexeRecap
    {
    }

    public class EnteteRecap : IEnteteAnnexeRecap
    {
        [Zone("D000", 3, 1, ZoneType.X)]
        public string TypeEnregistrement { get; set; }

        [Zone("D001", 7, 4, ZoneType.I)]
        public int SocieteMatricule { get; set; }

        [Zone("D002", 1, 11, ZoneType.X)]
        public string SocieteCle { get; set; }

        [Zone("D003", 1, 12, ZoneType.X)]
        public string SocieteCategorie { get; set; }

        [Zone("D004", 3, 13, ZoneType.I)]
        public int SocieteEtablissement { get; set; }

        [Zone("D005", 4, 16, ZoneType.X)]
        public string Exercice { get; set; }

        [Zone("D006", 1, 20, ZoneType.I)]
        public bool IsDecAnnexe1 { get; set; }

        [Zone("D007", 1, 21, ZoneType.I)]
        public bool IsDecAnnexe2 { get; set; }

        [Zone("D008", 1, 22, ZoneType.I)]
        public bool IsDecAnnexe3 { get; set; }

        [Zone("D009", 1, 23, ZoneType.I)]
        public bool IsDecAnnexe4 { get; set; }

        [Zone("D010", 1, 24, ZoneType.I)]
        public bool IsDecAnnexe5 { get; set; }

        [Zone("D011", 1, 25, ZoneType.I)]
        public bool IsDecAnnexe6 { get; set; }

        [Zone("D012", 1, 26, ZoneType.I)]
        public bool IsDecAnnexe7 { get; set; }

        [Zone("D013", 12, 27, ZoneType.Xr)]
        public string ZoneReserve { get; set; }
    }
}