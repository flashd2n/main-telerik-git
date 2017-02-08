using MainProject;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    class LogAnalyzerTestsSetUpTearDown
    {
        private LogAnalyzer analyzer = null;
        [SetUp]
        public void Setup()
        {
            analyzer = new LogAnalyzer();
        }

        [TestCase("validfilenamelowercaseextension.slf", true)]
        public void IsValidFileName_ValidLowerCaseFileName_ReturnsTrue(string filename, bool expected)
        {
            //Arrange -> done in setup

            //Act

            var result = analyzer.IsValidLogFileName(filename);

            //Asser

            Assert.AreEqual(result, expected);
        }

        [TestCase("validfilenameuppercaseextension.slf", true)]
        public void IsValidFileName_ValidUpperCaseFileName_ReturnsTrue(string filename, bool expected)
        {
            //Arrange -> done in setup

            //Act

            var result = analyzer.IsValidLogFileName(filename);

            //Asser

            Assert.AreEqual(result, expected);
        }

        [TearDown]
        public void Teardown()
        {
            analyzer = null;
        }
    }
}
