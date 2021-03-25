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
    public partial class CategorieCnssRepository : BaseRepository, ICategorieRepository
    {
        public CategorieCnssRepository(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public IEnumerable<CategorieCnss> GetAllCategories(int societeNo)
        {
            const string query = @" WHERE  SocieteNo = @SocieteNo";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<CategorieCnss>(queryGet, new
                {
                    societeNo
                });

                return result;
            }
        }

        public CategorieCnss GetCategorie(int no)
        {
            const string query = @" WHERE Id = @No ";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<CategorieCnss>(queryGet, new
                {
                    no
                }).SingleOrDefault();

                return result;
            }
        }

        public int Create(CategorieCnss categorie)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Query<int>(QueryInsert, new
                {
                    categorie.AccidentTravail,
                    categorie.CodeExploitation,
                    categorie.No,
                    categorie.Intitule,
                    categorie.SocieteNo,
                    categorie.TauxPatronal,
                    categorie.TauxSalarial,
                    categorie.CodePaie,
                    categorie.TypeVariablePaie
                }).SingleOrDefault();
            }
        }

        public void Update(CategorieCnss categorie)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(QueryUpdate, new
                {
                    categorie.AccidentTravail,
                    categorie.CodeExploitation,
                    categorie.No,
                    categorie.Intitule,
                    categorie.TauxPatronal,
                    categorie.TauxSalarial,
                    categorie.Id,
                    categorie.CodePaie,
                    categorie.TypeVariablePaie
                });
            }
        }

        public void Delete(CategorieCnss categorie)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(QueryDelete, new {No = categorie.Id});
            }
        }
    }
}