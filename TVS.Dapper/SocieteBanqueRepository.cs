using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TVS.Core;
using TVS.Core.Interfaces;
using TVS.Core.Models;
using TVS.Dapper.Settings;

namespace TVS.Dapper
{
    public partial class SocieteBanqueRepository : BaseRepository, ISocieteBanqueRepository
    {
        public SocieteBanqueRepository(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public IEnumerable<SocieteBanque> GetAll(int societeNo)
        {
            const string query = @" WHERE  SocieteId = @SocieteNo";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<SocieteBanque>(queryGet, new
                {
                    societeNo
                });

                return result;
            }
        }

        public SocieteBanque Get(int no)
        {
            const string query = @" WHERE Id = @No ";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<SocieteBanque>(queryGet, new
                {
                    no
                }).SingleOrDefault();

                return result;
            }
        }

        public int Create(SocieteBanque societeBanque)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Query<int>(QueryInsert, new
                {
                    societeBanque.Adresse,
                    societeBanque.Agence,
                    societeBanque.Banque,
                    societeBanque.Rib,
                    societeBanque.SocieteId
                }).SingleOrDefault();
            }
        }

        public void Update(SocieteBanque societeBanque)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(QueryUpdate, new
                {
                    societeBanque.Id,
                    societeBanque.Adresse,
                    societeBanque.Agence,
                    societeBanque.Rib,
                });
            }
        }

        public void Delete(SocieteBanque societeBanque)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(QueryDelete, new { No = societeBanque.Id });
            }
        }
    }
}
