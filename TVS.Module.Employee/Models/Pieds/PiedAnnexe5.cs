namespace TVS.Module.Employee.Models.Pieds
{
    public class PiedAnnexeCinq : IPiedAnnexe
    {
        [Zone("T500", 2, 1, ZoneType.X)]
        public string TypeEnregistrement { get; set; }

        [Zone("T506", 220, 19, ZoneType.Xr)]
        public string ZoneReserveA { get; set; }

        [Zone("T507", 15, 239, ZoneType.N)]
        public decimal MontantTauxDix { get; set; }

        [Zone("T508", 15, 254, ZoneType.N)]
        public decimal RetenueTauxDix { get; set; }

        [Zone("T509", 15, 269, ZoneType.N)]
        public decimal MontantAutreOperation { get; set; }

        [Zone("T510", 15, 284, ZoneType.N)]
        public decimal RetenusAutreOperation { get; set; }

        [Zone("T511", 15, 299, ZoneType.N)]
        public decimal MontantEtabPublic { get; set; }

        [Zone("T512", 15, 314, ZoneType.N)]
        public decimal RetenueEtabPublic { get; set; }

        [Zone("T513", 15, 329, ZoneType.N)]
        public decimal MontantEtabEtrangere { get; set; }

        [Zone("T514", 15, 344, ZoneType.N)]
        public decimal RetenueEtabEtangere { get; set; }

        [Zone("T515", 15, 359, ZoneType.N)]
        public decimal TotalNetServis { get; set; }

        [Zone("T516", 32, 374, ZoneType.Xr)]
        public string ZoneReserve { get; set; }
    }
}