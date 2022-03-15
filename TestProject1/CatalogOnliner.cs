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
            
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var iframeWait = wait.Until(d => d.FindElement(By.XPath("//iframe[@class ='modal-iframe']")));
            _driver.SwitchTo().Frame(iframeWait);

            var element =
                _driver.FindElement(
                    By.XPath("//*[@class ='product__title-link'][1]")).Text;

            var clearText = _driver.FindElement(By.CssSelector("[class ='search__input']"));
            clearText.Click();
            clearText.Clear();
            clearText.SendKeys($"{element}");
            
            var closeSearch = _driver.FindElement(By.ClassName("search__close"));
            closeSearch.Click();

        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}