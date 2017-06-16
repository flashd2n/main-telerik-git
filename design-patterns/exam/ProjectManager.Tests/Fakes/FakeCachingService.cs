using ProjectManager.Framework.Services;
using System;
using System.Collections.Generic;
using ProjectManager.Framework.Services.Contracts;

namespace ProjectManager.Tests.Fakes
{
    public class FakeCachingService : CachingService
    {
        public FakeCachingService(TimeSpan duration, IDatetimeProvider datetimeProvider) : base(duration, datetimeProvider)
        {
        }

        public IDictionary<string, object> Cache
        {
            get
            {
                return this.cache;
            }
        }
    }
}
