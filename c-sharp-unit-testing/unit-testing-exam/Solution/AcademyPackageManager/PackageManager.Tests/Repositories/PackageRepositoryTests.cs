using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;

namespace PackageManager.Tests.Repositories
{
    [TestFixture]
    public class PackageRepositoryTests
    {
        [Test]
        public void Add_ShouldThrowArgumentNullExceptionwithMessagePackageCannotBeNull_WhenInvalidPackageIsPassed()
        {
            // Arrange
            var expectedErrorMessage = "package cannot be null";
            var loggerStub = new Mock<ILogger>();
            var packages = new List<IPackage>();
            var sut = new PackageRepository(loggerStub.Object, packages);

            // Act & Assert

            var ex = Assert.Catch<ArgumentNullException>(() => sut.Add(null));
            StringAssert.Contains(expectedErrorMessage, ex.Message);

        }

        [Test]
        public void Add_ShouldNotThrowArgumentNullException_WhenValidPackageIsPassed()
        {
            // Arrange
            var expectedErrorMessage = "package cannot be null";
            var loggerStub = new Mock<ILogger>();
            var packages = new List<IPackage>();
            var sut = new PackageRepository(loggerStub.Object, packages);
            var packageStub = new Mock<IPackage>();
            // Act & Assert

            Assert.DoesNotThrow(() => sut.Add(packageStub.Object));
        }

        [Test]
        public void Add_ShouldIncrementPackagesCount_WhenAddingNotFoundPackage()
        {
            // Arrange
            var expectedCount = 2;
            var loggerStub = new Mock<ILogger>();
            var packages = new List<IPackage>();
            var sut = new PackageRepository(loggerStub.Object, packages);

            loggerStub.Setup(x => x.Log(It.IsAny<string>()));

            var packageForPackagesStub = new Mock<IPackage>();
            packageForPackagesStub.Setup(x => x.Name).Returns("notname");

            packages.Add(packageForPackagesStub.Object);

            var packageStub = new Mock<IPackage>();
            packageStub.Setup(x => x.Name).Returns("name");

            // Act

            sut.Add(packageStub.Object);

            // Assert

            Assert.AreEqual(expectedCount, packages.Count);
        }

        [Test]
        public void Add_ShouldCallLoggerLogWithMessageTryToInstallAnotherVersion_WhenAddingPackageWithSameVersion()
        {

            // Arrange
            var expectedMessage = "Try to install another version";
            var loggerMock = new Mock<ILogger>();
            var packages = new List<IPackage>();
            var sut = new PackageRepository(loggerMock.Object, packages);

            loggerMock.Setup(x => x.Log(It.IsAny<string>()));

            var packageForPackagesStub = new Mock<IPackage>();
            packageForPackagesStub.Setup(x => x.Name).Returns("name");

            packages.Add(packageForPackagesStub.Object);

            var packageStub = new Mock<IPackage>();
            packageStub.Setup(x => x.Name).Returns("name");
            packageStub.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(0);


            // Act

            sut.Add(packageStub.Object);

            // Assert

            loggerMock.Verify(x => x.Log(expectedMessage), Times.Once);

        }

        [Test]
        public void Add_ShouldCallUpdateMethodByNotCallingLoggerLogNever_WhenPackageExistsWithLowerVersion()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new List<IPackage>();
            var sut = new PackageRepository(loggerMock.Object, packages);

            loggerMock.Setup(x => x.Log(It.IsAny<string>()));

            var packageForPackagesStub = new Mock<IPackage>();
            packageForPackagesStub.Setup(x => x.Name).Returns("name");

            packages.Add(packageForPackagesStub.Object);

            var packageStub = new Mock<IPackage>();
            packageStub.Setup(x => x.Name).Returns("name");
            packageStub.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(1);
            
            // Act

            sut.Add(packageStub.Object);

            //

            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Never);
        }
        
        [Test]
        public void Add_ShouldCallLoggerLogWithMessagePackageWithNewerVersion_WhenPackageWithHigherVersionExists()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new List<IPackage>();
            var sut = new PackageRepository(loggerMock.Object, packages);

            loggerMock.Setup(x => x.Log(It.IsAny<string>()));

            var packageForPackagesStub = new Mock<IPackage>();
            packageForPackagesStub.Setup(x => x.Name).Returns("name");

            packages.Add(packageForPackagesStub.Object);

            var packageStub = new Mock<IPackage>();
            packageStub.Setup(x => x.Name).Returns("name");
            packageStub.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(-1);

            // Act

            sut.Add(packageStub.Object);

            // Assert

            loggerMock.Verify(x => x.Log(string.Format("{0}: There is a package with newer version!", packageStub.Object.Name)));

        }

        [Test]
        public void Delete_ShouldThrowArgumentNullException_WhenNullPackageIsPassed()
        {
            // Arrange
            var loggerStub = new Mock<ILogger>();
            var packages = new List<IPackage>();
            var sut = new PackageRepository(loggerStub.Object, packages);

            // Act & Assert

            Assert.Catch<ArgumentNullException>(() => sut.Delete(null));

        }

        [Test]
        public void Delete_ShouldthrowArgumentNullExceptionAndInvokeLoggerLogWithMessage_WhenPackageNotFound()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new List<IPackage>();
            var sut = new PackageRepository(loggerMock.Object, packages);

            loggerMock.Setup(x => x.Log(It.IsAny<string>()));

            var packageForPackagesStub = new Mock<IPackage>();
            packageForPackagesStub.Setup(x => x.Name).Returns("name");

            packages.Add(packageForPackagesStub.Object);

            var packageStub = new Mock<IPackage>();
            packageStub.Setup(x => x.Name).Returns("noname");


            // Assert
            Assert.Catch<ArgumentNullException>(() => sut.Delete(packageStub.Object));
            loggerMock.Verify(x => x.Log(string.Format("{0}: The package does not exist!", packageStub.Object.Name)), Times.Once);

        }

        [Test]
        public void Delete_ShouldInvokeLoggerThreeTimes_WhenPackageIsFoundButIsaDependencyOfOtherProjects()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new List<IPackage>();
            var sut = new PackageRepository(loggerMock.Object, packages);

            loggerMock.Setup(x => x.Log(It.IsAny<string>()));

            var dependencyStub = new Mock<IPackage>();
            dependencyStub.Setup(x => x.Equals(It.IsAny<IPackage>())).Returns(true);

            var packageForPackagesStub = new Mock<IPackage>();
            packageForPackagesStub.Setup(x => x.Equals(It.IsAny<IPackage>())).Returns(true);
            packageForPackagesStub.Setup(x => x.Name).Returns("name");
            packageForPackagesStub.Setup(x => x.Dependencies).Returns(new List<IPackage>() { dependencyStub.Object});
            

            packages.Add(packageForPackagesStub.Object);

            var packageStub = new Mock<IPackage>();
            packageStub.Setup(x => x.Name).Returns("name");
            packageStub.Setup(x => x.Equals(It.IsAny<IPackage>())).Returns(true);

            // Act

            sut.Delete(packageStub.Object);

            // Assert
            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(3));
            
        }

        [Test]
        public void Delete_ShouldReturnTheCorrectDeletedPackageAndNeverInvokeLoggerLog_WhenAllDataIsValid()
        {

            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new List<IPackage>();
            var sut = new PackageRepository(loggerMock.Object, packages);

            loggerMock.Setup(x => x.Log(It.IsAny<string>()));

            var packageForPackagesStub = new Mock<IPackage>();
            packageForPackagesStub.Setup(x => x.Equals(It.IsAny<IPackage>())).Returns(true);
            packageForPackagesStub.Setup(x => x.Name).Returns("name");
            packageForPackagesStub.Setup(x => x.Dependencies).Returns(new List<IPackage>());


            packages.Add(packageForPackagesStub.Object);

            var packageStub = new Mock<IPackage>();
            packageStub.Setup(x => x.Name).Returns("name");
            packageStub.Setup(x => x.Equals(It.IsAny<IPackage>())).Returns(true);

            // Act

            var result = sut.Delete(packageStub.Object);

            // Assert
            Assert.AreEqual(packageStub.Object, result);
            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Never);

        }

        [Test]
        public void Update_ShouldThrowArgumentNullException_WhenPassedPackageIsNull()
        {
            // Arrange
            var loggerStub = new Mock<ILogger>();
            var packages = new List<IPackage>();
            var sut = new PackageRepository(loggerStub.Object, packages);
            loggerStub.Setup(x => x.Log(It.IsAny<string>()));

            // Act & Assert

            Assert.Catch<ArgumentNullException>(() => sut.Update(null));

        }

        [Test]
        public void Update_ShouldNotThrowArgumentNullException_WhenPassedPackageIsValid()
        {
            // Arrange
            var loggerStub = new Mock<ILogger>();
            var packages = new List<IPackage>();
            var sut = new PackageRepository(loggerStub.Object, packages);
            loggerStub.Setup(x => x.Log(It.IsAny<string>()));

            var packageForPackagesStub = new Mock<IPackage>();
            packageForPackagesStub.Setup(x => x.Name).Returns("name");

            packages.Add(packageForPackagesStub.Object);


            var packageStub = new Mock<IPackage>();
            packageStub.Setup(x => x.Name).Returns("name");


            // Act & Assert

            Assert.DoesNotThrow(() => sut.Update(packageStub.Object));

        }

        [Test]
        public void Update_ShouldThrowArgumentNullExceptionAndInvokeLogerOnce_WhenNoPackageIsFound()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new List<IPackage>();
            var sut = new PackageRepository(loggerMock.Object, packages);
            loggerMock.Setup(x => x.Log(It.IsAny<string>()));

            var packageForPackagesStub = new Mock<IPackage>();
            packageForPackagesStub.Setup(x => x.Name).Returns("name");

            packages.Add(packageForPackagesStub.Object);


            var packageStub = new Mock<IPackage>();
            packageStub.Setup(x => x.Name).Returns("noname");

            // Act & Assert

            Assert.Catch<ArgumentNullException>(() => sut.Update(packageStub.Object));
            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Update_ShouldReturnTrue_WhenSuccessfullyUpdatedPackage()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new List<IPackage>();
            var sut = new PackageRepository(loggerMock.Object, packages);
            loggerMock.Setup(x => x.Log(It.IsAny<string>()));

            var packageForPackagesStub = new Mock<IPackage>();
            packageForPackagesStub.Setup(x => x.Name).Returns("name");

            packages.Add(packageForPackagesStub.Object);


            var packageStub = new Mock<IPackage>();
            packageStub.Setup(x => x.Name).Returns("name");
            packageStub.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(1);
            var versionStub = new Mock<IVersion>();
            packageStub.Setup(x => x.Version).Returns(versionStub.Object);

            // Act

            var result = sut.Update(packageStub.Object);

            // Assert

            Assert.True(result);
        }


        [Test]
        public void Update_ShouldThrowArgumentExceptionAndInvokeLoggerLogOnce_WhenFoundPackageWithHigherVersion()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new List<IPackage>();
            var sut = new PackageRepository(loggerMock.Object, packages);
            loggerMock.Setup(x => x.Log(It.IsAny<string>()));

            var packageForPackagesStub = new Mock<IPackage>();
            packageForPackagesStub.Setup(x => x.Name).Returns("name");

            packages.Add(packageForPackagesStub.Object);


            var packageStub = new Mock<IPackage>();
            packageStub.Setup(x => x.Name).Returns("name");
            packageStub.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(-1);
            var versionStub = new Mock<IVersion>();
            packageStub.Setup(x => x.Version).Returns(versionStub.Object);

            // Act & Assert

            Assert.Catch<ArgumentException>(() => sut.Update(packageStub.Object));
            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Update_ShouldInvokeLoggerLogOnceAndReturnFalse_WhenFoundPackageWithSameVersion()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new List<IPackage>();
            var sut = new PackageRepository(loggerMock.Object, packages);
            loggerMock.Setup(x => x.Log(It.IsAny<string>()));

            var packageForPackagesStub = new Mock<IPackage>();
            packageForPackagesStub.Setup(x => x.Name).Returns("name");

            packages.Add(packageForPackagesStub.Object);


            var packageStub = new Mock<IPackage>();
            packageStub.Setup(x => x.Name).Returns("name");
            packageStub.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(0);
            var versionStub = new Mock<IVersion>();
            packageStub.Setup(x => x.Version).Returns(versionStub.Object);

            // Act

            var result = sut.Update(packageStub.Object);

            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
            Assert.False(result);
        }

        [Test]
        public void GetAll_ShouldReturnEmptyCollection_WhenRepositoryHasNoPassedCollection()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var sut = new PackageRepository(loggerMock.Object, null);
            loggerMock.Setup(x => x.Log(It.IsAny<string>()));


            // Act

            var result = sut.GetAll();

            // Assert

            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public void GetAll_ShouldReturnCollectionWithNumberOfElementsEqualToTheNumberOfPackagesInPassedCollection_WhenThereIsAPassedCollection()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new List<IPackage>();
            var sut = new PackageRepository(loggerMock.Object, packages);
            loggerMock.Setup(x => x.Log(It.IsAny<string>()));

            var packageForCollectionStubOne = new Mock<IPackage>();
            var packageForCollectionStubTwo = new Mock<IPackage>();

            packages.Add(packageForCollectionStubOne.Object);
            packages.Add(packageForCollectionStubTwo.Object);
            // Act

            var result = sut.GetAll();

            // Assert

            Assert.AreEqual(2, result.Count());
        }

    }
}
