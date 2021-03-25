namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddTablesDeclarationSuspension : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.CategorieCnss",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocieteNo = c.Int(nullable: false),
                        No = c.Int(nullable: false),
                        Intitule = c.String(maxLength: 100),
                        CodeExploitation = c.String(maxLength: 4),
                        TauxSalarial = c.Decimal(nullable: false, precision: 24, scale: 6),
                        TauxPatronal = c.Decimal(nullable: false, precision: 24, scale: 6),
                        AccidentTravail = c.Decimal(nullable: false, precision: 24, scale: 6),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Societe", t => t.SocieteNo, cascadeDelete: true)
                .Index(t => t.SocieteNo);

            CreateTable(
                    "dbo.Employee",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocieteNo = c.Int(nullable: false),
                        Nom = c.String(nullable: false),
                        Prenom = c.String(nullable: false),
                        NomJeuneFille = c.String(nullable: false),
                        Cin = c.String(nullable: false),
                        SituationFamille = c.Int(nullable: false),
                        Civilite = c.Int(nullable: false),
                        NumeroCnss = c.String(nullable: false),
                        CleCnss = c.String(nullable: false),
                        CategorieNo = c.Int(nullable: false),
                        NumeroInterne = c.String(nullable: false),
                        AutresNom = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategorieCnss", t => t.CategorieNo)
                .ForeignKey("dbo.Societe", t => t.SocieteNo, cascadeDelete: true)
                .Index(t => t.SocieteNo)
                .Index(t => t.CategorieNo);

            CreateTable(
                    "dbo.DeclarationBcSuspenssion",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExerciceId = c.Int(nullable: false),
                        SocieteId = c.Int(nullable: false),
                        Trimestre = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsCloture = c.Boolean(nullable: false),
                        IsArchive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercice", t => t.ExerciceId, cascadeDelete: true)
                .ForeignKey("dbo.Societe", t => t.SocieteId, cascadeDelete: true)
                .Index(t => t.ExerciceId)
                .Index(t => t.SocieteId);

            CreateTable(
                    "dbo.LigneBc",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeclarationNo = c.Int(nullable: false),
                        NumeroOrdre = c.Int(nullable: false),
                        NumeroAutorisation = c.String(),
                        NumeroBonCommande = c.String(nullable: false),
                        DateBonCommande = c.DateTime(nullable: false),
                        NumeroFacture = c.String(nullable: false),
                        DateFacture = c.DateTime(nullable: false),
                        Identifiant = c.String(nullable: false),
                        RaisonSocialFournisseur = c.String(nullable: false),
                        PrixAchatHorsTaxe = c.Decimal(nullable: false, precision: 24, scale: 6),
                        MontantTva = c.Decimal(nullable: false, precision: 24, scale: 6),
                        ObjetFacture = c.String(),
                        SocieteNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeclarationBcSuspenssion", t => t.DeclarationNo, cascadeDelete: true)
                .Index(t => t.DeclarationNo);

            CreateTable(
                    "dbo.DeclarationCnss",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExerciceId = c.Int(nullable: false),
                        SocieteId = c.Int(nullable: false),
                        Trimestre = c.Int(nullable: false),
                        Complementaire = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsCloture = c.Boolean(nullable: false),
                        IsArchive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercice", t => t.ExerciceId, cascadeDelete: true)
                .ForeignKey("dbo.Societe", t => t.SocieteId, cascadeDelete: true)
                .Index(t => t.ExerciceId)
                .Index(t => t.SocieteId);

            CreateTable(
                    "dbo.LigneCnss",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Page = c.Int(),
                        Ligne = c.Int(),
                        Brut1 = c.Decimal(nullable: false, precision: 24, scale: 6),
                        Brut2 = c.Decimal(nullable: false, precision: 24, scale: 6),
                        Brut3 = c.Decimal(nullable: false, precision: 24, scale: 6),
                        EmployeeNo = c.Int(nullable: false),
                        DeclarationNo = c.Int(nullable: false),
                        CategorieNo = c.Int(nullable: false),
                        SocieteNo = c.Int(nullable: false),
                        CleCnss = c.String(nullable: false),
                        NumeroCnss = c.String(nullable: false),
                        Cin = c.String(nullable: false),
                        Nom = c.String(nullable: false),
                        Prenom = c.String(nullable: false),
                        AutresNom = c.String(nullable: false),
                        NomJeuneFille = c.String(nullable: false),
                        CodeExploitation = c.String(nullable: false, maxLength: 4),
                        Civilite = c.Int(nullable: false),
                        NumeroInterne = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategorieCnss", t => t.CategorieNo)
                .ForeignKey("dbo.DeclarationCnss", t => t.DeclarationNo, cascadeDelete: true)
                .Index(t => t.DeclarationNo)
                .Index(t => t.CategorieNo);

            CreateTable(
                    "dbo.DeclarationFactureSuspenssion",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExerciceId = c.Int(nullable: false),
                        SocieteId = c.Int(nullable: false),
                        Trimestre = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsCloture = c.Boolean(nullable: false),
                        IsArchive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercice", t => t.ExerciceId, cascadeDelete: true)
                .ForeignKey("dbo.Societe", t => t.SocieteId, cascadeDelete: true)
                .Index(t => t.ExerciceId)
                .Index(t => t.SocieteId);

            CreateTable(
                    "dbo.LigneFacture",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeclarationNo = c.Int(nullable: false),
                        NumeroOrdre = c.Int(nullable: false),
                        NumeroFacture = c.String(nullable: false),
                        DateFacture = c.DateTime(nullable: false),
                        TypeClient = c.Int(nullable: false),
                        IdentifiantClient = c.String(nullable: false),
                        NomPrenomClient = c.String(nullable: false),
                        AdresseClient = c.String(nullable: false),
                        NumeroAutorisation = c.String(nullable: false),
                        DateAutorisation = c.DateTime(nullable: false),
                        PrixVenteHt = c.Decimal(nullable: false, precision: 24, scale: 6),
                        TauxFodec = c.Decimal(nullable: false, precision: 24, scale: 6),
                        MontantFodec = c.Decimal(nullable: false, precision: 24, scale: 6),
                        TauxDroitConsommation = c.Decimal(nullable: false, precision: 24, scale: 6),
                        MontantDroitConsommation = c.Decimal(nullable: false, precision: 24, scale: 6),
                        TauxTva = c.Decimal(nullable: false, precision: 24, scale: 6),
                        MontantTva = c.Decimal(nullable: false, precision: 24, scale: 6),
                        SocieteNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeclarationFactureSuspenssion", t => t.DeclarationNo, cascadeDelete: true)
                .Index(t => t.DeclarationNo);
        }

        public override void Down()
        {
            DropForeignKey("dbo.CategorieCnss", "SocieteNo", "dbo.Societe");
            DropForeignKey("dbo.Employee", "SocieteNo", "dbo.Societe");
            DropForeignKey("dbo.DeclarationFactureSuspenssion", "SocieteId", "dbo.Societe");
            DropForeignKey("dbo.LigneFacture", "DeclarationNo", "dbo.DeclarationFactureSuspenssion");
            DropForeignKey("dbo.DeclarationFactureSuspenssion", "ExerciceId", "dbo.Exercice");
            DropForeignKey("dbo.DeclarationCnss", "SocieteId", "dbo.Societe");
            DropForeignKey("dbo.LigneCnss", "DeclarationNo", "dbo.DeclarationCnss");
            DropForeignKey("dbo.LigneCnss", "CategorieNo", "dbo.CategorieCnss");
            DropForeignKey("dbo.DeclarationCnss", "ExerciceId", "dbo.Exercice");
            DropForeignKey("dbo.DeclarationBcSuspenssion", "SocieteId", "dbo.Societe");
            DropForeignKey("dbo.LigneBc", "DeclarationNo", "dbo.DeclarationBcSuspenssion");
            DropForeignKey("dbo.DeclarationBcSuspenssion", "ExerciceId", "dbo.Exercice");
            DropForeignKey("dbo.Employee", "CategorieNo", "dbo.CategorieCnss");
            DropIndex("dbo.LigneFacture", new[] {"DeclarationNo"});
            DropIndex("dbo.DeclarationFactureSuspenssion", new[] {"SocieteId"});
            DropIndex("dbo.DeclarationFactureSuspenssion", new[] {"ExerciceId"});
            DropIndex("dbo.LigneCnss", new[] {"CategorieNo"});
            DropIndex("dbo.LigneCnss", new[] {"DeclarationNo"});
            DropIndex("dbo.DeclarationCnss", new[] {"SocieteId"});
            DropIndex("dbo.DeclarationCnss", new[] {"ExerciceId"});
            DropIndex("dbo.LigneBc", new[] {"DeclarationNo"});
            DropIndex("dbo.DeclarationBcSuspenssion", new[] {"SocieteId"});
            DropIndex("dbo.DeclarationBcSuspenssion", new[] {"ExerciceId"});
            DropIndex("dbo.Employee", new[] {"CategorieNo"});
            DropIndex("dbo.Employee", new[] {"SocieteNo"});
            DropIndex("dbo.CategorieCnss", new[] {"SocieteNo"});
            DropTable("dbo.LigneFacture");
            DropTable("dbo.DeclarationFactureSuspenssion");
            DropTable("dbo.LigneCnss");
            DropTable("dbo.DeclarationCnss");
            DropTable("dbo.LigneBc");
            DropTable("dbo.DeclarationBcSuspenssion");
            DropTable("dbo.Employee");
            DropTable("dbo.CategorieCnss");
        }
    }
}