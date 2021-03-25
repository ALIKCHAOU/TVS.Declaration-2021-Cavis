using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Dapper
{
    public partial class DeclarationFcRepository
    {
        private const string QueryGet = @"
SELECT [Id]
      ,[ExerciceId]
      ,[SocieteId]
      ,[Trimestre]
      ,[Date]
      ,[IsCloture]
      ,[IsArchive]
FROM [DeclarationFactureSuspenssion] ";

        private const string QueryInsert = @"
INSERT INTO [DeclarationFactureSuspenssion]
           (   [ExerciceId]
              ,[SocieteId]
              ,[Trimestre]
              ,[Date]
              ,[IsCloture]
              ,[IsArchive]
            )
     VALUES
           (@ExerciceId
           ,@SocieteId           
           ,@Trimestre
           ,@Date
           ,@IsCloture
           ,@IsArchive);

SELECT SCOPE_IDENTITY();

";
    }
}