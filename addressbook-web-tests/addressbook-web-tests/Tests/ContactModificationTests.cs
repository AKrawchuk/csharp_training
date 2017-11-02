using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            List<UserData> oldContacts = app.Contacts.GetContactList();

            if (!app.Contacts.IsContactPresentInList())
            {
                app.Contacts.AddNewContactClick();
                app.Contacts.UserInfo(new UserData("FirstName", "LastName"));
                app.Contacts.SaveNewContactClick();
                app.Navigator.OpenHomePage();
                oldContacts = app.Contacts.GetContactList();
            }
            UserData contactModif = new UserData("FirstName_Modified", "LastName_Modified");
            app.Contacts
               .EditContactClick(1)
               .UserInfo(contactModif)
               .UpdateContactClick();
            app.Navigator.OpenHomePage();

            List<UserData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].FirstName = contactModif.FirstName;
            oldContacts[0].LastName = contactModif.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            app.Auth.Logout();
        }
    }
}
