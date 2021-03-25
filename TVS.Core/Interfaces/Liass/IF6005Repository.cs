using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models.Liass;

namespace TVS.Core.Interfaces.Liass
{
    public interface IF6005Repository
    {

        void Create(F6005 f6005);
        void Update(F6005 f6002);
        void Delete(int id);
        F6005 Get(int societe, int exerciceId);
    }
}
