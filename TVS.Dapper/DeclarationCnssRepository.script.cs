using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Dapper
{
    public partial class DeclarationCnssRepository
    {

        private const string QueryGetAllExercice = @"
SELECT [Id]
      ,[Annee]
      ,[IsArchive]
      ,[IsCloturer]
  FROM [Exercice] ";
        private const string QueryGetAllSoc = @"
SELECT [Id]
      ,[RaisonSocial]
      ,[Activite]
      ,[Adresse]
      ,[CodePostal]
      ,[Ville]
      ,[Pays]
      ,[NumeroEmployeur]
      ,[CleEmployeur]
      ,[MatriculFiscal]
      ,[MatriculCle]
      ,[MatriculCodeTva]
      ,[MatriculCategorie]
      ,[MatriculEtablissement]
      ,[CodeBureau]
      ,[CurrentExerciceNo]
      ,[ServerName]
      ,[DatabaseName]
      ,[User]
      ,[Password]
      ,[Type]
      ,CnssTypeMatricule
  FROM [dbo].[Societe]
";

        private const string QueryGet = @"
SELECT [Id]
      ,[ExerciceId]
      ,[SocieteId]
      ,[Trimestre]
      ,[Complementaire]
      ,[Date]
      ,[IsCloture]
      ,[IsArchive]
FROM [DeclarationCnss] ";

        private const string QueryInsert = @"
INSERT INTO [DeclarationCnss]
           (   [ExerciceId]
              ,[SocieteId]
              ,[Trimestre]
              ,[Complementaire]
              ,[Date]
              ,[IsCloture]
              ,[IsArchive])
     VALUES
           (@ExerciceId
           ,@SocieteId           
           ,@Trimestre
           ,@Complementaire
           ,@Date
           ,@IsCloture
           ,@IsArchive);

SELECT SCOPE_IDENTITY();

";
    }
}