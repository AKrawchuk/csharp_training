using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class UserData : IEquatable<UserData>, IComparable<UserData>
    {
        private string allPhones;

        public UserData(string firstName,
                        string lastName,
                        string cellNumber = "380504341555",
                        string middleName = "",
                        string nickName = "",
                        string title = "",
                        string company = "", 
                        string address = "Some Address",
                        string homeNumber = "111111111", 
                        string workNumber = "22222222", 
                        string faxNumber = "",
                        string email1 = "first e-mail", 
                        string email2 = "", 
                        string email3 = "", 
                        string homepage = "google.com",
                        string address2 = "Somewhere", 
                        string secondaryHome = "", 
                        string notes = "")
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

        public override int GetHashCode()           
        {
            return FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        public int CompareTo(UserData other)        
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstName.CompareTo(other.FirstName);
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Title { get; set; }        
        public string Company { get; set; }
        public string Address { get; set; }
        public string HomeNumber { get; set; }
        public string CellNumber { get; set; }
        public string WorkNumber { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomeNumber) + CleanUp(CellNumber) + CleanUp(WorkNumber)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
        public string FaxNumber { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string Address2 { get; set; }
        public string SecondaryHome { get; set; }
        public string Notes { get; set; }
    }
}
