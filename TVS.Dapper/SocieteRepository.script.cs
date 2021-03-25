using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Dapper
{
    public partial class SocieteRepository
    {
        private const string QueryCreate = @"
INSERT INTO [dbo].[Societe]
           ([RaisonSocial]
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
)
     VALUES
           (@RaisonSocial 
           ,@Activite
           ,@Adresse
           ,@CodePostal
           ,@Ville 
           ,@Pays 
           ,@NumeroEmployeur
           ,@CleEmployeur
           ,@MatriculFiscal 
           ,@MatriculCle 
           ,@MatriculCodeTva
           ,@MatriculCategorie 
           ,@MatriculEtablissement 
           ,@CodeBureau
           ,@CurrentExerciceNo
           ,@ServerName 
            ,@DatabaseName 
            ,@User 
            ,@Password 
            ,@Type
            ,@CnssTypeMatricule
);
SELECT SCOPE_IDENTITY();";

        private const string QueryGetSocieteByUser = @"
SELECT S.Id
      ,S.RaisonSocial
      ,S.Activite
      ,S.Adresse
      ,S.CodePostal
      ,S.Ville
      ,S.Pays
      ,S.NumeroEmployeur
      ,S.CleEmployeur
      ,S.MatriculFiscal
      ,S.MatriculCle
      ,S.MatriculCodeTva
      ,S.MatriculCategorie
      ,S.MatriculEtablissement
      ,S.CodeBureau
      ,S.CurrentExerciceNo
      ,S.ServerName
      ,S.DatabaseName
      ,User
      ,S.Password
      ,S.Type
      ,S.CnssTypeMatricule
  FROM Societe S INNER JOIN UtilisateurSociete US ON  S.Id= US.IdSociete 
";

        private const string QueryUpdate = @"
UPDATE [dbo].[Societe]
   SET RaisonSocial = @RaisonSocial
      ,[Activite] = @Activite
      ,[Adresse] = @Adresse
      ,[CodePostal] = @CodePostal
      ,[Ville] = @Ville
      ,[Pays] = @Pays
      ,[NumeroEmployeur] = @NumeroEmployeur
      ,[CleEmployeur] = @CleEmployeur
      ,[MatriculFiscal] = @MatriculFiscal
      ,[MatriculCle] = @MatriculCle
      ,[MatriculCodeTva] = @MatriculCodeTva
      ,[MatriculCategorie] = @MatriculCategorie
      ,[MatriculEtablissement] = @MatriculEtablissement
      ,[CodeBureau] = @CodeBureau
      ,[CurrentExerciceNo] = @CurrentExerciceNo
      ,[ServerName] = @ServerName
      ,[DatabaseName] = @DatabaseName
      ,[User] = @User
      ,[Password] = @Password
      ,[Type] = @Type
      ,CnssTypeMatricule = @CnssTypeMatricule
WHERE Id = @Id
";
        private const string QueryDelete = @"DELETE FROM SOCIETE WHERE ID = @Id";
        private const string QueryGetAll = @"
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
    }
}