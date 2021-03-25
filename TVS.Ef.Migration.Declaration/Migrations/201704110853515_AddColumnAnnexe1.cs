namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnAnnexe1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T2016Annexe1", "RetenueUnPrct", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AddColumn("dbo.T2016Annexe1", "ContributionConjoncturelle", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T2016Annexe1", "ContributionConjoncturelle");
            DropColumn("dbo.T2016Annexe1", "RetenueUnPrct");
        }
    }
}
