using TVS.Core;

namespace TVS.Dapper.Settings
{
    public abstract class BaseRepository
    {
        private readonly IConnectionProvider _connectionProvider;

        protected BaseRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        protected string ConnectionString
        {
            get { return _connectionProvider.ConnectionString; }
        }

        protected IConnectionProvider ConnectionProvider
        {
            get { return _connectionProvider; }
        }
    }
}