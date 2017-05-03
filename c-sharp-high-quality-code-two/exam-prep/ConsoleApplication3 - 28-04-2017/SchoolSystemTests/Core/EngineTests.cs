using Moq;
using NUnit.Framework;
using SchoolManagementSystem;
using SchoolManagementSystem.Interfaces;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemTests
{
    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void Constructor_ShouldThrow_WhenInvalidPrinterIsPassed()
        {
            // Arrange
            var printerStub = new Mock<IPrinter>();

            // Act and Assert
            Assert.Catch(() => new Engine(null, printerStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrow_WhenInvalidReaderIsPassed()
        {
            // Arrange
            var readerStub = new Mock<IReader>();

            // Act and Assert
            Assert.Catch(() => new Engine(readerStub.Object, null));
        }

        [Test]
        public void Constructor_ShouldNotThrow_WhenValidParametersArePassed()
        {
            // Arrange
            var readerStub = new Mock<IReader>();
            var printerStub = new Mock<IPrinter>();

            // Act and assert

            Assert.DoesNotThrow(() => new Engine(readerStub.Object, printerStub.Object));
        }

        [Test]
        public void Constructor_ShouldCorrectlyAssignTeachersDictionary_WhenValidParametersArePassed()
        {
            // Arrange
            var readerStub = new Mock<IReader>();
            var printerStub = new Mock<IPrinter>();

            // Act
            var sut = new Engine(readerStub.Object, printerStub.Object);

            //Assert
            Assert.IsNotNull(Engine.Teachers);
        }

        [Test]
        public void Constructor_ShouldCorrectlyAssignStudentsDictionary_WhenValidParametersArePassed()
        {
            // Arrange
            var readerStub = new Mock<IReader>();
            var printerStub = new Mock<IPrinter>();

            // Act
            var sut = new Engine(readerStub.Object, printerStub.Object);

            //Assert
            Assert.IsNotNull(Engine.Students);
        }

        [Test]
        public void Start_DoesNotThrow_WhenOneValidCommadIsGiven()
        {
            // Arrange
            var readerStub = new Mock<IReader>();
            var printerStub = new Mock<IPrinter>();
            var command = "CreateStudent Pesho Peshev 1";
            var termination = "End";

            var sut = new Engine(readerStub.Object, printerStub.Object);
            
            readerStub.SetupSequence(x => x.ReadLine()).Returns(command).Returns(termination);

            Assert.DoesNotThrow(() => sut.Start());
        }

        //[Test, Timeout(2000)]
        //public void Start_ShouldNotFallIntoInfiniteLoop_WhenPassedValidTerminationCommand()
        //{
        //    // Arrange
        //    var command = "End";

        //    var readerStub = new Mock<IReader>();
        //    readerStub.Setup(x => x.ReadLine()).Returns(command);

        //    var printerStub = new Mock<IPrinter>();

        //    var sut = new Engine(readerStub.Object, printerStub.Object);

        //    // Act

        //    sut.Start();
        //}
    }
}
