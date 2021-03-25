namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumnNetAPaye : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VirementLigne", "NetAPaye", c => c.Decimal(nullable: false, precision: 24, scale: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VirementLigne", "NetAPaye", c => c.Decimal(nullable: false, precision: 24, scale: 6));
        }
    }
}
