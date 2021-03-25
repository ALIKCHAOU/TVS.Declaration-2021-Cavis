using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Core.Enums
{
    public enum SituationFamille
    {
        [Description("Célibataire")] Celibataire = 0,

        [Description("Marié(e)")] Marie = 1,

        [Description("Veuf(ve)")] Veuf = 2,

        [Description("Divorcé(e)")] Divorce = 3,

        [Description("Séparé(e)")] Separe = 4,

        [Description("Vie maritale")] VieMaritale = 5,

        [Description("Bénificiaire du PACS")] Benificiere = 6,

        [Description("Non Connue")] NonConnue = 7,

        [Description("Non applicable")] NonAplicable = 8,
    }
}