namespace TVS.Ef.Migration.Declaration
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddConnctionSage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Societe", "ServerName", c => c.String());
            AddColumn("dbo.Societe", "DatabaseName", c => c.String());
            AddColumn("dbo.Societe", "User", c => c.String());
            AddColumn("dbo.Societe", "Password", c => c.String());
            AddColumn("dbo.Societe", "Type", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Societe", "Type");
            DropColumn("dbo.Societe", "Password");
            DropColumn("dbo.Societe", "User");
            DropColumn("dbo.Societe", "DatabaseName");
            DropColumn("dbo.Societe", "ServerName");
        }
    }
}