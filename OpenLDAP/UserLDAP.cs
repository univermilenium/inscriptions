using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace univer.LDAP
{
    public class UserLDAP
    {       
        public string cn { get; set; }
        public string sn { get; set; }
        public string seeAlso { get; set; }
        public string userPassword { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string postalAddress { get; set; }

        public void isValid() 
        {
            this.isValidCn();
            this.isValidSeeAlso();
            this.isValidUserPassword();
            this.isValidTitle();
            this.isValidDescription();
            this.IsValidEmail();
        }

        private void isValidCn() 
        {
            if (this.cn.Equals(string.Empty))
            {
                throw new Exception("CN vacia");
            }
        }

        private void isValidSn()
        {
            if (this.cn.Equals(string.Empty))
            {
                throw new Exception("SN vacia");
            }
        }

        private void isValidSeeAlso()
        {
            if (this.cn.Equals(string.Empty))
            {
                throw new Exception("See Also vacia");
            }
        }

        private void isValidUserPassword()
        {
            if (this.cn.Equals(string.Empty))
            {
                throw new Exception("Password vacia");
            }
        }

        private void isValidTitle()
        {
            if (this.cn.Equals(string.Empty))
            {
                throw new Exception("Title vacia");
            }
        }

        private void isValidDescription()
        {
            if (this.cn.Equals(string.Empty))
            {
                throw new Exception("Description vacia");
            }
        }

        private bool IsValidEmail()
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(this.postalAddress);
                return true;
            }
            catch
            {
                this.postalAddress = string.Format("{0}@univermilenium.edu.mx", this.cn);
                return true;
            }
        }  
    }
}
