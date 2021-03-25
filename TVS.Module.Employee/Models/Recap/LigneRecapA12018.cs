namespace TVS.Module.Employee.Models.Recap
{
    public class LigneRecapA12018  : ILigneAnnexeRecap 
    {
        // Annexe 1 Exercice 2018  Contribution solicial de solidarite
        public string Name { get; set; }

        public Annexe Annexe { get; set; }

        [Zone("00", 3, 1, ZoneType.X)]
        public string TypeEnregistrement { get; set; }

        //[Zone("01", 15, 4, ZoneType.N)]
        //public decimal TotalAssiette { get; set; }

        [Zone("01", 20, 4, ZoneType.X)]
        public string Taux { get; set; }

        [Zone("02", 15, 24, ZoneType.N)]
        public decimal TotalRetenue { get; set; }

        public int Id { get; }
    }
}