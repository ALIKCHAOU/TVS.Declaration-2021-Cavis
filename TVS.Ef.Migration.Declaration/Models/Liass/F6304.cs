using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Ef.Migration.Declaration.Models.Liass
{
    [Table("F6304")]
   public class TF6304
    {
        public int Id { get; set; }
        [Required]
        public int SocieteNo { get; set; }

        public int ExerciceId { get; set; }
        public TSociete Societe { get; set; }
        public TExercice Exercice { get; set; }

        public int ActeDeDepot { get; set; }

        public string NatureDepot { get; set; }

        public decimal F63040001 { get; set; }
        public decimal F63040002 { get; set; }
        public decimal F63040003 { get; set; }
        public decimal F63040004 { get; set; }
        public decimal F63040005 { get; set; }
        public decimal F63040006 { get; set; }
        public decimal F63040007 { get; set; }
        public decimal F63040008 { get; set; }
        public decimal F63040009 { get; set; }
        public decimal F63040010 { get; set; }
        public decimal F63040011 { get; set; }
        public decimal F63040012 { get; set; }
        public decimal F63040013 { get; set; }
        public decimal F63040014 { get; set; }
        public decimal F63040015 { get; set; }
        public decimal F63040016 { get; set; }
        public decimal F63040017 { get; set; }
        public decimal F63040018 { get; set; }
        public decimal F63040019 { get; set; }
        public decimal F63040020 { get; set; }
        public decimal F63040021 { get; set; }
        public decimal F63040022 { get; set; }
        public decimal F63040023 { get; set; }
        public decimal F63040024 { get; set; }
        public decimal F63040025 { get; set; }
        public decimal F63040026 { get; set; }

        public decimal F63041001 { get; set; }
        public decimal F63041002 { get; set; }
        public decimal F63041003 { get; set; }
        public decimal F63041004 { get; set; }
        public decimal F63041005 { get; set; }
        public decimal F63041006 { get; set; }
        public decimal F63041007 { get; set; }
        public decimal F63041008 { get; set; }
        public decimal F63041009 { get; set; }
        public decimal F63041010 { get; set; }
        public decimal F63041011 { get; set; }
        public decimal F63041012 { get; set; }
        public decimal F63041013 { get; set; }
        public decimal F63041014 { get; set; }
        public decimal F63041015 { get; set; }
        public decimal F63041016 { get; set; }
        public decimal F63041017 { get; set; }
        public decimal F63041018 { get; set; }
        public decimal F63041019 { get; set; }
        public decimal F63041020 { get; set; }
        public decimal F63041021 { get; set; }
        public decimal F63041022 { get; set; }
        public decimal F63041023 { get; set; }
        public decimal F63041024 { get; set; }
        public decimal F63041025 { get; set; }
        public decimal F63041026 { get; set; }


    }
}
