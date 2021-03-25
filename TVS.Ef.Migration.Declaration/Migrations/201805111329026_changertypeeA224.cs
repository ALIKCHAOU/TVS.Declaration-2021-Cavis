namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changertypeeA224 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T2016Annexe2", "24", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T2016Annexe2", "24", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
