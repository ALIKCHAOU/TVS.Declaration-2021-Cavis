namespace TVS.Module.Employee.Models.Pieds
{
    public class PiedAnnexeQuatre : IPiedAnnexe
    {
        [Zone("T400", 2, 1, ZoneType.X)]
        public string TypeEnregistrement { get; set; }

        [Zone("T406", 221, 19, ZoneType.Xr)]
        public string ZoneReserveA { get; set; }

        [Zone("T407", 5, 240, ZoneType.Nr)]
        public string ZoneReserveB { get; set; }

        [Zone("T408", 15, 245, ZoneType.N)]
        public decimal TotalHonoraireNonDepotExistence { get; set; }

        [Zone("T409", 5, 260, ZoneType.Nr)]
        public string ZoneReserveC { get; set; }

        [Zone("T410", 15, 265, ZoneType.N)]
        public decimal TotalHonoraireNonResidente { get; set; }

        [Zone("T411", 5, 280, ZoneType.Nr)]
        public string ZoneReserveD { get; set; }

        [Zone("T412", 15, 285, ZoneType.N)]
        public decimal TotalPlusValueImmobiliere { get; set; }

        [Zone("T413", 5, 300, ZoneType.Nr)]
        public string ZoneReserveE { get; set; }

        [Zone("T414", 15, 305, ZoneType.N)]
        public decimal TotalPlusValeurFondPrevuesLegislation { get; set; }

        [Zone("T415", 5, 320, ZoneType.Nr)]
        public string ZoneReserveF { get; set; }

        [Zone("T416", 15, 325, ZoneType.N)]
        public decimal TotalRevenueMobiliere { get; set; }

        [Zone("T417", 1, 340, ZoneType.Xr)]
        public string ZoneReserveG { get; set; }

        [Zone("T418", 15, 341, ZoneType.N)]
        public decimal TotalMontantHonoraireExportation { get; set; }

        [Zone("T419", 15, 356, ZoneType.N)]
        public decimal TotalMontantParadisFiscaux { get; set; }

        [Zone("T420", 15, 371, ZoneType.N)]
        public decimal TotalRetenueOperee { get; set; }

        [Zone("T421", 15, 386, ZoneType.N)]
        public decimal TotalNetServis { get; set; }

        [Zone("T422", 5, 401, ZoneType.Xr)]
        public string ZoneReserveH { get; set; }
    }
}