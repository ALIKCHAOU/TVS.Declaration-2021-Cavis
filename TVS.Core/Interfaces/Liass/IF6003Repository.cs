using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models.Liass;

namespace TVS.Core.Interfaces.Liass
{
    public interface IF6003Repository
    {

        void Create(F6003 f6003);
        void Update(F6003 f6003);
        void Delete(int id);
        F6003 Get(int societe, int exerciceId);
    }
}
