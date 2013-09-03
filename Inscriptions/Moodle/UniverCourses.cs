using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace univer.moodle
{
    public class UniverCourses
    {
        static public int MPS0101 = 1;
        static public int MDER0101 = 2;
        static public int CRIM0103 = 3;
        static public int MPEG0103 = 4;
        static public int MPEG0418 = 5;

        public int getID(string shortname) 
        {
            int mid = (int)this.GetType().GetField(shortname).GetValue(this);
            return mid;
        }
    }
}
