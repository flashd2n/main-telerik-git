using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Contracts;
using System.Collections.Generic;

namespace SchoolSystem.Framework.Core
{
    public class InMemoryDatabase : IDatabase
    {
        private readonly IDictionary<int, ITeacher> teachers;
        private readonly IDictionary<int, IStudent> students;

        public InMemoryDatabase()
        {
            this.teachers = new Dictionary<int, ITeacher>();
            this.students = new Dictionary<int, IStudent>();
        }

        public IDictionary<int, ITeacher> Teachers
        {
            get { return this.teachers; }
        }

        public IDictionary<int, IStudent> Students
        {
            get { return this.students; }
        }
    }
}
