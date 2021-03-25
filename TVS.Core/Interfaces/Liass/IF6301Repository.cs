using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models.Liass;

namespace TVS.Core.Interfaces.Liass
{
    public interface IF6301Repository
    {

        void Create(F6301 f6301);
        void Update(F6301 f6301);
        void Delete(int id);
        F6301 Get(int societe, int exerciceId);
    }
}
