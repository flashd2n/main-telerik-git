using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using ArmyOfCreatures.Extended;
using ArmyOfCreatures.Extended.Creatures;
using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Tests.ExtendedTests
{
    [TestFixture]
    public class ExtendedCreaturesFactoryTests
    {
        [Test]
        public void CreateCreature_ShouldThrowArgumentExceptionWithSpecificMessage_WhenInvalidCreatureTypeIsPassed()
        {
            // Arrange

            var sut = new ExtendedCreaturesFactory();
            
            // Act & Assert

            var ex = Assert.Catch<ArgumentException>(() => sut.CreateCreature("notValidCreature"));
            StringAssert.Contains("Invalid creature type", ex.Message);
        }

        [Test]
        public void CreateCreature_ShouldReturnNewAncientBehemoth_WhenValidDataIsPassed()
        {
            // Arrange

            var sut = new ExtendedCreaturesFactory();

            // Act

            var result = sut.CreateCreature("AncientBehemoth");

            // Assert

            Assert.IsInstanceOf<AncientBehemoth>(result);

        }

        [Test]
        public void CreateCreature_ShouldReturnNewCyclopsKing_WhenValidDataIsPassed()
        {
            // Arrange

            var sut = new ExtendedCreaturesFactory();

            // Act

            var result = sut.CreateCreature("CyclopsKing");

            // Assert

            Assert.IsInstanceOf<CyclopsKing>(result);

        }

        [Test]
        public void CreateCreature_ShouldReturnNewGoblin_WhenValidDataIsPassed()
        {
            // Arrange

            var sut = new ExtendedCreaturesFactory();

            // Act

            var result = sut.CreateCreature("Goblin");

            // Assert

            Assert.IsInstanceOf<Goblin>(result);

        }

        [Test]
        public void CreateCreature_ShouldReturnNewGriffin_WhenValidDataIsPassed()
        {
            // Arrange

            var sut = new ExtendedCreaturesFactory();

            // Act

            var result = sut.CreateCreature("Griffin");

            // Assert

            Assert.IsInstanceOf<Griffin>(result);

        }

        [Test]
        public void CreateCreature_ShouldReturnNewWolfRaider_WhenValidDataIsPassed()
        {
            // Arrange

            var sut = new ExtendedCreaturesFactory();

            // Act

            var result = sut.CreateCreature("WolfRaider");

            // Assert

            Assert.IsInstanceOf<WolfRaider>(result);

        }

        [Test]
        public void CreateCreature_ShouldReturnNewAngelFromBaseClass_WhenValidDataIsPassed()
        {
            // Arrange

            var sut = new ExtendedCreaturesFactory();

            // Act

            var result = sut.CreateCreature("Angel");

            // Assert

            Assert.IsInstanceOf<Angel>(result);

        }

    }
}
