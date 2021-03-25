namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableVirement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SocieteBanque",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocieteId = c.Int(nullable: false),
                        Banque = c.Int(nullable: false),
                        Agence = c.String(),
                        Adresse = c.String(),
                        Rib = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VirementEntete",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateEcheance = c.DateTime(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        ReferenceEnvoi = c.String(),
                        MotifOperation = c.String(),
                        Cloturer = c.Boolean(nullable: false),
                        Archiver = c.Boolean(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 24, scale: 6),
                        NombreTotal = c.Int(nullable: false),
                        BanqueId = c.Int(nullable: false),
                        Banque = c.Int(nullable: false),
                        Rib = c.String(),
                        SocieteId = c.Int(nullable: false),
                        ExerciceId = c.Int(nullable: false),
                        Exercice = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VirementLigne",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnteteId = c.Int(nullable: false),
                        Matricule = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        NomBanque = c.String(),
                        CodeBanque = c.String(),
                        CodeGuichet = c.String(),
                        NumeroCompte = c.String(),
                        CleRib = c.String(),
                        NetAPaye = c.Decimal(nullable: false, precision: 24, scale: 6),
                        Motif = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VirementEntete", t => t.EnteteId, cascadeDelete: true)
                .Index(t => t.EnteteId);
            
            DropColumn("dbo.Societe", "RibSociete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Societe", "RibSociete", c => c.String());
            DropForeignKey("dbo.VirementLigne", "EnteteId", "dbo.VirementEntete");
            DropIndex("dbo.VirementLigne", new[] { "EnteteId" });
            DropTable("dbo.VirementLigne");
            DropTable("dbo.VirementEntete");
            DropTable("dbo.SocieteBanque");
        }
    }
}
