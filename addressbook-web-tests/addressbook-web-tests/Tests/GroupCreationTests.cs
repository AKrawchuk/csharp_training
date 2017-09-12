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
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage(baseURL + "addressbook/");
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("qwerty");
            group.Header = "asdfgh";
            group.Footer = "zxcvb";
            FillGroupForm(group);

            SubmitGroupCreation();
            ReturnToGroupsPage();
            Logout();
        }
    }
}
