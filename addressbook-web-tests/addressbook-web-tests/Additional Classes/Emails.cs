using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class Emails
    {
        private string _email1;
        private string _email2;
        private string _email3;
        private string _homepage;

        public Emails(string email1, string email2 = "second e-mail", string email3 = "third e-mail", string homepage = "google.com" )
        {
            Email1 = email1;
            Email2 = email2;
            Email3 = email3;
            Homepage = homepage;
        }
        public string Email1
        {
            get
            {
                return _email1;
            }
            set
            {
                _email1 = value;
            }
        }
        public string Email2
        {
            get
            {
                return _email2;
            }
            set
            {
                _email2 = value;
            }
        }
        public string Email3
        {
            get
            {
                return _email3;
            }
            set
            {
                _email3 = value;
            }
        }
        public string Homepage
        {
            get
            {
                return _homepage;
            }
            set
            {
                _homepage = value;
            }
        }
    }
}
