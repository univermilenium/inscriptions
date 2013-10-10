using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using univer.extractions;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

using System.Text.RegularExpressions;

using System.Security.Cryptography;



using System.DirectoryServices.Protocols;
using System.Security.Permissions;

using System.Net;

using univer.LDAP;


namespace playground
{
    class Program
    {
        private static string GetLDAPUserByName(string userName, string[] properties, string lineFeed)
        {
            StringBuilder sb = new StringBuilder();
            string query = "(objectClass=*)";
            //query = String.Format(query, userName);

            using (DirectoryEntry entry = new DirectoryEntry("LDAP://192.168.61.39", "cn=admin,dc=online,dc=univer", "ldap", AuthenticationTypes.ServerBind))
            {
                using (DirectorySearcher ds = new DirectorySearcher(entry, query, null, System.DirectoryServices.SearchScope.Subtree))
                {
                    SearchResultCollection res = ds.FindAll(); // all matches 
                    if(res.Count == 0 )
                    {
                        return "No se encontró el usuario " + userName;
                    }

                    foreach (SearchResult r in res)
                    {                       
                        
                       /*
                        foreach (string prop in properties)
                        {
                            foreach (object property in r.Properties[prop])
                            {
                                sb.Append(prop).Append("=").Append(property.ToString()).Append(lineFeed);
                            }
                        }
                         * */
                    }
                }
            }
            return sb.ToString();
        }

        static public string GetSHA1(string str)
        {
            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }


        static void Main(string[] args) 
        {
             
            ConnLDAP conn = new ConnLDAP();

            conn.admin_username = "admin";
            conn.admin_password = "ldap";
            conn.domain         = "dc=online,dc=univer";
            conn.server         = "192.168.61.39";

            UserLDAP user = new UserLDAP(conn);
            
            // test login user;
            user.cn = "admin";
            user.userPassword = "ldap";
            user.Login();





        }

        /*
        static void Main(string[] args)
        {

            try
            {
            
                //autenticacion ::: OK                
                //DirectoryEntry root = new DirectoryEntry("LDAP://192.168.61.39", "cn=admin,dc=online,dc=univer", "ldap", AuthenticationTypes.None);
                //object connected = root.NativeObject;

                //Read user properties
                string userDn = @"cn=admin,dc=online,dc=univer";
                string fullPath = @"LDAP://192.168.61.39/" + userDn;
                DirectoryEntry authUser = new DirectoryEntry(fullPath, userDn, "ldap", AuthenticationTypes.None);

                
                authUser.RefreshCache();

                foreach (PropertyValueCollection property in authUser.Properties) 
                {
                    Console.WriteLine(string.Format("{0}: {1}", property.PropertyName.ToString(), property.Value.ToString()));
                }

               // Console.ReadLine();

                //Add User
             
                string userDn2 = @"cn=admin,dc=online,dc=univer";
                string fullPath2 = @"LDAP://192.168.61.39/dc=online,dc=univer";
                DirectoryEntry entry = new DirectoryEntry(fullPath2, userDn2, "ldap", AuthenticationTypes.None);
                DirectoryEntry objUser = entry.Children.Add("cn=user12", "organizationalPerson");

                Console.WriteLine(objUser.Path);
                objUser.Properties["cn"].Add("user12"); // add this statement can avoid naming violation.
                objUser.Properties["sn"].Add("tu12");               //singlename sn
                objUser.Properties["title"].Add("student"); //student teacher
                string pass = GetMD5("testear");
                objUser.Properties["userPassword"].Add("{MD5}"+pass);

                objUser.CommitChanges();
                 * 
            



                var host = "192.168.61.39:389";
                var credential = new NetworkCredential("cn=admin,dc=online,dc=univer", "ldap");

                using (var con = new LdapConnection(host) { Credential = credential, AuthType = AuthType.Basic, AutoBind = false })
                {
                    con.SessionOptions.ProtocolVersion = 3;
                    con.Bind();

                    //Do other ldap operations here such as setting the user password
                    var pass = "newpass";
                    var req = new ModifyRequest
                    {
                        DistinguishedName = "cn=user,ou=test,dc=example,dc=com"
                    };

                    var dam = new DirectoryAttributeModification
                    {
                        Name = "userPassword",
                        Operation = DirectoryAttributeOperation.Replace
                    };
                    dam.Add(pass);
                    req.Modifications.Add(dam);

                    con.SendRequest(req);
                }

            }
            catch (Exception oe) 
            {
                Console.WriteLine(oe.Message.ToString());
                Console.ReadLine();
            }
        }
    */
    
    
    }
}
