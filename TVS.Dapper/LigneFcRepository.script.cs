using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Dapper
{
    public partial class LigneFcRepository
    {
        public const string QueryGet = @"
SELECT [Id]
      ,[DeclarationNo]
      ,[NumeroOrdre]
      ,[NumeroFacture]
      ,[DateFacture]
      ,[TypeClient]
      ,[IdentifiantClient]
      ,[NomPrenomClient]
      ,[AdresseClient]
      ,[NumeroAutorisation]
      ,[DateAutorisation]
      ,[PrixVenteHt]
      ,[TauxFodec]
      ,[MontantFodec]
      ,[TauxDroitConsommation]
      ,[MontantDroitConsommation]
      ,[TauxTva]
      ,[MontantTva]
      ,[SocieteNo]
  FROM [LigneFacture]";

        public const string QueryInsert = @"
INSERT INTO [LigneFacture]
           ([DeclarationNo]
           ,[NumeroOrdre]
           ,[NumeroFacture]
           ,[DateFacture]
           ,[TypeClient]
           ,[IdentifiantClient]
           ,[NomPrenomClient]
           ,[AdresseClient]
           ,[NumeroAutorisation]
           ,[DateAutorisation]
           ,[PrixVenteHt]
           ,[TauxFodec]
           ,[MontantFodec]
           ,[TauxDroitConsommation]
           ,[MontantDroitConsommation]
           ,[TauxTva]
           ,[MontantTva]
           ,[SocieteNo])
     VALUES
           (@DeclarationNo
           ,@NumeroOrdre
           ,@NumeroFacture
           ,@DateFacture
           ,@TypeClient
           ,@IdentifiantClient
           ,@NomPrenomClient
           ,@AdresseClient
           ,@NumeroAutorisation
           ,@DateAutorisation
           ,@PrixVenteHt
           ,@TauxFodec
           ,@MontantFodec
           ,@TauxDroitConsommation
           ,@MontantDroitConsommation
           ,@TauxTva
           ,@MontantTva
           ,@SocieteNo);

SELECT SCOPE_IDENTITY();
";

        public const string QueryUpdate = @"
UPDATE [LigneFacture]
   SET [DeclarationNo] = @DeclarationNo
      ,[NumeroOrdre] = @NumeroOrdre
      ,[NumeroFacture] = @NumeroFacture
      ,[DateFacture] = @DateFacture
      ,[TypeClient] = @TypeClient
      ,[IdentifiantClient] = @IdentifiantClient
      ,[NomPrenomClient] = @NomPrenomClient
      ,[AdresseClient] = @AdresseClient
      ,[NumeroAutorisation] = @NumeroAutorisation
      ,[DateAutorisation] = @DateAutorisation
      ,[PrixVenteHt] = @PrixVenteHt
      ,[TauxFodec] = @TauxFodec
      ,[MontantFodec] = @MontantFodec
      ,[TauxDroitConsommation] = @TauxDroitConsommation
      ,[MontantDroitConsommation] = @MontantDroitConsommation
      ,[TauxTva] = @TauxTva
      ,[MontantTva] = @MontantTva
      ,[SocieteNo] = @SocieteNo
 WHERE  [Id] = @Id
";

        public const string QueryDelete = @"
DELETE FROM [LigneFacture] WHERE [Id] = @No";
    }
}