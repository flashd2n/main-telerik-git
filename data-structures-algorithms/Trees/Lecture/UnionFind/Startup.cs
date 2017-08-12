using System;

namespace UnionFind
{
    class Startup
    {
        static void Main()
        {

            var uf = new UnionFind(32);

            uf.Print();
            Console.WriteLine(uf.Find(31));
        }
    }
}
