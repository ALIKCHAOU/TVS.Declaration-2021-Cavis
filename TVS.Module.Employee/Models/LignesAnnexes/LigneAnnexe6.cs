using System.Text.RegularExpressions;
using TVS.Module.Employee.Models.Enums;
using TVS.Module.Employee.Properties;
using FluentValidation;
using TVS.Config.Helpers;

namespace TVS.Module.Employee.Models
{
    public class LigneAnnexeSix : LigneAnnexeBase, ILigneAnnexe
    {
        [Zone("A600", 2, 1, ZoneType.X)]
        public string TypeEnregistrement { get; set; }

        [Zone("A612", 15, 239, ZoneType.N)]
        public decimal MontantRistournes { get; set; }

        [Zone("A613", 15, 254, ZoneType.N)]
        public decimal MontantVentes { get; set; }

        [Zone("A614", 15, 269, ZoneType.N)]
        public decimal MontantAvances { get; set; }

        [Zone("A615", 15, 284, ZoneType.N)]
        public decimal MontantRevenusJeuPari { get; set; }

        [Zone("A616", 15, 299, ZoneType.N)]
        public decimal MontantRetenuJeuPari { get; set; }

        [Zone("A617", 15, 314, ZoneType.N)]
        public decimal MontantVenteNeDepassantVingt { get; set; }

        [Zone("A618", 15, 329, ZoneType.N)]
        public decimal MontantRetenuNeDepassantVingt { get; set; }

        [Zone("A619", 15, 344, ZoneType.N)]
        public decimal MontantPercues { get; set; }

        [Zone("A620", 47, 359, ZoneType.Xr)]
        public string ZoneReserveA { get; set; }
    }

    public class LigneAnnexeSixValidator : AbstractValidator<LigneAnnexeSix>
    {
        public LigneAnnexeSixValidator()
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
            RuleFor(x => x.MontantRistournes)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "[A612]"));
            RuleFor(x => x.MontantVentes)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "[A613]"));
            RuleFor(x => x.MontantAvances)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "[A614]"));
            RuleFor(x => x.MontantRevenusJeuPari)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "[A615]"));
            RuleFor(x => x.MontantRetenuJeuPari)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "[A616]"));
            RuleFor(x => x.MontantVenteNeDepassantVingt)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "[A617]"));
            RuleFor(x => x.MontantRetenuNeDepassantVingt)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "[A618]"));
            RuleFor(x => x.MontantPercues)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "[A619]"));
        }
    }
}