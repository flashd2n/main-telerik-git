using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Disciplines
    {
        private string name;
        private int numberOfLessons;
        private int numberOfExercises;

        public Disciplines(string name, int numberOfLessons, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfExercises = numberOfExercises;
            this.NumberOfLessons = numberOfLessons;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public int NumberOfLessons
        {
            get
            {
                return this.numberOfLessons;
            }
            set
            {
                this.numberOfLessons = value;
            }
        }
        public int NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }
            set
            {
                this.numberOfExercises = value;
            }
        }
    }
}
