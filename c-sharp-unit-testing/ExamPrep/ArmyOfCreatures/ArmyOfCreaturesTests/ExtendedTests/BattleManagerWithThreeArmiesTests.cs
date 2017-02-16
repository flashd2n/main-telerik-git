using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Tests.ExtendedTests
{
    [TestFixture]
    public class BattleManagerWithThreeArmiesTests
    {
        [Test]
        public void Constructor_ShouldCallBaseAndAssignFirstArmyCreaturesFieldProperly_WhenValidDataIsPassed()
        {
            // Arrange

            var creaturesFactoryStub = new Mock<ICreaturesFactory>();
            var loggerStub = new Mock<ILogger>();
            var sut = new FakeBattleManagerWithThreeArmies(creaturesFactoryStub.Object, loggerStub.Object);

            // Act & Assert

            Assert.IsInstanceOf<ICollection<ICreaturesInBattle>>(sut.GetFirstArmyCreatures);
        }

        [Test]
        public void Constructor_ShouldCallBaseAndAssignSecondArmyCreaturesFieldProperly_WhenValidDataIsPassed()
        {
            // Arrange

            var creaturesFactoryStub = new Mock<ICreaturesFactory>();
            var loggerStub = new Mock<ILogger>();
            var sut = new FakeBattleManagerWithThreeArmies(creaturesFactoryStub.Object, loggerStub.Object);

            // Act & Assert

            Assert.IsInstanceOf<ICollection<ICreaturesInBattle>>(sut.GetSecondArmyCreatures);
        }

        [Test]
        public void Constructor_ShouldCallBaseAndAssignCreaturesFactoryFieldProperly_WhenValidDataIsPassed()
        {
            // Arrange

            var creaturesFactoryStub = new Mock<ICreaturesFactory>();
            var loggerStub = new Mock<ILogger>();
            var sut = new FakeBattleManagerWithThreeArmies(creaturesFactoryStub.Object, loggerStub.Object);

            // Act & Assert

            Assert.AreEqual(creaturesFactoryStub.Object, sut.GetCreaturesFactory);
        }

        [Test]
        public void Constructor_ShouldCallBaseAndAssignLoggerFieldProperly_WhenValidDataIsPassed()
        {
            // Arrange

            var creaturesFactoryStub = new Mock<ICreaturesFactory>();
            var loggerStub = new Mock<ILogger>();
            var sut = new FakeBattleManagerWithThreeArmies(creaturesFactoryStub.Object, loggerStub.Object);

            // Act & Assert

            Assert.AreEqual(loggerStub.Object, sut.GetLogger);
        }

        [Test]
        public void Constructor_ShouldCallBaseAndAssignThirdArmyFieldProperly_WhenValidDataIsPassed()
        {
            // Arrange

            var creaturesFactoryStub = new Mock<ICreaturesFactory>();
            var loggerStub = new Mock<ILogger>();
            var sut = new FakeBattleManagerWithThreeArmies(creaturesFactoryStub.Object, loggerStub.Object);

            // Act & Assert

            Assert.IsInstanceOf<ICollection<ICreaturesInBattle>>(sut.GetThirdArmyCreatures);
        }

    }
}
