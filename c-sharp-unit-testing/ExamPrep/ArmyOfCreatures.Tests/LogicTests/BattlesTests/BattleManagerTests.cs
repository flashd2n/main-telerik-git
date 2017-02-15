using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Tests.LogicTests.BattlesTests
{
    [TestFixture]
    public class BattleManagerTests
    {
        [Test]
        public void AddCreatures_ShouldThrowArgumentNullException_WhenIdentifierIsNull()
        {
            // Arrage

            var creaturesFactoryStub = new Mock<ICreaturesFactory>();
            var loggerStub = new Mock<ILogger>();
            var sut = new BattleManager(creaturesFactoryStub.Object, loggerStub.Object);

            // Act & Arrange

            Assert.Catch<ArgumentNullException>(() => sut.AddCreatures(null, 5));
        }

        [Test]
        public void AddCreatures_ShouldCallCreateCreatureFromFactory_WhenValidDataIsPassed()
        {
            // Arrange
            var creaturesFactoryMock = new Mock<ICreaturesFactory>();
            var loggerStub = new Mock<ILogger>();
            var sut = new BattleManager(creaturesFactoryMock.Object, loggerStub.Object);

            var creatureIdentifierStub = new Mock<ICreatureIdentifier>();
            var creatureStub = new Mock<ICreatures>();

            creatureIdentifierStub.Setup(x => x.CreatureType).Returns("someType");
            creatureIdentifierStub.Setup(x => x.ArmyNumber).Returns(1);
            creaturesFactoryMock.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creatureStub.Object);

            // Act

            sut.AddCreatures(creatureIdentifierStub.Object, 10);

            // Assert

            creaturesFactoryMock.Verify(x => x.CreateCreature(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void AddCreature_ShouldCallWriteLineFromLogger_WhenValidDataIsPassed()
        {
            // Arrange
            var creaturesFactoryStub = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();
            var sut = new BattleManager(creaturesFactoryStub.Object, loggerMock.Object);

            var creatureIdentifierStub = new Mock<ICreatureIdentifier>();
            var creatureStub = new Mock<ICreatures>();

            loggerMock.Setup(x => x.WriteLine(It.IsAny<string>()));
            creatureIdentifierStub.Setup(x => x.CreatureType).Returns("someType");
            creatureIdentifierStub.Setup(x => x.ArmyNumber).Returns(1);
            creaturesFactoryStub.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creatureStub.Object);

            // Act

            sut.AddCreatures(creatureIdentifierStub.Object, 10);

            // Assert

            loggerMock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);

            
        }

        [Test]
        public void AddCreature_ShouldReceiveArgumentExceptionFromAddCreatureByIdentifier_WhenCreatureWithArmyThreeIsPassedd()
        {
            // Arrange
            var creaturesFactoryStub = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();
            var sut = new BattleManager(creaturesFactoryStub.Object, loggerMock.Object);

            var creatureIdentifierStub = new Mock<ICreatureIdentifier>();
            var creatureStub = new Mock<ICreatures>();

            loggerMock.Setup(x => x.WriteLine(It.IsAny<string>()));
            creatureIdentifierStub.Setup(x => x.CreatureType).Returns("someType");
            creatureIdentifierStub.Setup(x => x.ArmyNumber).Returns(3);
            creaturesFactoryStub.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creatureStub.Object);

            // Act & Assert

            Assert.Catch<ArgumentException>(() => sut.AddCreatures(creatureIdentifierStub.Object, 10));
            
        }
        
        [Test]
        public void Attack_ShouldThrowArgumentNullException_WhenPassedAttackerIdentifierIsNull()
        {
            // Arrange
            var creaturesFactoryStub = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();
            var sut = new BattleManager(creaturesFactoryStub.Object, loggerMock.Object);

            var attackerIdentifierStub = new Mock<ICreatureIdentifier>();
            var defenderIdentifierStub = new Mock<ICreatureIdentifier>();

            // Act & Assert

            Assert.Catch<ArgumentNullException>(() => sut.Attack(null, defenderIdentifierStub.Object));
        }

        [Test]
        public void Attack_ShouldThrowArgumentException_WhenAttackingWithNullCreature()
        {
            // Arrange
            var creaturesFactoryStub = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();
            var sut = new BattleManager(creaturesFactoryStub.Object, loggerMock.Object);

            var attackerIdentifierStub = new Mock<ICreatureIdentifier>();
            var defenderIdentifierStub = new Mock<ICreatureIdentifier>();

            attackerIdentifierStub.Setup(x => x.ArmyNumber).Returns(1);

            // Act & Assert

            Assert.Catch<ArgumentException>(() => sut.Attack(attackerIdentifierStub.Object, defenderIdentifierStub.Object));

        }

        [Test]
        public void Attack_ShouldCallWriteLineFromLoggerExactlyFourTimes_WhenValidAttackHappens()
        {
            // Arrange
            var creaturesFactoryStub = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();
            var sut = new BattleManager(creaturesFactoryStub.Object, loggerMock.Object);

            var attackerIdentifierStub = new Mock<ICreatureIdentifier>();
            var defenderIdentifierStub = new Mock<ICreatureIdentifier>();

            attackerIdentifierStub.Setup(x => x.ArmyNumber).Returns(1);
            attackerIdentifierStub.Setup(x => x.CreatureType).Returns("Behemoth");
            defenderIdentifierStub.Setup(x => x.ArmyNumber).Returns(2);
            defenderIdentifierStub.Setup(x => x.CreatureType).Returns("Behemoth");

            var singleCreatureOneStub = new Behemoth();
            //singleCreatureOneStub.Setup(x => x.GetType().Name).Returns("Behemoth");
            var singleCreatureTwoStub = new Behemoth();
            //singleCreatureTwoStub.Setup(x => x.GetType().Name).Returns("Behemoth");

            var creatureInArmyOneStub = new Mock<ICreaturesInBattle>();
            var creatureInArmyTwoStub = new Mock<ICreaturesInBattle>();
            creatureInArmyOneStub.Setup(x => x.StartNewTurn());
            creatureInArmyOneStub.Setup(x => x.DealDamage(creatureInArmyTwoStub.Object));
            creatureInArmyOneStub.Setup(x => x.Creature).Returns(singleCreatureOneStub);
            creatureInArmyTwoStub.Setup(x => x.StartNewTurn());
            creatureInArmyTwoStub.Setup(x => x.Creature).Returns(singleCreatureTwoStub);

            sut.GetFirstArmyCreatures.Add(creatureInArmyOneStub.Object);
            sut.GetSecondArmyCreatures.Add(creatureInArmyTwoStub.Object);

            // Act

            sut.Attack(attackerIdentifierStub.Object, defenderIdentifierStub.Object);

            // Assert

            loggerMock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(4));

        }
    }
}
