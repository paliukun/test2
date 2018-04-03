using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfcGDB.DatabaseAccess
{
    public interface IPostgreServer
    {
        /// <summary>
        /// 
        /// </summary>
        event EventHandler<string> ExceptionEvent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<int> ExecuteNonQuery(string command);

    }
}
