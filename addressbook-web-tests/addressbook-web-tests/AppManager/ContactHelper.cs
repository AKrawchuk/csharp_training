﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

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

        public string GetContactInformationStringFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");

            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            string detailsString = firstName;
            string s = string.Format($"{firstName} {lastName}\r\n{address}\r\n\r\nH: {homePhone}\r\nM: {mobilePhone}\r\nW: {workPhone}\r\n\r\n{email1}\r\nHomepage:\r\n{homepage}\r\n\r\n\r\n{address2}");
            //Console.WriteLine("Output from edit form -----------------------");
            //Console.WriteLine(s);
            return s;
        }

        public string GetContactInformationFromDetails(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactDetails(0);
            string s = driver.FindElement(By.Id("content")).Text;
            //Console.WriteLine("Output from deails -----------------------");
            //Console.WriteLine(s);
            return s;
        }

        public UserData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new UserData(firstName, lastName)
            {
                Address = address,
                HomeNumber = homePhone,
                CellNumber = mobilePhone,
                WorkNumber = workPhone,
            };
        }

        public UserData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;

            return new UserData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones
            };
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
        public ContactHelper EditContactClick(int index)                                        //---------------------------
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click(); 
            return this;
        }

        public void InitContactModification(int index)                                          //---------------------------
        {
            driver.FindElements(By.Name("entry"))[index]
             .FindElements(By.TagName("td"))[7]
             .FindElement(By.TagName("a")).Click();
        }

        public void InitContactDetails(int index)                                          
        {
            driver.FindElements(By.Name("entry"))[index]
             .FindElements(By.TagName("td"))[6]
             .FindElement(By.TagName("a")).Click();
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
        public int GetNumberOfSearchResults()
        {
            manager.Navigator.OpenHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}
