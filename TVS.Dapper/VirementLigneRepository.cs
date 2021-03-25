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
    public partial class VirementLigneRepository : BaseRepository, IVirementLigneRepository
    {
        public VirementLigneRepository(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public IEnumerable<VirementLigne> GetAll(int enteteNo)
        {
            const string query = @" WHERE  EnteteId = @enteteNo";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<VirementLigne>(queryGet, new
                {
                    enteteNo
                });

                return result;
            }
        }

        public VirementLigne Get(int no)
        {
            const string query = @" WHERE Id = @No ";
            var queryGet = string.Concat(QueryGet, query);
            using (var con = new SqlConnection(ConnectionString))
            {
                var result = con.Query<VirementLigne>(queryGet, new
                {
                    no
                }).SingleOrDefault();

                return result;
            }
        }

        public int Create(VirementLigne ligne)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Query<int>(QueryInsert, new
                {
                    ligne.CleRib,
                    CodeBanque = ligne.CodeBanque??"",
                    CodeGuichet = ligne.CodeGuichet ?? "",
                    ligne.EnteteId,
                    ligne.Matricule,
                    Motif = ligne.Motif ?? "",
                    ligne.NetAPaye,
                    ligne.Prenom,
                    ligne.Nom,
                    NomBanque = ligne.NomBanque ?? "",
                    NumeroCompte = ligne.NumeroCompte ?? "",

                }).SingleOrDefault();
            }
        }

        public void Update(VirementLigne ligne)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(QueryUpdate, new
                {   ligne.Id,
                    ligne.CleRib,
                    ligne.CodeBanque,
                    ligne.CodeGuichet,
                    ligne.EnteteId,
                    ligne.Matricule,
                    ligne.Motif,
                    ligne.NetAPaye,
                    ligne.Prenom,
                    ligne.Nom,
                    ligne.NomBanque,
                    ligne.NumeroCompte
                });
            }
        }

        public void Delete(int no)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(QueryDelete, new { No = no });
            }
        }
    }
}
