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
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("New Group");
            group.Header = "header";
            group.Footer = "footer";

            GroupData newData = new GroupData("4445665645600000");
            newData.Header = "12344567889";
            newData.Footer = null;

            /*if (app.Groups.IsGroupPresentInList())                          //-------- не понимаю почему не перехватывает try catch (NoSuchElementException)
            {                                                                 //-------- описанная в IsGroupPresentInList -> IsElementPresent
                app.Groups.Modify(0, newData);
            }
            else                                                                    
            {
                app.Groups.Create(group);
                app.Groups.Modify(0, newData);
            }*/

            try
            {
                app.Groups.Modify(0, newData);
            }
            catch (NoSuchElementException)
            {
                app.Groups.Create(group);
                app.Groups.Modify(0, newData);
            }
        }
    }
}
