using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models.Liass;

namespace TVS.Core.Interfaces.Liass
{
    public interface IF6001Repository
    {

        void Create(F6001 f6001);
        void Update(F6001 f6001);
        void Delete(int id);
        F6001 Get(int societe, int exerciceId);
    }
}
