using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace IfcGDB.DatabaseAccess
{
    class PostgreServer : IPostgreServer
    {
        public PostgreServer(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        private readonly NpgsqlConnection _connection;

        public event EventHandler<string> ExceptionEvent = (object sender, string message) => { };

        #region public methods

        public async Task<int> ExecuteNonQuery(string command)
        {
            _connection.Open();

            int qureyresult = 0;

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(command, _connection);
                qureyresult = await cmd.ExecuteNonQueryAsync();
            }
            catch (NpgsqlException e)
            {
                ExceptionEvent(this, e.Message);
            }
            finally
            {
                _connection.Close();
            }

            return qureyresult;
        }

        #endregion
    }
}
