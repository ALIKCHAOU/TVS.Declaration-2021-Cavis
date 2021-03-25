using System.Collections.Generic;
using TVS.Core.Models;

namespace TVS.Core.Interfaces
{
    public interface ILigneBcRepository
    {
        IEnumerable<LigneBc> GetAll(int declarationNo);

        LigneBc Get(int no);

        int Create(LigneBc ligne);

        void Update(LigneBc ligne);

        void Delete(int no);
    }
}