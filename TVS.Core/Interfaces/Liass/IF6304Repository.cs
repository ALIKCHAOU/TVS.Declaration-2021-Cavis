using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models.Liass;

namespace TVS.Core.Interfaces.Liass
{
    public interface IF6304Repository
    {

        void Create(F6304 f6304);
        void Update(F6304 f6304);
        void Delete(int id);
        F6304 Get(int societe, int exerciceId);
    }
}
