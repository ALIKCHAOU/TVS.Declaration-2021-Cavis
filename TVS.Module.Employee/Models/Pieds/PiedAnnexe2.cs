namespace TVS.Module.Employee.Models.Pieds
{
    public class PiedAnnexeDeux : IPiedAnnexe
    {
        [Zone("T200", 2, 1, ZoneType.X)]
        public string TypeEnregistrement { get; set; }

        [Zone("T206", 221, 19, ZoneType.Xr)]
        public string ZoneReserveA { get; set; }

        [Zone("T207", 15, 240, ZoneType.N)]
        public decimal HonorairesOperationTelephonique { get; set; }

        [Zone("T208", 15, 255, ZoneType.N)]
        public decimal HonorairesRegimeReel { get; set; }

        [Zone("T209", 15, 270, ZoneType.N)]
        public decimal PresenceActionPartSocial { get; set; }

        [Zone("T210", 15, 285, ZoneType.N)]
        public decimal RemunerationPayee { get; set; }

        [Zone("T211", 15, 300, ZoneType.N)]
        public decimal PlusValueImmobiliere { get; set; }

        [Zone("T212", 15, 315, ZoneType.N)]
        public decimal LoyersDesHotels { get; set; }

        [Zone("T213", 15, 330, ZoneType.N)]
        public decimal RemunerationArtisteCreateur { get; set; }

        [Zone("T214", 15, 345, ZoneType.N)]
        public decimal HonoraireBureauEtudeExportateur { get; set; }

        [Zone("T215", 1, 360, ZoneType.Xr)]
        public string ZoneReserveB { get; set; }

        [Zone("T216", 15, 361, ZoneType.N)]
        public decimal MontantServisOperationExporation { get; set; }

        [Zone("T217", 15, 376, ZoneType.N)]
        public decimal MontantRetenueOperees { get; set; }

        [Zone("T218", 15, 391, ZoneType.N)]
        public decimal TotalNetServis { get; set; }
    }
}