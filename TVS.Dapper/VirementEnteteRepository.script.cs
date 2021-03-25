using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Dapper
{
    public partial class VirementEnteteRepository
    {
        private const string QueryGet = @"SELECT  [Id]
      ,[DateEcheance]
      ,[DateCreation]
      ,[ReferenceEnvoi]
      ,[MotifOperation]
      ,[Cloturer]
      ,[Archiver]
      ,[Total]
      ,[NombreTotal]
      ,[BanqueId]
      ,[Banque]
      ,[Rib]
      ,[SocieteId]
      ,[ExerciceId]
      ,[Exercice]
FROM [VirementEntete]";

        private const string QueryInsert = @"
INSERT INTO [dbo].[VirementEntete]
           ([DateEcheance]
           ,[DateCreation]
           ,[ReferenceEnvoi]
           ,[MotifOperation]
           ,[Cloturer]
           ,[Archiver]
           ,[Total]
           ,[NombreTotal]
           ,[BanqueId]
           ,[Banque]
           ,[Rib]
           ,[SocieteId]
           ,[ExerciceId]
           ,[Exercice])
     VALUES
           (@DateEcheance 
           ,@DateCreation 
           ,@ReferenceEnvoi 
           ,@MotifOperation 
           ,@Cloturer
           ,@Archiver
           ,@Total
           ,@NombreTotal 
           ,@BanqueId 
           ,@Banque 
           ,@Rib 
           ,@SocieteId 
           ,@ExerciceId 
           ,@Exercice );

SELECT SCOPE_IDENTITY();";

        private const string QueryUpdate = @"
UPDATE [VirementEntete]
   SET [DateEcheance] = @DateEcheance 
      ,[DateCreation] = @DateCreation 
      ,[ReferenceEnvoi] = @ReferenceEnvoi 
      ,[MotifOperation] = @MotifOperation 
      ,[Cloturer] = @Cloturer 
      ,[Archiver] = @Archiver 
      ,[Total] = @Total
      ,[NombreTotal] = @NombreTotal 
      ,[BanqueId] = @BanqueId 
      ,[Banque] = @Banque 
      ,[Rib] = @Rib 
      ,[SocieteId] = @SocieteId 
      ,[ExerciceId] = @ExerciceId 
      ,[Exercice] = @Exercice 
   WHERE [Id] = @Id
 ";
        private const string QueryDelete = @" DELETE FROM VirementEntete WHERE Id = @No ";
    }
}
