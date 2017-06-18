using ProjectManager.Framework.Services.Contracts;
using System;

namespace ProjectManager.Framework.Services.Providers
{
    public class DatetimeProvider : IDatetimeProvider
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

        public DateTime AddTime(TimeSpan duration)
        {
            return this.Now.Add(duration);
        }
    }
}
