namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringchefffamille : DbMigration
    {
        public override void Up()
        {
           // AlterColumn("dbo.T2016Annexe1", "Cheffamille", c => c.String());
        }
        
        public override void Down()
        {
          //  AlterColumn("dbo.T2016Annexe1", "Cheffamille", c => c.Int(nullable: false));
        }
    }
}
