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

        public DirectoryEntry AddUser() 
        {
            DirectoryEntry objUser = this.Entry().Children.Add("cn=user12", "organizationalPerson");
        }

        public void OpenasdfLDAP() 
        {

            
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
             

        }

    }
}
