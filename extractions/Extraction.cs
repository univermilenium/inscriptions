using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using univer.moodle;

namespace univer.extractions
{
    public class Extraction
    {
        public List<User> Users;
        public List<string> Errors;
        public Extraction()  
        {
            this.Users = new List<User>();
            this.Errors = new List<string>();
        }

        public Extraction getUsers() 
        {
            //consulta a interbase

            return this;
        }
        public void toCSV(string path)
        {
            string filename = string.Format("{0}usuarios.csv", path);
      
            if (this.Users.Count() > 0) 
            {    
                string header   = "username,password,Firstname,Lastname ,email,course1,group1,TYPE1";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename))
                {
                    file.WriteLine(header);
                    foreach (User user in this.Users)
                    {
                        try
                        {
                            if (user.isValid())
                            {
                                string row = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", user.username, user.username, user.firstname, user.lastname, user.email, user.course1, user.group1, user.type1);
                                file.WriteLine(row);
                            }
                        }
                        catch (Exception oe)
                        {
                            this.Errors.Add(oe.Message.ToString());
                        }
                    }
                }

                return;
            }

            throw new Exception("No hay usuarios a exportar");
        }
        public void toREST() 
        {

            //obtener id del curso
            //obtener id del grupo
            //obtener id del usuari
            //enrolar idusuario a curso
            //enrolar idusuario a grupo

            List<string> groups = new List<string>();
            List<string> errors = new List<string>();

            if (this.Users.Count() > 0)
            {
                foreach (User user in this.Users)
                {
                    try
                    {
                        //obtener id del curso.
                        MoodleCourse course = Moodle.Instance.getCourse(user.course1);
                        
                        //crear - obtener grupo
                        if (Moodle.Instance.createGroup(course, user.course1, "Grupo para " + course.name)) 
                        {
                            
                        }
                    }
                    catch
                    {
                        this.Errors.Add(user.toString());
                    }
                }
            }
        }

    }
}
