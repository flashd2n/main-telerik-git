using Moq;
using Ninject.Extensions.Interception;
using NUnit.Framework;
using ProjectManager.ConsoleClient.Interceptors;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Tests.Interceptors
{
    [TestFixture]
    public class LogErrorInterceptorTests
    {
        [Test]
        public void ConstructorShouldThrow_WhenAllParametersAreInvalid()
        {
            // Arrange & Act & Assert

            Assert.Throws<ArgumentNullException>(() => new LogErrorInterceptor(null, null));

        }

        [Test]
        public void ConstructorShouldThrow_WhenPassedLoggerIsInvalid()
        {
            // Arrange
            var loggerStub = new Mock<ILogger>();
            var writerStub = new Mock<IWriter>();

            // Act & Assert

            Assert.Throws<ArgumentNullException>(() => new LogErrorInterceptor(null, writerStub.Object));

        }

        [Test]
        public void ConstructorShouldThrow_WhenPassedWriterIsInvalid()
        {
            // Arrange
            var loggerStub = new Mock<ILogger>();
            var writerStub = new Mock<IWriter>();

            // Act & Assert

            Assert.Throws<ArgumentNullException>(() => new LogErrorInterceptor(loggerStub.Object, null));
        }

        [Test]
        public void ConstructorShouldNotThrow_WhenPassedParametersAreValid()
        {
            // Arrange
            var loggerStub = new Mock<ILogger>();
            var writerStub = new Mock<IWriter>();

            // Act & Assert

            Assert.DoesNotThrow(() => new LogErrorInterceptor(loggerStub.Object, writerStub.Object));
        }

        [Test]
        public void InterceptShouldCallProceedOnce_WhenAllParamsAreValid()
        {
            // Arrange
            var loggerStub = new Mock<ILogger>();
            var writerStub = new Mock<IWriter>();

            var invocationStub = new Mock<IInvocation>();
            object returnFromInvocation = "wow";

            invocationStub.Setup(x => x.Proceed());
            invocationStub.Setup(x => x.ReturnValue).Returns(returnFromInvocation);

            writerStub.Setup(x => x.WriteLine(It.IsAny<string>()));

            loggerStub.Setup(x => x.Error(It.IsAny<string>()));

            var sut = new LogErrorInterceptor(loggerStub.Object, writerStub.Object);

            // Act

            sut.Intercept(invocationStub.Object);

            // Assert

            invocationStub.Verify(x => x.Proceed(), Times.Once);
        }

        [Test]
        public void InterceptShouldShouldCallWriterWriteLineOnceWithCorrectArgument_WhenProceedDoesNotThrow()
        {
            // Arrange
            var loggerStub = new Mock<ILogger>();
            var writerStub = new Mock<IWriter>();

            var invocationStub = new Mock<IInvocation>();
            object returnFromInvocation = "wow";

            invocationStub.Setup(x => x.Proceed());
            invocationStub.Setup(x => x.ReturnValue).Returns(returnFromInvocation);

            writerStub.Setup(x => x.WriteLine(It.IsAny<string>()));

            loggerStub.Setup(x => x.Error(It.IsAny<string>()));

            var sut = new LogErrorInterceptor(loggerStub.Object, writerStub.Object);

            // Act

            sut.Intercept(invocationStub.Object);

            // Assert

            writerStub.Verify(x => x.WriteLine(returnFromInvocation.ToString()), Times.Once);
        }

        [Test]
        public void InterceptShouldCallLoggerErrorOnceWithCorrectMessage_WhenValidationExceptionIsCaught()
        {
            // Arrange
            var loggerStub = new Mock<ILogger>();
            var writerStub = new Mock<IWriter>();

            var invocationStub = new Mock<IInvocation>();
            var errorMessage = "wow";

            invocationStub.Setup(x => x.Proceed()).Throws(new UserValidationException(errorMessage));

            writerStub.Setup(x => x.WriteLine(It.IsAny<string>()));

            loggerStub.Setup(x => x.Error(It.IsAny<string>()));

            var sut = new LogErrorInterceptor(loggerStub.Object, writerStub.Object);

            // Act

            sut.Intercept(invocationStub.Object);

            // Assert

            loggerStub.Verify(x => x.Error(errorMessage), Times.Once);
        }

        [Test]
        public void InterceptShouldCallWriterWritelineOnceWithCorrectMessage_WhenValidationExceptionIsCaught()
        {
            // Arrange
            var loggerStub = new Mock<ILogger>();
            var writerStub = new Mock<IWriter>();

            var invocationStub = new Mock<IInvocation>();
            var errorMessage = "wow";

            invocationStub.Setup(x => x.Proceed()).Throws(new UserValidationException(errorMessage));

            writerStub.Setup(x => x.WriteLine(It.IsAny<string>()));

            loggerStub.Setup(x => x.Error(It.IsAny<string>()));

            var sut = new LogErrorInterceptor(loggerStub.Object, writerStub.Object);

            // Act

            sut.Intercept(invocationStub.Object);

            // Assert

            writerStub.Verify(x => x.WriteLine(errorMessage), Times.Once);
        }

        [Test]
        public void InterceptShouldCallLoggerErrorOnceWithCorrectMessage_WhenExceptionIsCaught()
        {
            // Arrange
            var loggerStub = new Mock<ILogger>();
            var writerStub = new Mock<IWriter>();

            var invocationStub = new Mock<IInvocation>();
            var errorMessage = "wow";

            invocationStub.Setup(x => x.Proceed()).Throws(new Exception(errorMessage));

            writerStub.Setup(x => x.WriteLine(It.IsAny<string>()));

            loggerStub.Setup(x => x.Error(It.IsAny<string>()));

            var sut = new LogErrorInterceptor(loggerStub.Object, writerStub.Object);

            // Act

            sut.Intercept(invocationStub.Object);

            // Assert

            loggerStub.Verify(x => x.Error(errorMessage), Times.Once);
        }

        [Test]
        public void InterceptShouldCallWriterWritelineOnceWithCorrectMessage_WhenExceptionIsCaught()
        {
            // Arrange
            var loggerStub = new Mock<ILogger>();
            var writerStub = new Mock<IWriter>();

            var invocationStub = new Mock<IInvocation>();
            var errorMessage = "wow";

            invocationStub.Setup(x => x.Proceed()).Throws(new Exception(errorMessage));

            writerStub.Setup(x => x.WriteLine(It.IsAny<string>()));

            loggerStub.Setup(x => x.Error(It.IsAny<string>()));

            var sut = new LogErrorInterceptor(loggerStub.Object, writerStub.Object);

            // Act

            sut.Intercept(invocationStub.Object);

            // Assert

            writerStub.Verify(x => x.WriteLine(It.Is<string>(str => str.Contains("Check the log file"))), Times.Once);
        }
    }
}
