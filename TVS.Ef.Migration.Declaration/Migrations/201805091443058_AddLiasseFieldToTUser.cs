namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLiasseFieldToTUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilisateur", "Liasse", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilisateur", "Liasse");
        }
    }
}
