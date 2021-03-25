using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Dapper
{
    public partial class EmployeeRepository
    {
        public const string QueryGet = @"
SELECT [Id]
      ,[Nom]
      ,[Prenom]
      ,[NomJeuneFille]
      ,[Cin]
      ,[SituationFamille]
      ,[Civilite]
      ,[NumeroCnss]
      ,[CleCnss]
      ,[CategorieNo]
      ,[NumeroInterne]
      ,[AutresNom]
      ,[SocieteNo]
  FROM [Employee]
";

        public const string QueryInsert = @"
INSERT INTO [Employee]
           ([Nom]
           ,[Prenom]
           ,[NomJeuneFille]
           ,[Cin]
           ,[SituationFamille]
           ,[Civilite]
           ,[NumeroCnss]
           ,[CleCnss]
           ,[CategorieNo]
           ,[NumeroInterne]
           ,[AutresNom]
           ,[SocieteNo])
     VALUES
           (@Nom
           ,@Prenom
           ,@NomJeuneFille
           ,@Cin
           ,@SituationFamille
           ,@Civilite
           ,@NumeroCnss
           ,@CleCnss
           ,@CategorieNo
           ,@NumeroInterne
           ,@AutresNom
           ,@SocieteNo);
SELECT SCOPE_IDENTITY();
";

        public const string QueryUpdate = @"UPDATE [Employee]
   SET [Nom] = @Nom
      ,[Prenom] = @Prenom
      ,[NomJeuneFille] = @NomJeuneFille
      ,[Cin] = @Cin
      ,[SituationFamille] = @SituationFamille
      ,[Civilite] = @Civilite
      ,[NumeroCnss] = @NumeroCnss
      ,[CleCnss] = @CleCnss
      ,[CategorieNo] = @CategorieNo
      ,[NumeroInterne] = @NumeroInterne
      ,[AutresNom] = @AutresNom
 WHERE Id =@Id";

        public const string QueryDelete = @"
DELETE FROM Employee WHERE Id = @No
";
    }
}