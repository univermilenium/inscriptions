using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using univer.extractions;

namespace playground
{
    class Program
    {

            public static int RoundOff(int i)
            {
                return ((int)Math.Round(i / 100.0)) * 100;
            }
        

        static void Main(string[] args)
        {
            string text = "CRIM0103";
            string text2 = "SCR-401-Neza";

            string justNumbers = new String(text.Where(Char.IsDigit).ToArray());
            string justNumbers2 = new String(text2.Where(Char.IsDigit).ToArray());

            int numb = int.Parse(justNumbers);
            int numb2 = int.Parse(justNumbers2);

            if (numb != numb2) 
            {
                Console.WriteLine("Diff");
            }


            User moi = new User();

            moi.username = "654654654";
            moi.password = "65465465";
            moi.firstname = "Moisés";
            moi.lastname = "Rangel";
            moi.email = "moises.rangel@gmail.com";
            moi.group1 = "SCR-401-Neza";
            moi.course1 = "CRIM0103";
            moi.type1 = 1;

            moi.isValid();

            Console.WriteLine(Program.RoundOff(numb));
            Console.WriteLine(Program.RoundOff(numb2));
            Console.ReadLine();
        }
    }
}
