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
    public partial class DeclarationBcRepository : BaseRepository, IDeclarationBcRepository
    {
        public DeclarationBcRepository(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public int Create(DeclarationBc declaration)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Query<int>(QueryInsert, new
                {
                    declaration.Date,
                    declaration.ExerciceId,
                    declaration.IsCloture,
                    declaration.IsArchive,
                    declaration.SocieteId,
                    declaration.Trimestre,
                    declaration.NumeroAutorisation
                }).SingleOrDefault();
            }
        }

        public IEnumerable<DeclarationBc> GetAll(int exerciceNo, int societeNo)
        {
            const string query = @" WHERE ExerciceId = @ExerciceNo AND SocieteId = @SocieteNo";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<DeclarationBc>(queryGet, new
                {
                    exerciceNo,
                    societeNo,
                });

                return result;
            }
        }

        public IEnumerable<DeclarationBc> GetAll(int societeNo)
        {
            const string query = @" WHERE SocieteId = @SocieteNo";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<DeclarationBc>(queryGet, new
                {
                    societeNo
                });

                return result;
            }
        }

        public DeclarationBc GetDeclaration(int trimestre, int exerciceNo, int societeNo)
        {
            const string query =
                @" WHERE Trimestre = @Trimestre AND ExerciceId = @ExerciceNo AND SocieteId = @SocieteNo ";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<DeclarationBc>(queryGet, new
                {
                    trimestre,
                    exerciceNo,
                    societeNo
                }).SingleOrDefault();

                return result;
            }
        }

        public DeclarationBc GetDeclaration(int no)
        {
            const string query = @" WHERE Id = @No ";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<DeclarationBc>(queryGet, new
                {
                    no
                }).SingleOrDefault();

                return result;
            }
        }

        public void Delete(int declarationNo)
        {
            const string query = @" DELETE FROM DeclarationBcSuspenssion WHERE Id = @No ";
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(query, new {No = declarationNo});
            }
        }

        public void Cloturer(int declarationNo, bool isCloture)
        {
            const string query = @"UPDATE DeclarationBcSuspenssion SET IsCloture = @isCloture
     WHERE Id = @No ";
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(query, new {No = declarationNo, isCloture});
            }
        }

        public void Archiver(int declarationNo)
        {
            const string query = @"UPDATE DeclarationBcSuspenssion SET IsArchive = 1
     WHERE Id = @No ";
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(query, new {No = declarationNo});
            }
        }

        public bool ExerciceHasDeclaration(int exerciceNo)
        {
            const string query = @" WHERE ExerciceId = @Exerciceno";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<DeclarationBc>(queryGet, new
                {
                    exerciceNo
                });

                return result.Any();
            }
        }
    }
}