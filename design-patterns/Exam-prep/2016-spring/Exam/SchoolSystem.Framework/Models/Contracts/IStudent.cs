using System.Collections.Generic;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Models.Contracts
{
    /// <summary>
    /// Represens a Student and extends a Person, has a Grade, a collection of Marks and a way of displaying those marks.
    /// </summary>
    public interface IStudent : IPerson
    {
        Grade Grade { get; set; }

        IList<IMark> Marks { get; }
    }
}
