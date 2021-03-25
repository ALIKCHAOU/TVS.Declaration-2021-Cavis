using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Ef.Migration.Declaration.Models.Liass
{
    [Table("F6303")]
    public class TF6303
    {
        public int Id { get; set; }
        [Required]
        public int SocieteNo { get; set; }

        public int ExerciceId { get; set; }
        public TSociete Societe { get; set; }
        public TExercice Exercice { get; set; }

        public int ActeDeDepot { get; set; }

        public string NatureDepot { get; set; }

        public decimal F63030001 { get; set; }
        public decimal F63030002 { get; set; }
        public decimal F63030003 { get; set; }
        public decimal F63030004 { get; set; }
        public decimal F63030005 { get; set; }
        public decimal F63030006 { get; set; }
        public decimal F63030007 { get; set; }
        public decimal F63030008 { get; set; }
        public decimal F63030009 { get; set; }
        public decimal F63030010 { get; set; }
        public decimal F63030011 { get; set; }
        public decimal F63030012 { get; set; }
        public decimal F63030013 { get; set; }
        public decimal F63030014 { get; set; }
        public decimal F63030015 { get; set; }
        public decimal F63030016 { get; set; }
        public decimal F63030017 { get; set; }
        public decimal F63030018 { get; set; }

        public decimal F63031001 { get; set; }
        public decimal F63031002 { get; set; }
        public decimal F63031003 { get; set; }
        public decimal F63031004 { get; set; }
        public decimal F63031005 { get; set; }
        public decimal F63031006 { get; set; }
        public decimal F63031007 { get; set; }
        public decimal F63031008 { get; set; }
        public decimal F63031009 { get; set; }
        public decimal F63031010 { get; set; }
        public decimal F63031011 { get; set; }
        public decimal F63031012 { get; set; }
        public decimal F63031013 { get; set; }
        public decimal F63031014 { get; set; }
        public decimal F63031015 { get; set; }
        public decimal F63031016 { get; set; }
        public decimal F63031017 { get; set; }
        public decimal F63031018 { get; set; }


    }
}
