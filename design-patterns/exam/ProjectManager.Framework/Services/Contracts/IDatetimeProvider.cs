using System;

namespace ProjectManager.Framework.Services.Contracts
{
    public interface IDatetimeProvider
    {
        DateTime Now { get; }
        DateTime AddTime(TimeSpan duration);
    }
}
