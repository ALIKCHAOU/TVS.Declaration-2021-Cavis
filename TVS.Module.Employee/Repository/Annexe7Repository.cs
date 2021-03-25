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
    public class AnnexeSeptRepository : IAnnexeSeptRepository
    {
        #region Script

        private const string Query = @"
SELECT
     Id,
    SocieteId,
    ExerciceId,
	[06] AS  Ordre,
	[07] AS  BeneficiaireType,
	[08] AS  BeneficiaireIdent,
	[09] AS  Beneficiaire,
	[10] AS  BeneficiaireActivite,
	[11] AS  BeneficiaireAdresse,
	[12] AS  TypeMontantPayee,
	[13] AS  MontantPayee,
	[14] AS  RetenueSource,
	[15] AS  MontantNetServi
FROM T2016Annexe7
";
        private const string ParamSociete = @" WHERE SocieteId = @SocieteId AND ExerciceId = @exerciceId ";

        private const string QueryInsert = @"
INSERT INTO T2016Annexe7
(   SocieteId,
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
	[15]
)
VALUES
(   @SocieteId,
    @ExerciceId,
    @Ordre,
    @BeneficiaireType,
	@BeneficiaireIdent,
	@Beneficiaire,
	@BeneficiaireActivite,
	@BeneficiaireAdresse,
	@TypeMontantPayee,
	@MontantPayee,
	@RetenueSource,
	@MontantNetServi
)";

        private const string QueryUpdate = @"UPDATE T2016Annexe7 SET
    [06]  =  @Ordre,
	[07]  =  @BeneficiaireType,
	[08]  =  @BeneficiaireIdent,
	[09]  =  @Beneficiaire,
	[10]  =  @BeneficiaireActivite,
	[11]  =  @BeneficiaireAdresse,
	[12]  =  @TypeMontantPayee,
	[13]  =  @MontantPayee,
	[14]  =  @RetenueSource,
	[15]  =  @MontantNetServi
WHERE Id = @Id
";

        private const string QueryDelete = @"
DELETE FROM [T2016Annexe7]
WHERE Id = @Id
";

        private const string ParamId = @" WHERE [Id] = @No";

        #endregion Script

        private readonly IConnectionProvider _cnProvider;

        public AnnexeSeptRepository(IConnectionProvider cnProvider)
        {
            if (cnProvider == null)
                throw new ArgumentNullException("cnProvider");

            _cnProvider = cnProvider;
        }

        public void Insert(LigneAnnexeSept ligne)
        {
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                cn.Execute(QueryInsert, ligne);
            }
        }

        public IEnumerable<LigneAnnexeSept> GetAll(int societeId, int exerciceId)
        {
            var query = new StringBuilder(Query);
            query.AppendLine(ParamSociete);
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                return cn.Query<LigneAnnexeSept>(query.ToString(), new {societeId, exerciceId });
            }
        }

        public void Update(LigneAnnexeSept ligne)
        {
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                cn.Execute(QueryUpdate, ligne);
            }
        }

        public void Delete(LigneAnnexeSept ligne)
        {
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                cn.Execute(QueryDelete, ligne);
            }
        }

        public LigneAnnexeSept Get(int ligneNo)
        {
            var query = new StringBuilder(Query);
            query.AppendLine(ParamId);
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                return cn.Query<LigneAnnexeSept>(query.ToString(), new
                {
                    No = ligneNo
                }).SingleOrDefault();
            }
        }
    }
}