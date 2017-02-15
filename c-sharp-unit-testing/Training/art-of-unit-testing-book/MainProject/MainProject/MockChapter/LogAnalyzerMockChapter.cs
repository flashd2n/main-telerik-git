using MainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.MockChapter
{
    public class LogAnalyzerMockChapter
    {
        private IWebService service;
        private IEmailService emailService;

        public LogAnalyzerMockChapter(IWebService service, IEmailService emailService)
        {
            this.service = service;
            this.emailService = emailService;
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                try
                {
                    service.LogError($"Filename is too short: {fileName}");
                }
                catch (Exception e)
                {
                    emailService.SendEmail("somerecipient", "error from webservice", e.Message);
                }


            }
        }
    }
}
