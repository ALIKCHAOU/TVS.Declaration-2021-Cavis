using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Dapper
{
    public partial class LigneBcRepository
    {
        public const string QueryGet = @"SELECT[Id]
      ,[DeclarationNo]
      ,[NumeroOrdre]
      ,[NumeroAutorisation]
      ,[NumeroBonCommande]
      ,[DateBonCommande]
      ,[NumeroFacture]
      ,[DateFacture]
      ,[Identifiant]
      ,[RaisonSocialFournisseur]
      ,[PrixAchatHorsTaxe]
      ,[MontantTva]
      ,[ObjetFacture]
      ,[SocieteNo]
        FROM[LigneBc]";

        public const string QueryInsert = @"
INSERT INTO [LigneBc]
           ([DeclarationNo]
           ,[NumeroOrdre]
           ,[NumeroAutorisation]
           ,[NumeroBonCommande]
           ,[DateBonCommande]
           ,[NumeroFacture]
           ,[DateFacture]
           ,[Identifiant]
           ,[RaisonSocialFournisseur]
           ,[PrixAchatHorsTaxe]
           ,[MontantTva]
           ,[ObjetFacture]
           ,[SocieteNo])
     VALUES
           (@DeclarationNo
           ,@NumeroOrdre
           ,@NumeroAutorisation
           ,@NumeroBonCommande
           ,@DateBonCommande
           ,@NumeroFacture
           ,@DateFacture
           ,@Identifiant
           ,@RaisonSocialFournisseur
           ,@PrixAchatHorsTaxe
           ,@MontantTva
           ,@ObjetFacture
           ,@SocieteNo);

SELECT SCOPE_IDENTITY();
";

        public const string QueryUpdate = @"
UPDATE [LigneBc]
   SET [NumeroAutorisation] = @NumeroAutorisation
      ,[NumeroBonCommande] = @NumeroBonCommande
      ,[DateBonCommande] = @DateBonCommande
      ,[NumeroFacture] = @NumeroFacture
      ,[DateFacture] = @DateFacture
      ,[Identifiant] = @Identifiant
      ,[RaisonSocialFournisseur] = @RaisonSocialFournisseur
      ,[PrixAchatHorsTaxe] = @PrixAchatHorsTaxe
      ,[MontantTva] = @MontantTva
      ,[ObjetFacture] = @ObjetFacture
      ,[NumeroOrdre] = @numeroOrdre
 WHERE [Id] = @Id
";

        public const string QueryDelete = @"
DELETE FROM [LigneBc] WHERE [Id] = @No";
    }
}