using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerClasses
{
    class Program
    {
        private string name;

        private Program(string name)
        {
            this.name = name;
        }

        private class NestedClass
        {
            private string name;
            private Program parent;

            public NestedClass(Program parent, string name)
            {
                this.parent = parent;
                this.name = name;
            }

            public void PrintNames()
            {
                Console.WriteLine($"Nested name: {this.name}");
                Console.WriteLine($"Outer name: {this.parent.name}");
            }

        }

        //static void Main()
        //{
        //    var outerClass = new Program("Kalin");
        //    var nestedClass = new Program.NestedClass(outerClass, "Gosho");
        //    nestedClass.PrintNames();


        //}


    }
}
