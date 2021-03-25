using System.Text.RegularExpressions;
using TVS.Module.Employee.Models.Enums;
using TVS.Module.Employee.Properties;
using FluentValidation;
using TVS.Config.Helpers;

namespace TVS.Module.Employee.Models
{
    public class LigneAnnexeTrois : LigneAnnexeBase, ILigneAnnexe
    {
        [Zone("A300", 2, 1, ZoneType.X)]
        public string TypeEnregistrement { get; set; }

        [Zone("A312", 15, 239, ZoneType.N)]
        public decimal CompteSpeciaux { get; set; }

        [Zone("A313", 15, 254, ZoneType.N)]
        public decimal AutreCapitauxMobilier { get; set; }

        [Zone("A314", 15, 269, ZoneType.N)]
        public decimal PretEtabBancaire { get; set; }

        [Zone("A315", 15, 284, ZoneType.N)]
        public decimal MontantRetenueOperee { get; set; }

        [Zone("A316", 15, 299, ZoneType.N)]
        public decimal MontantNetServi { get; set; }

        [Zone("A317", 92, 314, ZoneType.Xr)]
        public string ZoneReserveA { get; set; }
    }

    public class LigneAnnexeTroisValidator : AbstractValidator<LigneAnnexeTrois>
    {
        public LigneAnnexeTroisValidator()
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
            RuleFor(x => x.CompteSpeciaux)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "[A312]"));
            RuleFor(x => x.AutreCapitauxMobilier)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "[A313]"));
            RuleFor(x => x.PretEtabBancaire)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "[A314]"));
            RuleFor(x => x.MontantRetenueOperee)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "[A315]"));
            RuleFor(x => x.MontantNetServi)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "[A316]"));
        }
    }
}