using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses
{
    class School
    {
        private List<Class> schoolClas;

        public List<Class> SchoolClass
        {
            get { return this.schoolClas; }
            set { this.schoolClas = value; }
        }

        public School() : this(default(List<Class>))
        {
            this.SchoolClass = new List<Class>();
        }
        public School(List<Class> schoolClass)
        {
            this.SchoolClass = schoolClass;
        }


        public void AddClass(Class schoolClass)
        {
            this.SchoolClass.Add(schoolClass);
        }

    }
}
