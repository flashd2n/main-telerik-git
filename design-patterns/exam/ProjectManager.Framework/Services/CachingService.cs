using System;
using System.Collections.Generic;
using Bytes2you.Validation;
using ProjectManager.Framework.Services.Contracts;

namespace ProjectManager.Framework.Services
{
    public class CachingService : ICachingService
    {
        private readonly TimeSpan duration;
        private DateTime timeExpiring;
        private readonly IDatetimeProvider datetimeProvider;

        protected IDictionary<string, object> cache;

        public CachingService(TimeSpan duration, IDatetimeProvider datetimeProvider)
        {
            Guard.WhenArgument(duration, "duration").IsLessThan(TimeSpan.Zero).Throw();
            Guard.WhenArgument(datetimeProvider, "datetimeProvider").IsNull().Throw();

            this.duration = duration;
            this.datetimeProvider = datetimeProvider;

            this.timeExpiring = this.datetimeProvider.Now;
            this.cache = new Dictionary<string, object>();
        }
        
        public bool IsExpired
        {
            get
            {
                if (this.timeExpiring < this.datetimeProvider.Now)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void ResetCache()
        {
            this.cache = new Dictionary<string, object>();
            this.timeExpiring = this.datetimeProvider.AddTime(duration);
        }

        public object GetCacheValue(string className, string methodName)
        {
            return this.cache[$"{className}.{methodName}"];
        }

        public void AddCacheValue(string className, string methodName, object value)
        {
            this.cache.Add($"{className}.{methodName}", value);
        }
    }
}
