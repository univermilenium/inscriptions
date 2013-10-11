using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;

using System.Collections; // IDictionary
using System.Net;

using System.Security.Cryptography;

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
        
        private DirectoryEntry EntryAdmin()
        {
            return new DirectoryEntry(string.Format("LDAP://{0}/{1}", this.server, this.domain), string.Format("cn={0},{1}", this.admin_username, this.domain), this.admin_password, AuthenticationTypes.None);
        }

        private DirectoryEntry EntryAdmin(UserLDAP user)
        {
            return new DirectoryEntry(string.Format("LDAP://{0}/{1}", this.server, this.domain), string.Format("cn={0},{1}", user.cn, this.domain), user.userPassword, AuthenticationTypes.None);
        }

        private DirectoryEntry EntryAdmin(UserLDAP user, bool withAdminCredentials)
        {
            return new DirectoryEntry(string.Format("LDAP://{0}/cn={1},{2}", this.server, user.cn, this.domain), string.Format("cn={0},{1}", this.admin_username, this.domain), this.admin_password, AuthenticationTypes.None);
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

        public PropertyCollection PropertiesUser(UserLDAP userl) 
        {
            DirectoryEntry user = this.EntryAdmin(userl);
            return user.Properties;
        }

        public DirectoryEntry UpdateUser(UserLDAP user) 
        {
            System.DirectoryServices.PropertyCollection userProperties;
            DirectoryEntry  oUser = this.EntryAdmin(user, true);
            userProperties = oUser.Properties;

            if (userProperties.Contains("sn"))
            {
                userProperties["sn"].Value = user.sn;
            }

            if (userProperties.Contains("seeAlso"))
            {
                userProperties["seeAlso"].Value = user.seeAlso;
            }

            if (userProperties.Contains("userPassword"))
            {
                userProperties["userPassword"].Value = user.userPassword;
            }
            
            if (userProperties.Contains("title"))
            {
                userProperties["title"].Value = user.title;                
            }

            if (userProperties.Contains("description"))
            {
                userProperties["description"].Value = user.description;
            }

            if (userProperties.Contains("postalAddress"))
            {
                userProperties["postalAddress"].Value = user.postalAddress;
            }

            oUser.CommitChanges();

            return oUser;
        }

        public DirectoryEntry AddUser(UserLDAP user) 
        {
            DirectoryEntry objUser = this.EntryAdmin().Children.Add("cn=" + user.cn, "organizationalPerson");

            objUser.Properties["cn"].Add(user.cn);
            objUser.Properties["sn"].Add(user.sn);
            objUser.Properties["userPassword"].Add(user.userPassword);
            objUser.Properties["title"].Add(user.title);
            objUser.Properties["description"].Add(user.description);
            objUser.Properties["postalAddress"].Add(user.postalAddress);

            objUser.CommitChanges();

            return objUser;
        }
        
        static private string GetSHA1(string str)
        {
            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        
        static private string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
