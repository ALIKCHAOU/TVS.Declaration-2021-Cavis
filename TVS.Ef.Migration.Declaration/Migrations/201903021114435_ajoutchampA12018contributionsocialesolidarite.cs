namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajoutchampA12018contributionsocialesolidarite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T2016Annexe1", "ContributionSocialeSolidarite", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T2016Annexe1", "ContributionSocialeSolidarite");
        }
    }
}
