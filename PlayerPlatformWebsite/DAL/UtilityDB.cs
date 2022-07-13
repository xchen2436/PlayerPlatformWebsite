using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient; 
using System.Configuration;

namespace PlayerPlatformWebsite.DAL
{
    public static class UtilityDB
    {
        public static SqlConnection ConnectDB()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["PPDB"].ConnectionString;
            conn.Open();
            return conn;
        }
    }
}



