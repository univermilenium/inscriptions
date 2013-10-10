using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;

namespace univer.LDAP
{
    public class OpenLDAP
    {

        public string admin_username;
        public string admin_password;
        public string domain;
        public string server;


        public OpenLDAP() { }

        public OpenLDAP(string adminuser, string adminpass, string domain, string server) 
        {
            this.admin_username = adminuser;
            this.admin_password = adminpass;
            this.domain = domain;
            this.server = server;
        }

        private DirectoryEntry Entry() 
        {
            return new DirectoryEntry(string.Format("LDAP://{0}/{1}", this.server, this.domain), string.Format("cn={0},{1}", this.admin_username, this.domain), this.admin_password, AuthenticationTypes.None);
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
