using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestProject1
{
    public class TvCatalog
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
            var checkboxes = _driver.FindElements(By.ClassName("schema-product__control"));
            var firstTv = checkboxes.ElementAt(0);
            var secondTv = checkboxes.ElementAt(1);

            firstTv.Click();
            secondTv.Click();

            var button = _driver.FindElement(By.XPath(
                "//*[@id='before-footer-googletag']//following::*[contains(@class, 'compare-button__sub_main')]"));
            button.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement wrapper = wait.Until(e =>
                e.FindElement(
                    By.XPath("//*[@id='product-table']/tbody[5]/tr[4]")));
            Actions action = new Actions(_driver);
            action.MoveToElement(wrapper);
            action.Click().Build().Perform();

            IWebElement pushIcon = _driver.FindElement(By.XPath("//*[@id='product-table']/tbody[5]/tr[4]/td[1]/div/span"));
            pushIcon.Click();

            var table = wait.Until(e => e.FindElement(
                    By.XPath("//*[@class= 'product-table-tip__content']")));
            pushIcon.Click();

            var deleteTv = _driver.FindElement(By.XPath(
                "//*[@id='product-table']/tbody[2]/tr/th[3]/div/a"));
            deleteTv.Click();
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}