using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Factories;
using System;

namespace SchoolSystem.Framework.Core.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        private const int MaxStudentMarksCount = 20;
        private readonly IDatabase database;
        private readonly IModelsFactory modelsFactory;

        public TeacherAddMarkCommand(IDatabase database, IModelsFactory modelsFactory)
        {
            this.database = database;
            this.modelsFactory = modelsFactory;
        }

        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var mark = float.Parse(parameters[2]);

            var student = this.database.Students[studentId];
            var teacher = this.database.Teachers[teacherId];

            if (student.Marks.Count >= MaxStudentMarksCount)
            {
                throw new ArgumentException($"The student's marks count exceed the maximum count of {MaxStudentMarksCount} marks");
            }

            var subject = teacher.Subject;

            var newMark = this.modelsFactory.CreateMark(subject, mark);

            student.Marks.Add(newMark);

            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {mark} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
