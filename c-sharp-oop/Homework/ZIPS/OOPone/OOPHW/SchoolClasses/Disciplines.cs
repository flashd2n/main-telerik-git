using SchoolClasses.Interfaces;
using System.Collections.Generic;

namespace SchoolClasses
{
    class Disciplines : IDiscipline, IComment
    {
        private string name;
        private int numLectures;
        private int numExercises;
        private List<string> myComments;

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
        public List<string> MyComments
        {
            get { return this.myComments; }
            set { this.myComments = value; }
        }

        public void AddComment(string comment)
        {
            this.MyComments.Add(comment);
        }

        public Disciplines(string name, int numLectures, int numExercises) : base()
        {
            this.MyComments = new List<string>();
            this.Name = name;
            this.NumLectures = numLectures;
            this.NumExercises = numExercises;
        }


    }
}
