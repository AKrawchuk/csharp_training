using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class UserData : IEquatable<UserData>, IComparable<UserData>
    {
        private string allPhones;
        private string allNames;
        private string allPhonesInfo;
        private string allEmails;
        private string allEmailsNewLine;
        private string allInfo;

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
                        string email2 = "second e-mail", 
                        string email3 = "third e-mail", 
                        string homepage = "",
                        string address2 = "", 
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

        public UserData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public UserData()
        {
            AllInfo = allInfo;
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
            int result = FirstName.CompareTo(other.FirstName);
            if (result == 0)
                result = LastName.CompareTo(other.LastName);
            return result;
        }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "middlename")]
        public string MiddleName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "nickname")]
        public string NickName { get; set; }

        public string AllNames
        {
            get
            {
                if (allNames != null)
                {
                    return allNames;
                }
                else
                {
                    return CleanUpAllNames(FirstName) + CleanUpAllNames(MiddleName) + CleanUpAllNames(LastName).Trim();
                }
            }
            set
            {
                allNames = value;
            }
        }
        private string CleanUpAllNames(string allNames)
        {
            if (allNames == null || allNames == "")
            {
                return "";
            }
            return allNames + " ";
        }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomeNumber { get; set; }

        [Column(Name = "mobile")]
        public string CellNumber { get; set; }

        [Column(Name = "work")]
        public string WorkNumber { get; set; }

        [Column(Name = "fax")]
        public string FaxNumber { get; set; }

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
                    return (CleanUpPhones(HomeNumber) + CleanUpPhones(CellNumber) + CleanUpPhones(WorkNumber)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUpPhones(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
        public string AllPhonesInfo
        {
            get
            {
                if (allPhonesInfo != null)
                {
                    return allPhonesInfo;
                }
                else
                {
                    return "\r\n" + CleanUpHomePhone(HomeNumber)
                                  + CleanUpCellPhone(CellNumber)
                                  + CleanUpWorkPhone(WorkNumber)
                                  + CleanUpFaxPhone(FaxNumber).Trim();
                }
            }
            set
            {
                allPhonesInfo = value;
            }
        }
        private string CleanUpHomePhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return "H: " + phone + "\r\n";
        }
        private string CleanUpCellPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return "M: " + phone + "\r\n";
        }
        private string CleanUpWorkPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return "W: " + phone + "\r\n";
        }
        private string CleanUpFaxPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return "F: " + phone + "\r\n";
        }

        [Column(Name = "email")]
        public string Email1 { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return CleanUpAllEmails(Email1) + CleanUpAllEmails(Email2) + CleanUpAllEmails(Email3).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        public string AllEmailsNewLine
        {
            get
            {
                if (allEmailsNewLine != null)
                {
                    return allEmailsNewLine;
                }
                else
                {
                    return "\r\n" + CleanUpAllEmails(Email1) + CleanUpAllEmails(Email2) + CleanUpAllEmails(Email3).Trim();
                }
            }
            set
            {
                allEmailsNewLine = value;
            }
        }
        private string CleanUpAllEmails(string allEmails)
        {
            if (allEmails == null || allEmails == "")
            {
                return "";
            }
            return allEmails + "\r\n";
        }
        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        [Column(Name = "address2")]
        public string Address2 { get; set; }

        [Column(Name = "phone2")]
        public string SecondaryHome { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string AllInfo
        {
            get
            {
                if (allInfo != null)
                {
                    return allInfo;
                }
                else
                {
                    return (CleanUpAllInfo(AllNames)
                        + CleanUpAllInfo(NickName)
                        + CleanUpAllInfo(Title)
                        + CleanUpAllInfo(Company)
                        + CleanUpAllInfo(Address)
                        + CleanUpAllInfo(AllPhonesInfo)
                        + CleanUpAllInfo(AllEmailsNewLine)).Trim();
                }
            }
            set
            {
                allInfo = value;
            }
        }
        private string CleanUpAllInfo(string allInfo)
        {
            if (allInfo == null || allInfo == "")
            {
                return "";
            }
            return allInfo + "\r\n";
        }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<UserData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select g).ToList();
            }
        }
    }
}
