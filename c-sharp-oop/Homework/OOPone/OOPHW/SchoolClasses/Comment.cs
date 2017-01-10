using System.Collections.Generic;
using SchoolClasses.Interfaces;

namespace SchoolClasses
{
    class Comment : IComment
    {
        private List<string> myComments;

        public List<string> MyComments
        {
            get { return this.myComments; }
            set { this.myComments = value; }
        }

        public Comment() : this(default(List<string>))
        {
            this.MyComments = new List<string>();
        }
        public Comment(List<string> myComments)
        {
            this.MyComments = myComments;
        }
        public void AddComment(string comment)
        {
            this.MyComments.Add(comment);
        }
    }
}
