using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using univer.extractions;
using univer.moodle;

using System.Configuration;

namespace Inscriptions
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                
                string plantel     = Inscriptions.Properties.Settings.Default.plantel;
                string conn        = Inscriptions.Properties.Settings.Default.FbConnectionstring;
                string path        = Inscriptions.Properties.Settings.Default.outputpath;
                string type        = Inscriptions.Properties.Settings.Default.usertype;
                string track       = Inscriptions.Properties.Settings.Default.TrackingConnection;

                Extraction ex = new Extraction(type, track);

                Console.WriteLine("Presione Enter para iniciar la extracción de " + type);
                Console.WriteLine("Plantel: " + plantel);
                Console.ReadLine();

                //all the magic is inside!
                string file = string.Empty;
                switch(type)
                {
                    case "usuarios":
                        file = ex.getUsers(plantel, conn).toCSV(path);
                        break;
                    case "profesores":
                        file = ex.getTeachers(plantel, conn).toCSV(path);
                        break;
                    default:
                        throw new Exception("No existe el tipo: " + type.ToString());
                }

                Console.WriteLine(string.Format("Hay {0} errores. Presione Enter para continuar.", ex.Errors.Count));
                Console.ReadLine();

                if (ex.Errors.Count > 0) 
                {
                    string filepath = string.Format("{0}error_{1}.log", path, DateTime.Now.ToString("MM-dd-yyyy-hhmmss"));
                    using (System.IO.StreamWriter filelog = new System.IO.StreamWriter(filepath))
                    {
                        filelog.WriteLine(string.Format("Error.log para el archivo {0}:", file));

                        foreach (string error in ex.Errors)
                        {                            
                            filelog.WriteLine(error);
                            Console.WriteLine(error);
                        }                        
                    }

                    Console.ReadLine();
                }
            }
            catch (Exception oe) 
            {
                Console.WriteLine(oe.Message.ToString());
                Console.ReadLine();
            }
        }
    }
}
