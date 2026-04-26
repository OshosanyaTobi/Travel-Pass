using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TravelPass.SqlConn
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            return DBSQLServerUtils.GetDBConnection();
        }
    }
}