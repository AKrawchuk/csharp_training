using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper (ApplicationManager manager)
            : base(manager)
        {
        }

        private List<UserData> contactCache = null;

        public List<UserData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<UserData>();
                List<UserData>  contactCache1 = new List<UserData>();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    ICollection<IWebElement> cells = element.FindElements(By.TagName("td"));
                    contactCache.Add(new UserData(cells.ElementAt(2).Text, cells.ElementAt(1).Text));
                }
            }
            
            return new List<UserData>(contactCache);
        }

        public ContactHelper AddNewContactClick()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper SaveNewContactClick()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper UserInfo(UserData user)
        {
            Type(By.Name("firstname"), user.FirstName);
            Type(By.Name("middlename"), user.MiddleName);
            Type(By.Name("lastname"), user.LastName);
            Type(By.Name("nickname"), user.NickName);
            Type(By.Name("title"), user.Title);
            Type(By.Name("company"), user.Company);
            Type(By.Name("address"), user.Address);

            Type(By.Name("home"), user.HomeNumber);
            Type(By.Name("mobile"), user.CellNumber);
            Type(By.Name("work"), user.WorkNumber);
            Type(By.Name("fax"), user.FaxNumber);

            Type(By.Name("email"), user.Email1);
            Type(By.Name("email2"), user.Email2);
            Type(By.Name("email3"), user.Email3);
            Type(By.Name("homepage"), user.Homepage);

            Type(By.Name("address2"), user.Address2);
            Type(By.Name("phone2"), user.SecondaryHome);
            Type(By.Name("notes"), user.Notes);

            return this;
        }
        public ContactHelper EditContactClick(int v)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + v + "]")).Click();
            //contactCache = null;
            return this;
        }

        public ContactHelper DeleteContactClick()
        {
            driver.FindElement(By.XPath("//*[@id='content']/form[2]/input[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper UpdateContactClick()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectAllContactsInList()
        {
            driver.FindElement(By.Id("MassCB")).Click();
            return this;
        }

        public ContactHelper DeleteContactsInList()
        {
            driver.FindElement(By.XPath("//*[@id='content']/form[2]/div[2]/input")).Click();
            contactCache = null;
            return this;
        }

        public bool IsContactPresentInList()
        {
            return IsElementPresent(By.XPath("(//img[@alt='Edit'])"));
        }
    }
}
