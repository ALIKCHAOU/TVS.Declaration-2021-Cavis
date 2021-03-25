using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models;

namespace TVS.Core.Interfaces
{
   public interface  IUtilisateurSocieteRepository
    {

        IEnumerable<UtilisateurSociete> GetAll();
        int Create(UtilisateurSociete userSociete);
        void Update(UtilisateurSociete userSociete);
        //UtilisateurSociete Get(string login);
        void Delete(int id);
        void DeleteBySociete(int idSociete);
    }
}
