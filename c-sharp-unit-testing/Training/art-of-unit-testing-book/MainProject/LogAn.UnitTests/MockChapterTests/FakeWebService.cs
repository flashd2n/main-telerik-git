using MainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests.MockChapterTests
{
    public class FakeWebService : IWebService
    {
        public string lastError;
        public Exception exception = null;

        public void LogError(string message)
        {
            if (exception != null)
            {
                throw this.exception;
            }

            lastError = message;
        }
    }
}
