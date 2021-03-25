using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Config
{
    public interface IGroupConfiguration
    {
        string Server { get; }

        bool IsWinAuthentification { get; }

        string User { get; }

        string Password { get; }

        string Database { get; }
    }
}