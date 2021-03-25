namespace TVS.Module.Employee.Models.Recap
{
    public class PiedRecap : IPiedAnnexeRecap
    {
        [Zone("D340", 3, 1, ZoneType.X)]
        public string TypeEnregistrement { get; set; }

        [Zone("D341", 20, 4, ZoneType.Xr)]
        public string ZoneReserve { get; set; }

        [Zone("D342", 15, 24, ZoneType.N)]
        public decimal TotalGeneral { get; set; }
    }
}