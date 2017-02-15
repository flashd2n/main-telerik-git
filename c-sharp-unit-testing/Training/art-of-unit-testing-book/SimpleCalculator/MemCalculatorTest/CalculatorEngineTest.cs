using MemCalculator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemCalculatorTest
{
    [TestFixture]
    public class CalculatorEngineTest
    {
        [Test]
        public void Should_ReturnZero_ByDefault()
        {
            // Arrage
            var sut = new CalculatorEngine();

            // Act
            int result = sut.Equals();

            // Assert
            Assert.AreEqual(result, 0);
        }

        [TestCase(1)]
        public void Should_ReturnCorrectSum_WhenGivenValidValue(int number)
        {
            // Arrage
            var sut = new CalculatorEngine();

            // Act
            sut.Add(number);
            var sum = sut.Equals();

            // Assert

            Assert.AreEqual(number, sum);

        }
    }   
}
