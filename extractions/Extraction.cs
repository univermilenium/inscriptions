using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Odbc;
using System.Configuration;

using univer.moodle;

using FirebirdSql.Data.FirebirdClient;


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

        private string getQuery(string plantel) 
        {
            string query = string.Empty;

            if (plantel == Querys.SALUD)
            {
                query = Querys.salud();
            }

            if (plantel == Querys.IXTAPA)
            {
                query = Querys.ixtapaluca();
            }

            if (plantel == Querys.NEZA)
            {
                query = Querys.neza();
            }

            if (plantel == Querys.RAYON)
            {
                query = Querys.rayon();
            }

            if (plantel == Querys.HIDALGO)
            {
                query = Querys.hidalgo();
            }

            if (plantel.Equals(string.Empty)) { throw new Exception(string.Format("No existe el plantel: "+plantel)); }
      
            return query;
        }

        public Extraction getUsers(string plantel) 
        {
            string connectionstring = "ServerType=0;User=SYSDBA;Password=masterkey;Size=4096;Dialect=3;Pooling=FALSE;database=localhost:c:\\escolar\\DATOS.GDB";
            List<object[]> usersq = this.QueryFb(connectionstring, this.getQuery(plantel));
            //List<object[]> usersq = this.QueryFb(connectionstring, "select * from alumnos where nombre = 'MARIANA'");
            
            if (usersq.Count > 0) 
            {
                Console.WriteLine(string.Format("{0} usuarios a subir...", usersq.Count));
                
                int cont = 0;
                foreach (object user in usersq) 
                {
                    User MyUser = new User();

                    MyUser.username   = usersq[cont][0].ToString();
                    MyUser.password   = usersq[cont][1].ToString(); 
                    MyUser.firstname  = usersq[cont][2].ToString(); 
                    MyUser.lastname   = usersq[cont][3].ToString(); 
                    MyUser.course1    = usersq[cont][4].ToString(); 
                    MyUser.group1     = usersq[cont][5].ToString();

                    try
                    {
                        MyUser.type1 = int.Parse(usersq[cont][5].ToString());
                    }
                    catch 
                    {
                        MyUser.type1 = 0;
                    }

                    try
                    {
                        if(MyUser.isValid())
                        {
                            this.Users.Add(MyUser);
                            Console.WriteLine(string.Format("Se agrega {} al envio..."), MyUser.username);
                        }
                    }
                    catch(Exception oe) 
                    {
                        this.Errors.Add(oe.Message.ToString());
                    }
                    
                    cont++;
                }
            }

            return this;
        }

        private List<object[]> QueryFb(string connectionstring, string query) 
        {   
            try 
            {
                using (FbConnection dbConn = new FbConnection(connectionstring)) 
                {
                    Console.WriteLine("Consultando Control Escolar");

                    dbConn.Open();

                    using (var command = dbConn.CreateCommand())
                    {
                        command.CommandText = query;
                        using (var reader = command.ExecuteReader())
                        {
                            var rows = new List<object[]>();
                            while (reader.Read())
                            {
                                var columns = new object[reader.FieldCount];
                                reader.GetValues(columns);
                                rows.Add(columns);
                            }
                            return rows;
                        }
                    }                    
                }

            }catch(System.Exception oe)
            {
                throw new Exception(oe.Message);
            }
           
        }
        
        public void toCSV(string path)
        {
            string filename = string.Format("{0}usuarios.csv", path);
      
            if (this.Users.Count() > 0) 
            {
                Console.WriteLine(string.Format("Exportando {} registros de alumnos a formato csv.", this.Users.Count()));

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

            //Moodle.Instance.token   = ConfigurationSettings.AppSettings["token"];
            //Moodle.Instance.domain = "elearning.univermilenium.edu.mx";

            //obtener id del curso
            //obtener id del grupo
            //obtener id del usuari
            //enrolar idusuario a curso
            //enrolar idusuario a grupo

            List<string> groups = new List<string>();
            List<string> errors = new List<string>();

            /*
                dummies users
             */

            this.Users = new List<User>();
            User dummy = new User();

            dummy.username  = "dummy";
            dummy.firstname = "crash";
            dummy.lastname  = "test dummy";
            dummy.password  = "Dummy01$";
            dummy.email     = "dummy@testland.com";
            dummy.course1   = "PRUEBA";
            dummy.group1    = "GRUPODUMMIES";
            dummy.type1     = 1;

            this.Users.Add(dummy);

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
