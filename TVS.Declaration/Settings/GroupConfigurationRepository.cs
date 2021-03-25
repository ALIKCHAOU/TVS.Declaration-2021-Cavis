using DevExpress.XtraEditors;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace TVS.Declaration.Settings
{
    public class GroupConfigurationRepository : IConfigurationRepository<GroupConfiguration>
    {
        public void Save(GroupConfiguration configs, string pathDirectory)
        {
            if (configs == null) throw new ArgumentNullException("config");

            // load the config file
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // get the connection string section
            var connectionStringsSection = config.GetSection("connectionStrings") as ConnectionStringsSection;
            if (connectionStringsSection == null)
                throw new InvalidOperationException("Operation invalide! [config file section]");
            XtraMessageBox.Show(config.FilePath);
            // get the connection string setting.
            ConnectionStringSettings cnxSetting = connectionStringsSection.ConnectionStrings["Connection"];
            // modify the configuration
            if (cnxSetting == null)
            {
                // add the connection string if it doesn't already exist
                cnxSetting = new ConnectionStringSettings(
                    "Connection",
                    configs.GetConnection())
                {
                    ProviderName = "System.Data.SqlClient"
                };
                connectionStringsSection.ConnectionStrings.Add(cnxSetting);
            }
            else
            {
                // change the connection string
                cnxSetting.ConnectionString = configs.GetConnection();
            }
            // save changes
            config.Save(ConfigurationSaveMode.Full);
        }

        public GroupConfiguration Load(string path)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // load connection strings from exe config file
            var connectionStringsSection = config.GetSection("connectionStrings") as ConnectionStringsSection;
            if (connectionStringsSection == null)
                throw new InvalidOperationException("Operation invalide! [connectionStrings section]");

            // load settings section from exe config file
            KeyValueConfigurationCollection appSettings = config.AppSettings.Settings;
            if (appSettings == null)
                throw new InvalidOperationException("Operation invalide! [settings section]");
            ConnectionStringSettings connectString = connectionStringsSection.ConnectionStrings["Connection"];
            if (connectString == null) return null;
            var builder = new SqlConnectionStringBuilder(connectString.ConnectionString);

            var groupConfig = new GroupConfiguration
            {
                Database = builder.InitialCatalog,
                IsWinAuthentification = builder.IntegratedSecurity,
                Password = builder.Password,
                Server = builder.DataSource,
                User = builder.UserID
            };
            return groupConfig;
        }
    }
}