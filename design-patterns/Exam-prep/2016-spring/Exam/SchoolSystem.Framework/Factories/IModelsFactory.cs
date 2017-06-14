using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Framework.Factories
{
    public interface IModelsFactory
    {
        IMark CreateMark(Subject subject, float value);
        IStudent CreateStudent(string firstName, string lastName, Grade grade);
        ITeacher CreateTeacher(string firstName, string lastName, Subject subject);
    }
}
