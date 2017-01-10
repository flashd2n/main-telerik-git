using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Interfaces
{
    interface ITeacher
    {
        List<Disciplines> Disciplines { get; set; }
        void AddDiscipline(Disciplines discipline);
    }
}
