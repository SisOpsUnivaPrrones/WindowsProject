using System;
using System.Data;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PantallaLogin
{
    class Class1
    {
        static void Main(string[] args)
        {

            string connStr = "server=localhost;user=root;database=world;port=3306;password=''";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                
            }
        }
    }
}
