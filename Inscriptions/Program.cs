using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using univer.extractions;
using univer.moodle;

namespace Inscriptions
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Extraction ex = new Extraction();
            User user = new User();

            user.username = "4512454512";
            user.firstname = "moises";
            user.lastname = "rangel";
            user.password = "hashhash";
            user.group1 = "SPEG-5454545";
            user.email = "moises.rangel@gmail.com";
            user.course1 = "SHALALA";
            user.type1 = 1;

            ex.Users.Add(user);

            ex.toCSV(@"C:\Users\E-LEARNING5\Documents\");
             */


            MoodleUser user = new MoodleUser();
            user.firstname = "moi";
            user.lastname = "rangel";
            user.email = "mraasdfngel@gmail.com";
            user.username = "olakease";

            Moodle.Instance.token = "a470930b7e19172703769387b93c761e";
            Moodle.Instance.domain = "elearning.univermilenium.edu.mx";
            Moodle.Instance.CreateUser(user);
        }
    }
}
