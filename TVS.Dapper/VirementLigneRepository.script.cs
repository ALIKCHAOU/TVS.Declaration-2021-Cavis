using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Dapper
{
    public partial class VirementLigneRepository
    {
        private const string QueryGet = @"SELECT  [Id]
      ,[EnteteId]
      ,[Matricule]
      ,[Nom]
      ,[Prenom]
      ,[NomBanque]
      ,[CodeBanque]
      ,[CodeGuichet]
      ,[NumeroCompte]
      ,[CleRib]
      ,[NetAPaye]
      ,[Motif]
  FROM [VirementLigne]";

        private const string QueryInsert = @"
INSERT INTO [dbo].[VirementLigne]
           ([EnteteId]
           ,[Matricule]
           ,[Nom]
           ,[Prenom]
           ,[NomBanque]
           ,[CodeBanque]
           ,[CodeGuichet]
           ,[NumeroCompte]
           ,[CleRib]
           ,[NetAPaye]
           ,[Motif])
     VALUES
           (@EnteteId
           ,@Matricule
           ,@Nom
           ,@Prenom
           ,@NomBanque
           ,@CodeBanque
           ,@CodeGuichet
           ,@NumeroCompte
           ,@CleRib
           ,@NetAPaye
           ,@Motif);

SELECT SCOPE_IDENTITY();";

        private const string QueryUpdate = @"
UPDATE [VirementLigne]
   SET [Matricule] = @Matricule
      ,[Nom] = @Nom
      ,[Prenom] = @Prenom
      ,[NomBanque] = @NomBanque
      ,[CodeBanque] = @CodeBanque
      ,[CodeGuichet] = @CodeGuichet
      ,[NumeroCompte] = @NumeroCompte
      ,[CleRib] = @CleRib
      ,[NetAPaye] = @NetAPaye
      ,[Motif] = @Motif
   WHERE [Id] = @Id
 ";
        private const string QueryDelete = @" DELETE FROM VirementLigne WHERE Id = @No ";
    }
}
