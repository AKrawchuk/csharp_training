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
    public class GroupModificationTests : GroupTestBase
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

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsGroupPresentInList())                          
            {
                app.Groups.Create(group);
                oldGroups = app.Groups.GetGroupList();
            }
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groupp in newGroups)
            {
                if (groupp.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, groupp.Name);
                }
            }
        }

        [Test]
        public void GroupModificationTest_DB()
        {
            GroupData group = new GroupData("New Group");
            group.Header = "header";
            group.Footer = "footer";

            GroupData newData = new GroupData("4445665645600000");
            newData.Header = "12344567889";
            newData.Footer = null;

            List<GroupData> oldGroups = GroupData.GetAll();

            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsGroupPresentInList())
            {
                app.Groups.Create(group);
                oldGroups = GroupData.GetAll();
            }
            GroupData oldData = oldGroups[0];                           //------------16------------------

            app.Groups.Modify(oldData, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groupp in newGroups)
            {
                if (groupp.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, groupp.Name);
                }
            }
        }
    }
}
