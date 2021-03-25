using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core;
using TVS.Core.Models;

namespace TVS.Declaration.Societes.Controllers
{
    public class UserController
    {   private readonly DeclarationService _service;

        public UserController(DeclarationService service)
        {
            _service = service;
        }

        public void Create(User user)
        {
            if (string.IsNullOrEmpty(user.Login))
                throw new InvalidOperationException("Login invalide");
            _service.UserCreate(user.Login,
                user.Password,
                user.IsAdmin,
                user.Nom,
                user.Prenom,
                user.Mail,
                user.DecEmp,
                user.DecEmpAnnexe1,
                user.Cnss,
                user.Vente,
                user.Achat,
                user.Virement,
            user.Liasse);
        }
        public IEnumerable<User> GetAll()
        {
            return _service.UserGetAll();
        }
        internal void Delete(User currentView)
        {
            if (currentView == null) throw new ArgumentNullException("currentView");
            if (currentView.Id == 0) return;
            _service.UserDelete(currentView.Login);
        }

        internal User InitNew()
        {
            return new User
            {
                Cnss = true,
                Achat = true,
                DecEmp = true,
                DecEmpAnnexe1 = true,
                IsAdmin = false,
                Vente = true,
                Virement = true,

            };
        }
        internal bool IsUserExists(User currentView)
        {
            if (currentView == null) throw new ArgumentNullException("currentView");
            return _service.UserGetAll().Any(x => x.Login == currentView.Login);
        }

        internal void Update(User user)
        {
            if (user == null) throw new ArgumentNullException("currentView");
            _service.UserUpdate(user.Login,
              user.Password,
              user.IsAdmin,
              user.Nom,
              user.Prenom,
              user.Mail,
              user.DecEmp,
              user.DecEmpAnnexe1,
              user.Cnss,
              user.Vente,
              user.Achat,
              user.Virement,
            user.Liasse);
        }

    }
}
