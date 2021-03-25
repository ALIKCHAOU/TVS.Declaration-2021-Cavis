using System.Text.RegularExpressions;
using TVS.Module.Employee.Models.Enums;
using TVS.Module.Employee.Properties;
using FluentValidation;
using TVS.Config.Helpers;

namespace TVS.Module.Employee.Models
{
    public class LigneAnnexeQuatre : LigneAnnexeBase, ILigneAnnexe
    {
        [Zone("A400", 2, 1, ZoneType.X)]
        public string TypeEnregistrement { get; set; }

        [Zone("A412", 1, 239, typeof(TypeMontantServiAnnexe4))]
        public TypeMontantServiAnnexe4 TypeMontantServiActNonCommercial { get; set; }

        [Zone("A413", 5, 240, ZoneType.N)]
        public decimal TauxMontantServi { get; set; }

        [Zone("A414", 15, 245, ZoneType.N)]
        public decimal MontantServi { get; set; }

        [Zone("A415", 5, 260, ZoneType.N)]
        public decimal TauxHonoraireNonResidente { get; set; }

        [Zone("A416", 15, 265, ZoneType.N)]
        public decimal MontantHonoraireNonResidente { get; set; }

        [Zone("A417", 5, 280, ZoneType.N)]
        public decimal TauxPlusValueImmobiliere { get; set; }

        [Zone("A418", 15, 284, ZoneType.N)]
        public decimal MontantPlusValueImmobiliere { get; set; }

        [Zone("A419", 5, 300, ZoneType.N)]
        public decimal TauxCession { get; set; }

        [Zone("A420", 15, 305, ZoneType.N)]
        public decimal MontantCession { get; set; }

        [Zone("A421", 5, 320, ZoneType.N)]
        public decimal TauxRevenuValueMobiliere { get; set; }

        [Zone("A422", 15, 325, ZoneType.N, exported: true, editingInGrid: false)]
        public decimal MontantRevenuValueMobiliere
        {
            get { return MontantValeurMobiliere + MontantJetonsPresence + MontantActionsPartsSociales; }
        }

        [Zone("A4221", 15, 325, ZoneType.N, false)]
        public decimal MontantValeurMobiliere { get; set; }

        [Zone("A4222", 15, 325, ZoneType.N, false)]
        public decimal MontantJetonsPresence { get; set; }

        [Zone("A4223", 15, 325, ZoneType.N, false)]
        public decimal MontantActionsPartsSociales { get; set; }

        [Zone("A423", 1, 340, typeof(TypeMontantServiAnnexe2))]
        public TypeMontantServiAnnexe2 TypeMontantServiExport { get; set; }

        [Zone("A424", 15, 341, ZoneType.N)]
        public decimal MontantBrutExport { get; set; }

        [Zone("A425", 15, 356, ZoneType.N)]
        public decimal MontantParadisFiscaux { get; set; }

        [Zone("A426", 15, 371, ZoneType.N)]
        public decimal MontantRetenueOperee { get; set; }

        [Zone("A427", 15, 386, ZoneType.N)]
        public decimal MontantNetServi { get; set; }

        [Zone("A428", 5, 401, ZoneType.Xr)]
        public string ZoneReserve { get; set; }
    }

    public class LigneAnnexeQuatreValidator : AbstractValidator<LigneAnnexeQuatre>
    {
        public LigneAnnexeQuatreValidator()
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
            RuleFor(x => x.TauxMontantServi)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A413"));
            RuleFor(x => x.MontantServi)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A414"));
            RuleFor(x => x.TauxHonoraireNonResidente)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A415"));
            RuleFor(x => x.MontantHonoraireNonResidente)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A416"));
            RuleFor(x => x.TauxPlusValueImmobiliere)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A417"));
            RuleFor(x => x.MontantPlusValueImmobiliere)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A418"));
            RuleFor(x => x.TauxCession)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A419"));
            RuleFor(x => x.MontantCession)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A420"));
            RuleFor(x => x.TauxRevenuValueMobiliere)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A421"));
            RuleFor(x => x.MontantRevenuValueMobiliere)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A422"));
            RuleFor(x => x.MontantRetenueOperee)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A423"));
            RuleFor(x => x.MontantBrutExport)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A424"));
            RuleFor(x => x.MontantParadisFiscaux)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A425"));
            RuleFor(x => x.MontantRetenueOperee)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A426"));
            RuleFor(x => x.MontantNetServi)
                .GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(Resources.errMontantInvalid, "A427"));
        }
    }
}