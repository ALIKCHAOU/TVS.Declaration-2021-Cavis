namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddF6004ModeleAutorsie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.F6004ModeleAutorsie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocieteNo = c.Int(nullable: false),
                        ExerciceId = c.Int(nullable: false),
                        ActeDeDepot = c.Int(nullable: false),
                        NatureDepot = c.String(maxLength: 1),
                        F60040001 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040002 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040003 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040004 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040005 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040006 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040007 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040008 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040009 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040010 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040011 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040012 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040013 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040014 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040015 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040016 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040017 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040018 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040019 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040020 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040021 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040022 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040023 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040024 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040025 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040026 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60040027 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041001 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041002 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041003 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041004 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041005 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041006 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041007 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041008 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041009 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041010 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041011 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041012 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041013 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041014 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041015 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041016 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041017 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041018 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041019 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041020 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041021 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041022 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041023 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041024 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041025 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041026 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60041027 = c.Decimal(nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercice", t => t.ExerciceId)
                .ForeignKey("dbo.Societe", t => t.SocieteNo)
                .Index(t => t.SocieteNo)
                .Index(t => t.ExerciceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.F6004ModeleAutorsie", "SocieteNo", "dbo.Societe");
            DropForeignKey("dbo.F6004ModeleAutorsie", "ExerciceId", "dbo.Exercice");
            DropIndex("dbo.F6004ModeleAutorsie", new[] { "ExerciceId" });
            DropIndex("dbo.F6004ModeleAutorsie", new[] { "SocieteNo" });
            DropTable("dbo.F6004ModeleAutorsie");
        }
    }
}
