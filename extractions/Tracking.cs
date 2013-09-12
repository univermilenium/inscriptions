using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;

namespace univer.extractions
{
    public class Tracking
    {

        static public void trackuser(User user, string connectionstring) 
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
                  command.Parameters.Add("?", OleDbType.Integer).Value = 1;

                  command.ExecuteNonQuery();
              }

          }   
        }

    }
}
