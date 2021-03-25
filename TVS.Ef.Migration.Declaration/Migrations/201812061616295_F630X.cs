namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class F630X : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.F6301",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocieteNo = c.Int(nullable: false),
                        ExerciceId = c.Int(nullable: false),
                        ActeDeDepot = c.Int(nullable: false),
                        NatureDepot = c.String(maxLength: 1),
                        F63010001 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63010002 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63010003 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63010004 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63010005 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63010006 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63010007 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63010008 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63010009 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63010010 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63010011 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63010012 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63010013 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63010014 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63010015 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63010016 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63010017 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63010018 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63010019 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63011001 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63011002 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63011003 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63011004 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63011005 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63011006 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63011007 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63011008 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63011009 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63011010 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63011011 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63011012 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63011013 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63011014 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63011015 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63011016 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63011017 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63011018 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63011019 = c.Decimal(nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercice", t => t.ExerciceId)
                .ForeignKey("dbo.Societe", t => t.SocieteNo)
                .Index(t => t.SocieteNo)
                .Index(t => t.ExerciceId);
            
            CreateTable(
                "dbo.F6303",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocieteNo = c.Int(nullable: false),
                        ExerciceId = c.Int(nullable: false),
                        ActeDeDepot = c.Int(nullable: false),
                        NatureDepot = c.String(maxLength: 1),
                        F63030001 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63030002 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63030003 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63030004 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63030005 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63030006 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63030007 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63030008 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63030009 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63030010 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63030011 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63030012 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63030013 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63030014 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63030015 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63030016 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63030017 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63030018 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63031001 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63031002 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63031003 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63031004 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63031005 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63031006 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63031007 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63031008 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63031009 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63031010 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63031011 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63031012 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63031013 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63031014 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63031015 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63031016 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63031017 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63031018 = c.Decimal(nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercice", t => t.ExerciceId)
                .ForeignKey("dbo.Societe", t => t.SocieteNo)
                .Index(t => t.SocieteNo)
                .Index(t => t.ExerciceId);
            
            CreateTable(
                "dbo.F6304",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocieteNo = c.Int(nullable: false),
                        ExerciceId = c.Int(nullable: false),
                        ActeDeDepot = c.Int(nullable: false),
                        NatureDepot = c.String(maxLength: 1),
                        F63040001 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040002 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040003 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040004 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040005 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040006 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040007 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040008 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040009 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040010 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040011 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040012 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040013 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040014 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040015 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040016 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040017 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040018 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040019 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040020 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040021 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040022 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040023 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040024 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040025 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63040026 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041001 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041002 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041003 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041004 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041005 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041006 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041007 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041008 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041009 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041010 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041011 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041012 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041013 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041014 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041015 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041016 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041017 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041018 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041019 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041020 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041021 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041022 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041023 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041024 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041025 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F63041026 = c.Decimal(nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercice", t => t.ExerciceId)
                .ForeignKey("dbo.Societe", t => t.SocieteNo)
                .Index(t => t.SocieteNo)
                .Index(t => t.ExerciceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.F6304", "SocieteNo", "dbo.Societe");
            DropForeignKey("dbo.F6304", "ExerciceId", "dbo.Exercice");
            DropForeignKey("dbo.F6303", "SocieteNo", "dbo.Societe");
            DropForeignKey("dbo.F6303", "ExerciceId", "dbo.Exercice");
            DropForeignKey("dbo.F6301", "SocieteNo", "dbo.Societe");
            DropForeignKey("dbo.F6301", "ExerciceId", "dbo.Exercice");
            DropIndex("dbo.F6304", new[] { "ExerciceId" });
            DropIndex("dbo.F6304", new[] { "SocieteNo" });
            DropIndex("dbo.F6303", new[] { "ExerciceId" });
            DropIndex("dbo.F6303", new[] { "SocieteNo" });
            DropIndex("dbo.F6301", new[] { "ExerciceId" });
            DropIndex("dbo.F6301", new[] { "SocieteNo" });
            DropTable("dbo.F6304");
            DropTable("dbo.F6303");
            DropTable("dbo.F6301");
        }
    }
}
