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
    public partial class F6002Repository : BaseRepository, IF6002Repository
    {
        public   F6002Repository(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }
        public void Create(F6002 f6002) {

            using (var con = new SqlConnection(ConnectionString))
            {
                con.Query<int>(InsertSQL, f6002).SingleOrDefault();
            }
        }
        public void Update(F6002 f6002){
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Query<int>(UpdateSQL, f6002).SingleOrDefault();
            }
        }
        public void Delete(int id) {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Query<int>(DeleteSQL, new { id }).SingleOrDefault();
            }
        }
        public F6002 Get(int societeNo, int exerciceId) {
            const string query = @" WHERE SocieteNo = @SocieteNo AND ExerciceId = @ExerciceId ";
            var queryGet = string.Concat(GetSQL, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<F6002>(queryGet, new
                {
                    societeNo,
                    exerciceId
                }).FirstOrDefault();

                return result;
            }

        }
    }
}
