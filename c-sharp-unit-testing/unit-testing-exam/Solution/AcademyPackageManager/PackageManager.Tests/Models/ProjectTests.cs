using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageManager.Models;
using PackageManager.Repositories.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Models
{
    [TestFixture]
    public class ProjectTests
    {
        [Test]
        public void Constructor_ShouldInitiateNewPackageRepository_WhenNoPackagesPassed()
        {
            // Arrange

            string nameTest = "somename";
            string locationTest = "somelocation";

            // Act

            var sut = new Project(nameTest, locationTest);

            // Assert

            Assert.IsInstanceOf<IRepository<IPackage>>(sut.PackageRepository);

        }

        [Test]
        public void Constructor_ShouldCorrectlyAssignPackages_WhenValidPackagesArePassed()
        {
            // Arrange

            string nameTest = "somename";
            string locationTest = "somelocation";
            var packagesStub = new Mock<IRepository<IPackage>>();

            // Act

            var sut = new Project(nameTest, locationTest, packagesStub.Object);

            // Assert

            Assert.AreEqual(packagesStub.Object, sut.PackageRepository);

        }

        [Test]
        public void Property_ShouldCorrectlyAssignNameValue_WhenValidValueIsPassed()
        {
            // Arrange

            string nameTest = "somename";
            string locationTest = "somelocation";
            var packagesStub = new Mock<IRepository<IPackage>>();

            // Act

            var sut = new Project(nameTest, locationTest, packagesStub.Object);

            // Assert

            Assert.AreEqual(nameTest, sut.Name);
        }

        [Test]
        public void Property_ShouldThrowArgumentNullException_WhenNullNameValueIsPassed()
        {
            // Arrange

            string nameTest = null;
            string locationTest = "somelocation";
            var packagesStub = new Mock<IRepository<IPackage>>();

            // Act & Assert

            Assert.Catch<ArgumentNullException>(() => new Project(nameTest, locationTest, packagesStub.Object));
        }

        [Test]
        public void Property_ShouldCorrectlyAssignLocationValue_WhenValidValueIsPassed()
        {
            // Arrange

            string nameTest = "somename";
            string locationTest = "somelocation";
            var packagesStub = new Mock<IRepository<IPackage>>();

            // Act

            var sut = new Project(nameTest, locationTest, packagesStub.Object);

            // Assert

            Assert.AreEqual(locationTest, sut.Location);
        }

        [Test]
        public void Property_ShouldThrowArgumentNullException_WhenNullLocationValueIsPassed()
        {
            // Arrange

            string nameTest = "somelocation";
            string locationTest = null;
            var packagesStub = new Mock<IRepository<IPackage>>();

            // Act & Assert

            Assert.Catch<ArgumentNullException>(() => new Project(nameTest, locationTest, packagesStub.Object));
        }
    }
}
