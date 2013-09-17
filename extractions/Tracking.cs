using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;
using FirebirdSql.Data.FirebirdClient;

namespace univer.extractions
{
    public class Tracking
    {
        static private List<object[]> QueryFb(string connectionstring, string query)
        {
            try
            {
                using (FbConnection dbConn = new FbConnection(connectionstring))
                {

                    dbConn.Open();

                    using (var command = dbConn.CreateCommand())
                    {
                        command.CommandText = query;
                        using (var reader = command.ExecuteReader())
                        {
                            var rows = new List<object[]>();
                            while (reader.Read())
                            {
                                var columns = new object[reader.FieldCount];
                                reader.GetValues(columns);
                                rows.Add(columns);
                            }
                            return rows;
                        }
                    }
                }

            }
            catch (System.Exception oe)
            {
                throw new Exception(oe.Message);
            }

        }

        static public bool uniqueinscription(User user, string connectionstring, string type, string DBTYPE) 
        {
            switch (DBTYPE) 
            {
                case "FIREBIRD":
                    return Tracking.uniqueFbInscription(user, connectionstring, type);
                case "ACCESS":
                    return Tracking.uniqueAccesInscription(user, connectionstring, type);
                default:
                    throw new Exception("No existe el conector para " + DBTYPE);
            }
        }

        static public void trackuser(User user, string connectionstring, string type, string DBTYPE) 
        {
            switch (DBTYPE)
            {
                case "FIREBIRD":
                     Tracking.trackFbUser(user, connectionstring, type);
                     break;
                case "ACCESS":
                     Tracking.trackAccessUser(user, connectionstring, type);
                     break;
                default:
                    throw new Exception("No existe el conector para " + DBTYPE);
            }        
        }

        static private bool uniqueFbInscription(User user, string connectionstring, string type) 
        {
            bool val = false;

            string sqlcommand = string.Format("SELECT username FROM tracking WHERE username = '{0}' AND course1 = '{1}';", user.username, user.course1);
            if (type.Equals("profesores")) 
            {
                sqlcommand = string.Format("SELECT username FROM tracking WHERE username = '{0}' AND course1 = '{1}' AND group1 = '{2}';", user.username, user.course1, user.group1);
            }

            List<object[]> rows = Tracking.QueryFb(connectionstring, sqlcommand);
            val = (rows.Count > 0) ? true : false;
            if (val)
            {
                Console.WriteLine(string.Format("El usuario {0} ya está inscrito en el curso {1}.", user.username, user.course1));
            }

            return val;        
        }
        
        static private bool uniqueAccesInscription(User user, string connectionstring, string type) 
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

        static private void trackFbUser(User user, string connectionstring, string type)
        {
          using(FbConnection conn = new FbConnection(connectionstring))
          {
              using (var command = new FbCommand()) 
              {
                  conn.Open();
                  command.Connection = conn;
                  command.CommandType = System.Data.CommandType.Text;
                  command.CommandText = @"
                                            insert into tracking
                                            (
                                              username,
                                              firstname,
                                              lastname,
                                              email,
                                              course1,
                                              group1,
                                              type1,
                                              created
                                            ) values
                                            (
                                              @username,
                                              @firstname,
                                              @lastname,
                                              @email,
                                              @course1,
                                              @group1,
                                              @type1,
                                              'NOW'	
                                            );
                                            ";

                  command.Parameters.Add("@username", FbDbType.VarChar).Value = user.username;
                  command.Parameters.Add("@firstname", FbDbType.VarChar).Value = user.firstname;
                  command.Parameters.Add("@lastname", FbDbType.VarChar).Value = user.lastname;
                  command.Parameters.Add("@email", FbDbType.VarChar).Value = user.email;
                  command.Parameters.Add("@course1", FbDbType.VarChar).Value = user.course1;
                  command.Parameters.Add("@group1", FbDbType.VarChar).Value = user.group1;
                  command.Parameters.Add("@type1", FbDbType.Integer).Value = user.type1;

                  command.ExecuteNonQuery();
              }
          }
        }

        static private void trackAccessUser(User user, string connectionstring, string type) 
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
