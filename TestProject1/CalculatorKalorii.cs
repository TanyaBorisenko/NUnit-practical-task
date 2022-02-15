using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProject1
{
    public class CalculatorKalorii
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
            _driver.Navigate().GoToUrl("https://www.calc.ru/kalkulyator-kalorii.html");
            Thread.Sleep(3000);
            _driver.Manage().Window.Maximize();
            IWebElement activity = _driver.FindElement(By.Id("activity"));
            activity.Click();
            SelectElement select = new SelectElement(activity);
            select.SelectByValue("1.4625");
            var age = _driver.FindElement(By.Id("age"));
            age.Click();
            age.SendKeys("35");
            var weight = _driver.FindElement(By.Id("weight"));
            weight.Click();
            weight.SendKeys("85");
            var width = _driver.FindElement(By.Id("sm"));
            width.Click();
            width.SendKeys("185");
            var button = _driver.FindElement(By.Id("submit"));
            button.Click();
            Thread.Sleep(5000);
            var result = _driver.FindElement(By.XPath("//td[contains(text(), '3028 ккал/день')]"));
            Assert.AreEqual("3028 ккал/день", result.Text);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}