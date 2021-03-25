using System;

namespace TVS.Declaration.Settings
{
    public class AppConfiguration
    {
        private readonly IConfigurationRepository<GroupConfiguration> _repository;
        private GroupConfiguration _configuration;

        public AppConfiguration(IConfigurationRepository<GroupConfiguration> repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            _repository = repository;
        }

        /// <summary>
        ///     Renvoie la configuration en cours
        /// </summary>
        /// <returns></returns>
        public GroupConfiguration Get()
        {
            return _configuration;
        }

        public GroupConfiguration Load(string path)
        {
            _configuration = _repository.Load(path);
            if (_configuration == null) return null;
            //verifier si la configuration porte des valeur
            if (!_configuration.Validate()) throw new InvalidOperationException("Configuration errone");
            //verifier si la configuration etablie une connexion
            if (!_configuration.IsTrueConnection()) return null;
            return Get();
        }

        /// <summary>
        ///     Creation d'une nouvelle configuration
        /// </summary>
        /// <param name="config"></param>
        /// <param name="path"></param>
        public void Save(GroupConfiguration config, string path)
        {
            //verifier si la configuration porte des valeur
            if (!config.Validate()) throw new InvalidOperationException("Configuration errone");
            _repository.Save(config, path);
            _configuration = config;
        }
    }
}