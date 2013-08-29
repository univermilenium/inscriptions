using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void getUsers() 
        {
            //consulta a interbase
        }
        public void toCSV(string path)
        {
            System.IO.StreamWriter objWriter;
            string filename = string.Format("{0}\\usuarios.csv", path);
            objWriter = new System.IO.StreamWriter(filename, true);

            if (this.Users.Count() > 0) 
            {
    
                string header   = "username,password,Firstname,Lastname ,email,course1,group1,TYPE1\n\r";

                objWriter.WriteLine(header);
                foreach (User user in this.Users) 
                {
                    try
                    {
                        if (user.isValid())
                        {
                            string row = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}\n\r", user.username, user.username, user.firstname, user.lastname, user.email, user.course1, user.group1, user.type1);
                            objWriter.WriteLine(row);
                        }
                    }
                    catch (Exception oe) 
                    {
                        this.Errors.Add(oe.Message.ToString());
                    }
                }

                objWriter.Close();
                return;
            }

            throw new Exception("No hay usuarios a exportar");
        }
        public void toREST() { }

    }
}
