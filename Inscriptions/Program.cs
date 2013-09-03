﻿using System;
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

            // test para CreateUser
            /*
            MoodleUser user = new MoodleUser();
            user.firstname = "moi";
            user.lastname = "rangel";
            user.email = "test23@gmail.com";
            user.username = "test23";

            Moodle.Instance.token = "a470930b7e19172703769387b93c761e";
            Moodle.Instance.domain = "elearning.univermilenium.edu.mx";
            Moodle.Instance.CreateUser(user);
            */

            MoodleUser user = new MoodleUser();
            user.id = 1035;
            user.firstname = "moi";
            user.lastname = "rangel";
            user.email = "test23@gmail.com";
            user.username = "test23";

            MoodleCourse course = new MoodleCourse();
            course.id = 32;

            Moodle.Instance.token = "a470930b7e19172703769387b93c761e";
            Moodle.Instance.domain = "elearning.univermilenium.edu.mx";
            Moodle.Instance.EnrolUserToCourse(user, course, 1, 0, 0, 0);
            
        }
    }
}
