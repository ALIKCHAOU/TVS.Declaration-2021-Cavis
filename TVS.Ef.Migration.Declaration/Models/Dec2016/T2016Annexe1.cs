using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TVS.Ef.Migration.Declaration.Models.Dec2016
{
    [Table("T2016Annexe1")]
    public class T2016Annexe1
    {
        public int Id { get; set; }
        public int SocieteId { get; set; }
        public int ExerciceId { get; set; }

        [Column("06")]
        public int E06 { get; set; }

        [Column("07")]
        public int E07 { get; set; }

        [Column("08")]
        public string E08 { get; set; }

        [Column("09")]
        public string E09 { get; set; }

        [Column("10")]
        public string E10 { get; set; }

        [Column("11")]
        public string E11 { get; set; }

        [Column("12")]
        public int E12 { get; set; }

        [Column("13")]
        public int E13 { get; set; }

        [Column("14")]
        public DateTime E14 { get; set; }

        [Column("15")]
        public DateTime E15 { get; set; }

        [Column("16")]
        public int E16 { get; set; }

        [Column("17")]
        public decimal E17 { get; set; }

        [Column("18")]
        public decimal E18 { get; set; }

        [Column("19")]
        public decimal E19 { get; set; }

        [Column("20")]
        public decimal E20 { get; set; }

        [Column("21")]
        public decimal E21 { get; set; }

        [Column("22")]
        public decimal E22 { get; set; }

        [Column("23")]
        public decimal E23 { get; set; }

        [Column("RetenueUnPrct")]
        public decimal RetenueUnPrct { get; set; }

        [Column("ContributionConjoncturelle")]
        public decimal ContributionConjoncturelle { get; set; }

        [Column("SalaireNonImposable")]
        public decimal SalaireNonImposable { get; set; }

        [Column("ContributionSocialeSolidarite")]
        public decimal ContributionSocialeSolidarite { get; set; }

        [Column("Cheffamille")]
        public string Cheffamille { get; set; }
        [Column("IntereDetectible")]
        public decimal IntereDetectible { get; set; }

        public TSociete Societe { get; set; }
        public TExercice Exercice { get; set; }
    }
}