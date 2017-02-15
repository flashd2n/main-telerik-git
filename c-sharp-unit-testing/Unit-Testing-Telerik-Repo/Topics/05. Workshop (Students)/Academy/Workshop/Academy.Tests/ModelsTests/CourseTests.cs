using Academy.Models;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.ModelsTests
{

    [TestFixture]
    public class CourseTests
    {
        private const string name = "ValidCourseName";
        private const int lecturesPerWeek = 5;
        private readonly DateTime? starting = DateTime.Parse("02/13/2017");
        private readonly DateTime? ending = DateTime.Parse("03/13/2017");

        public Course GenerateValidCourse()
        {
            var validCourse = new Course(name, lecturesPerWeek, starting, ending);
            return validCourse;
        }

        [Test]
        public void Constructor_ShouldCorrectlySetName_WhenValidDataIsPassed()
        {
            // Arrange

            var sut = GenerateValidCourse();

            // Act & Assert

            Assert.AreEqual(name, sut.Name);

        }

        [Test]
        public void Constructor_ShouldCorrectlySetLecturesPerWeek_WhenValidDataIsPassed()
        {
            // Arrange

            var sut = GenerateValidCourse();

            // Act & Assert

            Assert.AreEqual(lecturesPerWeek, sut.LecturesPerWeek);

        }

        [Test]
        public void Constructor_ShouldCorrectlySetStartingDate_WhenValidDataIsPassed()
        {
            // Arrange

            var sut = GenerateValidCourse();

            // Act & Assert

            Assert.AreEqual(starting, sut.StartingDate);

        }

        [Test]
        public void Constructor_ShouldCorrectlySetEndingDate_WhenValidDataIsPassed()
        {
            // Arrange

            var sut = GenerateValidCourse();

            // Act & Assert

            Assert.AreEqual(ending, sut.EndingDate);
        }

        [Test]
        public void Constructor_ShouldCorrectlyInitializeOnlineStudents_WhenValidDataIsPassed()
        {
            // Arrange

            var sut = GenerateValidCourse();

            // Act & Assert

            Assert.IsInstanceOf<List<IStudent>>(sut.OnlineStudents);
        }

        [Test]
        public void Constructor_ShouldCorrectlyInitializeOnsiteStudents_WhenValidDataIsPassed()
        {
            // Arrange

            var sut = GenerateValidCourse();

            // Act & Assert

            Assert.IsInstanceOf<List<IStudent>>(sut.OnsiteStudents);
        }

        [Test]
        public void Constructor_ShouldCorrectlyInitializeLectures_WhenValidDataIsPassed()
        {
            // Arrange

            var sut = GenerateValidCourse();

            // Act & Assert

            Assert.IsInstanceOf<List<ILecture>>(sut.Lectures);
        }
        
        [TestCase(null)]
        [TestCase(" ")]
        public void NameProperty_ShouldThrowArgumentException_WhenPassedValueIsNullOrWhiteSpace(string invalidName)
        {
            // Arrange

            var sut = GenerateValidCourse();

            // Act & Assert

            Assert.Catch<ArgumentException>(() => sut.Name = invalidName);
        }

        [TestCase("a")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void NameProperty_ShouldThrowArgumentException_WhenPassedValueIsOutsideSetBoundaries(string invalidName)
        {
            // Arrange

            var sut = GenerateValidCourse();

            // Act & Assert

            Assert.Catch<ArgumentException>(() => sut.Name = invalidName);
        }

        [Test]
        public void NameProperty_ShouldNotThrow_WhenValidValueIsPassed()
        {
            // Arrange
            var sut = GenerateValidCourse();
            string valid = "VaaaalidName";

            // Act & Assert


            Assert.DoesNotThrow(() => sut.Name = valid);
        }

        [Test]
        public void NameProperty_ShouldCorrectlyAssignName_WhenValidValueIsPassed()
        {
            // Arrange
            var sut = GenerateValidCourse();
            string valid = "VaaaalidName";

            // Act
            sut.Name = valid;

            //Assert

            Assert.AreEqual(valid, sut.Name);
        }

        [TestCase(0)]
        [TestCase(8)]
        public void LecturesPerWeekProperty_ShouldThrowArgumentException_WhenPassedValueIsOutsideSetBoundaries(int invalidNumberOfLectures)
        {
            // Arrange

            var sut = GenerateValidCourse();

            // Act & Assert

            Assert.Catch<ArgumentException>(() => sut.LecturesPerWeek = invalidNumberOfLectures);
        }

        [Test]
        public void LecturesPerWeekProperty_ShouldNotThrow_WhenValidValueIsPassed()
        {
            // Arrange
            var sut = GenerateValidCourse();
            int valid = 3;

            // Act & Assert


            Assert.DoesNotThrow(() => sut.LecturesPerWeek = valid);
        }

        [Test]
        public void LecturesPerWeekProperty_ShouldCorrectlyAssignLEcturesPerWeek_WhenValidValueIsPassed()
        {
            // Arrange
            var sut = GenerateValidCourse();
            int valid = 3;

            // Act
            sut.LecturesPerWeek = valid;

            //Assert

            Assert.AreEqual(valid, sut.LecturesPerWeek);
        }

        [Test]
        public void StartingDateProperty_ShouldThrowArgumentException_WhenPassedValueIsNull()
        {
            // Arrange

            var sut = GenerateValidCourse();

            // Act & Assert

            Assert.Catch<ArgumentException>(() => sut.StartingDate = null);
        }

        [Test]
        public void StartingDateProperty_ShouldNotThrow_WhenValidValueIsPassed()
        {
            // Arrange
            var sut = GenerateValidCourse();
            DateTime? valid = starting;

            // Act & Assert


            Assert.DoesNotThrow(() => sut.StartingDate = valid);
        }

        [Test]
        public void StartingDateProperty_ShouldCorrectlyAssignStartingDate_WhenValidValueIsPassed()
        {
            // Arrange
            var sut = GenerateValidCourse();
            DateTime? valid = starting;

            // Act
            sut.StartingDate = valid;

            //Assert

            Assert.AreEqual(valid, sut.StartingDate);
        }

        [Test]
        public void EndingDateProperty_ShouldThrowArgumentException_WhenPassedValueIsNull()
        {
            // Arrange

            var sut = GenerateValidCourse();

            // Act & Assert

            Assert.Catch<ArgumentException>(() => sut.EndingDate = null);
        }

        [Test]
        public void EndingDateProperty_ShouldNotThrow_WhenValidValueIsPassed()
        {
            // Arrange
            var sut = GenerateValidCourse();
            DateTime? valid = ending;

            // Act & Assert


            Assert.DoesNotThrow(() => sut.EndingDate = valid);
        }

        [Test]
        public void EndingDateProperty_ShouldCorrectlyAssignEndingDate_WhenValidValueIsPassed()
        {
            // Arrange
            var sut = GenerateValidCourse();
            DateTime? valid = ending;

            // Act
            sut.EndingDate = valid;

            //Assert

            Assert.AreEqual(valid, sut.EndingDate);
        }

        [Test]
        public void ToString_ShouldReturnAListOfLectures_WhenValidLecturesArePresent()
        {
            // Arrange

            var sut = GenerateValidCourse();
            var lectureMock = new Mock<ILecture>();
            lectureMock.Setup(x => x.ToString());
            sut.Lectures.Add(lectureMock.Object);

            // Act

            sut.ToString();

            // Assert
            lectureMock.Verify(x => x.ToString(), Times.Once);

        }

        [Test]
        public void ToString_ShouldReturnAMessage_WhenNoLecturesArePresent()
        {
            // Arrange

            var sut = GenerateValidCourse();

            // Act

            var result = sut.ToString();

            // Assert

            StringAssert.Contains("no lectures", result);

        }

    }
}
