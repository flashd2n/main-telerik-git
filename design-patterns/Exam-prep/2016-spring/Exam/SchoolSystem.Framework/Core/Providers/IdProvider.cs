using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Providers
{
    public class PersonIdProvider : IIdProvider
    {
        private int currentStudentId = 0;
        private int currentTeacherId = 0;

        public int GetNextStudentId()
        {
            var nextStudentId = currentStudentId;
            ++currentStudentId;
            return nextStudentId;
        }

        public int GetNextTeacherID()
        {
            var nextTeacherId = currentTeacherId;
            ++currentTeacherId;
            return nextTeacherId;
        }

    }
}
