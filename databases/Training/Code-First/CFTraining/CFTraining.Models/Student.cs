namespace CFTraining.Models
{
    public class Student
    {
        public Student() { }

        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public virtual StudentAddress Address { get; set; }

    }
}
