using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetCustomExceptions
{
    class Startup
    {
        static void Main(string[] args)
        {

            try
            {
                throw new MyCustomException<string>("hahahah");
            }
            catch (MyCustomException<string> exc)
            {
                exc.MyExcProp = "asd";
                bool excMethod = exc.DisplayStuf(32, 5);
                Console.WriteLine(exc.Message);
                Console.WriteLine(excMethod);
            }

        }
    }
}
