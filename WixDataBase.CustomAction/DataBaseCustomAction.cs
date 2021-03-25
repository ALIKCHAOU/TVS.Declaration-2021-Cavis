using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Deployment.WindowsInstaller;
using TVS.Ef.Migration.Declaration;

namespace WixDataBase.CustomAction
{
    public class DataBaseCustomAction
    {
        /// <summary>
        /// enregistre les parametre de connexion s'ils sont validés dans la session
        /// </summary>
        [CustomAction]
        public static ActionResult SaveParameterConnection(Session session)
        {
            try
            {
                var valide = TestSqlConnection(session);

                return valide;
            }
            catch (Exception ex)
            {
                return ActionResult.Failure;
            }
        }

        /// <summary>
        /// creation de la base donnée
        /// </summary>
        [CustomAction]
        public static ActionResult ExecuteSql(Session session)
        {
            try
            {
                var valide = TestSqlConnection(session);

                if (valide == ActionResult.Success)
                {
                    var groupConfig = new GroupConfiguration
                    {
                        Database = GetSessionProperty(session, "DATABASE_NAME", false),
                        IsWinAuthentification =
                            GetSessionProperty(session, "DATABASE_WINDOWSAUTHENTICATION", false) == "1",
                        Password = GetSessionProperty(session, "DATABASE_PASSWORD", false).Trim(),
                        Server = GetSessionProperty(session, "DATABASE_SERVERNAME", false).Trim(),
                        User = GetSessionProperty(session, "DATABASE_USERNAME", false).Trim()
                    };
                    SetSessionProperty(session, "WINDOWSAUTHENTICATION", groupConfig.IsWinAuthentification + "");
                    var ctx = new GroupContextFactory(groupConfig);

                    var exist = ctx.DatabaseExists();
                    try
                    {
                        // create data base with entity framework
                        if (!exist)
                            ctx.DatabaseInitialize();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        // MessageBox.Show(exist.ToString());
                        // Save(groupConfig);
                    }
                    // MessageBox.Show("00");
                }
                return ActionResult.Success;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return ActionResult.Failure;
            }
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert)]
        public static void Save(GroupConfiguration configs)
        {
            try
            {
                if (configs == null) throw new ArgumentNullException("config");

                string appPath =
                    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string configFile = System.IO.Path.Combine(appPath, "DeclarationPlus.UIWin.exe.config");
                MessageBox.Show(configFile);
                var configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = configFile;
                //   System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

                // load the config file
                var fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = "DeclarationPlus.UIWin.exe.config";

                // fileMap.ExeConfigFilename = "appconfig";
                var config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                MessageBox.Show(configs.GetConnection());
                // get the connection string section
                var connectionStringsSection = config.GetSection("connectionStrings") as ConnectionStringsSection;
                if (connectionStringsSection == null)
                    throw new InvalidOperationException("Operation invalide! [config file section]");
                MessageBox.Show(connectionStringsSection.ConnectionStrings.ToString());
                // get the connection string setting.
                var cnxSetting = connectionStringsSection.ConnectionStrings["Connection"];

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

                    MessageBox.Show(connectionStringsSection.CurrentConfiguration.FilePath);
                }

                // save changes
                if (!connectionStringsSection.SectionInformation.IsProtected)
                {
                    connectionStringsSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    connectionStringsSection.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        [CustomAction]
        public static ActionResult TestSqlConnection(Session session)
        {
            var result = ActionResult.Failure;
            try
            {
                if (session == null)
                {
                    throw new ArgumentNullException("session");
                }
                var servername = GetSessionProperty(session, "DATABASE_SERVERNAME", false);

                if (string.IsNullOrEmpty(servername))
                    throw new ApplicationException("Nom du serveur invalide!");

                SetSessionProperty(session, "DATABASE_TEST_CONNECTION", "0");
                string sConnectionString = GetConnectionString(session, false);
                using (var connection = new SqlConnection(sConnectionString))
                {
                    try
                    {
                        connection.Open();
                        result = ActionResult.Success;
                    }
                    catch (SqlException ex)
                    {
                        result = ActionResult.Failure;
                        throw ex;
                    }
                }

                SetSessionProperty(session, "DATABASE_TEST_CONNECTION", "1");
            }
            catch (Exception ex)
            {
                result = ActionResult.Failure;
            }
            result = ActionResult.Success;
            return result;
        }

        private static void SetSessionProperty(Session session, string propertyName, string value)
        {
            session[propertyName] = value;
        }

        private static string GetSessionProperty(Session session, string propertyName, bool isCustomActionData)
        {
            if (isCustomActionData)
            {
                return session.CustomActionData[propertyName];
            }

            return session[propertyName];
        }

        private static string GetConnectionString(Session session, bool isCustomActionData)
        {
            string connectionSring;

            if (GetSessionProperty(session, "DATABASE_WINDOWSAUTHENTICATION", isCustomActionData) == "1")
            {
                connectionSring = string.Format(
                    @"Integrated Security=SSPI;Persist Security Info=False;Data Source={0};",
                    GetSessionProperty(session, "DATABASE_SERVERNAME", isCustomActionData).Trim());
            }
            else
            {
                connectionSring = string.Format(
                    @"Persist Security Info=False;Data Source={0};User ID={1};Password={2};",
                    GetSessionProperty(session, "DATABASE_SERVERNAME", isCustomActionData),
                    GetSessionProperty(session, "DATABASE_USERNAME", isCustomActionData),
                    GetSessionProperty(session, "DATABASE_PASSWORD", isCustomActionData));
            }

            if (GetSessionProperty(session, "DATABASE_AUTHENTICATEDATABASE", isCustomActionData) == "1")
            {
                connectionSring += string.Format("Initial Catalog={0};",
                    GetSessionProperty(session, "DATABASE_NAME", isCustomActionData));
            }
            return connectionSring;
        }
    }
}