namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Exercice",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Annee = c.String(nullable: false),
                        IsArchive = c.Boolean(nullable: false),
                        IsCloturer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Societe",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RaisonSocial = c.String(maxLength: 50),
                        Activite = c.String(maxLength: 250),
                        Adresse = c.String(maxLength: 250),
                        CodePostal = c.String(maxLength: 10),
                        Ville = c.String(maxLength: 50),
                        Pays = c.String(maxLength: 50),
                        NumeroEmployeur = c.String(maxLength: 8),
                        CleEmployeur = c.String(maxLength: 2),
                        MatriculFiscal = c.String(maxLength: 50),
                        MatriculCle = c.String(maxLength: 50),
                        MatriculCategorie = c.String(maxLength: 50),
                        MatriculEtablissement = c.String(maxLength: 50),
                        CodeBureau = c.String(maxLength: 2),
                        CurrentExerciceNo = c.Int(),
                        RibSociete = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercice", t => t.CurrentExerciceNo)
                .Index(t => t.CurrentExerciceNo);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Societe", "CurrentExerciceNo", "dbo.Exercice");
            DropIndex("dbo.Societe", new[] {"CurrentExerciceNo"});
            DropTable("dbo.Societe");
            DropTable("dbo.Exercice");
        }
    }
}