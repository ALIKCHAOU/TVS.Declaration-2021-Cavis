using System.Collections.Generic;
using TVS.Core.Models;

namespace TVS.Core.Interfaces
{
    public interface ILigneFcRepository
    {
        IEnumerable<LigneFc> GetAll(int declarationNo);

        LigneFc Get(int no);

        int Create(LigneFc ligne);

        void Update(LigneFc ligne);

        void Delete(int no);
    }
}