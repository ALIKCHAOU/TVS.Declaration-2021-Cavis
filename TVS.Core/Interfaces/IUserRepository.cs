using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models;

namespace TVS.Core.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        IEnumerable<User> GetAllBySociete(int idSociete);
        int Create(User user);
        void Update(User user);
        User Get(string login);
        void Delete(int userId);
       
    }
}
