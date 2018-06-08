using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantallaLogin
{
    class Conex
    {
        public SqlConnection conn;

        public Conex()
        {
            conn = new SqlConnection("Data Source=S11-9\\MSSQLDATOS\\SQLEXPRESS;Initial Catalog=soperativos;Integrated Security=False");
        }

        public void CrearUsuario(string usuario, string password)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Insert into usuarios values usuario="+usuario+","+"password="+password;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool ValidarUsuario(string usuario, string pass)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select *from usuarios where usuario =" +usuario+ "and password="+pass;
            bool result = cmd.ExecuteReader().GetEnumerator().MoveNext();
            conn.Close();
            return result;
        }


    }
}
