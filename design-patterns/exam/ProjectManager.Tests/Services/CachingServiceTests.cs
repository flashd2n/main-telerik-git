using Moq;
using NUnit.Framework;
using ProjectManager.Framework.Services;
using ProjectManager.Framework.Services.Contracts;
using ProjectManager.Tests.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Tests.Services
{
    [TestFixture]
    public class CachingServiceTests
    {
        [Test]
        public void ConstructorShouldThrow_WhenTimeSpanIsLessThanZero()
        {
            // Arrange
            int durationInMilliseconds = -10;

            var datetimeProvider = new Mock<IDatetimeProvider>();
            var duration = new TimeSpan(durationInMilliseconds);

            // Act & Assert

            Assert.Throws<ArgumentOutOfRangeException>(() => new CachingService(duration, datetimeProvider.Object));

        }

        [Test]
        public void ConstructorShouldThrow_WhenDatetimeProviderIsNull()
        {
            // Arrange
            int durationInMilliseconds = 1000;

            var datetimeProvider = new Mock<IDatetimeProvider>();
            var duration = new TimeSpan(durationInMilliseconds);

            // Act & Assert

            Assert.Throws<ArgumentNullException>(() => new CachingService(duration, null));

        }

        [Test]
        public void ConstructorShouldNotThrow_WhenAllParametersAreValid()
        {
            // Arrange
            int durationInMilliseconds = 1000;

            var datetimeProvider = new Mock<IDatetimeProvider>();
            var duration = new TimeSpan(durationInMilliseconds);

            // Act & Assert

            Assert.DoesNotThrow(() => new CachingService(duration, datetimeProvider.Object));

        }

        [Test]
        public void ConstructorShouldCreateInstanceOfCache()
        {
            // Arrange
            int durationInMilliseconds = 1000;

            var datetimeProvider = new Mock<IDatetimeProvider>();
            var duration = new TimeSpan(durationInMilliseconds);

            var sut = new FakeCachingService(duration, datetimeProvider.Object);

            // Act

            sut.ResetCache();

            // Assert

            Assert.IsInstanceOf<IDictionary<string, object>>(sut.Cache);
        }

        [Test]
        public void IsExpiredShouldReturnTrue_WhenTheCacheIsExpired()
        {
            // Arrange
            int durationInMilliseconds = 1000;

            var datetimeProvider = new Mock<IDatetimeProvider>();
            var duration = new TimeSpan(durationInMilliseconds);

            var timeOfCreation = new DateTime();

            datetimeProvider.SetupSequence(x => x.Now).Returns(timeOfCreation).Returns(timeOfCreation.AddDays(2));

            var sut = new CachingService(duration, datetimeProvider.Object);

            // Act

            var result = sut.IsExpired;

            // Assert

            Assert.True(result);
        }

        [Test]
        public void IsExpiredShouldReturnFalse_WhenTheCacheIsActive()
        {
            // Arrange
            int durationInMilliseconds = 1000;

            var datetimeProvider = new Mock<IDatetimeProvider>();
            var duration = new TimeSpan(durationInMilliseconds);

            var timeOfCreation = new DateTime();

            datetimeProvider.SetupSequence(x => x.Now).Returns(timeOfCreation.AddDays(2)).Returns(timeOfCreation);

            var sut = new CachingService(duration, datetimeProvider.Object);

            // Act

            var result = sut.IsExpired;

            // Assert

            Assert.IsFalse(result);
        }

        [Test]
        public void ResetCacheShouldCreateNewInstanceOfTheCache()
        {
            // Arrange
            int durationInMilliseconds = 1000;

            var datetimeProvider = new Mock<IDatetimeProvider>();
            var duration = new TimeSpan(durationInMilliseconds);

            var sut = new FakeCachingService(duration, datetimeProvider.Object);

            // Act

            sut.ResetCache();

            // Assert

            Assert.AreEqual(0, sut.Cache.Count());
        }

        [Test]
        public void ResetCacheShouldResetTheTimeExpiring()
        {
            // Arrange
            int durationInMilliseconds = 1000;

            var datetimeProvider = new Mock<IDatetimeProvider>();
            var duration = new TimeSpan(durationInMilliseconds);

            datetimeProvider.Setup(x => x.AddTime(It.IsAny<TimeSpan>()));

            var sut = new CachingService(duration, datetimeProvider.Object);

            // Act

            sut.ResetCache();

            // Assert

            datetimeProvider.Verify(x => x.AddTime(duration), Times.Once);
        }

        [Test]
        public void GetCacheValueShouldReturnCorrectValue()
        {
            // Arrange
            int durationInMilliseconds = 1000;

            var datetimeProvider = new Mock<IDatetimeProvider>();
            var duration = new TimeSpan(durationInMilliseconds);

            var sut = new FakeCachingService(duration, datetimeProvider.Object);

            sut.Cache.Add("myclass.mymethod", "awesome result");

            // Act

            var result = sut.GetCacheValue("myclass", "mymethod");

            // Assert

            Assert.AreEqual(result, sut.Cache["myclass.mymethod"]);

        }

        [Test]
        public void AddCacheValueShouldAddNewDataWithCorrectArguments()
        {

            // Arrange
            int durationInMilliseconds = 1000;

            var inputClass = "myclass";
            var inputMethod = "mymethod";
            var inputValue = "awesome result";

            var datetimeProvider = new Mock<IDatetimeProvider>();
            var duration = new TimeSpan(durationInMilliseconds);

            var sut = new FakeCachingService(duration, datetimeProvider.Object);


            // Act

            sut.AddCacheValue(inputClass, inputMethod, inputValue);

            // Assert

            Assert.AreEqual(sut.Cache[$"{inputClass}.{inputMethod}"], inputValue);

        }
    }
}
