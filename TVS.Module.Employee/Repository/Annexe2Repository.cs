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
    public class AnnexeDeuxRepository : IAnnexeDeuxRepository
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
    [12] AS  TypeMontantServiPersonne,
    [13] AS  MontantBurtHonoraires,
    [14] AS  HonorairesSociete,
    [15] AS  ActionsPartSociale,
    [16] AS  RemunerationsSalaries,
    [17] AS  PrixImmeuble,
    [18] AS  LoyersHotels,
    [19] AS  RemunerationsArtistes,
    [20] AS  HonorairesBureauEtude,
    [21] AS  TypeMontantServiOperationExport,
    [22] AS  MontantBrutHonorairesOperationExportation,
    [23] AS  MontantRetenueOperee,
    [24] AS  MontantNetServi
FROM T2016Annexe2
";
        private const string ParamSociete = @" WHERE SocieteId = @SocieteId AND ExerciceId = @exerciceId ";

        private const string QueryInsert = @"
INSERT INTO T2016Annexe2
(
    SocieteId,
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
    [19],
    [20],
    [21],
    [22],
    [23],
    [24]
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
    @TypeMontantServiPersonne,
    @MontantBurtHonoraires,
    @HonorairesSociete,
    @ActionsPartSociale,
    @RemunerationsSalaries,
    @PrixImmeuble,
    @LoyersHotels,
    @RemunerationsArtistes,
    @HonorairesBureauEtude,
    @TypeMontantServiOperationExport,
    @MontantBrutHonorairesOperationExportation,
    @MontantRetenueOperee,
    @MontantNetServi
)";

        private const string QueryUpdate = @"UPDATE T2016Annexe2 SET
[06] = @Ordre,
[07] = @BeneficiaireType,
[08] = @BeneficiaireIdent,
[09] = @Beneficiaire,
[10] = @BeneficiaireActivite,
[11] = @BeneficiaireAdresse,
[12] = @TypeMontantServiPersonne,
[13] = @MontantBurtHonoraires,
[14] = @HonorairesSociete,
[15] = @ActionsPartSociale,
[16] = @RemunerationsSalaries,
[17] = @PrixImmeuble,
[18] = @LoyersHotels,
[19] = @RemunerationsArtistes,
[20] = @HonorairesBureauEtude,
[21] = @TypeMontantServiOperationExport,
[22] = @MontantBrutHonorairesOperationExportation,
[23] = @MontantRetenueOperee,
[24] = @MontantNetServi
WHERE Id = @Id
";

        private const string QueryDelete = @"
DELETE FROM [T2016Annexe2]
WHERE [Id] = @Id";

        private const string ParamId = @" WHERE [Id] = @No";

        #endregion Script

        private readonly IConnectionProvider _cnProvider;

        public AnnexeDeuxRepository(IConnectionProvider cnProvider)
        {
            if (cnProvider == null)
                throw new ArgumentNullException("cnProvider");

            _cnProvider = cnProvider;
        }

        public void Insert(LigneAnnexeDeux ligne)
        {
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                cn.Execute(QueryInsert, ligne);
            }
        }

        public IEnumerable<LigneAnnexeDeux> GetAll(int societeId, int exerciceId)
        {
            var query = new StringBuilder(Query);
            query.AppendLine(ParamSociete);
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                return cn.Query<LigneAnnexeDeux>(query.ToString(), new {societeId, exerciceId });
            }
        }

        public void Update(LigneAnnexeDeux ligne)
        {
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                cn.Execute(QueryUpdate, ligne);
            }
        }

        public void Delete(LigneAnnexeDeux ligne)
        {
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                cn.Execute(QueryDelete, ligne);
            }
        }

        public LigneAnnexeDeux Get(int ligneNo)
        {
            var query = new StringBuilder(Query);
            query.AppendLine(ParamId);
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                return cn.Query<LigneAnnexeDeux>(query.ToString(), new
                {
                    No = ligneNo
                }).SingleOrDefault();
            }
        }
    }
}