using NUnit.Framework;
using MainProject;
using System;

namespace LogAn.UnitTests
{
    [TestFixture]
    class LogAnalyzerTests
    {
        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            // Arrange
            LogAnalyzer analyzer = new LogAnalyzer();

            // Act
            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");

            //Assert
            Assert.False(result);

        }

        [TestCase("Goodextensionnameuppercase.SLF", true)]
        [TestCase("Goodextensionnamelowercase.slf", true)]
        public void IsValidLogFileNAme_GoodExtension_ReturnsTrue(string fileName, bool expected)
        {
            // Arrange

            var sut = new LogAnalyzer();

            // Act

            var result = sut.IsValidLogFileName(fileName);

            // Assert

            Assert.AreEqual(result, expected);

        }

        [TestCase("filewithbadextension.foo", false)]
        public void IsValidLogFileName_BadExtension_ReturnsFalse(string fileName, bool expected)
        {
            // Arrange

            var sut = new LogAnalyzer();

            // Act

            var result = sut.IsValidLogFileName(fileName);

            //Assert

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void IsValidLogFileName_EmptyString_Throws()
        {
            // Arrange

            var sut = new LogAnalyzer();
            
            // Act & Assert

            var ex = Assert.Catch<ArgumentException>(() => sut.IsValidLogFileName(""));
            StringAssert.Contains("Filename cannot be empty.", ex.Message);
        }

        [Test]
        [Ignore("There is a problem with this test")]
        public void Some_IrrelevantTest_ThatShouldBeIgnored()
        {

        }

        [Test]
        public void IsValidFileName_WhenCalledBadValue_ChangesWasLastFileNameValidToFalse()
        {
            // Arrange
            var sut = new LogAnalyzer();

            // Act

            sut.IsValidLogFileName("badfilename.foo");

            // Assert

            Assert.False(sut.WasLastFileNameValid);
        }

        [Test]
        public void IsValidFileName_WhenCalledGoodValue_ChangesWasLastFileNameValidToTrue()
        {
            // Arrange
            var sut = new LogAnalyzer();

            // Act

            sut.IsValidLogFileName("goodfilename.slf");

            // Assert

            Assert.True(sut.WasLastFileNameValid);
        }
    }
}
