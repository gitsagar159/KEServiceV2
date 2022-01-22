using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace KEServiceV2.Models.Data
{
    public class MySQLConnection
    {
        static string _staticConnectionString;

        public static MySqlConnection StaticSqlConnection
        {
            get
            {

                MySqlConnection staticConnection = new MySqlConnection();
                staticConnection.ConnectionString = StaticConnectionString;
                return staticConnection;
            }
        }

        public static string StaticConnectionString
        {
            set { _staticConnectionString = value; }
            get
            {
                if (!string.IsNullOrEmpty(_staticConnectionString))
                    return _staticConnectionString;

                string con = ConfigurationManager.ConnectionStrings["KEMySQLConnection"].ConnectionString;

                return con;
            }

        }
    }
}