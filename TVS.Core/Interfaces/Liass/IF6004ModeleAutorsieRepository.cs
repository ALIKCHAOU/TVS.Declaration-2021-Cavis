using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models.Liass;

namespace TVS.Core.Interfaces.Liass
{
    public interface IF6004ModeleAutorsieRepository
    {

        void Create(F6004ModeleAutorsie f6004);
        void Update(F6004ModeleAutorsie f6004);
        void Delete(int id);
        F6004ModeleAutorsie Get(int societe, int exerciceId);
    }
}
