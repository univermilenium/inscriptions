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
        public string plantel;
        public string trackConnection;
        public string type = string.Empty;
        
        public Extraction(string type)  
        {
            this.Users = new List<User>();
            this.Errors = new List<string>();
            this.type = type;
        }

        public Extraction(string type, string trackConnection)
        {
            this.Users = new List<User>();
            this.Errors = new List<string>();
            this.type = type;
            this.trackConnection = trackConnection;
        }

        private string getQuery(string plantel) 
        {
            string query = string.Empty;

            if (plantel == Querys.SALUD)
            {
                query = Querys.salud();
                this.plantel = Querys.SALUD.ToLower();
            }

            if (plantel == Querys.IXTAPA)
            {
                query = Querys.ixtapaluca();
                this.plantel = Querys.IXTAPA.ToLower();
            }

            if (plantel == Querys.NEZA)
            {
                query = Querys.neza();
                this.plantel = Querys.NEZA.ToLower();
            }

            if (plantel == Querys.RAYON)
            {
                query = Querys.rayon();
                this.plantel = Querys.RAYON.ToLower();
            }

            if (plantel == Querys.HIDALGO)
            {
                query = Querys.hidalgo();
                this.plantel = Querys.HIDALGO.ToLower();
            }

            if (plantel.Equals(string.Empty)) { throw new Exception(string.Format("No existe el plantel: "+plantel)); }
      
            return query;
        }

        private string getTeacherQuery(string plantel)
        {
            string query = string.Empty;

            if (plantel == Querys.SALUD)
            {
                query = QuerysTeachers.salud();
                this.plantel = Querys.SALUD.ToLower();
            }

            if (plantel == Querys.IXTAPA)
            {
                query = QuerysTeachers.ixtapaluca();
                this.plantel = Querys.IXTAPA.ToLower();
            }

            if (plantel == Querys.NEZA)
            {
                query = QuerysTeachers.neza();
                this.plantel = Querys.NEZA.ToLower();
            }

            if (plantel == Querys.RAYON)
            {
                query = QuerysTeachers.rayon();
                this.plantel = Querys.RAYON.ToLower();
            }

            if (plantel == Querys.HIDALGO)
            {
                query = QuerysTeachers.hidalgo();
                this.plantel = Querys.HIDALGO.ToLower();
            }

            if (plantel.Equals(string.Empty)) { throw new Exception(string.Format("No existe el plantel: " + plantel)); }

            return query;
        }
        
        public Extraction getTeachers(string plantel, string connectionstring) 
        {
            List<object[]> usersq = this.QueryFb(connectionstring, this.getTeacherQuery(plantel));

            if (usersq.Count > 0)
            {
                Console.WriteLine(string.Format("{0} profesores a subir...", usersq.Count));
                string planteldeco = this.plantel[0].ToString().ToUpper() + this.plantel.Substring(1);

                int cont = 0;
                foreach (object user in usersq)
                {
                    User MyUser = new User();
                    try
                    {   
                        MyUser.username = usersq[cont][0].ToString();
                        MyUser.password = usersq[cont][0].ToString();
                        MyUser.firstname = "Profesor";
                        MyUser.lastname = usersq[cont][1].ToString();
                        MyUser.email = usersq[cont][2].ToString().ToLower();
                        MyUser.course1 = usersq[cont][4].ToString();
                        MyUser.group1 = string.Format("{0}-{1}", usersq[cont][3].ToString(), planteldeco);
                        MyUser.type1 = 3;

                    }
                    catch (Exception oe) 
                    {
                        Console.WriteLine(oe.ToString());
                        this.Errors.Add(oe.Message.ToString());
                    }

                    try
                    {
                        bool isvalid = MyUser.isValid();
                        if (isvalid)
                        {
                            this.Users.Add(MyUser);
                            Console.WriteLine(string.Format("Se agrega {0} al envio...", MyUser.username));
                        }
                    }
                    catch (Exception oe)
                    {
                        this.Errors.Add(oe.Message.ToString());
                        Console.WriteLine(oe.Message.ToString());
                    }

                    cont++;
                }
            }

            return this;

        
        }

        public Extraction getUsers(string plantel, string connectionstring) 
        {
            List<object[]> usersq = this.QueryFb(connectionstring, this.getQuery(plantel));
            
            if (usersq.Count > 0) 
            {
                Console.WriteLine(string.Format("{0} usuarios a subir...", usersq.Count));
                string planteldeco = this.plantel[0].ToString().ToUpper() + this.plantel.Substring(1);

                int cont = 0;
                foreach (object user in usersq) 
                {
                    User MyUser = new User();

                    MyUser.username   = usersq[cont][0].ToString();
                    MyUser.password   = usersq[cont][0].ToString(); 
                    MyUser.firstname  = usersq[cont][1].ToString();
                    MyUser.lastname   = string.Format("{0} {1}", usersq[cont][2].ToString(), usersq[cont][3].ToString());
                    MyUser.email      = usersq[cont][4].ToString().ToLower();
                    MyUser.course1    = usersq[cont][6].ToString(); 
                    MyUser.group1     = string.Format("{0}-{1}", usersq[cont][5].ToString(), planteldeco);
                    MyUser.type1 = 1;

                    try
                    {
                        bool isvalid = MyUser.isValid();
                        if(isvalid)
                        {   
                            this.Users.Add(MyUser);
                            Console.WriteLine(string.Format("Se agrega {0} al envio...", MyUser.username));
                        }
                    }
                    catch(Exception oe) 
                    {
                        this.Errors.Add(oe.Message.ToString());
                        Console.WriteLine(oe.Message.ToString());
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
        
        public string toCSV(string path)
        {
            string filename = string.Format("{0}{3}_{1}_{2}.csv", path, this.plantel, DateTime.Now.ToString("MM-dd-yyyy-hhmmss"), this.type);
   
            if (this.Users.Count() > 0)
            {
                Console.WriteLine(string.Format("Exportando {0} registros de alumnos a formato csv.", this.Users.Count()));

                string header = "username,password,firstname,lastname,email,course1,group1,TYPE1";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename))
                {
                    file.WriteLine(header);
                    foreach (User user in this.Users)
                    {
                        try
                        {
                            if (user.isValid())
                            {

                                if (!Tracking.uniqueinscription(user, this.trackConnection, this.type, "FIREBIRD")) 
                                {
                                    string row = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", user.username, user.username, user.firstname, user.lastname, user.email, user.course1, user.group1, user.type1);
                                    file.WriteLine(row);
                                   Tracking.trackuser(user, this.trackConnection, this.type, "FIREBIRD");                                
                                }
                            }
                        }
                        catch (Exception oe)
                        {
                            this.Errors.Add(oe.Message.ToString());
                        }
                    }
                }

                Console.WriteLine(string.Format("El archivo \"{0}\" se generó con éxito.", filename));

                return filename;
            }
            else 
            {
                throw new Exception("No hay usuarios a exportar");
            }
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
