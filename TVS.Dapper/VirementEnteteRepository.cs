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
    public partial class VirementEnteteRepository : BaseRepository, IVirementEnteteRepository
    {
        public VirementEnteteRepository(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public IEnumerable<VirementEntete> GetAll(int societeNo , int exerciceNo)
        {
            const string query = @" WHERE  SocieteId = @SocieteNo AND ExerciceId = @exerciceNo ";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<VirementEntete>(queryGet, new
                {
                    societeNo,
                    exerciceNo
                });

                return result;
            }
        }

        public VirementEntete Get(int no)
        {
            const string query = @" WHERE Id = @No ";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<VirementEntete>(queryGet, new
                {
                    no
                }).SingleOrDefault();

                return result;
            }
        }

        public int Create(VirementEntete entete)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Query<int>(QueryInsert, new
                {
                    entete.Rib,
                    entete.Archiver,
                    entete.Banque,
                    entete.BanqueId,
                    entete.Cloturer,
                    entete.DateCreation,
                    entete.DateEcheance,
                    entete.Exercice,
                    entete.ExerciceId,
                    MotifOperation = entete.MotifOperation ?? string.Empty,
                    entete.NombreTotal,
                    entete.Total,
                    ReferenceEnvoi = entete.ReferenceEnvoi ?? string.Empty,
                    entete.SocieteId,
                }).SingleOrDefault();
            }
        }

        public void Update(VirementEntete entete)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(QueryUpdate, new
                {
                    entete.Id,
                    entete.Rib,
                    entete.Archiver,
                    entete.Banque,
                    entete.BanqueId,
                    entete.Cloturer,
                    entete.DateCreation,
                    entete.DateEcheance,
                    entete.Exercice,
                    entete.ExerciceId,
                    MotifOperation = entete.MotifOperation ?? string.Empty,
                    entete.NombreTotal,
                    entete.Total,
                    ReferenceEnvoi = entete.ReferenceEnvoi ?? string.Empty,
                    entete.SocieteId,
                });
            }
        }

        public void Delete(VirementEntete societeBanque)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(QueryDelete, new { No = societeBanque.Id });
            }
        }

        public void Cloturer(int declarationNo, bool isCloture , string rib)
        {
            const string query = @"UPDATE VirementEntete SET Cloturer = @isCloture , Rib = @rib
     WHERE Id = @No ";
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(query, new { No = declarationNo, isCloture , rib});
            }
        }

        public void Archiver(int declarationNo)
        {
            const string query = @"UPDATE VirementEntete SET Archiver = 1
     WHERE Id = @No ";
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(query, new { No = declarationNo });
            }
        }
    }
}
