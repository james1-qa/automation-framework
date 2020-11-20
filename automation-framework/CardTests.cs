using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace automation_framework
{
    public class CardTests
    {
        IWebDriver driver;

        [SetUp] 
        public void Setup()
        {
            driver = new ChromeDriver(Path.GetFullPath(@"../../../" + "_drivers"));
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

        [Test]
        public void Ice_Spirit_headers_are_correct_on_Card_Details_Page()
        {
            // 1. Go to statsroyale.com
            driver.Url = "https://statsroyale.com/";
            // 2. Click on the cards link
            driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
            // 3. Go to ice spirit page
            driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']")).Click();
            // 4. Assert basic header stats
            var cardName = driver.FindElement(By.CssSelector("[class*='cardName']")).Text;
            var cardCategories = driver.FindElement(By.CssSelector(".card__rarity")).Text.Split(", ");
            var cardType = cardCategories[0];
            var cardArena = cardCategories[1];
            var cardRarity = driver.FindElement(By.CssSelector(".card__common")).Text;

            Assert.AreEqual("Ice Spirit", cardName);
            Assert.AreEqual("Troop", cardType);
            Assert.AreEqual("Arena 8", cardArena);
            Assert.AreEqual("Common", cardRarity);
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}