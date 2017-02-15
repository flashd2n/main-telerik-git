using MainProject.MockChapter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests.MockChapterTests
{
    [TestFixture]
    public class LogAnalyzerMochChapterTests
    {
        //[Test]
        //public void Should_SendLogToWebservice_WhenInvalidFilenameIsPassed()
        //{

        //    // Arrange

        //    var webServiceMock = new FakeWebService();
        //    var sut = new LogAnalyzerMockChapter(webServiceMock);

        //    // Act

        //    sut.Analyze("ss");

        //    // Assert

        //    StringAssert.Contains("Filename is too short", webServiceMock.lastError);

        //}


        [Test]
        public void Should_SendMessageToEmailService_WhenWebServiceThrows()
        {
            // Arrange

            var webServiceStub = new FakeWebService();
            webServiceStub.exception = new Exception("Exception Message");
            var emailServiceMock = new FakeEmailService();
            var sut = new LogAnalyzerMockChapter(webServiceStub, emailServiceMock);

            // Act

            sut.Analyze("ss");

            // Assert

            StringAssert.Contains("To: somerecipient", emailServiceMock.lastMessage);

        }
    }
}
