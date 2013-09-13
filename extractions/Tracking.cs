using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;

namespace univer.extractions
{
    public class Tracking
    {


        static public bool uniqueinscription(User user, string connectionstring, string type) 
        {
            bool val = false;
            
            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                using (var command = new OleDbCommand())
                {
                    conn.Open();
                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.Text;

                    string sqlcommand = "SELECT [username] FROM TRACKING WHERE [username] = ? AND [course] = ?";
                    if (type.Equals("profesores")) 
                    {
                        sqlcommand = "SELECT [username] FROM TRACKING WHERE [username] = ? AND [course] = ? AND [group] = ?";
                    }

                    command.CommandText = sqlcommand;
                    command.Parameters.Add("?", OleDbType.VarChar).Value = user.username;
                    command.Parameters.Add("?", OleDbType.VarChar).Value = user.course1;

                    if (type.Equals("profesores"))
                    {
                        command.Parameters.Add("?", OleDbType.VarChar).Value = user.group1;
                    }

                    OleDbDataReader reader = command.ExecuteReader();
                    val = reader.HasRows;
                }
            }

            if (val) 
            {
                Console.WriteLine(string.Format("El usuario {0} ya está inscrito en el curso {1}.", user.username, user.course1));
            }

            return val;
        }

        static public void trackuser(User user, string connectionstring, string type) 
        {
          using(OleDbConnection conn = new OleDbConnection(connectionstring))
          {

              using (var command = new OleDbCommand())
              {
                  conn.Open();
                  command.Connection = conn;
                  command.CommandType = System.Data.CommandType.Text;
                  command.CommandText = "INSERT INTO TRACKING ([username], [firstname], [lastname], [email], [course], [group], [type]) VALUES (?,?,?,?,?,?,?)";

                  command.Parameters.Add("?", OleDbType.VarChar).Value = user.username;
                  command.Parameters.Add("?", OleDbType.VarChar).Value = user.firstname;
                  command.Parameters.Add("?", OleDbType.VarChar).Value = user.lastname;
                  command.Parameters.Add("?", OleDbType.VarChar).Value = user.email;
                  command.Parameters.Add("?", OleDbType.VarChar).Value = user.course1;
                  command.Parameters.Add("?", OleDbType.VarChar).Value = user.group1;
                  command.Parameters.Add("?", OleDbType.Integer).Value = (type.Equals("profesores")) ? 3 : 1;

                  command.ExecuteNonQuery();
              }

          }   
        }

    }
}
