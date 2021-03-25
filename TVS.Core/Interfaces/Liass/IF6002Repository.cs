using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models.Liass;

namespace TVS.Core.Interfaces.Liass
{
    public interface IF6002Repository
    {

        void Create(F6002 f6002);
        void Update(F6002 f6002);
        void Delete(int id);
        F6002 Get(int societe, int exerciceId);
    }
}
