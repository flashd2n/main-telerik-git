using MainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests.MockChapterTests
{
    public class FakeEmailService : IEmailService
    {
        public string lastMessage;

        public void SendEmail(string to, string subject, string body)
        {
            this.lastMessage = string.Format($"To: {to} Subject: {subject} Body: {body}");
        }
    }
}
