using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Contacts
                .AddNewContactClick()
                .UserInfo(new UserData("FirstName", "LastName", "380504341555"))
                .SaveNewContactClick();
            app.Navigator.OpenHomePage();
            app.Auth.Logout();
        }
    }
}
