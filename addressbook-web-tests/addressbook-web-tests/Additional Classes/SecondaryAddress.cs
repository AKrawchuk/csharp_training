using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class SecondaryAddress
    {
        private string _address2;
        private string _secondaryHome;
        private string _notes;
        
        public SecondaryAddress(string address2, string secondaryHome = "Elsewhere", string notes = "bla-bla-bla")
        {
            Address2 = address2;
            SecondaryHome = secondaryHome;
            Notes = notes;
        }
        public string Address2
        {
            get
            {
                return _address2;
            }
            set
            {
                _address2 = value;
            }
        }
        public string SecondaryHome
        {
            get
            {
                return _secondaryHome;
            }
            set
            {
                _secondaryHome = value;
            }
        }
        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
            }
        }
    }
}
