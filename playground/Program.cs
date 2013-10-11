using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using univer.extractions;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Text.RegularExpressions;
using System.DirectoryServices.Protocols;
using System.Security.Permissions;
using System.Net;

using univer.extractions;
using univer.LDAP;


namespace playground
{
    class Program
    {
        static void unit_test() 
        {
            ConnLDAP conn = new ConnLDAP();

            conn.admin_username = "admin";
            conn.admin_password = "ldap";
            conn.domain = "dc=online,dc=univer";
            conn.server = "192.168.61.43";

            //Crear un usuario nuevo en LDAP
            UserLDAP user = new UserLDAP(conn);

            user.cn = "test01";
            user.sn = "Tester del Tester";
            user.title = "HQ";
            user.description = "Polanco";
            user.postalAddress = "moises.rangel@gmail.com";

            user.userPassword = "test01";

            DirectoryEntry MyUser = user.Add();

            if (user.Login())
            {
                PropertyCollection properties = user.Properties();
                if (properties.Count > 0)
                {
                    foreach (PropertyValueCollection property in properties)
                    {
                        Console.WriteLine(string.Format("{0}: {1}", property.PropertyName.ToString(), property.Value.ToString()));
                    }

                    Console.ReadLine();
                }

                user.sn = "Nombre Modificado";
                user.title = "Title modificado";
                user.description = "Description Modificado";
                user.postalAddress = "postalAddress Modificado";
                user.userPassword = "newPass";

                user.Update();

                user.Login();
            }        
        
        }

        static void Main(string[] args) 
        {
            

        }
    
    }
}
