namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableUserSociete : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UtilisateurSociete",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        IdSociete = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UtilisateurSociete");
        }
    }
}
