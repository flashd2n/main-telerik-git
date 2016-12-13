using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exThree
{
    class exerThree
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Company name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Phone Number");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter Fax number");
            string fax = Console.ReadLine();
            Console.WriteLine("Enter website");
            string website = Console.ReadLine();
            Console.WriteLine("Manager");
            string manager = Console.ReadLine();

            Console.WriteLine("The company name is {0}, we are located at {1}. You can reach us at {2} or via fax at {3} or via web at {4}. Our manager is {5}", name, address, phone, fax, website, manager);
        }
    }
}
