using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Core;

namespace PackageManager.Tests.Core
{
    [TestFixture]
    public class PackageInstallerTests
    {

        [Test]
        public void Constructor_ShouldInvokeRestorePackagesOnce_WhenValidDataIsPassed()
        {
            // Arrange
            var downloaderStub = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();

            downloaderStub.Setup(x => x.Remove(It.IsAny<string>()));
            downloaderStub.Setup(x => x.Download(It.IsAny<string>()));
            projectMock.Setup(x => x.Location).Returns("location");

            var packageStub = new Mock<IPackage>();
            packageStub.Setup(x => x.Name).Returns("name");

            projectMock.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>() { packageStub.Object});

            var packageDependencyOne = new Mock<IPackage>();
            packageDependencyOne.Setup(x => x.Name).Returns("namedepOne");
            packageDependencyOne.Setup(x => x.Dependencies).Returns(new List<IPackage>());

            packageStub.Setup(x => x.Dependencies.Count).Returns(1);
            packageStub.Setup(x => x.Dependencies).Returns(new List<IPackage>() { packageDependencyOne.Object });

            // Act

            var sut = new PackageInstaller(downloaderStub.Object, projectMock.Object);

            // Assert

            projectMock.Verify(x => x.PackageRepository.Add(It.IsAny<IPackage>()), Times.Exactly(2));
        }

        [Test]
        public void PerformOperation_ShouldCallDownloadTwoTimesRemoveOnetime_WhenNoDependencies()
        {

            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectStub = new Mock<IProject>();

            downloaderMock.Setup(x => x.Remove(It.IsAny<string>()));
            downloaderMock.Setup(x => x.Download(It.IsAny<string>()));
            projectStub.Setup(x => x.Location).Returns("location");

            var packageStub = new Mock<IPackage>();
            packageStub.Setup(x => x.Name).Returns("name");

            projectStub.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>() { packageStub.Object });
            packageStub.Setup(x => x.Dependencies).Returns(new List<IPackage>());

            // Act

            var sut = new PackageInstaller(downloaderMock.Object, projectStub.Object);

            // Assert

            downloaderMock.Verify(x => x.Download(It.IsAny<string>()), Times.Exactly(2));
            downloaderMock.Verify(x => x.Remove(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void PerformOperation_ShouldCallDownloadFourTimesRemoveTwoTimes_WhenOneDependencyIsPresent()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectStub = new Mock<IProject>();

            downloaderMock.Setup(x => x.Remove(It.IsAny<string>()));
            downloaderMock.Setup(x => x.Download(It.IsAny<string>()));
            projectStub.Setup(x => x.Location).Returns("location");

            var packageStub = new Mock<IPackage>();
            packageStub.Setup(x => x.Name).Returns("name");

            projectStub.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>() { packageStub.Object });

            var packageDependencyOne = new Mock<IPackage>();
            packageDependencyOne.Setup(x => x.Name).Returns("namedepOne");
            packageDependencyOne.Setup(x => x.Dependencies).Returns(new List<IPackage>());

            packageStub.Setup(x => x.Dependencies.Count).Returns(1);
            packageStub.Setup(x => x.Dependencies).Returns(new List<IPackage>() { packageDependencyOne.Object });

            // Act

            var sut = new PackageInstaller(downloaderMock.Object, projectStub.Object);

            // Assert
            downloaderMock.Verify(x => x.Download(It.IsAny<string>()), Times.Exactly(4));
            downloaderMock.Verify(x => x.Remove(It.IsAny<string>()), Times.Exactly(2));
        }



    }
}
