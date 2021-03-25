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
   public class UtilisateurSocieteRepository : BaseRepository, IUtilisateurSocieteRepository
    {
        private const string QueryCreate = @"
INSERT INTO UtilisateurSociete 
(IdUser ,
IdSociete)
VALUES 
(@IdUser,
@IdSociete)
SELECT SCOPE_IDENTITY();
";
        private const string QueryGetAll = @"
SELECT Id,
IdUser ,
IdSociete 

FROM UtilisateurSociete 
";
        private const string QueryUpdate = @"
UPDATE UtilisateurSociete SET 
IdUser = @IdUser,
IdSociete = @IdSociete
 
WHERE Id = @Id
";
        private const string QueryDelete = @"
DELETE FROM UtilisateurSociete WHERE Id = @Id
";

        private const string QueryDeleteBySociete = @"
DELETE FROM UtilisateurSociete WHERE IdSociete = @IdSociete
";
        public UtilisateurSocieteRepository(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public int Create(UtilisateurSociete userSociete)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Query<int>(QueryCreate, new
                {
                    userSociete.IdSociete,
                    userSociete.IdUser
                     
                }).SingleOrDefault();
            }
        }


        public void Delete(int userSocieteId)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Query<int>(QueryDelete, new
                {
                    Id = userSocieteId
                });

            }
        }

        public void DeleteBySociete(int idSociete)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Query<int>(QueryDeleteBySociete, new
                {
                   IdSociete = idSociete
                });

            }
        }

        public IEnumerable<UtilisateurSociete> GetAll()
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<UtilisateurSociete>(QueryGetAll);

                return result.ToList();
            }
        }

        //public User Get(string login)
        //{
        //    var query = QueryGetAll + " WHERE UPPER(login) = @login ";
        //    using (var con = new SqlConnection(ConnectionString))
        //    {
        //        var result = con.Query<User>(query, new
        //        {
        //            login = login.ToUpper()
        //        });

        //        return result.FirstOrDefault();
        //    }
        //}

        public void Update(UtilisateurSociete userSociete)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Query<int>(QueryUpdate, new
                {
                    userSociete.Id,
                    userSociete.IdSociete,
                    userSociete.IdUser
                });
            }
        }
    }

}
