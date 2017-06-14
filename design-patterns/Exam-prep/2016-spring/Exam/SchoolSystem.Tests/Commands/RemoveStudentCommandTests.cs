using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using System.Collections.Generic;

namespace SchoolSystem.Tests.Commands
{
    [TestFixture]
    public class RemoveStudentCommandTests
    {
        [Test]
        public void ExecuteShouldCallRemoveOnStudentsList_WhenValidParameters()
        {
            // Arrange
            var validParameters = new List<string>() { "1" };

            var databaseStub = new Mock<IDatabase>();
            databaseStub.Setup(x => x.Students.Remove(It.IsAny<int>()));

            var sut = new RemoveStudentCommand(databaseStub.Object);

            // Act

            var result = sut.Execute(validParameters);

            // Assert

            databaseStub.Verify(x => x.Students.Remove(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void ExecuteShouldCallRemoveOnStudentsListWithCorrectArgument_WhenValidParameters()
        {
            // Arrange
            var validParameters = new List<string>() { "1" };
            var validId = int.Parse(validParameters[0]);

            var databaseStub = new Mock<IDatabase>();
            databaseStub.Setup(x => x.Students.Remove(It.IsAny<int>()));

            var sut = new RemoveStudentCommand(databaseStub.Object);

            // Act

            var result = sut.Execute(validParameters);

            // Assert

            databaseStub.Verify(x => x.Students.Remove(validId), Times.Once);
        }

        [Test]
        public void ExecuteShouldReturnCorrectMessage_WhenSuccess()
        {
            // Arrange
            var validParameters = new List<string>() { "1" };

            var databaseStub = new Mock<IDatabase>();
            databaseStub.Setup(x => x.Students.Remove(It.IsAny<int>()));

            var sut = new RemoveStudentCommand(databaseStub.Object);

            // Act

            var result = sut.Execute(validParameters);

            // Assert

            StringAssert.Contains("sucessfully removed", result);

        }
    }
}
