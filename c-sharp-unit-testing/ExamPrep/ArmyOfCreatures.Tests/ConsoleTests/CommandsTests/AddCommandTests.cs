using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using ArmyOfCreatures.Console.Commands;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Tests.ConsoleTests.CommandsTests
{
    [TestFixture]
    public class AddCommandTests
    {
        [Test]
        public void ProcessCommand_ShouldThrowArgumentNullException_WhenIBattleManagerIsNull()
        {
            // Arrange

            var sut = new AddCommand();
            var testParameters = new string[] {"12", "creatureIdentifier" };

            // Act & Assert

            Assert.Catch<ArgumentNullException>(() => sut.ProcessCommand(null, testParameters));
        }

        [Test]
        public void ProcessCommand_ShouldThrowArgumentNullException_WhenPassedArgumentsArrayIsNull()
        {
            // Arrange

            var sut = new AddCommand();
            var battleManagerStub = new Mock<IBattleManager>();

            // Act & Assert

            Assert.Catch<ArgumentNullException>(() => sut.ProcessCommand(battleManagerStub.Object, null));
        }

        [Test]
        public void ProcessCommand_ShouldThrowArgumentException_WhenPassedArgumentsArrayCountIsNotValid()
        {
            // Arrange

            var sut = new AddCommand();
            var battleManagerStub = new Mock<IBattleManager>();
            var testParameters = new string[] { "12"};

            // Act & Assert

            Assert.Catch<ArgumentException>(() => sut.ProcessCommand(battleManagerStub.Object, testParameters));
        }

        [Test]
        public void ProcessCommand_ShouldCallIBattleManagerAddCreaturesMethod_WhenPassedParametersAreValid()
        {
            // Arrange

            var sut = new AddCommand();
            var battleManagerMock = new Mock<IBattleManager>();
            var testParameters = new string[] { "12", "creaturetype(3)" };

            // Act

            sut.ProcessCommand(battleManagerMock.Object, testParameters);

            // Assert

            battleManagerMock.Verify(x => x.AddCreatures(It.IsAny<CreatureIdentifier>(), It.IsAny<int>()), Times.Once);

            
        }

    }
}
