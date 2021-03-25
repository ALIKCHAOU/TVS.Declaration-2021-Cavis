using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Ef.Migration.Declaration.Models.Liass
{
    [Table("F6301")]
    public class TF6301
    {
        public int Id { get; set; }
        [Required]
        public int SocieteNo { get; set; }

        public int ExerciceId { get; set; }
        public TSociete Societe { get; set; }
        public TExercice Exercice { get; set; }

        public int ActeDeDepot { get; set; }

        public string NatureDepot { get; set; }

        public decimal F63010001 { get; set; }
        public decimal F63010002 { get; set; }
        public decimal F63010003 { get; set; }
        public decimal F63010004 { get; set; }
        public decimal F63010005 { get; set; }
        public decimal F63010006 { get; set; }
        public decimal F63010007 { get; set; }
        public decimal F63010008 { get; set; }
        public decimal F63010009 { get; set; }
        public decimal F63010010 { get; set; }
        public decimal F63010011 { get; set; }
        public decimal F63010012 { get; set; }
        public decimal F63010013 { get; set; }
        public decimal F63010014 { get; set; }
        public decimal F63010015 { get; set; }
        public decimal F63010016 { get; set; }
        public decimal F63010017 { get; set; }
        public decimal F63010018 { get; set; }
        public decimal F63010019 { get; set; }

        public decimal F63011001 { get; set; }
        public decimal F63011002 { get; set; }
        public decimal F63011003 { get; set; }
        public decimal F63011004 { get; set; }
        public decimal F63011005 { get; set; }
        public decimal F63011006 { get; set; }
        public decimal F63011007 { get; set; }
        public decimal F63011008 { get; set; }
        public decimal F63011009 { get; set; }
        public decimal F63011010 { get; set; }
        public decimal F63011011 { get; set; }
        public decimal F63011012 { get; set; }
        public decimal F63011013 { get; set; }
        public decimal F63011014 { get; set; }
        public decimal F63011015 { get; set; }
        public decimal F63011016 { get; set; }
        public decimal F63011017 { get; set; }
        public decimal F63011018 { get; set; }
        public decimal F63011019 { get; set; }

    }
}
