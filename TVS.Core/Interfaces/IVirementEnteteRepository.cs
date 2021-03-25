using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models;

namespace TVS.Core.Interfaces
{
    public interface IVirementEnteteRepository
    {
        IEnumerable<VirementEntete> GetAll(int societeNo , int exerciceId);

        VirementEntete Get(int no);

        int Create(VirementEntete entete);

        void Update(VirementEntete entete);

        void Delete(VirementEntete entete);

        void Cloturer(int declarationNo, bool isCloturer, string rib);

        void Archiver(int declarationNo);
    }
}
