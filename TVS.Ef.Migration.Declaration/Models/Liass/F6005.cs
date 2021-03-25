﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Ef.Migration.Declaration.Models.Liass
{
    [Table("F6005")]
    public class TF6005
    {
        public int Id { get; set; }

        [Required]
        public int SocieteNo { get; set; }

        public int ExerciceId { get; set; }
        public TSociete Societe { get; set; }
        public TExercice Exercice { get; set; }

        public int ActeDeDepot { get; set; }

        public string NatureDepot { get; set; }

        public string F60050000Codeformejuridique { get; set; }
        public string F60050000Categorie { get; set; }
        public string F60050001 { get; set; }
        public decimal F60050002 { get; set; }
        public decimal F60050003 { get; set; }
        public decimal F60050004 { get; set; }
        public decimal F60050005 { get; set; }
        public decimal F60050006 { get; set; }
        public decimal F60050007 { get; set; }
        public decimal F60050008 { get; set; }
        public decimal F60050009 { get; set; }
        public decimal F60050010 { get; set; }
        public decimal F60050011 { get; set; }
        public decimal F60050012 { get; set; }
        public decimal F60050013 { get; set; }
        public decimal F60050014 { get; set; }
        public decimal F60050015 { get; set; }
        public decimal F60050016 { get; set; }
        public decimal F60050017 { get; set; }
        public decimal F60050018 { get; set; }
        public decimal F60050019 { get; set; }
        public decimal F60050020 { get; set; }
        public decimal F60050021 { get; set; }
        public decimal F60050022 { get; set; }
        public decimal F60050023 { get; set; }
        public decimal F60050024 { get; set; }
        public decimal F60050025 { get; set; }
        public decimal F60050026 { get; set; }
        public decimal F60050027 { get; set; }
        public decimal F60050028 { get; set; }
        public decimal F60050029 { get; set; }
        public decimal F60050030 { get; set; }
        public decimal F60050031 { get; set; }
        public decimal F60050032 { get; set; }
        public decimal F60050033 { get; set; }
        public decimal F60050034 { get; set; }
        public decimal F60050035 { get; set; }
        public decimal F60050036 { get; set; }
        public decimal F60050037 { get; set; }
        public decimal F60050038 { get; set; }
        public decimal F60050039 { get; set; }
        public decimal F60050040 { get; set; }
        public decimal F60050041 { get; set; }
        public decimal F60050042 { get; set; }
        public decimal F60050043 { get; set; }
        public decimal F60050044 { get; set; }
        public decimal F60050045 { get; set; }
        public decimal F60050046 { get; set; }
        public decimal F60050047 { get; set; }
        public decimal F60050048 { get; set; }
        public decimal F60050049 { get; set; }
        public decimal F60050050 { get; set; }
        public decimal F60050051 { get; set; }
        public decimal F60050052 { get; set; }
        public decimal F60050053 { get; set; }
        public decimal F60050054 { get; set; }
        public string F60050055 { get; set; }
        public decimal F60050955 { get; set; }
        public decimal F60050056 { get; set; }
        public decimal F60050057 { get; set; }
        public decimal F60050058 { get; set; }
        public decimal F60050059 { get; set; }
        public decimal F60050060 { get; set; }
        public decimal F60050061 { get; set; }
        public decimal F60050062 { get; set; }
        public decimal F60050063 { get; set; }
        public decimal F60050064 { get; set; }
        public decimal F60050065 { get; set; }
        public decimal F60050066 { get; set; }
        public decimal F60050067 { get; set; }
        public decimal F60050068 { get; set; }
        public decimal F60050069 { get; set; }
        public decimal F60050070 { get; set; }
        public decimal F60050071 { get; set; }
        public decimal F60050072 { get; set; }
        public decimal F60050073 { get; set; }
        public decimal F60050074 { get; set; }
        public decimal F60050075 { get; set; }
        public decimal F60050076 { get; set; }
        public decimal F60050077 { get; set; }
        public decimal F60050078 { get; set; }
        public decimal F60050079 { get; set; }
        public decimal F60050080 { get; set; }
        public decimal F60050081 { get; set; }
        public decimal F60050082 { get; set; }
        public decimal F60050083 { get; set; }
        public decimal F60050084 { get; set; }
        public decimal F60050085 { get; set; }
        public decimal F60050086 { get; set; }
        public decimal F60050087 { get; set; }
        public decimal F60050088 { get; set; }
        public decimal F60050089 { get; set; }
        public decimal F60050090 { get; set; }
        public decimal F60050091 { get; set; }
        public decimal F60050092 { get; set; }
        public decimal F60050093 { get; set; }
        public decimal F60050094 { get; set; }
        public decimal F60050095 { get; set; }
        public decimal F60050096 { get; set; }
        public decimal F60050097 { get; set; }
        public decimal F60050098 { get; set; }
        public decimal F60050099 { get; set; }
        public decimal F60050100 { get; set; }
        public decimal F60050101 { get; set; }
        public decimal F60050102 { get; set; }
        public decimal F60050103 { get; set; }
        public decimal F60050104 { get; set; }
        public decimal F60050105 { get; set; }
        public decimal F60050106 { get; set; }
        public decimal F60050107 { get; set; }
        public decimal F60050108 { get; set; }
        public string F60051000Codeformejuridique { get; set; }
        public string F60051000Categorie { get; set; }
        public string F60051001 { get; set; }
        public decimal F60051002 { get; set; }
        public decimal F60051003 { get; set; }
        public decimal F60051004 { get; set; }
        public decimal F60051005 { get; set; }
        public decimal F60051006 { get; set; }
        public decimal F60051007 { get; set; }
        public decimal F60051008 { get; set; }
        public decimal F60051009 { get; set; }
        public decimal F60051010 { get; set; }
        public decimal F60051011 { get; set; }
        public decimal F60051012 { get; set; }
        public decimal F60051013 { get; set; }
        public decimal F60051014 { get; set; }
        public decimal F60051015 { get; set; }
        public decimal F60051016 { get; set; }
        public decimal F60051017 { get; set; }
        public decimal F60051018 { get; set; }
        public decimal F60051019 { get; set; }
        public decimal F60051020 { get; set; }
        public decimal F60051021 { get; set; }
        public decimal F60051022 { get; set; }
        public decimal F60051023 { get; set; }
        public decimal F60051024 { get; set; }
        public decimal F60051025 { get; set; }
        public decimal F60051026 { get; set; }
        public decimal F60051027 { get; set; }
        public decimal F60051028 { get; set; }
        public decimal F60051029 { get; set; }
        public decimal F60051030 { get; set; }
        public decimal F60051031 { get; set; }
        public decimal F60051032 { get; set; }
        public decimal F60051033 { get; set; }
        public decimal F60051034 { get; set; }
        public decimal F60051035 { get; set; }
        public decimal F60051036 { get; set; }
        public decimal F60051037 { get; set; }
        public decimal F60051038 { get; set; }
        public decimal F60051039 { get; set; }
        public decimal F60051040 { get; set; }
        public decimal F60051041 { get; set; }
        public decimal F60051042 { get; set; }
        public decimal F60051043 { get; set; }
        public decimal F60051044 { get; set; }
        public decimal F60051045 { get; set; }
        public decimal F60051046 { get; set; }
        public decimal F60051047 { get; set; }
        public decimal F60051048 { get; set; }
        public decimal F60051049 { get; set; }
        public decimal F60051050 { get; set; }
        public decimal F60051051 { get; set; }
        public decimal F60051052 { get; set; }
        public decimal F60051053 { get; set; }
        public decimal F60051054 { get; set; }
        public string F60051055 { get; set; }
        public decimal F60051955 { get; set; }
        public decimal F60051056 { get; set; }
        public decimal F60051057 { get; set; }
        public decimal F60051058 { get; set; }
        public decimal F60051059 { get; set; }
        public decimal F60051060 { get; set; }
        public decimal F60051061 { get; set; }
        public decimal F60051062 { get; set; }
        public decimal F60051063 { get; set; }
        public decimal F60051064 { get; set; }
        public decimal F60051065 { get; set; }
        public decimal F60051066 { get; set; }
        public decimal F60051067 { get; set; }
        public decimal F60051068 { get; set; }
        public decimal F60051069 { get; set; }
        public decimal F60051070 { get; set; }
        public decimal F60051071 { get; set; }
        public decimal F60051072 { get; set; }
        public decimal F60051073 { get; set; }
        public decimal F60051074 { get; set; }
        public decimal F60051075 { get; set; }
        public decimal F60051076 { get; set; }
        public decimal F60051077 { get; set; }
        public decimal F60051078 { get; set; }
        public decimal F60051079 { get; set; }
        public decimal F60051080 { get; set; }
        public decimal F60051081 { get; set; }
        public decimal F60051082 { get; set; }
        public decimal F60051083 { get; set; }
        public decimal F60051084 { get; set; }
        public decimal F60051085 { get; set; }
        public decimal F60051086 { get; set; }
        public decimal F60051087 { get; set; }
        public decimal F60051088 { get; set; }
        public decimal F60051089 { get; set; }
        public decimal F60051090 { get; set; }
        public decimal F60051091 { get; set; }
        public decimal F60051092 { get; set; }
        public decimal F60051093 { get; set; }
        public decimal F60051094 { get; set; }
        public decimal F60051095 { get; set; }
        public decimal F60051096 { get; set; }
        public decimal F60051097 { get; set; }
        public decimal F60051098 { get; set; }
        public decimal F60051099 { get; set; }
        public decimal F60051100 { get; set; }
        public decimal F60051101 { get; set; }
        public decimal F60051102 { get; set; }
        public decimal F60051103 { get; set; }
        public decimal F60051104 { get; set; }
        public decimal F60051105 { get; set; }
        public decimal F60051106 { get; set; }
        public decimal F60051107 { get; set; }
        public decimal F60051108 { get; set; }

    }
}
