using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace IfcGDB.DatabaseAccess
{
    class ConnectionCreator
    {
        public ConnectionCreator(IConnectionSettings connectionSettings)
        {
            _settings = connectionSettings;
        }

        public NpgsqlConnection Init(string password)
        {
            NpgsqlConnectionStringBuilder connectionBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = _settings.Host,
                Port = _settings.Port,
                Username = _settings.UserId,
                Password = password,
                Database = _settings.Database,
                SslMode = SslMode.Prefer
            };
            var connection = new NpgsqlConnection(connectionBuilder.ConnectionString);
            return connection;
        }

        private readonly IConnectionSettings _settings;
    }
}
