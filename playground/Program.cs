using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using univer.extractions;
using univer.OpenLDAP;

using System.DirectoryServices;
using System.Text.RegularExpressions;

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
                using (DirectorySearcher ds = new DirectorySearcher(entry, query, null, SearchScope.Subtree))
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


        static void Main(string[] args)
        {

            try
            {
            
                //autenticacion ::: OK                
                //DirectoryEntry root = new DirectoryEntry("LDAP://192.168.61.39", "cn=admin,dc=online,dc=univer", "ldap", AuthenticationTypes.None);
                //object connected = root.NativeObject;

                string userDn = @"cn=admin,dc=online,dc=univer";
                string fullPath = @"LDAP://192.168.61.39/" + userDn;
                DirectoryEntry authUser = new DirectoryEntry(fullPath, userDn, "ldap", AuthenticationTypes.None);

                
                authUser.RefreshCache();

                foreach (PropertyValueCollection property in authUser.Properties) 
                {
                    Console.WriteLine(string.Format("{0}: {1}", property.PropertyName.ToString(), property.Value.ToString()));
                }

                Console.ReadLine();
            }
            catch (Exception oe) 
            {
                Console.WriteLine(oe.Message.ToString());
                Console.ReadLine();
            }
        }
    }
}
