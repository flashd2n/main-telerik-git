using Moq;
using NUnit.Framework;
using ProjectManager.Commands;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Interfaces;
using ProjectManager.Models;
using System.Collections.Generic;

namespace ProjectManager.Tests
{
    [TestFixture]
    public class CreateTaskCommandTests
    {
        [Test]
        public void Execute_Throws_WhenInvalidParametersCountIsPassed()
        {
            // Arrange
            var databaseStub = new Mock<IDatabase>();
            var factoryStub = new Mock<IModelsFactory>();
            var expectedMessage = "Invalid command parameters count!";

            var sut = new CreateTaskCommand(databaseStub.Object, factoryStub.Object);

            var invalidParameters = new List<string>() { "one"};

            // Act and Assert

            Assert.Catch<UserValidationException>(() => sut.Execute(invalidParameters), expectedMessage);
        }

        [Test]
        public void Execute_Throws_WhenEmptyParametersArePassed()
        {
            // Arrange
            var databaseStub = new Mock<IDatabase>();
            var factoryStub = new Mock<IModelsFactory>();
            var expectedMessage = "Some of the passed parameters are empty!";

            var sut = new CreateTaskCommand(databaseStub.Object, factoryStub.Object);

            var invalidParameters = new List<string>() { "one", "two", "thre", "" };

            // Act and Assert

            Assert.Catch<UserValidationException>(() => sut.Execute(invalidParameters), expectedMessage);
        }

        [Test]
        public void Execute_CallsProjectIndex_WithCorrectId()
        {
            // Arrange
            var userStub = new Mock<IUser>();

            var projectStub = new Mock<IProject>();
            projectStub.Setup(x => x.Users).Returns(new List<IUser>() { userStub.Object });
            projectStub.Setup(x => x.Tasks.Add(It.IsAny<ITask>()));

            var databaseMock = new Mock<IDatabase>();
            databaseMock.Setup(x => x.Projects[0]).Returns(projectStub.Object);


            var factoryStub = new Mock<IModelsFactory>();
            var expectedIndex = 0;

            var sut = new CreateTaskCommand(databaseMock.Object, factoryStub.Object);

            var validParameters = new List<string>() { "0", "0", "BuildTheStar", "Pending" };

            // Act
            sut.Execute(validParameters);

            // Assert
            databaseMock.Verify(x => x.Projects[expectedIndex], Times.Once);
        }

        [Test]
        public void Execute_CallsUsersIndex_WithCorrectId()
        {
            // Arrange
            var userStub = new Mock<IUser>();

            var projectMock = new Mock<IProject>();
            projectMock.Setup(x => x.Users[0]).Returns(userStub.Object);
            projectMock.Setup(x => x.Tasks.Add(It.IsAny<ITask>()));

            var databaseStub = new Mock<IDatabase>();
            databaseStub.Setup(x => x.Projects[0]).Returns(projectMock.Object);


            var factoryStub = new Mock<IModelsFactory>();
            var expectedIndex = 0;

            var sut = new CreateTaskCommand(databaseStub.Object, factoryStub.Object);

            var validParameters = new List<string>() { "0", "0", "BuildTheStar", "Pending" };

            // Act
            sut.Execute(validParameters);

            // Assert
            projectMock.Verify(x => x.Users[expectedIndex], Times.Once);
        }

        [Test]
        public void Execute_CallsCreateTask_WithCorrectParameters()
        {
            // Arrange
            var userStub = new Mock<IUser>();

            var projectStub = new Mock<IProject>();
            projectStub.Setup(x => x.Users[0]).Returns(userStub.Object);
            projectStub.Setup(x => x.Tasks.Add(It.IsAny<ITask>()));

            var databaseStub = new Mock<IDatabase>();
            databaseStub.Setup(x => x.Projects[0]).Returns(projectStub.Object);


            var factoryMock = new Mock<IModelsFactory>();

            var sut = new CreateTaskCommand(databaseStub.Object, factoryMock.Object);

            var validParameters = new List<string>() { "0", "0", "BuildTheStar", "Pending" };

            // Act
            sut.Execute(validParameters);

            // Assert

            factoryMock.Verify(x => x.CreateTask(userStub.Object, "BuildTheStar", "Pending"), Times.Once);
        }

        [Test]
        public void Execute_AddsTask_ToProject()
        {
            // Arrange
            var taskStub = new Mock<ITask>();

            var userStub = new Mock<IUser>();

            var projectsMock = new Mock<IProject>();
            projectsMock.Setup(x => x.Users[0]).Returns(userStub.Object);
            projectsMock.Setup(x => x.Tasks.Add(It.IsAny<ITask>()));

            var databaseStub = new Mock<IDatabase>();
            databaseStub.Setup(x => x.Projects[0]).Returns(projectsMock.Object);

            var factoryStub = new Mock<IModelsFactory>();
            factoryStub.Setup(x => x.CreateTask(userStub.Object, "BuildTheStar", "Pending")).Returns(taskStub.Object);
            
            var sut = new CreateTaskCommand(databaseStub.Object, factoryStub.Object);

            var validParameters = new List<string>() { "0", "0", "BuildTheStar", "Pending" };
            
            // Act
            sut.Execute(validParameters);

            // Assert

            projectsMock.Verify(x => x.Tasks.Add(taskStub.Object), Times.Once);
        }

        [Test]
        public void Execute_ReturnsCorrectMessage_WhenMethodIsPerformedSuccessfully()
        {
            // Arrange
            var expectedOutput = "Successfully created";

            var taskStub = new Mock<ITask>();

            var userStub = new Mock<IUser>();

            var projectStub = new Mock<IProject>();
            projectStub.Setup(x => x.Users[0]).Returns(userStub.Object);
            projectStub.Setup(x => x.Tasks.Add(It.IsAny<ITask>()));

            var databaseStub = new Mock<IDatabase>();
            databaseStub.Setup(x => x.Projects[0]).Returns(projectStub.Object);

            var factoryStub = new Mock<IModelsFactory>();
            factoryStub.Setup(x => x.CreateTask(userStub.Object, "BuildTheStar", "Pending")).Returns(taskStub.Object);

            var sut = new CreateTaskCommand(databaseStub.Object, factoryStub.Object);

            var validParameters = new List<string>() { "0", "0", "BuildTheStar", "Pending" };

            // Act
            var outputMessage = sut.Execute(validParameters);

            // Assert

            StringAssert.Contains(expectedOutput, outputMessage);
        }
    }
}
