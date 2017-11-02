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
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
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
            app.Contacts
               .EditContactClick(1)
               .DeleteContactClick();
            app.Navigator.OpenHomePage();

            List<UserData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            app.Auth.Logout();
        }

        [Test]
        public void ContactRemovalTest_DB()
        {
            List<UserData> oldContacts = UserData.GetAll();                     //-----------16--------------
            UserData toBeRemoved = 

            if (!app.Contacts.IsContactPresentInList())
            {
                app.Contacts.AddNewContactClick();
                app.Contacts.UserInfo(new UserData("FirstName", "LastName"));
                app.Contacts.SaveNewContactClick();
                app.Navigator.OpenHomePage();
                oldContacts = UserData.GetAll();                                //-----------16--------------
            }
            app.Contacts
               .EditContactClick(1)
               .DeleteContactClick();
            app.Navigator.OpenHomePage();

            List<UserData> newContacts = UserData.GetAll();                     //-----------16--------------
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            app.Auth.Logout();
        }

        [Test]
        public void ContactRemovalTest111()
        {
            app.Contacts.CheckContactCreated();

            List<UserData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(0);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<UserData> newContacts = app.Contacts.GetContactList();
            UserData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (UserData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
