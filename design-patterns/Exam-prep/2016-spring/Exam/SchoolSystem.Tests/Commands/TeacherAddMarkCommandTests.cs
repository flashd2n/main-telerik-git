using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Factories;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using System;
using System.Collections.Generic;

namespace SchoolSystem.Tests.Commands
{
    [TestFixture]
    public class TeacherAddMarkCommandTests
    {
        [Test]
        public void ExecuteShouldThrow_WhenStudentHasExceededTheMaxCountOfMarks()
        {
            // Arrange
            var validParameters = new List<string>() { "1", "1", "5" };
            var validteacherId = int.Parse(validParameters[0]);
            var validStudentId = int.Parse(validParameters[1]);
            var validMarkValue = float.Parse(validParameters[2]);

            var teacherSubject = Subject.Bulgarian;

            var databaseStub = new Mock<IDatabase>();
            var modelsFactoryStub = new Mock<IModelsFactory>();

            var sut = new TeacherAddMarkCommand(databaseStub.Object, modelsFactoryStub.Object);

            var studentStub = new Mock<IStudent>();
            studentStub.Setup(x => x.Marks.Count).Returns(20);
            studentStub.Setup(x => x.Marks.Add(It.IsAny<IMark>()));

            var teacherStub = new Mock<ITeacher>();
            teacherStub.Setup(x => x.Subject).Returns(teacherSubject);

            databaseStub.Setup(x => x.Students[It.IsAny<int>()]).Returns(studentStub.Object);
            databaseStub.Setup(x => x.Teachers[It.IsAny<int>()]).Returns(teacherStub.Object);

            // Act & Assert

            Assert.Throws<ArgumentException>(() => sut.Execute(validParameters));

        }

        [Test]
        public void ExecuteShouldNotThrow_WhenStudentHasLessThanTheMaxCountOfMarks()
        {
            // Arrange
            var validParameters = new List<string>() { "1", "1", "5" };
            var validteacherId = int.Parse(validParameters[0]);
            var validStudentId = int.Parse(validParameters[1]);
            var validMarkValue = float.Parse(validParameters[2]);

            var teacherSubject = Subject.Bulgarian;

            var databaseStub = new Mock<IDatabase>();
            var modelsFactoryStub = new Mock<IModelsFactory>();

            var sut = new TeacherAddMarkCommand(databaseStub.Object, modelsFactoryStub.Object);

            var studentStub = new Mock<IStudent>();
            studentStub.Setup(x => x.Marks.Count).Returns(5);
            studentStub.Setup(x => x.Marks.Add(It.IsAny<IMark>()));

            var teacherStub = new Mock<ITeacher>();
            teacherStub.Setup(x => x.Subject).Returns(teacherSubject);

            databaseStub.Setup(x => x.Students[It.IsAny<int>()]).Returns(studentStub.Object);
            databaseStub.Setup(x => x.Teachers[It.IsAny<int>()]).Returns(teacherStub.Object);

            // Act & Assert

            Assert.DoesNotThrow(() => sut.Execute(validParameters));
        }

        [Test]
        public void ExecuteShouldGetCorrectStudentFromDatabase()
        {
            // Arrange
            var validParameters = new List<string>() { "1", "1", "5" };
            var validteacherId = int.Parse(validParameters[0]);
            var validStudentId = int.Parse(validParameters[1]);
            var validMarkValue = float.Parse(validParameters[2]);

            var teacherSubject = Subject.Bulgarian;

            var databaseStub = new Mock<IDatabase>();
            var modelsFactoryStub = new Mock<IModelsFactory>();

            var sut = new TeacherAddMarkCommand(databaseStub.Object, modelsFactoryStub.Object);

            var studentStub = new Mock<IStudent>();
            studentStub.Setup(x => x.Marks.Count).Returns(5);
            studentStub.Setup(x => x.Marks.Add(It.IsAny<IMark>()));

            var teacherStub = new Mock<ITeacher>();
            teacherStub.Setup(x => x.Subject).Returns(teacherSubject);

            databaseStub.Setup(x => x.Students[It.IsAny<int>()]).Returns(studentStub.Object);
            databaseStub.Setup(x => x.Teachers[It.IsAny<int>()]).Returns(teacherStub.Object);

            // Act

            var result = sut.Execute(validParameters);

            // Assert

            databaseStub.Verify(x => x.Students[validStudentId], Times.Once);
        }

        [Test]
        public void ExecuteShouldGetCorrectTeacherFromDatabase()
        {
            // Arrange
            var validParameters = new List<string>() { "1", "1", "5" };
            var validteacherId = int.Parse(validParameters[0]);
            var validStudentId = int.Parse(validParameters[1]);
            var validMarkValue = float.Parse(validParameters[2]);

            var teacherSubject = Subject.Bulgarian;

            var databaseStub = new Mock<IDatabase>();
            var modelsFactoryStub = new Mock<IModelsFactory>();

            var sut = new TeacherAddMarkCommand(databaseStub.Object, modelsFactoryStub.Object);

            var studentStub = new Mock<IStudent>();
            studentStub.Setup(x => x.Marks.Count).Returns(5);
            studentStub.Setup(x => x.Marks.Add(It.IsAny<IMark>()));

            var teacherStub = new Mock<ITeacher>();
            teacherStub.Setup(x => x.Subject).Returns(teacherSubject);

            databaseStub.Setup(x => x.Students[It.IsAny<int>()]).Returns(studentStub.Object);
            databaseStub.Setup(x => x.Teachers[It.IsAny<int>()]).Returns(teacherStub.Object);

            // Act

            var result = sut.Execute(validParameters);

            // Assert

            databaseStub.Verify(x => x.Teachers[validteacherId], Times.Once);
        }


        [Test]
        public void ExecuteShouldCallCreateMarkOnce_WhenValidParameters()
        {
            // Arrange
            var validParameters = new List<string>() { "1", "1", "5" };
            var validteacherId = int.Parse(validParameters[0]);
            var validStudentId = int.Parse(validParameters[1]);
            var validMarkValue = float.Parse(validParameters[2]);

            var teacherSubject = Subject.Bulgarian;

            var databaseStub = new Mock<IDatabase>();
            var modelsFactoryStub = new Mock<IModelsFactory>();

            var sut = new TeacherAddMarkCommand(databaseStub.Object, modelsFactoryStub.Object);

            var studentStub = new Mock<IStudent>();
            studentStub.Setup(x => x.Marks.Count).Returns(5);
            studentStub.Setup(x => x.Marks.Add(It.IsAny<IMark>()));

            var teacherStub = new Mock<ITeacher>();
            teacherStub.Setup(x => x.Subject).Returns(teacherSubject);

            databaseStub.Setup(x => x.Students[It.IsAny<int>()]).Returns(studentStub.Object);
            databaseStub.Setup(x => x.Teachers[It.IsAny<int>()]).Returns(teacherStub.Object);

            // Act

            var result = sut.Execute(validParameters);

            // Assert

            modelsFactoryStub.Verify(x => x.CreateMark(It.IsAny<Subject>(), It.IsAny<float>()), Times.Once);
        }

        [Test]
        public void ExecuteShouldCreateMarkWithCorrectData_WhenValidParameters()
        {
            // Arrange
            var validParameters = new List<string>() { "1", "1", "5" };
            var validteacherId = int.Parse(validParameters[0]);
            var validStudentId = int.Parse(validParameters[1]);
            var validMarkValue = float.Parse(validParameters[2]);

            var teacherSubject = Subject.Bulgarian;

            var databaseStub = new Mock<IDatabase>();
            var modelsFactoryStub = new Mock<IModelsFactory>();

            var sut = new TeacherAddMarkCommand(databaseStub.Object, modelsFactoryStub.Object);

            var studentStub = new Mock<IStudent>();
            studentStub.Setup(x => x.Marks.Count).Returns(5);
            studentStub.Setup(x => x.Marks.Add(It.IsAny<IMark>()));

            var teacherStub = new Mock<ITeacher>();
            teacherStub.Setup(x => x.Subject).Returns(teacherSubject);

            databaseStub.Setup(x => x.Students[It.IsAny<int>()]).Returns(studentStub.Object);
            databaseStub.Setup(x => x.Teachers[It.IsAny<int>()]).Returns(teacherStub.Object);

            // Act

            var result = sut.Execute(validParameters);

            // Assert

            modelsFactoryStub.Verify(x => x.CreateMark(teacherSubject, validMarkValue), Times.Once);
        }

        [Test]
        public void ExecuteShouldAddTheMarkToTheStudent_WhenValidParameters()
        {
            // Arrange
            var validParameters = new List<string>() { "1", "1", "5" };
            var validteacherId = int.Parse(validParameters[0]);
            var validStudentId = int.Parse(validParameters[1]);
            var validMarkValue = float.Parse(validParameters[2]);

            var teacherSubject = Subject.Bulgarian;

            var databaseStub = new Mock<IDatabase>();
            var modelsFactoryStub = new Mock<IModelsFactory>();

            var sut = new TeacherAddMarkCommand(databaseStub.Object, modelsFactoryStub.Object);

            var studentStub = new Mock<IStudent>();
            studentStub.Setup(x => x.Marks.Count).Returns(5);
            studentStub.Setup(x => x.Marks.Add(It.IsAny<IMark>()));

            var teacherStub = new Mock<ITeacher>();
            teacherStub.Setup(x => x.Subject).Returns(teacherSubject);

            var markStub = new Mock<IMark>();

            databaseStub.Setup(x => x.Students[It.IsAny<int>()]).Returns(studentStub.Object);
            databaseStub.Setup(x => x.Teachers[It.IsAny<int>()]).Returns(teacherStub.Object);

            modelsFactoryStub.Setup(x => x.CreateMark(It.IsAny<Subject>(), It.IsAny<float>())).Returns(markStub.Object);

            // Act

            var result = sut.Execute(validParameters);

            // Assert

            studentStub.Verify(x => x.Marks.Add(markStub.Object), Times.Once);

        }

        [Test]
        public void ExecuteShouldReturnCorrectSuccessMessage()
        {
            // Arrange
            var validParameters = new List<string>() { "1", "1", "5" };
            var validteacherId = int.Parse(validParameters[0]);
            var validStudentId = int.Parse(validParameters[1]);
            var validMarkValue = float.Parse(validParameters[2]);

            var teacherSubject = Subject.Bulgarian;

            var databaseStub = new Mock<IDatabase>();
            var modelsFactoryStub = new Mock<IModelsFactory>();

            var sut = new TeacherAddMarkCommand(databaseStub.Object, modelsFactoryStub.Object);

            var studentStub = new Mock<IStudent>();
            studentStub.Setup(x => x.Marks.Count).Returns(5);
            studentStub.Setup(x => x.Marks.Add(It.IsAny<IMark>()));

            var teacherStub = new Mock<ITeacher>();
            teacherStub.Setup(x => x.Subject).Returns(teacherSubject);

            databaseStub.Setup(x => x.Students[It.IsAny<int>()]).Returns(studentStub.Object);
            databaseStub.Setup(x => x.Teachers[It.IsAny<int>()]).Returns(teacherStub.Object);

            // Act

            var result = sut.Execute(validParameters);

            // Assert

            StringAssert.Contains("added mark", result);
        }
    }
}
