using System;
using System.Data;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PantallaLogin
{
    class ConexMySQL
    {
         
       public MySqlConnection conn;
       public ConexMySQL(){
            conn = new MySqlConnection("server=localhost;user=root;database=world;port=3306;password=''");
       }

        public void CrearUsuario(string usuario, string password)
        {
            conn.Open();
            MySqlCommand command = new MySqlCommand($"Insert into usuarios values({usuario},{password})", conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public bool ValidarUsuario(string usuario, string pass)
        {
            conn.Open();
            MySqlCommand command = new MySqlCommand($"Select *from usuarios where usuario = '{usuario}' and password='{pass}'", conn);
            bool result = command.ExecuteReader().GetEnumerator().MoveNext();
            conn.Close();
            return result;
        }

            
                
            
            
        
    }
}
