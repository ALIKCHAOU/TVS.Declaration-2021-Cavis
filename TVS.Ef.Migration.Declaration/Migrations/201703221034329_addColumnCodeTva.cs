namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnCodeTva : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Societe", "MatriculCodeTva", c => c.String(maxLength: 50));
            Sql(@"
UPDATE Societe
SET   [MatriculCodeTva] = 'E'
      ,[MatriculCle] ='A'
      ,[MatriculCategorie] = 'B'
      ,[MatriculEtablissement] = '000'
");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Societe", "MatriculCodeTva");
        }
    }
}
