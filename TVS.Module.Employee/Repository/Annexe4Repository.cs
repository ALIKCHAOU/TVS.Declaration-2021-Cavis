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
    public class AnnexeQuatreRepository : IAnnexeQuatreRepository
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
  [12] AS  TypeMontantServiActNonCommercial,
  [13] AS  TauxMontantServi,
  [14] AS  MontantServi,
  [15] AS  TauxHonoraireNonResidente,
  [16] AS  MontantHonoraireNonResidente,
  [17] AS  TauxPlusValueImmobiliere,
  [18] AS  MontantPlusValueImmobiliere,
  [19] AS  TauxCession,
  [20] AS  MontantCession,
  [21] AS  TauxRevenuValueMobiliere,
  [221] AS  MontantValeurMobiliere,
  [222] AS  MontantJetonsPresence,
  [223] AS  MontantActionsPartsSociales,
  [23] AS  TypeMontantServiExport,
  [24] AS  MontantBrutExport,
  [25] AS  MontantParadisFiscaux,
  [26] AS  MontantRetenueOperee,
  [27] AS  MontantNetServi
FROM T2016Annexe4
";
        private const string ParamSociete = @" WHERE SocieteId = @SocieteId AND ExerciceId = @exerciceId ";

        private const string QueryInsert = @"
INSERT INTO T2016Annexe4 (
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
  [221],
  [222],
  [223],
  [23],
  [24],
  [25],
  [26],
  [27])
VALUES
(   @SocieteId,
    @ExerciceId,
	@Ordre,
    @BeneficiaireType,
    @BeneficiaireIdent,
    @Beneficiaire,
    @BeneficiaireActivite,
    @BeneficiaireAdresse,
    @TypeMontantServiActNonCommercial,
    @TauxMontantServi,
    @MontantServi,
    @TauxHonoraireNonResidente,
    @MontantHonoraireNonResidente,
    @TauxPlusValueImmobiliere,
    @MontantPlusValueImmobiliere,
    @TauxCession,
    @MontantCession,
    @TauxRevenuValueMobiliere,
    @MontantValeurMobiliere,
    @MontantJetonsPresence,
    @MontantActionsPartsSociales,
    @TypeMontantServiExport,
    @MontantBrutExport,
    @MontantParadisFiscaux,
    @MontantRetenueOperee,
    @MontantNetServi)
";

        private const string QueryUpdate = @"
UPDATE T2016Annexe4 SET
  [06] =  @Ordre,
  [07] =  @BeneficiaireType,
  [08] =  @BeneficiaireIdent,
  [09] =  @Beneficiaire,
  [10] =  @BeneficiaireActivite,
  [11] =  @BeneficiaireAdresse,
  [12] =  @TypeMontantServiActNonCommercial,
  [13] =  @TauxMontantServi,
  [14] =  @MontantServi,
  [15] =  @TauxHonoraireNonResidente,
  [16] =  @MontantHonoraireNonResidente,
  [17] =  @TauxPlusValueImmobiliere,
  [18] =  @MontantPlusValueImmobiliere,
  [19] =  @TauxCession,
  [20] =  @MontantCession,
  [21] =  @TauxRevenuValueMobiliere,
  [221] =  @MontantValeurMobiliere,
  [222] =  @MontantJetonsPresence,
  [223] =  @MontantActionsPartsSociales,
  [23] =  @TypeMontantServiExport,
  [24] =  @MontantBrutExport,
  [25] =  @MontantParadisFiscaux,
  [26] =  @MontantRetenueOperee,
  [27] =  @MontantNetServi
WHERE Id = @Id

";

        private const string QueryDelete = @"
DELETE FROM [T2016Annexe4]
WHERE [Id] = @Id";

        private const string ParamId = @" WHERE [Id] = @No";

        #endregion Script

        private readonly IConnectionProvider _cnProvider;

        public AnnexeQuatreRepository(IConnectionProvider cnProvider)
        {
            if (cnProvider == null)
                throw new ArgumentNullException("cnProvider");

            _cnProvider = cnProvider;
        }

        public void Insert(LigneAnnexeQuatre ligne)
        {
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                cn.Execute(QueryInsert, ligne);
            }
        }

        public IEnumerable<LigneAnnexeQuatre> GetAll(int societeId, int exerciceId)
        {
            var query = new StringBuilder(Query);
            query.AppendLine(ParamSociete);
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                return cn.Query<LigneAnnexeQuatre>(query.ToString(), new {societeId, exerciceId });
            }
        }

        public void Update(LigneAnnexeQuatre ligne)
        {
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                cn.Execute(QueryUpdate, ligne);
            }
        }

        public void Delete(LigneAnnexeQuatre ligne)
        {
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                cn.Execute(QueryDelete, ligne);
            }
        }

        public LigneAnnexeQuatre Get(int ligneNo)
        {
            var query = new StringBuilder(Query);
            query.AppendLine(ParamId);
            using (var cn = new SqlConnection(_cnProvider.ConnectionString))
            {
                return cn.Query<LigneAnnexeQuatre>(query.ToString(), new
                {
                    No = ligneNo
                }).SingleOrDefault();
            }
        }
    }
}