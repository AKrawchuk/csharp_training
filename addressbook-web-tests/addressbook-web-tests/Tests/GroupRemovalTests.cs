using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            GroupData group = new GroupData("New Group");
            group.Header = "header";
            group.Footer = "footer";

            //List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Navigator.GoToGroupsPage();
            if (app.Groups.IsGroupPresentInList())                          
            {                                                                 
                app.Groups.Remove(0);
            }
            else                                                                    
            {
                app.Groups.Create(group);
                app.Groups.Remove(0);
            }

            //List<GroupData> newGroups = app.Groups.GetGroupList();
            //oldGroups.RemoveAt(0);
            
            //Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
