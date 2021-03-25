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
    public partial class LigneFcRepository : BaseRepository, ILigneFcRepository
    {
        public LigneFcRepository(IConnectionProvider connectionProvider) : base(connectionProvider)
        {
        }

        public IEnumerable<LigneFc> GetAll(int declarationNo)
        {
            var query = string.Concat(QueryGet, " WHERE [DeclarationNo] = @DeclarationNo");
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<LigneFc>(query, new
                {
                    DeclarationNo = declarationNo
                });

                return result.ToList();
            }
        }

        public LigneFc Get(int no)
        {
            string query = string.Concat(QueryGet, " WHERE [Id] = @No");
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<LigneFc>(query, new
                {
                    No = no
                }).SingleOrDefault();

                return result;
            }
        }

        public int Create(LigneFc ligne)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<int>(QueryInsert, ligne)
                    .SingleOrDefault();

                return result;
            }
        }

        public void Update(LigneFc ligne)
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