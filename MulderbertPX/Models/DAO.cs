using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MulderbertPX.Models
{
    /// <summary>
    /// Class Definition: Base Class that manages access to the remote database on DBS's SQL Sever
    /// </summary>
    public class DAO
    {
        //declare objs/vars
        SqlConnection conn { get; set; }

        public DAO()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString);
        }

        //method 1 - open connection 
        public SqlConnection OpenConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        //method 2 - close connection
        public void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}