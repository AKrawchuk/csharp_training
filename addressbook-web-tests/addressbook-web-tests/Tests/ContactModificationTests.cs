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
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (app.Contacts.IsContactPresentInList())
            {
                ContactModificationSequence();
            }
            else
            {
                app.Contacts.AddNewContactClick();
                app.Contacts.UserInfo(new UserData("FirstName", "LastName", "380504341555"));
                app.Contacts.SaveNewContactClick();
                app.Navigator.OpenHomePage();

                ContactModificationSequence();
            }
        }

        private void ContactModificationSequence()
        {
            app.Contacts
               .EditContactClick(1)
               .UserInfo(new UserData("FirstName_Modified", "LastName_Modified", "380504341555_Modified"))
               .UpdateContactClick();
            app.Navigator.OpenHomePage();
            app.Auth.Logout();
        }
    }
}
