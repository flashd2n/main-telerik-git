using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Core.Factories;
using Academy.Models.Utils.LectureResources;

namespace Academy.Tests.CoreTests.FactoriesTests
{
    [TestFixture]
    public class AcademyFactoryTests
    {
        [Test]
        public void CreateLectureResource_ShouldThrowArgumentException_WhenPassedValueTypeIsInvalid()
        {
            // Arrange
            var sut = AcademyFactory.Instance;

            // Act & Assert

            Assert.Catch<ArgumentException>(() => sut.CreateLectureResource("invalidTyoe", "somename", "someurl"));

        }

        [Test]
        public void CreateLectureResource_ShouldReturnCorrectVideoResource_WhenValidDataIsPassed()
        {
            // Arrange
            var sut = AcademyFactory.Instance;

            // Act

            var result = sut.CreateLectureResource("video", "somename", "someurl");

            // Assert

            Assert.IsInstanceOf<VideoResource>(result);

        }

        [Test]
        public void CreateLectureResource_ShouldReturnCorrectPresentationResource_WhenValidDataIsPassed()
        {
            // Arrange
            var sut = AcademyFactory.Instance;

            // Act

            var result = sut.CreateLectureResource("presentation", "somename", "someurl");

            // Assert

            Assert.IsInstanceOf<PresentationResource>(result);
        }

        [Test]
        public void CreateLectureResource_ShouldReturnCorrectDemoResource_WhenValidDataIsPassed()
        {
            // Arrange
            var sut = AcademyFactory.Instance;

            // Act

            var result = sut.CreateLectureResource("demo", "somename", "someurl");

            // Assert

            Assert.IsInstanceOf<DemoResource>(result);
        }

        [Test]
        public void CreateLectureResource_ShouldReturnCorrectHomeworkResource_WhenValidDataIsPassed()
        {
            // Arrange
            var sut = AcademyFactory.Instance;

            // Act

            var result = sut.CreateLectureResource("homework", "somename", "someurl");

            // Assert

            Assert.IsInstanceOf<HomeworkResource>(result);
        }
    }
}
