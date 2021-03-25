using TVS.Module.Employee.Models.Enums;

namespace TVS.Module.Employee.Models
{
    public static class StringHelper
    {
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }

        public static bool IsLengthLessThanOrEqual(this string value, int lenght)
        {
            return value.Length <= lenght;
        }
    }

    public abstract class LigneAnnexeBase
    {
        public int Id { get; set; }
        public int SocieteId { get; set; }
        public int ExerciceId { get; set; }

        [Zone("06", 6, 19, ZoneType.I)]
        public int Ordre { get; set; }

        [Zone("07", 1, 25, typeof(TypeBeneficiaire))]
        public TypeBeneficiaire BeneficiaireType { get; set; }

        [Zone("08", 13, 26, ZoneType.X)]
        public string BeneficiaireIdent { get; set; }

        [Zone("09", 40, 39, ZoneType.X)]
        public string Beneficiaire { get; set; }

        [Zone("10", 40, 79, ZoneType.X)]
        public string BeneficiaireActivite { get; set; }

        [Zone("11", 120, 119, ZoneType.X)]
        public string BeneficiaireAdresse { get; set; }
    }
}