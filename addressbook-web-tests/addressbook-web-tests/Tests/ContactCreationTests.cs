﻿using System;
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
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage(baseURL + "addressbook/");
            Login(new AccountData("admin", "secret"));
            AddNewContactClick();
            UserData_UserNames(new UserData("FirstName", "LastName", "380504341555"));
            SaveNewContactClick();
            Logout();
        }
    }
}
