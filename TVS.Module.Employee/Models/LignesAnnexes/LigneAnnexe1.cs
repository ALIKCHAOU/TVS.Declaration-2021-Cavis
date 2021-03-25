using TVS.Module.Employee.Models.Enums;
using TVS.Module.Employee.Properties;
using FluentValidation;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace TVS.Module.Employee.Models
{
    public enum ZoneType
    {
        X, // caracteres
        N, // numerique
        I, // entier
        D, // date
        E, // enumeration
        Xr, // caracteres (zone reserve)
        Nr ,// numerique  (zone reserve)
        S//Escapes
    }

    public class ZoneAttribute : Attribute
    {
        public ZoneAttribute(
            string code,
            int longueur,
            int position,
            ZoneType type,
            bool exported = true,
            bool editingInGrid = true)
        {
            Code = code;
            Longueur = longueur;
            Type = type;
            Position = position;
            Exported = exported;
            EditingInGrid = editingInGrid;
            // charger la designation a partir du fichier de ressource suivant le code
        }

        public ZoneAttribute(
            string code,
            int longueur,
            int position,
            Type t,
            bool exported = true,
            bool editingInGrid = true)
        {
            Code = code;
            Longueur = longueur;
            Type = ZoneType.E;
            Position = position;
            EnumType = t;
            Exported = exported;
            EditingInGrid = editingInGrid;
            // charger la designation a partir du fichier de ressource suivant le code
        }

        public string Code { get; set; }

        public string Designation
        {
            get { return Resources.ResourceManager.GetString(Code); }
        }

        public int Longueur { get; set; }

        public int Position { get; set; }

        public ZoneType Type { get; set; }

        public Type EnumType { get; set; }

        public bool Exported { get; set; }

        public bool EditingInGrid { get; set; }

        public override string ToString()
        {
            return string.Format("Code:{0}, Positon:{1}, Longueur:{2}", Code, Position, Longueur);
        }
    }

    public class LigneAnnexeUnValidator : AbstractValidator<LigneAnnexeUn>
    {
        public LigneAnnexeUnValidator()
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

                    return match.Success && y.BeneficiaireIdent.Trim().Length == 13;
                }
                return true;
            }).WithMessage(Resources.errBeneficiereIdent);

            RuleFor(x => x.BeneficiaireActivite).NotEmpty().WithMessage(Resources.errBeneficiaireActivite);

            RuleFor(x => x.SituationFamiliale)
                .NotEmpty()
                .WithMessage("Veuillez vérifier le situation familiale du bénéficiaire![A112]");

            RuleFor(x => x.NombreEnfant)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Veuillez vérifier le nombre d'enfant du bénéficiaire![A113]");

            RuleFor(x => x.DureeEnJour)
                .GreaterThan(0)
                .WithMessage("Veuillez vérifier le nombre de jours de travail du bénéficiaire![A116]");

            RuleFor(x => x.DureeEnJour)
                .LessThan(367)
                .WithMessage("Veuillez vérifier le nombre de jours de travail du bénéficiaire![A116]");

            RuleFor(x => x.DureeEnJour)
                .Must((y, t) => (int) (y.DateFinTravail - y.DateDebutTravail).TotalDays != t)
                .WithMessage("Veuillez vérifier le nombre de jours de travail du bénéficiaire![A116]");

            RuleFor(x => x.DateFinTravail)
                .Must((y, t) => y.DateFinTravail > y.DateDebutTravail)
                .WithMessage("Veuillez vérifier date fin de travail [A115]");

            RuleFor(x => x.RevenuImposable)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Veuillez vérifier le revenue imposable![A117]");

            RuleFor(x => x.AvantageEnNature)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Veuillez vérifier la valeur de l'aventage en nature![A118]");

            RuleFor(x => x.RevenuBrutImposable)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Veuillez vérifier le totale du revenu brut imposable![A119]");

            RuleFor(x => x.RevenuReinvesti)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Veuillez vérifier le revenu reinvesti![A120]");

            RuleFor(x => x.MontantRetenuesRegimeCommun)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Veuillez vérifier le montant des retenues pérées selon le régime commun![A121]");

            RuleFor(x => x.MontantRetenuesTauxVingt)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Veuillez vérifier le montant des retenues opérées au taux de 20% ![A122]");

            RuleFor(x => x.MontantNetServie)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Veuillez vérifier le montant net servi![A123]");

            RuleFor(x => x.RetenueUnPrct)
              .GreaterThanOrEqualTo(0)
              .WithMessage("Veuillez vérifier le montant retenu 1%![RetenueUnPrct]");

            RuleFor(x => x.ContributionConjoncturelle)
              .GreaterThanOrEqualTo(0)
              .WithMessage("Veuillez vérifier le montant contribution conjoncturelle![ContributionConjoncturelle]");
            RuleFor(x => x.ContributionSocialeSolidarite)
             .GreaterThanOrEqualTo(0)
             .WithMessage("Veuillez vérifier le montant contribution sociale solidarité![ContributionSocialeSolidarite]");
        }
    }

    public class LigneAnnexeUn : LigneAnnexeBase, ILigneAnnexe
    {
        public LigneAnnexeUn()
        {
            DateDebutTravail = new DateTime(2016, 1, 1);
            DateFinTravail = new DateTime(2016, 12, 31);
        }

        [Zone("A100", 2, 1, ZoneType.X)]
        public string TypeEnregistrement { get; set; }

        [Zone("A112", 1, 239, typeof(SituationFamiliale))]
        public SituationFamiliale SituationFamiliale { get; set; }

        [Description("Enfant")]
        [Zone("A113", 2, 240, ZoneType.I)]
        public int NombreEnfant { get; set; }

        [Zone("A114", 8, 242, ZoneType.D)]
        public DateTime DateDebutTravail { get; set; }

        [Zone("A115", 8, 250, ZoneType.D)]
        public DateTime DateFinTravail { get; set; }

        [Zone("A116", 3, 258, ZoneType.I, exported: true, editingInGrid: false)]
        public int DureeEnJour
        {
            get
            {
                var result = (int) (DateFinTravail.Date - DateDebutTravail).TotalDays + 1;
                return result;
            }
        }

        [Zone("A117", 15, 261, ZoneType.N)]
        public decimal RevenuImposable { get; set; }

        [Zone("A118", 15, 276, ZoneType.N)]
        public decimal AvantageEnNature { get; set; }

        [Zone("A119", 15, 291, ZoneType.N)]
        public decimal RevenuBrutImposable { get; set; }

        [Zone("A120", 15, 306, ZoneType.N)]
        public decimal RevenuReinvesti { get; set; }

        [Zone("A121", 15, 321, ZoneType.N)]
        public decimal MontantRetenuesRegimeCommun { get; set; }

        [Zone("A122", 15, 336, ZoneType.N)]
        public decimal MontantRetenuesTauxVingt { get; set; }

        [Zone("A123", 15, 351, ZoneType.N)]
        public decimal MontantNetServie { get; set; }

        [Zone("A124", 40, 366, ZoneType.Xr)]
        public string ZoneReserve { get; set; }

        [Zone("A198", 15,406, ZoneType.N,false)]
        public decimal RetenueUnPrct { get; set; }

        [Zone("A199", 15,420, ZoneType.N,false)]
        public decimal ContributionConjoncturelle { get; set; }

        [Zone("A200", 15,435, ZoneType.N,false)]
        public decimal SalaireNonImposable { get; set; }
        [Zone("A201", 15, 435, ZoneType.N, false)]
        public decimal ContributionSocialeSolidarite { get; set; }

        [Description("ChefFamille")]
        [Zone("ChefFamille", 15, 435, ZoneType.I, true)]
        public string ChefFamille { get; set; }

        [Description("IntereDetectible")]
        [Zone("IntereDetectible", 15, 435, ZoneType.N, true)]
        public decimal IntereDetectible { get; set; }
    }
}