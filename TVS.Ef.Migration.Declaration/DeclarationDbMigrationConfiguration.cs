using System.Data.Entity.Migrations;

namespace TVS.Ef.Migration.Declaration
{
    internal sealed class DeclarationDbMigrationConfiguration : DbMigrationsConfiguration<DeclarationContext>
    {
        public DeclarationDbMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            //  MigrationsNamespace=  "CoreDeclaration";
            //////var y = MigrationsDirectory;//= "My/Migrations/Directory";
            //  ContextKey = "CoreDeclarationn.DeclarationDbMigrationConfiguration";
        }

        protected override void Seed(DeclarationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}