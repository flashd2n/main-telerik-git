using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examples
{
    class exampless
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter person name: ");
            //string person = Console.ReadLine();

            //Console.Write("Enter book name: ");
            //string book = Console.ReadLine();

            //string from = "Author's Team";

            //Console.WriteLine("{0}Dear, {1}", '\t', person);
            //Console.WriteLine("We are pleased to inform you that \"{0}\" is the best bulgarian book.\nThe authors of the book wish you good luck Readers!\n\tYours,\n\t{1}", book, from);

            Console.WriteLine("This program calculates the area of a rectangle or a triangle");
            Console.WriteLine("Enter a and b for a rectangle o a and h for a triangle");

            int a;
            int b;

            bool aIs = int.TryParse(Console.ReadLine(), out a);
            if (aIs)
            {
                bool bIs = int.TryParse(Console.ReadLine(), out b);
                if (bIs)
                {
                    Console.WriteLine("For the area of a rectangle press 1 or for the area of a triangle press 2");

                    int choice;
                    bool isChoice = int.TryParse(Console.ReadLine(), out choice);

                    if (isChoice)
                    {
                        if (choice == 1 || choice == 2)
                        {
                            double area = (a * b) / choice;

                            Console.WriteLine("The area is {0}", area);
                        }
                        else
                        {
                            Console.WriteLine("Enter 1 or 2, please");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid number");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number");
                }
            }
            else
            {
                Console.WriteLine("Invalid number");
            }
        }
    }
}
