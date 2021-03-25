namespace TVS.Module.Employee.Models.Recap
{
    public class LigneRecap : ILigneAnnexeRecap
    {
        public string Name { get; set; }

        public Annexe Annexe { get; set; }

        [Zone("00", 3, 1, ZoneType.X)]
        public string TypeEnregistrement { get; set; }

        [Zone("01", 15, 4, ZoneType.N)]
        public decimal TotalAssiette { get; set; }

        [Zone("02", 5, 19, ZoneType.I)]
        public int Taux { get; set; }

        [Zone("03", 15, 24, ZoneType.N)]
        public decimal TotalRetenue { get; set; }

        public int Id { get; }
        //       

        //[Zone("01", 15, 4, ZoneType.N)]
        //public decimal TotalAssiette { get; set; }

        //[Zone("04", 0, 0, ZoneType.S)]
        public string Taux2018A1 { get; set; }

        //[Zone("02", 15, 24, ZoneType.N)]
        //public decimal TotalRetenue { get; set; }

       
    }
}