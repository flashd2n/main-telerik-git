using SchoolClasses.Interfaces;

namespace SchoolClasses
{
    class People : Comment, IPeople
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public People(string name) : base()
        {
            this.Name = name;
        }

    }
}
