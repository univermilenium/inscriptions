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

namespace univer.moodle
{
    public sealed class Moodle
    {
        public string token { get; set; }
        public string domain { get; set; }
        static readonly Moodle instance = new Moodle();
        static Moodle(){}
        Moodle() {}
        public static Moodle Instance
        {
            get
            {
                return instance;
            }
        }

        /*
         * based on https://moodle.org/mod/forum/discuss.php?d=210866
         */
        public List<MoodleResponse> CreateUser(MoodleUser user) 
        {
            String postData      = String.Format("users[0][username]={0}&users[0][password]={1}&users[0][firstname]={2}&users[0][lastname]={3}&users[0][email]={4}", user.username, user.password, user.firstname, user.lastname, user.email);
            string createRequest = string.Format("http://{0}/webservice/rest/server.php?wstoken={1}&wsfunction={2}&moodlewsrestformat=json", this.domain, this.token, "core_user_create_users");

            // Call Moodle REST Service
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(createRequest);
            req.Method         = "POST";
            req.ContentType    = "application/x-www-form-urlencoded";

            // Encode the parameters as form data:
            byte[] formData   =  UTF8Encoding.UTF8.GetBytes(postData);
            req.ContentLength = formData.Length;

            // Write out the form Data to the request:
            using (Stream post = req.GetRequestStream())
            {
                post.Write(formData, 0, formData.Length);
            }

            // Get the Response
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream resStream = resp.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            string contents = reader.ReadToEnd();

            // Deserialize
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            if (contents.Contains("exception"))
            {
                MoodleException moodleError   = serializer.Deserialize<MoodleException>(contents);
                List<MoodleResponse> response = new List<MoodleResponse>();
                response.Add(moodleError);
                return response;
            }
            else
            {
                List<MoodleResponse> newUsers = serializer.Deserialize<List<MoodleResponse>>(contents);
                return newUsers;
            }
        }
    }
}
