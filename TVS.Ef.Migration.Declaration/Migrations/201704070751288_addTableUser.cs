namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Utilisateur",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Mail = c.String(),
                        Password = c.String(),
                        IsAdmin = c.Int(nullable: false),
                        DecEmp = c.Int(nullable: false),
                        DecEmpAnnexe1 = c.Int(nullable: false),
                        Cnss = c.Int(nullable: false),
                        Vente = c.Int(nullable: false),
                        Achat = c.Int(nullable: false),
                        Virement = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            Sql(@"
INSERT INTO [Utilisateur] 
( Login ,
Password ,
IsAdmin ,
Nom,
Prenom,
Mail,
DecEmp ,
DecEmpAnnexe1 ,
Cnss ,
Vente ,
Achat ,
Virement)
VALUES 
(
'Admin',
'Admin',
1,
'',
'',
'',
1,
1,
1,
1,
1,
1)
");
        }
        
        public override void Down()
        {
            DropTable("dbo.Utilisateur");
        }
    }
}
