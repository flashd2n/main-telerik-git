using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MatrixRotatingWalk;

namespace MatrixRotatingWalkTests
{
    [TestFixture]
    public class CoordinatesTests
    {
        [Test]
        public void ConstructorShouldCreateCorrectCoordinatesIntance_WhenValidParametersArePassed()
        {
            // Arrange & Act

            var sut = new Coordinates(-1, 1);

            // Assert

            Assert.IsInstanceOf<Coordinates>(sut);
        }

        [Test]
        public void ConstructorShouldCorrectlyAssignTheXandYProperties_WhenValidValuesArePassed()
        {
            // Arrange & Act

            var expectedX = -1;
            var expectedY = 1;

            var sut = new Coordinates(-1, 1);

            // Assert

            Assert.AreEqual(expectedX, sut.X);
            Assert.AreEqual(expectedY, sut.Y);
        }

        [Test]
        public void ConstructorShouldThrow_PassedOneOrMoreValuesAreOutsideSetLimits()
        {
            // Arrange, Act and Assert 

            var invalidX = -2;
            var validY = 1;

            Assert.Throws<ArgumentOutOfRangeException>(() => new Coordinates(invalidX, validY));

        }

        [Test]
        public void PropertyShouldThrow_PassedValueIsOutsideSetLimits()
        {
            // Arrange
            var validX = 1;
            var validY = -1;
            var invalidY = -3;

            var sut = new Coordinates(validX, validY);

            // Act and Assert

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Y = invalidY);
        }
    }
}
