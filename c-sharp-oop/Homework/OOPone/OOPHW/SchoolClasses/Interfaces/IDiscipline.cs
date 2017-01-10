using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Interfaces
{
    interface IDiscipline
    {
        string Name { get; set; }
        int NumLectures { get; set; }
        int NumExercises { get; set; }
    }
}
