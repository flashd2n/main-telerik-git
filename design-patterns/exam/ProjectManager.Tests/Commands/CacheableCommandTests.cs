using Moq;
using NUnit.Framework;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Services;
using System;
using System.Collections.Generic;

namespace ProjectManager.Tests.Commands
{
    [TestFixture]
    public class CacheableCommandTests
    {
        [Test]
        public void ConstructorShouldThrow_WhenInvalidCommandIsPassed()
        {
            // Arrange

            var commandStub = new Mock<ICommand>();
            var cachingServiceStub = new Mock<ICachingService>();

            // Act & Assert

            Assert.Throws<ArgumentNullException>(() => new CacheableCommand(null, cachingServiceStub.Object));
        }

        [Test]
        public void ConstructorShouldThrow_WhenInvalidCachingServiceIsPassed()
        {
            // Arrange

            var commandStub = new Mock<ICommand>();
            var cachingServiceStub = new Mock<ICachingService>();

            // Act & Assert

            Assert.Throws<ArgumentNullException>(() => new CacheableCommand(commandStub.Object, null));
        }

        [Test]
        public void ConstructorShouldNotThrow_WhenAllPassedParametersAreValid()
        {
            // Arrange

            var commandStub = new Mock<ICommand>();
            var cachingServiceStub = new Mock<ICachingService>();

            // Act & Assert

            Assert.DoesNotThrow(() => new CacheableCommand(commandStub.Object, cachingServiceStub.Object));
        }

        [Test]
        public void ParameterCountPropertyShouldReturnCorrectBaseCommandValue()
        {
            // Arrange

            var commandStub = new Mock<ICommand>();
            var cachingServiceStub = new Mock<ICachingService>();


            commandStub.Setup(x => x.ParameterCount).Returns(1);

            var sut = new CacheableCommand(commandStub.Object, cachingServiceStub.Object);

            // Act & Assert

            Assert.AreEqual(1, sut.ParameterCount);

        }

        [Test]
        public void ExecuteShouldResetTheCache_WhenCacheIsExpired()
        {
            // Arrange
            var inputParameters = new List<string>();
            var returnFromBase = "wow";

            var commandStub = new Mock<ICommand>();
            var cachingServiceStub = new Mock<ICachingService>();

            cachingServiceStub.Setup(x => x.IsExpired).Returns(true);
            cachingServiceStub.Setup(x => x.ResetCache());
            cachingServiceStub.Setup(x => x.AddCacheValue(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()));

            commandStub.Setup(x => x.Execute(It.IsAny<IList<string>>())).Returns(returnFromBase);

            var sut = new CacheableCommand(commandStub.Object, cachingServiceStub.Object);

            // Act

            var result = sut.Execute(inputParameters);

            // Assert

            cachingServiceStub.Verify(x => x.ResetCache(), Times.Once);
        }

        [Test]
        public void ExecuteShouldExecuteBaseCommandOnce_WhenCacheIsExpired()
        {
            // Arrange
            var inputParameters = new List<string>();
            var returnFromBase = "wow";

            var commandStub = new Mock<ICommand>();
            var cachingServiceStub = new Mock<ICachingService>();

            cachingServiceStub.Setup(x => x.IsExpired).Returns(true);
            cachingServiceStub.Setup(x => x.ResetCache());
            cachingServiceStub.Setup(x => x.AddCacheValue(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()));

            commandStub.Setup(x => x.Execute(It.IsAny<IList<string>>())).Returns(returnFromBase);

            var sut = new CacheableCommand(commandStub.Object, cachingServiceStub.Object);

            // Act

            var result = sut.Execute(inputParameters);

            // Assert

            commandStub.Verify(x => x.Execute(It.IsAny<IList<string>>()), Times.Once);
        }

        [Test]
        public void ExecuteShouldExecuteBaseCommandOnceWithCorrectArgument_WhenCacheIsExpired()
        {
            // Arrange
            var inputParameters = new List<string>();
            var returnFromBase = "wow";

            var commandStub = new Mock<ICommand>();
            var cachingServiceStub = new Mock<ICachingService>();

            cachingServiceStub.Setup(x => x.IsExpired).Returns(true);
            cachingServiceStub.Setup(x => x.ResetCache());
            cachingServiceStub.Setup(x => x.AddCacheValue(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()));

            commandStub.Setup(x => x.Execute(It.IsAny<IList<string>>())).Returns(returnFromBase);

            var sut = new CacheableCommand(commandStub.Object, cachingServiceStub.Object);

            // Act

            var result = sut.Execute(inputParameters);

            // Assert

            commandStub.Verify(x => x.Execute(inputParameters), Times.Once);
        }

        [Test]
        public void ExecuteShouldAddReturnedValueFromBaseCommandToCache_WhenCacheIsExpired()
        {
            // Arrange
            var inputParameters = new List<string>();
            var returnFromBase = "wow";

            var commandStub = new Mock<ICommand>();
            var cachingServiceStub = new Mock<ICachingService>();

            cachingServiceStub.Setup(x => x.IsExpired).Returns(true);
            cachingServiceStub.Setup(x => x.ResetCache());
            cachingServiceStub.Setup(x => x.AddCacheValue(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()));

            commandStub.Setup(x => x.Execute(It.IsAny<IList<string>>())).Returns(returnFromBase);

            var sut = new CacheableCommand(commandStub.Object, cachingServiceStub.Object);

            // Act

            var result = sut.Execute(inputParameters);

            // Assert

            cachingServiceStub.Verify(x => x.AddCacheValue(It.IsAny<string>(), It.IsAny<string>(), returnFromBase), Times.Once);
        }

        [Test]
        public void ExecuteShouldReturnBaseCommandResult_WhenCacheIsExpired()
        {
            // Arrange
            var inputParameters = new List<string>();
            var returnFromBase = "wow";

            var commandStub = new Mock<ICommand>();
            var cachingServiceStub = new Mock<ICachingService>();

            cachingServiceStub.Setup(x => x.IsExpired).Returns(true);
            cachingServiceStub.Setup(x => x.ResetCache());
            cachingServiceStub.Setup(x => x.AddCacheValue(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()));

            commandStub.Setup(x => x.Execute(It.IsAny<IList<string>>())).Returns(returnFromBase);

            var sut = new CacheableCommand(commandStub.Object, cachingServiceStub.Object);

            // Act

            var result = sut.Execute(inputParameters);

            // Assert

            Assert.AreEqual(result, returnFromBase);
        }

        [Test]
        public void ExecuteShouldNotCallBaseCommand_WhenCacheIsNotExpired()
        {
            // Arrange
            var inputParameters = new List<string>();
            var returnFromCache = "cacheres";

            var commandStub = new Mock<ICommand>();
            var cachingServiceStub = new Mock<ICachingService>();

            commandStub.Setup(x => x.Execute(It.IsAny<IList<string>>()));

            cachingServiceStub.Setup(x => x.IsExpired).Returns(false);
            cachingServiceStub.Setup(x => x.GetCacheValue(It.IsAny<string>(), It.IsAny<string>())).Returns(returnFromCache);

            var sut = new CacheableCommand(commandStub.Object, cachingServiceStub.Object);

            // Act

            var result = sut.Execute(inputParameters);

            // Assert

            commandStub.Verify(x => x.Execute(It.IsAny<IList<string>>()), Times.Never);
        }

        [Test]
        public void ExecuteShouldGetTheReturnValueFromCache_WhenCacheIsNotExpired()
        {
            // Arrange
            var inputParameters = new List<string>();
            var returnFromCache = "cacheres";

            var commandStub = new Mock<ICommand>();
            var cachingServiceStub = new Mock<ICachingService>();

            cachingServiceStub.Setup(x => x.IsExpired).Returns(false);
            cachingServiceStub.Setup(x => x.GetCacheValue(It.IsAny<string>(), It.IsAny<string>())).Returns(returnFromCache);

            var sut = new CacheableCommand(commandStub.Object, cachingServiceStub.Object);

            // Act

            var result = sut.Execute(inputParameters);

            // Assert

            cachingServiceStub.Verify(x => x.GetCacheValue(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ExecuteShouldReturnCorrectValue_WhenCacheIsNotExpired()
        {
            // Arrange
            var inputParameters = new List<string>();
            var returnFromCache = "cacheres";

            var commandStub = new Mock<ICommand>();
            var cachingServiceStub = new Mock<ICachingService>();

            cachingServiceStub.Setup(x => x.IsExpired).Returns(false);
            cachingServiceStub.Setup(x => x.GetCacheValue(It.IsAny<string>(), It.IsAny<string>())).Returns(returnFromCache);

            var sut = new CacheableCommand(commandStub.Object, cachingServiceStub.Object);

            // Act

            var result = sut.Execute(inputParameters);

            // Assert

            Assert.AreEqual(result, returnFromCache);
        }

    }
}
