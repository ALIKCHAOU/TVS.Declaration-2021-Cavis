using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Ef.Migration.Declaration.Models.Liass
{
    [Table("F6003")]
    public class TF6003
    {
        public int Id { get; set; }

        [Required]
        public int SocieteNo { get; set; }

        public int ExerciceId { get; set; }
        public TSociete Societe { get; set; }
        public TExercice Exercice { get; set; }

        public int ActeDeDepot { get; set; }

        public string NatureDepot { get; set; }

        public decimal F60030001 { get; set; }
        public decimal F60030002 { get; set; }
        public decimal F60030003 { get; set; }
        public decimal F60030004 { get; set; }
        public decimal F60030005 { get; set; }
        public decimal F60030006 { get; set; }
        public decimal F60030007 { get; set; }
        public decimal F60030008 { get; set; }
        public decimal F60030009 { get; set; }
        public decimal F60030010 { get; set; }
        public decimal F60030011 { get; set; }
        public decimal F60030012 { get; set; }
        public decimal F60030013 { get; set; }
        public decimal F60030014 { get; set; }
        public decimal F60030015 { get; set; }
        public decimal F60030016 { get; set; }
        public decimal F60030017 { get; set; }
        public decimal F60030018 { get; set; }
        public decimal F60030019 { get; set; }
        public decimal F60030020 { get; set; }
        public decimal F60030021 { get; set; }
        public decimal F60030022 { get; set; }
        public decimal F60030023 { get; set; }
        public decimal F60030024 { get; set; }
        public decimal F60030025 { get; set; }
        public decimal F60030026 { get; set; }
        public decimal F60030027 { get; set; }
        public decimal F60030028 { get; set; }
        public decimal F60030029 { get; set; }
        public decimal F60030030 { get; set; }
        public decimal F60030031 { get; set; }
        public decimal F60030032 { get; set; }
        public decimal F60030033 { get; set; }
        public decimal F60030034 { get; set; }
        public decimal F60030035 { get; set; }
        public decimal F60030036 { get; set; }
        public decimal F60030037 { get; set; }
        public decimal F60030038 { get; set; }
        public decimal F60030039 { get; set; }
        public decimal F60030040 { get; set; }
        public decimal F60030041 { get; set; }
        public decimal F60030042 { get; set; }
        public decimal F60030043 { get; set; }
        public decimal F60030044 { get; set; }
        public decimal F60030045 { get; set; }
        public decimal F60030046 { get; set; }
        public decimal F60030047 { get; set; }
        public decimal F60030048 { get; set; }
        public decimal F60030049 { get; set; }
        public decimal F60030050 { get; set; }
        public decimal F60030051 { get; set; }
        public decimal F60030052 { get; set; }
        public decimal F60030053 { get; set; }
        public decimal F60030054 { get; set; }
        public decimal F60030055 { get; set; }
        public decimal F60030056 { get; set; }
        public decimal F60030057 { get; set; }
        public decimal F60030058 { get; set; }
        public decimal F60030059 { get; set; }
        public decimal F60030060 { get; set; }
        public decimal F60030061 { get; set; }
        public decimal F60030062 { get; set; }
        public decimal F60030063 { get; set; }
        public decimal F60030064 { get; set; }
        public decimal F60030065 { get; set; }
        public decimal F60030066 { get; set; }
        public decimal F60030067 { get; set; }
        public decimal F60030068 { get; set; }
        public decimal F60030069 { get; set; }
        public decimal F60030070 { get; set; }
        public decimal F60030071 { get; set; }
        public decimal F60030072 { get; set; }
        public decimal F60030073 { get; set; }
        public decimal F60030074 { get; set; }
        public decimal F60030075 { get; set; }
        public decimal F60030076 { get; set; }
        public decimal F60030077 { get; set; }
        public decimal F60030078 { get; set; }
        public decimal F60030079 { get; set; }
        public decimal F60030080 { get; set; }
        public decimal F60030081 { get; set; }
        public decimal F60030082 { get; set; }
        public decimal F60030083 { get; set; }
        public decimal F60030084 { get; set; }
        public decimal F60030085 { get; set; }
        public decimal F60030086 { get; set; }
        public decimal F60030087 { get; set; }
        public decimal F60030088 { get; set; }
        public decimal F60030089 { get; set; }
        public decimal F60030090 { get; set; }
        public decimal F60030091 { get; set; }
        public decimal F60030092 { get; set; }
        public decimal F60030093 { get; set; }
        public decimal F60030094 { get; set; }
        public decimal F60030095 { get; set; }
        public decimal F60030096 { get; set; }
        public decimal F60030097 { get; set; }
        public decimal F60030098 { get; set; }
        public decimal F60030099 { get; set; }
        public decimal F60030100 { get; set; }
        public decimal F60030101 { get; set; }
        public decimal F60030102 { get; set; }
        public decimal F60030103 { get; set; }
        public decimal F60030104 { get; set; }
        public decimal F60030105 { get; set; }
        public decimal F60030106 { get; set; }
        public decimal F60030107 { get; set; }
        public decimal F60030108 { get; set; }
        public decimal F60030109 { get; set; }
        public decimal F60030110 { get; set; }
        public decimal F60030111 { get; set; }
        public decimal F60030112 { get; set; }
        public decimal F60030113 { get; set; }
        public decimal F60030114 { get; set; }
        public decimal F60030115 { get; set; }
        public decimal F60030116 { get; set; }
        public decimal F60030117 { get; set; }
        public decimal F60030118 { get; set; }
        public decimal F60030119 { get; set; }
        public decimal F60030120 { get; set; }
        public decimal F60030121 { get; set; }
        public decimal F60030122 { get; set; }
        public decimal F60030123 { get; set; }
        public decimal F60030124 { get; set; }
        public decimal F60030125 { get; set; }
        public decimal F60030126 { get; set; }
        public decimal F60030127 { get; set; }
        public decimal F60030128 { get; set; }
        public decimal F60030129 { get; set; }
        public decimal F60030130 { get; set; }
        public decimal F60030131 { get; set; }
        public decimal F60030132 { get; set; }
        public decimal F60030133 { get; set; }
        public decimal F60030134 { get; set; }
        public decimal F60030135 { get; set; }
        public decimal F60030136 { get; set; }
        public decimal F60030137 { get; set; }
        public decimal F60030138 { get; set; }
        public decimal F60030139 { get; set; }
        public decimal F60030140 { get; set; }
        public decimal F60030141 { get; set; }
        public decimal F60030142 { get; set; }
        public decimal F60030143 { get; set; }
        public decimal F60030144 { get; set; }
        public decimal F60030145 { get; set; }
        public decimal F60030146 { get; set; }
        public decimal F60030147 { get; set; }
        public decimal F60030148 { get; set; }
        public decimal F60030149 { get; set; }
        public decimal F60030150 { get; set; }
        public decimal F60030151 { get; set; }
        public decimal F60030152 { get; set; }
        public decimal F60030153 { get; set; }
        public decimal F60030154 { get; set; }
        public decimal F60030155 { get; set; }
        public decimal F60030156 { get; set; }
        public decimal F60030157 { get; set; }
        public decimal F60030158 { get; set; }
        public decimal F60030159 { get; set; }
        public decimal F60030160 { get; set; }
        public decimal F60030161 { get; set; }
        public decimal F60030162 { get; set; }
        public decimal F60030163 { get; set; }
        public decimal F60030164 { get; set; }
        public decimal F60030165 { get; set; }
        public decimal F60030166 { get; set; }
        public decimal F60030167 { get; set; }
        public decimal F60030168 { get; set; }
        public decimal F60030169 { get; set; }
        public decimal F60030170 { get; set; }
        public decimal F60030171 { get; set; }
        public decimal F60030172 { get; set; }
        public decimal F60030173 { get; set; }
        public decimal F60030174 { get; set; }
        public decimal F60030175 { get; set; }
        public decimal F60030176 { get; set; }
        public decimal F60030177 { get; set; }
        public decimal F60030178 { get; set; }

    }
}
