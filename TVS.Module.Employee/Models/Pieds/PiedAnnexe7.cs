namespace TVS.Module.Employee.Models.Pieds
{
    public class PiedAnnexeSept : IPiedAnnexe
    {
        [Zone("T700", 2, 1, ZoneType.X)]
        public string TypeEnregistrement { get; set; }

        [Zone("T706", 222, 19, ZoneType.Xr)]
        public string ZoneReserveA { get; set; }

        [Zone("T707", 15, 241, ZoneType.N)]
        public decimal TotalMontantPayee { get; set; }

        [Zone("T708", 15, 256, ZoneType.N)]
        public decimal TotalRetenuSource { get; set; }

        [Zone("T709", 15, 271, ZoneType.N)]
        public decimal TotalMontantNetServi { get; set; }

        [Zone("T710", 120, 286, ZoneType.Xr)]
        public string ZoneReserveB { get; set; }
    }
}