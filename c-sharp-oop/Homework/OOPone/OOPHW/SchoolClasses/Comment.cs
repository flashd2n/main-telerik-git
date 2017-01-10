using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses
{
    class Comment
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
