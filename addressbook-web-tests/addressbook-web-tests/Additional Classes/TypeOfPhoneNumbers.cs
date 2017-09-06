using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class TypeOfPhoneNumbers
    {
        private string _homeNumber;
        private string _cellNumber;
        private string _workNumber;
        private string _faxNumber;

        public TypeOfPhoneNumbers(string cellNumber, string homeNumber = "111111111", string workNumber = "22222222", string faxNumber = "333333333")
        {
            HomeNumber = homeNumber;
            CellNumber = cellNumber;
            WorkNumber = workNumber;
            FaxNumber = faxNumber;
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
    }
}
