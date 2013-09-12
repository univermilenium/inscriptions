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
          
            Console.WriteLine("Presione Enter para iniciar la extracción de alumnos...");
            Console.WriteLine("Plantel: " + Inscriptions.Properties.Settings.Default.plantel);
            Console.ReadLine();
            try
            {
                Extraction ex      = new Extraction();
                string plantel     = Inscriptions.Properties.Settings.Default.plantel;
                string conn        = Inscriptions.Properties.Settings.Default.FbConnectionstring;
                string path        = Inscriptions.Properties.Settings.Default.outputpath;
                ex.trackConnection = Inscriptions.Properties.Settings.Default.TrackingConnection;

                //all the magic is inside!
                ex.getUsers(plantel, conn).toCSV(path, "usuarios");

                Console.ReadLine();

                if (ex.Errors.Count > 0) 
                {
                    Console.WriteLine(string.Format("Hay {0} errores. Presione Enter para visualizarlos.", ex.Errors.Count));
                    foreach (string error in ex.Errors) 
                    {
                        Console.WriteLine(error);
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
