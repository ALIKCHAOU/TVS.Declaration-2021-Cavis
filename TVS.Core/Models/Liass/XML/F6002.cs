using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Core.Models.Liass
{
    public partial class F6002
    {

       public string ToXML( Models.Societe ste,Models.Exercice ex)
        {
           // Models.Societe sos = TVS.
            string r = 
$@"<?xml version=""1.0"" encoding=""UTF-8""?>
<?xml-stylesheet type=""text/xsl"" href=""F6002.xsl""?>
<lf:F6002 xmlns:lf=""http://www.impots.finances.gov.tn/liasse"" xmlns:vc=""http://www.w3.org/2007/XMLSchema-versioning"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://www.impots.finances.gov.tn/liasse F6002.xsd"">
	<lf:VersionDocument>String</lf:VersionDocument>
	<lf:Entete>
		<lf:MatriculeFiscalDeclarant>{ste.MatriculFiscal}{ste.MatriculCle}{ste.MatriculCodeTva}{ste.MatriculCategorie}{ste.MatriculEtablissement}</lf:MatriculeFiscalDeclarant>
		<lf:NometPrenomouRaisonSociale>{ste.RaisonSocial}</lf:NometPrenomouRaisonSociale>
		<lf:Activite>{ste.Activite}</lf:Activite>
		<lf:Adresse>{ste.Adresse}</lf:Adresse>
		<lf:Exercice>{ex.Annee}</lf:Exercice>
		<lf:DateDebutExercice>01/01/{ex.Annee}</lf:DateDebutExercice>
		<lf:DateClotureExercice>31/12/{ex.Annee}</lf:DateClotureExercice>
		<lf:ActeDeDepot>{this.ActeDeDepot}</lf:ActeDeDepot>
		<lf:NatureDepot>{this.NatureDepot}</lf:NatureDepot>
	</lf:Entete>
	<lf:Details>
		<lf:F60020001>{this.F60020001*1000:0}</lf:F60020001>
		<lf:F60020002>{this.F60020002*1000:0}</lf:F60020002>
		<lf:F60020003>{this.F60020003*1000:0}</lf:F60020003>
		<lf:F60020004>{this.F60020004*1000:0}</lf:F60020004>
		<lf:F60020005>{this.F60020005*1000:0}</lf:F60020005>
		<lf:F60020006>{this.F60020006*1000:0}</lf:F60020006>
		<lf:F60020007>{this.F60020007*1000:0}</lf:F60020007>
		<lf:F60020008>{this.F60020008*1000:0}</lf:F60020008>
		<lf:F60020009>{this.F60020009*1000:0}</lf:F60020009>
		<lf:F60020010>{this.F60020010*1000:0}</lf:F60020010>
		<lf:F60020011>{this.F60020011*1000:0}</lf:F60020011>
		<lf:F60020012>{this.F60020012*1000:0}</lf:F60020012>
		<lf:F60020013>{this.F60020013*1000:0}</lf:F60020013>
		<lf:F60020014>{this.F60020014*1000:0}</lf:F60020014>
		<lf:F60020015>{this.F60020015*1000:0}</lf:F60020015>
		<lf:F60020016>{this.F60020016*1000:0}</lf:F60020016>
		<lf:F60020017>{this.F60020017*1000:0}</lf:F60020017>
		<lf:F60020018>{this.F60020018*1000:0}</lf:F60020018>
		<lf:F60020019>{this.F60020019*1000:0}</lf:F60020019>
		<lf:F60020020>{this.F60020020*1000:0}</lf:F60020020>
		<lf:F60020021>{this.F60020021*1000:0}</lf:F60020021>
		<lf:F60020022>{this.F60020022*1000:0}</lf:F60020022>
		<lf:F60020023>{this.F60020023*1000:0}</lf:F60020023>
		<lf:F60020024>{this.F60020024*1000:0}</lf:F60020024>
		<lf:F60020025>{this.F60020025*1000:0}</lf:F60020025>
		<lf:F60020026>{this.F60020026*1000:0}</lf:F60020026>
		<lf:F60020027>{this.F60020027*1000:0}</lf:F60020027>
		<lf:F60020028>{this.F60020028*1000:0}</lf:F60020028>
		<lf:F60020029>{this.F60020029*1000:0}</lf:F60020029>
		<lf:F60020030>{this.F60020030*1000:0}</lf:F60020030>
		<lf:F60020031>{this.F60020031*1000:0}</lf:F60020031>
		<lf:F60020032>{this.F60020032*1000:0}</lf:F60020032>
		<lf:F60020033>{this.F60020033*1000:0}</lf:F60020033>
		<lf:F60020034>{this.F60020034*1000:0}</lf:F60020034>
		<lf:F60020035>{this.F60020035*1000:0}</lf:F60020035>
		<lf:F60020036>{this.F60020036*1000:0}</lf:F60020036>
		<lf:F60020037>{this.F60020037*1000:0}</lf:F60020037>
		<lf:F60020038>{this.F60020038*1000:0}</lf:F60020038>
		<lf:F60020039>{this.F60020039*1000:0}</lf:F60020039>
		<lf:F60020040>{this.F60020040*1000:0}</lf:F60020040>
		<lf:F60020041>{this.F60020041*1000:0}</lf:F60020041>
		<lf:F60020042>{this.F60020042*1000:0}</lf:F60020042>
		<lf:F60020043>{this.F60020043*1000:0}</lf:F60020043>
		<lf:F60020044>{this.F60020044*1000:0}</lf:F60020044>
		<lf:F60020045>{this.F60020045*1000:0}</lf:F60020045>
		<lf:F60020046>{this.F60020046*1000:0}</lf:F60020046>
		<lf:F60020047>{this.F60020047*1000:0}</lf:F60020047>
		<lf:F60020048>{this.F60020048*1000:0}</lf:F60020048>
		<lf:F60020049>{this.F60020049*1000:0}</lf:F60020049>
		<lf:F60020050>{this.F60020050 * 1000:0}</lf:F60020050>
		<lf:F60020051>{this.F60020051 * 1000:0}</lf:F60020051>
		<lf:F60020052>{this.F60020052 * 1000:0}</lf:F60020052>
		<lf:F60020053>{this.F60020053 * 1000:0}</lf:F60020053>
		<lf:F60020054>{this.F60020054 * 1000:0}</lf:F60020054>
		<lf:F60020055>{this.F60020055 * 1000:0}</lf:F60020055>
		<lf:F60020056>{this.F60020056 * 1000:0}</lf:F60020056>
		<lf:F60020057>{this.F60020057 * 1000:0}</lf:F60020057>
		<lf:F60020058>{this.F60020058 * 1000:0}</lf:F60020058>
		<lf:F60020059>{this.F60020059 * 1000:0}</lf:F60020059>
		<lf:F60020060>{this.F60020060 * 1000:0}</lf:F60020060>
		<lf:F60020061>{this.F60020061 * 1000:0}</lf:F60020061>
		<lf:F60020062>{this.F60020062 * 1000:0}</lf:F60020062>
		<lf:F60020063>{this.F60020063 * 1000:0}</lf:F60020063>
		<lf:F60020064>{this.F60020064 * 1000:0}</lf:F60020064>
		<lf:F60020065>{this.F60020065 * 1000:0}</lf:F60020065>
		<lf:F60020066>{this.F60020066 * 1000:0}</lf:F60020066>
		<lf:F60020067>{this.F60020067 * 1000:0}</lf:F60020067>
		<lf:F60020068>{this.F60020068 * 1000:0}</lf:F60020068>
		<lf:F60020069>{this.F60020069 * 1000:0}</lf:F60020069>
		<lf:F60020070>{this.F60020070 * 1000:0}</lf:F60020070>
		<lf:F60020071>{this.F60020071 * 1000:0}</lf:F60020071>
		<lf:F60020072>{this.F60020072 * 1000:0}</lf:F60020072>
		<lf:F60020073>{this.F60020073 * 1000:0}</lf:F60020073>
		<lf:F60020074>{this.F60020074 * 1000:0}</lf:F60020074>
		<lf:F60020075>{this.F60020075 * 1000:0}</lf:F60020075>
		<lf:F60020076>{this.F60020076 * 1000:0}</lf:F60020076>
		<lf:F60020077>{this.F60020077 * 1000:0}</lf:F60020077>
		<lf:F60020078>{this.F60020078 * 1000:0}</lf:F60020078>
		<lf:F60020079>{this.F60020079 * 1000:0}</lf:F60020079>
	    <lf:F60020080>{this.F60020080 * 1000:0}</lf:F60020080>
		<lf:F60020081>{this.F60020081 * 1000:0}</lf:F60020081>
		<lf:F60020082>{this.F60020082 * 1000:0}</lf:F60020082>
		<lf:F60020083>{this.F60020083 * 1000:0}</lf:F60020083>
		<lf:F60020084>{this.F60020084 * 1000:0}</lf:F60020084>
		<lf:F60020085>{this.F60020085 * 1000:0}</lf:F60020085>
		<lf:F60020086>{this.F60020086 * 1000:0}</lf:F60020086>
		<lf:F60020087>{this.F60020087 * 1000:0}</lf:F60020087>
		<lf:F60020088>{this.F60020088 * 1000:0}</lf:F60020088>
		<lf:F60020089>{this.F60020089 * 1000:0}</lf:F60020089>
	    <lf:F60020090>{this.F60020090 * 1000:0}</lf:F60020090>
		<lf:F60020091>{this.F60020091 * 1000:0}</lf:F60020091>
		<lf:F60020092>{this.F60020092 * 1000:0}</lf:F60020092>
		<lf:F60020093>{this.F60020093 * 1000:0}</lf:F60020093>
		<lf:F60020094>{this.F60020094 * 1000:0}</lf:F60020094>
		<lf:F60020095>{this.F60020095 * 1000:0}</lf:F60020095>
		<lf:F60020096>{this.F60020096 * 1000:0}</lf:F60020096>
		<lf:F60020097>{this.F60020097 * 1000:0}</lf:F60020097>
		<lf:F60020098>{this.F60020098 * 1000:0}</lf:F60020098>
		<lf:F60020099>{this.F60020099 * 1000:0}</lf:F60020099>
		<lf:F60020100>{this.F60020100 * 1000:0}</lf:F60020100>
		<lf:F60020101>{this.F60020101 * 1000:0}</lf:F60020101>
		<lf:F60020102>{this.F60020102 * 1000:0}</lf:F60020102>
		<lf:F60020103>{this.F60020103 * 1000:0}</lf:F60020103>
		<lf:F60020104>{this.F60020104 * 1000:0}</lf:F60020104>
		<lf:F60020105>{this.F60020105 * 1000:0}</lf:F60020105>
		<lf:F60020106>{this.F60020106 * 1000:0}</lf:F60020106>		
	</lf:Details>
</lf:F6002>
";


            return r;
        }


    }
}
