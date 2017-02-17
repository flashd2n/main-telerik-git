using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models
{
    [TestFixture]
    public class PackageVersionTests
    {
        [Test]
        public void Constructor_ShouldProperlySetMajorValue_WhenValidValueIsPassed()
        {
            // Arrange
            var major = 5;
            var sut = new PackageVersion(major, 5, 5, Enums.VersionType.alpha);

            // Act & Assert

            Assert.AreEqual(major, sut.Major);
        }

        [Test]
        public void Constructor_ShouldProperlySetMinorValue_WhenValidValueIsPassed()
        {
            // Arrange
            var minor = 5;
            var sut = new PackageVersion(5, minor, 5, Enums.VersionType.alpha);

            // Act & Assert

            Assert.AreEqual(minor, sut.Minor);
        }

        [Test]
        public void Constructor_ShouldProperlySetPatchValue_WhenValidValueIsPassed()
        {
            // Arrange
            var patch = 5;
            var sut = new PackageVersion(5, 5, patch, Enums.VersionType.alpha);

            // Act & Assert

            Assert.AreEqual(patch, sut.Patch);
        }

        [Test]
        public void Constructor_ShouldProperlySetTypeValue_WhenValidValueIsPassed()
        {
            // Arrange
            var type = Enums.VersionType.alpha;
            var sut = new PackageVersion(5, 5, 5, type);

            // Act & Assert

            Assert.AreEqual(type, sut.VersionType);
        }

        [Test]
        public void Property_ShouldCorrectlyAssignMajorValue_WhenValidValueIsPassed()
        {
            // Arrange

            var sut = new PackageVersion(5, 5, 5, Enums.VersionType.alpha);

            // Act & Assert

            Assert.AreEqual(5, sut.Major);
            
        }

        [Test]
        public void Property_ShouldThrowArgumentException_WhenInvalidMajorValueIsPassed()
        {
            // Arrange

            var invalidMajor = -1;

            // Act & Assert

            Assert.Catch<ArgumentException>(() => new PackageVersion(invalidMajor, 5, 5, Enums.VersionType.alpha));

        }

        [Test]
        public void Property_ShouldCorrectlyAssignMinorValue_WhenValidValueIsPassed()
        {
            // Arrange

            var sut = new PackageVersion(5, 5, 5, Enums.VersionType.alpha);

            // Act & Assert

            Assert.AreEqual(5, sut.Minor);

        }

        [Test]
        public void Property_ShouldThrowArgumentException_WhenInvalidMinorValueIsPassed()
        {
            // Arrange

            var invalidMinor = -1;

            // Act & Assert

            Assert.Catch<ArgumentException>(() => new PackageVersion(invalidMinor, 5, 5, Enums.VersionType.alpha));

        }

        [Test]
        public void Property_ShouldCorrectlyAssignPatchValue_WhenValidValueIsPassed()
        {
            // Arrange

            var sut = new PackageVersion(5, 5, 5, Enums.VersionType.alpha);

            // Act & Assert

            Assert.AreEqual(5, sut.Patch);

        }

        [Test]
        public void Property_ShouldThrowArgumentException_WhenInvalidPatchValueIsPassed()
        {
            // Arrange

            var invalidPatch = -1;

            // Act & Assert

            Assert.Catch<ArgumentException>(() => new PackageVersion(invalidPatch, 5, 5, Enums.VersionType.alpha));

        }

        [Test]
        public void Property_ShouldCorrectlyAssignVersionTypeValue_WhenValidValueIsPassed()
        {
            // Arrange

            var sut = new PackageVersion(5, 5, 5, Enums.VersionType.alpha);

            // Act & Assert

            Assert.AreEqual(Enums.VersionType.alpha, sut.VersionType);

        }

        [Test]
        public void Property_ShouldThrowArgumentException_WhenInvalidVersionTypeIsPassed()
        {
            // Arrange

            var versionTypeStub = (Enums.VersionType)8;

            // Act & Assert

            Assert.Catch<ArgumentException>(() => new PackageVersion(5, 5, 5, versionTypeStub));

        }




    }
}
