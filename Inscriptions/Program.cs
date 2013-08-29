using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using univer.extractions;

namespace Inscriptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Extraction ex = new Extraction();
            User user = new User();

            user.username = "4512454512";
            user.firstname = "moises";
            user.lastname = "rangel";
            user.password = "hashhash";
            user.group1 = "SPEG-5454545";
            user.type1 = 1;

            ex.Users.Add(user);

            ex.toCSV("C:\\");
            
        }
    }
}
