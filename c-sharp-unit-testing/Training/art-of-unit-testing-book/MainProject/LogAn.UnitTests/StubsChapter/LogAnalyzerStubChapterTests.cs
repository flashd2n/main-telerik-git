using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MainProject;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerStubChapterTests
    {

        //Constructor Dependency Injection Tests

        //[Test]
        //public void Should_ReturnTrue_WhenValidFileNameExtensionIsPassed()
        //{
        //    // Arrange
        //    var fileExtensionManagerStub = new FakeExtensionManager();
        //    fileExtensionManagerStub.willBeValid = true;
        //    var sut = new LogAnalyzerStubChapter(fileExtensionManagerStub);

        //    // Act

        //    var result = sut.IsValidLogFileName("validextension");

        //    //Assert

        //    Assert.True(result);
        //}

        //[Test]
        //public void Should_Throw_WhenInValidFileNameExtensionIsPassed()
        //{
        //    // Arrange
        //    var fileExtensionManagerStub = new FakeExtensionManager();
        //    fileExtensionManagerStub.willThrow = new Exception();
        //    var sut = new LogAnalyzerStubChapter(fileExtensionManagerStub);

        //    // Act

        //    var result = sut.IsValidLogFileName("validextension");

        //    // Assert

        //    Assert.False(result);
        //}




        //// Property Dependency Injection Tests

        //[Test]
        //public void Should_ReturnTrue_WhenValidFileExtensionIsPassed()
        //{
        //    // Arrange
        //    var fileExtensionManagerStub = new FakeExtensionManager();
        //    fileExtensionManagerStub.willBeValid = true;

        //    var sut = new LogAnalyzerStubChapter();
        //    sut.Manager = fileExtensionManagerStub;

        //    // Act

        //    var result = sut.IsValidLogFileName("valid.name");

        //    // Assert

        //    Assert.True(result);
        //}


        //// Injecting Dependency by Faking the Factory

        //[Test]
        //public void Should_ReturnTrue_WhenValidFileNameExtensionIsPassed()
        //{
        //    // Arrange

        //    var extensionManagerStub = new FakeExtensionManager();
        //    extensionManagerStub.willBeValid = true;
        //    FileExtensionManagerFactory.SetManager(extensionManagerStub);
        //    var sut = new LogAnalyzerStubChapter();

        //    // Act

        //    var result = sut.IsValidFileName("valid name");

        //    // Assert

        //    Assert.True(result);

        //}


        
        // Extract And Override

        [Test]
        public void Should_ReturnTrue_WhenValidFileNameExtensionIsPassed()
        {
            // Arrange

            var sut = new FakeLogAnalyzerStubChapter();
            var extensionManagerStub = new FakeExtensionManager();
            extensionManagerStub.willBeValid = true;
            sut.manager = extensionManagerStub;

            // Act 

            var result = sut.IsValidFileName("valid name");

            // Assert

            Assert.True(result);
            
        }

    }
}
