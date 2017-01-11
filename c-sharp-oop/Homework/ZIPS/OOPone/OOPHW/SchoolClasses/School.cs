using SchoolClasses.Interfaces;
using System.Collections.Generic;

namespace SchoolClasses
{
    class School : ISchool
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
