using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.ModelsTests.Abstractions
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void Constructor_ShouldCorrectlyAssignUsername_WhenValidNameIsPassed()
        {
            // Arrange

            var sut = new FakeUser("validUsername");

            // Act & Assert

            Assert.AreEqual("validUsername", sut.Username);
        }

        [Test]
        public void UsernameProperty_ShouldThrowArgumentException_WhenPassedValueInvalid()
        {
            // Arrange
            var sut = new FakeUser("validUsername");
            // Act & Asser
            Assert.Catch<ArgumentException>(() => sut.Username = "a");


        }

        [Test]
        public void UsernameProperty_ShouldNotThrow_WhenPassedValueValid()
        {
            // Arrange
            var sut = new FakeUser("validUsername");
            // Act

            // Assert
            Assert.DoesNotThrow(() => sut.Username = "aaaaa");
        }

        [Test]
        public void UsernameProperty_ShouldCorrectlyAssignValue_WhenPassedValueValid()
        {
            // Arrange
            var sut = new FakeUser("validUsername");
            // Act
            sut.Username = "aaaaa";
            // Assert
            Assert.AreEqual("aaaaa", sut.Username);

        }
    }
}
