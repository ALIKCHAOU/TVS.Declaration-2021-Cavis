using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using TVS.Core;
using TVS.Core.Interfaces;
using TVS.Core.Models;
using TVS.Dapper.Settings;

namespace TVS.Dapper
{
    public partial class ExerciceRepository : BaseRepository, IExerciceRepository
    {
        public ExerciceRepository(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public void Cloturer(int no)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(QueryUpdate, new {id = no, IsCloturer = false});
            }
        }

        public int Create(string annee)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Query<int>(QueryInsert, new
                {
                    Annee = annee
                }).SingleOrDefault();
            }
        }

        public void Decloturer(int no)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(QueryUpdate, new {id = no, IsCloturer = false});
            }
        }

        public void Delete(int no)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(QueryDelete, new {id = no});
            }
        }

        public Exercice Get(int id)
        {
            var query = QueryGetAll + " WHERE Id = @id";
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<Exercice>(query, new {id});

                return result.FirstOrDefault();
            }
        }
        public Exercice GetExercice(int id)
        {
            var query = QueryGetAll + " WHERE Id = @id";
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<Exercice>(query, new {id});

                return result.FirstOrDefault();
            }
        }

      

        public Exercice Get(string annee)
        {
            var query = QueryGetAll + " WHERE ANNEE = @Annee";
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<Exercice>(query, new {annee});

                return result.FirstOrDefault();
            }
        }

        public IEnumerable<Exercice> GetAll()
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<Exercice>(QueryGetAll);

                return result.ToList();
            }
        }
 //public IEnumerable<Societe> GetAllSoc()
 //       {
 //           using (var con = new SqlConnection(ConnectionString))
 //           {
 //               var result = con.Query<Societe>(QueryGetAll);

 //               return result.ToList();
 //           }
 //       }



    }
}