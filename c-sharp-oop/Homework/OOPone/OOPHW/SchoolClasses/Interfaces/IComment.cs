using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Interfaces
{
    interface IComment
    {
        List<string> MyComments { get; set; }
        void AddComment(string comment);
    }
}
