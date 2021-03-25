namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnNumAutorisation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeclarationBcSuspenssion", "NumeroAutorisation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeclarationBcSuspenssion", "NumeroAutorisation");
        }
    }
}
