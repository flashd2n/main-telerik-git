using System;

namespace companyInformation
{
    class companyInfo
    {
        static void Main(string[] args)
        {
            string compName = Console.ReadLine();
            string address = Console.ReadLine();
            string number = Console.ReadLine();
            string fax = Console.ReadLine();
            string website = Console.ReadLine();
            string managerName = Console.ReadLine();
            string managerLast = Console.ReadLine();
            string age = Console.ReadLine();
            string managerPhone = Console.ReadLine();

            Console.WriteLine("{0}\nAddress: {1}\nTel. {2}\nFax: {3}\nWeb site: {4}\nManager: {5} {6} (age: {7}, tel. {8})", compName, address, number, fax.Length == 0 ? "(no fax)" : fax, website, managerName, managerLast, age, managerPhone);


        }
    }
}
