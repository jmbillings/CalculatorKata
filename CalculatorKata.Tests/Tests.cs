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
    }
}
