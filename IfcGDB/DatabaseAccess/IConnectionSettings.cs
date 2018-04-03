using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfcGDB.DatabaseAccess
{
    public interface IConnectionSettings
    {
        string Host { get; set; }
        int Port { get; set; }
        string UserId { get; set; }
        string Database { get; set; }
    }
}
