using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TVS.Ef.Migration.Declaration.Models.Dec2016
{
    [Table("T2016Annexe4")]
    public class T2016Annexe4
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
        public decimal E13 { get; set; }

        [Column("14")]
        public decimal E14 { get; set; }

        [Column("15")]
        public decimal E15 { get; set; }

        [Column("16")]
        public decimal E16 { get; set; }

        [Column("17")]
        public decimal E17 { get; set; }

        [Column("18")]
        public decimal E18 { get; set; }

        [Column("19")]
        public decimal E19 { get; set; }

        [Column("20")]
        public decimal E20 { get; set; }

        [Column("21")]
        public int E21 { get; set; }

        [Column("221")]
        public decimal E221 { get; set; }

        [Column("222")]
        public decimal E222 { get; set; }

        [Column("223")]
        public decimal E223 { get; set; }


        [Column("23")]
        public int E23 { get; set; }

        [Column("24")]
        public decimal E24 { get; set; }

        [Column("25")]
        public decimal E25 { get; set; }

        [Column("26")]
        public decimal E26 { get; set; }

        [Column("27")]
        public decimal E27 { get; set; }

        public TSociete Societe { get; set; }
        public TExercice Exercice { get; set; }
    }
}