using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class ResourcesFactoryTests
    {
        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void GetResources_ShouldReturnNewResourceObject_WhenValidParametersArePassedNoMatterTheOrder(string validInput)
        {
            // Arrange
            var sut = new ResourcesFactory();

            // Act

            var result = sut.GetResources(validInput);

            // Assert

            Assert.IsInstanceOf<Resources>(result);
        }

        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void GetResources_ShouldReturnNewResourceObjectWithCorrectlySetProperties_WhenValidParametersArePassedNoMatterTheOrder(string validInput)
        {
            // Arrange
            var sut = new ResourcesFactory();


            // Act

            var result = sut.GetResources(validInput);

            // Assert

            Assert.AreEqual(20, result.GoldCoins);
            Assert.AreEqual(30, result.SilverCoins);
            Assert.AreEqual(40, result.BronzeCoins);
        }

        [TestCase("nospacesstringcannotsplitme")]
        [TestCase("create resources noSuchResource(40) noSuchResource(30) noSuchResource(20)")]
        public void GetResources_ShouldThrowInvalidOperationExceptionThatContainsStringCommand_WhenInputStringIsInvalid(string invalidInput)
        {
            // Arrange
            var sut = new ResourcesFactory();

            // Act & Assert

            Assert.Catch<InvalidOperationException>(() => sut.GetResources(invalidInput));

        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void GetResources_ShouldThrowOverflowException_WhenInputStringIsInValidFormatButButValueForResourceAmountIsTooBig(string invalidInput)
        {
            // Arrange
            var sut = new ResourcesFactory();

            // Act & Assert

            Assert.Catch<OverflowException>(() => sut.GetResources(invalidInput));

        }

    }
}
