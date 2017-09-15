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
            GroupData group = new GroupData("qwerty");
            group.Header = "asdfgh";
            group.Footer = "zxcvb";

            app.Groups.Create(group);
        }
        [Test]
        public void EmptyNameGroupCreationTest()
        {
            GroupData group = new GroupData("qwerty");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
        }
    }
}
