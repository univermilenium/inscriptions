using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using univer.moodle;

using System.Configuration;

namespace Inscriptions
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            Moodle.Instance.token = "828b4f2b0836a6b18e9a0a515e5b0ad8";
            Moodle.Instance.domain = "ec2-54-234-253-120.compute-1.amazonaws.com/moodle/";

            MoodleUser user = new MoodleUser();

            //VERIFICA SI EXISTE EL USUARIO EN MOODLE

            string key = "username";
            user.username = "inscripcion";
            Moodle.Instance.VerifyUser(key, user.username);

                if (Moodle.Instance.contents.Contains(user.username)) 
                {
                    Console.WriteLine("SE ENCONTRO EL USUARIO");
                    Console.WriteLine(Moodle.Instance.contents);
                    Console.ReadLine();

                    //PONER EN VARIABLES LOS DATOS PARA PASAR A LA MATRICULACION
                }
                else
                {
                    //CREA EL USUARIO USUARIO

                    user.username = "inscripcion";
                    user.firstname = "Usuario";
                    user.lastname = "de Inscripciones";
                    user.email = "trippuser@gmail.com";
                    user.auth = "ldap";
                    Moodle.Instance.CreateUser(user);

                    if (Moodle.Instance.contents.Contains(user.username))
                    {
                        Console.WriteLine("SE CREO EL USUARIO");
                        Console.WriteLine(Moodle.Instance.contents);
                        Console.ReadLine();

                        //PONER EN VARIABLES LOS DATOS PARA PASAR A LA MATRICULACION
                    }
                        else
                    {
                        //EXCEPCION
                        Console.WriteLine("EXCEPCION: NO SE CREO EL USUARIO");
                        Console.WriteLine(Moodle.Instance.contents);
                        Console.ReadLine();
                    }
                }

            //OBTIENE EL ID DE LA MATERIA (CATALOGO) Y VERIFICA SI EXISTE LA MATERIA EN MOODLE

            MoodleCourse course = new MoodleCourse();
            course.shortname = "curso";
            Moodle.Instance.VerifyCourse(course.shortname);

            if (Moodle.Instance.contents.Contains(course.shortname))
                {
                Console.WriteLine("LA MATERIA EXISTE");
                Console.WriteLine(Moodle.Instance.contents);
                Console.ReadLine();
                }
            else
                {
                //EXCEPCION
                Console.WriteLine("EXCEPCION: NO EXISTE LA MATERIA");
                Console.WriteLine(Moodle.Instance.contents);
                Console.ReadLine();
                }

            ////VERIFICA SI EXISTE EL GRUPO EN MOODLE

            //            if(/*EXISTE GRUPO*/)
            //                {
            //                Console.WriteLine("EL GRUPO EXISTE");
            //                Console.ReadLine();

            //                //GUARDAR VARIABLES PARA PASAR A LA MATRICULACION
            //                }
            //                else
            //                {
            //                //EXCEPCION
            //                Console.WriteLine("EXCEPCION: NO EXISTE EL GRUPO");
            //                Console.ReadLine();

            //                //CREAR EL GRUPO

            //                if(/*createGroup*/)
            //                {
            //                    Console.WriteLine("SE CREO EL GRUPO");
            //                    Console.ReadLine();
            //                }
            //                else
            //                {
            //                    //EXCEPCION
            //                    Console.WriteLine("NO SE CREO EL GRUPO");
            //                    Console.ReadLine();
            //                }
            //                }

            ////MATRICULA EN MOODLE

            //user.id = 16;
            //user.username = "inscripcion";

            //if(/*EnrolUserToCourse*/)
            //{
            //    Console.WriteLine("SE MATRICULO AL USUARIO");
            //    Console.ReadLine();
            //}
            //else
            //{
            //    //EXCEPCION
            //    Console.WriteLine("EXCEPCION: NO SE MATRICULO AL USUARIO");
            //}
       
        }
    }
}
