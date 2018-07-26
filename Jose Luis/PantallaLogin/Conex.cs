using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;
using Windows.UI.Popups;

namespace PantallaLogin
{
    class Conex
    {
        public SqlConnection conn;

        public Conex()
        {
            conn = new SqlConnection("server=S11-9\\MSSQLDATOS\\SQLEXPRESS;Initial Catalog=soperativos; Integrated Security=False;");
        }

        public void CrearUsuario(string usuario, string password)
        {

            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Insert into usuarios values (" + usuario + "," + "HASHBYTES('MD5'," + "'" +password+ "'))";
                cmd.ExecuteNonQuery();
            }
           
             catch (Exception ex)
            {
                var message = new MessageDialog("Error de conexion");
            }
           
            conn.Close();
        }

        public bool ValidarUsuario(string usuario, string pass)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Select *from usuarios where usuario =" + usuario + "and password=" + pass;
                bool result = cmd.ExecuteReader().GetEnumerator().MoveNext();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                var message = new MessageDialog("error de conexion");
                return false;
            }
           
            
        }
    }
}
