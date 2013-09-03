using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Web;

using System.Xml.Linq;

namespace univer.moodle
{
    public sealed class Moodle
    {
        public string token { get; set; }
        public string domain { get; set; }
        public string contents { get; set; }
        public XDocument xmlresponse { get; set; }
        
        //collect all errors
        public List<MoodleException> Exceptions { get; set; }

        static readonly Moodle instance = new Moodle();
        static Moodle(){}
       
        Moodle() 
        {
            this.Exceptions = new List<MoodleException>();
        }

        public static Moodle Instance
        {
            get
            {
                return instance;
            }
        }

        private string getRequestUrl(string wsfunction)
        {
            return string.Format("http://{0}/webservice/rest/server.php?wstoken={1}&wsfunction={2}&moodlewsrestformat=json", this.domain, this.token, wsfunction);
        }

        private HttpWebRequest request(string requestUrl) 
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(requestUrl);
            req.Method         = "POST";
            req.ContentType    = "application/x-www-form-urlencoded";
            return req;
        }
        
        /*
        * based on https://moodle.org/mod/forum/discuss.php?d=210866
        */
        private bool executeWs(string postData, string wsfunction) 
        {

            bool status = false;

            HttpWebRequest req = this.request(this.getRequestUrl(wsfunction));

            byte[] formData = UTF8Encoding.UTF8.GetBytes(postData);
            req.ContentLength = formData.Length;

            using (Stream post = req.GetRequestStream())
            {
                post.Write(formData, 0, formData.Length);
            }

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream resStream = resp.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            this.contents = reader.ReadToEnd();

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            if (this.contents.Contains("exception"))
            {
                MoodleException moodleError = serializer.Deserialize<MoodleException>(this.contents);
                this.Exceptions.Add(moodleError);
            }
            else
            {
                status = true;
            }

            return status;
        }

        public MoodleCourse getCourse(string shortname) 
        {
            MoodleCourse mcourse  = new MoodleCourse();
            UniverCourses courses = new UniverCourses();

            try
            {
                mcourse.id = courses.getID(shortname);
                mcourse.name = shortname;
            }
            catch (System.Exception oe) 
            {
                throw new Exception(string.Format("No existe el curso: {0}. {1}", shortname, oe.Message.ToString()));
            }
            
            return mcourse;
        }
        
        public bool addGroupMembers(MoodleUser user, MoodleGroup group) 
        {
            string postData = string.Format("members[0][groupid]={0}&members[0][userid]={1}", group.id, user.id);
            return this.executeWs(postData, "core_group_add_group_members");
        }

        public bool EnrolUserToCourse(MoodleUser user, MoodleCourse course, int roleid, int? timestart, int? timeend, int? suspend) 
        {
            string postData      = string.Format("enrolments[0][roleid]={0}&enrolments[0][userid]={1}&enrolments[0][courseid]={2}&enrolments[0][timestart]={3}&enrolments[0][timeend]={4}&enrolments[0][suspend]={5}", roleid, user.id, course.id, timestart, timeend, suspend);
            return this.executeWs(postData, "enrol_manual_enrol_users");
        }

        public bool CreateUser(MoodleUser user) 
        {
            string postData      = string.Format("users[0][username]={0}&users[0][password]={1}&users[0][firstname]={2}&users[0][lastname]={3}&users[0][email]={4}", user.username, user.password, user.firstname, user.lastname, user.email);
            return this.executeWs(postData, "core_user_create_users");
        }

        public bool createGroup(MoodleCourse course, string name, string description)
        {
            string postData = string.Format("groups[0][courseid]={0}&groups[0][name]={1}&groups[0][description]={2}", course.id, name, description);
            return this.executeWs(postData, "core_group_create_groups");
        }

        public string getSingleValueResponse(string key)
        {
            string val = string.Empty;
            
            if (this.xmlresponse == null) 
            {
                this.parseResponse();
            }

            foreach (XElement xe in this.xmlresponse.Descendants("KEY"))
            {
                if (xe.Attribute("name").Value.Equals(key)) 
                {
                    val = xe.Value.ToString();
                    break;
                }
            }
            return val;
        }

        private void parseResponse() 
        {   
            if (this.contents == null) 
            {
                throw new Exception("No hay respuesta del servidor.");
            }

           this.xmlresponse = XDocument.Parse(this.contents);  
        }
    }
}
