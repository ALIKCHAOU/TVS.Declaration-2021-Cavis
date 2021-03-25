using System.Text.RegularExpressions;
using TVS.Module.Employee.Models.Enums;
using TVS.Module.Employee.Properties;
using FluentValidation;
using TVS.Config.Helpers;

namespace TVS.Module.Employee.Models
{
    public class LigneAnnexeCinq : LigneAnnexeBase, ILigneAnnexe
    {
        [Zone("A500", 2, 1, ZoneType.X)]
        public string TypeEnregistrement { get; set; }

        [Zone("A512", 15, 239, ZoneType.N)]
        public decimal MontantOpExport { get; set; }

        [Zone("A513", 15, 254, ZoneType.N)]
        public decimal RetenueOpExport { get; set; }

        [Zone("A514", 15, 269, ZoneType.N)]
        public decimal MontantAutreOp { get; set; }

        [Zone("A515", 15, 284, ZoneType.N)]
        public decimal RetenueAutreOp { get; set; }

        [Zone("A516", 15, 299, ZoneType.N)]
        public decimal MontantEtabPublic { get; set; }

        [Zone("A517", 15, 314, ZoneType.N)]
        public decimal RetenueEtabPublic { get; set; }

        [Zone("A518", 15, 329, ZoneType.N)]
        public decimal MontantEtabAlEtranger { get; set; }

        [Zone("A519", 15, 344, ZoneType.N)]
        public decimal RetenueEtabAlEtranger { get; set; }

        [Zone("A520", 15, 359, ZoneType.N)]
        public decimal MontantNetServi { get; set; }

        [Zone("A521", 32, 374, ZoneType.Xr)]
        public string ZoneReserve { get; set; }
    }

    public class LigneAnnexeCinqValidator : AbstractValidator<LigneAnnexeCinq>
    {
        public LigneAnnexeCinqValidator()
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
            RuleFor(x => x.MontantOpExport)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A512"));
            RuleFor(x => x.RetenueOpExport)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A513"));
            RuleFor(x => x.MontantAutreOp)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A514"));
            RuleFor(x => x.RetenueAutreOp)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A515"));
            RuleFor(x => x.MontantEtabPublic)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A516"));
            RuleFor(x => x.RetenueEtabPublic)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A517"));
            RuleFor(x => x.MontantEtabAlEtranger)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A518"));
            RuleFor(x => x.RetenueEtabAlEtranger)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A519"));
            RuleFor(x => x.MontantNetServi)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A520"));
        }
    }
}