using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models.Liass;

namespace TVS.Core.Interfaces.Liass
{
    public interface IF6303Repository
    {

        void Create(F6303 f6303);
        void Update(F6303 f6303);
        void Delete(int id);
        F6303 Get(int societe, int exerciceId);
    }
}
