using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) 
            : base(manager)
        {
        }


        public GroupHelper RemoveWise(int v)
        {
            GroupData group = new GroupData("New Group");
            group.Header = "header";
            group.Footer = "footer";

            try
            {
                RemoveGroup(v);
                return this;
            }
            catch (NoSuchElementException)
            {
                Create(group);
                RemoveGroup(v);
                return this;
            }
        }

        private void RemoveGroup(int v)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            RemoveGroup();
            ReturnToGroupsPage();
        }

        public GroupHelper ModifyWise(int v, GroupData newData)
        {
            GroupData group = new GroupData("New Group");
            group.Header = "header";
            group.Footer = "footer";

            try
            {
                ModifyGroup(v, newData);
                return this;
            }
            catch (NoSuchElementException)
            {
                Create(group);
                ModifyGroup(v, newData);
                return this;
            }
        }

        private void ModifyGroup(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData groupdata)
        {
            Type(By.Name("group_name"), groupdata.Name);
            Type(By.Name("group_header"), groupdata.Header);
            Type(By.Name("group_footer"), groupdata.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

    }
}
