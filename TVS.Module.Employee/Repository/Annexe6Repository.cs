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
    public class AnnexeSixRepository : IAnnexeSixRepository
    {
        #region Script

        private const string Query = @"
SELECT
     Id,
     SocieteId,
     ExerciceId,
	 [06]  AS  Ordre,
	 [07]  AS  BeneficiaireType,
	 [08]  AS  BeneficiaireIdent,
	 [09]  AS  Beneficiaire,
	 [10]  AS  BeneficiaireActivite,
	 [11]  AS  BeneficiaireAdresse,
	 [12]  AS  MontantRistournes,
	 [13]  AS  MontantVentes,
	 [14]  AS  MontantAvances,
     [15]  AS  MontantRevenusJeuPari,
     [16]  AS  MontantRetenuJeuPari,
	 [17]  AS  MontantVenteNeDepassantVingt,
	 [18]  AS  MontantRetenuNeDepassantVingt,
	 [19]  AS  MontantPercues
FROM T2016Annexe6  ";
        private const string ParamSociete = @" WHERE SocieteId = @SocieteId AND ExerciceId = @exerciceId ";

        private const string QueryInsert = @"
INSERT INTO T2016Annexe6
(    SocieteId,
     ExerciceId,
	 [06],
	 [07],
	 [08],
	 [09],
	 [10],
	 [11],
	 [12],
	 [13],
	 [14],
	 [15],
     [16],
     [17],
     [18],
     [19]
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
	@MontantRistournes,
	@MontantVentes,
	@MontantAvances,
    @MontantRevenusJeuPari,
    @MontantRetenuJeuPari,
	@MontantVenteNeDepassantVingt,
	@MontantRetenuNeDepassantVingt,
	@MontantPercues
)";

        private const string QueryUpdate = @"
UPDATE T2016Annexe6 SET
	 [06] = @Ordre,
	 [07] = @BeneficiaireType,
	 [08] = @BeneficiaireIdent,
	 [09] = @Beneficiaire,
	 [10] = @BeneficiaireActivite,
	 [11] = @BeneficiaireAdresse,
	 [12] = @MontantRistournes,
	 [13] = @MontantVentes,
	 [14] = @MontantAvances,
	 [15] = @MontantRevenusJeuPari,
     [16] = @MontantRetenuJeuPari,
	 [17] = @MontantVenteNeDepassantVingt,
	 [18] = @MontantRetenuNeDepassantVingt,
	 [19] = @MontantPercues
WHERE Id = @Id";

        private const string QueryDelete = @"
DELETE FROM [T2016Annexe6]
WHERE [Id] = @Id";

        private const string ParamId = @" WHERE [Id] = @No";

        #endregion Script

        private readonly IConnectionProvider _cnProvider;

        public AnnexeSixRepository(IConnectionProvider cnProvider)
        {
            if (cnProvider == null)
                throw new ArgumentNullException("cnProvider");

            _cnProvider = cnProvider;
        }

        public void Insert(LigneAnnexeSix ligne)
        {
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                cn.Execute(QueryInsert, ligne);
            }
        }

        public IEnumerable<LigneAnnexeSix> GetAll(int societeId, int exerciceId)
        {
            var query = new StringBuilder(Query);
            query.AppendLine(ParamSociete);
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                return cn.Query<LigneAnnexeSix>(query.ToString(), new {societeId, exerciceId });
            }
        }

        public void Update(LigneAnnexeSix ligne)
        {
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                cn.Execute(QueryUpdate, ligne);
            }
        }

        public void Delete(LigneAnnexeSix ligne)
        {
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                cn.Execute(QueryDelete, ligne);
            }
        }

        public LigneAnnexeSix Get(int ligneNo)
        {
            var query = new StringBuilder(Query);
            query.AppendLine(ParamId);
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                return cn.Query<LigneAnnexeSix>(query.ToString(), new
                {
                    No = ligneNo
                }).SingleOrDefault();
            }
        }
    }
}