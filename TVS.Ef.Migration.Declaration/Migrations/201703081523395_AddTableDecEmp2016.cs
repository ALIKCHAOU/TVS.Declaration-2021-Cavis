namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddTableDecEmp2016 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.T2016Annexe1",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocieteId = c.Int(nullable: false),
                        ExerciceId = c.Int(nullable: false),
                        _06 = c.Int(name: "06", nullable: false),
                        _07 = c.Int(name: "07", nullable: false),
                        _08 = c.String(name: "08"),
                        _09 = c.String(name: "09"),
                        _10 = c.String(name: "10"),
                        _11 = c.String(name: "11"),
                        _12 = c.Int(name: "12", nullable: false),
                        _13 = c.Int(name: "13", nullable: false),
                        _14 = c.DateTime(name: "14", nullable: false),
                        _15 = c.DateTime(name: "15", nullable: false),
                        _16 = c.Int(name: "16", nullable: false),
                        _17 = c.Decimal(name: "17", nullable: false, precision: 18, scale: 3),
                        _18 = c.Decimal(name: "18", nullable: false, precision: 18, scale: 3),
                        _19 = c.Decimal(name: "19", nullable: false, precision: 18, scale: 3),
                        _20 = c.Decimal(name: "20", nullable: false, precision: 18, scale: 3),
                        _21 = c.Decimal(name: "21", nullable: false, precision: 18, scale: 3),
                        _22 = c.Decimal(name: "22", nullable: false, precision: 18, scale: 3),
                        _23 = c.Decimal(name: "23", nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercice", t => t.ExerciceId)
                .ForeignKey("dbo.Societe", t => t.SocieteId)
                .Index(t => t.SocieteId)
                .Index(t => t.ExerciceId);

            CreateTable(
                    "dbo.T2016Annexe2",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocieteId = c.Int(nullable: false),
                        ExerciceId = c.Int(nullable: false),
                        _06 = c.Int(name: "06", nullable: false),
                        _07 = c.Int(name: "07", nullable: false),
                        _08 = c.String(name: "08"),
                        _09 = c.String(name: "09"),
                        _10 = c.String(name: "10"),
                        _11 = c.String(name: "11"),
                        _12 = c.Int(name: "12", nullable: false),
                        _13 = c.Decimal(name: "13", nullable: false, precision: 18, scale: 3),
                        _14 = c.Decimal(name: "14", nullable: false, precision: 18, scale: 3),
                        _15 = c.Decimal(name: "15", nullable: false, precision: 18, scale: 3),
                        _16 = c.Decimal(name: "16", nullable: false, precision: 18, scale: 3),
                        _17 = c.Decimal(name: "17", nullable: false, precision: 18, scale: 3),
                        _18 = c.Decimal(name: "18", nullable: false, precision: 18, scale: 3),
                        _19 = c.Decimal(name: "19", nullable: false, precision: 18, scale: 3),
                        _20 = c.Decimal(name: "20", nullable: false, precision: 18, scale: 3),
                        _21 = c.Int(name: "21", nullable: false),
                        _22 = c.Decimal(name: "22", nullable: false, precision: 18, scale: 3),
                        _23 = c.Decimal(name: "23", nullable: false, precision: 18, scale: 3),
                        _24 = c.Decimal(name: "24", nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercice", t => t.ExerciceId)
                .ForeignKey("dbo.Societe", t => t.SocieteId)
                .Index(t => t.SocieteId)
                .Index(t => t.ExerciceId);

            CreateTable(
                    "dbo.T2016Annexe3",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocieteId = c.Int(nullable: false),
                        ExerciceId = c.Int(nullable: false),
                        _06 = c.Int(name: "06", nullable: false),
                        _07 = c.Int(name: "07", nullable: false),
                        _08 = c.String(name: "08"),
                        _09 = c.String(name: "09"),
                        _10 = c.String(name: "10"),
                        _11 = c.String(name: "11"),
                        _12 = c.Decimal(name: "12", nullable: false, precision: 18, scale: 3),
                        _13 = c.Decimal(name: "13", nullable: false, precision: 18, scale: 3),
                        _14 = c.Decimal(name: "14", nullable: false, precision: 18, scale: 3),
                        _15 = c.Decimal(name: "15", nullable: false, precision: 18, scale: 3),
                        _16 = c.Decimal(name: "16", nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercice", t => t.ExerciceId)
                .ForeignKey("dbo.Societe", t => t.SocieteId)
                .Index(t => t.SocieteId)
                .Index(t => t.ExerciceId);

            CreateTable(
                    "dbo.T2016Annexe4",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocieteId = c.Int(nullable: false),
                        ExerciceId = c.Int(nullable: false),
                        _06 = c.Int(name: "06", nullable: false),
                        _07 = c.Int(name: "07", nullable: false),
                        _08 = c.String(name: "08"),
                        _09 = c.String(name: "09"),
                        _10 = c.String(name: "10"),
                        _11 = c.String(name: "11"),
                        _12 = c.Int(name: "12", nullable: false),
                        _13 = c.Decimal(name: "13", nullable: false, precision: 18, scale: 3),
                        _14 = c.Decimal(name: "14", nullable: false, precision: 18, scale: 3),
                        _15 = c.Decimal(name: "15", nullable: false, precision: 18, scale: 3),
                        _16 = c.Decimal(name: "16", nullable: false, precision: 18, scale: 3),
                        _17 = c.Decimal(name: "17", nullable: false, precision: 18, scale: 3),
                        _18 = c.Decimal(name: "18", nullable: false, precision: 18, scale: 3),
                        _19 = c.Decimal(name: "19", nullable: false, precision: 18, scale: 3),
                        _20 = c.Decimal(name: "20", nullable: false, precision: 18, scale: 3),
                        _21 = c.Int(name: "21", nullable: false),
                        _22 = c.Decimal(name: "22", nullable: false, precision: 18, scale: 3),
                        _23 = c.Int(name: "23", nullable: false),
                        _24 = c.Decimal(name: "24", nullable: false, precision: 18, scale: 3),
                        _25 = c.Decimal(name: "25", nullable: false, precision: 18, scale: 3),
                        _26 = c.Decimal(name: "26", nullable: false, precision: 18, scale: 3),
                        _27 = c.Decimal(name: "27", nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercice", t => t.ExerciceId)
                .ForeignKey("dbo.Societe", t => t.SocieteId)
                .Index(t => t.SocieteId)
                .Index(t => t.ExerciceId);

            CreateTable(
                    "dbo.T2016Annexe5",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocieteId = c.Int(nullable: false),
                        ExerciceId = c.Int(nullable: false),
                        _06 = c.Int(name: "06", nullable: false),
                        _07 = c.Int(name: "07", nullable: false),
                        _08 = c.String(name: "08"),
                        _09 = c.String(name: "09"),
                        _10 = c.String(name: "10"),
                        _11 = c.String(name: "11"),
                        _12 = c.Decimal(name: "12", nullable: false, precision: 18, scale: 3),
                        _13 = c.Decimal(name: "13", nullable: false, precision: 18, scale: 3),
                        _14 = c.Decimal(name: "14", nullable: false, precision: 18, scale: 3),
                        _15 = c.Decimal(name: "15", nullable: false, precision: 18, scale: 3),
                        _16 = c.Decimal(name: "16", nullable: false, precision: 18, scale: 3),
                        _17 = c.Decimal(name: "17", nullable: false, precision: 18, scale: 3),
                        _18 = c.Decimal(name: "18", nullable: false, precision: 18, scale: 3),
                        _19 = c.Decimal(name: "19", nullable: false, precision: 18, scale: 3),
                        _20 = c.Decimal(name: "20", nullable: false, precision: 18, scale: 3),
                        _21 = c.Decimal(name: "21", nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercice", t => t.ExerciceId)
                .ForeignKey("dbo.Societe", t => t.SocieteId)
                .Index(t => t.SocieteId)
                .Index(t => t.ExerciceId);

            CreateTable(
                    "dbo.T2016Annexe6",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocieteId = c.Int(nullable: false),
                        ExerciceId = c.Int(nullable: false),
                        _06 = c.Int(name: "06", nullable: false),
                        _07 = c.Int(name: "07", nullable: false),
                        _08 = c.String(name: "08"),
                        _09 = c.String(name: "09"),
                        _10 = c.String(name: "10"),
                        _11 = c.String(name: "11"),
                        _12 = c.Decimal(name: "12", nullable: false, precision: 18, scale: 3),
                        _13 = c.Decimal(name: "13", nullable: false, precision: 18, scale: 3),
                        _14 = c.Decimal(name: "14", nullable: false, precision: 18, scale: 3),
                        _15 = c.Decimal(name: "15", nullable: false, precision: 18, scale: 3),
                        _16 = c.Decimal(name: "16", nullable: false, precision: 18, scale: 3),
                        _17 = c.Decimal(name: "17", nullable: false, precision: 18, scale: 3),
                        _18 = c.Decimal(name: "18", nullable: false, precision: 18, scale: 3),
                        _19 = c.Decimal(name: "19", nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercice", t => t.ExerciceId)
                .ForeignKey("dbo.Societe", t => t.SocieteId)
                .Index(t => t.SocieteId)
                .Index(t => t.ExerciceId);

            CreateTable(
                    "dbo.T2016Annexe7",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocieteId = c.Int(nullable: false),
                        ExerciceId = c.Int(nullable: false),
                        _06 = c.Int(name: "06", nullable: false),
                        _07 = c.Int(name: "07", nullable: false),
                        _08 = c.String(name: "08"),
                        _09 = c.String(name: "09"),
                        _10 = c.String(name: "10"),
                        _11 = c.String(name: "11"),
                        _12 = c.Int(name: "12", nullable: false),
                        _13 = c.Decimal(name: "13", nullable: false, precision: 18, scale: 3),
                        _14 = c.Decimal(name: "14", nullable: false, precision: 18, scale: 3),
                        _15 = c.Decimal(name: "15", nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercice", t => t.ExerciceId)
                .ForeignKey("dbo.Societe", t => t.SocieteId)
                .Index(t => t.SocieteId)
                .Index(t => t.ExerciceId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.T2016Annexe7", "SocieteId", "dbo.Societe");
            DropForeignKey("dbo.T2016Annexe7", "ExerciceId", "dbo.Exercice");
            DropForeignKey("dbo.T2016Annexe6", "SocieteId", "dbo.Societe");
            DropForeignKey("dbo.T2016Annexe6", "ExerciceId", "dbo.Exercice");
            DropForeignKey("dbo.T2016Annexe5", "SocieteId", "dbo.Societe");
            DropForeignKey("dbo.T2016Annexe5", "ExerciceId", "dbo.Exercice");
            DropForeignKey("dbo.T2016Annexe4", "SocieteId", "dbo.Societe");
            DropForeignKey("dbo.T2016Annexe4", "ExerciceId", "dbo.Exercice");
            DropForeignKey("dbo.T2016Annexe3", "SocieteId", "dbo.Societe");
            DropForeignKey("dbo.T2016Annexe3", "ExerciceId", "dbo.Exercice");
            DropForeignKey("dbo.T2016Annexe2", "SocieteId", "dbo.Societe");
            DropForeignKey("dbo.T2016Annexe2", "ExerciceId", "dbo.Exercice");
            DropForeignKey("dbo.T2016Annexe1", "SocieteId", "dbo.Societe");
            DropForeignKey("dbo.T2016Annexe1", "ExerciceId", "dbo.Exercice");
            DropIndex("dbo.T2016Annexe7", new[] {"ExerciceId"});
            DropIndex("dbo.T2016Annexe7", new[] {"SocieteId"});
            DropIndex("dbo.T2016Annexe6", new[] {"ExerciceId"});
            DropIndex("dbo.T2016Annexe6", new[] {"SocieteId"});
            DropIndex("dbo.T2016Annexe5", new[] {"ExerciceId"});
            DropIndex("dbo.T2016Annexe5", new[] {"SocieteId"});
            DropIndex("dbo.T2016Annexe4", new[] {"ExerciceId"});
            DropIndex("dbo.T2016Annexe4", new[] {"SocieteId"});
            DropIndex("dbo.T2016Annexe3", new[] {"ExerciceId"});
            DropIndex("dbo.T2016Annexe3", new[] {"SocieteId"});
            DropIndex("dbo.T2016Annexe2", new[] {"ExerciceId"});
            DropIndex("dbo.T2016Annexe2", new[] {"SocieteId"});
            DropIndex("dbo.T2016Annexe1", new[] {"ExerciceId"});
            DropIndex("dbo.T2016Annexe1", new[] {"SocieteId"});
            DropTable("dbo.T2016Annexe7");
            DropTable("dbo.T2016Annexe6");
            DropTable("dbo.T2016Annexe5");
            DropTable("dbo.T2016Annexe4");
            DropTable("dbo.T2016Annexe3");
            DropTable("dbo.T2016Annexe2");
            DropTable("dbo.T2016Annexe1");
        }
    }
}