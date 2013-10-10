using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace univer.LDAP
{
    public class ConnLDAP
    {
        public string admin_username { get; set; }
        public string admin_password { get; set; }
        public string domain { get; set; }
        public string server { get; set; }

        public ConnLDAP() { }
    }
}
