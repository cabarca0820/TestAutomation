//This is sample code to test that environment set-up for Selenium C# is working.
//This uses the https://www.seleniumeasy.com website.
//The full instruction will be published later.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace MyUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        protected IWebDriver driver { get; set; }

        [TestMethod]
        [TestCategory("Selenium Environment Test")]
        public void SeleniumEnvironmentTest()
        {
            driver = GetChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.seleniumeasy.com/");
            var actualTitle = driver.Title;
            Assert.IsTrue(actualTitle.Contains("Selenium Easy"));
            driver.Close();
        }
        private IWebDriver GetChromeDriver()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDirectory);
        }
    }
}
