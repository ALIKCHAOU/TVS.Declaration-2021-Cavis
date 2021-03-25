namespace TVS.Module.Employee.Models.Pieds
{
    public class PiedAnnexeTrois : IPiedAnnexe
    {
        [Zone("T300", 2, 1, ZoneType.X)]
        public string TypeEnregistrement { get; set; }

        [Zone("T306", 220, 19, ZoneType.Xr)]
        public string ZoneReserveA { get; set; }

        [Zone("T307", 15, 239, ZoneType.N)]
        public decimal TotalCompteSpeciaux { get; set; }

        [Zone("T308", 15, 254, ZoneType.N)]
        public decimal TotalAutreCapitauxMobilier { get; set; }

        [Zone("T309", 15, 269, ZoneType.N)]
        public decimal TotalPretEtbBancaire { get; set; }

        [Zone("T310", 15, 284, ZoneType.N)]
        public decimal TotalRetenueOperee { get; set; }

        [Zone("T311", 15, 299, ZoneType.N)]
        public decimal TotalNetServi { get; set; }

        [Zone("T312", 92, 314, ZoneType.Xr)]
        public string ZoneReserveB { get; set; }
    }
}