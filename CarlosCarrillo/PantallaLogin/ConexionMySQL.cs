using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MySql.Data.MySqlClient;

namespace PantallaLogin
{
    public class ConexionMySQL
    {
        //private MySqlConnection connection;
        //public ConexionMySQL()
        //{
        //    connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=12345;database=test");
        //}

        //public void CrearUsuario(string usuario, string password)
        //{
        //    connection.Open();
        //    MySqlCommand command = 
        //        new MySqlCommand($"INSERT INTO usuarios VALUES ({usuario}, {password})", connection);
        //    command.ExecuteNonQuery();
        //    connection.Close();
        //}

        //public bool ValidarUsuario(string usuario, string password)
        //{
        //    connection.Open();
        //    MySqlCommand command =
        //        new MySqlCommand($"SELECT * FROM usuarios WHERE usuario = '{usuario}' AND password = {password}'", connection);
        //    bool result = command.ExecuteReader().GetEnumerator().MoveNext();
        //    connection.Close();
        //    return result;
        //}
    }
}
