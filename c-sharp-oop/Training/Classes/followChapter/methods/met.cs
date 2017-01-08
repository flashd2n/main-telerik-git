using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methods
{
    class met
    {
        int age = 2;

        static void Main()
        {
            var test = new met();
            var testTwo = new met();
            Console.WriteLine(test.age);
            Console.WriteLine("=====");
            Console.WriteLine(test.GetAge());
            Console.WriteLine("=====");
            test.MakeOlder();
            Console.WriteLine(test.GetAge());
            Console.WriteLine(testTwo.GetAge());
            test.PrintAge();
            testTwo.PrintAge();
            
        }
        

        public int GetAge()
        {
            return this.age;
        }

        public void MakeOlder()
        {
            this.age++;
        }

        public void PrintAge()
        {
            int myAge = this.GetAge();
            //int myAge = this.age; // this is practically the same
            Console.WriteLine($"My age is {myAge}");
            //Console.WriteLine($"My age is {this.age}"); // also practically the same
        }
    }
}
