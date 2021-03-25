using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Dapper
{
    public partial class LigneCnssRepository
    {
        private const string QueryGet = @"
SELECT [Id]
      ,[Page]
      ,[Ligne]
      ,[Brut1]
      ,[Brut2]
      ,[Brut3]
      ,[EmployeeNo]
      ,[DeclarationNo]
      ,[CategorieNo]
      ,[SocieteNo]
      ,[CleCnss]
      ,[NumeroCnss]
      ,[Cin]
      ,[Nom]
      ,[Prenom]
      ,[AutresNom]
      ,[NomJeuneFille]
      ,[CodeExploitation]
      ,[Civilite]
      ,[NumeroInterne]
  FROM [LigneCnss]
";

        private const string QueryInsert = @"

INSERT INTO [LigneCnss]
           ([Page]
           ,[Ligne]
           ,[Brut1]
           ,[Brut2]
           ,[Brut3]
           ,[EmployeeNo]
           ,[DeclarationNo]
           ,[CategorieNo]
           ,[SocieteNo]
           ,[CleCnss]
           ,[NumeroCnss]
           ,[Cin]
           ,[Nom]
           ,[Prenom]
           ,[AutresNom]
           ,[NomJeuneFille]
           ,[CodeExploitation]
           ,[Civilite]
           ,[NumeroInterne])
     VALUES
           (@Page
           ,@Ligne
           ,@Brut1
           ,@Brut2
           ,@Brut3
           ,@EmployeeNo
           ,@DeclarationNo
           ,@CategorieNo
           ,@SocieteNo
           ,@CleCnss
           ,@NumeroCnss
           ,@Cin
           ,@Nom
           ,@Prenom
           ,@AutresNom
           ,@NomJeuneFille
           ,@CodeExploitation
           ,@Civilite
           ,@NumeroInterne);

SELECT SCOPE_IDENTITY();";

        private const string QueryDelete = @"
DELETE FROM [LigneCnss] WHERE Id = @No";

        private const string QueryUpdate = @"
UPDATE [LigneCnss]
   SET [Page] = @Page
      ,[Ligne] = @Ligne
      ,[Brut1] = @Brut1
      ,[Brut2] = @Brut2
      ,[Brut3] = @Brut3
      ,[CategorieNo] = @CategorieNo
      ,[SocieteNo] = @SocieteNo
      ,[CleCnss] = @CleCnss
      ,[NumeroCnss] = @NumeroCnss
      ,[Cin] = @Cin
      ,[Nom] =@Nom
      ,[Prenom] = @Prenom
      ,[AutresNom] = @AutresNom
      ,[NomJeuneFille] = @NomJeuneFille
      ,[CodeExploitation] =@CodeExploitation
      ,[Civilite] = @Civilite
      ,[NumeroInterne] = @NumeroInterne
 WHERE Id = @Id";
    }
}