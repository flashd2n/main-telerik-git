using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Models.Contracts
{
    /// <summary>
    /// Represents a Teacher and exdents Person, has a Subject and a way of assinging Marks to Students.
    /// </summary>
    public interface ITeacher : IPerson
    {
        Subject Subject { get; set; }
    }
}
