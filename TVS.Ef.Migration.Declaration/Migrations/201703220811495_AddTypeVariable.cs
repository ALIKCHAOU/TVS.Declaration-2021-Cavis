namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeVariable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CategorieCnss", "TypeVariablePaie", c => c.Int(nullable: false));
            AddColumn("dbo.CategorieCnss", "CodePaie", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CategorieCnss", "CodePaie");
            DropColumn("dbo.CategorieCnss", "TypeVariablePaie");
        }
    }
}
