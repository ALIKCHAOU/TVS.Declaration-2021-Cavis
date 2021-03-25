using System;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using TVS.Config;

namespace TVS.Ef.Migration.Declaration
{
    internal sealed class CustomConnectionFactory : IDbConnectionFactory
    {
        private readonly IGroupConfiguration _configuration;

        public CustomConnectionFactory()
        {
            _configuration =
                new MigrationGroupConfiguration
                {
                    Server = @".",
                    Database = "DeclarationTvs",
                    IsWinAuthentification = true,
                    User = "sa",
                    Password = "Admin123"
                };
        }

        public CustomConnectionFactory(IGroupConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException("configuration");

            _configuration = configuration;
            var c = configuration as MigrationGroupConfiguration;
        }

        public DbConnection CreateConnection(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = _configuration.Server,
                InitialCatalog = _configuration.Database,
                IntegratedSecurity = _configuration.IsWinAuthentification,
                UserID = _configuration.User ?? string.Empty,
                Password = _configuration.Password ?? string.Empty
            };

            return new SqlConnection(builder.ConnectionString);
        }
    }
}