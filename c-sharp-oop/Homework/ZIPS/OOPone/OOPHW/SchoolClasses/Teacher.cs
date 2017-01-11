using SchoolClasses.Interfaces;
using System.Collections.Generic;

namespace SchoolClasses
{
    class Teacher : People, ITeacher
    {
        private List<Disciplines> disciplines;

        public List<Disciplines> Disciplines
        {
            get { return disciplines; }
            set { disciplines = value; }
        }

        public Teacher(string name) : base(name)
        {
            this.Disciplines = new List<Disciplines>();
        }
        public Teacher(string name, List<Disciplines> disciplines) : base(name)
        {
            this.Disciplines = disciplines;
        }

        public void AddDiscipline(Disciplines discipline)
        {
            this.Disciplines.Add(discipline);
        }

    }
}
