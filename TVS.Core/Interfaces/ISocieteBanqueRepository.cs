using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models;

namespace TVS.Core.Interfaces
{
    public interface ISocieteBanqueRepository
    {
        IEnumerable<SocieteBanque> GetAll(int societeNo);

        SocieteBanque Get(int no);

        int Create(SocieteBanque societeBanque);

        void Update(SocieteBanque societeBanque);

        void Delete(SocieteBanque societeBanque);
    }
}
