using System.ComponentModel;

namespace TVS.Module.Employee.Models.Enums
{
    public enum TypeMontantServiAnnexe2 : int
    {
        [Description("Montant brut est null")] MontantBrutNull = 0,

        [Description("Honoraires")] Honoraires = 1,

        [Description("Commissions")] Commissions = 2,

        [Description("Courtages")] Courtages = 3,

        [Description("Loyers")] Loyers = 4,

        [Description("Rémunérations au titre des activités non commerciales")] Remuneration = 5,

        [Description("Rémunérations en contre partie de la performance dans la prestation")] PerformancePrestation = 6
    }

    public enum TypeMontantServiAnnexe4 : int
    {
        [Description("Montant brut est null")] MontantBrutNull = 0,

        [Description("Honoraires")] Honoraires = 1,

        [Description("Commissions")] Commissions = 2,

        [Description("Courtages")] Courtages = 3,

        [Description("Loyers")] Loyers = 4,

        [Description("Rémunérations au titre des activités non commerciales")] Remuneration = 5,

        [Description("Autre revenu")] AutresRevenus = 6,


        [Description("Non Resident : territoire régime fiscal est privilégié")] NonResidentsterritoireregime = 7,

        [Description("Non Resident et autres établissements stables")] NonResidents1 = 8,

        [Description("Renumeration performence prestation")] RenumerationPerformencePrestation = 9
    }
}