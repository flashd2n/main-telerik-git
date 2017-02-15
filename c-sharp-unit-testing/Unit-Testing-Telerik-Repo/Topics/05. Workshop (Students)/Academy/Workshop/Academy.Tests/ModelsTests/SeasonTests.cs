using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;

namespace Academy.Tests.ModelsTests
{
    [TestFixture]
    public class SeasonTests
    {
        [Test]
        public void ListUsers_ShouldReturnListOfStudentsAndTrainers_WhenPresent()
        {
            // Arrange

            var sut = new Season(2016, 2017, Initiative.KidsAcademy);
            var trainerOneStub = new Mock<ITrainer>();
            var trainerTwoStub = new Mock<ITrainer>();
            trainerOneStub.Setup(x => x.ToString());
            trainerTwoStub.Setup(x => x.ToString());
            sut.Trainers.Add(trainerOneStub.Object);
            sut.Trainers.Add(trainerTwoStub.Object);

            // Act

            sut.ListUsers();


            // Assert

            trainerOneStub.Verify(x => x.ToString(), Times.Once);
            trainerTwoStub.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        public void ListUsers_ShouldReturnMessage_WhenNoUsersAreAvailable()
        {
            // Arrange
            var sut = new Season(2016, 2017, Initiative.KidsAcademy);


            // Act

            var result = sut.ListUsers();

            // Assert
            StringAssert.Contains("no users", result);

        }


        [Test]
        public void ListCourses_ShouldReturnListOfCourses_WhenNotEmpty()
        {
            // Arrange

            var sut = new Season(2016, 2017, Initiative.KidsAcademy);
            var courseOneStub = new Mock<ICourse>();
            var courseTwoStub = new Mock<ICourse>();
            courseOneStub.Setup(x => x.ToString());
            courseTwoStub.Setup(x => x.ToString());
            sut.Courses.Add(courseOneStub.Object);
            sut.Courses.Add(courseTwoStub.Object);

            // Act

            sut.ListCourses();


            // Assert

            courseOneStub.Verify(x => x.ToString(), Times.Once);
            courseTwoStub.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        public void ListCourses_ShouldReturnMessage_WhenEmpty()
        {
            // Arrange
            var sut = new Season(2016, 2017, Initiative.KidsAcademy);


            // Act

            var result = sut.ListCourses();

            // Assert
            StringAssert.Contains("no courses", result);

        }
}
