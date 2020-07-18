using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace authWF
{
    public static class DBUtils
    {
        public static string datasource;
        public static string database;
        public static string username;
        public static string password;

        public static string Datasource1
        {
            get { return datasource; }
            set { datasource = value; }
        }

        public static string Database1
        {
            get { return database; }
            set { database = value; ; }
        }

        public static string Username1
        {
            get { return username; }
            set { username = value; }
        }


        public static string Password1
        {
            get { return password; }
            set { password = value; }
        }


        public static SqlConnection GetDBConnection()
        {

            string datasource12 = "localhost";
            string database12 = "ps_bankrussia_test";
            string username12 = "adminkbr";
            string password12 = "xX123456";
            return DBSQLServerUtils.GetDBConnection(datasource12, database12, username12, password12);
        }
    }
}