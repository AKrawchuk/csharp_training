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
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            GroupData group = new GroupData("New Group");
            group.Header = "header";
            group.Footer = "footer";

            app.Navigator.GoToGroupsPage();
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (!app.Groups.IsGroupPresentInList())
            {
                app.Groups.Create(group);
                oldGroups = app.Groups.GetGroupList();
            }
            app.Groups.Remove(0);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groupp in newGroups)
            {
                Assert.AreNotEqual(groupp.Id, toBeRemoved.Id);
            }
        }

        [Test]
        public void GroupRemovalTest_DB()
        {
            GroupData group = new GroupData("New Group");
            group.Header = "header";
            group.Footer = "footer";

            app.Navigator.GoToGroupsPage();
            List<GroupData> oldGroups = GroupData.GetAll();             //-------------16---------
            GroupData toBeRemoved = oldGroups[0];                       //---------16---------

            if (!app.Groups.IsGroupPresentInList())
            {
                app.Groups.Create(group);
                oldGroups = GroupData.GetAll();                         //---------16---------
            }
            app.Groups.Remove(toBeRemoved);                             //---------16---------

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();             //---------16---------
            //GroupData toBeRemoved = oldGroups[0];                     //---------16---------
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groupp in newGroups)
            {
                Assert.AreNotEqual(groupp.Id, toBeRemoved.Id);
            }
        }
    }
}
