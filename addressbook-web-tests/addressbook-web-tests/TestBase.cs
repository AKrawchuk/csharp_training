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
    public class TestBase
    {
        /*protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;*/

        /*protected LoginHelper loginHelper;
        protected NavigationHelper navHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;*/

        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            /*FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"C:\\Program Files\\Mozilla Firefox_ESR\\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);

            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();*/

            app = new ApplicationManager();

            /*loginHelper = new LoginHelper(driver);
            navHelper = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);*/
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
            /*try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }*/
        }
    }
}
