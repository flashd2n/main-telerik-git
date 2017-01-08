using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Teacher
    {
        private string name;
        private List<Disciplines> disciplines = new List<Disciplines>();

        public Teacher(string name)
        {
            this.Name = name;
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
        public List<Disciplines> Disciplines
        {
            get
            {
                return this.disciplines;
            }
        }
        public void AddDiscipline(Disciplines discipline)
        {
            this.disciplines.Add(discipline);
        }

        public void PrintInfo()
        {
            Console.Write($"{this.Name}, who teaches: ");
            for (int i = 0; i < this.disciplines.Count; i++)
            {
                Console.Write($"{this.disciplines[i].Name} with {this.disciplines[i].NumberOfExercises} Exercises and {this.disciplines[i].NumberOfLessons} Lessons");
                Console.WriteLine("");
            }
        }
    }
}
