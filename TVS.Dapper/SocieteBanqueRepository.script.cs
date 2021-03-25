using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Dapper
{
    public partial class SocieteBanqueRepository
    {
        private const string QueryGet = @"SELECT  [Id]
        ,SocieteId 
        ,Banque 
        ,Agence 
        ,Adresse 
        ,Rib
FROM [SocieteBanque]";

        private const string QueryInsert = @"
INSERT INTO [dbo].[SocieteBanque]
           (SocieteId 
            ,Banque 
            ,Agence 
            ,Adresse 
            ,Rib)
     VALUES
           (@SocieteId 
            ,@Banque 
            ,@Agence 
            ,@Adresse 
            ,@Rib
);

SELECT SCOPE_IDENTITY();";

        private const string QueryUpdate = @"
UPDATE [SocieteBanque]
   SET Agence = @Agence
       ,Adresse = @Adresse
       ,Rib = @Rib
   WHERE [Id] = @Id
 ";
        private const string QueryDelete = @" DELETE FROM SocieteBanque WHERE Id = @No ";
    }
}
