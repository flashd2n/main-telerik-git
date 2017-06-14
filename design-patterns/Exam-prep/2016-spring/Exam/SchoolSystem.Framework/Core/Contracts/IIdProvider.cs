namespace SchoolSystem.Framework.Core.Contracts
{
    public interface IIdProvider
    {
        int GetNextStudentId();

        int GetNextTeacherID();
    }
}
