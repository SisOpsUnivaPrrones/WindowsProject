using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;
using Windows.UI.Popups;
using System.Security.Cryptography;



namespace PantallaLogin
{
    class Conex
    {
        public SqlConnection conn;

        public Conex()
        {
           //conn = new SqlConnection("Data Source=S11-9\\MSSQLDATOS\\SQLEXPRESS;Initial Catalog=soperativos; Integrated Security=SSPI;;");
          conn = new SqlConnection("Data Source=192.168.53.197;" +"Initial Catalog=soperativos;" +"User id=SA;" +"Password=Qwer1234;");

        }

        public void CrearUsuario(string usuario, string password)
        {
           
            MD5 md5Hash = MD5.Create();
            string newPass = GetMd5Hash(md5Hash, password);
            conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Insert into usuarios values ('" + usuario + "','" + newPass+"')";
                cmd.ExecuteNonQuery();
         
            conn.Close();
        }

        public bool ValidarUsuario(string usuario, string pass)
        {
            
            MD5 md5Hash = MD5.Create();
            string newPass = GetMd5Hash(md5Hash, pass);
            conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Select *from usuarios where nombre ='" + usuario + "' and pass='" + newPass +"'";
                bool result =cmd.ExecuteReader().GetEnumerator().MoveNext();
                conn.Close();
           
            return result;
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        
    }
}
