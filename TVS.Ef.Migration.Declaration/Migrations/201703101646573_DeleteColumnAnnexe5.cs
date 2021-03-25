namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class DeleteColumnAnnexe5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.T2016Annexe5", "21");
        }

        public override void Down()
        {
            AddColumn("dbo.T2016Annexe5", "21", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
    }
}