using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Ef.Migration.Declaration.Models.Liass
{
    [Table("F6004ModeleAutorsie")]
    public class TF6004ModeleAutorsie
    {
        public int Id { get; set; }

        [Required]
        public int SocieteNo { get; set; }

        public int ExerciceId { get; set; }
        public TSociete Societe { get; set; }
        public TExercice Exercice { get; set; }

        public int ActeDeDepot { get; set; }

        public string NatureDepot { get; set; }

        public decimal F60040001 { get; set; }
        public decimal F60040002 { get; set; }
        public decimal F60040003 { get; set; }
        public decimal F60040004 { get; set; }
        public decimal F60040005 { get; set; }
        public decimal F60040006 { get; set; }
        public decimal F60040007 { get; set; }
        public decimal F60040008 { get; set; }
        public decimal F60040009 { get; set; }
        public decimal F60040010 { get; set; }
        public decimal F60040011 { get; set; }
        public decimal F60040012 { get; set; }
        public decimal F60040013 { get; set; }
        public decimal F60040014 { get; set; }
        public decimal F60040015 { get; set; }
        public decimal F60040016 { get; set; }
        public decimal F60040017 { get; set; }
        public decimal F60040018 { get; set; }
        public decimal F60040019 { get; set; }
        public decimal F60040020 { get; set; }
        public decimal F60040021 { get; set; }
        public decimal F60040022 { get; set; }
        public decimal F60040023 { get; set; }
        public decimal F60040024 { get; set; }
        public decimal F60040025 { get; set; }
        public decimal F60040026 { get; set; }
        public decimal F60040027 { get; set; }
        

        public decimal F60041001 { get; set; }
        public decimal F60041002 { get; set; }
        public decimal F60041003 { get; set; }
        public decimal F60041004 { get; set; }
        public decimal F60041005 { get; set; }
        public decimal F60041006 { get; set; }
        public decimal F60041007 { get; set; }
        public decimal F60041008 { get; set; }
        public decimal F60041009 { get; set; }
        public decimal F60041010 { get; set; }
        public decimal F60041011 { get; set; }
        public decimal F60041012 { get; set; }
        public decimal F60041013 { get; set; }
        public decimal F60041014 { get; set; }
        public decimal F60041015 { get; set; }
        public decimal F60041016 { get; set; }
        public decimal F60041017 { get; set; }
        public decimal F60041018 { get; set; }
        public decimal F60041019 { get; set; }
        public decimal F60041020 { get; set; }
        public decimal F60041021 { get; set; }
        public decimal F60041022 { get; set; }
        public decimal F60041023 { get; set; }
        public decimal F60041024 { get; set; }
        public decimal F60041025 { get; set; }
        public decimal F60041026 { get; set; }
        public decimal F60041027 { get; set; }
    }
}
