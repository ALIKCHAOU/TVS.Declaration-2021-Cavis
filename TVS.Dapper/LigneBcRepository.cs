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
    public partial class LigneBcRepository : BaseRepository, ILigneBcRepository
    {
        public LigneBcRepository(IConnectionProvider connectionProvider) : base(connectionProvider)
        {
        }


        public IEnumerable<LigneBc> GetAll(int declarationNo)
        {
            var query = string.Concat(QueryGet, " WHERE [DeclarationNo] = @DeclarationNo");
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<LigneBc>(query, new
                {
                    DeclarationNo = declarationNo
                });

                return result.ToList();
            }
        }

        public LigneBc Get(int no)
        {
            string query = string.Concat(QueryGet, " WHERE [Id] = @No");
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<LigneBc>(query, new
                {
                    No = no
                }).SingleOrDefault();

                return result;
            }
        }

        public int Create(LigneBc ligne)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<int>(QueryInsert, ligne)
                    .SingleOrDefault();

                return result;
            }
        }

        public void Update(LigneBc ligne)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(QueryUpdate, ligne);
            }
        }

        public void Delete(int no)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(QueryDelete, new
                {
                    No = no
                });
            }
        }
    }
}