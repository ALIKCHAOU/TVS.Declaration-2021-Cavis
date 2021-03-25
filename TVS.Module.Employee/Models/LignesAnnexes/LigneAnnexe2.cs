using System.Text.RegularExpressions;
using TVS.Module.Employee.Models.Enums;
using TVS.Module.Employee.Properties;
using FluentValidation;
using TVS.Config.Helpers;

namespace TVS.Module.Employee.Models
{
    public class LigneAnnexeDeux : LigneAnnexeBase, ILigneAnnexe
    {
        [Zone("A200", 2, 1, ZoneType.X)]
        public string TypeEnregistrement { get; set; }

        [Zone("A212", 1, 239, typeof(TypeMontantServiAnnexe2))]
        public TypeMontantServiAnnexe2 TypeMontantServiPersonne { get; set; }

        [Zone("A213", 15, 240, ZoneType.N)]
        public decimal MontantBurtHonoraires { get; set; }

        [Zone("A214", 15, 255, ZoneType.N)]
        public decimal HonorairesSociete { get; set; }

        [Zone("A215", 15, 270, ZoneType.N)]
        public decimal ActionsPartSociale { get; set; }

        [Zone("A216", 15, 285, ZoneType.N)]
        public decimal RemunerationsSalaries { get; set; }

        [Zone("A217", 15, 300, ZoneType.N)]
        public decimal PrixImmeuble { get; set; }

        [Zone("A218", 15, 315, ZoneType.N)]
        public decimal LoyersHotels { get; set; }

        [Zone("A219", 15, 330, ZoneType.N)]
        public decimal RemunerationsArtistes { get; set; }

        [Zone("A220", 15, 345, ZoneType.N)]
        public decimal HonorairesBureauEtude { get; set; }

        [Zone("A221", 1, 360, typeof(TypeMontantServiAnnexe2))]
        public TypeMontantServiAnnexe2 TypeMontantServiOperationExport { get; set; }

        [Zone("A222", 15, 361, ZoneType.N)]
        public decimal MontantBrutHonorairesOperationExportation { get; set; }

        [Zone("A223", 15, 376, ZoneType.N)]
        public decimal MontantRetenueOperee { get; set; }

        [Zone("A224", 15, 391, ZoneType.N)]
        public decimal MontantNetServi { get; set; }
    }

    public class LigneAnnexeDeuxValidator : AbstractValidator<LigneAnnexeDeux>
    {
        public LigneAnnexeDeuxValidator()
        {
            RuleFor(x => x.BeneficiaireType).NotEmpty().WithMessage(Resources.errBeneficiaireType);
            RuleFor(x => x.Beneficiaire).NotEmpty().WithMessage(Resources.errBeneficiereNom);
            RuleFor(x => x.BeneficiaireIdent).NotEmpty().WithMessage(Resources.errBeneficiereIdent);

            RuleFor(x => x.BeneficiaireIdent).Must((y, t) =>
            {
                if (y.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale)
                {
                    var regex = new Regex(@"[0-9]{8}");
                    var match = regex.Match(y.BeneficiaireIdent.Trim());

                    return match.Success && y.BeneficiaireIdent.Trim().Length == 8;
                }
                if (y.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal)
                {
                    var regex = new Regex(@"[0-9]{7}[A-Z]{3}[0-9]{3}");
                    var match = regex.Match(y.BeneficiaireIdent.Trim());

                    if (match.Success && y.BeneficiaireIdent.Trim().Length != 13)
                        return false;
                    return NumeriqueHelper.ValiderMatricule(y.BeneficiaireIdent);
                }
                return true;
            }).WithMessage(Resources.errBeneficiereIdent);
            RuleFor(x => x.BeneficiaireActivite).NotEmpty().WithMessage(Resources.errBeneficiaireActivite);
            RuleFor(x => x.BeneficiaireAdresse).NotEmpty().WithMessage(Resources.errBeneficiaireAdresse);

            RuleFor(x => x.TypeMontantServiPersonne)
                .NotNull()
                .WithMessage(string.Format(Resources.errTypeMontantServi, "A212"));

            RuleFor(x => x.MontantBurtHonoraires)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A213"));

            RuleFor(x => x.HonorairesSociete)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A214"));
            RuleFor(x => x.ActionsPartSociale)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A215"));
            RuleFor(x => x.RemunerationsSalaries)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A216"));
            RuleFor(x => x.PrixImmeuble)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A217"));
            RuleFor(x => x.LoyersHotels)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A218"));
            RuleFor(x => x.RemunerationsArtistes)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A219"));
            RuleFor(x => x.HonorairesBureauEtude)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A220"));
            RuleFor(x => x.TypeMontantServiOperationExport)
                .NotNull()
                .WithMessage(string.Format(Resources.errTypeMontantServi, "A221"));
            RuleFor(x => x.MontantBrutHonorairesOperationExportation)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A222"));
            RuleFor(x => x.MontantRetenueOperee)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A223"));
            RuleFor(x => x.MontantNetServi)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A224"));
        }
    }
}