using TVS.Config;
using System.Data;
using System.Data.SqlClient;

namespace TVS.Declaration.Settings
{
    public class GroupConfiguration : IGroupConfiguration
    {
        private const string ConnectionString = @"
data source={0};initial catalog={1};integrated security={2};user={3};password={4};";

        public string Server { get; set; }

        public bool IsWinAuthentification { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public string Database { get; set; }

        public string GetConnection()
        {
            string connectionString = string.Format(ConnectionString
                , Server
                , Database
                , IsWinAuthentification
                , User
                , Password);

            return new SqlConnectionStringBuilder(connectionString)
            {
                ApplicationName = "Declaration",
                // MinPoolSize = 3
            }.ConnectionString;
        }

        private bool IsValid(string str)
        {
            return !(string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str));
        }

        public bool Validate()
        {
            return IsValid(Server)
                   && IsValid(Database);
        }

        public bool IsTrueConnection()
        {
            using (var con = new SqlConnection(GetConnection()))
            {
                try
                {
                    con.Open();
                    return con.State == ConnectionState.Open;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}