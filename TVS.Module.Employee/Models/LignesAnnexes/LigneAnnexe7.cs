using System.Text.RegularExpressions;
using TVS.Module.Employee.Models.Enums;
using TVS.Module.Employee.Properties;
using FluentValidation;
using TVS.Config.Helpers;

namespace TVS.Module.Employee.Models
{
    public class LigneAnnexeSept : LigneAnnexeBase, ILigneAnnexe
    {
        [Zone("A700", 2, 1, ZoneType.X)]
        public string TypeEnregistrement { get; set; }

        [Zone("A712", 2, 239, typeof(TypeMontantPayee))]
        public TypeMontantPayee TypeMontantPayee { get; set; }

        [Zone("A713", 15, 241, ZoneType.N)]
        public decimal MontantPayee { get; set; }

        [Zone("A714", 15, 256, ZoneType.N)]
        public decimal RetenueSource { get; set; }

        [Zone("A715", 15, 271, ZoneType.N)]
        public decimal MontantNetServi { get; set; }

        [Zone("A716", 120, 286, ZoneType.Xr)]
        public string ZoneReserveA { get; set; }
    }

    public class LigneAnnexeSeptValidator : AbstractValidator<LigneAnnexeSept>
    {
        public LigneAnnexeSeptValidator()
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
            RuleFor(x => x.MontantNetServi)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "[A715]"));
            RuleFor(x => x.MontantPayee)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "[A713]"));
            RuleFor(x => x.RetenueSource)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "[A714]"));
        }
    }
}