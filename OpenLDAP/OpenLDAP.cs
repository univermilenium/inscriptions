using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;

using System.Net;

namespace univer.LDAP
{
    public class OpenLDAP
    {

        public string admin_username;
        public string admin_password;
        public string domain;
        public string server;

        public OpenLDAP() { }

        public OpenLDAP(ConnLDAP conn) 
        {
            this.admin_username = conn.admin_password;
            this.admin_password = conn.admin_password;
            this.domain = conn.domain;
            this.server = conn.server;
        }

        private DirectoryEntry Entry() 
        {
            return new DirectoryEntry(string.Format("LDAP://{0}/{1}", this.server, this.domain), string.Format("cn={0},{1}", this.admin_username, this.domain), this.admin_password, AuthenticationTypes.None);
        }

        public bool AuthUser(string user, string domain,  string password) 
        {
            var credential = new NetworkCredential(string.Format("cn={0},{1}", user, domain), password);
            var host = this.server;
            try 
            {
                using (var con = new LdapConnection(host) { Credential = credential, AuthType = AuthType.Basic, AutoBind = false })
                {
                    con.SessionOptions.ProtocolVersion = 3;
                    con.Bind();
                    return true;
                }
            
            }catch(System.Exception e)
            {
                throw e;
            }

        }

        public PropertyCollection PropertiesUser() 
        {
            DirectoryEntry authuser = this.Entry();
            return authuser.Properties;
        }

        public DirectoryEntry AddUser(UserLDAP user) 
        {
            DirectoryEntry objUser = this.Entry().Children.Add("cn=" + user.cn, "organizationalPerson");

            objUser.Properties["cn"].Add(user.cn);
            objUser.Properties["sn"].Add(user.sn);
            objUser.Properties["seeAlso"].Add(user.seeAlso);
            objUser.Properties["userPassword"].Add(user.userPassword);
            objUser.Properties["title"].Add(user.title);
            objUser.Properties["description"].Add(user.description);
            objUser.Properties["postalAddress"].Add(user.postalAddress);

            objUser.CommitChanges();

            return objUser;
        }
    }
}
