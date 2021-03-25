using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using TVS.Config;

namespace TVS.Ef.Migration.Declaration
{
    public class GroupContextFactory : IGroupContextManager
    {
        private DeclarationContext _context;

        public GroupContextFactory(IGroupConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException("configuration");

            DbConfiguration.SetConfiguration(new CustomDatabaseConfiguration(configuration));
        }

        public void ChangeGroupConfiguration(IGroupConfiguration configuration)
        {
            DbConfiguration.SetConfiguration(new CustomDatabaseConfiguration(configuration));
        }

        public bool DatabaseCompatibleWithModel()
        {
            using (var context = new DeclarationContext())
            {
                if (!context.Database.Exists())
                    throw new InvalidOperationException("Database does not exist!");

                return context.Database.CompatibleWithModel(true);
            }
        }

        public bool DatabaseExists()
        {
            using (var context = new DeclarationContext())
            {
                return context.Database.Exists();
            }
        }

        public void DatabaseInitialize()
        {
            using (var context = new DeclarationContext())
            {
                context.Database.Initialize(false);
            }
        }

        public bool HasPendingMigration()
        {
            return new DbMigrator(new DeclarationDbMigrationConfiguration())
                .GetPendingMigrations()
                .Any();
        }

        public DeclarationContext Context
        {
            get
            {
                //if (_context != null)
                //{
                //    return _context;
                //}
                _context = new DeclarationContext();
                _context.Configuration.LazyLoadingEnabled = true;
                _context.Configuration.ValidateOnSaveEnabled = true;
                //_context.Database.CommandTimeout = 180;
                return _context;
            }
        }
    }
}