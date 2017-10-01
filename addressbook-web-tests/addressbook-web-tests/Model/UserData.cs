using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class UserData : IEquatable<UserData>, IComparable<UserData>
    {
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _nickname;
        private string _title;
        private string _company;
        private string _address;

        private string _homeNumber;
        private string _cellNumber;
        private string _workNumber;
        private string _faxNumber;

        private string _email1;
        private string _email2;
        private string _email3;
        private string _homepage;

        private string _address2;
        private string _secondaryHome;
        private string _notes;

        public UserData(string firstName,
                        string lastName,
                        string cellNumber,
                        string middleName = "MiddleName",
                        string nickName = "NickName",
                        string title = "Some Title",
                        string company = "SomeCompany", 
                        string address = "Some Address",
                        string homeNumber = "111111111", 
                        string workNumber = "22222222", 
                        string faxNumber = "333333333",
                        string email1 = "first e-mail", 
                        string email2 = "second e-mail", 
                        string email3 = "third e-mail", 
                        string homepage = "google.com",
                        string address2 = "Somewhere", 
                        string secondaryHome = "Elsewhere", 
                        string notes = "bla-bla-bla")
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            NickName = nickName;
            Title = title;
            Company = company;
            Address = address;

            HomeNumber = homeNumber;
            CellNumber = cellNumber;
            WorkNumber = workNumber;
            FaxNumber = faxNumber;

            Email1 = email1;
            Email2 = email2;
            Email3 = email3;
            Homepage = homepage;

            Address2 = address2;
            SecondaryHome = secondaryHome;
            Notes = notes;
        }

        public UserData(string firstName)
        {
            FirstName = firstName;
        }

        public bool Equals(UserData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (FirstName == other.FirstName) && (LastName == other.LastName);
        }

        public override int GetHashCode()           //---------------
        {
            return FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return FirstName;
        }

        public int CompareTo(UserData other)        //---------------
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstName.CompareTo(other.FirstName);
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
        public string HomeNumber
        {
            get
            {
                return _homeNumber;
            }
            set
            {
                _homeNumber = value;
            }
        }
        public string CellNumber
        {
            get
            {
                return _cellNumber;
            }
            set
            {
                _cellNumber = value;
            }
        }
        public string WorkNumber
        {
            get
            {
                return _workNumber;
            }
            set
            {
                _workNumber = value;
            }
        }
        public string FaxNumber
        {
            get
            {
                return _faxNumber;
            }
            set
            {
                _faxNumber = value;
            }
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
