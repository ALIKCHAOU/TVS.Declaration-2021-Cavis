namespace TVS.Declaration.Settings
{
    public interface IConfigurationRepository<T>
    {
        void Save(T config, string path);

        T Load(string path);
    }
}