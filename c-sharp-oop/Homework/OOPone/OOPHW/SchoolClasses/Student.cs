using SchoolClasses.Interfaces;

namespace SchoolClasses
{
    class Student : People, IStudent
    {
        private readonly int classNum;
        private static int count = 1;

        public int ClassNum
        {
            get { return classNum; }
        }

        public Student(string name) : base(name)
        {
            this.classNum = count;
            ++count;
        }

    }
}
