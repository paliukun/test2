using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfcGDB.DatabaseAccess
{
    class ConnectionSettings : IConnectionSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserId { get; set; }
        public string Database { get; set; }
    }
}
