using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantallaLogin
{
    public class ConexionMSSQL
    {
        private SqlConnection connection;
        public ConexionMSSQL()
        {
            connection = 
                new SqlConnection("Data Source=carlos-VirtualBox;Initial Catalog=LoginUWP;Integrated Security=False;User Id=sa;Password=Shagrath1;MultipleActiveResultSets=True");
        }

        public void CrearUsuario(string usuario, string password)
        {
            connection.Open();
            SqlCommand command =
                new SqlCommand($"INSERT INTO usuarios VALUES ('{usuario}', '{password}')", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public bool ValidarUsuario(string usuario, string password)
        {
            connection.Open();
            SqlCommand command =
                new SqlCommand($"SELECT * FROM usuarios WHERE usuario = '{usuario}' AND password = {password}'", connection);
            bool result = command.ExecuteReader().GetEnumerator().MoveNext();
            connection.Close();
            return result;
        }
    }
}
