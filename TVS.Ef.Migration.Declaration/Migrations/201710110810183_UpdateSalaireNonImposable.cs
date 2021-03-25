namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSalaireNonImposable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T2016Annexe1", "SalaireNonImposable", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T2016Annexe1", "SalaireNonImposable", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
