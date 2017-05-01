using StaticClassDependencyInversion.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClassDependencyInversion
{
    public class MailSender
    {
        private ILogger logger;

        public MailSender(ILogger logger)
        {
            this.logger = logger;
        }


        public void SendMail()
        {
            // do mail sending stuff then log

            this.logger.WriteStuff("mail sent");
        }

    }
}
