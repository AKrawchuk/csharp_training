﻿using System;
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
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contacts
                .EditContactClick(6)
                .UserInfo(new UserData("FirstName_Modified", "LastName_Modified", "380504341555_Modified"))
                .UpdateContactClick();
            app.Auth.Logout();
        }
    }
}