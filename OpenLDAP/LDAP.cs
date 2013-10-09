using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.Security.Permissions;

namespace univer.OpenLDAP
{

    [DirectoryServicesPermission(SecurityAction.LinkDemand, Unrestricted = true)]
    public class LDAP
    {

        // static variables used throughout the example
        static LdapConnection ldapConnection;
        static string  ldapServer;
        static NetworkCredential credential;
        static string targetOU; // dn of an OU. eg: "OU=sample,DC=fabrikam,DC=com";

        public LDAP(string server, string user, string password, string domain, string OU) 
        {
            try
            {
                //set arguments
                ldapServer = server;
                credential = new NetworkCredential(user, password, domain);
                targetOU = OU;               

                ldapConnection = new LdapConnection(ldapServer);
                ldapConnection.Credential = credential;
                ldapConnection.Bind();
                Console.WriteLine("Success!");
            }
            catch (Exception e)
            {
                throw new Exception("\r\nUnexpected exception occured:\r\n\t" + e.GetType() + ":" + e.Message);
            }
        }

    }
}
