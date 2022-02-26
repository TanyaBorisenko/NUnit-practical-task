using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProject1
{
    public class CatalogOnliner
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
            _driver.Navigate().GoToUrl("https://catalog.onliner.by");
            Thread.Sleep(3000);
            _driver.Manage().Window.Maximize();
            var searchButton = _driver.FindElement(By.ClassName("fast-search__input"));
            searchButton.Click();
            searchButton.SendKeys("Тостер");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}