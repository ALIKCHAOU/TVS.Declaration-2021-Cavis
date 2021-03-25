using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models;

namespace TVS.Core.Interfaces
{
    public interface IVirementLigneRepository
    {
        IEnumerable<VirementLigne> GetAll(int enteteNo);

        VirementLigne Get(int no);

        int Create(VirementLigne entete);

        void Update(VirementLigne entete);

        void Delete(int no);
    }
}
