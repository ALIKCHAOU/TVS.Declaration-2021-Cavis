using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Core.Enums
{
    public enum TypeAuthentification
    {
        [Description("Authentification Windows")] Windows = 0,

        [Description("Authentification Sql")] Sql = 1
    }
}