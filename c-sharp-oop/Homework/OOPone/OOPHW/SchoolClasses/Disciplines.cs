using SchoolClasses.Interfaces;

namespace SchoolClasses
{
    class Disciplines : Comment, IDiscipline
    {
        private string name;
        private int numLectures;
        private int numExercises;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int NumLectures
        {
            get { return numLectures; }
            set { numLectures = value; }
        }
        public int NumExercises
        {
            get { return numExercises; }
            set { numExercises = value; }
        }

        public Disciplines(string name, int numLectures, int numExercises) : base()
        {
            this.Name = name;
            this.NumLectures = numLectures;
            this.NumExercises = numExercises;
        }


    }
}
