using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Commands;
using PackageManager.Tests.Fakes;
using PackageManager.Enums;

namespace PackageManager.Tests.Commands
{
    [TestFixture]
    public class InstallCommandsTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenInstallerPassedIsNull()
        {
            // Arrange

            var installerStub = new Mock<IInstaller<IPackage>>();
            var packageStub = new Mock<IPackage>();

            // Act & Assert

            Assert.Catch<ArgumentNullException>(() => new InstallCommand(null, packageStub.Object));


        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenPackagePassedIsNull()
        {
            // Arrange

            var installerStub = new Mock<IInstaller<IPackage>>();

            // Act & Assert

            Assert.Catch<ArgumentNullException>(() => new InstallCommand(installerStub.Object, null));
        }

        [Test]
        public void Constructor_ShouldNotThrow_WhenValidInstallerAndPackageArePassed()
        {
            // Arrange

            var installerStub = new Mock<IInstaller<IPackage>>();
            var packageStub = new Mock<IPackage>();

            // Act & Assert

            Assert.DoesNotThrow(() => new InstallCommand(installerStub.Object, packageStub.Object));
            
        }

        [Test]
        public void Constructor_ShouldCorrectlySetInstallerField_WhenPassedValidData()
        {
            // Arrange

            var installerStub = new Mock<IInstaller<IPackage>>();
            var packageStub = new Mock<IPackage>();

            // Act

            var sut = new FakeInstallCommand(installerStub.Object, packageStub.Object);
            

            // Assert

            Assert.AreEqual(installerStub.Object, sut.GetInstaller());

        }

        [Test]
        public void Constructor_ShouldCorrectlySetPackageField_WhenPassedValidData()
        {
            // Arrange

            var installerStub = new Mock<IInstaller<IPackage>>();
            var packageStub = new Mock<IPackage>();

            // Act

            var sut = new FakeInstallCommand(installerStub.Object, packageStub.Object);

            // Assert

            Assert.AreEqual(packageStub.Object, sut.GetPackage());

        }

        [Test]
        public void Constructor_ShouldCorrectlyAssignInstallerOperation_WhenValidInstallerIsPased()
        {
            // Arrange
            var expected = InstallerOperation.Install;
            var installerStub = new Mock<IInstaller<IPackage>>();
            var packageStub = new Mock<IPackage>();

            // Act

            var sut = new FakeInstallCommand(installerStub.Object, packageStub.Object);

            // Assert

            Assert.AreEqual(expected, sut.GetInstaller().Operation);

        }

        [Test]
        public void Execute_ShouldCorrectlyCallPerformOperation_WhenInvoked()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageStub = new Mock<IPackage>();
            var sut = new InstallCommand(installerMock.Object, packageStub.Object);

            installerMock.Setup(x => x.PerformOperation(It.IsAny<IPackage>()));

            // Act

            sut.Execute();

            // Assert

            installerMock.Verify(x => x.PerformOperation(It.IsAny<IPackage>()), Times.Once);
        }


    }
}
