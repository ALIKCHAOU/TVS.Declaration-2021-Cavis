using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Dapper.Liass;
using PostSharp.Patterns.Model;
using TVS.Core.Models.Liass;
using TVS.Core.Interfaces.Liass;
using TVS.Core;
using TVS.Dapper.Settings;
using System.Data.SqlClient;
using Dapper;

namespace TVS.Dapper.Liass
{
    public partial class F6003Repository : BaseRepository, IF6003Repository
    {
        public   F6003Repository(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }
        public void Create(F6003 F6003) {

            using (var con = new SqlConnection(ConnectionString))
            {
                con.Query<int>(InsertSQL, F6003).SingleOrDefault();
            }
        }
        public void Update(F6003 F6003){
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Query<int>(UpdateSQL, F6003).SingleOrDefault();
            }
        }
        public void Delete(int id) {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Query<int>(DeleteSQL, new { id }).SingleOrDefault();
            }
        }
        public F6003 Get(int societeNo, int exerciceId) {
            const string query = @" WHERE SocieteNo = @SocieteNo AND ExerciceId = @ExerciceId ";
            var queryGet = string.Concat(GetSQL, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<F6003>(queryGet, new
                {
                    societeNo,
                    exerciceId
                }).FirstOrDefault();

                return result;
            }

        }
    }
}
