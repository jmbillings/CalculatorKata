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
        [TestCase("100", 100)]
        [TestCase("999", 999)]
        public void SingleNumberStringShouldReturnTheSameNumber(string inputString, int expectedValue)
        {
            Assert.AreEqual(expectedValue, m_Calculator.Add(inputString));
        }

        [Test]
        [TestCase("0,0", 0)]
        [TestCase("0,1", 1)]
        [TestCase("1,1", 2)]
        [TestCase("10,1", 11)]
        [TestCase("10,10", 20)]
        [TestCase("999,999", 1998)]
        public void DoubleNumberStringShouldReturnTheSumOfTheNumbers(string inputString, int expectedValue)
        {
            Assert.AreEqual(expectedValue, m_Calculator.Add(inputString));
        }

        [Test]
        [TestCase("0,0,0", 0)]
        [TestCase("0,0,1", 1)]
        [TestCase("0,1,1", 2)]
        [TestCase("1,1,1", 3)]
        [TestCase("1,1,1,1",4)]
        [TestCase("10,10,10", 30)]
        [TestCase("10,20,30,40", 100)]
        [TestCase("999,999,999,999", 3996)]
        [TestCase("1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1", 20)]
        public void StringOfAnyNumbersShouldReturnTheSumOfTheNumbers(string inputString, int expectedValue)
        {
            Assert.AreEqual(expectedValue, m_Calculator.Add(inputString));
        }

        [Test]
        [TestCase("0,0\n0", 0)]
        [TestCase("0\n0\n1", 1)]
        [TestCase("10\n20\n30,40", 100)]
        [TestCase("999\n999\n999,999", 3996)]
        [TestCase("1,1,1,1,1,1\n1,1,1,1\n1,1,1\n1\n1,1,1,1,1,1", 20)]
        public void NumbersCanBeSplitByCommaOrNewline(string inputString, int expectedValue)
        {
            Assert.AreEqual(expectedValue, m_Calculator.Add(inputString));
        }

        [Test]
        [TestCase("//!\n1", 1)]
        [TestCase("//!\n1,1", 2)]
        [TestCase("//!\n1!1", 2)]
        [TestCase("//!\n1!1\n1,1", 4)]
        [TestCase("//a\n10a20a30", 60)]
        public void CustomDelimiterCanBeUsedToSplitNumbers(string inputString, int expectedValue)
        {
            Assert.AreEqual(expectedValue, m_Calculator.Add(inputString));
        }

        [Test]
        [TestCase("-1", "negatives not allowed -1")]
        [TestCase("-1,-2,3,4", "negatives not allowed -1 -2")]
        [TestCase("100,200,-300", "negatives not allowed -300")]
        public void NegativeNumbersThrowExceptionContainingTheNegativeNumbers(string inputString, string expectedExceptionMessage)
        {
            Exception thrownException = Assert.Throws<Exception>(() => m_Calculator.Add(inputString));         
            Assert.That(thrownException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        [TestCase("1001", 0)]
        [TestCase("1,1000", 1001)]
        [TestCase("1001,1001,1000", 1000)]
        [TestCase("1,1001",1)]
        [TestCase("1,2,3,4,9999",10)]
        public void NumbersGreaterThan1000AreIgnored(string inputString, int expectedValue)
        {
            Assert.AreEqual(expectedValue, m_Calculator.Add(inputString));
        }

        [Test]
        [TestCase("//[!]\n1", 1)]
        [TestCase("//[!!!]\n1!!!1", 2)]
        [TestCase("//[###]\n1###1###1###1###1", 5)]
        [TestCase("//[aaaaaa]\n1,1\n1aaaaaa1", 4)]
        public void CustomLengthDelimitersCanBeSpecified(string inputString, int expectedValue)
        {
            Assert.AreEqual(expectedValue, m_Calculator.Add(inputString));
        }
    }
}