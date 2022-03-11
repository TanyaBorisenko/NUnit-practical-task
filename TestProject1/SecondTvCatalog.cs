using System.Threading;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
    public class SecondTvCatalog
    {
        private IWebDriver _driver;

        [SetUp]
        public void BeforeTests()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void Test()
        {
            _driver.Navigate().GoToUrl("https://catalog.onliner.by/tv");
            Thread.Sleep(3000);
            _driver.Manage().Window.Maximize();
            var appleButton =
                _driver.FindElement(
                    By.CssSelector("[class = \"schema-filter__store-item schema-filter__store-item_apple\"]"));
            appleButton.Click();

            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            var googleButton =
                _driver.FindElement(
                    By.CssSelector("[class = \"schema-filter__store-item schema-filter__store-item_google\"]"));
            googleButton.Click();

            var window = _driver.WindowHandles.Count;
            Assert.AreEqual(3, window);
            
            var someButton = _driver.FindElement(By.XPath("//*[@class = 'W9yFB']//*[@class = 'LkLjZd ScJHi U8Ww7d xjAeve nMZKrb  id-track-click']"));
            someButton.Click();
            Thread.Sleep(3000);

            var logger = LoggerBuilder.GetLogger<SecondTvCatalog>();
            var apps = _driver
                .FindElements(By.XPath("//*[text()='Похожие приложения']//following::*[@class=\"poRVub\"]")).Count;
            logger.LogInformation($"{apps}");


            _driver.SwitchTo().Window(_driver.WindowHandles[2]);
            var moreButon = _driver.FindElement(By.CssSelector("div > [data-metrics-click*='more']"));
            moreButon.Click();
            _driver.Close();

            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            Thread.Sleep(3000);
            var banner = _driver.FindElement(By.CssSelector("[border='0'][width='2000']"));
            banner.Click();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}