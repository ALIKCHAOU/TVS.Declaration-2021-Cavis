using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TVS.Core;
using TVS.Core.Interfaces;
using TVS.Core.Models;
using TVS.Dapper.Settings;

namespace TVS.Dapper
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private const string QueryCreate = @"
INSERT INTO Utilisateur 
(Login ,
Password ,
IsAdmin ,
Nom,
Prenom,
Mail,
DecEmp ,
DecEmpAnnexe1 ,
Cnss ,
Vente ,
Achat ,
Virement,
Liasse)
VALUES 
(
@Login,
@Password,
@IsAdmin ,
@Nom,
@Prenom,
@Mail,
@DecEmp ,
@DecEmpAnnexe1 ,
@Cnss ,
@Vente ,
@Achat ,
@Virement,
@Liasse);
SELECT SCOPE_IDENTITY();
";
        private const string QueryGetAll = @"
SELECT Id,
Login ,
Password ,
IsAdmin ,
Nom,
Prenom,
Mail,
DecEmp ,
DecEmpAnnexe1 ,
Cnss ,
Vente ,
Achat ,
Virement,
Liasse
FROM Utilisateur 
";

        private const string QueryGetBySociete = @"
SELECT U.Id,
U.Login ,
U.Password ,
U.IsAdmin ,
U.Nom,
U.Prenom,
U.Mail,
U.DecEmp ,
U.DecEmpAnnexe1 ,
U.Cnss ,
U.Vente ,
U.Achat ,
U.Virement,
U.Liasse
FROM Utilisateur U INNER JOIN UtilisateurSociete US ON  U.Id= US.IdUser WHERE  US.IdSociete= @IdSociete
";
        private const string QueryUpdate = @"
UPDATE Utilisateur SET 
Login = @Login,
Password = @Password,
IsAdmin  = @IsAdmin,
Nom = @Nom,
Prenom = @Prenom,
Mail = @Mail,
DecEmp = @DecEmp,
DecEmpAnnexe1 = @DecEmpAnnexe1,
Cnss = @Cnss,
Vente =@Vente,
Achat = @Achat,
Virement = @Virement,
Liasse = @Liasse
WHERE Id = @Id
";
        private const string QueryDelete = @"
DELETE FROM Utilisateur WHERE Id = @Id
";
        public UserRepository(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public int Create(User user)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Query<int>(QueryCreate, new
                {
                    user.Achat,
                    user.Cnss,
                    user.DecEmp,
                    user.DecEmpAnnexe1,
                    user.IsAdmin,
                    user.Login,
                    user.Password,
                    user.Vente,
                    user.Virement,
                    user.Nom,
                    user.Prenom,
                    user.Mail,
                    user.Liasse
                }).SingleOrDefault();
            }
        }


        public void Delete(int userId)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Query<int>(QueryDelete, new
                {
                    Id = userId
                });
                
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<User>(QueryGetAll);

                return result.ToList();
            }
        }

        public IEnumerable<User> GetAllBySociete(int idSociete)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                var sql = QueryGetBySociete.Replace("@IdSociete", idSociete.ToString());
                var result = con.Query<User>(sql);

                return result.ToList();
            }
        }

        public User Get(string login)
        {
            var query = QueryGetAll + " WHERE UPPER(login) = @login ";
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<User>(query , new
                {
                    login = login.ToUpper()
                });

                return result.FirstOrDefault();
            }
        }

        public void Update(User user)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Query<int>(QueryUpdate, new
                {
                    user.Id,
                    user.Achat,
                    user.Cnss,
                    user.DecEmp,
                    user.DecEmpAnnexe1,
                    user.IsAdmin,
                    user.Login,
                    user.Password,
                    user.Vente,
                    user.Virement,
                    user.Nom,
                    user.Prenom,
                    user.Mail,
                    user.Liasse
                });
            }
        }
    }
}
