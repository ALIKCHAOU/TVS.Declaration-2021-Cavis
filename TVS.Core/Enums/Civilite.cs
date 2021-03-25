using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Core.Enums
{
    public enum Civilite
    {
        [Description("M")] Monsieur = 0,

        [Description("Mme")] Madame = 1,

        [Description("Mlle")] Mademoiselle = 2
    }
}