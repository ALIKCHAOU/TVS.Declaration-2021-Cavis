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
    public partial class F6004ModeleAutorsieRepository : BaseRepository, IF6004ModeleAutorsieRepository
    {
        public F6004ModeleAutorsieRepository(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }
        public void Create(F6004ModeleAutorsie F6004ModeleAutorsie) {

            using (var con = new SqlConnection(ConnectionString))
            {
                con.Query<int>(InsertSQL, F6004ModeleAutorsie).SingleOrDefault();
            }
        }
        public void Update(F6004ModeleAutorsie F6004ModeleAutorsie)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Query<int>(UpdateSQL, F6004ModeleAutorsie).SingleOrDefault();
            }
        }
        public void Delete(int id) {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Query<int>(DeleteSQL, new { id }).SingleOrDefault();
            }
        }
        public F6004ModeleAutorsie Get(int societeNo, int exerciceId) {
            const string query = @" WHERE SocieteNo = @SocieteNo AND ExerciceId = @ExerciceId ";
            var queryGet = string.Concat(GetSQL, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<F6004ModeleAutorsie>(queryGet, new
                {
                    societeNo,
                    exerciceId
                }).FirstOrDefault();

                return result;
            }

        }
    }
}
