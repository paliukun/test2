using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfcGDB.UI
{
    class ConnectionException : Exception
    {
        public ConnectionException()
        {
            Message = "Connection Failed!";
        }
        public ConnectionException(string message)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}
