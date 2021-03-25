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
    public partial class LigneCnssRepository : BaseRepository, ILigneCnssRepository
    {
        public LigneCnssRepository(IConnectionProvider connectionProvider) : base(connectionProvider)
        {
        }

        public IEnumerable<LigneCnss> GetAll(int categorieNo, int declarationNo)
        {
            const string query = @" WHERE  [DeclarationNo] = @DeclarationNo AND [CategorieNo] = @CategorieNo";
            string queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<LigneCnss>(queryGet, new
                {
                    categorieNo,
                    declarationNo
                });

                return result;
            }
        }

        public IEnumerable<LigneCnss> GetLignesByEmployees(int employeeNo)
        {
            const string query = @" WHERE  [EmployeeNo] = @EmployeeNo";
            string queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<LigneCnss>(queryGet, new
                {
                    employeeNo
                });

                return result;
            }
        }

        public bool Existe(int employeeNo, int declarationNo, string matricule, int categorie)
        {
            const string query =
                @" WHERE  [EmployeeNo] = @EmployeeNo AND [DeclarationNo] = @declarationNo AND [CategorieNo] = @categorie AND [NumeroInterne] = @matricule ";
            string queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<LigneCnss>(queryGet, new
                {
                    employeeNo,
                    declarationNo,
                    matricule,
                    categorie
                });

                return result.Any();
            }
        }

        public IEnumerable<LigneCnss> GetAll(int declarationNo, int employeeNo, string numeroInterne)
        {
            const string query =
                @" WHERE [DeclarationNo] = @DeclarationNo AND  [EmployeeNo] = @EmployeeNo AND [NumeroInterne] = @NumeroInterne";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<LigneCnss>(queryGet, new
                {
                    DeclarationNo = declarationNo,
                    EmployeeNo = employeeNo,
                    NumeroInterne = numeroInterne
                });

                return result;
            }
        }

        public IEnumerable<LigneCnss> GetLignesByDeclaration(int declarationNo)
        {
            const string query = @" WHERE  [DeclarationNo] = @declarationNo";
            string queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<LigneCnss>(queryGet, new
                {
                    declarationNo
                });

                return result;
            }
        }

        public LigneCnss Get(DeclarationCnss declaration, Employee employe)
        {
            const string query = @" WHERE  [DeclarationNo] = @declarationNo AND [EmployeeNo] = @EmployeeNo";
            string queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<LigneCnss>(queryGet, new
                {
                    DeclarationNo = declaration.Id,
                    EmployeeNo = employe.Id
                });

                return result.FirstOrDefault();
            }
        }

        public IEnumerable<LigneCnss> GetLigne( int employeNo , int trim1, int ex1, int trim2, int ex2)
        {
            const string query = @" WHERE  
            [EmployeeNo] = @EmployeeNo   
            AND  DeclarationNo IN
            (SELECT     DeclarationNo FROM   DeclarationCnss
            WHERE       Trimestre >= @trim1 AND Trimestre <= trim2 AND  ExerciceId >= @ex1 AND ExerciceId <= ex2  )    ";

            string queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<LigneCnss>(queryGet, new
                {
                    //DeclarationNo = declarationNo,
                    EmployeeNo = employeNo,
                    trim1,
                    trim2,
                    ex1,
                    ex2
                });

                return result;
            }
        }

        public LigneCnss Get(int no)
        {
            const string query = @" WHERE Id = @No ";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<LigneCnss>(queryGet, new
                {
                    no
                }).SingleOrDefault();

                return result;
            }
        }

        public void Create(LigneCnss ligne)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Query<int>(QueryInsert, ligne);
            }
            ;
        }

        public void Update(LigneCnss ligne)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(QueryUpdate, ligne);
            }
            ;
        }

        public void Delete(LigneCnss ligne)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(QueryDelete, new {No = ligne.Id});
            }
        }

        public void DeleteLigneDeclaration(int declarationNo)
        {
            var query = "DELETE FROM [LigneCnss] WHERE DeclarationNo = @DeclarationNo";
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(query, new {DeclarationNo = declarationNo});
            }
        }

        public bool ExistCategorieHasLigne(int categorieNo)
        {
            const string query = @" WHERE  [CategorieNo] = @categorieNo ";
            string queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<LigneCnss>(queryGet, new
                {
                    categorieNo,
                });

                return result.Any();
            }
        }
    }
}