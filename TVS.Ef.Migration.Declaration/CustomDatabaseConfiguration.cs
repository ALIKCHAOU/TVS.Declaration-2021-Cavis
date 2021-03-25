using System;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using TVS.Config;

namespace TVS.Ef.Migration.Declaration
{
    internal sealed class CustomDatabaseConfiguration : DbConfiguration
    {
        public CustomDatabaseConfiguration()
        {
            SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
            SetDefaultConnectionFactory(new CustomConnectionFactory());
            SetDatabaseInitializer(new CustomDatabaseInitializer());
        }

        public CustomDatabaseConfiguration(IGroupConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException("configuration");

            SetDatabaseInitializer(new CustomDatabaseInitializer());
            SetDefaultConnectionFactory(new CustomConnectionFactory(configuration));
        }
    }
}