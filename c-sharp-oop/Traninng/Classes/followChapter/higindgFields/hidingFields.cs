using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace higindgFields
{
    class hidingFields
    {
        int myValue = 3;

        static void Main()
        {

            var instance = new hidingFields();
            instance.PrintMyValue();

        }

        void PrintMyValue()
        {
            int myValue = 5;
            Console.WriteLine($"My value is {this.myValue}");
            Console.WriteLine($"My value is {myValue}");
        }


    }
}
