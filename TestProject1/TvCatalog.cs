using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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

            var button = _driver.FindElement(By.CssSelector("[class = \"compare-button__sub compare-button__sub_main\"])"));
            button.Click();
            Thread.Sleep(3000);
            var wrapper = _driver.FindElement(By.ClassName("product-table__wrapper"));
            wrapper.Click();
            var pushIcon =
                _driver.FindElement(By.ClassName("product-table-tip__trigger product-table-tip__trigger_visible"));
            pushIcon.Click();
            Thread.Sleep(3000);
            pushIcon.Click();
            Thread.Sleep(3000);
            var deleteTv = _driver.FindElement(By.ClassName(
                "product-icon product-icon_trash product-table-cell-container__control product-table-cell-container__control_right product-table-cell-container__control_top"));
            deleteTv.Click();
            Thread.Sleep(3000);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}