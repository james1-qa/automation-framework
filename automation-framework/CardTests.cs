using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace automation_framework
{
    public class CardTests
    {
        IWebDriver driver;

        [SetUp] 
        public void Setup()
        {
            driver = new EdgeDriver(Path.GetFullPath(@"../../../" + "_drivers"));
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Ice_Spirit_is_on_cards_page()
        {
            // 1. Go to statsroyale.com
            driver.Url = "https://statsroyale.com/";
            // 2. Click on the cards link
            driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
            // 3. Assert ice spirit is displayed
            var iceSpirit = driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']"));
            Assert.That(iceSpirit.Displayed);
         }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}