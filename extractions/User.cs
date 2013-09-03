using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public string course1   { get; set; }
        public string group1    { get; set; }
        public int    type1     { get; set; }

        public bool isValid() 
        {
            try 
            {
                this.IsValidEmail();
                this.IsValidCourse();
                this.IsValidGroup();
                this.IsValidType();
                this.IsValidUsername();
                this.IsValidFullName();

                return true;
            }
            catch (Exception oe)
            {
                throw new Exception(string.Format("Registro no válido. {0}", oe.Message.ToString()));
            }
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
        }

        private void IsValidCourse() 
        {
            if (this.course1.Equals(string.Empty))
            {
                throw new Exception("El curso está vacio");
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
                throw new Exception(string.Format("Email no válido: {0}", this.email));
            }
        }        
    }
}
