using TVS.Core;

namespace TVS.Dapper.Settings
{
    public interface IRepositoryFactory
    {
        T Create<T>() where T : BaseRepository;
    }
}