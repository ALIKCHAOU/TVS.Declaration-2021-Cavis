namespace TVS.Module.Employee.Models.Pieds
{
    public class PiedAnnexeSix : IPiedAnnexe
    {
        [Zone("T600", 2, 1, ZoneType.X)]
        public string TypeEnregistrement { get; set; }

        [Zone("T606", 220, 19, ZoneType.Xr)]
        public string ZoneReserveA { get; set; }

        [Zone("T607", 15, 239, ZoneType.N)]
        public decimal TotalRistournes { get; set; }

        [Zone("T608", 15, 254, ZoneType.N)]
        public decimal TotalVentes { get; set; }

        [Zone("T609", 15, 269, ZoneType.N)]
        public decimal TotalAvances { get; set; }

        [Zone("T610", 15, 284, ZoneType.N)]
        public decimal TotalRevenuJeuPari { get; set; }

        [Zone("T611", 15, 299, ZoneType.N)]
        public decimal TotalRetenuJeuPari { get; set; }

        [Zone("T612", 15, 314, ZoneType.N)]
        public decimal TotalVenteNeDepassantVingt { get; set; }

        [Zone("T613", 15, 329, ZoneType.N)]
        public decimal TotalRetenuNeDepassantVingt { get; set; }

        [Zone("T614", 15, 344, ZoneType.N)]
        public decimal MontantServicesRendus { get; set; }

        [Zone("T615", 47, 359, ZoneType.Xr)]
        public string ZoneReserveB { get; set; }
    }
}