using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Dapper
{
    public partial class DeclarationBcRepository
    {
        private const string QueryGet = @"
SELECT [Id]
      ,[ExerciceId]
      ,[SocieteId]
      ,[Trimestre]
      ,[Date]
      ,[IsCloture]
      ,[IsArchive]
      ,[NumeroAutorisation]
FROM [DeclarationBcSuspenssion] ";

        private const string QueryInsert = @"
INSERT INTO [DeclarationBcSuspenssion]
           (   [ExerciceId]
              ,[SocieteId]
              ,[Trimestre]
              ,[Date]
              ,[IsCloture]
              ,[IsArchive]
              ,[NumeroAutorisation])
     VALUES
           (@ExerciceId
           ,@SocieteId           
           ,@Trimestre
           ,@Date
           ,@IsCloture
           ,@IsArchive
           ,@NumeroAutorisation);

SELECT SCOPE_IDENTITY();

";
    }
}