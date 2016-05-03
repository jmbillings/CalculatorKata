using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorKata.Tests
{
    [TestFixture]
    public class Tests
    {
        Calculator m_Calculator;

        [TestFixtureSetUp]
        public void Setup()
        {
            m_Calculator = new Calculator();
        }

        [Test]
        public void EmptyStringReturnsZero()
        {
            Assert.AreEqual(0, m_Calculator.Add(""));
        }

        [Test]
        [TestCase("0", 0)]
        [TestCase("1", 1)]
        [TestCase("10", 10)]
        [TestCase("999", 999)]
        public void SingleNumberStringShouldReturnTheSameNumber(string inputString, int expectedValue)
        {
            Assert.AreEqual(expectedValue, m_Calculator.Add(inputString));
        }

        [Test]
        [TestCase("0,0", 0)]
        [TestCase("0,1", 1)]
        [TestCase("1,1", 2)]
        [TestCase("10,10", 20)]
        [TestCase("999,999", 1998)]
        public void DoubleNumberStringShouldReturnTheSumOfTheNumbers(string inputString, int expectedValue)
        {
            Assert.AreEqual(expectedValue, m_Calculator.Add(inputString));
        }
    }
}