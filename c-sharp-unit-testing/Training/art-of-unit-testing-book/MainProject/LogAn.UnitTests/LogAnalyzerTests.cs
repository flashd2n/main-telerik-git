using NUnit.Framework;
using MainProject;

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

        [TestCase("Goodextensionnameuppercase.SLF")]
        [TestCase("Goodextensionnamelowercase.slf")]
        public void IsValidLogFileNAme_GoodExtension_ReturnsTrue(string fileName)
        {
            // Arrange

            var sut = new LogAnalyzer();

            // Act

            var result = sut.IsValidLogFileName(fileName);

            // Assert

            Assert.True(result);

        }


    }
}
