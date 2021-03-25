using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Dapper
{
    public partial class CategorieCnssRepository
    {
        private const string QueryGet = @"SELECT  [Id]
      ,[No]
      ,[Intitule]
      ,[CodeExploitation]
      ,[TauxSalarial]
      ,[TauxPatronal]
      ,[AccidentTravail]
      ,[SocieteNo]
      ,[TypeVariablePaie]
      ,[CodePaie]
FROM [CategorieCnss]";

        private const string QueryInsert = @"
INSERT INTO [dbo].[CategorieCnss]
           (No
           ,[Intitule]
           ,[CodeExploitation]
           ,[TauxSalarial]
           ,[TauxPatronal]
           ,[AccidentTravail]
           ,[SocieteNo]
           ,[TypeVariablePaie]
           ,[CodePaie])
     VALUES
           (@No
           ,@Intitule
           ,@CodeExploitation
           ,@TauxSalarial
           ,@TauxPatronal
           ,@AccidentTravail
           ,@SocieteNo
           ,@TypeVariablePaie
           ,@CodePaie
);

SELECT SCOPE_IDENTITY();";

        private const string QueryUpdate = @"
UPDATE [CategorieCnss]
   SET [No] = @No
      ,[Intitule] = @Intitule
      ,[CodeExploitation] = @CodeExploitation
      ,[TauxSalarial] = @TauxSalarial
      ,[TauxPatronal] = @TauxPatronal
      ,[AccidentTravail] = @AccidentTravail
      ,[TypeVariablePaie] = @TypeVariablePaie
      ,[CodePaie] = @CodePaie
   WHERE [Id] = @Id
 ";
        private const string QueryDelete = @" DELETE FROM CategorieCnss WHERE Id = @No ";
    }
}