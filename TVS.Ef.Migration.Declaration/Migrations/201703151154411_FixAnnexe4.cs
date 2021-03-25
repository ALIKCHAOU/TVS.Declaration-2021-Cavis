namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class FixAnnexe4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T2016Annexe4", "221", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.T2016Annexe4", "222", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.T2016Annexe4", "223", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            DropColumn("dbo.T2016Annexe4", "22");
        }

        public override void Down()
        {
            AddColumn("dbo.T2016Annexe4", "22", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            DropColumn("dbo.T2016Annexe4", "223");
            DropColumn("dbo.T2016Annexe4", "222");
            DropColumn("dbo.T2016Annexe4", "221");
        }
    }
}