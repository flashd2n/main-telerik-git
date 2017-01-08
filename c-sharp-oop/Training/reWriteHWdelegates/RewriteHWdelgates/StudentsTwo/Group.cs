using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTwo
{
    public class Group
    {

        private int groupNumber;
        private string deptName;

        public int GroupNumber
        {
            get { return groupNumber; }
            set { groupNumber = value; }
        }
        public string DeptName
        {
            get { return deptName; }
            set { deptName = value; }
        }
        public Group(int groupNumber, string deptName)
        {
            this.GroupNumber = groupNumber;
            this.DeptName = deptName;
        }


    }
}
