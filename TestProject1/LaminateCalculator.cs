using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProject1
{
    public class LaminateCalculator
    {
        private IWebDriver _driver;

        [SetUp]
        public void BeforeTests()
        {
            _driver = new ChromeDriver();
            // _driver = new ChromeDriver(@"C:\Users\Саша\RiderProjects\TestProject1\TestProject1\Resources\");
        }

        [Test]
        public void Test1()
        {
            _driver.Navigate().GoToUrl("https://calc.by/building-calculators/laminate.html");
            Thread.Sleep(3000);
            _driver.Manage().Window.Maximize();
            IWebElement layingLaminate = _driver.FindElement(By.Id("laying_method_laminate"));
            layingLaminate.Click();
            SelectElement select = new SelectElement(layingLaminate);
            select.SelectByValue("2");
            var lnRoom = _driver.FindElement(By.Id("ln_room_id"));
            lnRoom.Click();
            lnRoom.Clear();
            lnRoom.SendKeys("500");
            var wdRoom = _driver.FindElement(By.Id("wd_room_id"));
            wdRoom.Click();
            wdRoom.Clear();
            wdRoom.SendKeys("400");
            var lnLam = _driver.FindElement(By.Id("ln_lam_id"));
            lnLam.Click();
            lnLam.Clear();
            lnLam.SendKeys("2000");
            var wdLam = _driver.FindElement(By.Id("wd_lam_id"));
            wdLam.Click();
            wdLam.Clear();
            wdLam.SendKeys("200");
            var directionLam = _driver.FindElement(By.Id("direction-laminate-id1"));
            directionLam.Click();
            var button = _driver.FindElement(By.CssSelector(".calc-btn-div .calc-btn"));
            button.Click();
            Thread.Sleep(5000);
            var result1 =
                _driver.FindElement(By.XPath("//*[contains(text(),'Требуемое количество досок ламината: ')]//span"));
            Assert.AreEqual("53", result1.Text);
            Thread.Sleep(5000);
            var result2 = _driver.FindElement(By.XPath("//*[contains(text(),'Количество упаковок ламината: ')]//span"));
            Assert.AreEqual("7", result2.Text);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}