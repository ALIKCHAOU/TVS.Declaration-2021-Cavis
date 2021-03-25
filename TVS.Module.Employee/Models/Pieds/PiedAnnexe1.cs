namespace TVS.Module.Employee.Models.Pieds
{
    public class PiedAnnexeUn : IPiedAnnexe
    {
        [Zone("T100", 2, 1, ZoneType.X)]
        public string TypeEnregistrement { get; set; }

        [Zone("T106", 242, 19, ZoneType.Xr)]
        public string ZoneReserveA { get; set; }

        [Zone("T107", 15, 261, ZoneType.N)]
        public decimal TotalRevenuImposable { get; set; }

        [Zone("T108", 15, 276, ZoneType.N)]
        public decimal TotalAventageNature { get; set; }

        [Zone("T109", 15, 291, ZoneType.N)]
        public decimal TotalRevenuBrutImposable { get; set; }

        [Zone("T110", 15, 306, ZoneType.N)]
        public decimal TotalRevenuReinvesti { get; set; }

        [Zone("T111", 15, 321, ZoneType.N)]
        public decimal TotalRetenuRegimeCommun { get; set; }

        [Zone("T112", 15, 336, ZoneType.N)]
        public decimal TotalRetenueTauxVingt { get; set; }

        [Zone("T113", 15, 351, ZoneType.N)]
        public decimal TotalNetServi { get; set; }

        [Zone("T114", 40, 366, ZoneType.Xr)]
        public string ZoneReserveB { get; set; }

        //[Zone("T115", 15, 351, ZoneType.N)]
        public decimal TotalContributionSocialeSolidarite { get; set; }
    }
}