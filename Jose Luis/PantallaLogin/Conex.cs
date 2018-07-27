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
           conn = new SqlConnection("Data Source=S11-9\\MSSQLDATOS\\SQLEXPRESS;Initial Catalog=soperativos; Integrated Security=SSPI;;");
          // conn = new SqlConnection("Data Source=192.168.53.197;" +"Initial Catalog=soperativos;" +"User id=SA;" +"Password=Qwer1234;");

        }

        public void CrearUsuario(string usuario, string password)
        {

          
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Insert into usuarios values ('" + usuario + "',HASHBYTES('MD5','" + password+"'))";
                cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool ValidarUsuario(string usuario, string pass)
        {
           
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Select *from usuarios where nombre ='" + usuario + "' and pass='" + pass +"'";
                bool result = cmd.ExecuteReader().GetEnumerator().MoveNext();
                conn.Close();
                return result;
            
           
            
        }
    }
}
