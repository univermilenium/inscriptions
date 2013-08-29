using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace univer.moodle
{
    public abstract class MoodleResponse
    {
        public string response { get; set; }
        public string id { get; set; }
        public string username { get; set; }
    }
}
