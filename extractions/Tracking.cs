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
              conn.Open();

              using (var command = conn.CreateCommand())
              {
                  command.CommandText = string.Format("INSERT INTO TRACKING([username], firstname, lastname, email, course, group, type) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6})", user.username, user.firstname, user.lastname, user.email, user.course1, user.group1, user.type1);
                  command.ExecuteNonQuery();
              }
          }   
        }

    }
}
