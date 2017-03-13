using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welenda.lk.Database
{
    public class Connection
    {
        private static Connection dbInstance;
        private readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WelendaConnectionString"].ToString());

        public Connection()
        {
        }

        public static Connection getDbInstance()
        {
            if (dbInstance == null)
            {
                dbInstance = new Connection();
            }
            return dbInstance;
        }

        public SqlConnection GetDBConnection()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Not connected : " + e.ToString());
                Console.ReadLine();
            }

            return con;
        }
    }
}
