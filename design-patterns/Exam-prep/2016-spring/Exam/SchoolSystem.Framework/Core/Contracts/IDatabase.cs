using SchoolSystem.Framework.Models.Contracts;
using System.Collections.Generic;

namespace SchoolSystem.Framework.Core.Contracts
{
    public interface IDatabase
    {
        IDictionary<int, ITeacher> Teachers { get; }

        IDictionary<int, IStudent> Students { get; }
    }
}
