using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfcGDB.DatabaseAccess
{
    public class DatabaseLogin
    {
        public IPostgreServer PostgreServer { get; private set; }

        public void CreateServer(IConnectionSettings connectionSettings, string password)
        {
            PostgreServer = new PostgreServer(new ConnectionCreator(connectionSettings).Init(password));
        }
    }
}
