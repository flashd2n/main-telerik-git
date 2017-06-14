using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Factories;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using System.Collections.Generic;

namespace SchoolSystem.Tests.Commands
{
    [TestFixture]
    public class CreateStudentCommandTests
    {
        [Test]
        public void ExecuteShouldCallCreateStudentOnce_WhenValidParametersArePassed()
        {
            // Arrange
            var validInputParameters = new List<string>() { "gosho", "goshev", "7" };
            var newStudentId = 1;

            var modelsFactoryMock = new Mock<IModelsFactory>();
            var idProviderStub = new Mock<IIdProvider>();
            var databaseStub = new Mock<IDatabase>();

            var studentStub = new Mock<IStudent>();

            var sut = new CreateStudentCommand(modelsFactoryMock.Object, idProviderStub.Object, databaseStub.Object);

            modelsFactoryMock.Setup(x => x.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>())).Returns(studentStub.Object);

            idProviderStub.Setup(x => x.GetNextStudentId()).Returns(newStudentId);

            databaseStub.Setup(x => x.Students.Add(It.IsAny<int>(), It.IsAny<IStudent>()));

            // Act

            var result = sut.Execute(validInputParameters);

            // Assert

            modelsFactoryMock.Verify(x => x.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>()), Times.Once);
        }

        [Test]
        public void ExecuteShouldCallCreateStudentOnceWithCorrectArguments_WhenValidParametersArePassed()
        {
            // Arrange
            var validInputParameters = new List<string>() { "gosho", "goshev", "7" };
            var newStudentId = 1;

            var modelsFactoryMock = new Mock<IModelsFactory>();
            var idProviderStub = new Mock<IIdProvider>();
            var databaseStub = new Mock<IDatabase>();

            var studentStub = new Mock<IStudent>();

            var sut = new CreateStudentCommand(modelsFactoryMock.Object, idProviderStub.Object, databaseStub.Object);

            modelsFactoryMock.Setup(x => x.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>())).Returns(studentStub.Object);

            idProviderStub.Setup(x => x.GetNextStudentId()).Returns(newStudentId);

            databaseStub.Setup(x => x.Students.Add(It.IsAny<int>(), It.IsAny<IStudent>()));

            // Act

            var result = sut.Execute(validInputParameters);

            // Assert

            var expectedGrade = (Grade)int.Parse(validInputParameters[2]);

            modelsFactoryMock.Verify(x => x.CreateStudent(validInputParameters[0], validInputParameters[1], expectedGrade), Times.Once);
        }

        [Test]
        public void ExecuteShouldGetStudentId_WhenValidParametersArePassed()
        {
            // Arrange
            var validInputParameters = new List<string>() { "gosho", "goshev", "7" };
            var newStudentId = 1;
            var expectedGrade = (Grade)int.Parse(validInputParameters[2]);

            var modelsFactoryStub = new Mock<IModelsFactory>();
            var idProviderMock = new Mock<IIdProvider>();
            var databaseStub = new Mock<IDatabase>();

            var studentStub = new Mock<IStudent>();

            var sut = new CreateStudentCommand(modelsFactoryStub.Object, idProviderMock.Object, databaseStub.Object);

            modelsFactoryStub.Setup(x => x.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>())).Returns(studentStub.Object);

            idProviderMock.Setup(x => x.GetNextStudentId()).Returns(newStudentId);

            databaseStub.Setup(x => x.Students.Add(It.IsAny<int>(), It.IsAny<IStudent>()));

            // Act

            var result = sut.Execute(validInputParameters);

            // Assert

            idProviderMock.Verify(x => x.GetNextStudentId(), Times.Once);

        }

        [Test]
        public void ExecuteShouldAddStudentToDatabase_WhenValidParametersArePassed()
        {
            // Arrange
            var validInputParameters = new List<string>() { "gosho", "goshev", "7" };
            var newStudentId = 1;
            var expectedGrade = (Grade)int.Parse(validInputParameters[2]);

            var modelsFactoryStub = new Mock<IModelsFactory>();
            var idProviderStub = new Mock<IIdProvider>();
            var databaseMock = new Mock<IDatabase>();

            var studentStub = new Mock<IStudent>();

            var sut = new CreateStudentCommand(modelsFactoryStub.Object, idProviderStub.Object, databaseMock.Object);

            modelsFactoryStub.Setup(x => x.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>())).Returns(studentStub.Object);

            idProviderStub.Setup(x => x.GetNextStudentId()).Returns(newStudentId);

            databaseMock.Setup(x => x.Students.Add(It.IsAny<int>(), It.IsAny<IStudent>()));

            // Act

            var result = sut.Execute(validInputParameters);

            // Assert

            databaseMock.Verify(x => x.Students.Add(It.IsAny<int>(), It.IsAny<IStudent>()), Times.Once);
        }

        [Test]
        public void ExecuteShouldAddStudentToDatabaseWithCorrectParameters_WhenValidParametersArePassed()
        {
            // Arrange
            var validInputParameters = new List<string>() { "gosho", "goshev", "7" };
            var newStudentId = 1;
            var expectedGrade = (Grade)int.Parse(validInputParameters[2]);

            var modelsFactoryStub = new Mock<IModelsFactory>();
            var idProviderStub = new Mock<IIdProvider>();
            var databaseMock = new Mock<IDatabase>();

            var studentStub = new Mock<IStudent>();

            var sut = new CreateStudentCommand(modelsFactoryStub.Object, idProviderStub.Object, databaseMock.Object);

            modelsFactoryStub.Setup(x => x.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>())).Returns(studentStub.Object);

            idProviderStub.Setup(x => x.GetNextStudentId()).Returns(newStudentId);

            databaseMock.Setup(x => x.Students.Add(It.IsAny<int>(), It.IsAny<IStudent>()));

            // Act

            var result = sut.Execute(validInputParameters);

            // Assert

            databaseMock.Verify(x => x.Students.Add(newStudentId, studentStub.Object), Times.Once);
        }

        [Test]
        public void ExecuteShouldCorrectSuccessMessage_WhenOperationWasSuccessfull()
        {
            // Arrange
            var validInputParameters = new List<string>() { "gosho", "goshev", "7" };
            var newStudentId = 1;
            var expectedGrade = (Grade)int.Parse(validInputParameters[2]);

            var modelsFactoryStub = new Mock<IModelsFactory>();
            var idProviderStub = new Mock<IIdProvider>();
            var databaseStub = new Mock<IDatabase>();

            var studentStub = new Mock<IStudent>();

            var sut = new CreateStudentCommand(modelsFactoryStub.Object, idProviderStub.Object, databaseStub.Object);

            modelsFactoryStub.Setup(x => x.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>())).Returns(studentStub.Object);

            idProviderStub.Setup(x => x.GetNextStudentId()).Returns(newStudentId);

            databaseStub.Setup(x => x.Students.Add(It.IsAny<int>(), It.IsAny<IStudent>()));

            // Act

            var result = sut.Execute(validInputParameters);

            // Assert

            StringAssert.Contains($"student with name {validInputParameters[0]} {validInputParameters[1]}, grade {expectedGrade} and ID {newStudentId} was created", result);
        }
    }
}
