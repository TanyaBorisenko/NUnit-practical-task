using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace TestProject1
{
    [TestFixture]
    public class TestCalculator
    {
        private Calculator _calc;

        [SetUp]
        public void BeforeTests()
        {
            _calc = new Calculator();
        }

        [OneTimeTearDown]
        public void AfterTests()
        {
            Console.Write("Complete.");
        }

        [Test]
        public void SumAb()
        {
            double num1 = 4;
            double num2 = 2;
            double sum = 6;

            double result = _calc.Sum(num1, num2);

            Assert.AreEqual(sum, result);
            Assert.Pass("Test done.");
        }

        [Test]
        public void DivAb()
        {
            double num1 = 10;
            double num2 = 2;
            double expected = 5;

            double result = _calc.Div(num1, num2);

            Assert.AreSame(expected, result);
        }

        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivByZero()
        {
            double num1 = 9;
            double num2 = 0;

            Assert.Catch(typeof(DivideByZeroException), () => _calc.Div(num1, num2));
        }

        [Test]
        public void Multiply()
        {
            double num1 = 10;
            double num2 = 10;
            double expected = 100;

            double result = _calc.Multiply(num1, num2);

            Assert.AreEqual(expected, result);
            Assert.IsTrue(true);
        }
    }
}