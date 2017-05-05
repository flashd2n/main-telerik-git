using Moq;
using NUnit.Framework;
using ProjectManager.Common.Exceptions;
using ProjectManager.Interfaces;
using System;

namespace ProjectManager.Tests
{
    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void Start_Reads_WhenTypedOnTheConsole()
        {
            // Arrange
            var validCommad = "CreateProject DeathStar 2016-1-1 2018-05-04 Active";
            var terminateCommand = "exit";
            var expectedOutput = "Program terminated.";

            var loggerStub = new Mock<IFileLogger>();

            var processorStub = new Mock<ICommandProcessor>();

            var readerStub = new Mock<IReader>();
            readerStub.SetupSequence(x => x.ReadLine()).Returns(validCommad).Returns(terminateCommand);

            var writerMock = new Mock<IWriter>();

            var sut = new Engine(loggerStub.Object, processorStub.Object, readerStub.Object, writerMock.Object);

            // Act
            sut.Start();

            // Assert
            writerMock.Verify(x => x.WriteLine(expectedOutput), Times.Once);
        }

        [Test]
        public void Start_CallsWriteLineOne_WhenTerminaCommandIsPassed()
        {
            // Arrange
            var terminateCommand = "exit";
            var expectedOutput = "Program terminated.";

            var loggerStub = new Mock<IFileLogger>();

            var processorStub = new Mock<ICommandProcessor>();

            var readerStub = new Mock<IReader>();
            readerStub.SetupSequence(x => x.ReadLine()).Returns(terminateCommand);

            var writerMock = new Mock<IWriter>();

            var sut = new Engine(loggerStub.Object, processorStub.Object, readerStub.Object, writerMock.Object);

            // Act
            sut.Start();

            // Assert
            writerMock.Verify(x => x.WriteLine(expectedOutput), Times.Once);
        }

        [Test]
        public void Start_WritesTheCorrectExecutionresult_WhenValidCommandIsPassed()
        {
            // Arrange
            var validCommad = "CreateProject DeathStar 2016-1-1 2018-05-04 Active";
            var terminateCommand = "exit";
            var expectedOutput = "Successfully created a new project!";

            var loggerStub = new Mock<IFileLogger>();

            var processorStub = new Mock<ICommandProcessor>();
            processorStub.Setup(x => x.ProcessCommand(validCommad)).Returns(expectedOutput);

            var readerStub = new Mock<IReader>();
            readerStub.SetupSequence(x => x.ReadLine()).Returns(validCommad).Returns(terminateCommand);

            var writerMock = new Mock<IWriter>();

            var sut = new Engine(loggerStub.Object, processorStub.Object, readerStub.Object, writerMock.Object);

            // Act
            sut.Start();

            // Assert
            writerMock.Verify(x => x.WriteLine(expectedOutput), Times.Once);
        }

        [Test]
        public void Start_WritesExceptionMessage_WhenUserValidationExceptionOccurs()
        {
            // Arrange
            var invalidCommad = "CreateProject DeathStar 2016-1-1 2018-05-04 Active InvalidParameter";
            var terminateCommand = "exit";
            var expectedOutput = " - Error: Invalid command parameters count!";
            var exceptionMessage = "Invalid command parameters count!";

            var loggerStub = new Mock<IFileLogger>();

            var processorStub = new Mock<ICommandProcessor>();
            processorStub.Setup(x => x.ProcessCommand(invalidCommad)).Throws(new UserValidationException(exceptionMessage));

            var readerStub = new Mock<IReader>();
            readerStub.SetupSequence(x => x.ReadLine()).Returns(invalidCommad).Returns(terminateCommand);

            var writerMock = new Mock<IWriter>();

            var sut = new Engine(loggerStub.Object, processorStub.Object, readerStub.Object, writerMock.Object);

            // Act
            sut.Start();

            // Assert
            writerMock.Verify(x => x.WriteLine(expectedOutput), Times.Once);
        }

        [Test]
        public void Start_LogsExceptionMessage_WhenGenericExceptionOccurs()
        {
            // Arrange
            var invalidCommad = "CreateProject DeathStar 2016-1-1 2018-05-04 Active InvalidParameter";
            var terminateCommand = "exit";
            var expectedOutput = "Generic Exception Message";
            var exceptionMessage = "Generic Exception Message";

            var loggerMock = new Mock<IFileLogger>();

            var processorStub = new Mock<ICommandProcessor>();
            processorStub.Setup(x => x.ProcessCommand(invalidCommad)).Throws(new Exception(exceptionMessage));

            var readerStub = new Mock<IReader>();
            readerStub.SetupSequence(x => x.ReadLine()).Returns(invalidCommad).Returns(terminateCommand);

            var writerStub = new Mock<IWriter>();

            var sut = new Engine(loggerMock.Object, processorStub.Object, readerStub.Object, writerStub.Object);

            // Act
            sut.Start();

            // Assert
            loggerMock.Verify(x => x.LogError(expectedOutput), Times.Once);
        }

        [Test]
        public void Start_WritesSomethingHappned_WhenGenericExceptionOccurs()
        {
            // Arrange
            var invalidCommad = "CreateProject DeathStar 2016-1-1 2018-05-04 Active InvalidParameter";
            var terminateCommand = "exit";
            var expectedOutput = "Opps, something happened. :(";
            var exceptionMessage = "Generic Exception Message";

            var loggerStub = new Mock<IFileLogger>();

            var processorStub = new Mock<ICommandProcessor>();
            processorStub.Setup(x => x.ProcessCommand(invalidCommad)).Throws(new Exception(exceptionMessage));

            var readerStub = new Mock<IReader>();
            readerStub.SetupSequence(x => x.ReadLine()).Returns(invalidCommad).Returns(terminateCommand);

            var writerMock = new Mock<IWriter>();

            var sut = new Engine(loggerStub.Object, processorStub.Object, readerStub.Object, writerMock.Object);

            // Act
            sut.Start();

            // Assert
            writerMock.Verify(x => x.WriteLine(expectedOutput), Times.Once);
        }
    }
}
