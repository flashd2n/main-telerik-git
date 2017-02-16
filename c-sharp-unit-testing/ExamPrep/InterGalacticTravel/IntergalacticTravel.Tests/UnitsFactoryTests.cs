using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using IntergalacticTravel.Exceptions;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class UnitsFactoryTests
    {

        [Test]
        public void GetUnit_ShouldReturnNewProcyonUnit_WhenValidDataIsPassed()
        {
            // Arrange
            var sut = new UnitsFactory();

            // Act

            var result = sut.GetUnit("create unit Procyon Gosho 1");

            // Assert

            Assert.IsInstanceOf<Procyon>(result);

        }

        [Test]
        public void GetUnit_ShouldReturnNewLuytenUnit_WhenValidDataIsPassed()
        {
            // Arrange
            var sut = new UnitsFactory();

            // Act

            var result = sut.GetUnit("create unit Luyten Pesho 2");

            // Assert

            Assert.IsInstanceOf<Luyten>(result);

        }

        [Test]
        public void GetUnit_ShouldReturnNewLacailleUnit_WhenValidDataIsPassed()
        {
            // Arrange
            var sut = new UnitsFactory();

            // Act

            var result = sut.GetUnit("create unit Lacaille Tosho 3");

            // Assert

            Assert.IsInstanceOf<Lacaille>(result);

        }
        
        [TestCase("thisparameterstringhasnotspacesandcannotbesplit")]
        [TestCase("create unit NotAValidType Tosho 3")]
        public void GetUnit_ShouldThrowInvalidUnitCreationCommandException_WhenPassedDataIsNotValid(string invalidParameters)
        {
            // Arrange

            var sut = new UnitsFactory();

            // Act & Assert

            Assert.Catch<InvalidUnitCreationCommandException>(() => sut.GetUnit(invalidParameters));
        }

    }
}
