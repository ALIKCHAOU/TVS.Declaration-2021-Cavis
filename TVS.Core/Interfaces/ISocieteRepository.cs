using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models;

namespace TVS.Core.Interfaces
{
    public interface ISocieteRepository
    {
        IEnumerable<Societe> GetAll();
        Societe Get(string raisonSociale);
        Societe Get(int no);
        void Update(Societe societe);
        int Create(Societe societe);
        IEnumerable<Societe> GetSocieteByUser(int idUser);
        void Delete(int no);
    }
}