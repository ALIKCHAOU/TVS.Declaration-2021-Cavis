namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateF6005 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.F6005", "F60050001", c => c.String());
            AlterColumn("dbo.F6005", "F60051001", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.F6005", "F60051001", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.F6005", "F60050001", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
    }
}
