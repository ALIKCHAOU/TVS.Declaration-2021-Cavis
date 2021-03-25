using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Dapper
{
    public partial class ExerciceRepository
    {
        private const string QueryGetAll = @"
SELECT [Id]
      ,[Annee]
      ,[IsArchive]
      ,[IsCloturer]
  FROM [Exercice] ";
        private const string QueryInsert = @"INSERT INTO [dbo].[Exercice]
           ([Annee]
           ,[IsArchive]
           ,[IsCloturer])
     VALUES
           (@Annee
           ,0
           ,0);
SELECT SCOPE_IDENTITY();";

        private const string QueryUpdate = @"
UPDATE [dbo].[Exercice]
   SET [IsCloturer] = @IsCloturer
 WHERE Id = @Id";

        private const string QueryDelete = @"
DELETE FROM [Exercice] WHERE Id = @Id
";
    }
}