using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;

namespace tracking
{
    class Program
    {


        void checkinscription() 
        {
        
        }

        static void Main(string[] args)
        {
            string connectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\E-LEARNING5\\Documents\\tracking.accdb";
            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                using (var command = new OleDbCommand())
                {
                    conn.Open();
                    command.Connection  = conn;
                    command.CommandType = System.Data.CommandType.Text;   
                    command.CommandText = "INSERT INTO TRACKING ([username], [firstname], [lastname], [email], [course], [group], [type]) VALUES (?,?,?,?,?,?,?)";

                    command.Parameters.Add("?", OleDbType.VarChar).Value = "username"; 
                    command.Parameters.Add("?", OleDbType.VarChar).Value = "firstname"; 
                    command.Parameters.Add("?", OleDbType.VarChar).Value = "lastname"; 
                    command.Parameters.Add("?", OleDbType.VarChar).Value = "email"; 
                    command.Parameters.Add("?", OleDbType.VarChar).Value = "course"; 
                    command.Parameters.Add("?", OleDbType.VarChar).Value = "group"; 
                    command.Parameters.Add("?", OleDbType.Integer).Value = 1; 

                    command.ExecuteNonQuery();
                }

                Console.ReadLine();
            }
        }
    }
}
