using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Pl
{
    internal class operations
    {
        public static void dbconntest() 
        {
            string connStr = "server=localhost;user=root;database=Bank;port=3306;password=";

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                Console.WriteLine("Connection successful, you may proceed");

            }
            catch (Exception err)
            {
                Console.WriteLine("Couldn't connect to the database, check the connection");
                Console.WriteLine(err.ToString());
            }
            conn.Close();
            Console.Read();
        }

    
    }
}
