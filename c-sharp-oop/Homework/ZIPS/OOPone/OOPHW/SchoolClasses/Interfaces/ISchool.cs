using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Interfaces
{
    interface ISchool
    {
        List<Class> SchoolClass { get; set; }
        void AddClass(Class schoolClass);
    }
}
