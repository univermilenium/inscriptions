using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using univer.moodle;

namespace univer.extractions
{
    public class User
    {
        public string username  { get; set; }
        public string password  { get; set; }
        public string firstname { get; set; }
        public string lastname  { get; set; }
        public string email     { get; set; }
        private string _course1;
        public string course1
        {
            get { return this._course1; }
            set 
            {                 
                this._course1 = this.getValidCourse(value); 
            }        
        }
        public string group1    { get; set; }
        public int    type1     { get; set; }

        private string getValidCourse(string course) 
        {
            string val = string.Empty;

            switch (course) 
            {
                case "MPEG-103":
                    val = "MPEG0103";
                    break;

                case "MPEG-418":
                    val = "MPEG0418";
                    break;

                case "MPEG-0103":
                    val = "MPEG0103";
                    break;

                case "MPEG-0418":
                    val = "MPEG0418";
                    break;

                case "MDER101":
                    val = "MDER0101";
                    break;
                default:
                    val = course;
                    break;
            }

            return val;

        }


        public static int RoundOff(int i)
        {
            return ((int)Math.Round(i / 100.0)) * 100;
        }

        public bool isValid() 
        {
            try 
            {   
                this.IsValidCourse();
                this.IsValidGroup();
                this.IsValidType();
                this.IsValidUsername();
                this.IsValidFullName();
                this.IsValidEmail();
                return true;
            }
            catch (Exception oe)
            {
                throw new Exception(string.Format("Registro no válido. {0}", oe.Message.ToString()));
            }
        }

        public string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", " ", RegexOptions.Compiled);
        }

        public string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public string toString() 
        {
            return string.Format("matricula: {0}, grupo: {1}, curso: {2}", this.username, this.group1, this.course1);
        }

        private void IsValidFullName()
        {
            if (this.firstname.Equals(string.Empty)) 
            {
                throw new Exception("El nombre está vacio");
            }

            if (this.lastname.Equals(string.Empty))
            {
                throw new Exception("El apellido está vacio");
            }

            this.firstname = this.RemoveDiacritics(this.firstname);
            this.lastname = this.RemoveDiacritics(this.lastname);
        }

        //Valida que el curso no esté vacio, además de la correspondencia del cuatrimestre según la nomenclatura del grupo con  la asignatura.
        private void IsValidCourse() 
        {
            if (this.course1.Equals(string.Empty))
            {
                throw new Exception("El curso está vacio");
            }

            string text_course = new String(this.course1.Where(Char.IsDigit).ToArray());
            string text_group = new String(this.group1.Where(Char.IsDigit).ToArray());

            int grade_course = User.RoundOff(int.Parse(text_course));
            int grade_group = User.RoundOff(int.Parse(text_group));

            if (grade_course != grade_group) 
            {
                throw new Exception(string.Format("El cuatrimestre del grupo {0} no corresponde al cuatrimestre de asignatura {1}. Matricula: {2}", this.group1, this.course1, this.username));
            }
        }

        private void IsValidUsername() 
        {
            if (this.username.Equals(string.Empty))
            {
                throw new Exception("Matrícula vacia");
            }
        }

        private void IsValidGroup() 
        {
            string first = this.group1.ToLower()[0].ToString();
            if (!first.Equals("s"))
            {
                throw new Exception(string.Format("Grupo no válido: {0}", this.group1));
            }
        }

        private void IsValidType() 
        {
            //solo 1 y 3 (student y non-editing teachear)
            if (this.type1 == 1 || this.type1 == 3 )
            {
                return;
            }

            throw new Exception(string.Format("Tipo de usuario no válido: {0}", this.type1.ToString()));
            
        }

        private bool IsValidEmail()
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(this.email);
                return true;
            }
            catch
            {
                this.email = string.Format("{0}@tmp.univermilenium.edu.mx", this.username);
                return true;
            }
        }        
    }
}
