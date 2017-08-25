using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoding
{
    class Startup
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            var frequencies = new Dictionary<char, int>();
            var queue = new BinaryHeap<int>((a, b) => a < b);

            foreach (var ch in line)
            {
                if (frequencies.ContainsKey(ch))
                {
                    frequencies[ch]++;
                }
                else
                {
                    frequencies[ch] = 1;
                }
            }



        }
    }
}
