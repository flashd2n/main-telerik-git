using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    delegate void MyDelegate(string name);

    class Startup
    {
        static void Main()
        {
            //var del = new MyDelegate(SayHello);
            //del.Invoke();

            MyDelegate del = GiveMeMyDelegate();
            //del();
            TestDelegate(del, "John");

        }

        static void SayHello(string name)
        {
            Console.WriteLine($"Hey There, {name}");
        }

        static void TestDelegate(MyDelegate del, string name)
        {
            del(name);
        }

        static MyDelegate GiveMeMyDelegate()
        {
            return new MyDelegate(SayHello);
        }

    }
}
