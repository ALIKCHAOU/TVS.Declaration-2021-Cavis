namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChefFamille : DbMigration
    {
        public override void Up()
        {
           AddColumn("dbo.T2016Annexe1", "Cheffamille", c => c.String(nullable: false));
            AddColumn("dbo.T2016Annexe1", "IntereDetectible", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T2016Annexe1", "IntereDetectible");
           DropColumn("dbo.T2016Annexe1", "Cheffamille");
        }
    }
}
