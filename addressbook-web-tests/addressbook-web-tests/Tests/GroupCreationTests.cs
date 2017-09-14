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
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.InitGroupCreation();
            GroupData group = new GroupData("qwerty");
            group.Header = "asdfgh";
            group.Footer = "zxcvb";
            app.Groups.FillGroupForm(group);

            app.Groups.SubmitGroupCreation();
            app.Navigator.ReturnToGroupsPage();
            app.Auth.Logout();
        }
    }
}
