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
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            try
            {
                app.Contacts
                .EditContactClick(1)
                .DeleteContactClick();
                app.Navigator.OpenHomePage();
                app.Auth.Logout();
            }
            catch (NoSuchElementException)
            {
                app.Contacts.AddNewContactClick();
                app.Contacts.UserInfo(new UserData("FirstName", "LastName", "380504341555"));
                app.Contacts.SaveNewContactClick();
                app.Navigator.OpenHomePage();

                app.Contacts
                .EditContactClick(1)
                .DeleteContactClick();
                app.Navigator.OpenHomePage();
                app.Auth.Logout();
            }
            
        }
    }
}
