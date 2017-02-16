using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Specialties;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Tests.LogicTests.SpecialtiesTests
{
    [TestFixture]
    public class DoubleDefenseWhenDefendingTests
    {
        [Test]
        public void ApplyWhenDefending_ShouldThrowArgumentNullException_WhenICreaturesInBattleDefenderWithSpecialtyIsNull()
        {
            // Arrange

            var sut = new DoubleDefenseWhenDefending(5);
            var attackerStub = new Mock<ICreaturesInBattle>();

            // Act & Assert

            Assert.Catch<ArgumentNullException>(() => sut.ApplyWhenDefending(null, attackerStub.Object));

        }

        [Test]
        public void ApplyWhenDefending_ShouldThrowArgumentNullException_WhenICreaturesInBattleAttackerIsNull()
        {
            // Arrange

            var sut = new DoubleDefenseWhenDefending(5);
            var defenderStub = new Mock<ICreaturesInBattle>();

            // Act & Assert

            Assert.Catch<ArgumentNullException>(() => sut.ApplyWhenDefending(defenderStub.Object, null));

        }

        [Test]
        public void ApplyWhenDefending_ShouldReturnAndNotChangeCurrentDefenseOfDefenderWithSpecialtyWhenEffectIsExpired()
        {
            // Arrange

            var sut = new DoubleDefenseWhenDefending(1);
            var attackerStub = new Mock<ICreaturesInBattle>();
            var defenderWithSpecialtyMock = new Mock<ICreaturesInBattle>();
            defenderWithSpecialtyMock.Setup(x => x.CurrentDefense).Returns(5);

            // Act

            sut.ApplyWhenDefending(defenderWithSpecialtyMock.Object, attackerStub.Object);
            sut.ApplyWhenDefending(defenderWithSpecialtyMock.Object, attackerStub.Object);

            // Assert

            defenderWithSpecialtyMock.Verify(x => x.CurrentDefense, Times.Once);
        }

        [Test]
        public void ApplyWhenDefending_ShouldMultiplyByTwoTheCurrentDefenseProperty_WhenEffectHasNotExpired()
        {
            // Arrange

            var sut = new DoubleDefenseWhenDefending(1);
            var attackerStub = new Mock<ICreaturesInBattle>();
            var defenderWithSpecialtyMock = new Mock<ICreaturesInBattle>();
            defenderWithSpecialtyMock.Setup(x => x.CurrentDefense).Returns(5);

            // Act

            sut.ApplyWhenDefending(defenderWithSpecialtyMock.Object, attackerStub.Object);

            // Assert

            defenderWithSpecialtyMock.Verify(x => x.CurrentDefense, Times.Once);
        }


    }
}
