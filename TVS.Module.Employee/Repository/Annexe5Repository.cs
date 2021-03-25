using Dapper;
using TVS.Module.Employee.Interfaces;
using TVS.Module.Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVS.Core;
using System.Data.SqlClient;

namespace TVS.Module.Employee.Dal
{
    public class AnnexeCinqRepository : IAnnexeCinqRepository
    {
        #region Script

        private const string Query = @"SELECT
    Id,
    SocieteId,
    ExerciceId,
[06] AS  Ordre,
[07] AS  BeneficiaireType,
[08] AS  BeneficiaireIdent,
[09] AS  Beneficiaire,
[10] AS  BeneficiaireActivite,
[11] AS  BeneficiaireAdresse,
[12] AS  MontantOpExport,
[13] AS  RetenueOpExport,
[14] AS  MontantAutreOp,
[15] AS  RetenueAutreOp,
[16] AS  MontantEtabPublic,
[17] AS  RetenueEtabPublic,
[18] AS  MontantEtabAlEtranger,
[19] AS  RetenueEtabAlEtranger,
[20] AS  MontantNetServi
FROM T2016Annexe5 ";
        private const string ParamSociete = @" WHERE SocieteId = @SocieteId AND ExerciceId = @exerciceId ";

        private const string QueryInsert = @"
INSERT INTO  T2016Annexe5(
SocieteId,
ExerciceId,
[06] ,
[07] ,
[08] ,
[09] ,
[10] ,
[11] ,
[12] ,
[13] ,
[14] ,
[15] ,
[16] ,
[17] ,
[18] ,
[19] ,
[20] 
) VALUES
(
    @SocieteId,
    @ExerciceId,
    @Ordre,
	@BeneficiaireType,
	@BeneficiaireIdent,
	@Beneficiaire,
	@BeneficiaireActivite,
	@BeneficiaireAdresse,
	@MontantOpExport,
	@RetenueOpExport,
	@MontantAutreOp,
	@RetenueAutreOp,
	@MontantEtabPublic,
	@RetenueEtabPublic,
	@MontantEtabAlEtranger,
	@RetenueEtabAlEtranger,
	@MontantNetServi
)";

        private const string QueryUpdate = @"UPDATE T2016Annexe5 SET
[06]  = @Ordre,
[07]  = @BeneficiaireType,
[08]  = @BeneficiaireIdent,
[09]  = @Beneficiaire,
[10]  = @BeneficiaireActivite,
[11]  = @BeneficiaireAdresse,
[12]  = @MontantOpExport,
[13]  = @RetenueOpExport,
[14]  = @MontantAutreOp,
[15]  = @RetenueAutreOp,
[16]  = @MontantEtabPublic,
[17]  = @RetenueEtabPublic,
[18]  = @MontantEtabAlEtranger,
[19]  = @RetenueEtabAlEtranger,
[20]  = @MontantNetServi
WHERE Id = @Id";

        private const string QueryDelete = @"
DELETE FROM [T2016Annexe5]
WHERE [Id] = @Id";

        private const string ParamId = @" WHERE [Id] = @No";

        #endregion Script

        private readonly IConnectionProvider _cnProvider;

        public AnnexeCinqRepository(IConnectionProvider cnProvider)
        {
            if (cnProvider == null)
                throw new ArgumentNullException("cnProvider");

            _cnProvider = cnProvider;
        }

        public void Insert(LigneAnnexeCinq ligne)
        {
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                cn.Execute(QueryInsert, ligne);
            }
        }

        public IEnumerable<LigneAnnexeCinq> GetAll(int societeId, int exerciceId)
        {
            var query = new StringBuilder(Query);
            query.AppendLine(ParamSociete);
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                return cn.Query<LigneAnnexeCinq>(query.ToString(), new {societeId, exerciceId });
            }
        }

        public void Update(LigneAnnexeCinq ligne)
        {
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                cn.Execute(QueryUpdate, ligne);
            }
        }

        public void Delete(LigneAnnexeCinq ligne)
        {
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                cn.Execute(QueryDelete, ligne);
            }
        }

        public LigneAnnexeCinq Get(int ligneNo)
        {
            var query = new StringBuilder(Query);
            query.AppendLine(ParamId);
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                return cn.Query<LigneAnnexeCinq>(query.ToString(), new
                {
                    No = ligneNo
                }).SingleOrDefault();
            }
        }
    }
}