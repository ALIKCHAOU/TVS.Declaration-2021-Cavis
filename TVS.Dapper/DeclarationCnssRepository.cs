using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TVS.Core;
using TVS.Core.Interfaces;
using TVS.Core.Models;
using TVS.Dapper.Settings;

namespace TVS.Dapper
{
    public partial class DeclarationCnssRepository : BaseRepository, IDeclarationCnssRepository
    {
        public DeclarationCnssRepository(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public int Create(DeclarationCnss declaration)
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
                    declaration.Complementaire
                }).SingleOrDefault();
            }
        }

        public IEnumerable<DeclarationCnss> GetAll(int exerciceNo, int societeNo)
        {
            const string query = @" WHERE ExerciceId = @ExerciceNo AND SocieteId = @SocieteNo";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<DeclarationCnss>(queryGet, new
                {
                    exerciceNo,
                    societeNo,
                });

                return result;
            }
        }

        public IEnumerable<DeclarationCnss> GetAll(int societeNo)
        {
            const string query = @" WHERE SocieteId = @SocieteNo";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<DeclarationCnss>(queryGet, new
                {
                    societeNo
                });

                return result;
            }
        }

        public DeclarationCnss GetDeclaration(int trimestre, int exerciceNo, int societeNo)
        {
            const string query =
                @" WHERE Trimestre = @Trimestre AND ExerciceId = @ExerciceNo AND SocieteId = @SocieteNo ";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<DeclarationCnss>(queryGet, new
                {
                    trimestre,
                    exerciceNo,
                    societeNo
                }).SingleOrDefault();

                return result;
            }
        }

        public DeclarationCnss GetDeclaration(int no)
        {
            const string query = @" WHERE Id = @No ";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<DeclarationCnss>(queryGet, new
                {
                    no
                }).SingleOrDefault();

                return result;
            }
        }
        public DeclarationCnss GetDeclarationCnss(int no)
        {
            const string query = @" WHERE Id = @No ";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<DeclarationCnss>(queryGet, new
                {
                    no
                }).SingleOrDefault();

                return result;
            }
        }

        public IEnumerable<Exercice> GetAllExercice()
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<Exercice>(QueryGetAllExercice);

                return result.ToList();
            }
        }

        public IEnumerable<Societe> GetAllSoc()
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<Societe>(QueryGetAllSoc);

                return result.ToList();
            }
        }

        public IEnumerable<DeclarationCnss> GetDeclarationByTrimestre(int trimestre, int exerciceNo, int trimestreF, int exerciceNoF)
        {
            const string query =
                @" WHERE Trimestre >= @trimestre  AND Trimestre <= @trimestreF AND  ExerciceId  >= @exerciceNo  AND ExerciceId  <= @exerciceNoF ";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<DeclarationCnss>(queryGet, new
                {
                    trimestre,
                    exerciceNo,
                    trimestreF,
                    exerciceNoF
                });

                return result;
            }
        }


        public void Delete(int declarationNo)
        {
            const string query = @" DELETE FROM DeclarationCnss WHERE Id = @No ";
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(query, new {No = declarationNo});
            }
        }

        public void Cloturer(int declarationNo, bool isCloture)
        {
            const string query = @"UPDATE DeclarationCnss SET IsCloture = @isCloture
     WHERE Id = @No ";
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(query, new {No = declarationNo, isCloture});
            }
        }

        public void Archiver(int declarationNo)
        {
            const string query = @"UPDATE DeclarationCnss SET IsArchive = 1
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