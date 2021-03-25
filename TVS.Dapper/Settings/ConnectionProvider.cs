using TVS.Core;

namespace TVS.Dapper.Settings
{
    public class ConnectionProvider : IConnectionProvider
    {
        public string ConnectionString { get; set; }
    }
}