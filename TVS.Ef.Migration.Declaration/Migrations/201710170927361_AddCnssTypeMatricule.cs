namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCnssTypeMatricule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Societe", "CnssTypeMatricule", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Societe", "CnssTypeMatricule");
        }
    }
}
