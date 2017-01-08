using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Startup
    {
        static void Main()
        {
            var assembly = Assembly.GetExecutingAssembly();

            Console.WriteLine(assembly.FullName);

            var types = assembly.GetTypes();

            //for (int i = 0; i < types.Length; i++)
            //{
            //    Console.WriteLine(types[i]);
            //}


            foreach (var type in types)
            {
                Console.WriteLine(type);

                var properties = type.GetProperties();

                foreach (var prop in properties)
                {
                    Console.WriteLine($"\t{prop}");
                }

                var fields = type.GetFields();

                foreach (var field in fields)
                {
                    Console.WriteLine($"\tFields: {field}");
                }

                var methods = type.GetMethods();

                foreach (var method in methods)
                {
                    Console.WriteLine($"\tMethods: {method}");
                }
                
            }
        }
    }
}
