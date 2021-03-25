namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddF6002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.F6002",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocieteNo = c.Int(nullable: false),
                        ExerciceId = c.Int(nullable: false),
                        ActeDeDepot = c.Int(nullable: false),
                        NatureDepot = c.String(maxLength: 1),
                        F60020001 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020002 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020003 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020004 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020005 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020006 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020007 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020008 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020009 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020010 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020011 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020012 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020013 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020014 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020015 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020016 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020017 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020018 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020019 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020020 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020021 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020022 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020023 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020024 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020025 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020026 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020027 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020028 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020029 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020030 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020031 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020032 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020033 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020034 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020035 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020036 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020037 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020038 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020039 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020040 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020041 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020042 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020043 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020044 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020045 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020046 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020047 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020048 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020049 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020050 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020051 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020052 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020053 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020054 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020055 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020056 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020057 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020058 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020059 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020060 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020061 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020062 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020063 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020064 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020065 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020066 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020067 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020068 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020069 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020070 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020071 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020072 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020073 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020074 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020075 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020076 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020077 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020078 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020079 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020080 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020081 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020082 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020083 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020084 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020085 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020086 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020087 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020088 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020089 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020090 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020091 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020092 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020093 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020094 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020095 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020096 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020097 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020098 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020099 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020100 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020101 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020102 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020103 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020104 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020105 = c.Decimal(nullable: false, precision: 18, scale: 3),
                        F60020106 = c.Decimal(nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercice", t => t.ExerciceId)
                .ForeignKey("dbo.Societe", t => t.SocieteNo)
                .Index(t => t.SocieteNo)
                .Index(t => t.ExerciceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.F6002", "SocieteNo", "dbo.Societe");
            DropForeignKey("dbo.F6002", "ExerciceId", "dbo.Exercice");
            DropIndex("dbo.F6002", new[] { "ExerciceId" });
            DropIndex("dbo.F6002", new[] { "SocieteNo" });
            DropTable("dbo.F6002");
        }
    }
}
