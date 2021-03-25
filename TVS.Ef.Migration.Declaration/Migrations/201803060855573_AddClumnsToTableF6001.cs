namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClumnsToTableF6001 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.F6001", "ActeDeDepot", c => c.Int(nullable: false));
            AddColumn("dbo.F6001", "NatureDepot", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.F6001", "NatureDepot");
            DropColumn("dbo.F6001", "ActeDeDepot");
        }
    }
}
