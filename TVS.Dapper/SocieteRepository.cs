using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core;
using TVS.Core.Interfaces;
using TVS.Core.Models;
using TVS.Dapper.Settings;

namespace TVS.Dapper
{
    public partial class SocieteRepository : BaseRepository, ISocieteRepository
    {
        public SocieteRepository(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public int Create(Societe societe)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Query<int>(QueryCreate, new
                {
                    societe.Activite,
                    societe.Adresse,
                    societe.CleEmployeur,
                    societe.CodeBureau,
                    societe.CodePostal,
                    societe.CurrentExerciceNo,
                    societe.Id,
                    societe.MatriculCategorie,
                    societe.MatriculCle,
                    societe.MatriculCodeTva,
                    societe.MatriculEtablissement,
                    societe.MatriculFiscal,
                    societe.NumeroEmployeur,
                    societe.Pays,
                    societe.RaisonSocial,
                    societe.Ville,
                    societe.ServerName,
                    societe.DatabaseName,
                    societe.User,
                    societe.Password,
                    societe.Type,
                    societe.CnssTypeMatricule
                }).SingleOrDefault();
            }
        }

        public void Delete(int no)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(QueryDelete, new {id = no});
            }
        }

        public Societe Get(int no)
        {
            var query = QueryGetAll + " WHERE Id = @id";
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<Societe>(query, new {id = no});

                return result.FirstOrDefault();
            }
        }

        public IEnumerable<Societe> GetSocieteByUser(int idUtilisatreur)
        {
            var query = QueryGetSocieteByUser + "  WHERE US.IdUser = @idUser";
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<Societe>(query, new { idUser = idUtilisatreur });                              

                return result.ToList();
            }
        }

        public Societe Get(string raisonSociale)
        {
            var query = QueryGetAll + " WHERE RaisonSocial = @RaisonSocial";
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<Societe>(query, new {RaisonSocial = raisonSociale});

                return result.FirstOrDefault();
            }
        }

        public IEnumerable<Societe> GetAll()
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<Societe>(QueryGetAll);

                return result.ToList();
            }
        }

       

        public void Update(Societe societe)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(QueryUpdate, new
                {
                    societe.Activite,
                    societe.Adresse,
                    societe.CleEmployeur,
                    societe.CodeBureau,
                    societe.CodePostal,
                    societe.CurrentExerciceNo,
                    societe.Id,
                    societe.MatriculCategorie,
                    societe.MatriculCle,
                    societe.MatriculCodeTva,
                    societe.MatriculEtablissement,
                    societe.MatriculFiscal,
                    societe.NumeroEmployeur,
                    societe.Pays,
                    societe.RaisonSocial,
                    societe.Ville,
                    societe.ServerName,
                    societe.DatabaseName,
                    societe.User,
                    societe.Password,
                    societe.Type,
                    societe.CnssTypeMatricule
                });
            }
        }
    }
}