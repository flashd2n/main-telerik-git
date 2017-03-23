using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }

        public bool CompareAge(Student otherStudent)
        {
            var firstDateString = this.OtherInfo.Substring(this.OtherInfo.Length - 10);
            DateTime firstDate = DateTime.Parse(firstDateString);

            var secondDateString = otherStudent.OtherInfo.Substring(otherStudent.OtherInfo.Length - 10);
            DateTime secondDate = DateTime.Parse(secondDateString);

            var result = firstDate < secondDate;
            return result;
        }
    }
}
