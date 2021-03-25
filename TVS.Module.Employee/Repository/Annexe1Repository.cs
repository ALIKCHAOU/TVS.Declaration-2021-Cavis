using Dapper;
using TVS.Module.Employee.Interfaces;
using TVS.Module.Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using TVS.Core;

namespace TVS.Module.Employee.Dal
{
    public class AnnexeUnRepository : IAnnexeUnRepository
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
     [12] AS  SituationFamiliale,
     [13] AS  NombreEnfant,
     [14] AS  DateDebutTravail,
     [15] AS  DateFinTravail,
     [16] AS  DureeEnJour,
     [17] AS  RevenuImposable,
     [18] AS  AvantageEnNature,
     [19] AS  RevenuBrutImposable,
     [20] AS  RevenuReinvesti,
     [21] AS  MontantRetenuesRegimeCommun,
     [22] AS  MontantRetenuesTauxVingt,
     [23] AS  MontantNetServie,
     RetenueUnPrct,
     ContributionConjoncturelle,
     SalaireNonImposable ,
ContributionSocialeSolidarite
,IntereDetectible,Cheffamille

FROM T2016Annexe1 
 ";

        private const string QueryInsert = @"
INSERT INTO T2016Annexe1
(
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
     [20] ,
     [21] ,
     [22] ,
     [23],
     RetenueUnPrct,
     ContributionConjoncturelle,
     SalaireNonImposable,
ContributionSocialeSolidarite,
IntereDetectible,
Cheffamille
)
VALUES
(
    @SocieteId,
    @ExerciceId,
    @Ordre,
	@BeneficiaireType,
	@BeneficiaireIdent,
	@Beneficiaire,
	@BeneficiaireActivite,
	@BeneficiaireAdresse,
	@SituationFamiliale,
	@NombreEnfant,
	@DateDebutTravail,
	@DateFinTravail,
	@DureeEnJour,
	@RevenuImposable,
	@AvantageEnNature,
	@RevenuBrutImposable,
	@RevenuReinvesti,
	@MontantRetenuesRegimeCommun,
	@MontantRetenuesTauxVingt,
	@MontantNetServie,
    @RetenueUnPrct,
    @ContributionConjoncturelle,
    @SalaireNonImposable,
    @ContributionSocialeSolidarite,
    @IntereDetectible,
    @Cheffamille
)";

        private const string QueryUpdate = @"
UPDATE T2016Annexe1 SET
     [06]  = @Ordre,
     [07]  = @BeneficiaireType,
     [08]  = @BeneficiaireIdent,
     [09]  = @Beneficiaire,
     [10]  = @BeneficiaireActivite,
     [11]  = @BeneficiaireAdresse,
     [12]  = @SituationFamiliale,
     [13]  = @NombreEnfant,
     [14]  = @DateDebutTravail,
     [15]  = @DateFinTravail,
     [16]  = @DureeEnJour,
     [17]  = @RevenuImposable,
     [18]  = @AvantageEnNature,
     [19]  = @RevenuBrutImposable,
     [20]  = @RevenuReinvesti,
     [21]  = @MontantRetenuesRegimeCommun,
     [22]  = @MontantRetenuesTauxVingt,
     [23]  = @MontantNetServie,
     [RetenueUnPrct] = @RetenueUnPrct,
     [ContributionConjoncturelle] = @ContributionConjoncturelle,
     [SalaireNonImposable] = @SalaireNonImposable ,
     [ContributionSocialeSolidarite] = @ContributionSocialeSolidarite,
   [IntereDetectible]  =  @IntereDetectible,
   [Cheffamille]= @Cheffamille
WHERE Id = @Id
";

        private const string QueryDelete = @"
DELETE FROM [T2016Annexe1]
WHERE [Id] = @Id";

        private const string ParamId = @" WHERE [Id] = @No";
        private const string ParamSociete = @" WHERE SocieteId = @SocieteId AND ExerciceId = @exerciceId ";
        #endregion Script

        private readonly IConnectionProvider _cnProvider;

        public AnnexeUnRepository(IConnectionProvider cnProvider)
        {
            if (cnProvider == null)
                throw new ArgumentNullException("cnProvider");

            _cnProvider = cnProvider;
        }

        public void Insert(LigneAnnexeUn ligne)
        {
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                cn.Execute(QueryInsert, ligne);
            }
        }

        public bool ExistBeneficiaire(string ident)
        {
            return false;
        }

        public IEnumerable<LigneAnnexeUn> GetAll(int societeId, int exerciceId)
        {
            var query = new StringBuilder(Query);
            query.AppendLine(ParamSociete);
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                return cn.Query<LigneAnnexeUn>(query.ToString(), new {societeId ,exerciceId});
            }
        }

        public void Update(LigneAnnexeUn ligne)
        {

            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                cn.Execute(QueryUpdate, ligne);
            }


        }

        public void Delete(LigneAnnexeUn ligne)
        {
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                cn.Execute(QueryDelete, ligne);
            }
        }

        public LigneAnnexeUn Get(int ligneNo)
        {
            var query = new StringBuilder(Query);
            query.AppendLine(ParamId);
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                return cn.Query<LigneAnnexeUn>(query.ToString(), new
                {
                    No = ligneNo
                }).SingleOrDefault();
            }
        }
    }
}