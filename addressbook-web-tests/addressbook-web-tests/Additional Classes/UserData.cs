using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class UserData
    {
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _nickname;
        private string _title;
        private string _company;
        private string _address;

        public UserData(string firstName,
                    string lastName,
                    string middleName = "MiddleName",
                    string nickName = "NickName",
                    string title = "Some Title",
                    string company = "SomeCompany", 
                    string address = "Some Address")
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            NickName = nickName;
            Title = title;
            Company = company;
            Address = address;
        }
        
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public string MiddleName
        {
            get
            {
                return _middleName;
            }
            set
            {
                _middleName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        public string NickName
        {
            get
            {
                return _nickname;
            }
            set
            {
                _nickname = value;
            }
        }
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }
        public string Company
        {
            get
            {
                return _company;
            }
            set
            {
                _company = value;
            }
        }
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

    }


}
