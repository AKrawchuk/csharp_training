using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            List<UserData> oldContacts = app.Contacts.GetContactList();

            UserData contact = new UserData("FirstName", "LastName");
            app.Contacts
                .AddNewContactClick()
                .UserInfo(contact)
                .SaveNewContactClick();
            app.Navigator.OpenHomePage();

            List<UserData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            app.Auth.Logout();
        }

        public static IEnumerable<UserData> RandomContactDataProvider()
        {
            List<UserData> contacts = new List<UserData>();
            for (int i = 0; i < 3; i++)
            {
                contacts.Add(new UserData(GeneraterandomString(10), GeneraterandomString(10))
                {
                    FirstName = GeneraterandomString(25),
                    LastName = GeneraterandomString(25),
                    Company = GeneraterandomString(25),
                    Address = GeneraterandomString(25),
                    HomeNumber = GeneraterandomString(25),
                    CellNumber = GeneraterandomString(25),
                });
            }
            return contacts;
        }
        public static IEnumerable<UserData> ContactDataFromXmlFile()
        {
            return (List<UserData>)new XmlSerializer(typeof(List<UserData>)).Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<UserData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<UserData>>(File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void DDT_ContactCreationTest(UserData contact)
        {
            List<UserData> oldContacts = app.Contacts.GetContactList();

            app.Contacts
                .AddNewContactClick()
                .UserInfo(contact)
                .SaveNewContactClick();
            app.Navigator.OpenHomePage();

            List<UserData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            app.Auth.Logout();
        }
    }
}
