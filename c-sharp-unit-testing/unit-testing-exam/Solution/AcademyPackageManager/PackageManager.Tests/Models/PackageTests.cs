using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models
{
    [TestFixture]
    public class PackageTests
    {
        [Test]
        public void Constructor_ShouldInitiateNewDependencies_WhenNoDependenciesPassed()
        {
            // Arrange

            string nameTest = "somename";
            var versionStub = new Mock<IVersion>();

            // Act

            var sut = new Package(nameTest, versionStub.Object);

            // Assert

            Assert.IsInstanceOf<ICollection<IPackage>>(sut.Dependencies);

        }

        [Test]
        public void Constructor_ShouldCorrectlyAssignDependencies_WhenValidDependenciesArePassed()
        {
            // Arrange

            string nameTest = "somename";
            var versionStub = new Mock<IVersion>();
            var dependenciesStub = new Mock<ICollection<IPackage>>();

            // Act

            var sut = new Package(nameTest, versionStub.Object, dependenciesStub.Object);

            // Assert

            Assert.AreEqual(dependenciesStub.Object, sut.Dependencies);

        }

        [Test]
        public void Property_ShouldCorrectlyAssignNameValue_WhenValidDataIsPassed()
        {
            // Arrage
            string nameTest = "somename";
            var versionStub = new Mock<IVersion>();
            var dependenciesStub = new Mock<ICollection<IPackage>>();

            // Act
            var sut = new Package(nameTest, versionStub.Object, dependenciesStub.Object);

            // Assert

            Assert.AreEqual(nameTest, sut.Name);

        }

        [Test]
        public void Property_ShouldThrowArgumentNullException_WhenNullNameIsPassed()
        {
            // Arrage
            string nameTest = null;
            var versionStub = new Mock<IVersion>();
            var dependenciesStub = new Mock<ICollection<IPackage>>();

            // Act & Assert

            Assert.Catch<ArgumentNullException>(() => new Package(nameTest, versionStub.Object, dependenciesStub.Object));

        }

        [Test]
        public void Property_ShouldCorrectlyAssignVersionValue_WhenValidDataIsPassed()
        {
            // Arrage
            string nameTest = "somename";
            var versionStub = new Mock<IVersion>();
            var dependenciesStub = new Mock<ICollection<IPackage>>();

            // Act
            var sut = new Package(nameTest, versionStub.Object, dependenciesStub.Object);

            // Assert

            Assert.AreEqual(versionStub.Object, sut.Version);
        }

        [Test]
        public void Property_ShouldThrowArgumentNullException_WhenNullVersionIsPassed()
        {
            // Arrage
            string nameTest = "sometestname";
            var dependenciesStub = new Mock<ICollection<IPackage>>();

            // Act & Assert

            Assert.Catch<ArgumentNullException>(() => new Package(nameTest, null, dependenciesStub.Object));
        }

        [Test]
        public void Property_ShouldCorrectlySetUrlForAllFourVersionProperties_WhenValidVersionIsPassed()
        {
            // Arrange
            string nameTest = "somename";
            var versionStub = new Mock<IVersion>();
            var dependenciesStub = new Mock<ICollection<IPackage>>();

            versionStub.Setup(x => x.Major).Returns(5);
            versionStub.Setup(x => x.Minor).Returns(6);
            versionStub.Setup(x => x.Patch).Returns(7);
            versionStub.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            // Act
            var sut = new Package(nameTest, versionStub.Object, dependenciesStub.Object);

            // Assert

            StringAssert.Contains(versionStub.Object.Major.ToString(), sut.Url);
            StringAssert.Contains(versionStub.Object.Minor.ToString(), sut.Url);
            StringAssert.Contains(versionStub.Object.Patch.ToString(), sut.Url);
            StringAssert.Contains(versionStub.Object.VersionType.ToString(), sut.Url);

        }

        [Test]
        public void CompareTo_ShouldThrowArgumentNullExceptionWithMessageContainsCannotBeNull_WhenNullValueIsPassed()
        {
            // Arrange
            string expectedErrorMessage = "cannot be null";
            string nameTest = "somename";
            var versionStub = new Mock<IVersion>();
            var dependenciesStub = new Mock<ICollection<IPackage>>();

            versionStub.Setup(x => x.Major).Returns(5);
            versionStub.Setup(x => x.Minor).Returns(6);
            versionStub.Setup(x => x.Patch).Returns(7);
            versionStub.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var sut = new Package(nameTest, versionStub.Object, dependenciesStub.Object);

            // Act & Assert

            var ex = Assert.Catch<ArgumentNullException>(() => sut.CompareTo(null));
            StringAssert.Contains(expectedErrorMessage, ex.Message);
        }

        [Test]
        public void CompareTo_ShouldThrowArgumentException_WhenPassedValueHasDifferentName()
        {
            // Arrange
            string nameTest = "somename";
            var versionStub = new Mock<IVersion>();
            var dependenciesStub = new Mock<ICollection<IPackage>>();

            versionStub.Setup(x => x.Major).Returns(5);
            versionStub.Setup(x => x.Minor).Returns(6);
            versionStub.Setup(x => x.Patch).Returns(7);
            versionStub.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var sut = new Package(nameTest, versionStub.Object, dependenciesStub.Object);
            var otherStub = new Mock<IPackage>();

            otherStub.Setup(x => x.Name).Returns("notsomename");
            otherStub.Setup(x => x.Version.Major).Returns(5);
            otherStub.Setup(x => x.Version.Minor).Returns(6);
            otherStub.Setup(x => x.Version.Patch).Returns(7);
            otherStub.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.alpha);

            // Act & Assert
            Assert.Catch<ArgumentException>(() => sut.CompareTo(otherStub.Object));
        }

        [Test]
        public void CompareTo_ShouldNotThrow_WhenValidValueIsPassed()
        {
            // Arrange
            string nameTest = "somename";
            var versionStub = new Mock<IVersion>();
            var dependenciesStub = new Mock<ICollection<IPackage>>();

            versionStub.Setup(x => x.Major).Returns(5);
            versionStub.Setup(x => x.Minor).Returns(6);
            versionStub.Setup(x => x.Patch).Returns(7);
            versionStub.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var sut = new Package(nameTest, versionStub.Object, dependenciesStub.Object);
            var otherStub = new Mock<IPackage>();

            otherStub.Setup(x => x.Name).Returns("somename");
            otherStub.Setup(x => x.Version.Major).Returns(5);
            otherStub.Setup(x => x.Version.Minor).Returns(6);
            otherStub.Setup(x => x.Version.Patch).Returns(7);
            otherStub.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.alpha);

            // Act & Assert

            Assert.DoesNotThrow(() => sut.CompareTo(otherStub.Object));
        }

        [Test]
        public void CompareTo_ShouldReturnNegative_WhenPassedPackageIsHigherVersion()
        {
            // Arrange
            var expectedValue = -1;
            string nameTest = "somename";
            var versionStub = new Mock<IVersion>();
            var dependenciesStub = new Mock<ICollection<IPackage>>();

            versionStub.Setup(x => x.Major).Returns(5);
            versionStub.Setup(x => x.Minor).Returns(6);
            versionStub.Setup(x => x.Patch).Returns(7);
            versionStub.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var sut = new Package(nameTest, versionStub.Object, dependenciesStub.Object);
            var otherStub = new Mock<IPackage>();

            otherStub.Setup(x => x.Name).Returns("somename");
            otherStub.Setup(x => x.Version.Major).Returns(6);
            otherStub.Setup(x => x.Version.Minor).Returns(7);
            otherStub.Setup(x => x.Version.Patch).Returns(8);
            otherStub.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.alpha);

            // Act

            var result = sut.CompareTo(otherStub.Object);

            // Assert

            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void CompareTo_ShouldReturnPositive_WhenPassedPackageIsLowerVersion()
        {
            // Arrange
            var expectedValue = 1;
            string nameTest = "somename";
            var versionStub = new Mock<IVersion>();
            var dependenciesStub = new Mock<ICollection<IPackage>>();

            versionStub.Setup(x => x.Major).Returns(5);
            versionStub.Setup(x => x.Minor).Returns(6);
            versionStub.Setup(x => x.Patch).Returns(7);
            versionStub.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var sut = new Package(nameTest, versionStub.Object, dependenciesStub.Object);
            var otherStub = new Mock<IPackage>();

            otherStub.Setup(x => x.Name).Returns("somename");
            otherStub.Setup(x => x.Version.Major).Returns(4);
            otherStub.Setup(x => x.Version.Minor).Returns(5);
            otherStub.Setup(x => x.Version.Patch).Returns(6);
            otherStub.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.alpha);

            // Act

            var result = sut.CompareTo(otherStub.Object);

            // Assert

            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void CompareTo_ShouldReturnZero_WhenPassedPackageIsTheSameVersion()
        {
            // Arrange
            var expectedValue = 0;
            string nameTest = "somename";
            var versionStub = new Mock<IVersion>();
            var dependenciesStub = new Mock<ICollection<IPackage>>();

            versionStub.Setup(x => x.Major).Returns(5);
            versionStub.Setup(x => x.Minor).Returns(6);
            versionStub.Setup(x => x.Patch).Returns(7);
            versionStub.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var sut = new Package(nameTest, versionStub.Object, dependenciesStub.Object);
            var otherStub = new Mock<IPackage>();

            otherStub.Setup(x => x.Name).Returns("somename");
            otherStub.Setup(x => x.Version.Major).Returns(5);
            otherStub.Setup(x => x.Version.Minor).Returns(6);
            otherStub.Setup(x => x.Version.Patch).Returns(7);
            otherStub.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.alpha);

            // Act

            var result = sut.CompareTo(otherStub.Object);

            // Assert

            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void Equals_ShouldThrowArgumentNullException_WhenPassedValueIsNull()
        {
            // Arrange
            string nameTest = "somename";
            var versionStub = new Mock<IVersion>();
            var dependenciesStub = new Mock<ICollection<IPackage>>();

            versionStub.Setup(x => x.Major).Returns(5);
            versionStub.Setup(x => x.Minor).Returns(6);
            versionStub.Setup(x => x.Patch).Returns(7);
            versionStub.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var sut = new Package(nameTest, versionStub.Object, dependenciesStub.Object);

            // Act & Assert

            Assert.Catch<ArgumentNullException>(() => sut.Equals(null));

        }

        [Test]
        public void Equals_ShouldThrowArgumentExceptionWithMessagemustBeIPackage_WhenPassedValueIsNotIPackage()
        {
            // Arrange
            string expectedMessage = "must be IPackage";
            string nameTest = "somename";
            var versionStub = new Mock<IVersion>();
            var dependenciesStub = new Mock<ICollection<IPackage>>();

            versionStub.Setup(x => x.Major).Returns(5);
            versionStub.Setup(x => x.Minor).Returns(6);
            versionStub.Setup(x => x.Patch).Returns(7);
            versionStub.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var sut = new Package(nameTest, versionStub.Object, dependenciesStub.Object);
            var objStub = new Object();

            // Act & Assert

            var ex = Assert.Catch<ArgumentException>(() => sut.Equals(objStub));
            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [Test]
        public void Equals_ShouldNotThrow_WhenValidValueIsPassed()
        {
            // Arrange
            string nameTest = "somename";
            var versionStub = new Mock<IVersion>();
            var dependenciesStub = new Mock<ICollection<IPackage>>();

            versionStub.Setup(x => x.Major).Returns(5);
            versionStub.Setup(x => x.Minor).Returns(6);
            versionStub.Setup(x => x.Patch).Returns(7);
            versionStub.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var sut = new Package(nameTest, versionStub.Object, dependenciesStub.Object);
            var objStub = new Mock<IPackage>();

            objStub.Setup(x => x.Name).Returns("somename");
            objStub.Setup(x => x.Version.Major).Returns(5);
            objStub.Setup(x => x.Version.Minor).Returns(6);
            objStub.Setup(x => x.Version.Patch).Returns(7);
            objStub.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.alpha);

            // Act & Assert

            Assert.DoesNotThrow(() => sut.Equals(objStub.Object));

        }

        [Test]
        public void Equals_ShouldReturnTrue_WhenPassedObjectIsEqualtoThePackage()
        {
            // Arrange
            string nameTest = "somename";
            var versionStub = new Mock<IVersion>();
            var dependenciesStub = new Mock<ICollection<IPackage>>();

            versionStub.Setup(x => x.Major).Returns(5);
            versionStub.Setup(x => x.Minor).Returns(6);
            versionStub.Setup(x => x.Patch).Returns(7);
            versionStub.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var sut = new Package(nameTest, versionStub.Object, dependenciesStub.Object);
            var objStub = new Mock<IPackage>();

            objStub.Setup(x => x.Name).Returns("somename");
            objStub.Setup(x => x.Version.Major).Returns(5);
            objStub.Setup(x => x.Version.Minor).Returns(6);
            objStub.Setup(x => x.Version.Patch).Returns(7);
            objStub.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.alpha);

            // Act

            var result = sut.Equals(objStub.Object);

            // Assert

            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_ShouldReturnFalse_WhenPassedObjectIsEqualtoThePackage()
        {
            // Arrange
            string nameTest = "somename";
            var versionStub = new Mock<IVersion>();
            var dependenciesStub = new Mock<ICollection<IPackage>>();

            versionStub.Setup(x => x.Major).Returns(5);
            versionStub.Setup(x => x.Minor).Returns(6);
            versionStub.Setup(x => x.Patch).Returns(7);
            versionStub.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

            var sut = new Package(nameTest, versionStub.Object, dependenciesStub.Object);
            var objStub = new Mock<IPackage>();

            objStub.Setup(x => x.Name).Returns("notsomename");
            objStub.Setup(x => x.Version.Major).Returns(6);
            objStub.Setup(x => x.Version.Minor).Returns(7);
            objStub.Setup(x => x.Version.Patch).Returns(8);
            objStub.Setup(x => x.Version.VersionType).Returns(Enums.VersionType.beta);

            // Act

            var result = sut.Equals(objStub.Object);

            // Assert

            Assert.IsFalse(result);
        }

    }
}
