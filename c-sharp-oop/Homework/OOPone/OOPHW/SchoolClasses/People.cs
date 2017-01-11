using SchoolClasses.Interfaces;
using System.Collections.Generic;

namespace SchoolClasses
{
    class People : IPeople, IComment
    {
        private string name;
        private List<string> myComments;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<string> MyComments
        {
            get { return this.myComments; }
            set { this.myComments = value; }
        }

        public void AddComment(string comment)
        {
            this.MyComments.Add(comment);
        }

        public People(string name) : base()
        {
            this.MyComments = new List<string>();
            this.Name = name;
        }



    }
}
